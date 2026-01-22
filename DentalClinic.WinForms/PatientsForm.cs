using DentalClinic.Core.Entities;
using DentalClinic.Core.Interfaces.Services;

namespace DentalClinic.WinForms;

public partial class PatientsForm : Form
{
    private readonly IPatientService? _patientService;
    private readonly AppSession? _session;

    public PatientsForm()
    {
        InitializeComponent();
    }

    public PatientsForm(IPatientService patientService, AppSession session) : this()
    {
        _patientService = patientService;
        _session = session;
    }

    private async void PatientsForm_Shown(object sender, EventArgs e)
    {
        ApplyPermissions();
        await ReloadAsync();
    }

    private void ApplyPermissions()
    {
        var isAdmin = _session?.CurrentUser?.Role == "Admin";
        btnDelete.Enabled = isAdmin;
    }

    private async void btnRefresh_Click(object sender, EventArgs e)
    {
        await ReloadAsync();
    }

    private async void btnAdd_Click(object sender, EventArgs e)
    {
        if (_patientService is null) return;

        using var dlg = new PatientEditForm();
        if (dlg.ShowDialog(this) != DialogResult.OK) return;

        try
        {
            await _patientService.CreateAsync(dlg.Result);
            await ReloadAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void btnEdit_Click(object sender, EventArgs e)
    {
        if (_patientService is null) return;

        var selected = GetSelected();
        if (selected is null) return;

        using var dlg = new PatientEditForm(selected);
        if (dlg.ShowDialog(this) != DialogResult.OK) return;

        try
        {
            await _patientService.UpdateAsync(dlg.Result);
            await ReloadAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void btnDelete_Click(object sender, EventArgs e)
    {
        if (_patientService is null) return;

        var isAdmin = _session?.CurrentUser?.Role == "Admin";
        if (!isAdmin)
        {
            MessageBox.Show("Only Admin can delete.", "Access denied",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var selected = GetSelected();
        if (selected is null) return;

        if (MessageBox.Show($"Delete patient #{selected.Id}?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            return;

        try
        {
            await _patientService.DeleteAsync(selected.Id);
            await ReloadAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private Patient? GetSelected()
    {
        if (gridPatients.CurrentRow?.DataBoundItem is Patient p)
            return p;

        MessageBox.Show("Select a patient first.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        return null;
    }

    private async Task ReloadAsync()
    {
        if (_patientService is null) return;

        var data = await _patientService.GetAllAsync();
        gridPatients.DataSource = data;
    }
}
