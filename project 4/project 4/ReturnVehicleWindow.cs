using project_4.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_4
{
    public partial class ReturnVehicleForm : Form
    {
        public ReturnVehicleForm()
        {
            InitializeComponent();// تهيئة المكونات //static with any form
            LoadComboBox();// تحميل قائمة المركبات المحجوزة
}
        

        private void LoadComboBox()
        {
            try
            {
                // نتأكد إن القايمة مش null
                if (RentalManager.Vehicles == null)
                {
                    MessageBox.Show("فشل في تحميل المركبات. تأكدي إن المركبات موجودة.");
                    return;
                }

                // تعبئة قايمة المركبات المحجوزة فقط
                VehicleComboBox.DataSource = RentalManager.Vehicles.Where(v => !v.IsAvailable).ToList();
                VehicleComboBox.DisplayMember = "DisplayText";
                VehicleComboBox.ValueMember = "VehicleID";

                // لو مفيش مركبات محجوزة، نعرض رسالة
                if (VehicleComboBox.Items.Count == 0)
                {
                    MessageBox.Show("مفيش مركبات محجوزة حاليًا للإرجاع.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حصل خطأ أثناء تحميل القايمة: {ex.Message}");
            }
        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (VehicleComboBox.SelectedValue == null)
                {
                    MessageBox.Show("اختاري مركبة من القايمة!");
                    return;
                }
                int vehicleId = (int)VehicleComboBox.SelectedValue;
                RentalManager.ReturnVehicle(vehicleId);
                MessageBox.Show("تم إرجاع المركبة بنجاح!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حصل خطأ: {ex.Message}");
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void VehicleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ممكن نستخدمها لو عايزين نعمل حاجة لما المستخدم يختار مركبة
        }

        private void ReturnVehicleForm_Load(object sender, EventArgs e)
        {

        }
    }
}