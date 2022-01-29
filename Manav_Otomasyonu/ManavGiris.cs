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
    public partial class ManavGiris : Form
    {
        public ManavGiris()
        {
            InitializeComponent();
        }
     
        private void btnGiris_Click(object sender, EventArgs e)
        {
            string username = txtKullaniciAdi.Text;
            string password = txtSifre.Text;

            if (rbYönetici.Checked==true)
            {
                if (username== "admin" || password =="123" )
                {
                    Form1 fm = new Form1();
                    fm.ShowDialog();
                    fm.Close();

                }
               
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifreniz yanlış.", "Manav Uygulaması", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (rbMusteri.Checked == true)
            {
                MessageBox.Show("Sayfa Bakım Aşamasındadır. Lütfen daha sonra tekrar deneyiniz..");
            }

        }

        private void ManavGiris_Load(object sender, EventArgs e)
        {
           
        }
    }
}
