using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stok_Takip_Sistemi___Berat_Çakır
{
    internal class SqlBaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection("Data Source=beratxhunter\\SQLEXPRESS;Initial Catalog=StokTakipSis;Integrated Security=True;Encrypt=False;");
            baglan.Open();
            return baglan;
        }
    }
}
