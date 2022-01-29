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
        ProductsRepo productRepo;
        CustomersRepo customersRepo;
        CategoryRepo categoryRepo;
        Products selectedProduct = null;
        public ProductForm()
        {
            InitializeComponent();
            productRepo = new ProductsRepo();
            customersRepo = new CustomersRepo();
            categoryRepo = new CategoryRepo();
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            FillForm();
        }

        private void FillForm()
        {
            FillControls();
            FillDatas();
        }

    

        private void FillDatas()
        {
            int ProductId = (Convert.ToInt32(this.Tag));
            if (ProductId > 0)
            {
                var Product = productRepo.GetById(ProductId);
                if (Product != null)
                {
                    selectedProduct = Product;
                    txtProductName.Text = Product.ProductName;
                    txtQuantityPerUnit.Text = Product.QuantityPerUnit;
                    nuUnitPrice.Value = Convert.ToDecimal(Product.UnitPrice);
                    nuUnitsInStock.Value = Convert.ToDecimal(Product.UnitsInStock);
                    nuUnitsOnOrder.Value = Convert.ToDecimal(Product.UnitOnOrder);
                    cmbCategories.SelectedValue = Product.CategoryId;
                    cmbCustomers.SelectedValue = Product.CustomerId;

                }

            }
        }
        private void FillControls()
        {
            FillCustomers();
            FillCategory();
        }

        private void FillCategory()
        {
            var Category = categoryRepo.Get();
            cmbCategories.DataSource = Category;
            cmbCategories.ValueMember = "CategoryId";
            cmbCategories.DisplayMember = "CategoryName";
        }

        private void FillCustomers()
        {
            var Customers = customersRepo.Get();
            cmbCustomers.DataSource = Customers;
            cmbCustomers.ValueMember = "CustomerId";
            cmbCustomers.DisplayMember = "CustomerName";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(txtProductName.Text))
            {
                MessageBox.Show("Lütfen Ürün Adı Giriniz.", "Ürün Formu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            FormSave();
        }

        private void FormSave()
        {
            if (selectedProduct == null)
            {
                selectedProduct = new Products();
            }
            selectedProduct.ProductName = txtProductName.Text;
            selectedProduct.CustomerId = Convert.ToInt32(cmbCustomers.SelectedValue);
            selectedProduct.CategoryId = Convert.ToInt32(cmbCategories.SelectedValue);
            selectedProduct.QuantityPerUnit = txtQuantityPerUnit.Text;
            selectedProduct.UnitPrice = Convert.ToDecimal(nuUnitPrice.Value);
            selectedProduct.UnitsInStock = Convert.ToInt16(nuUnitsInStock.Value);
            selectedProduct.UnitOnOrder = Convert.ToInt16(nuUnitsOnOrder.Value);
            if (Convert.ToInt32(this.Tag)==0)
            {
                int ProductId = productRepo.Create(selectedProduct);
                selectedProduct.ProductId = ProductId;
                this.Tag = ProductId;
            }
            else
            {
                selectedProduct.ProductId = productRepo.Update(selectedProduct);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedProduct==null)
            {
                return;
            }
            else
            {
                int id = selectedProduct.ProductId;
                productRepo.Delete(id);
                this.Close();
                 
            }
        }
    }
}
