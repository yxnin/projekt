namespace DentalClinic.WinForms.Notifications;

public abstract class NotificationCreator
{
    // Factory Method
    protected abstract INotificationSender CreateSender();

    public void Notify(string title, string message)
    {
        var sender = CreateSender();
        sender.Send(title, message);
    }
}
