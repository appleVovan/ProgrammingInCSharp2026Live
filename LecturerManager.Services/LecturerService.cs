using KMA.ProgrammingInChsarp2026.LecturerManager.DTOModels.Lecturers;
using KMA.ProgrammingInCSharp2026.LecturerManager.Repositories;
using System;
using System.Collections.Generic;
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
        public IEnumerable<LecturerListDTO> GetLecturersByDepartment(Guid departmentId)
        {
            foreach (var lecturer in _lecturerRepository.GetLecturersByDepartment(departmentId))
            {
                yield return new LecturerListDTO(lecturer.Id, lecturer.FirstName, lecturer.LastName, lecturer.Position);
            }
        }

        public LecturerDetailsDTO GetLecturer(Guid lecturerId)
        {
            var lecturer = _lecturerRepository.GetLecturer(lecturerId);
            return lecturer is null ? null : new LecturerDetailsDTO(lecturer.Id, lecturer.FirstName, lecturer.LastName, lecturer.Position, lecturer.DateOfBirth);
        }
    }
}
