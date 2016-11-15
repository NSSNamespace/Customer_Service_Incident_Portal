using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CustomerService
{
    public class Order
    {
        [Key]

        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public DateTime DateCreated { get; set; }

    }
}
