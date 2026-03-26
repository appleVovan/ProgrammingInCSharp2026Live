using KMA.ProgrammingInChsarp2026.LecturerManager.DBModels;
using Microsoft.Maui.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace KMA.ProgrammingInCSharp2026.LecturerManager.Storage
{
    public class FileStorageContext : IStorageContext
    {
        private static readonly string DatabasePath = Path.Combine(FileSystem.AppDataDirectory, "File Storage 1");

        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1,1);

        private async Task Init()
        {
            await _semaphore.WaitAsync();

            try
            {
                if (!Directory.Exists(DatabasePath))
                    await CreateMockStorage();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        private async Task CreateMockStorage()
        {
            Directory.CreateDirectory(DatabasePath);

            var inMemoryStorage = new InMemoryStorageContext();

            var tasks = new List<Task>();

            await foreach (var department in inMemoryStorage.GetDepartmentsAsync())
            {
                Directory.CreateDirectory(Path.Combine(DatabasePath, department.Id.ToString()));

                tasks.Add(File.WriteAllTextAsync(DepartmentFilePath(department.Id), JsonSerializer.Serialize(department)));

                foreach(var lecturer in await inMemoryStorage.GetLecturersByDepartmentAsync(department.Id))
                {
                    tasks.Add(File.WriteAllTextAsync(LecturerFilePath(department.Id, lecturer.Id), JsonSerializer.Serialize(lecturer)));
                }
            }
            await Task.WhenAll(tasks);
        }

        private string DepartmentFilePath(Guid departmentId)
        {
            return Path.Combine(DatabasePath, departmentId.ToString() + ".json");
        }
        private string DepartmentDirectoryPath(Guid departmentId)
        {
            return Path.Combine(DatabasePath, departmentId.ToString());
        }
        private string LecturerFilePath(Guid departmentId, Guid lecturerId)
        {
            return LecturerFilePath(DepartmentDirectoryPath(departmentId), lecturerId);
        }
        private string LecturerFilePath(string departmentFolderPath, Guid lecturerId)
        {
            return Path.Combine(departmentFolderPath, lecturerId.ToString() + ".json");
        }

        public async Task<DepartmentDBModel> GetDepartmentAsync(Guid departmentId)
        {
            await Init();
            var filePath = DepartmentFilePath(departmentId);
            if (!File.Exists(filePath))
                return null;
            var json = await File.ReadAllTextAsync(filePath);
            return JsonSerializer.Deserialize<DepartmentDBModel>(json);
        }

        public async IAsyncEnumerable<DepartmentDBModel> GetDepartmentsAsync()
        {
            await Init();
            foreach (var file in Directory.GetFiles(DatabasePath, "*.json"))
            {
                var json = await File.ReadAllTextAsync(file);
                yield return JsonSerializer.Deserialize<DepartmentDBModel>(json);
            }
        }

        public async Task<LecturerDBModel> GetLecturerAsync(Guid lecturerId)
        {
            await Init();
            foreach (var directory in Directory.GetDirectories(DatabasePath))
            {
                var filePath = LecturerFilePath(directory, lecturerId);
                if (!File.Exists(filePath))
                    continue;
                var json = await File.ReadAllTextAsync(filePath);
                return JsonSerializer.Deserialize<LecturerDBModel>(json);
            }
            return null;
        }

        public async Task<IEnumerable<LecturerDBModel>> GetLecturersByDepartmentAsync(Guid departmentId)
        {
            await Init();
            var lecturers = new List<LecturerDBModel>();
            var departmentDirectory = DepartmentDirectoryPath(departmentId);
            if (!Directory.Exists(departmentDirectory))
                return lecturers;
            foreach (var file in Directory.GetFiles(departmentDirectory, "*.json"))
            {
                var json = await File.ReadAllTextAsync(file);
                lecturers.Add(JsonSerializer.Deserialize<LecturerDBModel>(json));
            }
            return lecturers;
        }

        public async Task<int> GetLecturersCountByDepartmentAsync(Guid departmentId)
        {
            await Init();
            var departmentDirectory = DepartmentDirectoryPath(departmentId);
            if (!Directory.Exists(departmentDirectory))
                return 0;
            return Directory.GetFiles(departmentDirectory).Length;
        }
    }
}
