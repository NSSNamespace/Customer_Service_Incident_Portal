using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using CustomerServiceConsole;

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

        public void CanGetEmployeeById ()
        {
            
        }

    }
}
