using KMA.ProgrammingInChsarp2026.LecturerManager.UIModels;
using KMA.ProgrammingInCSharp2026.LecturerManager.Services;

namespace KMA.ProgrammingInCSharp2026.LecturerManager.ConsoleApp
{
    internal class Program
    {
        enum AppState
        {
            Default = 0,
            DepartmentDetails = 1,
            End = 2,
            Exit = 100,
        }

        private static AppState _appState = AppState.Default;
        private static IStorageService _storageService;
        private static List<DepartmentUIModel> _departments;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
        static void Main(string[] args)
        {
            Console.WriteLine("Hello and welcome to the Lecturer Manager Console App!");
            _storageService = new StorageService();
            string command = null;
            while (_appState != AppState.Exit)
            {
                switch (_appState)
                {
                    case AppState.DepartmentDetails:
                        DepartmentDetailsState(command);
                        break;
                    case AppState.Default:
                        DefaultState();
                        break;
                }
                Console.WriteLine("Type Exit to close application.");
                command = Console.ReadLine();
                UpdateState(command);
            }
        }
        private static void UpdateState(string command)
        {
            switch (command)
            {
                case "Back":
                    _appState = AppState.Default;
                    break;
                case "Exit":
                    _appState = AppState.Exit;
                    Console.WriteLine("Thank you and see you later!");
                    break;
                default:
                    switch (_appState)
                    {
                        case AppState.Default:
                            _appState = AppState.DepartmentDetails;
                            break;
                        case AppState.End:
                            Console.WriteLine("Unknown command. Please try again.");
                            break;
                    }
                    break;
            }
        }

        private static void DefaultState()
        {
            Console.WriteLine("Here is the list of all Departments: ");
            LoadDepartments();
            foreach (var department in _departments)
            {
                Console.WriteLine(department);
            }
            Console.WriteLine("Type the name of Department to see it's Lecturers.");
        }

        private static void LoadDepartments()
        {
            if (_departments != null)
                return;
            _departments = new List<DepartmentUIModel>();
            foreach (var department in _storageService.GetAllDepartments())
            {
                var departmentUIModel = new DepartmentUIModel(_storageService, department);
                _departments.Add(departmentUIModel);
            }
        }

        private static void DepartmentDetailsState(string departmentName)
        {
            bool departmentExists = false;
            foreach (var department in _departments)
            {
                if (department.Name == departmentName)
                {
                    departmentExists = true;
                    department.LoadLecturers();
                    Console.WriteLine($"Lecturers in {department.Name}:");
                    foreach (var lecturer in department.Lecturers)
                    {
                        Console.WriteLine(lecturer);
                    }
                }
            }
            if (!departmentExists)
                Console.WriteLine("Department not found. Please try again.");
            else
            {
                Console.WriteLine("Type Back to get list of all Departments.");
                _appState = AppState.End;
            }
        }
    }    
}
