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
                    "[GenreId]) VALUES(@Name, @YearReleased, @Director, @GenreId)";
                var cmd = new SqlCommand(query, connection);
                connection.Open();
                cmd.Parameters.AddWithValue("@Name", newMovie.Name);
                cmd.Parameters.AddWithValue("@YearReleased", newMovie.YearReleased);
                cmd.Parameters.AddWithValue("@Director", newMovie.Director);
                cmd.Parameters.AddWithValue("@GenreId", newMovie.GenreId);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        //edit movie method
        public void EditMovie(Movies movie, int id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var query = @"UPDATE Movies SET
                [Name] = @Name
                ,[YearReleased] = @YearReleased
                ,[Director] = @Director
                ,[GenreId] = @GenreId
                WHERE Id = @Id";
                var cmd = new SqlCommand(query, connection);
                connection.Open();
                cmd.Parameters.AddWithValue("@Name", movie.Id);
                cmd.Parameters.AddWithValue("@YearReleased", movie.YearReleased);
                cmd.Parameters.AddWithValue("@Director", movie.Director);
                cmd.Parameters.AddWithValue("@GenreId", movie.GenreId);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        //delete movie method
        public void DeleteMovie(int id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var cmd = new SqlCommand("DELETE FROM Movies WHERE ID=@Id", connection);
                cmd.Parameters.AddWithValue("@Id", id);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();

            }
        }

        //check out movie method.
        public void CheckOutMovie(int id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var cmd = new SqlCommand(@"UPDATE Movies SET
                [IsCheckedOut] = @IsCheckedOut WHERE Id = @Id", connection);
                cmd.Parameters.AddWithValue("@IsCheckedOut", true);
                cmd.Parameters.AddWithValue("@Id", id);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }

        }
    }
}