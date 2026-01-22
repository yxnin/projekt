namespace DentalClinic.WinForms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TableLayoutPanel table;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.TextBox tbPassword;

        private System.Windows.Forms.FlowLayoutPanel panelButtons;
        private System.Windows.Forms.Button btnLogin;
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
            table = new TableLayoutPanel();
            lblEmail = new Label();
            tbEmail = new TextBox();
            lblPassword = new Label();
            tbPassword = new TextBox();
            panelButtons = new FlowLayoutPanel();
            btnLogin = new Button();
            btnRegister = new Button();
            btnCancel = new Button();
            table.SuspendLayout();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // table
            // 
            table.ColumnCount = 2;
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 96F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            table.Controls.Add(lblEmail, 0, 0);
            table.Controls.Add(tbEmail, 1, 0);
            table.Controls.Add(lblPassword, 0, 1);
            table.Controls.Add(tbPassword, 1, 1);
            table.Dock = DockStyle.Top;
            table.Location = new Point(10, 9);
            table.Margin = new Padding(3, 2, 3, 2);
            table.Name = "table";
            table.RowCount = 2;
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
            table.Size = new Size(404, 51);
            table.TabIndex = 0;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Dock = DockStyle.Fill;
            lblEmail.Location = new Point(3, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(90, 26);
            lblEmail.TabIndex = 0;
            lblEmail.Text = "Email";
            lblEmail.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tbEmail
            // 
            tbEmail.Dock = DockStyle.Fill;
            tbEmail.Location = new Point(99, 2);
            tbEmail.Margin = new Padding(3, 2, 3, 2);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(302, 23);
            tbEmail.TabIndex = 2;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Dock = DockStyle.Fill;
            lblPassword.Location = new Point(3, 26);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(90, 26);
            lblPassword.TabIndex = 1;
            lblPassword.Text = "Password";
            lblPassword.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tbPassword
            // 
            tbPassword.Dock = DockStyle.Fill;
            tbPassword.Location = new Point(99, 28);
            tbPassword.Margin = new Padding(3, 2, 3, 2);
            tbPassword.Name = "tbPassword";
            tbPassword.PasswordChar = '●';
            tbPassword.Size = new Size(302, 23);
            tbPassword.TabIndex = 3;
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(btnLogin);
            panelButtons.Controls.Add(btnRegister);
            panelButtons.Controls.Add(btnCancel);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.FlowDirection = FlowDirection.RightToLeft;
            panelButtons.Location = new Point(10, 71);
            panelButtons.Margin = new Padding(3, 2, 3, 2);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(404, 30);
            panelButtons.TabIndex = 1;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(335, 2);
            btnLogin.Margin = new Padding(3, 2, 3, 2);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(66, 22);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(263, 2);
            btnRegister.Margin = new Padding(3, 2, 3, 2);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(66, 22);
            btnRegister.TabIndex = 1;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(191, 2);
            btnCancel.Margin = new Padding(3, 2, 3, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(66, 22);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // LoginForm
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(424, 110);
            Controls.Add(panelButtons);
            Controls.Add(table);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            Padding = new Padding(10, 9, 10, 9);
            StartPosition = FormStartPosition.CenterParent;
            Text = "Login";
            table.ResumeLayout(false);
            table.PerformLayout();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
