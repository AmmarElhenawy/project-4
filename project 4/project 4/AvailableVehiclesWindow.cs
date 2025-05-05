using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// using VehicleRentalApp.models;
using project_4.models; // هنا خلي بالك المسار حسب مكان الموديلات اللي عندك

namespace project_4
{
    // نافذة عرض المركبات المتاحة للإيجار
    public partial class AvailableVehiclesForm : Form
    {
        public AvailableVehiclesForm()
        {
            InitializeComponent(); // تهيئة مكونات النافذة (ثابت مع أي نافذة)
            // LoadAvailableVehicles will be called in Form Load event
        }

        // دالة لتحميل المركبات المتاحة وعرضها في الجدول
        private void LoadAvailableVehicles()
        {
            var vehicles = RentalManager.GetAvailableVehicles();
            dataGridViewVehicles.AutoGenerateColumns = false;
            dataGridViewVehicles.Columns.Clear();

            // Common columns
            dataGridViewVehicles.Columns.Add("VehicleID", "ID");
            dataGridViewVehicles.Columns.Add("Brand", "Brand");
            dataGridViewVehicles.Columns.Add("Model", "Model");
            dataGridViewVehicles.Columns.Add("Price", "Price");
            dataGridViewVehicles.Columns.Add("IsAvailable", "Available");

            // Car-specific columns
            var carBagCapacity = new DataGridViewTextBoxColumn();
            carBagCapacity.Name = "BagCapacity";
            carBagCapacity.HeaderText = "Bag Capacity";
            dataGridViewVehicles.Columns.Add(carBagCapacity);

            var carPassengerCapacity = new DataGridViewTextBoxColumn();
            carPassengerCapacity.Name = "PassengerCapacity";
            carPassengerCapacity.HeaderText = "Passenger Capacity";
            dataGridViewVehicles.Columns.Add(carPassengerCapacity);

            // Motorcycle-specific column
            var motoHasSidecar = new DataGridViewTextBoxColumn();
            motoHasSidecar.Name = "HasSidecar";
            motoHasSidecar.HeaderText = "Has Sidecar";
            dataGridViewVehicles.Columns.Add(motoHasSidecar);

            dataGridViewVehicles.Rows.Clear();
            foreach (var v in vehicles)
            {
                if (v is Car car)
                {
                    dataGridViewVehicles.Rows.Add(
                        car.VehicleID,
                        car.Brand,
                        car.Model,
                        car.Price,
                        car.IsAvailable ? "Yes" : "No",
                        car.PassengerCapacity,
                        car.BagCapacity,
                        ""
                    );
                }
                else if (v is Motorcycle moto)
                {
                    dataGridViewVehicles.Rows.Add(
                        moto.VehicleID,
                        moto.Brand,
                        moto.Model,
                        moto.Price,
                        moto.IsAvailable ? "Yes" : "No",
                        "",
                        "",
                        moto.HasSidecar ? "Yes" : "No"
                    );
                }
            }
        }

        private void AvailableVehiclesForm_Load_1(object sender, EventArgs e)
        {
            LoadAvailableVehicles();
        }

        private void dataGridViewVehicles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}