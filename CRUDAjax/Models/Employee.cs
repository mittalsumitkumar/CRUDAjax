using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDAjax.Models
{
    public class Employee
    {
        //public int EmployeeID { get; set; }

        //public string Name { get; set; }

        //public int Age { get; set; }

        //public string State { get; set; }

        //public string Country { get; set; }
        public long ID { get; set; }

        public string EmployeeName { get; set; }

        public long PhoneNumber { get; set; }

        public string Address { get; set; }
        public string Gender { get; set; }

        public string Designation { get; set; }

        public long ManagerID { get; set; }

        public string ManagerName { get; set; }
    }
}
