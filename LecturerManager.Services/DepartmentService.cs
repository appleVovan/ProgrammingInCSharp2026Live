using KMA.ProgrammingInChsarp2026.LecturerManager.DTOModels.Departments;
using KMA.ProgrammingInCSharp2026.LecturerManager.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace KMA.ProgrammingInCSharp2026.LecturerManager.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ILecturerRepository _lecturerRepository;
        public DepartmentService(IDepartmentRepository departmentRepository, ILecturerRepository lecturerRepository)
        {
            _departmentRepository = departmentRepository;
            _lecturerRepository = lecturerRepository;
        }
        public async IAsyncEnumerable<DepartmentListDTO> GetAllDepartmentsAsync()
        {
            await foreach (var department in _departmentRepository.GetDepartmentsAsync())
            {
                var lecturersCount = await _lecturerRepository.GetLecturersCountByDepartmentAsync(department.Id);
                yield return new DepartmentListDTO(department.Id, department.Name, department.Faculty, lecturersCount);
            }
        }

        public async Task<DepartmentDetailsDTO> GetDepartmentAsync(Guid departmentId)
        {
            var department = await _departmentRepository.GetDepartmentAsync(departmentId);            
            return department is null ? null : new DepartmentDetailsDTO(department.Id, department.Name, department.Faculty, department.Email);
        }
    }
}
