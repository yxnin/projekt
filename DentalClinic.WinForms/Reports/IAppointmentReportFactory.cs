using DentalClinic.Core.Models;

namespace DentalClinic.WinForms.Reports;

public interface IAppointmentReportFactory
{
    string Format { get; }              // "TXT" / "JSON"
    string DefaultExtension { get; }    // ".txt" / ".json"
    string Description { get; }         // do dialogu

    IReportGenerator<List<AppointmentListItem>> CreateGenerator();
    IReportExporter<List<AppointmentListItem>> CreateExporter();
}
