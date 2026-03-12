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
        public IEnumerable<DepartmentDBModel> GetDepartments()
        {
            return _storageContext.GetDepartments();
        }

        public DepartmentDBModel GetDepartment(Guid departmentId)
        {
            return _storageContext.GetDepartment(departmentId);
        }
    }
}
