using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_4.models
{
    internal class Vehicle
    {
        public int VehicleID { get; set; }
        // public string Manufacturer { get; set; }    
            public string Brand { get; set; } // moved from derived classes
        public string Model { get; set; }
        public int Price { get; set; }
        public bool IsAvailable { get; set; } = true;

        // عرض المركبة في القوائم
        public string DisplayText => $"#{VehicleID} - {Brand} {Model} ({(IsAvailable ? "متاحة" : "محجوزة")})";
        public Vehicle() { }

        // constructor including Brand
        // البناء الرئيسي لإنشاء مركبة جديدة
        // يتطلب إدخال البيانات الأساسية للمركبة
        public Vehicle(int id, string brand, string model, int price)
        {
            VehicleID = id;
            Brand = brand;
            Model = model;
            Price = price;
            IsAvailable = true;
        }

        //public override string ToString()
        //{
        //    return $"{VehicleID}, {Brand}, {Model}, {Price}, {IsAvailable}";
        //}
    }
}
