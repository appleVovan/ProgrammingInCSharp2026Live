using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KMA.ProgrammingInChsarp2026.LecturerManager.Common;
using KMA.ProgrammingInChsarp2026.LecturerManager.Common.Enums;
using KMA.ProgrammingInChsarp2026.LecturerManager.DTOModels.Lecturers;
using KMA.ProgrammingInCSharp2026.LecturerManager.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace KMA.ProgrammingInCSharp2026.LecturerManager.ViewModels
{
    public partial class LecturerCreateViewModel : BaseViewModel, IQueryAttributable
    {
        private readonly ILecturerService _lecturerService;

        private Guid _departmentId;
        private EnumWithName<LecturerPosition>[] _positions;

        [ObservableProperty]
        private string _firstName;
        [ObservableProperty]
        private string _lastName;
        [ObservableProperty]
        private EnumWithName<LecturerPosition> _position;
        [ObservableProperty]
        private DateTime? _dateOfBirth;

        [ObservableProperty]
        private Dictionary<string, string> _errors;

        public EnumWithName<LecturerPosition>[] Positions => _positions;

        public LecturerCreateViewModel(ILecturerService lecturerService)
        {
            _lecturerService = lecturerService;
            _positions = EnumExtensions.GetValueWithNames<LecturerPosition>();
            Errors = InitErrors();
        }
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            _departmentId = (Guid)query[nameof(LecturerCreateDTO.DepartmentId)];
        }

        [RelayCommand]
        public async Task CreateLecturer()
        {
            IsBusy = true;
            var errors = Validators.ValidateLecturer(FirstName, LastName, Position?.Value, DateOfBirth);
            Errors = InitErrors();
            if (errors.Count > 0)
            {
                foreach (var error in errors)
                {
                    if (String.IsNullOrWhiteSpace(Errors[error.MemberName]))
                    {
                        Errors[error.MemberName] = error.ErrorMessage;
                        continue;
                    }
                    Errors[error.MemberName] += Environment.NewLine + error.ErrorMessage;
                }
                OnPropertyChanged(nameof(Errors));
                IsBusy = false;
                return;
            }
            try
            {
                var newLecturer = new LecturerCreateDTO(_departmentId, FirstName, LastName, Position.Value, DateOfBirth.Value);
                await _lecturerService.CreateLecturerAsync(newLecturer);
                await Shell.Current.DisplayAlertAsync("Success", "Lecturer created successfully!", "OK");
                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlertAsync("Error", $"Failed to create lecturer: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        public async Task Back()
        {
            try
            {
                IsBusy = true;
                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlertAsync("Error", $"Failed to navigate back: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private Dictionary<string, string> InitErrors()
        {
            return new Dictionary<string, string>()
            {
                { nameof(FirstName), string.Empty },
                { nameof(LastName), string.Empty },
                { nameof(Position), string.Empty },
                { nameof(DateOfBirth), string.Empty }
            };
        }
    }
}
