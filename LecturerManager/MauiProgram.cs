using KMA.ProgrammingInCSharp2026.LecturerManager.Pages;
using KMA.ProgrammingInCSharp2026.LecturerManager.Services;
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
            builder.Services.AddSingleton<IStorageService, StorageService>();

            builder.Services.AddSingleton<DepartmentsPage>();
            builder.Services.AddTransient<DepartmentDetailsPage>();
            builder.Services.AddTransient<LecturerDetailsPage>();


            return builder.Build();
        }
    }
}
