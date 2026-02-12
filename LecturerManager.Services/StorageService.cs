using KMA.ProgrammingInChsarp2026.LecturerManager.DBModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KMA.ProgrammingInCSharp2026.LecturerManager.Services
{
    public class StorageService
    {
        private List<DepartmentDBModel> _departments;
        private List<LecturerDBModel> _lecturers;

        private void LoadData()
        {
            if (_departments != null && _lecturers != null)
                return;
            _departments = FakeStorage.Departments.ToList();
            _lecturers = FakeStorage.Lecturers.ToList();
        }

        /// <summary>
        /// Gets all lecturers of specified department
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        public IEnumerable<LecturerDBModel> GetLecturers(Guid departmentId)
        {
            LoadData();
            var resultList = new List<LecturerDBModel>();
            foreach (var lecturer in _lecturers)
            {
                if (lecturer.DepartmentId == departmentId)
                    resultList.Add(lecturer);
            }
            return resultList;     
            
        }

        public IEnumerable<DepartmentDBModel> GetAllDepartments()
        {
            LoadData();
            var resultList = new List<DepartmentDBModel>();
            foreach (var department in _departments)
            {
                resultList.Add(department);
            }
            return resultList;
        }

    }
}
