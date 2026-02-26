using KMA.ProgrammingInChsarp2026.LecturerManager.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace KMA.ProgrammingInChsarp2026.LecturerManager.DBModels
{
    public class DepartmentDBModel
    {
        //Id is generated only once during the creation of the object and cannot be changed later. 
        public Guid Id { get; }
        public string Name { get; set; }    
        public Faculty Faculty { get; set; }

        public DepartmentDBModel(string name, Faculty faculty): this(Guid.NewGuid(), name, faculty)
        {
        }

        public DepartmentDBModel(Guid id, string name, Faculty faculty)
        {
            Id = id;
            Name = name;
            Faculty = faculty;
        }
    }
}
