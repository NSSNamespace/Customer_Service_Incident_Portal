using CustomerService;
using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace CustomerService
{
    public class DepartmentFactory
    {
        public List<Department> Get()
        {
            BangazonConnection conn = new BangazonConnection();
            List<Department> Departments = new List<Department>();
            conn.execute("SELECT DepartmentId, Label FROM Departments",
            (SqliteDataReader reader) =>
            {
                while (reader.Read())
                {
                    Departments.Add(new Department
                    {
                        DepartmentId = reader.GetInt32(0),
                        Label = reader[1].ToString(),
                    });
                }
            });
            return Departments;
        }

    }
}