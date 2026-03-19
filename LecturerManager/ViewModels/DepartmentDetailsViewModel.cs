using KMA.ProgrammingInChsarp2026.LecturerManager.DTOModels.Departments;
using KMA.ProgrammingInChsarp2026.LecturerManager.DTOModels.Lecturers;
using KMA.ProgrammingInCSharp2026.LecturerManager.Pages;
using KMA.ProgrammingInCSharp2026.LecturerManager.Services;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace KMA.ProgrammingInCSharp2026.LecturerManager.ViewModels
{
    public partial class DepartmentDetailsViewModel : ObservableObject, IQueryAttributable
    {
        private readonly IDepartmentService _departmentService;
        private readonly ILecturerService _lecturerService;
        [ObservableProperty]
        private DepartmentDetailsDTO _currentDepartment;
        [ObservableProperty]
        private ObservableCollection<LecturerListDTO> _lecturers;



        public DepartmentDetailsViewModel(IDepartmentService departmentService, ILecturerService lecturerService)
        {
            _departmentService = departmentService;
            _lecturerService = lecturerService;
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            var departmentId = (Guid)query["DepartmentId"];
            CurrentDepartment = _departmentService.GetDepartment(departmentId);
            Lecturers = new ObservableCollection<LecturerListDTO>(_lecturerService.GetLecturersByDepartment(departmentId));
            OnPropertyChanged(nameof(Lecturers));
        }

        [RelayCommand]
        private void LoadLecturer(Guid lecturerId)
        {
            Shell.Current.GoToAsync($"{nameof(LecturerDetailsPage)}", new Dictionary<string, object> { { "LecturerId", lecturerId } });
        }

    }
}
