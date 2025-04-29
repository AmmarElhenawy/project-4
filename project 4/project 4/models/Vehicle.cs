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
        public string Model { get; set; }
        public int Price { get; set; }
        public bool IsAvailable { get; set; } = true;

        // خاصية جديدة لعرض الموديل مع الرقم في الـ ComboBox
        public string DisplayText => $"#{VehicleID} - {Model} ({(IsAvailable ? "متاحة" : "محجوزة")})";
        public Vehicle() { }

        public Vehicle(int id, string model, int price)
        {
            VehicleID = id;
            Model = model;
            Price = price;
            IsAvailable = true;
        }

        public override string ToString()
        {
            return $"{VehicleID}, {Model}, {Price}, {IsAvailable}";
        }
    }
}
