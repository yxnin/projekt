using DentalClinic.Core.Entities;
using DentalClinic.Core.Interfaces.Services;

namespace DentalClinic.WinForms;

public partial class DentistsForm : Form
{
    private readonly IDentistService? _dentistService;

    public DentistsForm()
    {
        InitializeComponent();
    }

    public DentistsForm(IDentistService dentistService) : this()
    {
        _dentistService = dentistService;
    }

    private async void DentistsForm_Shown(object sender, EventArgs e)
    {
        await ReloadAsync();
    }

    private async void btnRefresh_Click(object sender, EventArgs e)
    {
        await ReloadAsync();
    }

    private async void btnAdd_Click(object sender, EventArgs e)
    {
        if (_dentistService is null) return;

        using var dlg = new DentistEditForm();
        if (dlg.ShowDialog(this) != DialogResult.OK) return;

        try
        {
            await _dentistService.CreateAsync(dlg.Result);
            await ReloadAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void btnEdit_Click(object sender, EventArgs e)
    {
        if (_dentistService is null) return;

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
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void btnDelete_Click(object sender, EventArgs e)
    {
        if (_dentistService is null) return;

        var selected = GetSelected();
        if (selected is null) return;

        if (MessageBox.Show($"Delete dentist #{selected.Id}?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            return;

        try
        {
            await _dentistService.DeleteAsync(selected.Id);
            await ReloadAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private Dentist? GetSelected()
    {
        if (gridDentists.CurrentRow?.DataBoundItem is Dentist d)
            return d;

        MessageBox.Show("Select a dentist first.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        return null;
    }

    private async Task ReloadAsync()
    {
        if (_dentistService is null) return;

        var data = await _dentistService.GetAllAsync();
        gridDentists.DataSource = data;
    }
}
