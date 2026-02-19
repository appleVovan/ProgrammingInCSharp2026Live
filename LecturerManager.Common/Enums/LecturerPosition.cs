using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KMA.ProgrammingInChsarp2026.LecturerManager.Common.Enums
{
    public enum LecturerPosition
    {
        [Display(Name = "Assistant")]
        Assistant,
        [Display(Name = "Lecturer")]
        Lecturer,
        [Display(Name = "Senior Lecturer")]
        SeniorLecturer,
        [Display(Name = "Associate Professor")]
        AssociateProfessor,
        [Display(Name = "Professor")]
        Professor,
    }
}
