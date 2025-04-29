namespace project_4
{
    partial class BookVehicleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.CustomerComboBox = new System.Windows.Forms.ComboBox();
            this.VehicleComboBox = new System.Windows.Forms.ComboBox();
            this.StartDatePicker = new System.Windows.Forms.DateTimePicker();
            this.EndDatePicker = new System.Windows.Forms.DateTimePicker();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.CustomerLabel = new System.Windows.Forms.Label();
            this.VehicleLabel = new System.Windows.Forms.Label();
            this.StartDateLabel = new System.Windows.Forms.Label();
            this.EndDateLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CustomerComboBox
            // 
            this.CustomerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CustomerComboBox.FormattingEnabled = true;
            this.CustomerComboBox.Location = new System.Drawing.Point(140, 20);
            this.CustomerComboBox.Name = "CustomerComboBox";
            this.CustomerComboBox.Size = new System.Drawing.Size(200, 24);
            this.CustomerComboBox.TabIndex = 0;
            this.CustomerComboBox.SelectedIndexChanged += new System.EventHandler(this.CustomerComboBox_SelectedIndexChanged);
            // 
            // VehicleComboBox
            // 
            this.VehicleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.VehicleComboBox.FormattingEnabled = true;
            this.VehicleComboBox.Location = new System.Drawing.Point(140, 60);
            this.VehicleComboBox.Name = "VehicleComboBox";
            this.VehicleComboBox.Size = new System.Drawing.Size(200, 24);
            this.VehicleComboBox.TabIndex = 1;
            this.VehicleComboBox.SelectedIndexChanged += new System.EventHandler(this.VehicleComboBox_SelectedIndexChanged);
            // 
            // StartDatePicker
            // 
            this.StartDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.StartDatePicker.Location = new System.Drawing.Point(140, 100);
            this.StartDatePicker.Name = "StartDatePicker";
            this.StartDatePicker.Size = new System.Drawing.Size(200, 22);
            this.StartDatePicker.TabIndex = 2;
            // 
            // EndDatePicker
            // 
            this.EndDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.EndDatePicker.Location = new System.Drawing.Point(140, 140);
            this.EndDatePicker.Name = "EndDatePicker";
            this.EndDatePicker.Size = new System.Drawing.Size(200, 22);
            this.EndDatePicker.TabIndex = 3;
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Location = new System.Drawing.Point(80, 190);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(100, 30);
            this.ConfirmButton.TabIndex = 4;
            this.ConfirmButton.Text = "تأكيد الحجز";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(200, 190);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(100, 30);
            this.CancelButton.TabIndex = 5;
            this.CancelButton.Text = "إلغاء";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // CustomerLabel
            // 
            this.CustomerLabel.AutoSize = true;
            this.CustomerLabel.Location = new System.Drawing.Point(30, 23);
            this.CustomerLabel.Name = "CustomerLabel";
            this.CustomerLabel.Size = new System.Drawing.Size(63, 16);
            this.CustomerLabel.TabIndex = 6;
            this.CustomerLabel.Text = "اختر العميل:";
            // 
            // VehicleLabel
            // 
            this.VehicleLabel.AutoSize = true;
            this.VehicleLabel.Location = new System.Drawing.Point(30, 63);
            this.VehicleLabel.Name = "VehicleLabel";
            this.VehicleLabel.Size = new System.Drawing.Size(69, 16);
            this.VehicleLabel.TabIndex = 7;
            this.VehicleLabel.Text = "اختر المركبة:";
            // 
            // StartDateLabel
            // 
            this.StartDateLabel.AutoSize = true;
            this.StartDateLabel.Location = new System.Drawing.Point(30, 103);
            this.StartDateLabel.Name = "StartDateLabel";
            this.StartDateLabel.Size = new System.Drawing.Size(68, 16);
            this.StartDateLabel.TabIndex = 8;
            this.StartDateLabel.Text = "تاريخ البداية:";
            // 
            // EndDateLabel
            // 
            this.EndDateLabel.AutoSize = true;
            this.EndDateLabel.Location = new System.Drawing.Point(30, 143);
            this.EndDateLabel.Name = "EndDateLabel";
            this.EndDateLabel.Size = new System.Drawing.Size(71, 16);
            this.EndDateLabel.TabIndex = 9;
            this.EndDateLabel.Text = "تاريخ النهاية:";
            // 
            // BookVehicleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 250);
            this.Controls.Add(this.EndDateLabel);
            this.Controls.Add(this.StartDateLabel);
            this.Controls.Add(this.VehicleLabel);
            this.Controls.Add(this.CustomerLabel);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.EndDatePicker);
            this.Controls.Add(this.StartDatePicker);
            this.Controls.Add(this.VehicleComboBox);
            this.Controls.Add(this.CustomerComboBox);
            this.Name = "BookVehicleForm";
            this.Text = "حجز مركبة";
            this.Load += new System.EventHandler(this.BookVehicleForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CustomerComboBox;
        private System.Windows.Forms.ComboBox VehicleComboBox;
        private System.Windows.Forms.DateTimePicker StartDatePicker;
        private System.Windows.Forms.DateTimePicker EndDatePicker;
        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label CustomerLabel;
        private System.Windows.Forms.Label VehicleLabel;
        private System.Windows.Forms.Label StartDateLabel;
        private System.Windows.Forms.Label EndDateLabel;
    }
}