namespace DentalClinic.WinForms.Notifications;

public sealed class FileNotificationCreator : NotificationCreator
{
    private readonly string _path;

    public FileNotificationCreator(string path)
    {
        _path = path;
    }

    protected override INotificationSender CreateSender()
        => new FileNotificationSender(_path);
}
