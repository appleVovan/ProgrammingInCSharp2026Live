using KMA.ProgrammingInCSharp2026.LecturerManager.ViewModels;

namespace KMA.ProgrammingInCSharp2026.LecturerManager.Pages;

public partial class LecturerDetailsPage : ContentPage
{
    private LecturerDetailsViewModel _viewModel;
    public LecturerDetailsPage(LecturerDetailsViewModel vm)
    {
        InitializeComponent();
        BindingContext = _viewModel = vm;
    }

    protected override async void OnAppearing()
    {
        await _viewModel.RefreshData();
    }
}