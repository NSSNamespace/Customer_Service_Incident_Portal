using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerService;
using System.Text.RegularExpressions;

namespace CustomerService
{
    public class EmployeeFactory
    {
        public Employee getSingleEmployee(string fullName)
        {
            Employee emp = new Employee();

            string[] FullNameArr = Regex.Split(fullName, @"\s+").Where(s => s != string.Empty).ToArray();
            string FirstName = FullNameArr[0];
            string LastName = FullNameArr[1];



                return emp; 

        }



    }
}
