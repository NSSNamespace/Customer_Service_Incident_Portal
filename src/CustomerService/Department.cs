using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CustomerService
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        public string Label { get; set; }
    }
}
