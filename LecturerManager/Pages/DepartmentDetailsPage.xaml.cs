using KMA.ProgrammingInChsarp2026.LecturerManager.UIModels;
using KMA.ProgrammingInCSharp2026.LecturerManager.Services;

namespace KMA.ProgrammingInCSharp2026.LecturerManager.Pages;

[QueryProperty(nameof(CurrentDepartment), nameof(CurrentDepartment))]
public partial class DepartmentDetailsPage : ContentPage
{
    private IStorageService _storage;
    private DepartmentUIModel _currentDepartment;

    public DepartmentUIModel CurrentDepartment
    {
        get => _currentDepartment;
        set
        {
            _currentDepartment = value;
            _currentDepartment.LoadLecturers();
            BindingContext = CurrentDepartment;
        }
    }
    public DepartmentDetailsPage(IStorageService storage)
	{
		InitializeComponent();
        _storage = storage;
	}

    private void LecturerSelected(object sender, SelectionChangedEventArgs e)
    {
        var lecturer = (LecturerUIModel)e.CurrentSelection[0];
        Shell.Current.GoToAsync($"{nameof(LecturerDetailsPage)}", new Dictionary<string, object> { { nameof(LecturerDetailsPage.CurrentLecturer), lecturer } });
    }
}