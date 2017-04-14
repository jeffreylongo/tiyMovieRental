using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace tiyMovieRental.Models
{
    public class Customers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }

        public Customers(SqlDataReader reader)
        {
            this.Id = (int)reader["Id"];
            this.Name = reader["Name"].ToString();
            this.PhoneNumber = (int)reader["PhoneNumber"];
            this.Email = reader["Email"].ToString();

        }

        public Customers()
        {
        }
    }
}