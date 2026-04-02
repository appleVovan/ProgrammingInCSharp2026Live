using KMA.ProgrammingInChsarp2026.LecturerManager.DBModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KMA.ProgrammingInCSharp2026.LecturerManager.Storage
{
    public interface IStorageContext
    {
        IAsyncEnumerable<DepartmentDBModel> GetDepartmentsAsync();
        Task<DepartmentDBModel> GetDepartmentAsync(Guid departmentId);
        Task<IEnumerable<LecturerDBModel>> GetLecturersByDepartmentAsync(Guid departmentId);
        Task<LecturerDBModel> GetLecturerAsync(Guid lecturerId);
        Task<int> GetLecturersCountByDepartmentAsync(Guid departmentId);
        Task SaveLecturerAsync(LecturerDBModel lecturer);
        Task DeleteLecturerAsync(Guid lecturerId);
    }
}
