﻿
using backend_lab_B81083.Models;
using System.Data;
using System.Data.SqlClient;

namespace backend_lab_B81083.Handlers
{
    using Dapper;
    using System.Data.SqlClient;
    namespace backend_lab_B81083.Repositories
    {
        public class CountryRepository
        {
            private readonly string _connectionString;
            public CountryRepository()
            {
                var builder = WebApplication.CreateBuilder();
                _connectionString = builder.Configuration.GetConnectionString("CountryContext");
            }
            public List<CountryModel> GetCountries()
            {
                using var connection = new
                SqlConnection(_connectionString);
                string query = "SELECT * FROM dbo.Country";
                return connection.Query<CountryModel>(query).ToList();
            }
        }
    }
}