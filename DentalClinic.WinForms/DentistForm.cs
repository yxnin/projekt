using DentalClinic.Core.Entities;
using DentalClinic.Core.Interfaces.Services;

namespace DentalClinic.WinForms;

public partial class DentistsForm : Form
{
    private readonly IDentistService? _dentistService;
    private readonly AppSession? _session;

    public DentistsForm()
    {
        InitializeComponent();
    }

    public DentistsForm(IDentistService dentistService, AppSession session) : this()
    {
        _dentistService = dentistService;
        _session = session;
    }

    private async void DentistsForm_Shown(object sender, EventArgs e)
    {
        ApplyPermissions();
        await ReloadAsync();
    }

    private void ApplyPermissions()
    {
        var isAdmin = _session?.CurrentUser?.Role == UserRoles.Admin;

        // Tylko Admin może modyfikować dentystów
        btnAdd.Enabled = isAdmin;
        btnEdit.Enabled = isAdmin;
        btnDelete.Enabled = isAdmin;

        // Odśwież może każdy
        btnRefresh.Enabled = true;
    }

    private async void btnRefresh_Click(object sender, EventArgs e)
    {
        await ReloadAsync();
    }

    private async void btnAdd_Click(object sender, EventArgs e)
    {
        if (_dentistService is null) return;
        if (_session?.CurrentUser?.Role != UserRoles.Admin) return;

        using var dlg = new DentistEditForm();
        if (dlg.ShowDialog(this) != DialogResult.OK) return;

        try
        {
            await _dentistService.CreateAsync(dlg.Result);
            await ReloadAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void btnEdit_Click(object sender, EventArgs e)
    {
        if (_dentistService is null) return;
        if (_session?.CurrentUser?.Role != UserRoles.Admin) return;

        var selected = GetSelected();
        if (selected is null) return;

        using var dlg = new DentistEditForm(selected);
        if (dlg.ShowDialog(this) != DialogResult.OK) return;

        try
        {
            await _dentistService.UpdateAsync(dlg.Result);
            await ReloadAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void btnDelete_Click(object sender, EventArgs e)
    {
        if (_dentistService is null) return;
        if (_session?.CurrentUser?.Role != UserRoles.Admin) return;

        var selected = GetSelected();
        if (selected is null) return;

        if (MessageBox.Show($"Usunąć dentystę (ID={selected.Id})?", "Potwierdź",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            return;

        try
        {
            await _dentistService.DeleteAsync(selected.Id);
            await ReloadAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private Dentist? GetSelected()
    {
        if (gridDentists.CurrentRow?.DataBoundItem is Dentist d)
            return d;

        MessageBox.Show("Najpierw wybierz dentystę z listy.", "Informacja",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        return null;
    }

    private async Task ReloadAsync()
    {
        if (_dentistService is null) return;

        var data = await _dentistService.GetAllAsync();
        gridDentists.DataSource = data;

        ApplyPolishColumnHeaders();
    }

    private void ApplyPolishColumnHeaders()
    {
        if (gridDentists.Columns.Count == 0) return;

        if (gridDentists.Columns.Contains("FirstName"))
            gridDentists.Columns["FirstName"].HeaderText = "Imię";

        if (gridDentists.Columns.Contains("LastName"))
            gridDentists.Columns["LastName"].HeaderText = "Nazwisko";

        if (gridDentists.Columns.Contains("Phone"))
            gridDentists.Columns["Phone"].HeaderText = "Telefon";

        if (gridDentists.Columns.Contains("Specialization"))
            gridDentists.Columns["Specialization"].HeaderText = "Specjalizacja";

        // Ukryj techniczne
        if (gridDentists.Columns.Contains("Id"))
            gridDentists.Columns["Id"].Visible = false;

        if (gridDentists.Columns.Contains("CreatedUtc"))
            gridDentists.Columns["CreatedUtc"].Visible = false;
    }
}
