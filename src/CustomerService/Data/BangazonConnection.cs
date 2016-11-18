using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace CustomerService
{
    public class BangazonConnection
    {
        public static string _path = "Data Source=" + Environment.GetEnvironmentVariable("Bangazon_Db_Path2");

        public static void doesDbExist()
        {
            SqliteConnection dbcon = new SqliteConnection(_path);

            dbcon.Open();
            SqliteCommand dbcmd = dbcon.CreateCommand();

            dbcmd.CommandText = @"SELECT * FROM employee";

            var dbData = dbcmd.ExecuteReader();

            if (dbData == null)
            {
                createTables();
            }
            else
            {
                // clean up
                dbcmd.Dispose();
                dbcon.Close();
            }
        }


        public static void createTables()
        {


            SqliteConnection dbcon = new SqliteConnection(_path);

            dbcon.Open();
            SqliteCommand dbcmd = dbcon.CreateCommand();

            dbcmd.CommandText = @"
                CREATE TABLE Employee
                (
                    EmployeeId integer NOT NULL PRIMARY KEY AUTOINCREMENT,
                    FirstName string,
                    LastName string,
                    DepartmentName string,
                    IsAdmin integer
                );

                CREATE TABLE Incident
                (
                    IncidentId integer NOT NULL PRIMARY KEY AUTOINCREMENT,
                    OrderId integer,
                    CustomerId integer,
                    EmployeeId integer,
                    Resolution string,
                    IncidentTypeId integer,
                    FOREIGN KEY(IncidentTypeId) REFERENCES IncidentType(IncidentTypeId),
                    FOREIGN KEY(EmployeeId) REFERENCES Employee(EmployeeId)
                );

                CREATE TABLE IncidentType
                (
                    IncidentTypeId integer NOT NULL PRIMARY KEY AUTOINCREMENT,
                    Label string
                );

                INSERT INTO Employee
                (
                FirstName, LastName, DepartmentName, IsAdmin
                )
                VALUES
                (
                'Bob', 'Bobson', 'IT', 0
                );

                INSERT INTO Employee
                (
                FirstName, LastName, DepartmentName, IsAdmin
                )
                VALUES
                (
                'Rob', 'Bobson', 'Customer Service', 1
                );

                INSERT INTO Employee
                (
                FirstName, LastName, DepartmentName, IsAdmin
                )
                VALUES
                (
                'Bob', 'Robson', 'Customer Success Department', 0
                );

                INSERT INTO Employee
                (
                FirstName, LastName, DepartmentName, IsAdmin
                )
                VALUES
                (
                'Rob', 'Robson', 'Customer Wow', 1
                );

                INSERT INTO IncidentType (Label) VALUES ('Defective Product');
                INSERT INTO IncidentType (Label) VALUES ('Product Not Delivered');
                INSERT INTO IncidentType (Label) VALUES ('Unhappy With Product');
                INSERT INTO IncidentType (Label) VALUES ('Request For Information');
                INSERT INTO IncidentType (Label) VALUES ('Fraudulent Charge');
                INSERT INTO IncidentType (Label) VALUES ('Shipping Info Update');

                INSERT INTO Incident
                (
                    OrderId, CustomerId, EmployeeId, Resolution, IncidentTypeId
                )
                VALUES
                (
                    1234, 5678, 1, 'Told customer to shop elsewhere', 3
                );

                INSERT INTO Incident
                (
                    OrderId, CustomerId, EmployeeId, Resolution, IncidentTypeId
                )
                VALUES
                (
                    1235, 5679, 2, 'Advised customer not to reproduce', 2
                );"

;





            dbcmd.ExecuteNonQuery();


            // clean up
            dbcmd.Dispose();
            dbcon.Close();
        }
    }
}