using KMA.ProgrammingInChsarp2026.LecturerManager.Common.Enums;
using KMA.ProgrammingInChsarp2026.LecturerManager.DBModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KMA.ProgrammingInCSharp2026.LecturerManager.Services
{
    internal class InMemoryStorageContext : IStorageContext
    {
        private record DepartmentRecord (Guid Id, string Name, Faculty Faculty);
        private record LecturerRecord (Guid Id, Guid DepartmentId, string FirstName, string LastName, LecturerPosition Position, DateTime BirthDate);

        private static readonly List<DepartmentRecord> _departments = new List<DepartmentRecord>();
        private static readonly List<LecturerRecord> _lecturers = new List<LecturerRecord>();

        static InMemoryStorageContext()
        {
            #region MockStoragePopulation
            var departmentOfMath = new DepartmentRecord(Guid.NewGuid(), "Mathematics", Faculty.FacultyOfInformatics);
            var departmentOfInformatics = new DepartmentRecord(Guid.NewGuid(), "Informatics", Faculty.FacultyOfInformatics);
            var departmentOfPhysics = new DepartmentRecord(Guid.NewGuid(), "Physics", Faculty.FacultyOfPhysics);
            _departments.Add(departmentOfMath);
            _departments.Add(departmentOfInformatics);
            _departments.Add(departmentOfPhysics);

            _lecturers.Add(new LecturerRecord(Guid.NewGuid(), departmentOfInformatics.Id, "Volodymyr", "Yablonskyi", LecturerPosition.SeniorLecturer, new DateTime(1993, 06, 20)));
            _lecturers.Add(new LecturerRecord(Guid.NewGuid(), departmentOfInformatics.Id, "Mykola", "Hlybovets", LecturerPosition.Professor, new DateTime(1966, 05, 10)));
            _lecturers.Add(new LecturerRecord(Guid.NewGuid(), departmentOfInformatics.Id, "Semen", "Gorokhoskyi", LecturerPosition.AssociateProfessor, new DateTime(1951, 08, 12)));
            _lecturers.Add(new LecturerRecord(Guid.NewGuid(), departmentOfInformatics.Id, "Natalia", "Gulaeva", LecturerPosition.AssociateProfessor, new DateTime(1981, 11, 17)));
            _lecturers.Add(new LecturerRecord(Guid.NewGuid(), departmentOfInformatics.Id, "Oleksandr", "Zhezherun", LecturerPosition.AssociateProfessor, new DateTime(1971, 11, 17)));
            _lecturers.Add(new LecturerRecord(Guid.NewGuid(), departmentOfInformatics.Id, "Alla", "Nagirna", LecturerPosition.AssociateProfessor, new DateTime(1978, 12, 28)));
            _lecturers.Add(new LecturerRecord(Guid.NewGuid(), departmentOfInformatics.Id, "Kyrylo", "Salata", LecturerPosition.Assistant, new DateTime(1998, 09, 21)));
            _lecturers.Add(new LecturerRecord(Guid.NewGuid(), departmentOfInformatics.Id, "Yuriy", "Yushchenko", LecturerPosition.SeniorLecturer, new DateTime(1978, 09, 21)));
            _lecturers.Add(new LecturerRecord(Guid.NewGuid(), departmentOfInformatics.Id, "Trohym", "Babych", LecturerPosition.Assistant, new DateTime(1992, 09, 21)));
            _lecturers.Add(new LecturerRecord(Guid.NewGuid(), departmentOfInformatics.Id, "Oleksandr", "Frankiv", LecturerPosition.SeniorLecturer, new DateTime(1978, 09, 21)));
            _lecturers.Add(new LecturerRecord(Guid.NewGuid(), departmentOfMath.Id, "Ruslan", "Chorney", LecturerPosition.AssociateProfessor, new DateTime(1986, 02, 21)));
            _lecturers.Add(new LecturerRecord(Guid.NewGuid(), departmentOfMath.Id, "Bohdana", "Oliynyk", LecturerPosition.Professor, new DateTime(1976, 02, 05))); 
            #endregion

        }

        public IEnumerable<DepartmentDBModel> GetDepartments()
        {
            var result = new List<DepartmentDBModel>();
            foreach (var department in _departments)
            {
                result.Add(new DepartmentDBModel(department.Id, department.Name, department.Faculty));
            }
            return result;
        }

        public IEnumerable<LecturerDBModel> GetLecturersByDepartment(Guid departmentId)
        {
            throw new NotImplementedException();
        }
    }
}
