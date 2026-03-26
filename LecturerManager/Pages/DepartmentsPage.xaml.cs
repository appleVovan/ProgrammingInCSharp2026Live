using KMA.ProgrammingInCSharp2026.LecturerManager.ViewModels;
using System.Collections.ObjectModel;

namespace KMA.ProgrammingInCSharp2026.LecturerManager.Pages;

public partial class DepartmentsPage : ContentPage
{
    private DepartmentsViewModel _viewModel;
    public DepartmentsPage(DepartmentsViewModel vm)
	{
		InitializeComponent();
		BindingContext = _viewModel = vm;
    }

    protected override async void OnAppearing()
    {
        await _viewModel.RefreshData();
    }
}