using CustomerService;
using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace CustomerService
{
    public class DepartmentFactory
    {

        private static DepartmentFactory _instance;

        public static DepartmentFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DepartmentFactory();
                }
                return _instance;
            }
        }

        public List<Department> GetAll()
        {
            BangazonConnection conn = new BangazonConnection();
            List<Department> Departments = new List<Department>();
            conn.executeNewDb("SELECT DepartmentId, Label FROM Department",
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