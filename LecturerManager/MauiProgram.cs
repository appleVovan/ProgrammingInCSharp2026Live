using KMA.ProgrammingInCSharp2026.LecturerManager.Pages;
using KMA.ProgrammingInCSharp2026.LecturerManager.Repositories;
using KMA.ProgrammingInCSharp2026.LecturerManager.Services;
using KMA.ProgrammingInCSharp2026.LecturerManager.Storage;
using KMA.ProgrammingInCSharp2026.LecturerManager.ViewModels;
using Microsoft.Extensions.Logging;

namespace KMA.ProgrammingInCSharp2026.LecturerManager
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<IStorageContext, FileStorageContext>();
            builder.Services.AddSingleton<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddSingleton<ILecturerRepository, LecturerRepository>();


            builder.Services.AddSingleton<IDepartmentService, DepartmentService>();
            builder.Services.AddSingleton<ILecturerService, LecturerService>();

            builder.Services.AddSingleton<DepartmentsPage>();
            builder.Services.AddTransient<DepartmentDetailsPage>();
            builder.Services.AddTransient<LecturerDetailsPage>();

            builder.Services.AddSingleton<DepartmentsViewModel>();
            builder.Services.AddTransient<DepartmentDetailsViewModel>();
            builder.Services.AddTransient<LecturerDetailsViewModel>();

            return builder.Build();

        }
    }
}
