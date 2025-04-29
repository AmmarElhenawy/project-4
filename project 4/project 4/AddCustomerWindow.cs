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
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                int customerId = int.Parse(CustomerIdTextBox.Text);
                string name = NameTextBox.Text;
                int phone = int.Parse(PhoneTextBox.Text);
                int licenseNumber = int.Parse(LicenseNumberTextBox.Text);

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
                    LicenseNumber = licenseNumber
                });

                MessageBox.Show("تم إضافة العميل بنجاح!");
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

        private void LicenseNumberTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddCustomerForm_Load(object sender, EventArgs e)
        {

        }

        private void PhoneTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void CustomerIdTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}