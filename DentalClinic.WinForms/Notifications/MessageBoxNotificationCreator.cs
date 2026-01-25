namespace DentalClinic.WinForms.Notifications;

public sealed class MessageBoxNotificationCreator : NotificationCreator
{
    private readonly IWin32Window? _owner;

    public MessageBoxNotificationCreator(IWin32Window? owner)
    {
        _owner = owner;
    }

    protected override INotificationSender CreateSender()
        => new MessageBoxNotificationSender(_owner);
}
