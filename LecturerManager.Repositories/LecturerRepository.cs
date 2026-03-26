using KMA.ProgrammingInChsarp2026.LecturerManager.DBModels;
using KMA.ProgrammingInCSharp2026.LecturerManager.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace KMA.ProgrammingInCSharp2026.LecturerManager.Repositories
{
    public class LecturerRepository : ILecturerRepository
    {
        private readonly IStorageContext _storageContext;
        public LecturerRepository(IStorageContext storageContext)
        {
            _storageContext = storageContext;
        }
        public Task<IEnumerable<LecturerDBModel>> GetLecturersByDepartmentAsync(Guid departmentId)
        {
            return _storageContext.GetLecturersByDepartmentAsync(departmentId);
        }

        public Task<LecturerDBModel> GetLecturerAsync(Guid lecturerId)
        {
            return _storageContext.GetLecturerAsync(lecturerId);
        }

        public Task<int> GetLecturersCountByDepartmentAsync(Guid departmentId)
        {
            return _storageContext.GetLecturersCountByDepartmentAsync(departmentId);
        }
    }
}
