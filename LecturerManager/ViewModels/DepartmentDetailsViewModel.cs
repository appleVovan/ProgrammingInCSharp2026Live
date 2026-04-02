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
            OnPropertyChanged(nameof(Lecturers));
        }

        [RelayCommand]
        public async Task RefreshData()
        {
            IsBusy = true;
            try
            {
                CurrentDepartment = await _departmentService.GetDepartmentAsync(_departmentId) ?? throw new Exception("Department does not exist.");
                Lecturers = new ObservableCollection<LecturerListDTO>(await _lecturerService.GetLecturersByDepartmentAsync(_departmentId));
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlertAsync("Error", $"Failed to load department details: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        private async Task LoadLecturer(Guid lecturerId)
        {
            IsBusy = true;
            try
            {
                await Shell.Current.GoToAsync($"{nameof(LecturerDetailsPage)}", new Dictionary<string, object> { { "LecturerId", lecturerId } });
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlertAsync("Error", $"Failed to navigate to lecturer details: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        private async Task AddLecturer()
        {
            IsBusy = true;
            try
            {
                await Shell.Current.GoToAsync($"{nameof(LecturerCreatePage)}", new Dictionary<string, object> { { nameof(LecturerCreateDTO.DepartmentId), _departmentId } });
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlertAsync("Error", $"Failed to navigate to lecturer create page: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        private async Task DeleteLecturer(LecturerListDTO lecturer)
        {
            IsBusy = true;
            try
            {
                if (await Shell.Current.DisplayAlertAsync("Confirm", "Are you sure you want to delete this lecturer?", "Yes", "No"))
                    await _lecturerService.DeleteLecturerAsync(lecturer.Id);
                Lecturers.Remove(lecturer);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlertAsync("Error", $"Failed to navigate to lecturer details: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}
