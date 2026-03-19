using KMA.ProgrammingInChsarp2026.LecturerManager.DBModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KMA.ProgrammingInCSharp2026.LecturerManager.Storage
{
    public interface IStorageContext
    {
        IEnumerable<DepartmentDBModel> GetDepartments();
        DepartmentDBModel GetDepartment(Guid departmentId);
        IEnumerable<LecturerDBModel> GetLecturersByDepartment(Guid departmentId);
        LecturerDBModel GetLecturer(Guid lecturerId);
        int GetLecturersCountByDepartment(Guid departmentId);
    }
}
