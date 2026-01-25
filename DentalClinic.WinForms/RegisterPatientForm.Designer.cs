namespace DentalClinic.WinForms
{
    partial class RegisterPatientForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TableLayoutPanel table;
        private System.Windows.Forms.Label lblFirst;
        private System.Windows.Forms.Label lblLast;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblBirth;

        private System.Windows.Forms.TextBox tbFirstName;
        private System.Windows.Forms.TextBox tbLastName;
        private System.Windows.Forms.TextBox tbPhone;
        private System.Windows.Forms.DateTimePicker dtBirth;

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
            lblFirst = new Label();
            tbFirstName = new TextBox();
            lblLast = new Label();
            tbLastName = new TextBox();
            lblPhone = new Label();
            tbPhone = new TextBox();
            lblBirth = new Label();
            dtBirth = new DateTimePicker();
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
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            table.Controls.Add(lblFirst, 0, 0);
            table.Controls.Add(tbFirstName, 1, 0);
            table.Controls.Add(lblLast, 0, 1);
            table.Controls.Add(tbLastName, 1, 1);
            table.Controls.Add(lblPhone, 0, 2);
            table.Controls.Add(tbPhone, 1, 2);
            table.Controls.Add(lblBirth, 0, 3);
            table.Controls.Add(dtBirth, 1, 3);
            table.Dock = DockStyle.Top;
            table.Location = new Point(12, 12);
            table.Name = "table";
            table.RowCount = 4;
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            table.Size = new Size(460, 136);
            table.TabIndex = 1;
            // 
            // lblFirst
            // 
            lblFirst.AutoSize = true;
            lblFirst.Dock = DockStyle.Fill;
            lblFirst.Location = new Point(3, 0);
            lblFirst.Name = "lblFirst";
            lblFirst.Size = new Size(114, 34);
            lblFirst.TabIndex = 0;
            lblFirst.Text = "First name";
            lblFirst.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tbFirstName
            // 
            tbFirstName.Dock = DockStyle.Fill;
            tbFirstName.Location = new Point(123, 3);
            tbFirstName.Name = "tbFirstName";
            tbFirstName.Size = new Size(334, 23);
            tbFirstName.TabIndex = 1;
            // 
            // lblLast
            // 
            lblLast.AutoSize = true;
            lblLast.Dock = DockStyle.Fill;
            lblLast.Location = new Point(3, 34);
            lblLast.Name = "lblLast";
            lblLast.Size = new Size(114, 34);
            lblLast.TabIndex = 2;
            lblLast.Text = "Last name";
            lblLast.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tbLastName
            // 
            tbLastName.Dock = DockStyle.Fill;
            tbLastName.Location = new Point(123, 37);
            tbLastName.Name = "tbLastName";
            tbLastName.Size = new Size(334, 23);
            tbLastName.TabIndex = 3;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Dock = DockStyle.Fill;
            lblPhone.Location = new Point(3, 68);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(114, 34);
            lblPhone.TabIndex = 4;
            lblPhone.Text = "Phone";
            lblPhone.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tbPhone
            // 
            tbPhone.Dock = DockStyle.Fill;
            tbPhone.Location = new Point(123, 71);
            tbPhone.Name = "tbPhone";
            tbPhone.Size = new Size(334, 23);
            tbPhone.TabIndex = 5;
            // 
            // lblBirth
            // 
            lblBirth.AutoSize = true;
            lblBirth.Dock = DockStyle.Fill;
            lblBirth.Location = new Point(3, 102);
            lblBirth.Name = "lblBirth";
            lblBirth.Size = new Size(114, 34);
            lblBirth.TabIndex = 6;
            lblBirth.Text = "Birth date";
            lblBirth.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dtBirth
            // 
            dtBirth.Dock = DockStyle.Fill;
            dtBirth.Format = DateTimePickerFormat.Short;
            dtBirth.Location = new Point(123, 105);
            dtBirth.Name = "dtBirth";
            dtBirth.ShowCheckBox = true;
            dtBirth.Size = new Size(334, 23);
            dtBirth.TabIndex = 7;
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(btnOk);
            panelButtons.Controls.Add(btnCancel);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.FlowDirection = FlowDirection.RightToLeft;
            panelButtons.Location = new Point(12, 160);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(460, 40);
            panelButtons.TabIndex = 0;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(382, 3);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 29);
            btnOk.TabIndex = 0;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(301, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 29);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // RegisterPatientForm
            // 
            AcceptButton = btnOk;
            CancelButton = btnCancel;
            ClientSize = new Size(484, 212);
            Controls.Add(panelButtons);
            Controls.Add(table);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RegisterPatientForm";
            Padding = new Padding(12);
            StartPosition = FormStartPosition.CenterParent;
            Text = "Patient data";
            table.ResumeLayout(false);
            table.PerformLayout();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
