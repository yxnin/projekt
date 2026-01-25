using DentalClinic.WinForms.UiCommands;
using Microsoft.Extensions.DependencyInjection;

namespace DentalClinic.WinForms;

public partial class MainForm : Form
{
    private readonly IServiceProvider? _sp;
    private readonly AppSession? _session;
    private readonly UiCommandFactory? _factory;

    public MainForm()
    {
        InitializeComponent();
    }

    public MainForm(IServiceProvider sp, AppSession session, UiCommandFactory factory) : this()
    {
        _sp = sp;
        _session = session;
        _factory = factory;
        RefreshStatusAndAccess();
    }

    private void btnPatients_Click(object sender, EventArgs e) => ExecuteNav(NavigationTarget.Patients);
    private void btnAppointments_Click(object sender, EventArgs e) => ExecuteNav(NavigationTarget.Appointments);
    private void btnDentists_Click(object sender, EventArgs e) => ExecuteNav(NavigationTarget.Dentists);
    private void btnServices_Click(object sender, EventArgs e) => ExecuteNav(NavigationTarget.Services);
    private void btnMyAppointments_Click(object sender, EventArgs e) => ExecuteNav(NavigationTarget.MyAppointments);

    private void ExecuteNav(NavigationTarget target)
    {
        if (_sp is null || _session is null || _factory is null) return;
        var cmd = _factory.Create(target, _sp, _session, this);
        cmd.Execute();
    }

    private void btnLogin_Click(object sender, EventArgs e)
    {
        if (_sp is null) return;
        using var f = _sp.GetRequiredService<LoginForm>();
        if (f.ShowDialog(this) == DialogResult.OK)
            RefreshStatusAndAccess();
    }

    private void btnLogout_Click(object sender, EventArgs e)
    {
        if (_session is null) return;

        _session.SignOut();
        RefreshStatusAndAccess();
    }

    private void RefreshStatusAndAccess()
    {
        var user = _session?.CurrentUser;

        if (user is null)
        {
            lblStatus.Text = "Not logged in";
            btnPatients.Enabled = false;
            btnAppointments.Enabled = false;
            btnDentists.Enabled = false;
            btnServices.Enabled = false;
            btnMyAppointments.Enabled = false;
            btnLogout.Enabled = false;
            return;
        }

        lblStatus.Text = $"Logged in as: {user.Email} (Role: {user.Role})";

        // faktyczne zasady dostępu są w UiCommandFactory; tu tylko UX
        btnPatients.Enabled = true;
        btnAppointments.Enabled = true;
        btnDentists.Enabled = true;
        btnServices.Enabled = true;
        btnMyAppointments.Enabled = true;
        btnLogout.Enabled = true;
    }
}
