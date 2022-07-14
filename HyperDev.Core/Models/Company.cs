using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperDev.Core.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //Limited, Anonim
        public string Type { get; set; }
        public string TaxAdministration { get; set; }
        public string TaxNumber { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Address { get; set; }


        //NAV PROP
        public virtual List<Department> Departments { get; set; }
    }
}
