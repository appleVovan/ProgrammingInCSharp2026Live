using KMA.ProgrammingInChsarp2026.LecturerManager.DTOModels.Departments;
using KMA.ProgrammingInCSharp2026.LecturerManager.Pages;
using KMA.ProgrammingInCSharp2026.LecturerManager.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace KMA.ProgrammingInCSharp2026.LecturerManager.ViewModels
{
    public class DepartmentsViewModel
    {
        private readonly IDepartmentService _departmentService;
        public ObservableCollection<DepartmentListDTO> Departments { get; set; }
        public DepartmentListDTO SelectedDepartment { get; set; }
        public Command DepartmentSelectedCommand { get; }
        public DepartmentsViewModel(IDepartmentService departmentService)
        {
            _departmentService = departmentService;

            Departments = new ObservableCollection<DepartmentListDTO>(_departmentService.GetAllDepartments());
            DepartmentSelectedCommand = new Command(LoadDepartment);
        }

        private void LoadDepartment()
        {
            if (SelectedDepartment == null)
                return;
            Shell.Current.GoToAsync($"{nameof(DepartmentDetailsPage)}", new Dictionary<string, object> { { "DepartmentId", SelectedDepartment.Id } });
        }
    }
}
