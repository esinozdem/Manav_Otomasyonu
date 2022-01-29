using Manav_Otomasyonu.Repository;
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
    public partial class CategoryForm : Form
    {
        CategoryRepo categoryRepo;
        Category selectedCategory = null;
        
        public CategoryForm()
        {
            InitializeComponent();
            categoryRepo = new CategoryRepo();
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            FillData();
        }

        private void FillData()
        {
            int CategoryId = Convert.ToInt32(this.Tag);
            if (CategoryId>0)
            {
                var category = categoryRepo.GetById(CategoryId);
                if (CategoryId !=0)
                {
                    selectedCategory = category;
                    txtCategoryName.Text = category.CategoryName;
                    txtCatDes.Text = category.Description;
                    
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FormSave();
            if (string.IsNullOrEmpty(txtCategoryName.Text))
            {
                MessageBox.Show("Lütfen Kategori Adı Giriniz.","Kategori Formu",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
           
            

        }

        private void FormSave()
        {
            if (selectedCategory ==null)
            {
                selectedCategory = new Category();
            }
            selectedCategory.CategoryName = txtCategoryName.Text;
            selectedCategory.Description = txtCatDes.Text;
            if (Convert.ToInt32(this.Tag)==0)
            {
                selectedCategory.CategoryId = categoryRepo.Create(selectedCategory);
                this.Tag = selectedCategory.CategoryId;
            }
            else
            {
                selectedCategory.CategoryId = categoryRepo.Update(selectedCategory);
            }
               
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedCategory==null)
            {
                return;
            }
            else
            {
                int id = selectedCategory.CategoryId;
                categoryRepo.Delete(id);
                this.Close();
            }
        }
    }
}
