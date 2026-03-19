using KMA.ProgrammingInCSharp2026.LecturerManager.ViewModels;

namespace KMA.ProgrammingInCSharp2026.LecturerManager.Pages;

public partial class LecturerDetailsPage : ContentPage
{
    public LecturerDetailsPage(LecturerDetailsViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
    }
}