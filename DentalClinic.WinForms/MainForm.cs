using DentalClinic.Core.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace DentalClinic.WinForms;

public partial class MainForm : Form
{
    private readonly IServiceProvider? _sp;
    private readonly AppSession? _session;

    public MainForm()
    {
        InitializeComponent();
    }

    public MainForm(IServiceProvider sp, AppSession session) : this()
    {
        _sp = sp;
        _session = session;
        RefreshStatusAndAccess();
    }

    private bool IsAdmin => _session?.CurrentUser?.Role == UserRoles.Admin;

    private void btnPatients_Click(object sender, EventArgs e)
    {
        if (_sp is null) return;

        if (!IsAdmin)
        {
            MessageBox.Show("Brak dostępu (RODO).", "Access denied",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        using var form = _sp.GetRequiredService<PatientsForm>();
        form.ShowDialog(this);
    }

    private void btnAppointments_Click(object sender, EventArgs e)
    {
        if (_sp is null) return;

        if (!IsAdmin)
        {
            MessageBox.Show("Brak dostępu (RODO).", "Access denied",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        using var form = _sp.GetRequiredService<AppointmentsForm>();
        form.ShowDialog(this);
    }

    private void btnDentists_Click(object sender, EventArgs e)
    {
        if (_sp is null) return;
        using var form = _sp.GetRequiredService<DentistsForm>();
        form.ShowDialog(this);
    }

    private void btnServices_Click(object sender, EventArgs e)
    {
        if (_sp is null) return;
        using var form = _sp.GetRequiredService<ServicesForm>();
        form.ShowDialog(this);
    }

    private void btnLogin_Click(object sender, EventArgs e)
    {
        if (_sp is null) return;
        using var f = _sp.GetRequiredService<LoginForm>();
        if (f.ShowDialog(this) == DialogResult.OK)
            RefreshStatusAndAccess();
    }

    private void RefreshStatusAndAccess()
    {
        if (_session?.CurrentUser is null)
        {
            lblStatus.Text = "Not logged in";
            btnPatients.Enabled = false;
            btnAppointments.Enabled = false;
            btnDentists.Enabled = false;
            btnServices.Enabled = false;
            return;
        }

        lblStatus.Text = $"Logged in as: {_session.CurrentUser.Email} (Role: {_session.CurrentUser.Role})";

        // zwykły user: może widzieć Dentystów i Usługi, ale NIE Pacjentów i Wizyt
        btnPatients.Enabled = IsAdmin;
        btnAppointments.Enabled = IsAdmin;

        btnDentists.Enabled = true;
        btnServices.Enabled = true;
    }
}
