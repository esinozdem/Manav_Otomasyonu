
namespace Manav_Otomasyonu
{
    partial class ManavGiris
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGiris = new System.Windows.Forms.Button();
            this.rbYönetici = new System.Windows.Forms.RadioButton();
            this.rbMusteri = new System.Windows.Forms.RadioButton();
            this.txtKullaniciAdi = new System.Windows.Forms.TextBox();
            this.txtSifre = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "Şifre:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Kullanıcı Adı:";
            // 
            // btnGiris
            // 
            this.btnGiris.Location = new System.Drawing.Point(149, 191);
            this.btnGiris.Name = "btnGiris";
            this.btnGiris.Size = new System.Drawing.Size(247, 44);
            this.btnGiris.TabIndex = 11;
            this.btnGiris.Text = "Giriş";
            this.btnGiris.UseVisualStyleBackColor = true;
            this.btnGiris.Click += new System.EventHandler(this.btnGiris_Click);
            // 
            // rbYönetici
            // 
            this.rbYönetici.AutoSize = true;
            this.rbYönetici.Location = new System.Drawing.Point(291, 153);
            this.rbYönetici.Name = "rbYönetici";
            this.rbYönetici.Size = new System.Drawing.Size(106, 21);
            this.rbYönetici.TabIndex = 10;
            this.rbYönetici.TabStop = true;
            this.rbYönetici.Text = "Yönetici Girişi";
            this.rbYönetici.UseVisualStyleBackColor = true;
            // 
            // rbMusteri
            // 
            this.rbMusteri.AutoSize = true;
            this.rbMusteri.Location = new System.Drawing.Point(149, 153);
            this.rbMusteri.Margin = new System.Windows.Forms.Padding(4);
            this.rbMusteri.Name = "rbMusteri";
            this.rbMusteri.Size = new System.Drawing.Size(105, 21);
            this.rbMusteri.TabIndex = 9;
            this.rbMusteri.TabStop = true;
            this.rbMusteri.Text = "Müşteri Girişi";
            this.rbMusteri.UseVisualStyleBackColor = true;
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.Location = new System.Drawing.Point(148, 51);
            this.txtKullaniciAdi.Margin = new System.Windows.Forms.Padding(4);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Size = new System.Drawing.Size(248, 25);
            this.txtKullaniciAdi.TabIndex = 7;
            // 
            // txtSifre
            // 
            this.txtSifre.Location = new System.Drawing.Point(148, 98);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.PasswordChar = '*';
            this.txtSifre.Size = new System.Drawing.Size(247, 25);
            this.txtSifre.TabIndex = 14;
            // 
            // ManavGiris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 281);
            this.Controls.Add(this.txtSifre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGiris);
            this.Controls.Add(this.rbYönetici);
            this.Controls.Add(this.rbMusteri);
            this.Controls.Add(this.txtKullaniciAdi);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ManavGiris";
            this.Text = "ManavGiris";
            this.Load += new System.EventHandler(this.ManavGiris_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGiris;
        private System.Windows.Forms.RadioButton rbYönetici;
        private System.Windows.Forms.RadioButton rbMusteri;
        private System.Windows.Forms.TextBox txtKullaniciAdi;
        private System.Windows.Forms.MaskedTextBox txtSifre;
    }
}