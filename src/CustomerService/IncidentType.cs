using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerService
{
    public class IncidentType
    {

        [Key]
        public int IncidentTypeId { get; set; }

        public string Label { get; set; }
    }
}
