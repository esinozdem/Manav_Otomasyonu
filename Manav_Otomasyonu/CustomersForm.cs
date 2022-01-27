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
    public partial class CustomersForm : Form
    {
        CustomersRepo customersRepo;
        public CustomersForm()
        {
            InitializeComponent();
            customersRepo = new CustomersRepo();
        }

        private void CustomersForm_Load(object sender, EventArgs e)
        {
            FillData();
        }
        Customers selecteditem = null;
        private void FillData()
        {
            int customerId = Convert.ToInt32(this.Tag);
            if (customerId>0)
            {
                var customer = customersRepo.GetById(customerId);
                if (customer != null)
                {
                    selecteditem = customer;
                    txtCustomerName.Text = customer.CustomerName;
                    txtBirthDay.Text = customer.BirthDate;
                    txtAddress.Text = customer.Address;
                    txtCity.Text = customer.City;
                    txtCounty.Text = customer.County;
                    txtPostalCode.Text = customer.PostalCode;
                    txtPhone.Text = customer.Phone;
                }

            }

        }

       
        private void btnSave_Click(object sender, EventArgs e)
        {
            FormSave();
        }

        private void FormSave()
        {
            if (this.selecteditem == null) //Yeni Müşteri Ekleme işlemi
            {
                this.selecteditem = new Customers();
            }
            this.selecteditem = new Customers();
            this.selecteditem.CustomerName = txtCustomerName.Text;
            this.selecteditem.BirthDate = txtBirthDay.Text;
            this.selecteditem.Address = txtAddress.Text;
            this.selecteditem.City = txtCity.Text;
            this.selecteditem.County = txtCounty.Text;
            this.selecteditem.PostalCode = txtPostalCode.Text;
            this.selecteditem.Phone = txtPhone.Text;
            if (Convert.ToInt32(this.Tag) == 0)
            {
                //Insert işlemi
                this.selecteditem.CustomerId = customersRepo.Createe(this.selecteditem);
                this.Tag = this.selecteditem.CustomerId;

            }
            else
            // 1 kere basıldığında ınsert, ikinci kez basıldığında Update işlemi uygulanır.
            {
                customersRepo.UppDate(this.selecteditem);
            }
               


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bu Kaydı Silmek İstiyor Musunuz ?","Uygulama",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)== DialogResult.OK)
            {
                if (Convert.ToInt32(this.Tag) !=0)
                {
                   
                    this.selecteditem.CustomerId =customersRepo.Deletee(this.selecteditem);
                }

            }
        }
    }
}
