using KMA.ProgrammingInChsarp2026.LecturerManager.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace KMA.ProgrammingInChsarp2026.LecturerManager.DTOModels.Departments
{
    public class DepartmentListDTO
    {        
        public Guid Id { get; }
        public string Name { get; }    
        public Faculty Faculty { get; }
        public int LecturersCount { get; }

        public DepartmentListDTO(Guid id, string name, Faculty faculty, int lecturersCount)
        {
            Id = id;
            Name = name;
            Faculty = faculty;
            LecturersCount = lecturersCount;
        }
    }
}
