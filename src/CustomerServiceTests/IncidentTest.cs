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

        [Fact]

        public void CanGetIncidentByIncidentId()
        {
            Incident newInc = new Incident
            {
                IncidentId = 123,
                IncidentTypeId = 44,
                OrderId = 3,
                CustomerId = 22,
                EmployeeId = 45,
                Resolution = "Told to shop elsewhere"
            };

            try
            {
                newInc.save();
                IncidentFactory newIncidentFactory = new IncidentFactory();
                var incident = newIncidentFactory.get(123);

                Assert.Equal(incident.IncidentId, 123);
                Assert.Equal(incident.IncidentTypeId, 44);
                Assert.Equal(incident.OrderId, 3);
                Assert.Equal(incident.CustomerId, 22);
                Assert.Equal(incident.EmployeeId, 45);
                Assert.Equal(incident.Resolution, "Told to shop elsewhere");
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }


        }
    }
}
