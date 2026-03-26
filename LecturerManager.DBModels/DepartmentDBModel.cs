using KMA.ProgrammingInChsarp2026.LecturerManager.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace KMA.ProgrammingInChsarp2026.LecturerManager.DBModels
{
    public class DepartmentDBModel
    {
        //Id is generated only once during the creation of the object and cannot be changed later. 
        public Guid Id { get; set; }
        public string Name { get; set; }    
        public Faculty Faculty { get; set; }
        public string Email { get; set; }

        public DepartmentDBModel()
        {
            
        }

        public DepartmentDBModel(string name, Faculty faculty, string email) : this(Guid.NewGuid(), name, faculty, email)
        {
        }

        public DepartmentDBModel(Guid id, string name, Faculty faculty, string email)
        {
            Id = id;
            Name = name;
            Faculty = faculty;
            Email = email;
        }
    }
}
