using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manav_Otomasyonu
{
    using Repository;
    using Entities;
    using System.Data.SqlClient;

    public partial class CustomersForm : Form
    {
        CustomersRepo customersRepo;
        ProductsRepo productsRepo;
        CategoryRepo categoryRepo;
        Customers selectedCustomer = null;
        public CustomersForm()
        {
            InitializeComponent();
            customersRepo = new CustomersRepo();
            productsRepo = new ProductsRepo();
            categoryRepo = new CategoryRepo();
        }

        private void CustomersForm_Load(object sender, EventArgs e)
        {
            FillData();
            SehirEkle();
        }

        private void FillData()
        {
            int CustomerId = Convert.ToInt32(this.Tag);
            if (CustomerId > 0)
            {
                var Customer = customersRepo.GetById(CustomerId);
                if (Customer != null)
                {
                    selectedCustomer = Customer;
                    txtCustomerName.Text = Customer.CustomerName;
                    txtBirthDay.Text = Customer.BirthDate;
                    //cmbIller.SelectedIndex = Customer.City;
                    //cmbIlce.SelectedIndex = Customer.County;
                    txtPhone.Text = Customer.Phone;
                    txtPostalCode.Text = Customer.PostalCode;
                    txtAddress.Text = Customer.Address;
                }

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
            if (cmbIller.SelectedItem==null || cmbIlce.SelectedItem==null)
            {
                MessageBox.Show("Lütfen İl Seçiniz.");
            }
            if (string.IsNullOrEmpty(txtCustomerName.Text))
            {
                MessageBox.Show("Lütfen Müşteri Adını Giriniz.", "Müşteri Formu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            FormSave();

            this.Close();
        }

        private void FormSave()
        {
            if (selectedCustomer==null)
            {
                selectedCustomer = new Customers();
            }
            selectedCustomer.CustomerName = txtCustomerName.Text;
            selectedCustomer.BirthDate = txtBirthDay.Text;
            selectedCustomer.City = cmbIller.SelectedItem.ToString();
            selectedCustomer.County = cmbIlce.SelectedItem.ToString();
            selectedCustomer.Address = txtAddress.Text;
            selectedCustomer.Phone = txtPhone.Text;
            selectedCustomer.PostalCode = txtPostalCode.Text;
            if (Convert.ToInt32(this.Tag)==0)
            {
                selectedCustomer.CustomerId = customersRepo.Create(selectedCustomer);
                this.Tag = selectedCustomer.CustomerId;
            }
            else
            {
                selectedCustomer.CustomerId = customersRepo.Update(selectedCustomer);
            }

        }
        private const string connectionString = @"Server=DESKTOP-U32R22S\S2019; Database=Manav; uid=sa; pwd=1;";
        void SehirEkle()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(" Select * From Iller", connection );
            if (connection.State == ConnectionState.Closed) connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                cmbIller.Items.Add(reader[1]);
            }
            if (connection.State == ConnectionState.Open) connection.Close();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedCustomer==null)
            {
                return;
            }
            else
            {
                int id = selectedCustomer.CustomerId;
                customersRepo.Delete(id);
                this.Close();
            }
        }

        private void cmbIller_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbIlce.Items.Clear();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(" Select * From dbo.ilceler where sehirid=@p1", connection);
            if (connection.State == ConnectionState.Closed) connection.Open();
            command.Parameters.AddWithValue("@p1", cmbIller.SelectedIndex + 1);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                cmbIlce.Items.Add(reader[1]);

            }
            if (connection.State == ConnectionState.Open) connection.Close();
        }
    }
}
