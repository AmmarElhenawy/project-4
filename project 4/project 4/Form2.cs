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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var window = new AvailableVehiclesForm();
            window.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var window = new AddCustomerForm();
            window.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var window = new BookVehicleForm();
            window.ShowDialog();
        }

        //private void button5_Click(object sender, EventArgs e)
        //{
        //    var window = new BookVehicleForm();
        //    window.ShowDialog();
        //}

        private void button5_Click(object sender, EventArgs e)
        {
            var window = new ReturnVehicleForm();
            window.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var window = new ViewBookingsForm();
            window.ShowDialog();
        }



    }
}
