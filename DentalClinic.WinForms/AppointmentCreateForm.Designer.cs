namespace DentalClinic.WinForms
{
    partial class AppointmentCreateForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TableLayoutPanel table;
        private System.Windows.Forms.Label lblPatient;
        private System.Windows.Forms.Label lblDentist;
        private System.Windows.Forms.Label lblService;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.ComboBox cbPatient;
        private System.Windows.Forms.ComboBox cbDentist;
        private System.Windows.Forms.ComboBox cbService;
        private System.Windows.Forms.DateTimePicker dtStart;
        private System.Windows.Forms.FlowLayoutPanel panelButtons;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.table = new System.Windows.Forms.TableLayoutPanel();
            this.lblPatient = new System.Windows.Forms.Label();
            this.lblDentist = new System.Windows.Forms.Label();
            this.lblService = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.cbPatient = new System.Windows.Forms.ComboBox();
            this.cbDentist = new System.Windows.Forms.ComboBox();
            this.cbService = new System.Windows.Forms.ComboBox();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.panelButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.table.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // table
            // 
            this.table.ColumnCount = 2;
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table.Controls.Add(this.lblPatient, 0, 0);
            this.table.Controls.Add(this.cbPatient, 1, 0);
            this.table.Controls.Add(this.lblDentist, 0, 1);
            this.table.Controls.Add(this.cbDentist, 1, 1);
            this.table.Controls.Add(this.lblService, 0, 2);
            this.table.Controls.Add(this.cbService, 1, 2);
            this.table.Controls.Add(this.lblStart, 0, 3);
            this.table.Controls.Add(this.dtStart, 1, 3);
            this.table.Dock = System.Windows.Forms.DockStyle.Top;
            this.table.Location = new System.Drawing.Point(12, 12);
            this.table.Name = "table";
            this.table.RowCount = 4;
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.table.Size = new System.Drawing.Size(560, 136);
            this.table.TabIndex = 0;
            // 
            // labels
            // 
            this.lblPatient.AutoSize = true; this.lblPatient.Dock = System.Windows.Forms.DockStyle.Fill; this.lblPatient.Text = "Patient"; this.lblPatient.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDentist.AutoSize = true; this.lblDentist.Dock = System.Windows.Forms.DockStyle.Fill; this.lblDentist.Text = "Dentist"; this.lblDentist.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblService.AutoSize = true; this.lblService.Dock = System.Windows.Forms.DockStyle.Fill; this.lblService.Text = "Service"; this.lblService.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStart.AutoSize = true; this.lblStart.Dock = System.Windows.Forms.DockStyle.Fill; this.lblStart.Text = "Start"; this.lblStart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboboxes
            // 
            this.cbPatient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cbPatient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbDentist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cbDentist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cbService.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // dtStart
            // 
            this.dtStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStart.CustomFormat = "yyyy-MM-dd HH:mm";
            // 
            // panelButtons
            // 
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.panelButtons.Location = new System.Drawing.Point(12, 160);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(560, 40);
            this.panelButtons.TabIndex = 1;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(482, 3);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 29);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(401, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 29);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // AppointmentCreateForm
            // 
            this.AcceptButton = this.btnOk;
            this.CancelButton = this.btnCancel;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 212);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.table);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AppointmentCreateForm";
            this.Padding = new System.Windows.Forms.Padding(12);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add appointment";
            this.panelButtons.Controls.Add(this.btnOk);
            this.panelButtons.Controls.Add(this.btnCancel);
            this.table.ResumeLayout(false);
            this.table.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
