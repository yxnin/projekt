using DentalClinic.Core.Interfaces.Repositories;
using DentalClinic.Core.Interfaces.Services;
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
                // EF Core
                services.AddDbContext<DentalClinicDbContext>(opt =>
                    opt.UseSqlite("Data Source=dentalclinic.db"));

                // Repozytorium generyczne
                services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

                // Singleton (wymagany wzorzec)
                services.AddSingleton<AppSession>();

                // Rejestracja form
                services.AddTransient<MainForm>();
                services.AddTransient<LoginForm>();

                // TODO: serwisy domenowe
                // services.AddScoped<IAuthService, AuthService>();
            })
            .Build();

        // migracje na starcie (opcjonalnie)
        using (var scope = host.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<DentalClinicDbContext>();
            db.Database.Migrate();
        }

        ApplicationConfiguration.Initialize();
        Application.Run(host.Services.GetRequiredService<MainForm>());
    }
}
