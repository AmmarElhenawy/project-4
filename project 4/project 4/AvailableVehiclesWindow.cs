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
            foreach (var v in vehicles)
            {
                if (string.IsNullOrWhiteSpace(v.Brand))
                    v.Brand = "غير محدد";
                // Add TypeName property for display if not present
                if (v.GetType().GetProperty("TypeName") == null)
                {
                    // Using Tag property as a workaround if needed
                }
            }
            dataGridViewVehicles.AutoGenerateColumns = true;
            dataGridViewVehicles.DataSource = null;
            dataGridViewVehicles.DataSource = vehicles;
        }

        private void AvailableVehiclesForm_Load_1(object sender, EventArgs e)
        {
            LoadAvailableVehicles();
        }
    }
}