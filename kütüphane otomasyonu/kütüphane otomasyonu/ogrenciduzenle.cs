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
    public partial class ogrenciduzenle : Form
    {
        //Database ile program arasında bağlantı oluşturuyoruz:
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\kutuphanedatabase.accdb");

        public ogrenciduzenle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Database ile program arasında bağlantıyı açıyoruz:
            baglanti.Open();
            //Programdan ile Database'deki öğrenci bilgilerini güncelliyoruz.
            OleDbCommand komut = new OleDbCommand("update ogrenci set tcno='" + textBox1.Text + "', adi='" + textBox2.Text + "', soyadi='" + textBox3.Text + "', telefon='" + textBox4.Text + "', adres='" + textBox5.Text +"' where tcno='" + textBox1.Text + "'", baglanti);
            komut.ExecuteNonQuery();
            //Database ile program arasında bağlantıyı kapatıyoruz:
            baglanti.Close();
            MessageBox.Show("Öğrenci bilgilerii başarıyla düzenlendi.");
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //Database ile program arasında bağlantıyı açıyoruz:
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select * from ogrenci where tcno LIKE'" + textBox1.Text.ToString() + "'", baglanti);
            OleDbDataReader okuyucu = komut.ExecuteReader();
            while (okuyucu.Read())
            {
                textBox2.Text = okuyucu["adi"].ToString();
                textBox3.Text = okuyucu["soyadi"].ToString();
                textBox4.Text = okuyucu["telefon"].ToString();
                textBox5.Text = okuyucu["adres"].ToString();
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
