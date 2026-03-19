using KMA.ProgrammingInChsarp2026.LecturerManager.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace KMA.ProgrammingInChsarp2026.LecturerManager.DTOModels.Lecturers
{
    public class LecturerDetailsDTO
    {
        public Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public LecturerPosition Position { get; }
        public DateTime DateofBirth { get; }

        public LecturerDetailsDTO(Guid guid, string firstName, string lastName, LecturerPosition position, DateTime dateofBirth)
        {
            Id = guid;
            FirstName = firstName;
            LastName = lastName;
            Position = position;
            DateofBirth = dateofBirth;
        }
    }
}
