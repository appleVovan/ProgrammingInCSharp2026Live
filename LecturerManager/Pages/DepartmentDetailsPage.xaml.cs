using KMA.ProgrammingInCSharp2026.LecturerManager.ViewModels;

namespace KMA.ProgrammingInCSharp2026.LecturerManager.Pages;

public partial class DepartmentDetailsPage : ContentPage
{    
    public DepartmentDetailsPage(DepartmentDetailsViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}