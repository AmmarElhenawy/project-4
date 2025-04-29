using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_4.models
{
    public enum CarType { Sedan, SUV, Hatchback, Convertible }
    public enum FuelType { Petrol, Diesel, Electric, Hybrid }
    internal class Car : Vehicle
    {
        public string Brand { get; set; }
        public CarType Type { get; set; }
        public FuelType Fuel { get; set; }

        public Car(int id, string brand, string model, FuelType fuel, CarType type, int price)
            : base(id, model, price)
        {
            Brand = brand;
            Fuel = fuel;
            Type = type;
        }

        public override string ToString()
        {
            return $"{VehicleID}, {Brand}, {Model}, {Fuel}, {Type}, {Price}, {IsAvailable}";
        }
    }
}