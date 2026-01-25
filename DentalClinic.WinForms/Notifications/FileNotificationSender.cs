namespace DentalClinic.WinForms.Notifications;

public sealed class FileNotificationSender : INotificationSender
{
    private readonly string _path;

    public FileNotificationSender(string path)
    {
        _path = path;
    }

    public void Send(string title, string message)
    {
        var line = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | {title} | {message}{Environment.NewLine}";
        File.AppendAllText(_path, line);
    }
}
