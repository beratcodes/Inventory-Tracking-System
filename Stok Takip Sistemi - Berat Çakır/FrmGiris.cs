using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stok_Takip_Sistemi___Berat_Çakır
{
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();
        private void btnGiris_Click(object sender, EventArgs e)
        {
            if(txtKullanici.Text == null)
            {
                MessageBox.Show("Lütfen bir kullanıcı adı giriniz!","Hata",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(txtSifre.Text == null)
            {
                MessageBox.Show("Lütfen bir şifre giriniz!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            string sorgu = "Select * From Tbl_Kullanici where KullaniciAd=@kullanıcı and Sifre=@sifre";

            SqlCommand giris = new SqlCommand(sorgu, bgl.baglanti());
            giris.Parameters.AddWithValue("@kullanıcı", txtKullanici.Text);
            giris.Parameters.AddWithValue("@sifre", txtSifre.Text);
            SqlDataReader dr = giris.ExecuteReader();

            if(dr.Read())
            {
                FrmKategoriler kategoriler = new FrmKategoriler();
                this.Hide();
                kategoriler.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Lütfen girilen parametreleri kontrol ediniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LblKayitOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmKayıtOl kayıtOl = new FrmKayıtOl();
            kayıtOl.Show();
            this.Hide();
        }
    }
}
