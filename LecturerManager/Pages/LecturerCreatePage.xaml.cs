namespace KMA.ProgrammingInCSharp2026.LecturerManager.Pages;

public partial class LecturerCreatePage : ContentPage
{
	public LecturerCreatePage()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		var currentBut = (Button)sender;
		currentBut.Text += " Ha";
		if (currentBut.Text.StartsWith("Button 2"))
		{
			var newBut = new Button();
			newBut.Text = "Button 4";
			newBut.Clicked += Button_Clicked;
			Grid grid = (Grid)Content;
			grid.Children.Add(newBut);
			grid.SetRow(newBut, 1);
            grid.SetColumn(newBut, 1);
        } else if (currentBut.Text.StartsWith("Button 4"))
		{
            var newBut = new Button();
            newBut.Text = "Button 1";
            newBut.Clicked += Button_Clicked;
            Grid grid = (Grid)Content;
            grid.Children.Add(newBut);
            grid.SetRow(newBut, 0);
            grid.SetColumn(newBut, 0);
        }
    }
}