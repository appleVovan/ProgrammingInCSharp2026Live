using KMA.ProgrammingInChsarp2026.LecturerManager.Common.Enums;
using KMA.ProgrammingInChsarp2026.LecturerManager.DBModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace KMA.ProgrammingInChsarp2026.LecturerManager.UIModels
{
    public class LecturerUIModel
    {
        private LecturerDBModel _dbModel;
        private Guid _departmentId;
        private string _firstName;
        private string _lastName;
        private LecturerPosition _position;
        private DateTime _dateOfBirth;
        private int _age;

        public Guid? Id
        {
            get => _dbModel?.Id;
        }
        public Guid DepartmentId
        {
            get => _departmentId;
        }
        public string FirstName
        {
            get => _firstName;
            set => _firstName = value;
        }
        public string LastName
        {
            get => _lastName;
            set => _lastName = value;
        }
        public LecturerPosition Position
        {
            get => _position;
            set => _position = value;
        }
        public DateTime DateOfBirth
        {
            get => _dateOfBirth;
            set
            {
                if (_dbModel != null)
                    return; //Prevent changing DateOfBirth if DBModel exists
                _dateOfBirth = value;
                CalculateAge();
            }
        }
        public int Age
        {
            get => _age;
        }

        // Constructor used to create new Lecturer
        public LecturerUIModel(Guid departmentId)
        {
            _departmentId = departmentId;
        }
        // Constructor used to load existing Department for viewing/editing
        public LecturerUIModel(LecturerDBModel dBModel)
        {
            _dbModel = dBModel;
            _departmentId = dBModel.DepartmentId;
            _firstName = dBModel.FirstName;
            _lastName = dBModel.LastName;
            _position = dBModel.Position;
            _dateOfBirth = dBModel.DateOfBirth;
            CalculateAge();
        }

        private void CalculateAge()
        {
            var today = DateTime.Today;
            _age = today.Year - _dateOfBirth.Year;
            if (_dateOfBirth.Date > today.AddYears(-_age))
                _age--;
        }

        public void SaveChangesToDBModel()
        {
            if (_dbModel != null)
            {
                _dbModel.FirstName = _firstName;
                _dbModel.LastName = _lastName;
                _dbModel.Position = _position;
            }
            else
            {
                _dbModel = new LecturerDBModel(_departmentId, _firstName, _lastName, _position, _dateOfBirth);
            }
        }

        public override string ToString()
        {
            return $"Lecturer: {FirstName} {LastName}, {Position}, Age: {Age}"; ;
        }
    }
}
