using DentalClinic.Core.Interfaces.Patterns;
using DentalClinic.Core.Interfaces.Repositories;
using DentalClinic.Core.Interfaces.Services;
using DentalClinic.Core.Patterns;
using DentalClinic.Core.Services;
using DentalClinic.Infrastructure.Data;
using DentalClinic.Infrastructure.Repositories;
using DentalClinic.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DentalClinic.WinForms;

internal static class Program
{
    public static IServiceProvider ServiceProvider { get; private set; } = default!;

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

                services.AddScoped<IAuthService, AuthService>();
                services.AddScoped<IPatientService, PatientService>();
                services.AddScoped<IDentistService, DentistService>();
                services.AddScoped<IServiceCatalogService, ServiceCatalogService>();
                services.AddScoped<IAppointmentService, AppointmentService>();

                services.AddScoped<IAppointmentReadService, AppointmentReadService>();
                services.AddScoped<IClinicMediator, ClinicMediator>();

                services.AddTransient<MainForm>();
                services.AddTransient<LoginForm>();

                services.AddTransient<PatientsForm>();
                services.AddTransient<PatientEditForm>();

                services.AddTransient<AppointmentsForm>();
                services.AddTransient<AppointmentCreateForm>();

                // NOWE: Dentyści
                services.AddTransient<DentistsForm>();
                services.AddTransient<DentistEditForm>();
            })
            .Build();

        ServiceProvider = host.Services;

        using (var scope = host.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<DentalClinicDbContext>();
            db.Database.Migrate();
            DbSeeder.SeedAsync(db).GetAwaiter().GetResult();
        }

        ApplicationConfiguration.Initialize();
        Application.Run(host.Services.GetRequiredService<MainForm>());
    }
}
