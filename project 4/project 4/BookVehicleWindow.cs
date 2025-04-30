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
    public partial class BookVehicleForm : Form
    {
        public BookVehicleForm()
        {
            InitializeComponent();//static with any form
            LoadComboBoxes(); // تحميل قوائم الاختيار عند فتح النافذة
        }

        private void LoadComboBoxes()
        {
            // هنا انت بتجيب العملاء والمركبات من مديرة الإيجار ,
            // و تعبئة القوائم في النافذة 
            //try catch لتجنب حدوث خطأ
            try
            {
                // نتأكد إن القوايم مش null
                if (RentalManager.Customers == null || RentalManager.GetAvailableVehicles() == null)
                {
                    MessageBox.Show("فشل في تحميل البيانات. تأكدي إن العملاء والمركبات موجودين.");
                    return;
                }

                // تعبئة قايمة العملاء
                // CustomerComboBox from designer page
                CustomerComboBox.DataSource = RentalManager.Customers;// RentalManager.Customers from RentalManager.cs // مصدر البيانات هو قائمة العملاء
                CustomerComboBox.DisplayMember = "DisplayText";// CustomerComboBox.DisplayMember = "DisplayText" from designer page // عرض اسم العميل
                CustomerComboBox.ValueMember = "Id";// CustomerComboBox.ValueMember = "Id" from designer page //  قيمة العميل و ربطه ب القيمة

                // تعبئة قايمة المركبات المتاحة
                // VehicleComboBox from designer page
                VehicleComboBox.DataSource = RentalManager.GetAvailableVehicles();// RentalManager.GetAvailableVehicles() from RentalManager.cs // مصدر البيانات هو قائمة المركبات المتاحة
                VehicleComboBox.DisplayMember = "DisplayText";// VehicleComboBox.DisplayMember = "DisplayText" from designer page // عرض اسم المركبة
                VehicleComboBox.ValueMember = "VehicleID";// VehicleComboBox.ValueMember = "VehicleID" from designer page //  قيمة المركبة و ربطه ب القيمة

                // لو مفيش عملاء أو مركبات، نعرض رسالة
                if (CustomerComboBox.Items.Count == 0)
                {
                    MessageBox.Show("مفيش عملاء مسجلين. أضيفي عملاء أولاً!");
                }
                if (VehicleComboBox.Items.Count == 0)
                {
                    MessageBox.Show("مفيش مركبات متاحة حاليًا.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حصل خطأ أثناء تحميل القوايم: {ex.Message}");
            }
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            try
            {
                // نتأكد إن العميل والمركبة مختارين
                if (CustomerComboBox.SelectedValue == null || VehicleComboBox.SelectedValue == null)
                {
                    MessageBox.Show("اختاري عميل ومركبة من القايمة!");
                    return;
                }

                // نتأكد إن التواريخ مختارة
                if (!StartDatePicker.Checked || !EndDatePicker.Checked)
                {
                    MessageBox.Show("اختاري تاريخ البداية وتاريخ النهاية!");
                    return;
                }

                // ناخد القيم من الـ ComboBox
                int customerId = (int)CustomerComboBox.SelectedValue; // رقم العميل المختار
                int vehicleId = (int)VehicleComboBox.SelectedValue; // رقم المركبة المختار
                DateTime start = StartDatePicker.Value; // تاريخ البداية
                DateTime end = EndDatePicker.Value; // تاريخ النهاية
                                                    // حساب عدد الأيام
                int days = (end - start).Days + 1; // +1 عشان نحسب اليوم الأول

                // جيب المركبة بناءً على vehicleId
                Vehicle vehicle = RentalManager.Vehicles.FirstOrDefault(v => v.VehicleID == vehicleId); 
                    // حساب التكلفة الإجمالية
                double totalCost = days * vehicle.Price;
                

                RentalManager.BookVehicle(vehicleId, customerId, start, end);// RentalManager.BookVehicle() from RentalManager.cs // حجز المركبة
                MessageBox.Show($"التكلفة الإجمالية للحجز: {totalCost} جنيه لمدة {days} أيام.", "تأكيد الحجز"); this.Close();
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

        private void CustomerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ممكن نستخدمها لو عايزين نعمل حاجة لما المستخدم يختار عميل
        }

        private void VehicleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ممكن نستخدمها لو عايزين نعمل حاجة لما المستخدم يختار مركبة
        }

        private void BookVehicleForm_Load(object sender, EventArgs e)
        {

        }
    }
}