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
        public IEnumerable<DepartmentListDTO> GetAllDepartments()
        {
            foreach (var department in _departmentRepository.GetDepartments())
            {
                var lecturersCount = _lecturerRepository.GetLecturersCountByDepartment(department.Id);
                yield return new DepartmentListDTO(department.Id, department.Name, department.Faculty, lecturersCount);
            }
        }

        public DepartmentDetailsDTO GetDepartment(Guid departmentId)
        {
            var department = _departmentRepository.GetDepartment(departmentId);            
            return department is null ? null : new DepartmentDetailsDTO(department.Id, department.Name, department.Faculty, department.Email);
        }
    }
}
