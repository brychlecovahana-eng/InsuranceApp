using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;

namespace InsuranceApp.Data.Context
{
    public class Database
    {
        private readonly string _connectionString;

        public Database(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

    }
}

