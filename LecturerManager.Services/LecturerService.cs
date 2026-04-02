using KMA.ProgrammingInChsarp2026.LecturerManager.DBModels;
using KMA.ProgrammingInChsarp2026.LecturerManager.DTOModels.Lecturers;
using KMA.ProgrammingInCSharp2026.LecturerManager.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KMA.ProgrammingInCSharp2026.LecturerManager.Services
{
    public class LecturerService : ILecturerService
    {
        private readonly ILecturerRepository _lecturerRepository;
        public LecturerService(ILecturerRepository lecturerRepository)
        {
            _lecturerRepository = lecturerRepository;
        }
        public async Task<IEnumerable<LecturerListDTO>> GetLecturersByDepartmentAsync(Guid departmentId)
        {
            return (await _lecturerRepository.GetLecturersByDepartmentAsync(departmentId)).Select(lecturer => new LecturerListDTO(lecturer.Id, lecturer.FirstName, lecturer.LastName, lecturer.Position));
        }

        public async Task<LecturerDetailsDTO> GetLecturerAsync(Guid lecturerId)
        {
            var lecturer = await _lecturerRepository.GetLecturerAsync(lecturerId);
            return lecturer is null ? null : new LecturerDetailsDTO(lecturer.Id, lecturer.FirstName, lecturer.LastName, lecturer.Position, lecturer.DateOfBirth);
        }

        public async Task CreateLecturerAsync(LecturerCreateDTO lecturerCreateDTO)
        {
            var errors = lecturerCreateDTO.Validate();
            if (errors.Count > 0)
                throw new ValidationException(String.Join(Environment.NewLine, errors.Select(s => s.ErrorMessage)));
            var newLecturer = new LecturerDBModel(lecturerCreateDTO.DepartmentId, lecturerCreateDTO.FirstName, lecturerCreateDTO.LastName, lecturerCreateDTO.Position, lecturerCreateDTO.DateOfBirth);
            await _lecturerRepository.SaveLecturerAsync(newLecturer);
        }

        public Task DeleteLecturerAsync(Guid lecturerId)
        {
            return _lecturerRepository.DeleteLecturerAsync(lecturerId);
        }
    }
}
