using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Reflection;

namespace project_4.models
{
    internal static class RentalManager
    {
        public static List<Vehicle> Vehicles { get; set; } = new List<Vehicle>
        {
            new Car(1, "Toyota", "Corolla", CarType.Sedan, 200, 5, 250),
            new Car(2, "BMW", "X5", CarType.SUV, 350, 7, 300),
            new Car(3, "Nissan", "Altima", CarType.Sedan, 250, 4, 200),
            new Motorcycle(101, "Honda", "CBR", BikeType.Sport, 150, true),
            new Motorcycle(102, "Yamaha", "MT-07", BikeType.Sport, 100, false),
            new Motorcycle(103, "Kawasaki", "Ninja", BikeType.Sport, 180, false)
        };

        public static List<Customer> Customers { get; set; } = new List<Customer>
        {
            new Customer { Id = 1, Name = "محمد أحمد", Phone = 123456789, LicenseNumber = 987654, IsLicenseEgyptianOrNot = LicenseType.Egyptian },
            new Customer { Id = 2, Name = "فاطمة علي", Phone = 987654321, LicenseNumber = 123456, IsLicenseEgyptianOrNot = LicenseType.Foreign }
        };

        public static List<Booking> Bookings { get; set; } = new List<Booking>();

        static RentalManager()
        {
            LoadData();
        }

        public static List<Vehicle> GetAvailableVehicles()
        {
            return Vehicles.Where(v => v.IsAvailable).ToList();
        }

        public static List<Car> GetAvailableCars()
        {
            return Vehicles.OfType<Car>().Where(c => c.IsAvailable).ToList();
        }

        public static List<Motorcycle> GetAvailableMotorcycles()
        {
            return Vehicles.OfType<Motorcycle>().Where(m => m.IsAvailable).ToList();
        }

        public static void BookVehicle(int vehicleID, int customerId, DateTime startDate, DateTime endDate)
        {
            var vehicle = Vehicles.FirstOrDefault(v => v.VehicleID == vehicleID && v.IsAvailable)
                ?? throw new Exception("المركبة مش متاحة أو مش موجودة.");

            var customer = Customers.FirstOrDefault(c => c.Id == customerId)
                ?? throw new Exception("العميل مش موجود.");

            if (startDate < DateTime.Now)
                throw new Exception("تاريخ البداية لازم يكون في المستقبل.");

            if (endDate <= startDate)
                throw new Exception("تاريخ النهاية لازم يكون بعد تاريخ البداية.");

            int days = (endDate - startDate).Days + 1;
            double amount = days * vehicle.Price;

            vehicle.IsAvailable = false;
            Bookings.Add(new Booking
            {
                CustomerName = customer.Name,
                VehicleID = vehicleID,
                StartDate = startDate,
                EndDate = endDate,
                TotalAmount = amount
            });

            SaveData();
            SaveAppPath();
        }

        public static void ReturnVehicle(int vehicleID)
        {
            var vehicle = Vehicles.FirstOrDefault(v => v.VehicleID == vehicleID)
                ?? throw new Exception("المركبة مش موجودة.");

            if (vehicle.IsAvailable)
                throw new Exception("المركبة دي مش محجوزة .");

            var booking = Bookings.FirstOrDefault(b => b.VehicleID == vehicleID)
                ?? throw new Exception("مفيش حجز مسجل للمركبة .");

            vehicle.IsAvailable = true;
            Bookings.Remove(booking);

            SaveData();
        }

        public static List<Booking> GetBookings()
        {
            return Bookings.ToList();
        }

        private static void SaveData()
        {
            try
            {
                string appPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                var settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto,
                    Formatting = Formatting.Indented
                };

                File.WriteAllText(Path.Combine(appPath, "vehicles.json"), JsonConvert.SerializeObject(Vehicles, settings));
                File.WriteAllText(Path.Combine(appPath, "bookings.json"), JsonConvert.SerializeObject(Bookings, settings));
                File.WriteAllText(Path.Combine(appPath, "customers.json"), JsonConvert.SerializeObject(Customers, settings));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving data: {ex.Message}");
            }
        }

        private static void SaveAppPath()
        {
            try
            {
                string appPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                File.WriteAllText(Path.Combine(appPath, "appPath.json"), JsonConvert.SerializeObject(new { AppPath = appPath }));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving app path: {ex.Message}");
            }
        }

        private static void LoadData()
        {
            try
            {
                string appPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                var settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto
                };

                if (File.Exists(Path.Combine(appPath, "vehicles.json")))
                {
                    var vehiclesJson = File.ReadAllText(Path.Combine(appPath, "vehicles.json"));
                    var loadedVehicles = JsonConvert.DeserializeObject<List<Vehicle>>(vehiclesJson, settings);
                    if (loadedVehicles != null)
                    {
                        Vehicles.Clear();
                        Vehicles.AddRange(loadedVehicles);
                    }
                }

                if (File.Exists(Path.Combine(appPath, "bookings.json")))
                {
                    var bookingsJson = File.ReadAllText(Path.Combine(appPath, "bookings.json"));
                    var loadedBookings = JsonConvert.DeserializeObject<List<Booking>>(bookingsJson, settings);
                    if (loadedBookings != null)
                    {
                        Bookings.Clear();
                        Bookings.AddRange(loadedBookings);
                    }
                }

                if (File.Exists(Path.Combine(appPath, "customers.json")))
                {
                    var customersJson = File.ReadAllText(Path.Combine(appPath, "customers.json"));
                    var loadedCustomers = JsonConvert.DeserializeObject<List<Customer>>(customersJson, settings);
                    if (loadedCustomers != null)
                    {
                        Customers.Clear();
                        Customers.AddRange(loadedCustomers);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading data: {ex.Message}");
            }
        }
    }
}