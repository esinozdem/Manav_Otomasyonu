using Manav_Otomasyonu.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manav_Otomasyonu.Repository
{
    using VM;
    public class ProductsRepo : RepositoryBase, IRepository<Products>
    {
        public int Create(Products item)
        {
            int id = 0;
            try
            {
                SqlCommand command = new SqlCommand("Sp_Product_Create", this.Connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
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
            catch (Exception ex )
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (this.Connection.State == System.Data.ConnectionState.Open) this.Connection.Close();
            }
            return id;
        }

        public void Delete(int id)
        {
            if (MessageBox.Show("Bu Kaydı Silmek İstiyor Musunuz ?","Manav Uygulaması",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)==DialogResult.OK)
                                
            {
                if (MessageBox.Show("Bu Kaydı Silmek İstediğinizden Emin misiniz ?", "Silme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        SqlCommand command = new SqlCommand("Sp_Product_Delete", this.Connection);
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("ProductId", id);
                        if (this.Connection.State == System.Data.ConnectionState.Closed) this.Connection.Open();
                        command.ExecuteReader();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        if (this.Connection.State == System.Data.ConnectionState.Open) this.Connection.Close();
                    }
                }
            }
        }

        public List<Products> Get()
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
                    Products product = ProductMapping(reader);
                    products.Add(product);
                }
            }
            catch (Exception )
            {


            }
            finally
            {
                if (this.Connection.State == System.Data.ConnectionState.Open) this.Connection.Close();
            }
            return products;
        }
        public List<VMProduct> GetVMProducts()
        {
            List<VMProduct> products = new List<VMProduct>();
            try
            {
                SqlCommand command = new SqlCommand("Sp_Product", this.Connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                if (this.Connection.State == System.Data.ConnectionState.Closed) this.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    VMProduct product = new VMProduct();
                    product.ProductId = Convert.ToInt32(reader["ProductId"]);
                    product.ProductName = reader["ProductName"].ToString();
                    product.CategoryName= reader["CategoryName"].ToString();
                    products.Add(product);
                }
            }
            catch (Exception)
            {


            }
            finally
            {
                if (this.Connection.State == System.Data.ConnectionState.Open) this.Connection.Close();
            }
            return products;
        }
        public Products GetById(int id)
        {
            Products product = null;
            try
            {
                SqlCommand command = new SqlCommand("Sp_Product", this.Connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("ProductId", id);
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

        public int Update(Products item)
        {
            int id = 0;
            try
            {
                SqlCommand command = new SqlCommand("Sp_Product_Create", this.Connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
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
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (this.Connection.State == System.Data.ConnectionState.Open) this.Connection.Close();
            }
            return id;
        }
        public Products ProductMapping(SqlDataReader reader)
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
    }
}
