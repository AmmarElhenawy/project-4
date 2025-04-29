using System; // مكتبة الأساسيات (أنواع البيانات، الاستثناءات...)
using System.Collections.Generic; // مكتبة القوائم (List)
using System.Linq; // مكتبة الاستعلامات LINQ (زي Where, FirstOrDefault)
using System.Text; // مكتبة النصوص (قلما تستخدم هنا)
using System.Threading.Tasks; // مكتبة المهام المتزامنة (مش مستخدمة هنا)
using System.IO; // مكتبة التعامل مع الملفات
using Newtonsoft.Json; // مكتبة تحويل البيانات إلى/من JSON (نستخدمها للحفظ والتحميل)
// using System.Text.Json; // مكتبة JSON الأصلية (مش مستخدمة الآن)

namespace project_4.models // مساحة الأسماء للمشروع (تنظيم الكود)
{
    internal static class RentalManager // كلاس ثابت لإدارة كل عمليات التأجير
    {
        // قائمة المركبات في النظام
        public static List<Vehicle> Vehicles { get; set; } = new List<Vehicle> 
        {
            // إضافة سيارة افتراضية
            new Car(1, "Toyota", "Corolla", FuelType.Petrol, CarType.Sedan, 50), 
            new Car(2, "Hyundai", "Tucson", FuelType.Diesel, CarType.SUV, 70),
            new Car(3, "Tesla", "Model 3", FuelType.Electric, CarType.Sedan, 100),
            // إضافة دراجة افتراضية
            new Motorcycle(4, "Harley-Davidson", "Street 750", BikeType.Cruiser, 40), 
            new Motorcycle(5, "Yamaha", "YZF R3", BikeType.Sport, 45)
        };

        // قائمة العملاء في النظام
        public static List<Customer> Customers { get; set; } = new List<Customer> 
        {
            // عميل افتراضي
            new Customer { Id = 1, Name = "محمد أحمد", Phone = 123456789, LicenseNumber = 987654 }, 
            new Customer { Id = 2, Name = "فاطمة علي", Phone = 987654321, LicenseNumber = 123456 }
        };

        // قائمة الحجوزات
        public static List<Booking> Bookings { get; set; } = new List<Booking>();

        // دالة البناء الثابتة: تتنفذ مرة واحدة عند تشغيل البرنامج
        static RentalManager() 
        {
            // بنحمل البيانات من الملفات لو موجودة
            LoadData(); // تحميل البيانات من ملفات JSON (لو موجودة)
        }

        // دالة ترجع المركبات المتاحة فقط
        public static List<Vehicle> GetAvailableVehicles() 
        {
            // ترجع المركبات اللي متاحة للحجز فقط
            return Vehicles.Where(v => v.IsAvailable).ToList(); 
        }

        // دالة لحجز مركبة
        public static void BookVehicle(int vehicleID, int customerId, DateTime startDate, DateTime endDate) 
        {
            // نبحث عن المركبة المطلوبة والمتاحة
            var vehicle = Vehicles.FirstOrDefault(v => v.VehicleID == vehicleID && v.IsAvailable); 
            if (vehicle == null)
                // لو مش موجودة أو مش متاحة نرمي استثناء
                throw new Exception("المركبة مش متاحة أو مش موجودة."); 

            // نبحث عن العميل
            var customer = Customers.FirstOrDefault(c => c.Id == customerId); 
            if (customer == null)
                // لو العميل مش موجود نرمي استثناء
                throw new Exception("العميل مش موجود."); 

            // تحقق من صحة التاريخ
            if (startDate < DateTime.Now)
                throw new Exception("تاريخ البداية لازم يكون في المستقبل."); 

            if (endDate <= startDate)
                throw new Exception("تاريخ النهاية لازم يكون بعد تاريخ البداية.");

            // حساب عدد الأيام
            int days = (endDate - startDate).Days + 1; 
            // حساب التكلفة الكلية
            double amount = days * vehicle.Price; 

            // نجعل المركبة غير متاحة
            vehicle.IsAvailable = false; 
            // نضيف حجز جديد
            Bookings.Add(new Booking
            {
                // اسم العميل
                CustomerName = customer.Name, 
                // رقم المركبة
                VehicleID = vehicleID, 
                // تاريخ البداية
                StartDate = startDate, 
                // تاريخ النهاية
                EndDate = endDate, 
                // المبلغ الكلي
                TotalAmount = amount 
            });

            // نحفظ التغييرات في الملفات
            SaveData(); // حفظ البيانات بعد الحجز
        }

        // دالة لإرجاع مركبة
        public static void ReturnVehicle(int vehicleID) 
        {
            // ندور على المركبة
            var vehicle = Vehicles.FirstOrDefault(v => v.VehicleID == vehicleID);
            if (vehicle == null)
                throw new Exception("المركبة مش موجودة.");

            // نتأكد إن المركبة محجوزة
            if (vehicle.IsAvailable)
                throw new Exception("المركبة دي مش محجوزة .");

            // ندور على الحجز النشط للمركبة
            var booking = Bookings.FirstOrDefault(b => b.VehicleID == vehicleID);
            if (booking == null)
                throw new Exception("مفيش حجز مسجل للمركبة .");

            // نرجّع المركبة ونخليها متاحة
            vehicle.IsAvailable = true;

            // نزيل الحجز من قايمة الحجوزات (اختياري)
            Bookings.Remove(booking);

            SaveData(); // حفظ التغييرات
        }

        // دالة ترجع كل الحجوزات
        public static List<Booking> GetBookings() 
        {
            // ترجع نسخة من قائمة الحجوزات
            return Bookings.ToList(); 
        }

        // دالة لحفظ البيانات في ملفات JSON
        private static void SaveData() 
        {
            try
            {
                // حفظ المركبات
                File.WriteAllText("vehicles.json", JsonConvert.SerializeObject(Vehicles)); 
                // حفظ الحجوزات
                File.WriteAllText("bookings.json", JsonConvert.SerializeObject(Bookings)); 
                // حفظ العملاء
                File.WriteAllText("customers.json", JsonConvert.SerializeObject(Customers)); 
            }
            catch (Exception ex)
            {
                // لو حصل خطأ أثناء الحفظ
                Console.WriteLine($"خطأ أثناء حفظ البيانات: {ex.Message}"); 
            }
        }

        // دالة لتحميل البيانات من ملفات JSON
        private static void LoadData() 
        {
            try
            {
                // لو ملف المركبات موجود
                if (File.Exists("vehicles.json")) 
                {
                    // نقرأ محتوى الملف
                    var vehiclesJson = File.ReadAllText("vehicles.json"); 
                    // نحول النص إلى قائمة مركبات
                    var loadedVehicles = JsonConvert.DeserializeObject<List<Vehicle>>(vehiclesJson); 
                    if (loadedVehicles != null)
                    {
                        // نفرغ القائمة القديمة
                        Vehicles.Clear(); 
                        // نضيف الجديدة
                        Vehicles.AddRange(loadedVehicles); 
                    }
                }

                // لو ملف الحجوزات موجود
                if (File.Exists("bookings.json")) 
                {
                    var bookingsJson = File.ReadAllText("bookings.json");
                    var loadedBookings = JsonConvert.DeserializeObject<List<Booking>>(bookingsJson);
                    if (loadedBookings != null)
                    {
                        Bookings.Clear();
                        Bookings.AddRange(loadedBookings);
                    }
                }

                // لو ملف العملاء موجود
                if (File.Exists("customers.json")) 
                {
                    var customersJson = File.ReadAllText("customers.json");
                    var loadedCustomers = JsonConvert.DeserializeObject<List<Customer>>(customersJson);
                    if (loadedCustomers != null)
                    {
                        Customers.Clear();
                        Customers.AddRange(loadedCustomers);
                    }
                }
            }
            catch (Exception ex)
            {
                // لو حصل خطأ أثناء التحميل
                Console.WriteLine($"خطأ أثناء تحميل البيانات: {ex.Message}"); 
            }
        }
    }
}