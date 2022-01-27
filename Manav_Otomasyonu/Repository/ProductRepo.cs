using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;

namespace Manav_Otomasyonu.Repository
{
    using Entities;
    

    public class ProductRepo :RepositoryBase
    {
        
        public ProductRepo()
        {
        
        }
        //ürünlerimi Liste Şeklinde Çekeceğim Metot.
        public List<Products> GetProducts()
        {
            List<Products> products = new List<Products>();
            try
            {
                SqlCommand command = new SqlCommand("Sp_Product", this.Connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                if (this.Connection.State == System.Data.ConnectionState.Closed) this.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var product = ProductMapping(reader);
                    products.Add(product);
                }
            }
            catch (Exception ex)
            {


            }
            finally
            {
                if (this.Connection.State == System.Data.ConnectionState.Open) this.Connection.Close();
            }
            return products;
        }
        public Products Get(int ProductId)
        {
            Products product = null;
            try
            {
                SqlCommand command = new SqlCommand("Sp_Product", this.Connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("ProductId", ProductId);
                if (this.Connection.State == System.Data.ConnectionState.Closed) this.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    product = ProductMapping(reader);
                }
            }
            catch (Exception)
            {


            }
            finally
            {
                if (this.Connection.State == System.Data.ConnectionState.Open) this.Connection.Close();
            }
            return product;
        }
        private Products ProductMapping(SqlDataReader reader)
        {
            Products product = new Products();
            product.ProductId = Convert.ToInt32(reader["ProductId"]);
            product.ProductName = reader["ProductName"].ToString();
            product.CustomerId = Convert.ToInt32(reader["CustomerId"]);
            product.CategoryId = Convert.ToInt32(reader["CategoryId"]);
            product.QuantityPerUnit = reader["QuantityPerUnit"].ToString();
            product.UnitPrice = Convert.ToDecimal(reader["UnitPrice"]);
            product.UnitsInStock = Convert.ToInt16(reader["UnitsInStock"]);
            product.UnitOnOrder = Convert.ToInt16(reader["UnitOnOrder"]);
            return product;

        }
      
        public int Create(Products item)
        {
            int id = 0;
            try
            {
                SqlCommand command = new SqlCommand("Sp_Product_Create", this.Connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ProductId", item.ProductId);
                command.Parameters.AddWithValue("@ProductName", item.ProductName);
                command.Parameters.AddWithValue("@CustomerId", item.CustomerId);
                command.Parameters.AddWithValue("@CategoryId", item.CategoryId);
                command.Parameters.AddWithValue("@QuantityPerUnit", item.QuantityPerUnit);
                command.Parameters.AddWithValue("@UnitPrice", item.UnitPrice);
                command.Parameters.AddWithValue("@UnitsInStock", item.UnitsInStock);
                command.Parameters.AddWithValue("@UnitOnOrder", item.UnitOnOrder);
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
        public int Update(Products item)
        {
            int id = 0;
            try
            {
                SqlCommand command = new SqlCommand("Sp_Product_Create", this.Connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ProductId", item.ProductId);
                command.Parameters.AddWithValue("@ProductName", item.ProductName);
                command.Parameters.AddWithValue("@CustomerId", item.CustomerId);
                command.Parameters.AddWithValue("@CategoryId", item.CategoryId);
                command.Parameters.AddWithValue("@QuantityPerUnit", item.QuantityPerUnit);
                command.Parameters.AddWithValue("@UnitPrice", item.UnitPrice);
                command.Parameters.AddWithValue("@UnitsInStock", item.UnitsInStock);
                command.Parameters.AddWithValue("@UnitOnOrder", item.UnitOnOrder);
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
