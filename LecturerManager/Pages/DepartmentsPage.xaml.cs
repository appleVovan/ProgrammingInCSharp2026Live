using KMA.ProgrammingInChsarp2026.LecturerManager.UIModels;
using KMA.ProgrammingInCSharp2026.LecturerManager.Services;
using System.Collections.ObjectModel;

namespace KMA.ProgrammingInCSharp2026.LecturerManager.Pages;

public partial class DepartmentsPage : ContentPage
{
	private readonly IStorageService _storage;
    public ObservableCollection<DepartmentUIModel> Departments { get; set; }
    public DepartmentsPage(IStorageService storageService)
	{
		InitializeComponent();
		_storage = storageService;
		Departments = new ObservableCollection<DepartmentUIModel>();
		foreach (var department in _storage.GetAllDepartments())
		{
			Departments.Add(new DepartmentUIModel(_storage, department));
		}
		BindingContext = this;
    }

    private async void DepartmentSelected(object sender, SelectionChangedEventArgs e)
    {
		var department = (DepartmentUIModel)e.CurrentSelection[0];
		await Shell.Current.GoToAsync($"{nameof(DepartmentDetailsPage)}", new Dictionary<string, object> { { nameof(DepartmentDetailsPage.CurrentDepartment), department} });
    }
}