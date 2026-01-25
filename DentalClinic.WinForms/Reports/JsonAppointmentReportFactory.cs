using DentalClinic.Core.Interfaces.Services;
using DentalClinic.Core.Models;

namespace DentalClinic.WinForms.Reports;

public sealed class JsonAppointmentReportFactory : IAppointmentReportFactory
{
    private readonly IAppointmentReadService _read;

    public JsonAppointmentReportFactory(IAppointmentReadService read)
    {
        _read = read;
    }

    public string Format => "JSON";
    public string DefaultExtension => ".json";
    public string Description => "JSON report|*.json";


    public IReportGenerator<List<AppointmentListItem>> CreateGenerator()
        => new AppointmentListGenerator(_read);

    public IReportExporter<List<AppointmentListItem>> CreateExporter()
        => new JsonAppointmentReportExporter();
}
