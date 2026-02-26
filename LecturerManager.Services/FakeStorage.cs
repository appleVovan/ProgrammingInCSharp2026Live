using KMA.ProgrammingInChsarp2026.LecturerManager.Common.Enums;
using KMA.ProgrammingInChsarp2026.LecturerManager.DBModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KMA.ProgrammingInCSharp2026.LecturerManager.Services
{
    internal static class FakeStorage
    {
        private static readonly List<DepartmentDBModel> _departments;
        private static readonly List<LecturerDBModel> _lecturers;

        internal static IEnumerable<DepartmentDBModel> Departments
        {
            get
            {
                return _departments.ToList();
            }
        }

        internal static IEnumerable<LecturerDBModel> Lecturers
        {
            get
            {
                return _lecturers.ToList();
            }
        }

        static FakeStorage()
        {
            var departmentOfMath = new DepartmentDBModel("Mathematics", Faculty.FacultyOfInformatics);
            var departmentOfInformatics = new DepartmentDBModel("Informatics", Faculty.FacultyOfInformatics);
            var departmentOfPhysics = new DepartmentDBModel("Physics", Faculty.FacultyOfPhysics);
            _departments = new List<DepartmentDBModel> { departmentOfMath, departmentOfInformatics, departmentOfPhysics };

            _lecturers = new List<LecturerDBModel>
            {
                new LecturerDBModel(departmentOfInformatics.Id, "Volodymyr", "Yablonskyi", LecturerPosition.SeniorLecturer, new DateTime(1993,06,20)),
                new LecturerDBModel(departmentOfInformatics.Id, "Mykola", "Hlybovets", LecturerPosition.Professor, new DateTime(1966,05,10)),
                new LecturerDBModel(departmentOfInformatics.Id, "Semen", "Gorokhoskyi", LecturerPosition.AssociateProfessor, new DateTime(1951,08,12)),
                new LecturerDBModel(departmentOfInformatics.Id, "Natalia", "Gulaeva", LecturerPosition.AssociateProfessor, new DateTime(1981,11,17)),
                new LecturerDBModel(departmentOfInformatics.Id, "Oleksandr", "Zhezherun", LecturerPosition.AssociateProfessor, new DateTime(1971,11,17)),
                new LecturerDBModel(departmentOfInformatics.Id, "Alla", "Nagirna", LecturerPosition.AssociateProfessor, new DateTime(1978,12,28)),
                new LecturerDBModel(departmentOfInformatics.Id, "Kyrylo", "Salata", LecturerPosition.Assistant, new DateTime(1998,09,21)),
                new LecturerDBModel(departmentOfInformatics.Id, "Yuriy", "Yushchenko", LecturerPosition.SeniorLecturer, new DateTime(1978,09,21)),
                new LecturerDBModel(departmentOfInformatics.Id, "Trohym", "Babych", LecturerPosition.Assistant, new DateTime(1992,09,21)),
                new LecturerDBModel(departmentOfInformatics.Id, "Oleksandr", "Frankiv", LecturerPosition.SeniorLecturer, new DateTime(1978,09,21)),
                new LecturerDBModel(departmentOfMath.Id, "Ruslan", "Chorney", LecturerPosition.AssociateProfessor, new DateTime(1986,02,21)),
                new LecturerDBModel(departmentOfMath.Id, "Bohdana", "Oliynyk", LecturerPosition.Professor, new DateTime(1976,02,05)),
            };

        }
    }
}
