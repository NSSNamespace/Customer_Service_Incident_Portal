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
        string Banner = "***********************************************";
        string Greeting = "Welcome to the Bangazon Customer Service Portal!";
        string NamePlease = "Please enter your name or type 'Create User' to create an account.";
        Console.WriteLine(Banner);
        Console.WriteLine(Greeting + "\r\n" + NamePlease);
            Console.WriteLine(Banner);
        var EmployeeName = Console.ReadLine();

            if (EmployeeName != "Create User")
            {
                Employee CurrentEmployee = employeeFactory.get(EmployeeName);
                employeeFactory.ActiveEmployee = CurrentEmployee;
                Console.WriteLine("Welcome " + CurrentEmployee.FirstName + " " + CurrentEmployee.LastName + "!");
                Console.ReadLine();
            }

            else if (EmployeeName == "Create User");
 
            {

                Employee newEmployee = new Employee();
                Console.WriteLine("Please enter your first name");
                newEmployee.FirstName = Console.ReadLine();
                Console.WriteLine("Please enter your last name");
                newEmployee.LastName = Console.ReadLine();
                Console.WriteLine("Please enter your employee id");
                newEmployee.EmployeeId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please enter your department name");
                newEmployee.DepartmentName = Console.ReadLine();
                newEmployee.save();

            }
        }
    }
}
