using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerService;
using System.Text.RegularExpressions;
using Microsoft.Data.Sqlite;

namespace CustomerService
{
    public class EmployeeFactory
    {
        // Make the factory a singleton to maintain state across all employees
        private static EmployeeFactory _instance;

        public static EmployeeFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EmployeeFactory();
                }
                return _instance;
            }
        }

        // To track the currently active customer - selected by user
        private Employee _activeEmployee = null;
        public Employee ActiveEmployee
        {
            get
            {
                return _activeEmployee;
            }
            set
            {
                _activeEmployee = value;
            }
        }


        // Get a single employee
        public Employee get(string fullName)
        {
            string[] FullNameArr = Regex.Split(fullName, @"\s+").Where(s => s != string.Empty).ToArray();
            string FirstName = FullNameArr[0];
            string LastName = FullNameArr[1];

            BangazonConnection conn = new BangazonConnection();
            Employee e = null;

            conn.execute(@"select 
				EmployeeId,
				FirstName, 
				LastName, 
				DepartmentName,
                FROM Employee,
                WHERE FirstName = '" + FirstName + "' AND " + "LastName = '" + LastName + "'",
                (SqliteDataReader reader) => {
                while (reader.Read())
                {
                    e = new Employee
                    {
                        EmployeeId = reader.GetInt32(0),
                        FirstName = reader[1].ToString(),
                        LastName = reader[2].ToString(),
                        DepartmentName = reader[3].ToString()
                    };
                }
            });

            return e;
        }
    }
}
