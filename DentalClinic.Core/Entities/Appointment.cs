using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Core.Entities;

public class Appointment : EntityBase
{
    public int PatientId { get; set; }
    public Patient? Patient { get; set; }

    public int DentistId { get; set; }
    public Dentist? Dentist { get; set; }

    public int ServiceCatalogItemId { get; set; }
    public ServiceCatalogItem? Service { get; set; }

    public DateTime StartUtc { get; set; }
    public string Status { get; set; } = AppointmentStatus.Scheduled;
}

public static class AppointmentStatus
{
    public const string Scheduled = "Scheduled";
    public const string Cancelled = "Cancelled";
    public const string Done = "Done";

    public static bool IsValid(string status) =>
        status is Scheduled or Cancelled or Done;
}
