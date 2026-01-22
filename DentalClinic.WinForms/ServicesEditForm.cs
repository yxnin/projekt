using DentalClinic.Core.Entities;

namespace DentalClinic.WinForms;

public partial class ServiceEditForm : Form
{
    public ServiceCatalogItem Result { get; private set; }

    public ServiceEditForm()
    {
        InitializeComponent();
        Result = new ServiceCatalogItem();
        LoadToControls(Result);
    }

    public ServiceEditForm(ServiceCatalogItem existing) : this()
    {
        Result = new ServiceCatalogItem
        {
            Id = existing.Id,
            Name = existing.Name,
            Price = existing.Price,
            DurationMinutes = existing.DurationMinutes
        };
        LoadToControls(Result);
    }

    private void LoadToControls(ServiceCatalogItem s)
    {
        tbName.Text = s.Name;
        nudPrice.Value = s.Price < 0 ? 0 : s.Price;
        nudDuration.Value = s.DurationMinutes <= 0 ? 30 : s.DurationMinutes;
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
        Result.Name = tbName.Text.Trim();
        Result.Price = nudPrice.Value;
        Result.DurationMinutes = (int)nudDuration.Value;

        if (string.IsNullOrWhiteSpace(Result.Name))
        {
            MessageBox.Show("Name is required.", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DialogResult = DialogResult.None;
            return;
        }

        DialogResult = DialogResult.OK;
        Close();
    }
}
