﻿using System;
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

        public string DepartmentName { get; set; }

        public void save()
        {
            BangazonConnection conn = new BangazonConnection();

            Employee emp = new Employee();

            string query = string.Format(@"
			insert into Employee 
			  (FirstName, LastName, EmployeeId, DepartmentName)
			values 
			  ('{0}', '{1}', '{2}', '{3}');
			",
                this.FirstName,
                this.LastName,
                this.EmployeeId,
                this.DepartmentName
            );

            conn.insert(query);
        }
    }
}
