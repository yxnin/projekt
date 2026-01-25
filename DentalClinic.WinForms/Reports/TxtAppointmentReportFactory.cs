using DentalClinic.Core.Interfaces.Services;
using DentalClinic.Core.Models;

namespace DentalClinic.WinForms.Reports;

public sealed class TxtAppointmentReportFactory : IAppointmentReportFactory
{
    private readonly IAppointmentReadService _read;

    public TxtAppointmentReportFactory(IAppointmentReadService read)
    {
        _read = read;
    }

    public string Format => "TXT";
    public string DefaultExtension => ".txt";
    public string Description => "Text report|*.txt";


    public IReportGenerator<List<AppointmentListItem>> CreateGenerator()
        => new AppointmentListGenerator(_read);

    public IReportExporter<List<AppointmentListItem>> CreateExporter()
        => new TxtAppointmentReportExporter();
}
