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
    public partial class kitapsil : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\kutuphanedatabase.accdb");

        public kitapsil()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("delete from kitap where barkodno='" + textBox1.Text + "'", baglanti);
            komut.ExecuteNonQuery();
            MessageBox.Show("Kitap başarıyla silindi.");
            baglanti.Close();
            textBox1.Clear();
        }
    }
}
