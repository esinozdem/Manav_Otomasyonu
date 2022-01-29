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
    using System;
    public partial class CategoryList : Form
    {
        CategoryRepo categoryRepo;
        public CategoryList()
        {
            InitializeComponent();
            categoryRepo = new CategoryRepo();
        }

        private void CategoryList_Load(object sender, EventArgs e)
        {
            FillGrid();
        }

       
        private void FillGrid()
        {
            gridCategory.DataSource = categoryRepo.Get();
        }

        private void gridCategory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            var category = (gridCategory.DataSource as List<Category>)[e.RowIndex];
            CategoryForm caform = new CategoryForm();
            caform.Tag = category.CategoryId;
            caform.ShowDialog();
            FillGrid();
        }
    }
}
