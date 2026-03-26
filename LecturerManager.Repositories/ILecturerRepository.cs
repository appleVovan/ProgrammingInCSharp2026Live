using KMA.ProgrammingInChsarp2026.LecturerManager.DBModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KMA.ProgrammingInCSharp2026.LecturerManager.Repositories
{
    public interface ILecturerRepository
    {
        Task<IEnumerable<LecturerDBModel>> GetLecturersByDepartmentAsync(Guid departmentId);

        Task<LecturerDBModel> GetLecturerAsync(Guid lecturerId);
        Task<int> GetLecturersCountByDepartmentAsync(Guid departmentId);
    }
}
