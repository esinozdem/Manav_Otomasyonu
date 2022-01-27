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
    public partial class Form1 : Form
    {
        ProductRepo productRepo;
        CustomersRepo customersRepo;
        public Form1()
        {
            InitializeComponent();
            productRepo = new ProductRepo();
            customersRepo = new CustomersRepo();
        }

        private void ürünlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
            
        }

       
       

        private void yeniÜrünToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductForm form = new ProductForm();
            form.ShowDialog();
        }

      

        private void yeniMüşteriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomersForm forms = new CustomersForm();
            forms.ShowDialog();
           
        }
      
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void müşteriListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerList clist = new CustomerList();
            clist.ShowDialog();
        }

        private void ürünListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductList plist = new ProductList();
            plist.ShowDialog();
        }
    }
}
