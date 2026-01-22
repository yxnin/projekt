namespace DentalClinic.WinForms
{
    partial class PatientEditForm
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
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 105F));
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
            table.Location = new Point(10, 9);
            table.Margin = new Padding(3, 2, 3, 2);
            table.Name = "table";
            table.RowCount = 4;
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
            table.Size = new Size(404, 102);
            table.TabIndex = 0;
            // 
            // lblFirst
            // 
            lblFirst.AutoSize = true;
            lblFirst.Dock = DockStyle.Fill;
            lblFirst.Location = new Point(3, 0);
            lblFirst.Name = "lblFirst";
            lblFirst.Size = new Size(99, 26);
            lblFirst.TabIndex = 0;
            lblFirst.Text = "First name";
            lblFirst.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tbFirstName
            // 
            tbFirstName.Dock = DockStyle.Fill;
            tbFirstName.Location = new Point(108, 2);
            tbFirstName.Margin = new Padding(3, 2, 3, 2);
            tbFirstName.Name = "tbFirstName";
            tbFirstName.Size = new Size(293, 23);
            tbFirstName.TabIndex = 1;
            // 
            // lblLast
            // 
            lblLast.AutoSize = true;
            lblLast.Dock = DockStyle.Fill;
            lblLast.Location = new Point(3, 26);
            lblLast.Name = "lblLast";
            lblLast.Size = new Size(99, 26);
            lblLast.TabIndex = 2;
            lblLast.Text = "Last name";
            lblLast.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tbLastName
            // 
            tbLastName.Dock = DockStyle.Fill;
            tbLastName.Location = new Point(108, 28);
            tbLastName.Margin = new Padding(3, 2, 3, 2);
            tbLastName.Name = "tbLastName";
            tbLastName.Size = new Size(293, 23);
            tbLastName.TabIndex = 3;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Dock = DockStyle.Fill;
            lblPhone.Location = new Point(3, 52);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(99, 26);
            lblPhone.TabIndex = 4;
            lblPhone.Text = "Phone";
            lblPhone.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tbPhone
            // 
            tbPhone.Dock = DockStyle.Fill;
            tbPhone.Location = new Point(108, 54);
            tbPhone.Margin = new Padding(3, 2, 3, 2);
            tbPhone.Name = "tbPhone";
            tbPhone.Size = new Size(293, 23);
            tbPhone.TabIndex = 5;
            // 
            // lblBirth
            // 
            lblBirth.AutoSize = true;
            lblBirth.Dock = DockStyle.Fill;
            lblBirth.Location = new Point(3, 78);
            lblBirth.Name = "lblBirth";
            lblBirth.Size = new Size(99, 26);
            lblBirth.TabIndex = 6;
            lblBirth.Text = "Birth date";
            lblBirth.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dtBirth
            // 
            dtBirth.Dock = DockStyle.Fill;
            dtBirth.Format = DateTimePickerFormat.Short;
            dtBirth.Location = new Point(108, 80);
            dtBirth.Margin = new Padding(3, 2, 3, 2);
            dtBirth.Name = "dtBirth";
            dtBirth.ShowCheckBox = true;
            dtBirth.Size = new Size(293, 23);
            dtBirth.TabIndex = 7;
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
            panelButtons.Size = new Size(404, 30);
            panelButtons.TabIndex = 1;
            // 
            // btnOk
            // 
            btnOk.DialogResult = DialogResult.OK;
            btnOk.Location = new Point(335, 2);
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
            btnCancel.Location = new Point(263, 2);
            btnCancel.Margin = new Padding(3, 2, 3, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(66, 22);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // PatientEditForm
            // 
            AcceptButton = btnOk;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(424, 159);
            Controls.Add(panelButtons);
            Controls.Add(table);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PatientEditForm";
            Padding = new Padding(10, 9, 10, 9);
            StartPosition = FormStartPosition.CenterParent;
            Text = "Patient";
            table.ResumeLayout(false);
            table.PerformLayout();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
