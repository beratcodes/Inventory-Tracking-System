using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stok_Takip_Sistemi___Berat_Çakır
{
    public partial class FrmÜrünler : Form
    {
        public string UrunTuru { get; set; }
        public string UrunMarka { get; set; }
        public string UrunTipi { get; set; }

        public FrmÜrünler(string urunTuru, string urunMarka = null, string urunTipi = null)
        {
            InitializeComponent();
            this.UrunTuru = urunTuru;
            this.UrunMarka = urunMarka;
            this.UrunTipi = urunTipi;
        }

        SqlBaglantisi bgl = new SqlBaglantisi();
        DataTable dt = new DataTable();

        void verileriYukle()
        {
            string sorgu = "SELECT * FROM Tbl_Ürünler WHERE ÜrünTürü = @urunTuru";
            // SQL sorgusu: Seçilen ürün türüne göre filtreleme yap
            SqlCommand komut = new SqlCommand(sorgu, bgl.baglanti());
            komut.Parameters.AddWithValue("@urunTuru", UrunTuru);

            // Verileri DataTable'a doldur
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);

            // DataGridView'e verileri yükle
            dataGridView1.DataSource = dt;

            bgl.baglanti().Close();
        }

        private void FrmÜrünler_Load(object sender, EventArgs e)
        {
            verileriYukle();
            dataGridView1.ReadOnly = true;
            txtUrunTuru.ReadOnly = true;
            txtUrunID.ReadOnly = true;
            ResimleriGizle();

            txtUrunTuru.Text = UrunTuru;

            // cmbUrunTipi, cmbUrunRenk ve cmbUrunBeden için varsayılan değerleri ayarlıyoruz
            if (UrunTuru == "İş Ayakkabısı")
            {
                cmbUrunTipi.Items.Add("Seçiniz...");
                cmbUrunRenk.Items.Add("Seçiniz...");
                cmbUrunBeden.Items.Add("Seçiniz...");
                cmbUrunMarka.Items.Add("Seçiniz...");
                
                cmbUrunTipi.Items.Add("Standart");
                cmbUrunRenk.Items.Add("Standart");
                cmbUrunBeden.Items.Add("35");
                cmbUrunBeden.Items.Add("36");
                cmbUrunBeden.Items.Add("37");
                cmbUrunBeden.Items.Add("38");
                cmbUrunBeden.Items.Add("39");
                cmbUrunBeden.Items.Add("40");
                cmbUrunBeden.Items.Add("41");
                cmbUrunBeden.Items.Add("42");
                cmbUrunBeden.Items.Add("43");
                cmbUrunBeden.Items.Add("44");
                cmbUrunBeden.Items.Add("45");
                cmbUrunMarka.Items.Add("YDS");
                cmbUrunMarka.Items.Add("Base B1006A");
                cmbUrunMarka.Items.Add("Toworkfor X");
                cmbUrunMarka.Items.Add("Swolx Combo X");
                cmbUrunMarka.Items.Add("BMES 1453");

                cmbUrunTipi.SelectedItem = "Seçiniz...";
                cmbUrunRenk.SelectedItem = "Seçiniz...";
                cmbUrunBeden.SelectedItem = "Seçiniz...";
                cmbUrunMarka.SelectedItem = "Seçiniz...";
            }
            else if (UrunTuru == "İş Pantolonu")
            {
                cmbUrunTipi.Items.Add("Seçiniz...");
                cmbUrunRenk.Items.Add("Seçiniz...");
                cmbUrunBeden.Items.Add("Seçiniz...");
                cmbUrunMarka.Items.Add("Seçiniz...");

                cmbUrunTipi.Items.Add("Harman");
                cmbUrunTipi.Items.Add("Parça");
                cmbUrunTipi.Items.Add("Gabardin");
                cmbUrunRenk.Items.Add("Standart");
                cmbUrunBeden.Items.Add("S");
                cmbUrunBeden.Items.Add("M");
                cmbUrunBeden.Items.Add("L");
                cmbUrunBeden.Items.Add("XL");
                cmbUrunBeden.Items.Add("XXL");
                cmbUrunBeden.Items.Add("3XL");
                cmbUrunMarka.Items.Add("Standart");

                cmbUrunTipi.SelectedItem = "Seçiniz...";
                cmbUrunRenk.SelectedItem = "Seçiniz...";
                cmbUrunBeden.SelectedItem = "Seçiniz...";
                cmbUrunMarka.SelectedItem = "Seçiniz...";
            }
            else if (UrunTuru == "Baret")
            {
                cmbUrunTipi.Items.Add("Seçiniz...");
                cmbUrunRenk.Items.Add("Seçiniz...");
                cmbUrunBeden.Items.Add("Seçiniz...");
                cmbUrunMarka.Items.Add("Seçiniz...");

                cmbUrunRenk.Items.Add("Beyaz");
                cmbUrunRenk.Items.Add("Turuncu");
                cmbUrunRenk.Items.Add("Sarı");
                cmbUrunRenk.Items.Add("Mavi");
                cmbUrunRenk.Items.Add("Yeşil");
                cmbUrunBeden.Items.Add("Standart");
                cmbUrunTipi.Items.Add("Standart");

                cmbUrunMarka.Items.Add("3M");
                cmbUrunMarka.Items.Add("Cerva Alpinworker");

                cmbUrunTipi.SelectedItem = "Seçiniz...";
                cmbUrunRenk.SelectedItem = "Seçiniz...";
                cmbUrunBeden.SelectedItem = "Seçiniz...";
                cmbUrunMarka.SelectedItem = "Seçiniz...";

            }
            else if (UrunTuru == "Yelek")
            {
                cmbUrunTipi.Items.Add("Seçiniz...");
                cmbUrunRenk.Items.Add("Seçiniz...");
                cmbUrunBeden.Items.Add("Seçiniz...");
                cmbUrunMarka.Items.Add("Seçiniz...");

                cmbUrunBeden.Items.Add("S");
                cmbUrunBeden.Items.Add("M");
                cmbUrunBeden.Items.Add("L");
                cmbUrunBeden.Items.Add("XL");
                cmbUrunBeden.Items.Add("XXL");
                cmbUrunBeden.Items.Add("3XL");
                cmbUrunRenk.Items.Add("Turuncu");
                cmbUrunRenk.Items.Add("Sarı");
                cmbUrunRenk.Items.Add("Kahverengi");
                cmbUrunRenk.Items.Add("Gri");
                cmbUrunTipi.Items.Add("Çok Cepli");
                cmbUrunTipi.Items.Add("Mühendis");
                cmbUrunTipi.Items.Add("İşçi");
                cmbUrunTipi.Items.Add("Deri");

                cmbUrunMarka.Items.Add("Standart");

                cmbUrunTipi.SelectedItem = "Seçiniz...";
                cmbUrunRenk.SelectedItem = "Seçiniz...";
                cmbUrunBeden.SelectedItem = "Seçiniz...";
                cmbUrunMarka.SelectedItem = "Seçiniz...";
            }
            else if (UrunTuru == "Tulum")
            {
                cmbUrunTipi.Items.Add("Seçiniz...");
                cmbUrunRenk.Items.Add("Seçiniz...");
                cmbUrunBeden.Items.Add("Seçiniz...");
                cmbUrunMarka.Items.Add("Seçiniz...");

                cmbUrunTipi.Items.Add("Bahçıvan");
                cmbUrunTipi.Items.Add("Tyvek");
                cmbUrunTipi.Items.Add("Reflektör");
                cmbUrunTipi.Items.Add("İşçi");
                cmbUrunRenk.Items.Add("Turuncu");
                cmbUrunRenk.Items.Add("Lacivert");
                cmbUrunRenk.Items.Add("Mavi");
                cmbUrunRenk.Items.Add("Yeşil");
                cmbUrunRenk.Items.Add("Beyaz");
                cmbUrunBeden.Items.Add("S");
                cmbUrunBeden.Items.Add("M");
                cmbUrunBeden.Items.Add("L");
                cmbUrunBeden.Items.Add("XL");
                cmbUrunBeden.Items.Add("2XL");
                cmbUrunBeden.Items.Add("3XL");

                cmbUrunMarka.Items.Add("Standart");

                cmbUrunTipi.SelectedItem = "Seçiniz...";
                cmbUrunRenk.SelectedItem = "Seçiniz...";
                cmbUrunBeden.SelectedItem = "Seçiniz...";
                cmbUrunMarka.SelectedItem = "Seçiniz...";
            } 
            else if(UrunTuru == "Eldiven")
            {
                cmbUrunTipi.Items.Add("Seçiniz...");
                cmbUrunRenk.Items.Add("Seçiniz...");
                cmbUrunBeden.Items.Add("Seçiniz...");
                cmbUrunMarka.Items.Add("Seçiniz...");

                cmbUrunTipi.Items.Add("Kaynakçı");
                cmbUrunTipi.Items.Add("Elektirikçi");
                cmbUrunTipi.Items.Add("Aşçı");
                cmbUrunTipi.Items.Add("İşçi");
                cmbUrunRenk.Items.Add("Standart");
                cmbUrunBeden.Items.Add("Standart");

                cmbUrunMarka.Items.Add("Beybi");
                cmbUrunMarka.Items.Add("Dolphin");
                cmbUrunMarka.Items.Add("Universal");

                cmbUrunTipi.SelectedItem = "Seçiniz...";
                cmbUrunRenk.SelectedItem = "Seçiniz...";
                cmbUrunBeden.SelectedItem = "Seçiniz...";
                cmbUrunMarka.SelectedItem = "Seçiniz...";
            }
        }

        private void ResimleriGizle()
        {
            // Ayakkabılar
            ydsPicture.Visible = false;
            BasePicture.Visible = false;
            TowolkforPicture.Visible = false;
            BmesPicture.Visible = false;
            SwolxPicture.Visible = false;

            // Yelekler
            CokCepliGri.Visible = false;
            CokCepliKahve.Visible = false;
            DeriYelekKahve.Visible = false;
            MühYelekSarı.Visible = false;
            MühYelekTuruncu.Visible = false;
            IsciYelekSari.Visible = false;

            // Tulumlar
            LacivertBahçıvanPctr.Visible = false;
            TuruncuBahcıvanPctr.Visible = false;
            MaviBahcıvanPctr.Visible = false;
            İşTulumuLacivertPctr.Visible = false;
            IsTuruncuPctr.Visible = false;
            TyvekTulumPctr.Visible = false;
            ReflektörLacivertPctr.Visible = false;
            ReflektörTuruncuPctr.Visible = false;
            IsMaviTulumPicture.Visible = false;

            // Pantolonlar 
            GabardinPicture.Visible = false;
            HarmanPicture.Visible = false;
            ParcaPicture.Visible = false;

            // Baretler
            UcMBeyazPicture.Visible = false;
            UcMMaviPicture.Visible = false;
            UcMSarıPicture.Visible = false;
            UcMTuruncuPicture.Visible = false;
            UcMYesilPicture.Visible = false;
            CervaBeyaz.Visible = false;
            CervaMavi.Visible = false;
            CervaSarı.Visible = false;
            CervaTuruncu.Visible = false;

            // Eldivenler 
            AscıEldiveni.Visible = false;
            IscıBeybi.Visible = false;
            KaynakcıUniversal.Visible = false;
            ElektirikciBeybi.Visible = false;
        }

        private void GeriBtn_Click(object sender, EventArgs e)
        {
            FrmKategoriler kategori = new FrmKategoriler();
            this.Hide();
            kategori.ShowDialog();
            this.Close();
        }

        private void btnOzellikEkle_Click(object sender, EventArgs e)
        {
            // Ürün Tipi Ekle
            if (!string.IsNullOrEmpty(txtTipEkle.Text) && !cmbUrunTipi.Items.Contains(txtTipEkle.Text))
            {
                cmbUrunTipi.Items.Add(txtTipEkle.Text);
            }

            // Ürün Beden Ekle
            if (!string.IsNullOrEmpty(txtBedenEkle.Text) && !cmbUrunBeden.Items.Contains(txtBedenEkle.Text))
            {
                cmbUrunBeden.Items.Add(txtBedenEkle.Text);
            }

            // Ürün Renk Ekle
            if (!string.IsNullOrEmpty(txtRenkEkle.Text) && !cmbUrunRenk.Items.Contains(txtRenkEkle.Text))
            {
                cmbUrunRenk.Items.Add(txtRenkEkle.Text);
            }

            // Ürün Marka Ekle
            if (!string.IsNullOrEmpty(txtMarkaEkle.Text) && !cmbUrunMarka.Items.Contains(txtMarkaEkle.Text))
            {
                cmbUrunMarka.Items.Add(txtMarkaEkle.Text);
            }

            // TextBox'ları temizle
            txtTipEkle.Clear();
            txtBedenEkle.Clear();
            txtRenkEkle.Clear();
            txtMarkaEkle.Clear();

            // Veritabanında mevcut ürün türüyle eşleşen kaydı güncelle
            //urunEkle.ExecuteNonQuery();
            //bgl.baglanti().Close();

            MessageBox.Show("Ürün özellikleri başarıyla güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Textbox'ları temizle
            txtBedenEkle.Clear();
            txtRenkEkle.Clear();
            txtTipEkle.Clear();
            txtMarkaEkle.Clear();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtUrunID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            cmbUrunTipi.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbUrunMarka.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            cmbUrunRenk.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            cmbUrunBeden.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtAlisFiyat.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
            txtSatisFiyat.Text = dataGridView1.Rows[secilen].Cells[8].Value.ToString();

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            if (e.RowIndex >= 0)
            {
                LblFiyat.Text = "Fiyat: " + row.Cells["SatisFiyat"].Value.ToString() + " TL";
                LblMarka.Text = "Marka: " + row.Cells["ÜrünMarka"].Value.ToString();
                LblTip.Text = "Ürün Tipi: " + row.Cells["ÜrünTipi"].Value.ToString();
                LblBeden.Text = "Beden: " + row.Cells["ÜrünBeden"].Value.ToString();
            }
            
            string eldivenTipi = row.Cells["ÜrünTipi"].Value.ToString();
            string ayakkabıMarka = row.Cells["ÜrünMarka"].Value.ToString();
            string pantolonTipi = row.Cells["ÜrünTipi"].Value.ToString();
            string yelekTipi = row.Cells["ÜrünTipi"].Value.ToString();
            string baretMarka = row.Cells["ÜrünMarka"].Value.ToString();
            string tulumTipi = row.Cells["ÜrünTipi"].Value.ToString();

            ResimleriGizle();

            if (txtUrunTuru.Text == "Eldiven")
            {
                switch(eldivenTipi)
                {
                    case "Elektirikçi":
                        ElektirikciBeybi.Visible = true; break;
                    case "Kaynakçı":
                        KaynakcıUniversal.Visible = true; break;
                    case "Aşçı":
                        AscıEldiveni.Visible = true; break;
                    case "İşçi":
                        IscıBeybi.Visible = true; break;
                }
            }
            else if(txtUrunTuru.Text == "İş Ayakkabısı")
            {
                switch(ayakkabıMarka)
                {
                    case "YDS":
                        ydsPicture.Visible = true; break;
                    case "Base B1006A":
                        BasePicture.Visible = true; break;
                    case "Toworkfor X":
                        TowolkforPicture.Visible = true; break;
                    case "Swolx Combo X":
                        SwolxPicture.Visible = true; break;
                    case "BMES 1453":
                        BmesPicture.Visible = true; break;  
                }
            }
            else if(txtUrunTuru.Text == "İş Pantolonu")
            {
                switch (pantolonTipi)
                {
                    case "Parça":
                        ParcaPicture.Visible = true; break;
                    case "Harman":
                        HarmanPicture.Visible = true; break;
                    case "Gabardin":
                        GabardinPicture.Visible = true; break;  
                }
            }
            else if(txtUrunTuru.Text == "Tulum")
            {
                switch(tulumTipi)
                {
                    case "Bahçıvan":
                        if(row.Cells["ÜrünRenk"].Value.ToString() == "Lacivert")
                        {
                            LacivertBahçıvanPctr.Visible = true; break;
                        }
                        if(row.Cells["ÜrünRenk"].Value.ToString() == "Turuncu")
                        {
                            TuruncuBahcıvanPctr.Visible = true; break;
                        }
                        if(row.Cells["ÜrünRenk"].Value.ToString() == "Mavi")
                        {
                            MaviBahcıvanPctr.Visible=true; break;
                        }
                        break;
                    case "Tyvek":
                        if(row.Cells["ÜrünRenk"].Value.ToString() == "Beyaz")
                        {
                            TyvekTulumPctr.Visible = true; break;
                        }
                        break;
                    case "Reflektör":
                        if(row.Cells["ÜrünRenk"].Value.ToString() == "Lacivert")
                        {
                            ReflektörLacivertPctr.Visible = true; break;
                        }
                        if(row.Cells["ÜrünRenk"].Value.ToString() == "Turuncu")
                        {
                            ReflektörTuruncuPctr.Visible = true; break;
                        }
                        break;
                    case "İşçi":
                        if(row.Cells["ÜrünRenk"].Value.ToString() == "Lacivert")
                        {
                            İşTulumuLacivertPctr.Visible = true; break;
                        }
                        if(row.Cells["ÜrünRenk"].Value.ToString() == "Turuncu")
                        {
                            IsTuruncuPctr.Visible = true; break;
                        }
                        if(row.Cells["ÜrünRenk"].Value.ToString() == "Mavi")
                        {
                            IsMaviTulumPicture.Visible = true; break;   
                        }
                        break;
                }
            }
            else if(txtUrunTuru.Text == "Baret")
            {
                switch (baretMarka)
                {
                    case "3M":
                        if(row.Cells["ÜrünRenk"].Value.ToString() == "Turuncu")
                        {
                            UcMTuruncuPicture.Visible = true; break;
                        }
                        if(row.Cells["ÜrünRenk"].Value.ToString() == "Beyaz")
                        {
                            UcMBeyazPicture.Visible = true; break;  
                        }
                        if(row.Cells["ÜrünRenk"].Value.ToString() == "Mavi")
                        {
                            UcMMaviPicture.Visible = true; break;
                        }
                        if(row.Cells["ÜrünRenk"].Value.ToString() == "Yeşil")
                        {
                            UcMYesilPicture.Visible = true; break;
                        }
                        if(row.Cells["ÜrünRenk"].Value.ToString() == "Sarı")
                        {
                            UcMSarıPicture.Visible = true; break;
                        }
                        break;
                    case "Cerva Alpinworker":
                        if(row.Cells["ÜrünRenk"].Value.ToString() == "Turuncu")
                        {
                            CervaTuruncu.Visible = true; break;
                        }
                        if(row.Cells["ÜrünRenk"].Value.ToString() == "Beyaz")
                        {
                            CervaBeyaz.Visible = true; break;
                        }
                        if(row.Cells["ÜrünRenk"].Value.ToString() == "Mavi")
                        {
                            CervaMavi.Visible = true; break;
                        }
                        if(row.Cells["ÜrünRenk"].Value.ToString() == "Sarı")
                        {
                            CervaSarı.Visible= true; break;
                        }break;
                }
            }
            else if(txtUrunTuru.Text == "Yelek")
            {
                switch(yelekTipi)
                {
                    case "Çok Cepli":
                        if(row.Cells["ÜrünRenk"].Value.ToString() == "Kahverengi")
                        {
                            CokCepliKahve.Visible = true; break;
                        }
                        if(row.Cells["ÜrünRenk"].Value.ToString() == "Gri")
                        {
                            CokCepliGri.Visible = true; break;  
                        }break;
                    case "Mühendis":
                        if(row.Cells["ÜrünRenk"].Value.ToString() == "Turuncu")
                        {
                            MühYelekTuruncu.Visible = true; break;
                        }
                        if(row.Cells["ÜrünRenk"].Value.ToString() == "Sarı")
                        {
                            MühYelekSarı.Visible = true; break;
                        }break;
                    case "İşçi":
                        IsciYelekSari.Visible = true; break;
                    case "Deri":
                        DeriYelekKahve.Visible = true; break;
                }
            }
        }

        private int GetMevcutStok(string urunID)
        {
            // Veritabanından ürünün stok adedini almak için sorgu hazırlıyoruz
            SqlCommand komut = new SqlCommand("SELECT StokAdedi FROM Tbl_Ürünler WHERE ÜrünID = @urunID", bgl.baglanti());
            komut.Parameters.AddWithValue("@urunID", urunID);  // Ürün ID'sini parametre olarak veriyoruz

            // Veritabanından sonuçları okuyoruz
            SqlDataReader dr = komut.ExecuteReader();
            int stokAdedi = 0;  // Başlangıçta stok adedini 0 olarak kabul ediyoruz
            if (dr.Read()) // Eğer veri varsa, stok adetini alıyoruz
            {
                stokAdedi = Convert.ToInt32(dr["StokAdedi"]);
            }

            bgl.baglanti().Close(); // Bağlantıyı kapatıyoruz
            return stokAdedi; // Mevcut stok miktarını döndürüyoruz
        }

        private void UpdateStokAdedi(string urunID, int yeniStokAdedi)
        {
            // Veritabanında ürünün stok miktarını güncellemek için sorgu hazırlıyoruz
            SqlCommand komut = new SqlCommand("UPDATE Tbl_Ürünler SET StokAdedi = @yeniStokAdedi WHERE ÜrünID = @urunID", bgl.baglanti());
            komut.Parameters.AddWithValue("@yeniStokAdedi", yeniStokAdedi); // Yeni stok miktarını parametre olarak veriyoruz
            komut.Parameters.AddWithValue("@urunID", urunID);  // Ürün ID'sini parametre olarak veriyoruz

            komut.ExecuteNonQuery(); // Sorguyu çalıştırıyoruz
            bgl.baglanti().Close(); // Bağlantıyı kapatıyoruz
        }

        private void btnSat_Click(object sender, EventArgs e)
        {
            // Verilerin alındığı yerler
            string urunID = txtUrunID.Text;
            string urunTuru = txtUrunTuru.Text;
            string urunTipi = cmbUrunTipi.SelectedItem.ToString();
            string urunMarka = cmbUrunMarka.Text;
            string urunRenk = cmbUrunRenk.SelectedItem.ToString();
            string urunBeden = cmbUrunBeden.SelectedItem.ToString();
            decimal alisFiyati = decimal.Parse(txtAlisFiyat.Text);
            decimal satisFiyati = decimal.Parse(txtSatisFiyat.Text);
            int satilanAdet = int.Parse(txtAdet.Text);
            DateTime satisTarihi = DateTime.Now;

            // Stok Adedi Güncelleme
            if (satilanAdet > 0)
            {
                // 1. Ürün satışını yapmadan önce stoktaki adet kontrol edelim
                int mevcutStok = GetMevcutStok(urunID);  // Ürünün mevcut stok bilgisini al

                if (satilanAdet > mevcutStok)
                {
                    MessageBox.Show("Stokta yeterli ürün bulunmamaktadır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 2. Stok adetini düşürme
                UpdateStokAdedi(urunID, mevcutStok - satilanAdet);  // Stoktan satılan adet kadar düşür

                // 3. Tbl_Rapor tablosuna satış verilerini ekleme
                SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Rapor WHERE ÜrünID = @urunID AND Tarih = @tarih", bgl.baglanti());
                komut.Parameters.AddWithValue("@urunID", urunID);
                komut.Parameters.AddWithValue("@tarih", satisTarihi.Date); // Günlük satış işlemi

                SqlDataReader dr = komut.ExecuteReader();
                bool isExisting = dr.HasRows; // Aynı gün satılmışsa var olan satırı güncelleme

                bgl.baglanti().Close();

                if (isExisting)
                {
                    // 4. Eğer o gün aynı ürün satıldıysa, SatilanAdet'i güncelle
                    SqlCommand guncelleKomut = new SqlCommand("UPDATE Tbl_Rapor SET SatilanAdet = SatilanAdet + @satilanAdet WHERE ÜrünID = @urunID AND Tarih = @tarih", bgl.baglanti());
                    guncelleKomut.Parameters.AddWithValue("@satilanAdet", satilanAdet);
                    guncelleKomut.Parameters.AddWithValue("@urunID", urunID);
                    guncelleKomut.Parameters.AddWithValue("@tarih", satisTarihi.Date);
                    guncelleKomut.ExecuteNonQuery();
                }
                else
                {
                    // 5. Eğer o gün satılmamışsa, yeni bir kayıt ekle
                    SqlCommand ekleKomut = new SqlCommand("INSERT INTO Tbl_Rapor (ÜrünID, ÜrünTürü, ÜrünTipi, ÜrünMarka, ÜrünRenk, ÜrünBeden, AlisFiyati, SatisFiyati, SatilanAdet, Tarih) " +
                        "VALUES (@urunID, @urunTuru, @urunTipi, @urunMarka, @urunRenk, @urunBeden, @alisFiyati, @satisFiyati, @satilanAdet, @tarih)", bgl.baglanti());
                    ekleKomut.Parameters.AddWithValue("@urunID", urunID);
                    ekleKomut.Parameters.AddWithValue("@urunTuru", urunTuru);
                    ekleKomut.Parameters.AddWithValue("@urunTipi", urunTipi);
                    ekleKomut.Parameters.AddWithValue("@urunMarka", urunMarka);
                    ekleKomut.Parameters.AddWithValue("@urunRenk", urunRenk);
                    ekleKomut.Parameters.AddWithValue("@urunBeden", urunBeden);
                    ekleKomut.Parameters.AddWithValue("@alisFiyati", alisFiyati);
                    ekleKomut.Parameters.AddWithValue("@satisFiyati", satisFiyati);
                    ekleKomut.Parameters.AddWithValue("@satilanAdet", satilanAdet);
                    ekleKomut.Parameters.AddWithValue("@tarih", satisTarihi.Date);
                    ekleKomut.ExecuteNonQuery();
                }

                MessageBox.Show("Satış işlemi başarıyla gerçekleştirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Satılacak adet girilmemiş.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (!DateTime.TryParse(SatisTarih.Text, out DateTime satisTarih))
                {
                    MessageBox.Show("Geçerli bir tarih giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Fiyat ve adet kontrolleri
                if (!decimal.TryParse(txtSatisFiyat.Text, out decimal satisFiyat))
                {
                    MessageBox.Show("Lütfen geçerli bir satış fiyatı giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!decimal.TryParse(txtAlisFiyat.Text, out decimal alisFiyat))
                {
                    MessageBox.Show("Lütfen geçerli bir alış fiyatı giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!int.TryParse(txtAdet.Text, out int stokAdedi))
                {
                    MessageBox.Show("Lütfen geçerli bir stok adedi giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Boş alan kontrolleri
                if (string.IsNullOrWhiteSpace(cmbUrunMarka.Text) || cmbUrunMarka.SelectedItem == "Seçiniz..." ||
                    string.IsNullOrWhiteSpace(cmbUrunBeden.Text) || cmbUrunBeden.SelectedItem == "Seçiniz..." ||
                    string.IsNullOrWhiteSpace(cmbUrunRenk.Text) || cmbUrunRenk.SelectedItem == "Seçiniz..." ||
                    string.IsNullOrWhiteSpace(cmbUrunTipi.Text) || cmbUrunTipi.SelectedItem == "Seçiniz...")
                {
                    MessageBox.Show("Lütfen tüm alanları doldurunuz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Ürün türü kontrolü
                string secilenTur = txtUrunTuru.Text;

                // Veritabanı bağlantısını aç
                bgl.baglanti();

                // Mevcut kaydı kontrol et (Beden kriteri eklendi)
                SqlCommand kontrolKomutu = new SqlCommand(
                    "SELECT COUNT(*) FROM Tbl_Ürünler " +
                    "WHERE ÜrünTürü = @ürünTürü AND ÜrünMarka = @ürünMarka AND ÜrünBeden = @ürünBeden and ÜrünTipi = @ürünTipi and ÜrünRenk = @ürünRenk", bgl.baglanti());
                kontrolKomutu.Parameters.AddWithValue("@ürünTürü", txtUrunTuru.Text);
                kontrolKomutu.Parameters.AddWithValue("@ürünMarka", cmbUrunMarka.Text);
                kontrolKomutu.Parameters.AddWithValue("@ürünBeden", cmbUrunBeden.Text); // Beden kontrolü 
                kontrolKomutu.Parameters.AddWithValue("@ürünTipi", cmbUrunTipi.Text); // Tip kontrolü 
                kontrolKomutu.Parameters.AddWithValue("@ürünRenk", cmbUrunRenk.Text); // Renk kontrolü 

                int kayitSayisi = (int)kontrolKomutu.ExecuteScalar(); // Kayıt sayısını al

                if (kayitSayisi > 0) // Kayıt varsa
                {
                    // Stok ve fiyat güncelle (Beden kontrolü eklendi)
                    SqlCommand urunGuncelle = new SqlCommand(
                        "UPDATE Tbl_Ürünler " +
                        "SET StokAdedi = StokAdedi + @p1, SatisFiyat = @p2 " +
                        "WHERE ÜrünTürü = @p3 AND ÜrünMarka = @p4 AND ÜrünBeden = @p5 and ÜrünTipi = @p6 and ÜrünRenk = @p7", bgl.baglanti());
                    urunGuncelle.Parameters.AddWithValue("@p1", stokAdedi);    // Yeni Eklenen adet
                    urunGuncelle.Parameters.AddWithValue("@p2", satisFiyat);   // Güncellenen Fiyat
                    urunGuncelle.Parameters.AddWithValue("@p3", txtUrunTuru.Text);
                    urunGuncelle.Parameters.AddWithValue("@p4", cmbUrunMarka.Text);
                    urunGuncelle.Parameters.AddWithValue("@p5", cmbUrunBeden.Text); // Beden kontrolü 
                    urunGuncelle.Parameters.AddWithValue("@p6", cmbUrunTipi.Text); // Tip kontrolü 
                    urunGuncelle.Parameters.AddWithValue("@p7", cmbUrunRenk.Text); // Renk kontrolü 


                    urunGuncelle.ExecuteNonQuery();
                    MessageBox.Show($"Mevcut {secilenTur} kaydının stoğu güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else // Kayıt yoksa yeni kayıt ekle
                {
                    SqlCommand urunEkle = new SqlCommand(
                        "INSERT INTO Tbl_Ürünler " +
                        "(ÜrünTürü,ÜrünTipi,ÜrünMarka,ÜrünRenk,ÜrünBeden,StokAdedi,AlisFiyat,SatisFiyat,Tarih) VALUES " +
                        "(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", bgl.baglanti());
                    urunEkle.Parameters.AddWithValue("@p1", txtUrunTuru.Text);
                    urunEkle.Parameters.AddWithValue("@p2", cmbUrunTipi.Text);
                    urunEkle.Parameters.AddWithValue("@p3", cmbUrunMarka.Text);
                    urunEkle.Parameters.AddWithValue("@p4", cmbUrunRenk.Text);
                    urunEkle.Parameters.AddWithValue("@p5", cmbUrunBeden.Text);
                    urunEkle.Parameters.AddWithValue("@p6", stokAdedi);
                    urunEkle.Parameters.AddWithValue("@p7", alisFiyat);
                    urunEkle.Parameters.AddWithValue("@p8", satisFiyat);
                    urunEkle.Parameters.AddWithValue("@p9", satisTarih.ToString("yyyy-MM-dd")); // Tarih formatı

                    urunEkle.ExecuteNonQuery();
                    MessageBox.Show($"Yeni {secilenTur} başarıyla stoğa eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Veritabanı bağlantısını kapat
                bgl.baglanti().Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bgl.baglanti().Close();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                // Seçilen ürünü silmek için yazdığım kod bloğu.
                SqlCommand urunSil = new SqlCommand(
                    "Delete From Tbl_Ürünler where ÜrünID = @p1", bgl.baglanti());
                urunSil.Parameters.Add("@p1", txtUrunID.Text);
                urunSil.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Ürün başarıyla silindi.","Bilgi",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Girdiğiniz Parametreleri Lütfen Kontrol Ediniz." + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            // Seçilen ürünü güncellemek için yazdığım kod
            try
            {
                SqlCommand urunGuncelle = new SqlCommand(
                    "Update Tbl_Ürünler set ÜrünTipi=@p1, ÜrünMarka=@p2, ÜrünRenk=@p3, ÜrünBeden=@p4, " +
                    "AlisFiyat=@p5, SatisFiyat=@p6 where ÜrünID=@p7", bgl.baglanti());

                urunGuncelle.Parameters.AddWithValue("@p1", cmbUrunTipi.Text);
                urunGuncelle.Parameters.AddWithValue("@p2", cmbUrunMarka.Text);
                urunGuncelle.Parameters.AddWithValue("@p3", cmbUrunRenk.Text);
                urunGuncelle.Parameters.AddWithValue("@p4", cmbUrunBeden.Text);
                urunGuncelle.Parameters.AddWithValue("@p5", decimal.Parse(txtAlisFiyat.Text)); // Sayıya dönüştürün
                urunGuncelle.Parameters.AddWithValue("@p6", decimal.Parse(txtSatisFiyat.Text)); // Sayıya dönüştürün
                urunGuncelle.Parameters.AddWithValue("@p7", int.Parse(txtUrunID.Text)); // Sayıya dönüştürün

                urunGuncelle.ExecuteNonQuery();
                bgl.baglanti().Close();

                LblBeden.Text = "Beden: " + cmbUrunBeden.Text;
                LblFiyat.Text = "Fiyat: " + decimal.Parse(txtSatisFiyat.Text) + " TL";
                LblMarka.Text = "Marka: " + cmbUrunMarka.Text;
                LblTip.Text = "Ürün Tipi: " + cmbUrunTipi.Text;

                MessageBox.Show("Ürün başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            ResimleriGizle();
            LblAdet.Text = "";
            LblBeden.Text = "";
            LblFiyat.Text = "";
            LblMarka.Text = "";
            LblTip.Text = "";
            
            txtUrunID.Text = "";
            txtSatisFiyat.Text = "";
            txtAlisFiyat.Text = "";
            txtAdet.Text = "";
            cmbUrunBeden.SelectedItem = "Seçiniz...";
            cmbUrunMarka.SelectedItem = "Seçiniz...";
            cmbUrunRenk.SelectedItem = "Seçiniz...";
            cmbUrunTipi.SelectedItem = "Seçiniz...";

            // Seçilen Ürün Türüne göre listeleme işlemi
            try
            {
                // SQL sorgusunu oluştur
                SqlCommand komut = new SqlCommand(
                    "SELECT * FROM Tbl_Ürünler WHERE ÜrünTürü = @urunTuru", bgl.baglanti());

                // FrmKategoriler formundan seçilen ürün türünü parametre olarak ekle
                komut.Parameters.AddWithValue("@urunTuru", FrmKategoriler.SecilenUrunTuru);

                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Sonuçları DataGridView'e yükle
                dataGridView1.DataSource = dt;

                bgl.baglanti().Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
