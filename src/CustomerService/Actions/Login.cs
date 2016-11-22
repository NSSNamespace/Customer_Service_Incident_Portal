using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerService
{

    //Class: Login
    //Author: Liz Sanger

    public class Login
    {
        //Method: user login

        public static void UserLogin()
        {
            
            //Create new instances of employee and department factories immediately on method invocation
            EmployeeFactory employeeFactory = EmployeeFactory.Instance;
            DepartmentFactory departmentFactory = DepartmentFactory.Instance;

            string Banner = "====================================";
            string Greeting = "BANGAZON INC CUSTOMER SERVICE PORTAL";
            string NamePlease = "Enter your first and last name to start. Type 'new user' to create a new user account.";
         
            //Greet the user and prompt to enter name or create account and capture user input

            Console.WriteLine(Banner + "\r\n" + Greeting + "\r\n" + Banner + "\r\n" + NamePlease + "\r\n>");

            var EmployeeName = Console.ReadLine();
            
            //if the user tries to access an existing account, call get method on instance of employee factory to query database. Get method accepts an argument of type string
            if (EmployeeName != "new user")
            {
                try
                {
                    Employee CurrentEmployee = employeeFactory.get(EmployeeName);
                    //if a match is found, make that employee the active employee on employee factory instance and greet the employee by name
                    employeeFactory.ActiveEmployee = CurrentEmployee;
                    Console.WriteLine("Welcome " + CurrentEmployee.FirstName + " " + CurrentEmployee.LastName + "!");
                    Console.ReadLine();
                }

                //if name entered is invalid, notify user and restart user login method
                catch
                {
                    Console.WriteLine("The employee name you have entered appears to be invalid. Please try again.");
                    UserLogin();
                }

                }
            //if employee opts to create a new account, create a new employee and prompt the user for first name and last name. Then query the database with GetAll method in department factory to present user with a list of department names and id's. Establish new employee account with user input.

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
