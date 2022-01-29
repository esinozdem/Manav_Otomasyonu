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
    using Entities;
    using Repository;
    public partial class ProductList : Form
    {
        ProductsRepo productRepo;
        public ProductList()
        {
            InitializeComponent();
            productRepo = new ProductsRepo();
        }

        private void ProductList_Load(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void FillGrid()
        {
            grdProduct.DataSource = productRepo.GetVMProducts();
        }

        private void grdProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            var product = (grdProduct.DataSource as List<VM.VMProduct>)[e.RowIndex];
            ProductForm form = new ProductForm();
            form.Tag = product.ProductId;
             form.ShowDialog();
            FillGrid();
        }

        private void grdProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
