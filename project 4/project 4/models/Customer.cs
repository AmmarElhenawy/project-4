using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_4.models
{
// تعداد يمثل نوع رخصة القيادة
public enum LicenseType
{
    Egyptian,  // رخصة مصرية
    Foreign    // رخصة أجنبية
}

    internal class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Phone { get; set; }
        public int LicenseNumber { get; set; }
        public LicenseType IsLicenseEgyptianOrNot { get; set; }
        // خاصية جديدة لعرض الاسم مع الرقم في الـ ComboBox
        public string DisplayText => $"#{Id} - {Name}";

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Phone: {Phone}, License: {LicenseNumber}, IsLicenseEgyptianOrNot: {IsLicenseEgyptianOrNot}";
        }
    }
}
