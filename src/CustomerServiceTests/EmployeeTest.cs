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
            bool IsMonday = true;
            Assert.True(IsMonday);
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
        }
    }
}
