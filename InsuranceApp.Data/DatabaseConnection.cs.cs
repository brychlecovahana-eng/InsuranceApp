using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsuranceApp.Data
{
    internal class DatabaseConnection
    {
        private readonly string _connectionString =
            "Data Source=YUMPC;" +
            "Initial Catalog=Database;" +
            "Integrated Security=True;" +
            "Encrypt=True;" +
            "Trust Server Certificate=True";
         
        public SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
