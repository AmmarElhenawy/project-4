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
    public partial class AvailableVehiclesForm : Form
    {
        public AvailableVehiclesForm()
        {
            InitializeComponent();
            LoadAvailableVehicles();
        }

        private void LoadAvailableVehicles()
        {
            // هنا انت بتجيب العربيات المتاحة
            var availableVehicles = RentalManager.GetAvailableVehicles();

            foreach (var vehicle in availableVehicles)
            {
                listBox1.Items.Add($"رقم المركبة: {vehicle.VehicleID} | الموديل: {vehicle.Model} | السعر: {vehicle.Price} جنيه/يوم");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

