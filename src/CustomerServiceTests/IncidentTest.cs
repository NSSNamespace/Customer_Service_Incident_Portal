using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using CustomerService;

namespace CustomerServiceTests
{
    public class IncidentTest
    {

        Incident incident = new Incident
        {
      
        };

        [Fact]

        public void TestThatTestsAreWorking()
        {
            bool dodo = false;
            Assert.Equal(dodo, false);
        }

        [Fact]

        public void CanCreateAnIncident()
        {
            Assert.NotNull(incident);
        }

        [Fact]
        public void CanGetIncidentsByEmployeeAssigned()
        {
            Incident newInc = new Incident();
            int employeeId = 3;
            newInc.getByEmployee(employeeId);
        }
    }
}
