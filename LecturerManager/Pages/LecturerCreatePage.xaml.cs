using KMA.ProgrammingInChsarp2026.LecturerManager.Common;
using KMA.ProgrammingInChsarp2026.LecturerManager.Common.Enums;
using KMA.ProgrammingInCSharp2026.LecturerManager.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace KMA.ProgrammingInCSharp2026.LecturerManager.Pages;

public partial class LecturerCreatePage : ContentPage
{
	public LecturerCreatePage(LecturerCreateViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}