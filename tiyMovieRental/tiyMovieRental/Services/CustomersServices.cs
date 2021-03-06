﻿using System;
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
        //get customer
        public Customers GetCustomer(int id)
        {
            var customer = new Customers();
            using (var connection = new SqlConnection(ConnectionString))
            {
                var query = "SELECT * FROM Customers WHERE ID = @id";
                var cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id", id);
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    customer = new Customers(reader);
                }
                connection.Close();
            }
            return customer;
        }
        //add new customer method
        public void AddCustomer(Customers newCustomer)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var query = "INSERT INTO Customers ([Name], [PhoneNumber], [Email])" +
                    "VALUES(@Name, @PhoneNumber, @Email)";
                var cmd = new SqlCommand(query, connection);
                connection.Open();
                cmd.Parameters.AddWithValue("@Name", newCustomer.Name);
                cmd.Parameters.AddWithValue("@PhoneNumber", newCustomer.PhoneNumber);
                cmd.Parameters.AddWithValue("@Email", newCustomer.Email);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
        //edit customer method
        public void EditCustomer(Customers customer, int id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var query = @"UPDATE Customers SET
                [Name] = @Name
                ,[PhoneNumber] = @PhoneNumber
                ,[Email] = @Email
                WHERE Id = @Id";
                var cmd = new SqlCommand(query, connection);
                connection.Open();
                cmd.Parameters.AddWithValue("@Id", customer.Id);
                cmd.Parameters.AddWithValue("@Name", customer.Name);
                cmd.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);
                cmd.Parameters.AddWithValue("@Email", customer.Email);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
        //delete customer method
        public void DeleteCustomer(int id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var cmd = new SqlCommand("DELETE FROM Customers WHERE ID=@Id", connection);
                cmd.Parameters.AddWithValue("@Id", id);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();

            }
        }
    }
}