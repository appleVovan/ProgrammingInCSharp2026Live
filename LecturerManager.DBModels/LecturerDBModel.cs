using KMA.ProgrammingInChsarp2026.LecturerManager.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace KMA.ProgrammingInChsarp2026.LecturerManager.DBModels
{
    public class LecturerDBModel
    {
        //Id is generated only once during the creation of the object and cannot be changed later. 
        public Guid Id { get; set; }
        //DepartmentId is set only once during the creation of the object and cannot be changed later. 
        public Guid DepartmentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public LecturerPosition Position { get; set; }
        //DateOfBirth is set only once during the creation of the object and cannot be changed later. 
        public DateTime DateOfBirth { get; set; }

        public LecturerDBModel()
        {
            
        }

        public LecturerDBModel(Guid departmentId, string firstName, string lastName, LecturerPosition position, DateTime dateOfBirth):this(Guid.NewGuid(), departmentId, firstName, lastName, position, dateOfBirth)
        {
        }

        public LecturerDBModel(Guid guid, Guid departmentId, string firstName, string lastName, LecturerPosition position, DateTime dateOfBirth)
        {
            Id = guid;
            DepartmentId = departmentId;
            FirstName = firstName;
            LastName = lastName;
            Position = position;
            DateOfBirth = dateOfBirth;
        }
    }
}
