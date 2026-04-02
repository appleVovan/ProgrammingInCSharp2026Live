using KMA.ProgrammingInChsarp2026.LecturerManager.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace KMA.ProgrammingInChsarp2026.LecturerManager.DTOModels.Lecturers
{
    public class LecturerCreateDTO
    {
        public Guid DepartmentId { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public LecturerPosition Position { get; }
        public DateTime DateOfBirth { get; }
        public LecturerCreateDTO(Guid departmentId, string firstName, string lastName, LecturerPosition position, DateTime dateOfBirth)
        {
            DepartmentId = departmentId;
            FirstName = firstName;
            LastName = lastName;
            Position = position;
            DateOfBirth = dateOfBirth;
        }
    }
}
