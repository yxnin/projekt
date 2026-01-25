namespace DentalClinic.WinForms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Button btnPatients;
        private System.Windows.Forms.Button btnAppointments;
        private System.Windows.Forms.Button btnDentists;
        private System.Windows.Forms.Button btnServices;
        private System.Windows.Forms.Button btnMyAppointments;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnPatients = new Button();
            btnAppointments = new Button();
            btnDentists = new Button();
            btnServices = new Button();
            btnMyAppointments = new Button();
            btnLogin = new Button();
            btnLogout = new Button();
            lblStatus = new Label();
            SuspendLayout();
            // 
            // btnPatients
            // 
            btnPatients.Location = new Point(21, 18);
            btnPatients.Margin = new Padding(3, 2, 3, 2);
            btnPatients.Name = "btnPatients";
            btnPatients.Size = new Size(175, 34);
            btnPatients.TabIndex = 0;
            btnPatients.Text = "Pacjenci";
            btnPatients.UseVisualStyleBackColor = true;
            btnPatients.Click += btnPatients_Click;
            // 
            // btnAppointments
            // 
            btnAppointments.Location = new Point(21, 60);
            btnAppointments.Margin = new Padding(3, 2, 3, 2);
            btnAppointments.Name = "btnAppointments";
            btnAppointments.Size = new Size(175, 34);
            btnAppointments.TabIndex = 1;
            btnAppointments.Text = "Wizyty (admin)";
            btnAppointments.UseVisualStyleBackColor = true;
            btnAppointments.Click += btnAppointments_Click;
            // 
            // btnDentists
            // 
            btnDentists.Location = new Point(21, 102);
            btnDentists.Margin = new Padding(3, 2, 3, 2);
            btnDentists.Name = "btnDentists";
            btnDentists.Size = new Size(175, 34);
            btnDentists.TabIndex = 2;
            btnDentists.Text = "Dentyści";
            btnDentists.UseVisualStyleBackColor = true;
            btnDentists.Click += btnDentists_Click;
            // 
            // btnServices
            // 
            btnServices.Location = new Point(21, 144);
            btnServices.Margin = new Padding(3, 2, 3, 2);
            btnServices.Name = "btnServices";
            btnServices.Size = new Size(175, 34);
            btnServices.TabIndex = 3;
            btnServices.Text = "Usługi";
            btnServices.UseVisualStyleBackColor = true;
            btnServices.Click += btnServices_Click;
            // 
            // btnMyAppointments
            // 
            btnMyAppointments.Location = new Point(21, 186);
            btnMyAppointments.Margin = new Padding(3, 2, 3, 2);
            btnMyAppointments.Name = "btnMyAppointments";
            btnMyAppointments.Size = new Size(175, 34);
            btnMyAppointments.TabIndex = 4;
            btnMyAppointments.Text = "Moje wizyty";
            btnMyAppointments.UseVisualStyleBackColor = true;
            btnMyAppointments.Click += btnMyAppointments_Click;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(21, 228);
            btnLogin.Margin = new Padding(3, 2, 3, 2);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(175, 34);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Zaloguj się";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(21, 270);
            btnLogout.Margin = new Padding(3, 2, 3, 2);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(175, 34);
            btnLogout.TabIndex = 6;
            btnLogout.Text = "Wyloguj";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // lblStatus
            // 
            lblStatus.Location = new Point(21, 319);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(718, 17);
            lblStatus.TabIndex = 7;
            lblStatus.Text = "Niezalogowano";
            lblStatus.Click += lblStatus_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(788, 375);
            Controls.Add(lblStatus);
            Controls.Add(btnLogout);
            Controls.Add(btnLogin);
            Controls.Add(btnMyAppointments);
            Controls.Add(btnServices);
            Controls.Add(btnDentists);
            Controls.Add(btnAppointments);
            Controls.Add(btnPatients);
            Margin = new Padding(3, 2, 3, 2);
            Name = "MainForm";
            Text = "DentalClinic";
            ResumeLayout(false);
        }
    }
}
