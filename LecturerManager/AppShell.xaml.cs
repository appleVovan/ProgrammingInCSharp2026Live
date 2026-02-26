using KMA.ProgrammingInCSharp2026.LecturerManager.Pages;

namespace KMA.ProgrammingInCSharp2026.LecturerManager
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute($"{nameof(DepartmentsPage)}/{nameof(DepartmentDetailsPage)}", typeof(DepartmentDetailsPage));
            Routing.RegisterRoute($"{nameof(DepartmentsPage)}/{nameof(DepartmentDetailsPage)}/{nameof(LecturerDetailsPage)}", typeof(LecturerDetailsPage));
        }
    }
}
