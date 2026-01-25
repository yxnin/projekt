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
        var isAdmin = _session?.CurrentUser?.Role == UserRoles.Admin;

        // Pacjenci = dane wrażliwe, więc tylko admin ma edycję
        btnAdd.Enabled = isAdmin;
        btnEdit.Enabled = isAdmin;
        btnDelete.Enabled = isAdmin;

        btnRefresh.Enabled = true;
    }

    private async void btnRefresh_Click(object sender, EventArgs e)
    {
        await ReloadAsync();
    }

    private async void btnAdd_Click(object sender, EventArgs e)
    {
        if (_patientService is null) return;
        if (_session?.CurrentUser?.Role != UserRoles.Admin) return;

        using var dlg = new PatientEditForm();
        if (dlg.ShowDialog(this) != DialogResult.OK) return;

        try
        {
            await _patientService.CreateAsync(dlg.Result);
            await ReloadAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void btnEdit_Click(object sender, EventArgs e)
    {
        if (_patientService is null) return;
        if (_session?.CurrentUser?.Role != UserRoles.Admin) return;

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
            MessageBox.Show(ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void btnDelete_Click(object sender, EventArgs e)
    {
        if (_patientService is null) return;

        var isAdmin = _session?.CurrentUser?.Role == UserRoles.Admin;
        if (!isAdmin)
        {
            MessageBox.Show("Tylko administrator może usuwać.", "Brak dostępu",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var selected = GetSelected();
        if (selected is null) return;

        if (MessageBox.Show($"Usunąć pacjenta (ID={selected.Id})?", "Potwierdź",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            return;

        try
        {
            await _patientService.DeleteAsync(selected.Id);
            await ReloadAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private Patient? GetSelected()
    {
        if (gridPatients.CurrentRow?.DataBoundItem is Patient p)
            return p;

        MessageBox.Show("Najpierw wybierz pacjenta z listy.", "Informacja",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        return null;
    }

    private async Task ReloadAsync()
    {
        if (_patientService is null) return;

        var data = await _patientService.GetAllAsync();
        gridPatients.DataSource = data;

        ApplyPolishColumnHeaders();
    }

    private void ApplyPolishColumnHeaders()
    {
        if (gridPatients.Columns.Count == 0) return;

        if (gridPatients.Columns.Contains("FirstName"))
            gridPatients.Columns["FirstName"].HeaderText = "Imię";

        if (gridPatients.Columns.Contains("LastName"))
            gridPatients.Columns["LastName"].HeaderText = "Nazwisko";

        if (gridPatients.Columns.Contains("Phone"))
            gridPatients.Columns["Phone"].HeaderText = "Telefon";

        if (gridPatients.Columns.Contains("BirthDate"))
            gridPatients.Columns["BirthDate"].HeaderText = "Data urodzenia";

        // Ukryj techniczne
        if (gridPatients.Columns.Contains("Id"))
            gridPatients.Columns["Id"].Visible = false;

        if (gridPatients.Columns.Contains("CreatedUtc"))
            gridPatients.Columns["CreatedUtc"].Visible = false;
    }
}
