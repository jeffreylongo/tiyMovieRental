using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using tiyMovieRental.Models;

namespace tiyMovieRental.Services
{
    public class RentalLogServices
    {
        const string ConnectionString = @"Server=localhost\SQLEXPRESS;Database=tiyMovieRental;Trusted_Connection=True;";

        //get all rental records method
        public List<RentalLog> GetAllMovies()
        {
            var rv = new List<RentalLog>();
            using (var connection = new SqlConnection(ConnectionString))
            {
                var query = "SELECT * FROM RentalLog";
                var cmd = new SqlCommand(query, connection);
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rv.Add(new RentalLog(reader));
                }
                return rv;
            }

        }
        //get single rental log
        public RentalLog GetRentalLog(int id)
        {
            var rentalLog = new RentalLog();
            using (var connection = new SqlConnection(ConnectionString))
            {
                var query = "SELECT * FROM RentalLog WHERE ID = @id";
                var cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id", id);
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rentalLog = new RentalLog(reader);
                }
                connection.Close();
            }
            return rentalLog;
        }
        //add new rental log method
        public void AddRentalLog(RentalLog newRentalLog)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var query = "INSERT INTO RentalLog ([CustomerId], [MovieId], [DateCheckedOut], " +
                    "[DueDate]) VALUES(@CustomerId, @MovieId, @DateCheckedOut, @DueDate)";
                var cmd = new SqlCommand(query, connection);
                connection.Open();
                cmd.Parameters.AddWithValue("@CustomerId", newRentalLog.CustomerId);
                cmd.Parameters.AddWithValue("@MovieId", newRentalLog.MovieId);
                cmd.Parameters.AddWithValue("@DateCheckedOut", newRentalLog.DateCheckedOut);
                cmd.Parameters.AddWithValue("@DueDate", newRentalLog.DueDate);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
        //edit rental log method
        public void EditRentalLog(RentalLog rentalLog, int id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var query = @"UPDATE RentalLog SET
                [CustomerId] = @CustomerId
                ,[MovieId] = @MovieId
                ,[DateCheckedOut] = @DateCheckedOut
                ,[DueDate] = @DueDate
                WHERE Id = @Id";
                var cmd = new SqlCommand(query, connection);
                connection.Open();
                cmd.Parameters.AddWithValue("@CustomerId", rentalLog.CustomerId);
                cmd.Parameters.AddWithValue("@MovieId", rentalLog.MovieId);
                cmd.Parameters.AddWithValue("@DateCheckedOut", rentalLog.DateCheckedOut);
                cmd.Parameters.AddWithValue("@DueDate", rentalLog.DueDate);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
        //delete rental log method
        public void DeleteRentalLog(int id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var cmd = new SqlCommand("DELETE FROM RentalLog WHERE ID=@Id", connection);
                cmd.Parameters.AddWithValue("@Id", id);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();

            }
        }
    }
}