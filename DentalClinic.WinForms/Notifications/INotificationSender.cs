namespace DentalClinic.WinForms.Notifications;

public interface INotificationSender
{
    void Send(string title, string message);
}
