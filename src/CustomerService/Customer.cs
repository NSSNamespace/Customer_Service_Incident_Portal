using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerService
{
    public class Customer
    {
        [Key]

        public int CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string StreetAddress { get; set; }

        public DateTime DateCreated { get; set; }
    
    }
}
