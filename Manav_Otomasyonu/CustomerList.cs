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
    public partial class CustomerList : Form
    {
        CustomersRepo customersRepo;
        public CustomerList()
        {
            InitializeComponent();
            customersRepo = new CustomersRepo();
        }

        private void CustomerList_Load(object sender, EventArgs e)
        {
            FillGrid();
        }
             
        private void FillGrid()
        {
            dataGridView1.DataSource = customersRepo.Get();
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            var customers = (dataGridView1.DataSource as List<Entities.Customers>)[e.RowIndex];
            CustomersForm form = new CustomersForm();
            form.ShowDialog();
            FillGrid();
        }

        
    }
}
