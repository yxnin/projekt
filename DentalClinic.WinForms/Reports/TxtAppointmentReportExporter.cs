using System.Text;
using DentalClinic.Core.Models;

namespace DentalClinic.WinForms.Reports;

public sealed class TxtAppointmentReportExporter : IReportExporter<List<AppointmentListItem>>
{
    public void Export(List<AppointmentListItem> data, string filePath)
    {
        var sb = new StringBuilder();
        sb.AppendLine("Appointments report");
        sb.AppendLine($"Generated: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
        sb.AppendLine($"Count: {data.Count}");
        sb.AppendLine(new string('-', 80));

        foreach (var a in data)
        {
            sb.AppendLine(
                $"#{a.AppointmentId} | {a.StartUtc:yyyy-MM-dd HH:mm} UTC | {a.Status} | " +
                $"Patient: {a.PatientFullName} | Dentist: {a.DentistFullName} | " +
                $"Service: {a.ServiceName} ({a.DurationMinutes} min, {a.ServicePrice} PLN)");
        }

        File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
    }
}
