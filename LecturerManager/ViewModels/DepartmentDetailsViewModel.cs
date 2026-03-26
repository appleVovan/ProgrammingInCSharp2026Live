using KMA.ProgrammingInChsarp2026.LecturerManager.DTOModels.Departments;
using KMA.ProgrammingInChsarp2026.LecturerManager.DTOModels.Lecturers;
using KMA.ProgrammingInCSharp2026.LecturerManager.Pages;
using KMA.ProgrammingInCSharp2026.LecturerManager.Services;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace KMA.ProgrammingInCSharp2026.LecturerManager.ViewModels
{
    public partial class DepartmentDetailsViewModel : BaseViewModel, IQueryAttributable
    {
        private readonly IDepartmentService _departmentService;
        private readonly ILecturerService _lecturerService;

        private Task<DepartmentDetailsDTO> _departmentTask;
        private Task<IEnumerable<LecturerListDTO>> _lecturersTask;

        private Guid _departmentId;

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
            _departmentId = (Guid)query["DepartmentId"];
            _departmentTask = _departmentService.GetDepartmentAsync(_departmentId);
            _lecturersTask = _lecturerService.GetLecturersByDepartmentAsync(_departmentId);
            OnPropertyChanged(nameof(Lecturers));
        }

        internal async Task RefreshData()
        {
            IsBusy = true;
            CurrentDepartment = await _departmentTask;
            Lecturers = new ObservableCollection<LecturerListDTO>(await _lecturersTask);
            IsBusy = false;
        }

        [RelayCommand]
        private async Task LoadLecturer(Guid lecturerId)
        {
            IsBusy = true;
            await Shell.Current.GoToAsync($"{nameof(LecturerDetailsPage)}", new Dictionary<string, object> { { "LecturerId", lecturerId } });
            IsBusy = false;
        }

    }
}
