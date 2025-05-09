using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_4.models
{
    internal class Booking
    {
        public string CustomerName { get; set; }
        public int VehicleID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double TotalAmount { get; set; }

        public override string ToString()
        {
            return $"Name:{CustomerName} , VehicleID:{VehicleID}, StartDate:{StartDate:yyyy-MM-dd},EndDate: {EndDate:yyyy-MM-dd}, TotalAmount:{TotalAmount}";
        }
    }
}