using DentalClinic.Core.Entities;
using DentalClinic.Core.Interfaces.Services;

namespace DentalClinic.WinForms;

public partial class ServicesForm : Form
{
    private readonly IServiceCatalogService? _serviceCatalog;
    private readonly AppSession? _session;

    public ServicesForm()
    {
        InitializeComponent();
        // jeśli designer ma AutoGenerateColumns=true, zostawiamy jak jest
    }

    public ServicesForm(IServiceCatalogService serviceCatalog, AppSession session) : this()
    {
        _serviceCatalog = serviceCatalog;
        _session = session;
    }

    private async void ServicesForm_Shown(object sender, EventArgs e)
    {
        ApplyPermissions();
        await ReloadAsync();
    }

    private void ApplyPermissions()
    {
        var isAdmin = _session?.CurrentUser?.Role == "Admin";
        btnDelete.Enabled = isAdmin;
        btnAdd.Enabled = isAdmin;
        btnEdit.Enabled = isAdmin;
    }

    private async void btnRefresh_Click(object sender, EventArgs e)
    {
        await ReloadAsync();
    }

    private async void btnAdd_Click(object sender, EventArgs e)
    {
        if (_serviceCatalog is null) return;

        using var dlg = new ServiceEditForm();
        if (dlg.ShowDialog(this) != DialogResult.OK) return;

        try
        {
            await _serviceCatalog.CreateAsync(dlg.Result);
            await ReloadAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void btnEdit_Click(object sender, EventArgs e)
    {
        if (_serviceCatalog is null) return;

        var selected = GetSelected();
        if (selected is null) return;

        using var dlg = new ServiceEditForm(selected);
        if (dlg.ShowDialog(this) != DialogResult.OK) return;

        try
        {
            await _serviceCatalog.UpdateAsync(dlg.Result);
            await ReloadAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void btnDelete_Click(object sender, EventArgs e)
    {
        if (_serviceCatalog is null) return;

        var isAdmin = _session?.CurrentUser?.Role == "Admin";
        if (!isAdmin)
        {
            MessageBox.Show("Tylko administrator może usuwać.", "Brak dostępu",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var selected = GetSelected();
        if (selected is null) return;

        if (MessageBox.Show($"Usunąć usługę (ID={selected.Id})?", "Potwierdź",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            return;

        try
        {
            await _serviceCatalog.DeleteAsync(selected.Id);
            await ReloadAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private ServiceCatalogItem? GetSelected()
    {
        if (gridServices.CurrentRow?.DataBoundItem is ServiceCatalogItem s)
            return s;

        MessageBox.Show("Najpierw wybierz usługę z listy.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
        return null;
    }

    private async Task ReloadAsync()
    {
        if (_serviceCatalog is null) return;

        var data = await _serviceCatalog.GetAllAsync();
        gridServices.DataSource = data;

        ApplyPolishColumnHeaders();
    }

    private void ApplyPolishColumnHeaders()
    {
        if (gridServices.Columns.Count == 0) return;

        // Nagłówki po polsku
        if (gridServices.Columns.Contains("Name"))
            gridServices.Columns["Name"].HeaderText = "Nazwa";

        if (gridServices.Columns.Contains("Price"))
            gridServices.Columns["Price"].HeaderText = "Cena";

        if (gridServices.Columns.Contains("DurationMinutes"))
            gridServices.Columns["DurationMinutes"].HeaderText = "Czas (min)";

        // Techniczne – ukryj
        if (gridServices.Columns.Contains("Id"))
            gridServices.Columns["Id"].Visible = false;

        if (gridServices.Columns.Contains("CreatedUtc"))
            gridServices.Columns["CreatedUtc"].Visible = false;
    }
}
