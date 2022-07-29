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
    public partial class ogrencilistele : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\kutuphanedatabase.accdb");

        DataTable tablo = new DataTable();
        public ogrencilistele()
        {
            InitializeComponent();
        }

        private void ogrencilistele_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbDataAdapter adaptr = new OleDbDataAdapter("select * from ogrenci", baglanti);
            adaptr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
    }
}
