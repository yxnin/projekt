using DentalClinic.Core.Interfaces.Patterns;
using DentalClinic.Core.Interfaces.Repositories;
using DentalClinic.Core.Interfaces.Services;
using DentalClinic.Core.Patterns;
using DentalClinic.Core.Services;
using DentalClinic.Infrastructure.Data;
using DentalClinic.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DentalClinic.WinForms;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        var host = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.AddDbContext<DentalClinicDbContext>(opt =>
                    opt.UseSqlite("Data Source=dentalclinic.db"));

                services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

                services.AddSingleton<AppSession>();

                // Formy
                services.AddTransient<MainForm>();
                services.AddTransient<LoginForm>();

                // Serwisy domenowe
                services.AddScoped<IAuthService, AuthService>();
                services.AddScoped<IPatientService, PatientService>();
                services.AddScoped<IDentistService, DentistService>();
                services.AddScoped<IServiceCatalogService, ServiceCatalogService>();
                services.AddScoped<IAppointmentService, AppointmentService>();

                // Mediator
                services.AddScoped<IClinicMediator, ClinicMediator>();
            })
            .Build();

        using (var scope = host.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<DentalClinicDbContext>();
            db.Database.Migrate();
        }

        ApplicationConfiguration.Initialize();
        Application.Run(host.Services.GetRequiredService<MainForm>());
    }
}
