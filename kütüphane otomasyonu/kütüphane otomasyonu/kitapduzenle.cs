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
    public partial class kitapduzenle : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\kutuphanedatabase.accdb");
        public kitapduzenle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Database ile program arasında bağlantıyı açıyoruz:
            baglanti.Open();
            //Programdan ile Database'deki kitap bilgilerini güncelliyoruz.
            OleDbCommand komut = new OleDbCommand("update kitap set barkodno='" + textBox1.Text + "', kitapadi='" + textBox2.Text + "', yazari='" + textBox3.Text + "', sayfasayisi='" + textBox4.Text + "', rafno='" + textBox5.Text + "' where barkodno='" + textBox1.Text + "'", baglanti);
            komut.ExecuteNonQuery();
            //Database ile program arasında bağlantıyı kapatıyoruz:
            baglanti.Close();
            MessageBox.Show("Kitap bilgilerii başarıyla düzenlendi.");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //Database ile program arasında bağlantıyı açıyoruz:
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select * from kitap where barkodno LIKE'" + textBox1.Text.ToString() + "'", baglanti);
            OleDbDataReader okuyucu = komut.ExecuteReader();
            while (okuyucu.Read())
            {
                textBox2.Text = okuyucu["kitapadi"].ToString();
                textBox3.Text = okuyucu["yazari"].ToString();
                textBox4.Text = okuyucu["sayfasayisi"].ToString();
                textBox5.Text = okuyucu["rafno"].ToString();
            }
            //Database ile program arasında bağlantıyı kapatıyoruz:
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }
    }
}
