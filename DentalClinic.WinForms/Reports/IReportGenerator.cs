namespace DentalClinic.WinForms.Reports;

public interface IReportGenerator<T>
{
    Task<T> GenerateAsync(string? filterText, CancellationToken ct = default);
}
