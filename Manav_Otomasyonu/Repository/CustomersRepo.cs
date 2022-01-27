﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manav_Otomasyonu.Repository
{
    using Entities;
    using System.Data.SqlClient;
    public class CustomersRepo : RepositoryBase, IRepository <Customers>
    {

        public  void Create(Customers item)
        {
            int id = 0;
            try
            {
                SqlCommand command = new SqlCommand("Sp_Customer_Create", this.Connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("CustomerId", item.CustomerId);
                command.Parameters.AddWithValue("CustomerName", item.CustomerName);
                command.Parameters.AddWithValue("BirthDate", item.BirthDate);
                command.Parameters.AddWithValue("Address", item.Address);
                command.Parameters.AddWithValue("City", item.City);
                command.Parameters.AddWithValue("County", item.County);
                command.Parameters.AddWithValue("PostalCode", item.PostalCode);
                command.Parameters.AddWithValue("Phone", item.Phone);
                if (this.Connection.State == System.Data.ConnectionState.Closed) this.Connection.Open();
                id = Convert.ToInt32(command.ExecuteScalar());

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (this.Connection.State == System.Data.ConnectionState.Open) this.Connection.Close();
            }



        }
        public int Createe(Customers item)
        {
            int id = 0;
            try
            {
                SqlCommand command = new SqlCommand("Sp_Customer_Create", this.Connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("CustomerId", item.CustomerId);
                command.Parameters.AddWithValue("CustomerName", item.CustomerName);
                command.Parameters.AddWithValue("BirthDate", item.BirthDate);
                command.Parameters.AddWithValue("Address", item.Address);
                command.Parameters.AddWithValue("City", item.City);
                command.Parameters.AddWithValue("County", item.County);
                command.Parameters.AddWithValue("PostalCode", item.PostalCode);
                command.Parameters.AddWithValue("Phone", item.Phone);
                if (this.Connection.State == System.Data.ConnectionState.Closed) this.Connection.Open();
                id = Convert.ToInt32(command.ExecuteScalar());

            }
            catch (Exception ex)
            {

                
            }
            finally
            {
                if (this.Connection.State == System.Data.ConnectionState.Open) this.Connection.Close();
            }
            return id;
        }


        public void Delete(Customers item)
        {
        }
        public int Deletee(Customers item)
        {

            int id = 0;
            try
            {
                SqlCommand command = new SqlCommand("Sp_Customer_Delete", this.Connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("CustomerId", item.CustomerId);
                if (this.Connection.State == System.Data.ConnectionState.Closed) this.Connection.Open();
                id = Convert.ToInt32(command.ExecuteNonQuery());
            }
            catch (Exception)
            {

            }
            finally
            {
                if (this.Connection.State == System.Data.ConnectionState.Open) this.Connection.Close();
            }
            return id;
        }

        public List<Customers> Get()
        {
            List<Customers> customers = new List<Customers>();

            try
            {
                SqlCommand command = new SqlCommand("Sp_Customers", this.Connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                if (this.Connection.State == System.Data.ConnectionState.Closed) this.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var customer = CustomerMapping(reader);
                    customers.Add(customer);
                }
            }
            catch (Exception)
            {


            }
            finally
            {
                if (this.Connection.State == System.Data.ConnectionState.Open) this.Connection.Close();
            }
            return customers;
        }
        private Customers CustomerMapping(SqlDataReader reader)
        {
            Customers customer = new Customers();
            customer.CustomerId = Convert.ToInt32(reader["CustomerId"]);
            customer.CustomerName = reader["CustomerName"].ToString();
            customer.BirthDate = reader["BirthDate"].ToString();
            customer.Address = reader["Address"].ToString();
            customer.City = reader["City"].ToString();
            customer.County = reader["County"].ToString();
            customer.PostalCode = reader["PostalCode"].ToString();
            customer.Phone = reader["Phone"].ToString();
            return customer;
        }

        public Customers GetById(int id)
        {
            Customers customers = null;
            try
            {
                SqlCommand command = new SqlCommand("Sp_Customers", this.Connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CustomerId", this.Connection);
                if (this.Connection.State == System.Data.ConnectionState.Closed) this.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    customers = CustomerMapping(reader);
                }

            }
            catch (Exception ex)
            {


            }
            finally
            {
                if (this.Connection.State == System.Data.ConnectionState.Open) this.Connection.Close();
            }
            return customers;
        }

        public void Update(Customers item)
        {
            int id = 0;
            try
            {
                SqlCommand command = new SqlCommand("Sp_Update", this.Connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("CustomerId", item.CustomerId);
                command.Parameters.AddWithValue("CustomerName", item.CustomerName);
                command.Parameters.AddWithValue("BirthDate", item.BirthDate);
                command.Parameters.AddWithValue("Address", item.Address);
                command.Parameters.AddWithValue("City", item.City);
                command.Parameters.AddWithValue("County", item.County);
                command.Parameters.AddWithValue("PostalCode", item.PostalCode);
                command.Parameters.AddWithValue("Phone", item.Phone);
                if (this.Connection.State == System.Data.ConnectionState.Closed) this.Connection.Open();
                id = Convert.ToInt32(command.ExecuteScalar());

            }
            catch (Exception ex)
            {

               
            }
            finally
            {
                if (this.Connection.State == System.Data.ConnectionState.Open) this.Connection.Close();
            }

        }
        public int UppDate(Customers item)
        {
            int id = 0;
            try
            {
                SqlCommand command = new SqlCommand("Sp_Update", this.Connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("CustomerId", item.CustomerId);
                command.Parameters.AddWithValue("CustomerName", item.CustomerName);
                command.Parameters.AddWithValue("BirthDate", item.BirthDate);
                command.Parameters.AddWithValue("Address", item.Address);
                command.Parameters.AddWithValue("City", item.City);
                command.Parameters.AddWithValue("County", item.County);
                command.Parameters.AddWithValue("PostalCode", item.PostalCode);
                command.Parameters.AddWithValue("Phone", item.Phone);
                if (this.Connection.State == System.Data.ConnectionState.Closed) this.Connection.Open();
                id = Convert.ToInt32(command.ExecuteScalar());

            }
            catch (Exception ex)
            {


            }
            finally
            {
                if (this.Connection.State == System.Data.ConnectionState.Open) this.Connection.Close();
            }
            return id;
        }


    }
}

