using DentalClinic.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddDbContext<DentalClinicDbContext>(opt =>
            opt.UseSqlite("Data Source=dentalclinic.db"));

        // TODO: services.AddScoped<IUserService, UserService>();
        // TODO: services.AddScoped<IAppointmentService, AppointmentService>();

        // Singleton (wymagany wzorzec)
        services.AddSingleton<AppSession>();

        // Mediator (wymagany) - zarejestrujesz później
        // services.AddSingleton<IMediator, ClinicMediator>();

        services.AddTransient<App>(); // główna pętla UI
    })
    .Build();

// migracje automatycznie na starcie (wygodne w konsoli)
using (var scope = host.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DentalClinicDbContext>();
    db.Database.Migrate();
}

await host.Services.GetRequiredService<App>().RunAsync();