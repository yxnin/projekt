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
            table = new TableLayoutPanel();
            lblPatient = new Label();
            cbPatient = new ComboBox();
            lblDentist = new Label();
            cbDentist = new ComboBox();
            lblService = new Label();
            cbService = new ComboBox();
            lblStart = new Label();
            dtStart = new DateTimePicker();
            panelButtons = new FlowLayoutPanel();
            btnOk = new Button();
            btnCancel = new Button();
            table.SuspendLayout();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // table
            // 
            table.ColumnCount = 2;
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 105F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            table.Controls.Add(lblPatient, 0, 0);
            table.Controls.Add(cbPatient, 1, 0);
            table.Controls.Add(lblDentist, 0, 1);
            table.Controls.Add(cbDentist, 1, 1);
            table.Controls.Add(lblService, 0, 2);
            table.Controls.Add(cbService, 1, 2);
            table.Controls.Add(lblStart, 0, 3);
            table.Controls.Add(dtStart, 1, 3);
            table.Dock = DockStyle.Top;
            table.Location = new Point(10, 9);
            table.Margin = new Padding(3, 2, 3, 2);
            table.Name = "table";
            table.RowCount = 4;
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
            table.Size = new Size(491, 102);
            table.TabIndex = 0;
            // 
            // lblPatient
            // 
            lblPatient.AutoSize = true;
            lblPatient.Dock = DockStyle.Fill;
            lblPatient.Location = new Point(3, 0);
            lblPatient.Name = "lblPatient";
            lblPatient.Size = new Size(99, 26);
            lblPatient.TabIndex = 0;
            lblPatient.Text = "Patient";
            lblPatient.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cbPatient
            // 
            cbPatient.Dock = DockStyle.Fill;
            cbPatient.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPatient.Location = new Point(108, 2);
            cbPatient.Margin = new Padding(3, 2, 3, 2);
            cbPatient.Name = "cbPatient";
            cbPatient.Size = new Size(380, 23);
            cbPatient.TabIndex = 1;
            // 
            // lblDentist
            // 
            lblDentist.AutoSize = true;
            lblDentist.Dock = DockStyle.Fill;
            lblDentist.Location = new Point(3, 26);
            lblDentist.Name = "lblDentist";
            lblDentist.Size = new Size(99, 26);
            lblDentist.TabIndex = 2;
            lblDentist.Text = "Dentist";
            lblDentist.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cbDentist
            // 
            cbDentist.Dock = DockStyle.Fill;
            cbDentist.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDentist.Location = new Point(108, 28);
            cbDentist.Margin = new Padding(3, 2, 3, 2);
            cbDentist.Name = "cbDentist";
            cbDentist.Size = new Size(380, 23);
            cbDentist.TabIndex = 3;
            // 
            // lblService
            // 
            lblService.AutoSize = true;
            lblService.Dock = DockStyle.Fill;
            lblService.Location = new Point(3, 52);
            lblService.Name = "lblService";
            lblService.Size = new Size(99, 26);
            lblService.TabIndex = 4;
            lblService.Text = "Service";
            lblService.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cbService
            // 
            cbService.Dock = DockStyle.Fill;
            cbService.DropDownStyle = ComboBoxStyle.DropDownList;
            cbService.Location = new Point(108, 54);
            cbService.Margin = new Padding(3, 2, 3, 2);
            cbService.Name = "cbService";
            cbService.Size = new Size(380, 23);
            cbService.TabIndex = 5;
            // 
            // lblStart
            // 
            lblStart.AutoSize = true;
            lblStart.Dock = DockStyle.Fill;
            lblStart.Location = new Point(3, 78);
            lblStart.Name = "lblStart";
            lblStart.Size = new Size(99, 26);
            lblStart.TabIndex = 6;
            lblStart.Text = "Start";
            lblStart.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dtStart
            // 
            dtStart.CustomFormat = "yyyy-MM-dd HH:mm";
            dtStart.Dock = DockStyle.Fill;
            dtStart.Format = DateTimePickerFormat.Custom;
            dtStart.Location = new Point(108, 80);
            dtStart.Margin = new Padding(3, 2, 3, 2);
            dtStart.Name = "dtStart";
            dtStart.Size = new Size(380, 23);
            dtStart.TabIndex = 7;
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(btnOk);
            panelButtons.Controls.Add(btnCancel);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.FlowDirection = FlowDirection.RightToLeft;
            panelButtons.Location = new Point(10, 120);
            panelButtons.Margin = new Padding(3, 2, 3, 2);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(491, 30);
            panelButtons.TabIndex = 1;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(422, 2);
            btnOk.Margin = new Padding(3, 2, 3, 2);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(66, 22);
            btnOk.TabIndex = 0;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(350, 2);
            btnCancel.Margin = new Padding(3, 2, 3, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(66, 22);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // AppointmentCreateForm
            // 
            AcceptButton = btnOk;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(511, 159);
            Controls.Add(panelButtons);
            Controls.Add(table);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AppointmentCreateForm";
            Padding = new Padding(10, 9, 10, 9);
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add appointment";
            table.ResumeLayout(false);
            table.PerformLayout();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
