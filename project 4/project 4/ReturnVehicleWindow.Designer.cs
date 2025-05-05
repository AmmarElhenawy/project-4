namespace project_4
{
    partial class ReturnVehicleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox VehicleComboBox;
        private System.Windows.Forms.Button ReturnButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label label1;
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.VehicleComboBox = new System.Windows.Forms.ComboBox();
            this.ReturnButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // VehicleComboBox
            // 
            this.VehicleComboBox.Location = new System.Drawing.Point(180, 18);
            this.VehicleComboBox.Name = "VehicleComboBox";
            this.VehicleComboBox.Size = new System.Drawing.Size(180, 24);
            this.VehicleComboBox.TabIndex = 1;
            this.VehicleComboBox.SelectedIndexChanged += new System.EventHandler(this.VehicleComboBox_SelectedIndexChanged);
            // 
            // ReturnButton
            // 
            this.ReturnButton.Location = new System.Drawing.Point(90, 70);
            this.ReturnButton.Name = "ReturnButton";
            this.ReturnButton.Size = new System.Drawing.Size(100, 30);
            this.ReturnButton.TabIndex = 2;
            this.ReturnButton.Text = "Return";
            this.ReturnButton.Click += new System.EventHandler(this.ReturnButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(200, 70);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(100, 30);
            this.CancelButton.TabIndex = 3;
            this.CancelButton.Text = "Close";
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = " Select Vehicle To Return :";
            // 
            // ReturnVehicleForm
            // 
            this.ClientSize = new System.Drawing.Size(400, 130);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.VehicleComboBox);
            this.Controls.Add(this.ReturnButton);
            this.Controls.Add(this.CancelButton);
            this.Name = "ReturnVehicleForm";
            this.Text = "Return Vehicle ";
            this.Load += new System.EventHandler(this.ReturnVehicleForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}