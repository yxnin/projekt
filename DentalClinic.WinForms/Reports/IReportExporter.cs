namespace DentalClinic.WinForms.Reports;

public interface IReportExporter<T>
{
    void Export(T data, string filePath);
}
