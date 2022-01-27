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
        ProductRepo productRepo;
        public ProductList()
        {
            InitializeComponent();
            productRepo = new ProductRepo();
        }

        private void ProductList_Load(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void FillGrid()
        {
            grdProduct.DataSource = productRepo.GetProducts();
        }

        private void grdProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            var customers = (grdProduct.DataSource as List<Entities.Products>)[e.RowIndex];
            ProductForm form = new ProductForm();
            form.ShowDialog();
            FillGrid();
        }
    }
}
