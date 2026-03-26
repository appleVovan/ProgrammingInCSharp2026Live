using CommunityToolkit.Mvvm.ComponentModel;
using KMA.ProgrammingInChsarp2026.LecturerManager.Common.Enums;
using KMA.ProgrammingInChsarp2026.LecturerManager.DTOModels.Lecturers;
using KMA.ProgrammingInCSharp2026.LecturerManager.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace KMA.ProgrammingInCSharp2026.LecturerManager.ViewModels
{
    public partial class LecturerDetailsViewModel : BaseViewModel, IQueryAttributable
    {
        private readonly ILecturerService _lecturerService;

        private LecturerDetailsDTO _currentLecturer;
        private int _age;

        private Guid _lecturerId;

        public string FirstName => _currentLecturer?.FirstName;
        public string LastName => _currentLecturer?.LastName;
        public LecturerPosition? Position => _currentLecturer?.Position;
        public DateTime? DateOfBirth => _currentLecturer?.DateofBirth;
        public int Age => _age;


        public LecturerDetailsViewModel(ILecturerService lecturerService)
        {
            _lecturerService = lecturerService;
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            _lecturerId = (Guid)query["LecturerId"];
        }
        internal async Task RefreshData()
        {
            IsBusy = true;
            _currentLecturer = await _lecturerService.GetLecturerAsync(_lecturerId);
            CalculateAge();
            OnPropertyChanged(nameof(FirstName));
            OnPropertyChanged(nameof(LastName));
            OnPropertyChanged(nameof(Position));
            OnPropertyChanged(nameof(DateOfBirth));
            OnPropertyChanged(nameof(Age));
            IsBusy = false;
        }

        private void CalculateAge()
        {
            if (DateOfBirth == null)
                return;

            var dob = DateOfBirth.Value;
            var today = DateTime.Today;
            _age = today.Year - dob.Year;
            if (dob.Date > today.AddYears(-_age))
                _age--;
        }
    }
}
