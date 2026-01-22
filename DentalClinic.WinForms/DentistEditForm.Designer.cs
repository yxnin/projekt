namespace DentalClinic.WinForms
{
    partial class DentistEditForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TableLayoutPanel table;
        private System.Windows.Forms.Label lblFirst;
        private System.Windows.Forms.Label lblLast;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblSpec;

        private System.Windows.Forms.TextBox tbFirstName;
        private System.Windows.Forms.TextBox tbLastName;
        private System.Windows.Forms.TextBox tbPhone;
        private System.Windows.Forms.TextBox tbSpecialization;

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
            this.lblFirst = new System.Windows.Forms.Label();
            this.lblLast = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblSpec = new System.Windows.Forms.Label();
            this.tbFirstName = new System.Windows.Forms.TextBox();
            this.tbLastName = new System.Windows.Forms.TextBox();
            this.tbPhone = new System.Windows.Forms.TextBox();
            this.tbSpecialization = new System.Windows.Forms.TextBox();
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
            this.table.Controls.Add(this.lblFirst, 0, 0);
            this.table.Controls.Add(this.tbFirstName, 1, 0);
            this.table.Controls.Add(this.lblLast, 0, 1);
            this.table.Controls.Add(this.tbLastName, 1, 1);
            this.table.Controls.Add(this.lblPhone, 0, 2);
            this.table.Controls.Add(this.tbPhone, 1, 2);
            this.table.Controls.Add(this.lblSpec, 0, 3);
            this.table.Controls.Add(this.tbSpecialization, 1, 3);
            this.table.Dock = System.Windows.Forms.DockStyle.Top;
            this.table.Location = new System.Drawing.Point(12, 12);
            this.table.Name = "table";
            this.table.RowCount = 4;
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.table.Size = new System.Drawing.Size(460, 136);
            this.table.TabIndex = 0;
            // 
            // labels
            // 
            this.lblFirst.AutoSize = true; this.lblFirst.Dock = System.Windows.Forms.DockStyle.Fill; this.lblFirst.Text = "First name"; this.lblFirst.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLast.AutoSize = true; this.lblLast.Dock = System.Windows.Forms.DockStyle.Fill; this.lblLast.Text = "Last name"; this.lblLast.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPhone.AutoSize = true; this.lblPhone.Dock = System.Windows.Forms.DockStyle.Fill; this.lblPhone.Text = "Phone"; this.lblPhone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSpec.AutoSize = true; this.lblSpec.Dock = System.Windows.Forms.DockStyle.Fill; this.lblSpec.Text = "Specialization"; this.lblSpec.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textboxes
            // 
            this.tbFirstName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLastName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPhone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSpecialization.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // panelButtons
            // 
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.panelButtons.Location = new System.Drawing.Point(12, 160);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(460, 40);
            this.panelButtons.TabIndex = 1;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(382, 3);
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
            this.btnCancel.Location = new System.Drawing.Point(301, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 29);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // DentistEditForm
            // 
            this.AcceptButton = this.btnOk;
            this.CancelButton = this.btnCancel;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 212);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.table);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DentistEditForm";
            this.Padding = new System.Windows.Forms.Padding(12);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dentist";
            this.panelButtons.Controls.Add(this.btnOk);
            this.panelButtons.Controls.Add(this.btnCancel);
            this.table.ResumeLayout(false);
            this.table.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
