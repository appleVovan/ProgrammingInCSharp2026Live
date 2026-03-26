using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KMA.ProgrammingInChsarp2026.LecturerManager.DTOModels.Departments;
using KMA.ProgrammingInCSharp2026.LecturerManager.Pages;
using KMA.ProgrammingInCSharp2026.LecturerManager.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace KMA.ProgrammingInCSharp2026.LecturerManager.ViewModels
{
    public partial class DepartmentsViewModel : BaseViewModel
    {
        private readonly IDepartmentService _departmentService;
        [ObservableProperty]
        public ObservableCollection<DepartmentListDTO> _departments;
        [ObservableProperty]
        public DepartmentListDTO _selectedDepartment;
        public DepartmentsViewModel(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        internal async Task RefreshData()
        {
            IsBusy = true;
            Departments = new ObservableCollection<DepartmentListDTO>();
            await foreach (var department in _departmentService.GetAllDepartmentsAsync())
            {
                Departments.Add(department);
            }
            IsBusy = false;
        }

        [RelayCommand]
        private async Task LoadDepartment()
        {
            IsBusy = true;
            if (SelectedDepartment == null)
                return;
            await Shell.Current.GoToAsync($"{nameof(DepartmentDetailsPage)}", new Dictionary<string, object> { { "DepartmentId", SelectedDepartment.Id } });
            IsBusy = false;
        }
    }
}
