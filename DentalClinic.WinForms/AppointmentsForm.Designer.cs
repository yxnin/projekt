namespace DentalClinic.WinForms
{
    partial class AppointmentsForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.TextBox tbFilter;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancelAppointment;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridView gridAppointments;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnCancelAppointment = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.tbFilter = new System.Windows.Forms.TextBox();
            this.gridAppointments = new System.Windows.Forms.DataGridView();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAppointments)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.btnExport);
            this.panelTop.Controls.Add(this.btnCancelAppointment);
            this.panelTop.Controls.Add(this.btnAdd);
            this.panelTop.Controls.Add(this.btnRefresh);
            this.panelTop.Controls.Add(this.tbFilter);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Padding = new System.Windows.Forms.Padding(8);
            this.panelTop.Size = new System.Drawing.Size(1100, 50);
            this.panelTop.TabIndex = 0;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(1010, 10);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(80, 30);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "Exportuj";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnCancelAppointment
            // 
            this.btnCancelAppointment.Location = new System.Drawing.Point(880, 10);
            this.btnCancelAppointment.Name = "btnCancelAppointment";
            this.btnCancelAppointment.Size = new System.Drawing.Size(120, 30);
            this.btnCancelAppointment.TabIndex = 3;
            this.btnCancelAppointment.Text = "Anuluj";
            this.btnCancelAppointment.UseVisualStyleBackColor = true;
            this.btnCancelAppointment.Click += new System.EventHandler(this.btnCancelAppointment_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(770, 10);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 30);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Dodaj";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(660, 10);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 30);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Odśwież";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // tbFilter
            // 
            this.tbFilter.Location = new System.Drawing.Point(8, 12);
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.PlaceholderText = "Filtry (np. status=scheduled AND dentistID=1 AND date>=2026-01-01";
            this.tbFilter.Size = new System.Drawing.Size(640, 27);
            this.tbFilter.TabIndex = 0;
            // 
            // gridAppointments
            // 
            this.gridAppointments.AllowUserToAddRows = false;
            this.gridAppointments.AllowUserToDeleteRows = false;
            this.gridAppointments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAppointments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAppointments.Location = new System.Drawing.Point(0, 50);
            this.gridAppointments.MultiSelect = false;
            this.gridAppointments.Name = "gridAppointments";
            this.gridAppointments.ReadOnly = true;
            this.gridAppointments.RowHeadersWidth = 51;
            this.gridAppointments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridAppointments.Size = new System.Drawing.Size(1100, 550);
            this.gridAppointments.TabIndex = 1;
            // 
            // AppointmentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 600);
            this.Controls.Add(this.gridAppointments);
            this.Controls.Add(this.panelTop);
            this.Name = "AppointmentsForm";
            this.Text = "Wizyty";
            this.Shown += new System.EventHandler(this.AppointmentsForm_Shown);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAppointments)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
