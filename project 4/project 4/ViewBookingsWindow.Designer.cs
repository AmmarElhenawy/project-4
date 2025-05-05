namespace project_4
{
    partial class ViewBookingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox BookingsList;
        private System.Windows.Forms.Button CloseButton;

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
            this.BookingsList = new System.Windows.Forms.ListBox();
            this.CloseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BookingsList
            // 
            this.BookingsList.FormattingEnabled = true;
            this.BookingsList.ItemHeight = 16;
            this.BookingsList.Location = new System.Drawing.Point(20, 20);
            this.BookingsList.Name = "BookingsList";
            this.BookingsList.Size = new System.Drawing.Size(440, 196);
            this.BookingsList.TabIndex = 0;
            this.BookingsList.SelectedIndexChanged += new System.EventHandler(this.BookingsList_SelectedIndexChanged);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(200, 230);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(100, 30);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.Text = "Close";
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // ViewBookingsForm
            // 
            this.ClientSize = new System.Drawing.Size(500, 300);
            this.Controls.Add(this.BookingsList);
            this.Controls.Add(this.CloseButton);
            this.Name = "ViewBookingsForm";
            this.Text = "Show Bookings ";
            this.ResumeLayout(false);

        }
    }
}