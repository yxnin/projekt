namespace DentalClinic.WinForms.Notifications;

public sealed class MessageBoxNotificationSender : INotificationSender
{
    private readonly IWin32Window? _owner;

    public MessageBoxNotificationSender(IWin32Window? owner)
    {
        _owner = owner;
    }

    public void Send(string title, string message)
    {
        MessageBox.Show(_owner, message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
