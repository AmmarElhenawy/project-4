using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_4.models
{
    public enum BikeType { Cruiser, Sport, Touring, Naked }

    internal class Motorcycle : Vehicle
    {
        public BikeType Type { get; set; }
        public bool HasSidecar { get; set; } // وجود مقطورة جانبية
        public object Manufacturer { get; internal set; }
        public bool HasSideCar { get; internal set; }

        // البناء الرئيسي لإنشاء دراجة جديدة
        // يتطلب إدخال البيانات الأساسية للدراجة
        public Motorcycle(int id, string brand, string model, BikeType type, int price, bool hasSidecar)
            : base(id, brand, model, price)
        {
            Type = type;
            HasSidecar = hasSidecar;
        }

        public override string ToString()
        {
            return $"{VehicleID}, {Model}, Sidecar:{(HasSidecar ? "Yes" : "No")}, {Type}, {Price}, {IsAvailable}";
        }
    }
}
