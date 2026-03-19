using KMA.ProgrammingInChsarp2026.LecturerManager.DTOModels.Departments;
using KMA.ProgrammingInCSharp2026.LecturerManager.Repositories;
using KMA.ProgrammingInCSharp2026.LecturerManager.Services;
using KMA.ProgrammingInCSharp2026.LecturerManager.Storage;

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
        private static IDepartmentService _departmentService;
        private static ILecturerService _lecturerService;
        private static List<DepartmentListDTO> _departments;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
        static void Main(string[] args)
        {
            Console.WriteLine("Hello and welcome to the Lecturer Manager Console App!");
            var storageContext = new InMemoryStorageContext();
            var departmentRepo = new DepartmentRepository(storageContext);
            var lecturerRepo = new LecturerRepository(storageContext);

            _departmentService = new DepartmentService(departmentRepo, lecturerRepo);
            _lecturerService = new LecturerService(lecturerRepo);
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
            _departments = new List<DepartmentListDTO>();
            foreach (var department in _departmentService.GetAllDepartments())
            {
                _departments.Add(department);
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
                    Console.WriteLine($"Lecturers in {department.Name}:");
                    foreach (var lecturer in _lecturerService.GetLecturersByDepartment(department.Id))
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
