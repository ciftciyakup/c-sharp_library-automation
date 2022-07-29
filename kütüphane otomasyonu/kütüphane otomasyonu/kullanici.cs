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
    public partial class kullanici : Form
    {
        //Veritabanı ile bağlantı kurmak için bağlantı kodumuz:
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\kutuphanedatabase.accdb");

        public kullanici()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Programı kapatma butonu için kodumuz:
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Eğer hem Kullanıcı adı TextBox'ı hem de Şifre TextBox'ı boş ise:
            if(textBox1.Text=="" && textBox2.Text=="")
            {
                MessageBox.Show("Lütfen giriş bilgilerinizi doldurun");
            }
            //Sadece Kullanıcı adı TextBox'ı boş ise:
            else if(textBox1.Text=="")
            {
                MessageBox.Show("Lütfen kullanıcı adını boş bırakmayın");
            }
            //Sadece Şifre TextBox'ı boş ise:
            else if(textBox2.Text=="")
            {
                MessageBox.Show("Lütfen şifreyi boş bırakmayın");
            }
            else
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from kullanicigirisi where kullaniciadi='" + textBox1.Text.ToString() + "'", baglanti);
                OleDbDataReader okuyucu = komut.ExecuteReader();
                if (okuyucu.Read()==true)
                {
                    if (textBox1.Text.ToString() == okuyucu["kullaniciadi"].ToString() && textBox2.Text.ToString() == okuyucu["sifre"].ToString())
                    {
                        //Kullanıcı adı ve Şifre doğru ise MessageBox ile ekrana "Hoşgeldin Sayın" kelimeleri ile beraber Database'den çekilen kullanıcının adı ve soyadı yazılır.
                        MessageBox.Show("Hoşgeldin Sayın " + okuyucu["adi"].ToString() + " " + okuyucu["soyadi"].ToString());
                        //anamenu Form'unu aynı isimde bir değişkene atadık.
                        Form anamenu = new anamenu();
                        //anamenu değişkenini göstermesini sağladık.
                        anamenu.Show();
                        //kullanıcıgirisi formunu gizlemesini sağladık.
                        this.Hide();
                    }
                    //Kullanıcı adı veya Şifre yanlış ise:
                    else
                    {
                        MessageBox.Show("Kullanıcı adı veya Şifre yanlıştır. Lütfen kontrol ediniz.");
                    }
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya Şifre yanlıştır. Lütfen kontrol ediniz.");
                }
                baglanti.Close();
            }
        }
    }
}
