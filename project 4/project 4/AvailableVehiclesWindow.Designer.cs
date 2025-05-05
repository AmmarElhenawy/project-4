using System.Windows.Forms;
using System;

namespace project_4
{
    partial class AvailableVehiclesForm
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelCars = new System.Windows.Forms.Label();
            this.labelMotorcycles = new System.Windows.Forms.Label();
            this.dataGridViewVehicles = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVehicles)).BeginInit();
            this.SuspendLayout();
            // 
            // labelCars
            // 
            this.labelCars.AutoSize = true;
            this.labelCars.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCars.Location = new System.Drawing.Point(12, 9);
            this.labelCars.Name = "labelCars";
            this.labelCars.Size = new System.Drawing.Size(68, 25);
            this.labelCars.TabIndex = 0;
            this.labelCars.Text = "عربيات";
            // 
            // labelMotorcycles
            // 
            this.labelMotorcycles.AutoSize = true;
            this.labelMotorcycles.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMotorcycles.Location = new System.Drawing.Point(12, 225);
            this.labelMotorcycles.Name = "labelMotorcycles";
            this.labelMotorcycles.Size = new System.Drawing.Size(100, 25);
            this.labelMotorcycles.TabIndex = 2;
            this.labelMotorcycles.Text = "موتوسيكلات";
            // 
            // dataGridViewVehicles
            // 
            this.dataGridViewVehicles.ColumnHeadersHeight = 29;
            this.dataGridViewVehicles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewVehicles.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewVehicles.Name = "dataGridViewVehicles";
            this.dataGridViewVehicles.RowHeadersWidth = 51;
            this.dataGridViewVehicles.Size = new System.Drawing.Size(800, 450);
            this.dataGridViewVehicles.TabIndex = 3;
            this.dataGridViewVehicles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewVehicles_CellContentClick);
            // 
            // AvailableVehiclesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewVehicles);
            this.Controls.Add(this.labelMotorcycles);
            this.Controls.Add(this.labelCars);
            this.Name = "AvailableVehiclesForm";
            this.Text = "Available Vehicle";            this.Load += new System.EventHandler(this.AvailableVehiclesForm_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVehicles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void dataGridViewMotorcycles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void dataGridViewCars_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Label labelCars;
        private System.Windows.Forms.Label labelMotorcycles;
        private System.Windows.Forms.DataGridView dataGridViewVehicles;

        // private void AvailableVehiclesForm_Load(object sender, EventArgs e)
        // {
        //     // Configure Cars DataGridView
        //     dataGridViewCars.Columns.Clear();
        //     dataGridViewCars.Columns.Add("ID", "ID");
        //     dataGridViewCars.Columns.Add("Model", "Model");
        //     dataGridViewCars.Columns.Add("Price", "Price");
        //     dataGridViewCars.Columns.Add("Available", "Available");
        //     dataGridViewCars.Columns.Add("NoOfPassengers", "No. Pass");
        //     dataGridViewCars.Columns.Add("BagCapacity", "Bag Capacity");

        //     // Populate Cars DataGridView
        //     foreach (var car in project_4.models.RentalManager.GetAvailableCars())
        //     {
        //         dataGridViewCars.Rows.Add(
        //             car.VehicleID,
        //             $"{car.Manufacturer} {car.Model}",
        //             car.Price,
        //             car.IsAvailable ? "Yes" : "No",
        //             car.NoOfPassengers,
        //             car.BagCapacity
        //         );
        //     }

        //     // Configure Motorcycles DataGridView
        //     dataGridViewMotorcycles.Columns.Clear();
        //     dataGridViewMotorcycles.Columns.Add("ID", "ID");
        //     dataGridViewMotorcycles.Columns.Add("Model", "Model");
        //     dataGridViewMotorcycles.Columns.Add("Price", "Price");
        //     dataGridViewMotorcycles.Columns.Add("Available", "Available");
        //     dataGridViewMotorcycles.Columns.Add("HasSidecar", "Has Sidecar");

        //     // Populate Motorcycles DataGridView
        //     foreach (var motorcycle in project_4.models.RentalManager.GetAvailableMotorcycles())
        //     {
        //         dataGridViewMotorcycles.Rows.Add(
        //             motorcycle.VehicleID,
        //             $"{motorcycle.Manufacturer} {motorcycle.Model}",
        //             motorcycle.Price,
        //             motorcycle.IsAvailable ? "Yes" : "No",
        //             motorcycle.HasSideCar ? "Yes" : "No"
        //         );
        //     }

        //     // Adjust column widths to fit content
        //     dataGridViewCars.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        //     dataGridViewMotorcycles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        // }
    }
}