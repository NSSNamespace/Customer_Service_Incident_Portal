using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using CustomerService;

namespace CustomerServiceTests
{
    public class DepartmentTests
    {
        [Fact]
        public void TestThatTestsAreTesting()
        {
            bool disco = true;
            Assert.Equal(true, disco);
        }

        [Fact]
        public void CanMakeADepartment()
        {
            Department newDepartment = new Department();
            newDepartment.Label = "Housewares";
            newDepartment.DepartmentId = 444444444;
            Assert.NotNull(newDepartment);
            Assert.Equal(newDepartment.Label, "Housewares");
            Assert.Equal(newDepartment.DepartmentId, 444444444);

         }

        [Fact]
        public void CanGetListOfDepartments()
        {
            DepartmentFactory newDF = new DepartmentFactory();
            var departmentlist = newDF.getAll();
            Assert.NotNull(departmentlist);

            foreach (var department in departmentlist)
            {
                Assert.NotNull(department);
                Assert.True(department.GetType() == typeof(Department));
                Assert.True(department.DepartmentId.GetType() == typeof(int));
                Assert.NotNull(department.Label);
                Assert.NotNull(department.DepartmentId);
            }

        }
    }
}