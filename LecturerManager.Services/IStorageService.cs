using KMA.ProgrammingInChsarp2026.LecturerManager.DBModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KMA.ProgrammingInCSharp2026.LecturerManager.Services
{
    public interface IStorageService
    {
        public IEnumerable<LecturerDBModel> GetLecturers(Guid departmentId);
        public IEnumerable<DepartmentDBModel> GetAllDepartments();
    }
}
