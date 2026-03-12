using KMA.ProgrammingInChsarp2026.LecturerManager.DBModels;
using KMA.ProgrammingInChsarp2026.LecturerManager.DTOModels.Departments;
using System;
using System.Collections.Generic;
using System.Text;

namespace KMA.ProgrammingInCSharp2026.LecturerManager.Services
{
    public interface IDepartmentService
    {
        IEnumerable<DepartmentListDTO> GetAllDepartments();
        DepartmentDetailsDTO GetDepartment(Guid departmentId);
    }
}
