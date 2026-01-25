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
            this.btnPatients = new System.Windows.Forms.Button();
            this.btnAppointments = new System.Windows.Forms.Button();
            this.btnDentists = new System.Windows.Forms.Button();
            this.btnServices = new System.Windows.Forms.Button();
            this.btnMyAppointments = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnPatients
            // 
            this.btnPatients.Location = new System.Drawing.Point(24, 24);
            this.btnPatients.Name = "btnPatients";
            this.btnPatients.Size = new System.Drawing.Size(200, 45);
            this.btnPatients.TabIndex = 0;
            this.btnPatients.Text = "Pacjenci";
            this.btnPatients.UseVisualStyleBackColor = true;
            this.btnPatients.Click += new System.EventHandler(this.btnPatients_Click);
            // 
            // btnAppointments
            // 
            this.btnAppointments.Location = new System.Drawing.Point(24, 80);
            this.btnAppointments.Name = "btnAppointments";
            this.btnAppointments.Size = new System.Drawing.Size(200, 45);
            this.btnAppointments.TabIndex = 1;
            this.btnAppointments.Text = "Wizyty (admin)";
            this.btnAppointments.UseVisualStyleBackColor = true;
            this.btnAppointments.Click += new System.EventHandler(this.btnAppointments_Click);
            // 
            // btnDentists
            // 
            this.btnDentists.Location = new System.Drawing.Point(24, 136);
            this.btnDentists.Name = "btnDentists";
            this.btnDentists.Size = new System.Drawing.Size(200, 45);
            this.btnDentists.TabIndex = 2;
            this.btnDentists.Text = "Dentyści";
            this.btnDentists.UseVisualStyleBackColor = true;
            this.btnDentists.Click += new System.EventHandler(this.btnDentists_Click);
            // 
            // btnServices
            // 
            this.btnServices.Location = new System.Drawing.Point(24, 192);
            this.btnServices.Name = "btnServices";
            this.btnServices.Size = new System.Drawing.Size(200, 45);
            this.btnServices.TabIndex = 3;
            this.btnServices.Text = "Usługi";
            this.btnServices.UseVisualStyleBackColor = true;
            this.btnServices.Click += new System.EventHandler(this.btnServices_Click);
            // 
            // btnMyAppointments
            // 
            this.btnMyAppointments.Location = new System.Drawing.Point(24, 248);
            this.btnMyAppointments.Name = "btnMyAppointments";
            this.btnMyAppointments.Size = new System.Drawing.Size(200, 45);
            this.btnMyAppointments.TabIndex = 4;
            this.btnMyAppointments.Text = "Moje wizyty (user)";
            this.btnMyAppointments.UseVisualStyleBackColor = true;
            this.btnMyAppointments.Click += new System.EventHandler(this.btnMyAppointments_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(24, 304);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(200, 45);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(24, 360);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(200, 45);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "Wyloguj";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(24, 425);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(820, 23);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "Not logged in";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 500);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnMyAppointments);
            this.Controls.Add(this.btnServices);
            this.Controls.Add(this.btnDentists);
            this.Controls.Add(this.btnAppointments);
            this.Controls.Add(this.btnPatients);
            this.Name = "MainForm";
            this.Text = "DentalClinic";
            this.ResumeLayout(false);
        }
    }
}
