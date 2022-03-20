using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDAjax.Models
{
    public class Manager
    {
         public long ID { get; set; }

        public string ManagerName { get; set; }


        public long PhoneNumber { get; set; }

        public string Address { get; set; }
    }
}
