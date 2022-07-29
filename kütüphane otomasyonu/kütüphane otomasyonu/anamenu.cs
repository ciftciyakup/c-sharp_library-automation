using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kütüphane_otomasyonu
{
    public partial class anamenu : Form
    {
        public anamenu()
        {
            InitializeComponent();
        }

        private void öğrenciToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ekleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ogrencie = new ogrenciekle();
            ogrencie.Show();
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ogrencis = new ogrencisil();
            ogrencis.Show();
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ogrencid = new ogrenciduzenle();
            ogrencid.Show();
        }

        private void anamenu_Load(object sender, EventArgs e)
        {

        }

        private void ekleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Formu açmak için:
            Form kitape = new kitapekle();
            kitape.Show();
        }

        private void silToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form kitaps = new kitapsil();
            kitaps.Show();
        }

        private void düzenleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form kitapd = new kitapduzenle();
            kitapd.Show();
        }

        private void listeleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form kitapl = new kitaplistele();
            kitapl.Show();
        }

        private void kitapVerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form kitapv = new kitapver();
            kitapv.Show();
        }

        private void listeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ogrencil = new ogrencilistele();
            ogrencil.Show();
        }

        private void geçKalanKitaplarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form geckitap = new geckalankitaplar();
            geckitap.Show();
        }
    }
}
