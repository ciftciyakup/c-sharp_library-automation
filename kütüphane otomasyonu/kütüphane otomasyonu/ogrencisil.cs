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
    public partial class ogrencisil : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\kutuphanedatabase.accdb");


        public ogrencisil()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("delete from ogrenci where tcno='" + textBox1.Text + "'", baglanti);
            komut.ExecuteNonQuery();
            MessageBox.Show("Öğrenci başarıyla silindi.");
            baglanti.Close();
        }
    }
}
