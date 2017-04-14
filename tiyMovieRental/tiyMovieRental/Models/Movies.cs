using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace tiyMovieRental.Models
{
    public class Movies
    {
       

        public int Id { get; set; }
        public string Name { get; set; }
        public int YearReleased { get; set; }
        public string Director { get; set; }
        public int GenreId { get; set; }
        public bool IsCheckedOut { get; set; }

        public Movies(SqlDataReader reader)
        {
            this.Id = (int)reader["Id"];
            this.Name = reader["Name"].ToString();
            this.YearReleased = (int)reader["YearReleased"];
            this.Director = reader["Director"].ToString();
            this.GenreId = (int)reader["GenreId"];
            this.IsCheckedOut = (bool)reader["IsCheckedOut"];

        }

        public Movies()
        {
        }
    }
}