using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerService
{
    public class Program
    {
        public static void Main(string[] args)
        {

            // call method to seed database
            DatabaseSeed.createTables();

        }
        
    }
}
