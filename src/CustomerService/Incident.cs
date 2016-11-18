using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerService;

namespace CustomerService
{
    public class Incident
    {
        public void getByEmployee(int employeeId)
        {
            throw new NotImplementedException();
        }

        public int IncidentId { get; set; }

        public int IncidentTypeId { get; set; }

        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public string Resolution { get; set; }

        public int EmployeeId { get; set; }

        public void save ()
        {
        }
    }
}
