namespace DentalClinic.WinForms
{
    partial class RegisterForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TableLayoutPanel table;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblPassword2;
        private System.Windows.Forms.Label lblFirst;
        private System.Windows.Forms.Label lblLast;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblBirth;

        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbPassword2;
        private System.Windows.Forms.TextBox tbFirstName;
        private System.Windows.Forms.TextBox tbLastName;
        private System.Windows.Forms.TextBox tbPhone;
        private System.Windows.Forms.DateTimePicker dtBirth;

        private System.Windows.Forms.FlowLayoutPanel panelButtons;
        private System.Windows.Forms.Button btnRegister;
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
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblPassword2 = new System.Windows.Forms.Label();
            this.lblFirst = new System.Windows.Forms.Label();
            this.lblLast = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblBirth = new System.Windows.Forms.Label();

            this.tbEmail = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbPassword2 = new System.Windows.Forms.TextBox();
            this.tbFirstName = new System.Windows.Forms.TextBox();
            this.tbLastName = new System.Windows.Forms.TextBox();
            this.tbPhone = new System.Windows.Forms.TextBox();
            this.dtBirth = new System.Windows.Forms.DateTimePicker();

            this.panelButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            this.table.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();

            // table
            this.table.ColumnCount = 2;
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));

            this.table.RowCount = 7;
            for (int i = 0; i < 7; i++)
                this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));

            this.table.Dock = System.Windows.Forms.DockStyle.Top;
            this.table.Location = new System.Drawing.Point(12, 12);
            this.table.Name = "table";
            this.table.Size = new System.Drawing.Size(520, 238);

            // labels
            this.lblEmail.Text = "E-mail"; this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; this.lblEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPassword.Text = "Hasło"; this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; this.lblPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPassword2.Text = "Powtórz hasło"; this.lblPassword2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; this.lblPassword2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFirst.Text = "Imię"; this.lblFirst.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; this.lblFirst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLast.Text = "Nazwisko"; this.lblLast.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; this.lblLast.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPhone.Text = "Numer telefonu"; this.lblPhone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; this.lblPhone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBirth.Text = "Data urodzenia"; this.lblBirth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; this.lblBirth.Dock = System.Windows.Forms.DockStyle.Fill;

            // textboxes
            this.tbEmail.Dock = System.Windows.Forms.DockStyle.Fill;

            this.tbPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPassword.PasswordChar = '●';

            this.tbPassword2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPassword2.PasswordChar = '●';

            this.tbFirstName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLastName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPhone.Dock = System.Windows.Forms.DockStyle.Fill;

            // dtBirth
            this.dtBirth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtBirth.ShowCheckBox = true;

            // dodanie kontrolek
            this.table.Controls.Add(this.lblEmail, 0, 0);
            this.table.Controls.Add(this.tbEmail, 1, 0);

            this.table.Controls.Add(this.lblPassword, 0, 1);
            this.table.Controls.Add(this.tbPassword, 1, 1);

            this.table.Controls.Add(this.lblPassword2, 0, 2);
            this.table.Controls.Add(this.tbPassword2, 1, 2);

            this.table.Controls.Add(this.lblFirst, 0, 3);
            this.table.Controls.Add(this.tbFirstName, 1, 3);

            this.table.Controls.Add(this.lblLast, 0, 4);
            this.table.Controls.Add(this.tbLastName, 1, 4);

            this.table.Controls.Add(this.lblPhone, 0, 5);
            this.table.Controls.Add(this.tbPhone, 1, 5);

            this.table.Controls.Add(this.lblBirth, 0, 6);
            this.table.Controls.Add(this.dtBirth, 1, 6);

            // panelButtons
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.panelButtons.Location = new System.Drawing.Point(12, 260);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(520, 40);

            // btnRegister
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(90, 29);
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);

            // btnCancel
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 29);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;

            this.panelButtons.Controls.Add(this.btnRegister);
            this.panelButtons.Controls.Add(this.btnCancel);

            // RegisterForm
            this.AcceptButton = this.btnRegister;
            this.CancelButton = this.btnCancel;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 312);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.table);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegisterForm";
            this.Padding = new System.Windows.Forms.Padding(12);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Zarejestruj";

            this.table.ResumeLayout(false);
            this.table.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
