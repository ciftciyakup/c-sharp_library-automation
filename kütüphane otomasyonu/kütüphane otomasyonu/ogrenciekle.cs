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
    public partial class ogrenciekle : Form
    {

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+Application.StartupPath+"\\kutuphanedatabase.accdb");
        public ogrenciekle()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("insert into ogrenci (tcno,adi,soyadi,telefon,adres) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')", baglanti);
            komut.ExecuteNonQuery();
            MessageBox.Show("Öğrenci başarıyla kaydedildi.");
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }
    }
}
