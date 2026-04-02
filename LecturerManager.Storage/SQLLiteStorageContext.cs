using KMA.ProgrammingInChsarp2026.LecturerManager.DBModels;
using Microsoft.Maui.Storage;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace KMA.ProgrammingInCSharp2026.LecturerManager.Storage
{
    public class SQLLiteStorageContext : IStorageContext
    {
        private const string DatabaseFileName = "lecturer_manager.db3";
        private static readonly string DatabasePath = Path.Combine(FileSystem.AppDataDirectory, "DB Storage 1", DatabaseFileName);
        private SQLiteAsyncConnection _databaseConnection;

        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1,1);

        private async Task Init()
        {
            await _semaphore.WaitAsync();

            try
            {
                if (_databaseConnection is not null)
                    return;

                bool isFirstLaunch = !File.Exists(DatabasePath);

                if (isFirstLaunch)
                    await CreateMockStorage();
                else
                    _databaseConnection = new SQLiteAsyncConnection(DatabasePath);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        private async Task CreateMockStorage()
        {
            var dir = Path.GetDirectoryName(DatabasePath);
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            _databaseConnection = new SQLiteAsyncConnection(DatabasePath);

            var inMemoryStorage = new InMemoryStorageContext();

            await _databaseConnection.CreateTableAsync<DepartmentDBModel>();
            await _databaseConnection.CreateTableAsync<LecturerDBModel>();

            await foreach (var department in inMemoryStorage.GetDepartmentsAsync())
            {
                await _databaseConnection.InsertAsync(department);
                await _databaseConnection.InsertAllAsync(await inMemoryStorage.GetLecturersByDepartmentAsync(department.Id));
            }
        }

        public async Task<DepartmentDBModel> GetDepartmentAsync(Guid departmentId)
        {
            await Init();
            return await _databaseConnection.Table<DepartmentDBModel>().FirstOrDefaultAsync(d => d.Id == departmentId);
        }

        public async IAsyncEnumerable<DepartmentDBModel> GetDepartmentsAsync()
        {
            await Init();
            foreach (var department in await _databaseConnection.Table<DepartmentDBModel>().ToListAsync())
            {
                yield return department;
            }
        }

        public async Task<LecturerDBModel> GetLecturerAsync(Guid lecturerId)
        {
            await Init();
            return await _databaseConnection.Table<LecturerDBModel>().FirstOrDefaultAsync(l => l.Id == lecturerId);
        }

        public async Task<IEnumerable<LecturerDBModel>> GetLecturersByDepartmentAsync(Guid departmentId)
        {
            await Init();
            return await _databaseConnection.Table<LecturerDBModel>().Where(l => l.DepartmentId == departmentId).ToListAsync();
        }

        public async Task<int> GetLecturersCountByDepartmentAsync(Guid departmentId)
        {
            await Init();
            return await _databaseConnection.Table<LecturerDBModel>().CountAsync(l => l.DepartmentId == departmentId);
        }

        public Task SaveLecturerAsync(LecturerDBModel lecturer)
        {
            throw new NotImplementedException();
        }

        public Task DeleteLecturerAsync(Guid lecturerId)
        {
            throw new NotImplementedException();
        }
    }
}
