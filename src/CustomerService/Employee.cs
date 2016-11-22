using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CustomerService
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int DepartmentId { get; set; }

        public void save()
        {
            BangazonConnection conn = new BangazonConnection();

            Employee emp = new Employee();

            string query = string.Format(@"
			insert into Employee 
			  (FirstName, LastName, DepartmentId)
			values 
			  ('{0}', '{1}', '{2}');
			",
                this.FirstName,
                this.LastName,
                this.DepartmentId
            );

            conn.insert(query);
        }
    }
}
