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
            FillDataGrid();
        }

        private void grdCustomers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            Customers customer = (grdCustomers.DataSource as List<Customers>)[e.RowIndex];
            CustomersForm cform = new CustomersForm();
            cform.Tag = customer.CustomerId;
            cform.ShowDialog();
            FillDataGrid();
        }

        private void FillDataGrid()
        {
            grdCustomers.DataSource = customersRepo.Get();
        }
    }
}
