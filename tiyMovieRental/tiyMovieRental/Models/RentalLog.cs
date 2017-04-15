using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace tiyMovieRental.Models
{
    public class RentalLog
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int MovieId { get; set; }
        public DateTime DateCheckedOut { get; set; }
        public DateTime DueDate { get; set; }

        public RentalLog(SqlDataReader reader)
        {
            this.Id = (int)reader["Id"];
            this.CustomerId = (int)reader["CustomerId"];
            this.MovieId = (int)reader["YearReleased"];
            this.DateCheckedOut = (DateTime)reader["DateChekedOut"];
            this.DueDate = (DateTime)reader["DueDate"];

        }

        public RentalLog()
        {
        }
    }
}