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

    
    public partial class FrmKategoriler : Form
    {
        public FrmKategoriler()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();
        private void GeriBtn_Click(object sender, EventArgs e)
        {
            FrmGiris girisYap = new FrmGiris();
            this.Hide();
            girisYap.ShowDialog();
            this.Close();
        }

        public static string SecilenUrunTuru = "";

        private void FrmKategoriler_Load(object sender, EventArgs e)
        {
            UrunTurleriniGetir();
            cmbUrunTur.Items.Add("Seçiniz...");

            cmbUrunTur.SelectedItem = "Seçiniz...";
        }

        private void UrunTurleriniGetir()
        {
            cmbUrunTur.Items.Clear();

            string komut = "Select DISTINCT ÜrünTürü From Tbl_Ürünler";
            SqlCommand command = new SqlCommand(komut, bgl.baglanti());

            SqlDataReader dr = command.ExecuteReader();

            while(dr.Read())
            {
                cmbUrunTur.Items.Add(dr["ÜrünTürü"].ToString());
            }

            bgl.baglanti().Close();
        }

        private void btnUrunTurEkle_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtUrunEkle.Text))
            {
                string komut = "insert into Tbl_Ürünler (ÜrünTürü) values (@urunTur)";
                SqlCommand urunturEkle = new SqlCommand(komut, bgl.baglanti());
                urunturEkle.Parameters.AddWithValue("@urunTur", txtUrunEkle.Text);

                urunturEkle.ExecuteNonQuery();
                bgl.baglanti().Close();

                MessageBox.Show("Ürün Türü Başarıyla Eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                UrunTurleriniGetir();

                txtUrunEkle.Clear();
            }
            else
            {
                MessageBox.Show("Lütfen bir ürün türü giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAc_Click(object sender, EventArgs e)
        {
            if (cmbUrunTur.SelectedItem != null && cmbUrunTur.SelectedItem.ToString() != "Seçiniz...")
            {
                // Ürün türünü al
                string secilenUrunTuru = cmbUrunTur.SelectedItem.ToString();

                // FrmÜrünler formunu oluştur ve ürün türünü gönder
                FrmÜrünler urunlerFormu = new FrmÜrünler(secilenUrunTuru);
                this.Hide();
                urunlerFormu.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Lütfen bir ürün türü seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (cmbUrunTur.SelectedItem != null)
            {
                string secilenUrunTuru = cmbUrunTur.SelectedItem.ToString();

                DialogResult sonuc = MessageBox.Show($"{secilenUrunTuru} ürün türünü silmek istediğinize emin misiniz?",
                    "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (sonuc == DialogResult.Yes)
                {
                    // Veritabanından sil
                    string sorgu = "DELETE FROM Tbl_Ürünler WHERE ÜrünTürü = @p1";
                    SqlCommand komut = new SqlCommand(sorgu, bgl.baglanti());
                    komut.Parameters.AddWithValue("@p1", secilenUrunTuru);
                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();

                    // ComboBox'tan kaldır
                    cmbUrunTur.Items.Remove(secilenUrunTuru);

                    // FrmUrunler'deki DataGridView'i güncelle
                    FrmÜrünler frmUrunler = Application.OpenForms["FrmUrunler"] as FrmÜrünler;
                    
                    MessageBox.Show("Ürün Türü Silindi");
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir ürün türü seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRaporGoster_Click(object sender, EventArgs e)
        {
            FrmRapor frmRapor = new FrmRapor();
            this.Hide();
            frmRapor.ShowDialog();
            this.Close();
        }

        private void cmbUrunTur_SelectedIndexChanged(object sender, EventArgs e)
        {
            SecilenUrunTuru = cmbUrunTur.SelectedItem.ToString();
        }
    }
}
