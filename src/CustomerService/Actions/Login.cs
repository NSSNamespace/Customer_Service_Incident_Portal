using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerService
{
    public class Login
    {
        public static void UserLogin()
        {

            EmployeeFactory employeeFactory = EmployeeFactory.Instance;
            DepartmentFactory departmentFactory = DepartmentFactory.Instance;

            string Banner = "====================================";
            string Greeting = "BANGAZON INC CUSTOMER SERVICE PORTAL";
            string NamePlease = "Enter your first and last name to start. Type 'new user' to create a new user account.";
         
            Console.WriteLine(Banner + "\r\n" + Greeting + "\r\n" + Banner + "\r\n" + NamePlease + "\r\n>");
            var EmployeeName = Console.ReadLine();

            if (EmployeeName != "new user")
            {
                try
                {
                    Employee CurrentEmployee = employeeFactory.get(EmployeeName);
                    employeeFactory.ActiveEmployee = CurrentEmployee;
                    Console.WriteLine("Welcome " + CurrentEmployee.FirstName + " " + CurrentEmployee.LastName + "!");
                    Console.ReadLine();
                }

                catch
                {
                    Console.WriteLine("The employee name you have entered appears to be invalid. Please try again.");
                    UserLogin();
                }

                }

            else if (EmployeeName == "new user")

            {

                Employee newEmployee = new Employee();
                Console.WriteLine("First Name\r\n>");
                newEmployee.FirstName = Console.ReadLine();
                Console.WriteLine("Last Name\r\n>");
                newEmployee.LastName = Console.ReadLine();
                List<Department> depList = departmentFactory.GetAll();
                Console.WriteLine("Please select your department Id\r\n>");
                foreach(Department department in depList)
                {
                    Console.WriteLine("Deparment Name: " + department.Label + "Id: " + department.DepartmentId);
                }
                var employeeDepartmentId = Convert.ToInt32(Console.ReadLine());
                newEmployee.DepartmentId = employeeDepartmentId;
                newEmployee.save();
                Console.ReadLine();

            }

            else
            {
                Console.WriteLine("Invalid input. Please try again.");
                UserLogin();
            }
        }
    }
}
