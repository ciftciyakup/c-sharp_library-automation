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
    public partial class kitapver : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\kutuphanedatabase.accdb");
        DataTable tablo = new DataTable();
        public kitapver()
        {
            InitializeComponent();
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

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            //Database ile program arasında bağlantıyı açıyoruz:
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select * from kitap where barkodno LIKE'" + textBox10.Text.ToString() + "'", baglanti);
            OleDbDataReader okuyucu = komut.ExecuteReader();
            while (okuyucu.Read())
            {
                textBox9.Text = okuyucu["kitapadi"].ToString();
                textBox8.Text = okuyucu["yazari"].ToString();
                textBox7.Text = okuyucu["sayfasayisi"].ToString();
                textBox6.Text = okuyucu["rafno"].ToString();
            }
            //Database ile program arasında bağlantıyı kapatıyoruz:
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("insert into kitapver (tcno,adi,soyadi,telefon,adres,barkodno,kitapadi,yazar,sayfasayisi,rafno,verilistarih,teslimtarih) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox10.Text + "','" + textBox9.Text + "','" + textBox8.Text + "','" + textBox7.Text + "','" + textBox6.Text + "','" + dateTimePicker1.Text + "','"+dateTimePicker2.Text+"')", baglanti);
            komut.ExecuteNonQuery();
            tablo.Clear();
            OleDbDataAdapter adaptr = new OleDbDataAdapter("select * from kitapver", baglanti);
            adaptr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            MessageBox.Show("Başarıyla kaydedildi.");
            baglanti.Close();
        }

        private void kitapver_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            tablo.Clear();
            OleDbDataAdapter adaptr = new OleDbDataAdapter("select * from kitapver", baglanti);
            adaptr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
        }
    }
}
