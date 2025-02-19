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
    public partial class FrmKayıtOl : Form
    {
        public FrmKayıtOl()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        private void btnKayıtOl_Click(object sender, EventArgs e)
        {
            try
            {
                string sorgu = "insert into Tbl_Kullanici (KullaniciAd,Sifre) values (@kullanici,@sifre)";
                SqlCommand kayıt = new SqlCommand(sorgu, bgl.baglanti());
                kayıt.Parameters.AddWithValue("@kullanici", txtKullanici.Text);
                kayıt.Parameters.AddWithValue("@sifre", txtSifre.Text);
                kayıt.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Kaydınız başarıyla oluşturuldu.","Bilgi",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Girdiğiniz Parametreleri kontrol ediniz." + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GeriBtn_Click(object sender, EventArgs e)
        {
            FrmGiris girisYap = new FrmGiris();
            this.Hide();
            girisYap.ShowDialog();
            this.Close();
        }
    }
}
