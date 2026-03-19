using KMA.ProgrammingInChsarp2026.LecturerManager.DTOModels.Lecturers;
using System;
using System.Collections.Generic;
using System.Text;

namespace KMA.ProgrammingInCSharp2026.LecturerManager.Services
{
    public interface ILecturerService
    {
        IEnumerable<LecturerListDTO> GetLecturersByDepartment(Guid departmentId);

        LecturerDetailsDTO GetLecturer(Guid lecturerId);
    }
}
