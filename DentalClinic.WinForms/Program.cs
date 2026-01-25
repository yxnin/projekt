using DentalClinic.Core.Interfaces.Patterns;
using DentalClinic.Core.Interfaces.Repositories;
using DentalClinic.Core.Interfaces.Services;
using DentalClinic.Core.Patterns;
using DentalClinic.Core.Services;
using DentalClinic.Infrastructure.Data;
using DentalClinic.Infrastructure.Repositories;
using DentalClinic.Infrastructure.Services;
using DentalClinic.WinForms.Reports;
using DentalClinic.WinForms.UiCommands;
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
                // EF Core
                services.AddDbContext<DentalClinicDbContext>(opt =>
                    opt.UseSqlite("Data Source=dentalclinic.db"));

                // repo
                services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

                // singleton 
                services.AddSingleton<AppSession>();

                // serwisy domenowe
                services.AddScoped<IAuthService, AuthService>();
                services.AddScoped<IPatientService, PatientService>();
                services.AddScoped<IDentistService, DentistService>();
                services.AddScoped<IServiceCatalogService, ServiceCatalogService>();
                services.AddScoped<IAppointmentService, AppointmentService>();

                // read service + mediator
                services.AddScoped<IAppointmentReadService, AppointmentReadService>();
                services.AddScoped<IClinicMediator, ClinicMediator>();

                // simple Factory
                services.AddSingleton<UiCommandFactory>();

                // abstract Factory
                services.AddTransient<IAppointmentReportFactory, TxtAppointmentReportFactory>();
                services.AddTransient<IAppointmentReportFactory, JsonAppointmentReportFactory>();

                // formy
                services.AddTransient<MainForm>();
                services.AddTransient<LoginForm>();

                services.AddTransient<PatientsForm>();
                services.AddTransient<PatientEditForm>();

                services.AddTransient<DentistsForm>();
                services.AddTransient<DentistEditForm>();

                services.AddTransient<ServicesForm>();
                services.AddTransient<ServiceEditForm>();
                
                services.AddTransient<AppointmentsForm>();
                services.AddTransient<AppointmentCreateForm>();

                // panel usera
                services.AddTransient<UserAppointmentsForm>();
                services.AddTransient<UserAppointmentCreateForm>();

                // rejestracja z danymi pacjenta
                services.AddTransient<RegisterPatientForm>();

                services.AddTransient<RegisterForm>();

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
