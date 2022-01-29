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
    public class CategoryRepo : RepositoryBase, IRepository<Category>
    {
        public int Create(Category item)
        {
            int id = 0;
            try
            {
                SqlCommand command = new SqlCommand("Sp_CreateUpdate", this.Connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CategoryName", item.CategoryName);
                command.Parameters.AddWithValue("@Description", item.Description);
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

        public void Delete(int id)
        {

            if (MessageBox.Show("Bu Kaydı Silmek İstiyor Musunuz ?", "Manav Uygulaması", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)

            {
                if (MessageBox.Show("Bu Kaydı Silmek İstediğinizden Emin misiniz ?", "Silme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        SqlCommand command = new SqlCommand("Sp_Categoriy_Delete", this.Connection);
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("CategoryId", id);
                        if (this.Connection.State == System.Data.ConnectionState.Closed) this.Connection.Open();
                        command.ExecuteNonQuery();
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

        public List<Category> Get()
        {
            List<Category> categories = new List<Category>();
            try
            {
                SqlCommand command = new SqlCommand("Sp_Categori", this.Connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                if (this.Connection.State == System.Data.ConnectionState.Closed) this.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Category category = new Category();
                    category.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                    category.CategoryName = reader["CategoryName"].ToString();
                    category.Description = reader["Description"].ToString();
                    categories.Add(category);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (this.Connection.State == System.Data.ConnectionState.Open) this.Connection.Close();
            }
            return categories;
        }

        public Category GetById(int id)
        {
            Category category = new Category();
            try
            {
                SqlCommand command = new SqlCommand("Sp_Categori", this.Connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("CategoryId", id);
                if (this.Connection.State == System.Data.ConnectionState.Closed) this.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    category = CategoryMapping(reader);
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (this.Connection.State == System.Data.ConnectionState.Open) this.Connection.Close();
            }
            return category;
        }

        private Category CategoryMapping(SqlDataReader reader)
        {
            Category category = new Category();
            category.CategoryId = Convert.ToInt32(reader["CategoryID"]);
            category.CategoryName = reader["CategoryName"].ToString();
            category.Description = reader["Description"].ToString();
            return category;
        }

        public int Update(Category item)
        {
            int id = 0;
            try
            {
                SqlCommand command = new SqlCommand("Sp_CreateUpdate", this.Connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CategoryId", item.CategoryId);
                command.Parameters.AddWithValue("@CategoryName", item.CategoryName);
                command.Parameters.AddWithValue("@Description", item.Description);
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
    }
}


