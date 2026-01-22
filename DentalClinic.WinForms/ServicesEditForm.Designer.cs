namespace DentalClinic.WinForms
{
    partial class ServiceEditForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TableLayoutPanel table;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblDuration;

        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.NumericUpDown nudPrice;
        private System.Windows.Forms.NumericUpDown nudDuration;

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
            lblName = new Label();
            tbName = new TextBox();
            lblPrice = new Label();
            nudPrice = new NumericUpDown();
            lblDuration = new Label();
            nudDuration = new NumericUpDown();
            panelButtons = new FlowLayoutPanel();
            btnOk = new Button();
            btnCancel = new Button();
            table.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudDuration).BeginInit();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // table
            // 
            table.ColumnCount = 2;
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 105F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            table.Controls.Add(lblName, 0, 0);
            table.Controls.Add(tbName, 1, 0);
            table.Controls.Add(lblPrice, 0, 1);
            table.Controls.Add(nudPrice, 1, 1);
            table.Controls.Add(lblDuration, 0, 2);
            table.Controls.Add(nudDuration, 1, 2);
            table.Dock = DockStyle.Top;
            table.Location = new Point(10, 9);
            table.Margin = new Padding(3, 2, 3, 2);
            table.Name = "table";
            table.RowCount = 3;
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
            table.Size = new Size(404, 76);
            table.TabIndex = 0;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Dock = DockStyle.Fill;
            lblName.Location = new Point(3, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(99, 26);
            lblName.TabIndex = 0;
            lblName.Text = "Name";
            lblName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tbName
            // 
            tbName.Dock = DockStyle.Fill;
            tbName.Location = new Point(108, 2);
            tbName.Margin = new Padding(3, 2, 3, 2);
            tbName.Name = "tbName";
            tbName.Size = new Size(293, 23);
            tbName.TabIndex = 0;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Dock = DockStyle.Fill;
            lblPrice.Location = new Point(3, 26);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(99, 26);
            lblPrice.TabIndex = 1;
            lblPrice.Text = "Price";
            lblPrice.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // nudPrice
            // 
            nudPrice.DecimalPlaces = 2;
            nudPrice.Dock = DockStyle.Fill;
            nudPrice.Location = new Point(108, 28);
            nudPrice.Margin = new Padding(3, 2, 3, 2);
            nudPrice.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudPrice.Name = "nudPrice";
            nudPrice.Size = new Size(293, 23);
            nudPrice.TabIndex = 1;
            // 
            // lblDuration
            // 
            lblDuration.AutoSize = true;
            lblDuration.Dock = DockStyle.Fill;
            lblDuration.Location = new Point(3, 52);
            lblDuration.Name = "lblDuration";
            lblDuration.Size = new Size(99, 26);
            lblDuration.TabIndex = 2;
            lblDuration.Text = "Duration (min)";
            lblDuration.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // nudDuration
            // 
            nudDuration.Dock = DockStyle.Fill;
            nudDuration.Location = new Point(108, 54);
            nudDuration.Margin = new Padding(3, 2, 3, 2);
            nudDuration.Maximum = new decimal(new int[] { 600, 0, 0, 0 });
            nudDuration.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudDuration.Name = "nudDuration";
            nudDuration.Size = new Size(293, 23);
            nudDuration.TabIndex = 2;
            nudDuration.Value = new decimal(new int[] { 30, 0, 0, 0 });
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
            panelButtons.Size = new Size(404, 30);
            panelButtons.TabIndex = 1;
            // 
            // btnOk
            // 
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
            // ServiceEditForm
            // 
            AcceptButton = btnOk;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(424, 136);
            Controls.Add(panelButtons);
            Controls.Add(table);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ServiceEditForm";
            Padding = new Padding(10, 9, 10, 9);
            StartPosition = FormStartPosition.CenterParent;
            Text = "Service";
            table.ResumeLayout(false);
            table.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudDuration).EndInit();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
