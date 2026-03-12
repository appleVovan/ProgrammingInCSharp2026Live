using KMA.ProgrammingInChsarp2026.LecturerManager.DBModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KMA.ProgrammingInCSharp2026.LecturerManager.Services
{
    [Obsolete("This class was created for testing and learning purposes. It is no longer needed and will be removed in the future.")]
    public interface IStorageService
    {
        public IEnumerable<LecturerDBModel> GetLecturers(Guid departmentId);
        public IEnumerable<DepartmentDBModel> GetAllDepartments();
    }
}
