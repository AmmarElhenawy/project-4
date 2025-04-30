using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_4.models
{
    public enum CarType { Sedan, SUV, Hatchback, Convertible }
    internal class Car : Vehicle
    {
        public CarType Type { get; set; }
        public int BagCapacity { get; set; } // سعة الأكياس
        public int PassengerCapacity { get; set; } // سعة الركاب
        public object Manufacturer { get; internal set; }
        public object NoOfPassengers { get; internal set; }

        // البناء الرئيسي لإنشاء سيارة جديدة
        // يتطلب إدخال البيانات الأساسية للسيارة
        public Car(int id, string brand, string model, CarType type, int price, int bagCapacity, int passengerCapacity)
            : base(id, brand, model, price)
        {
            Type = type;
            BagCapacity = bagCapacity;
            PassengerCapacity = passengerCapacity;
        }

        public override string ToString()
        {
            return $"{VehicleID}, {Brand}, {Model}, Bags:{BagCapacity}, Passengers:{PassengerCapacity}, {Type}, {Price}, {IsAvailable}";
        }
    }
}