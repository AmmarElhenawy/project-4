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
    public partial class AddCustomerForm : Form
    {
        public AddCustomerForm()
        {
            InitializeComponent();//static with any form
        }

        // عند الضغط على زر إضافة عميل جديد، يتم تنفيذ هذه الدالة
        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                // قراءة بيانات العميل من حقول النموذج

                // 1. قراءة رقم العميل من حقل النص
                int customerId = int.Parse(CustomerIdTextBox.Text);

                // 2. قراءة الاسم من حقل النص
                string name = NameTextBox.Text;

                // 3. قراءة رقم الهاتف من حقل النص
                int phone = int.Parse(PhoneTextBox.Text);

                // 4. قراءة رقم الترخيص من حقل النص
                int licenseNumber = int.Parse(LicenseNumberTextBox.Text);
            
        // التأكد من وجود قيمة مختارة في ComboBox
        if (LicenseTypeComboBox.SelectedItem == null)
        {
            MessageBox.Show("الرجاء اختيار نوع رخصة القيادة.");
            return;
        }
            // إضافة السطر التالي لأخذ نوع الرخصة // LicenseType is an enum in RentalManager
               LicenseType selectedLicenseType = (LicenseType)LicenseTypeComboBox.SelectedItem;


                // التأكد إن العميل مش موجود
                if (RentalManager.Customers.Exists(c => c.Id == customerId))
                {
                    MessageBox.Show("العميل ده موجود بالفعل! اختار رقم عميل مختلف.");
                    return;
                }

                // التأكد إن الاسم مش فاضي
                if (string.IsNullOrWhiteSpace(name))
                {
                    MessageBox.Show("الاسم ما ينفعش يكون فاضي!");
                    return;
                }

                // إضافة العميل
                RentalManager.Customers.Add(new Customer
                {
                    Id = customerId,
                    Name = name,
                    Phone = phone,
                    LicenseNumber = licenseNumber,
                    IsLicenseEgyptianOrNot = selectedLicenseType // إضافة الخاصية هنا
                });

                // إظهار رسالة إضافة العميل بنجاح
                MessageBox.Show("تم إضافة العميل بنجاح!");
                this.Close();
            }
            catch (Exception ex)
            {
                // إظهار رسالة خطأ
                MessageBox.Show($"حصل خطأ: {ex.Message}");
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            // إغلاق النافذة
            this.Close();
        }

        private void LicenseNumberTextBox_TextChanged(object sender, EventArgs e)
        {

        }
private void AddCustomerForm_Load(object sender, EventArgs e)
{
            LicenseTypeComboBox.DataSource = Enum.GetValues(typeof(LicenseType));
            LicenseTypeComboBox.SelectedIndex = 0; // اختيار القيمة الأولى كافتراضي
        }

        private void PhoneTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void CustomerIdTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void LicenseTypeComboBox_SelectChanged(object sender, EventArgs e)
        {

        }

        private void LicenseTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}