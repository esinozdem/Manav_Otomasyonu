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
    public partial class ProductForm : Form
    {
        ProductRepo productRepo;
        CustomersRepo customersRepo;
        public ProductForm()
        {
            InitializeComponent();
            productRepo = new ProductRepo();
            customersRepo = new CustomersRepo();
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            FillControls();
        }
        Products selecteditem = null;
        private void FillControls()
        {
            FillCustomers();
        }

        private void FillCustomers()
        {
            var customers = customersRepo.Get();
            cmbCustomers.DisplayMember = "CustomersName";
            cmbCustomers.ValueMember = "CustomersId";
            cmbCustomers.DataSource = customers;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FormSave();
        }

        private void FormSave()
        {
            if (this.selecteditem == null)
            {
                this.selecteditem = new Products();

            }
            this.selecteditem = new Products();
            this.selecteditem.ProductName = txtProductName.Text;
            //this.selecteditem.CustomerId = Convert.ToInt32(cmbCustomers.SelectedValue);
            this.selecteditem.QuantityPerUnit = txtQuantityPerUnit.Text;
            this.selecteditem.UnitPrice = nuUnitPrice.Value;
            this.selecteditem.UnitsInStock = Convert.ToInt16(nuUnitsInStock.Value);
            this.selecteditem.UnitOnOrder = Convert.ToInt16(nuUnitsOnOrder.Value);
            if (Convert.ToInt32(this.Tag) == 0)
            {
                this.selecteditem.ProductId = productRepo.Create(this.selecteditem);
                this.Tag = this.selecteditem.ProductId;
            }
            else
            {
                productRepo.Update(this.selecteditem);
            }
        }
    }
}
