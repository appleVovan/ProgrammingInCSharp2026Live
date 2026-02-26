using KMA.ProgrammingInChsarp2026.LecturerManager.DBModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KMA.ProgrammingInCSharp2026.LecturerManager.Services
{
    internal interface IStorageContext
    {
        IEnumerable<DepartmentDBModel> GetDepartments();
        IEnumerable<LecturerDBModel> GetLecturersByDepartment(Guid departmentId);
    }
}
