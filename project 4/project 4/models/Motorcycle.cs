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
        public string Brand { get; set; }
        public BikeType Type { get; set; }

        public Motorcycle(int id, string brand, string model, BikeType type, int price)
            : base(id, model, price)
        {
            Brand = brand;
            Type = type;
        }

        public override string ToString()
        {
            return $"{VehicleID}, {Brand}, {Model}, {Type}, {Price}, {IsAvailable}";
        }
    }
}
