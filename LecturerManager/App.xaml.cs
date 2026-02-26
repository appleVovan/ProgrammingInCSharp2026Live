using Microsoft.Extensions.DependencyInjection;

namespace KMA.ProgrammingInCSharp2026.LecturerManager
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState activationState)
        {
            return new Window(new AppShell());
        }
    }
}