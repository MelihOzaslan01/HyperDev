using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperDev.Core.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TopDepartment { get; set; }
        public string SubDepartment { get; set; }
        public int CompanyId { get; set; }

        //NAV PROP
        public virtual Company Company { get; set; }

    }
}














