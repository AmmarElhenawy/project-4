using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// استيراد مكتبة التعامل مع الملفات
using System.IO;
// استيراد مكتبة تحويل البيانات إلى JSON
using Newtonsoft.Json;
// استيراد مكتبة معلومات التجميع Assembly
using System.Reflection;

// تعريف مساحة الأسماء الخاصة بالمشروع
namespace project_4.models
{
    // تعريف كلاس ثابت لإدارة عمليات التأجير
    internal static class RentalManager
    {
        // قائمة بجميع المركبات (سيارات وموتوسيكلات)
        public static List<Vehicle> Vehicles { get; set; } = new List<Vehicle>
        {
            // إضافة بعض السيارات الافتراضية
            new Car(1, "Toyota", "Corolla", CarType.Sedan, 200, 5, 250),
            new Car(2, "BMW", "X5", CarType.SUV, 350, 7, 300),
            new Car(3, "Nissan", "Altima", CarType.Sedan, 250, 4, 200),
            // إضافة بعض الموتوسيكلات الافتراضية
            new Motorcycle(101, "Honda", "CBR", BikeType.Sport, 150, true),
            new Motorcycle(102, "Yamaha", "MT-07", BikeType.Sport, 100, true),
            new Motorcycle(103, "Kawasaki", "Ninja", BikeType.Sport, 180, true)
        };

        // قائمة بجميع العملاء
        public static List<Customer> Customers { get; set; } = new List<Customer>
        {
            // إضافة بعض العملاء الافتراضيين
            new Customer { Id = 1, Name = "محمد أحمد", Phone = 123456789, LicenseNumber = 987654, IsLicenseEgyptianOrNot = LicenseType.Egyptian },
            new Customer { Id = 2, Name = "فاطمة علي", Phone = 987654321, LicenseNumber = 123456, IsLicenseEgyptianOrNot = LicenseType.Foreign }
        };

        // قائمة الحجوزات الحالية
        public static List<Booking> Bookings { get; set; } = new List<Booking>();

        // مُنشئ ثابت للكلاس، يتم استدعاؤه عند تحميل البرنامج
        static RentalManager()
        {
            // تحميل البيانات من الملفات عند بدء البرنامج
            LoadData();
        }

        // دالة لإرجاع قائمة المركبات المتاحة فقط
        public static List<Vehicle> GetAvailableVehicles()
        {
            // الحصول على المركبات المتاحة فقط
            var vehicles = Vehicles.Where(v => v.IsAvailable).ToList();
            // إضافة نوع المركبة بجانب الموديل
            foreach (var v in vehicles)
            {
                if (v.GetType().Name == "Car")
                    v.GetType().GetProperty("Model")?.SetValue(v, v.Model );
                else if (v.GetType().Name == "Motorcycle")
                    v.GetType().GetProperty("Model")?.SetValue(v, v.Model  );
            }
            // إرجاع القائمة النهائية
            return vehicles;
        }

        // دالة لإرجاع السيارات المتاحة فقط
        public static List<Car> GetAvailableCars()
        {
            // البحث عن السيارات المتاحة فقط
            return Vehicles.OfType<Car>().Where(c => c.IsAvailable).ToList();
        }

        // دالة لإرجاع الموتوسيكلات المتاحة فقط
        public static List<Motorcycle> GetAvailableMotorcycles()
        {
            // البحث عن الموتوسيكلات المتاحة فقط
            return Vehicles.OfType<Motorcycle>().Where(m => m.IsAvailable).ToList();
        }

        // دالة لحجز مركبة
        public static void BookVehicle(int vehicleID, int customerId, DateTime startDate, DateTime endDate)
        {
            // البحث عن المركبة المتاحة المطلوبة
            var vehicle = Vehicles.FirstOrDefault(v => v.VehicleID == vehicleID && v.IsAvailable)
                ?? throw new Exception("المركبة مش متاحة أو مش موجودة.");

            // البحث عن العميل المطلوب
            var customer = Customers.FirstOrDefault(c => c.Id == customerId)
                ?? throw new Exception("العميل مش موجود.");

            // التأكد أن تاريخ البداية في المستقبل
            if (startDate < DateTime.Now)
                throw new Exception("تاريخ البداية لازم يكون في المستقبل.");

            // التأكد أن تاريخ النهاية بعد البداية
            if (endDate <= startDate)
                throw new Exception("تاريخ النهاية لازم يكون بعد تاريخ البداية.");

            // حساب عدد الأيام
            int days = (endDate - startDate).Days + 1;// +1 بيحسب يوميها معاها
            // حساب المبلغ الإجمالي
            double amount = days * vehicle.Price;

            //  جعل المركبة غير متاحة اتحجزت خلاص
            vehicle.IsAvailable = false;
            // إضافة الحجز إلى قائمة الحجوزات
            Bookings.Add(new Booking
            {
                CustomerName = customer.Name,
                VehicleID = vehicleID,
                StartDate = startDate,
                EndDate = endDate,
                TotalAmount = amount
            });

            // حفظ البيانات بعد الحجز
            SaveData();
            SaveAppPath();
        }

        // دالة لإرجاع مركبة (إلغاء الحجز)
        public static void ReturnVehicle(int vehicleID)
        {
            // البحث عن المركبة
            var vehicle = Vehicles.FirstOrDefault(v => v.VehicleID == vehicleID)
                ?? throw new Exception("المركبة مش موجودة.");

            // التأكد أن المركبة محجوزة
            if (vehicle.IsAvailable)
                throw new Exception("المركبة دي مش محجوزة .");

            // البحث عن الحجز المرتبط بالمركبة
            var booking = Bookings.FirstOrDefault(b => b.VehicleID == vehicleID)
                ?? throw new Exception("مفيش حجز مسجل للمركبة .");

            // جعل المركبة متاحة مرة أخرى
            vehicle.IsAvailable = true;
            // إزالة الحجز من القائمة
            Bookings.Remove(booking);

            // حفظ البيانات بعد الإرجاع
            SaveData();
        }

        // دالة لإرجاع قائمة الحجوزات
        public static List<Booking> GetBookings()
        {
            // إرجاع نسخة من قائمة الحجوزات
            return Bookings.ToList();
        }

        // دالة لحفظ البيانات في ملفات JSON
        private static void SaveData()
        {
            try
            {
                // تحديد مسار التطبيق
                string appPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                // إعدادات التحويل إلى JSON
                var settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto,
                    Formatting = Formatting.Indented
                };

                // حفظ المركبات في ملف
                File.WriteAllText(Path.Combine(appPath, "vehicles.json"), JsonConvert.SerializeObject(Vehicles, settings));
                // حفظ الحجوزات في ملف
                File.WriteAllText(Path.Combine(appPath, "bookings.json"), JsonConvert.SerializeObject(Bookings, settings));
                // حفظ العملاء في ملف
                File.WriteAllText(Path.Combine(appPath, "customers.json"), JsonConvert.SerializeObject(Customers, settings));
            }
            catch (Exception ex)
            {
                // طباعة الخطأ إذا حدث أثناء الحفظ
                Console.WriteLine($"Error saving data: {ex.Message}");
            }
        }

        // دالة لحفظ مسار التطبيق في ملف خاص
        private static void SaveAppPath()
        {
            try
            {
                // تحديد مسار التطبيق
                string appPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                // حفظ المسار في ملف appPath.json
                File.WriteAllText(Path.Combine(appPath, "appPath.json"), JsonConvert.SerializeObject(new { AppPath = appPath }));
            }
            catch (Exception ex)
            {
                // طباعة الخطأ إذا حدث أثناء الحفظ
                Console.WriteLine($"Error saving app path: {ex.Message}");
            }
        }

        // دالة لتحميل البيانات من ملفات JSON عند بدء التشغيل
        private static void LoadData()
        {
            try
            {
                // تحديد مسار التطبيق
                string appPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                // إعدادات التحويل من JSON
                var settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto
                };

                // تحميل المركبات إذا كان الملف موجود
                if (File.Exists(Path.Combine(appPath, "vehicles.json")))
                {
                    var vehiclesJson = File.ReadAllText(Path.Combine(appPath, "vehicles.json"));
                    var loadedVehicles = JsonConvert.DeserializeObject<List<Vehicle>>(vehiclesJson, settings);
                    if (loadedVehicles != null)
                    {
                        Vehicles.Clear();
                        Vehicles.AddRange(loadedVehicles);
                        Console.WriteLine($"Loaded {loadedVehicles.Count} vehicles from JSON.");
                    }
                    else
                    {
                        Console.WriteLine("Failed to deserialize vehicles from JSON.");
                    }
                }
                else
                {
                    Console.WriteLine("vehicles.json file not found, using default vehicle list.");
                }

                // تحميل الحجوزات إذا كان الملف موجود
                if (File.Exists(Path.Combine(appPath, "bookings.json")))
                {
                    var bookingsJson = File.ReadAllText(Path.Combine(appPath, "bookings.json"));
                    var loadedBookings = JsonConvert.DeserializeObject<List<Booking>>(bookingsJson, settings);
                    if (loadedBookings != null)
                    {
                        Bookings.Clear();
                        Bookings.AddRange(loadedBookings);
                        Console.WriteLine($"Loaded {loadedBookings.Count} bookings from JSON.");
                    }
                    else
                    {
                        Console.WriteLine("Failed to deserialize bookings from JSON.");
                    }
                }
                else
                {
                    Console.WriteLine("bookings.json file not found, using empty booking list.");
                }

                // تحميل العملاء إذا كان الملف موجود
                if (File.Exists(Path.Combine(appPath, "customers.json")))
                {
                    var customersJson = File.ReadAllText(Path.Combine(appPath, "customers.json"));
                    var loadedCustomers = JsonConvert.DeserializeObject<List<Customer>>(customersJson, settings);
                    if (loadedCustomers != null)
                    {
                        Customers.Clear();
                        Customers.AddRange(loadedCustomers);
                        Console.WriteLine($"Loaded {loadedCustomers.Count} customers from JSON.");
                    }
                    else
                    {
                        Console.WriteLine("Failed to deserialize customers from JSON.");
                    }
                }
                else
                {
                    Console.WriteLine("customers.json file not found, using default customer list.");
                }
            }
            catch (Exception ex)
            {
                // طباعة الخطأ إذا حدث أثناء التحميل
                Console.WriteLine($"Error loading data: {ex.Message}");
            }
        }
    }
}