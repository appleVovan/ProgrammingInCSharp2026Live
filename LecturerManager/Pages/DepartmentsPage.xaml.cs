using KMA.ProgrammingInChsarp2026.LecturerManager.UIModels;
using KMA.ProgrammingInCSharp2026.LecturerManager.Services;
using System.Collections.ObjectModel;

namespace KMA.ProgrammingInCSharp2026.LecturerManager.Pages;

public partial class DepartmentsPage : ContentPage
{
	private StorageService _storage;
    public ObservableCollection<DepartmentUIModel> Departments { get; set; }
    public DepartmentsPage()
	{
		InitializeComponent();
		_storage = new StorageService();
		Departments = new ObservableCollection<DepartmentUIModel>();
		foreach (var department in _storage.GetAllDepartments())
		{
			Departments.Add(new DepartmentUIModel(department));
		}
		BindingContext = this;
    }
}