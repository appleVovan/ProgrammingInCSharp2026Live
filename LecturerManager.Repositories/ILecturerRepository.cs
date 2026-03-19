using KMA.ProgrammingInChsarp2026.LecturerManager.DBModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KMA.ProgrammingInCSharp2026.LecturerManager.Repositories
{
    public interface ILecturerRepository
    {
        IEnumerable<LecturerDBModel> GetLecturersByDepartment(Guid departmentId);

        LecturerDBModel GetLecturer(Guid lecturerId);
        int GetLecturersCountByDepartment(Guid departmentId);
    }
}
