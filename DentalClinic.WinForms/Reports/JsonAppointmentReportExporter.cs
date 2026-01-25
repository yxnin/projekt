using System.Text.Json;
using DentalClinic.Core.Models;

namespace DentalClinic.WinForms.Reports;

public sealed class JsonAppointmentReportExporter : IReportExporter<List<AppointmentListItem>>
{
    public void Export(List<AppointmentListItem> data, string filePath)
    {
        var json = JsonSerializer.Serialize(data, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(filePath, json);
    }
}
