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
        
        //get all movies method
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

        //get movie
        public Movies GetMovie(int id)
        {
            var movie = new Movies();
            using (var connection = new SqlConnection(ConnectionString))
            {
                var query = "SELECT * FROM Movies WHERE ID = @id";
                var cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id", id);
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    movie = new Movies(reader);
                }
                connection.Close();
            }
            return movie;
        }

        //add new movie method
        public void AddMovie(Movies newMovie)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var query = "INSERT INTO Movies ([Name], [YearReleased], [Director], " +
                    "[GenreId]) VALUES(@Name, @YearReleased, @Director)";
                var cmd = new SqlCommand(query, connection);
                connection.Open();
                cmd.Parameters.AddWithValue("@Contents", newMovie.Name);
                cmd.Parameters.AddWithValue("@GiftHint", newMovie.YearReleased);
                cmd.Parameters.AddWithValue("@ColorWrappingPaper", newMovie.Director);
                cmd.Parameters.AddWithValue("@Height", newMovie.GenreId);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}