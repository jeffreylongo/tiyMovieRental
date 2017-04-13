using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using tiyMovieRental.Models;

namespace tiyMovieRental.Services
{
    public class MoviesServices
    {
        const string ConnectionString = @"Server=localhost\SQLEXPRESS;Database=tiyMovieRental;Trusted_Connection=True;";
        //get all gifts method
        public List<Movies> GetAllMovies()
        {
            var rv = new List<Movies>();
            using (var connection = new SqlConnection(ConnectionString))
            {
                var query = "SELECT * FROM Movies";
                var cmd = new SqlCommand(query, connection);
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rv.Add(new Movies(reader));
                }
                return rv;
            }
        }
    }
}