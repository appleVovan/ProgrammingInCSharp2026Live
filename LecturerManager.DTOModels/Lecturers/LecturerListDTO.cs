using KMA.ProgrammingInChsarp2026.LecturerManager.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace KMA.ProgrammingInChsarp2026.LecturerManager.DTOModels.Lecturers
{
    public class LecturerListDTO
    {
        public Guid Id { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public LecturerPosition Position { get; set; }
        
        public LecturerListDTO(Guid guid, string firstName, string lastName, LecturerPosition position)
        {
            Id = guid;
            FirstName = firstName;
            LastName = lastName;
            Position = position;
        }
    }
}
