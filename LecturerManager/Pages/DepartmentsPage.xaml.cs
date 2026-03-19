using KMA.ProgrammingInCSharp2026.LecturerManager.ViewModels;
using System.Collections.ObjectModel;

namespace KMA.ProgrammingInCSharp2026.LecturerManager.Pages;

public partial class DepartmentsPage : ContentPage
{
    public DepartmentsPage(DepartmentsViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
    }
}