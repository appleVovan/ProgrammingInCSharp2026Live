using KMA.ProgrammingInChsarp2026.LecturerManager.Common;
using KMA.ProgrammingInChsarp2026.LecturerManager.Common.Enums;
using KMA.ProgrammingInChsarp2026.LecturerManager.UIModels;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace KMA.ProgrammingInCSharp2026.LecturerManager.Pages;

public partial class LecturerCreatePage : ContentPage
{
	public LecturerCreatePage()
	{
		InitializeComponent();
        pPosition.ItemsSource = EnumExtensions.GetValueWithNames<LecturerPosition>();
    }

    private void CreateClicked(object sender, EventArgs e)
    {
        if (String.IsNullOrWhiteSpace(eFistName.Text))
        {
            DisplayAlert("Incomplete data!", "First Name can't be empty", "OK");
            return;
        }
        if (String.IsNullOrWhiteSpace(eLastName.Text))
        {
            DisplayAlert("Incomplete data!", "Last Name can't be empty", "OK");
            return;
        }
        if (pPosition.SelectedItem == null)
        {
            DisplayAlert("Incomplete data!", "Position must be selected", "OK");
            return;
        }
        if (dpDoB.Date == null)
        {
            DisplayAlert("Incomplete data!", "Date of birth must be selected", "OK");
            return;
        }
        var lecturer = new LecturerUIModel(Guid.Empty)
        {
            FirstName = eFistName.Text,
            LastName = eLastName.Text,
            Position = ((EnumWithName<LecturerPosition>)pPosition.SelectedItem).Value,
            DateOfBirth = dpDoB.Date.Value
        };
        lecturer.SaveChangesToDBModel();
        DisplayAlert("Lecturer Created!", $"Lecturer {lecturer.FirstName} {lecturer.LastName} was created successfully, his age is {lecturer.Age}", "OK");
    }

    private void BackClicked(object sender, EventArgs e)
    {
        //TODO: navigate back to the previous page
    }
}