using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using tiyMovieRental.Models;

namespace tiyMovieRental.Services
{
    public class CustomersServices
    {
        const string ConnectionString = @"Server=localhost\SQLEXPRESS;Database=tiyMovieRental;Trusted_Connection=True;";

        //get all Customers method
        public List<Customers> GetAllCustomers()
        {
            var rv = new List<Customers>();
            using (var connection = new SqlConnection(ConnectionString))
            {
                var query = "SELECT * FROM Customers";
                var cmd = new SqlCommand(query, connection);
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rv.Add(new Customers(reader));
                }
                return rv;
            }
        }
    }
}