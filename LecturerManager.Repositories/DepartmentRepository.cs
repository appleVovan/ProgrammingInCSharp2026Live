using KMA.ProgrammingInChsarp2026.LecturerManager.DBModels;
using KMA.ProgrammingInCSharp2026.LecturerManager.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace KMA.ProgrammingInCSharp2026.LecturerManager.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly IStorageContext _storageContext;
        public DepartmentRepository(IStorageContext storageContext)
        {
            _storageContext = storageContext;
        }
        public IAsyncEnumerable<DepartmentDBModel> GetDepartmentsAsync()
        {
            return _storageContext.GetDepartmentsAsync();
        }

        public Task<DepartmentDBModel> GetDepartmentAsync(Guid departmentId)
        {
            return _storageContext.GetDepartmentAsync(departmentId);
        }
    }
}
