using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using CustomerService;

namespace CustomerServiceTests
{
    public class EmployeeTest
    {

        Employee employee = new Employee
        {
            EmployeeId = 123,
            FirstName = "Bob",
            LastName = "Dole",
            DepartmentName = "Accounting"

        };

        [Fact]

        public void TrueTest()
        {
            bool isTrue = true;
            Assert.True(isTrue);
        }

        [Fact]

        public void CanCreateEmployee ()
        {
            Assert.NotNull(employee);
        }
        
        [Fact]

        public void EmployeeHasDepartment ()
        {
            Assert.NotNull(employee.DepartmentName);
            Assert.Equal(employee.DepartmentName, "Accounting");
        }

        [Fact]

        public void EmployeeHasFirstNameAndLastName()
        {
            Assert.Equal(employee.FirstName, "Bob");
            Assert.Equal(employee.LastName, "Dole");
        }

        [Fact]

        public void EmployeeHasId ()
        {
            Assert.NotNull(employee.EmployeeId);
            Assert.Equal(employee.EmployeeId, 123);
        }

        [Fact]
        public void CanGetEmployeeByName ()
        {
            EmployeeFactory EmFac = new EmployeeFactory();
            Employee oneEmployee = EmFac.get("john smith");

            Assert.NotNull(oneEmployee);
            Assert.Equal(oneEmployee.FirstName, "john");
            Assert.Equal(oneEmployee.LastName, "smith");
          
        }
        [Fact]
        public void CanSaveAnEmployee()
        {
            Employee emp = new Employee();
            emp.FirstName = "GJerome";
            emp.LastName = "GJeraldo";
            emp.DepartmentName = "GJeriatrics";
            emp.EmployeeId = 123;

            emp.save();
            EmployeeFactory empfac = new EmployeeFactory();
            var name = "GJerome GJeraldo";
            var shouldBeGJ = empfac.get(name);
        }
    }
}
