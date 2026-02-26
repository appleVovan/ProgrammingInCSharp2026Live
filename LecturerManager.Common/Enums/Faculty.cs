using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KMA.ProgrammingInChsarp2026.LecturerManager.Common.Enums
{
    public enum Faculty
    {
        [Display(Name = "Faculty Of Informatics")]
        FacultyOfInformatics,
        [Display(Name = "Faculty Of Mathematics")]
        FacultyOfMathematics,
        [Display(Name = "Faculty Of Physics")]
        FacultyOfPhysics,
        [Display(Name = "Faculty Of Economics")]
        FacultyOfEconomics
    }
}
