using KMA.ProgrammingInChsarp2026.LecturerManager.Common.Enums;
using KMA.ProgrammingInChsarp2026.LecturerManager.DBModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KMA.ProgrammingInChsarp2026.LecturerManager.UIModels
{
    public class DepartmentUIModel
    {
        private DepartmentDBModel _dbModel;
        private string _name;
        private Faculty _faculty;
        private List<LecturerUIModel> _lecturers;

        public Guid Id 
        {
            get => _dbModel.Id; 
        }
        public string Name 
        {
            get => _name;
            set => _name = value;
        }
        public Faculty Faculty 
        { 
            get => _faculty;
            set => _faculty = value;
        }
        public IReadOnlyList<LecturerUIModel> Lecturers
        { 
            get => _lecturers;
        }

        public int Staff 
        { 
            get => Lecturers?.Count ?? 0;
        }

        public DepartmentUIModel()
        {
            _lecturers = new List<LecturerUIModel>();
        }

        public DepartmentUIModel(DepartmentDBModel dbModel) : this()
        {
            _dbModel = dbModel;
            _name = dbModel.Name;
            _faculty = dbModel.Faculty;
        }
    }
}
