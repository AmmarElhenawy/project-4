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
    public partial class ViewBookingsForm : Form
    {
        public ViewBookingsForm()
        {
            InitializeComponent();//static with any form
            LoadBookings();
        }

        private void LoadBookings()
        {
            ///LoadBookings() بتجيب كل الحجوزات من RentalManager.Bookings وتعرضهم في BookingsList (الـ ListBox). 
            
            BookingsList.DataSource = null; //هذا الخطوة تمنع الـ ListBox من الاحتفاظ بالبيانات القديمة أو من محاولة عرض نفس البيانات مرتين
            BookingsList.DataSource = RentalManager.GetBookings();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
            ///لو المستخدم ضغط على زرار "إغلاق"، الدالة CloseButton_Click بتقفل النافذة.
        }

        private void BookingsList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}