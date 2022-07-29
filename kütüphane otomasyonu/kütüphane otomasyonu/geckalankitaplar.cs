using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Access veritabanı için gereken kütüphane kodu:
using System.Data.OleDb;

namespace kütüphane_otomasyonu
{
    public partial class geckalankitaplar : Form
    {
        //Veritabanı için bağlantı kodumuz:
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\kutuphanedatabase.accdb");
        public geckalankitaplar()
        {
            InitializeComponent();
        }

        private void geckalankitaplar_Load(object sender, EventArgs e)
        {
            string tarih = DateTime.Now.ToShortDateString();
            baglanti.Open();
            OleDbDataAdapter komut = new OleDbDataAdapter("select * from kitapver where teslimtarih <'" + tarih + "'", baglanti);
            DataTable tablo = new DataTable();
            komut.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
    }
}
