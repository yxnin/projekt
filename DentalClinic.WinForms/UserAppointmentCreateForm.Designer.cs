namespace DentalClinic.WinForms
{
    partial class UserAppointmentCreateForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TableLayoutPanel table;
        private System.Windows.Forms.Label lblDentist;
        private System.Windows.Forms.Label lblService;
        private System.Windows.Forms.Label lblStart;
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
            table.Controls.Add(lblDentist, 0, 0);
            table.Controls.Add(cbDentist, 1, 0);
            table.Controls.Add(lblService, 0, 1);
            table.Controls.Add(cbService, 1, 1);
            table.Controls.Add(lblStart, 0, 2);
            table.Controls.Add(dtStart, 1, 2);
            table.Dock = DockStyle.Top;
            table.Location = new Point(10, 9);
            table.Margin = new Padding(3, 2, 3, 2);
            table.Name = "table";
            table.RowCount = 3;
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
            table.Size = new Size(491, 76);
            table.TabIndex = 0;
            // 
            // lblDentist
            // 
            lblDentist.AutoSize = true;
            lblDentist.Dock = DockStyle.Fill;
            lblDentist.Location = new Point(3, 0);
            lblDentist.Name = "lblDentist";
            lblDentist.Size = new Size(99, 26);
            lblDentist.TabIndex = 0;
            lblDentist.Text = "Dentysta";
            lblDentist.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cbDentist
            // 
            cbDentist.Dock = DockStyle.Fill;
            cbDentist.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDentist.Location = new Point(108, 2);
            cbDentist.Margin = new Padding(3, 2, 3, 2);
            cbDentist.Name = "cbDentist";
            cbDentist.Size = new Size(380, 23);
            cbDentist.TabIndex = 1;
            // 
            // lblService
            // 
            lblService.AutoSize = true;
            lblService.Dock = DockStyle.Fill;
            lblService.Location = new Point(3, 26);
            lblService.Name = "lblService";
            lblService.Size = new Size(99, 26);
            lblService.TabIndex = 2;
            lblService.Text = "Usługa";
            lblService.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cbService
            // 
            cbService.Dock = DockStyle.Fill;
            cbService.DropDownStyle = ComboBoxStyle.DropDownList;
            cbService.Location = new Point(108, 28);
            cbService.Margin = new Padding(3, 2, 3, 2);
            cbService.Name = "cbService";
            cbService.Size = new Size(380, 23);
            cbService.TabIndex = 3;
            // 
            // lblStart
            // 
            lblStart.AutoSize = true;
            lblStart.Dock = DockStyle.Fill;
            lblStart.Location = new Point(3, 52);
            lblStart.Name = "lblStart";
            lblStart.Size = new Size(99, 26);
            lblStart.TabIndex = 4;
            lblStart.Text = "Data";
            lblStart.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dtStart
            // 
            dtStart.CustomFormat = "yyyy-MM-dd HH:mm";
            dtStart.Dock = DockStyle.Fill;
            dtStart.Format = DateTimePickerFormat.Custom;
            dtStart.Location = new Point(108, 54);
            dtStart.Margin = new Padding(3, 2, 3, 2);
            dtStart.Name = "dtStart";
            dtStart.Size = new Size(380, 23);
            dtStart.TabIndex = 5;
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(btnOk);
            panelButtons.Controls.Add(btnCancel);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.FlowDirection = FlowDirection.RightToLeft;
            panelButtons.Location = new Point(10, 97);
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
            btnOk.Text = "Potwierdź";
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
            btnCancel.Text = "Anuluj";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // UserAppointmentCreateForm
            // 
            AcceptButton = btnOk;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(511, 136);
            Controls.Add(panelButtons);
            Controls.Add(table);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UserAppointmentCreateForm";
            Padding = new Padding(10, 9, 10, 9);
            StartPosition = FormStartPosition.CenterParent;
            Text = "Zaplanuj wizytę";
            table.ResumeLayout(false);
            table.PerformLayout();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
