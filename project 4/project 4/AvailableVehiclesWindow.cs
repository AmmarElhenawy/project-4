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
            LoadAvailableVehicles(); // تحميل المركبات المتاحة عند فتح النافذة
        }

        // دالة لتحميل المركبات المتاحة وعرضها في الجدولين (واحد للعربيات وواحد للموتوسيكلات)
        private void LoadAvailableVehicles()
        {
            // تحميل العربيات المتاحة من RentalManager وعرضها في جدول العربيات
            var availableCars = RentalManager.GetAvailableCars(); // جلب العربيات المتاحة فقط
            foreach (var car in availableCars)
            {
                dataGridViewCars.Rows.Add(
                    car.VehicleID, // رقم المركبة
                    $"{car.Manufacturer} {car.Model}", // الموديل (الشركة والطراز)
                    car.Price, // السعر
                    car.IsAvailable ? "نعم" : "لا", // حالة التوفر (متاح أو لا)
                    car.NoOfPassengers, // عدد الركاب
                    car.BagCapacity // سعة الحقائب
                );
            }

            // تحميل الموتوسيكلات المتاحة من RentalManager وعرضها في جدول الموتوسيكلات
            var availableMotorcycles = RentalManager.GetAvailableMotorcycles(); // جلب الموتوسيكلات المتاحة فقط
            foreach (var motorcycle in availableMotorcycles)
            {
                dataGridViewMotorcycles.Rows.Add(
                    motorcycle.VehicleID, // رقم المركبة
                    $"{motorcycle.Manufacturer} {motorcycle.Model}", // الموديل (الشركة والطراز)
                    motorcycle.Price, // السعر
                    motorcycle.IsAvailable ? "نعم" : "لا", // حالة التوفر (متاح أو لا)
                    motorcycle.HasSideCar ? "نعم" : "لا" // هل يحتوي على عربة جانبية
                );
            }
        }

        // دالة تفعيل عند اختيار مركبة من جدول العربيات (في المستقبل ممكن نضيف تفاعل هنا)
        private void dataGridViewCars_SelectionChanged(object sender, EventArgs e)
        {
            // سيتم تنفيذ الكود هنا عند اختيار مركبة من جدول العربيات
        }

        // دالة تفعيل عند اختيار مركبة من جدول الموتوسيكلات (في المستقبل ممكن نضيف تفاعل هنا)
        private void dataGridViewMotorcycles_SelectionChanged(object sender, EventArgs e)
        {
            // سيتم تنفيذ الكود هنا عند اختيار مركبة من جدول الموتوسيكلات
        }

        private void AvailableVehiclesForm_Load(object sender, EventArgs e)
        {

        }
    }
}