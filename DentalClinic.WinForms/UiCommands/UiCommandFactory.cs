using DentalClinic.Core.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace DentalClinic.WinForms.UiCommands;

public class UiCommandFactory
{
    public IUiCommand Create(
        NavigationTarget target,
        IServiceProvider sp,
        AppSession session,
        Form owner)
    {
        return target switch
        {
            NavigationTarget.Patients => new OpenFormCommand<PatientsForm>(
                sp, owner, () => session.CurrentUser?.Role == UserRoles.Admin, "Brak dostępu (RODO)."),

            NavigationTarget.Appointments => new OpenFormCommand<AppointmentsForm>(
                sp, owner, () => session.CurrentUser?.Role == UserRoles.Admin, "Brak dostępu (RODO)."),

            NavigationTarget.Dentists => new OpenFormCommand<DentistsForm>(
                sp, owner, () => session.CurrentUser is not null, "Zaloguj się, aby wejść."),

            NavigationTarget.Services => new OpenFormCommand<ServicesForm>(
                sp, owner, () => session.CurrentUser is not null, "Zaloguj się, aby wejść."),
            NavigationTarget.MyAppointments => new OpenFormCommand<UserAppointmentsForm>(
sp, owner,
() => session.CurrentUser is not null && session.CurrentUser.Role != UserRoles.Admin && session.CurrentUser.PatientId is not null,
"Brak dostępu lub konto niepowiązane z pacjentem."
),


            _ => throw new ArgumentOutOfRangeException(nameof(target), target, null)
        };
    }

    private sealed class OpenFormCommand<TForm> : IUiCommand where TForm : Form
    {
        private readonly IServiceProvider _sp;
        private readonly Form _owner;
        private readonly Func<bool> _canOpen;
        private readonly string _denyMessage;

        public OpenFormCommand(IServiceProvider sp, Form owner, Func<bool> canOpen, string denyMessage)
        {
            _sp = sp;
            _owner = owner;
            _canOpen = canOpen;
            _denyMessage = denyMessage;
        }

        public void Execute()
        {
            if (!_canOpen())
            {
                MessageBox.Show(_denyMessage, "Access denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var form = _sp.GetRequiredService<TForm>();
            form.ShowDialog(_owner);
        }
    }
}
