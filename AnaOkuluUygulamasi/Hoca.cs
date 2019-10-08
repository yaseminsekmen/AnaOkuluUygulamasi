using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnaOkuluUygulamasi
{
    public partial class Hoca : Form
    {
        public Hoca()
        {
            InitializeComponent();
        }
        AnaOkuluDataContext baglanti = new AnaOkuluDataContext();

        public void Temizle()
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
            comboBox6.Text = "";
            textBox1.Text = "";
          
        }
        public void Listele()
        {

            dataGridView1.DataSource = baglanti.Hocalars.ToList();

        }

        private void Hoca_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = baglanti.Hocalars.ToList();
            comboBox1.ValueMember = "hoca_id";

            comboBox2.DataSource = baglanti.Cocuks.ToList();
            comboBox2.ValueMember = "cocuk_id";
            comboBox2.DisplayMember = "AdSoyad";

            comboBox3.DataSource = baglanti.Birimlers.ToList();
            comboBox3.ValueMember = "birim_id";
            comboBox3.DisplayMember = "BirimAdi";

            comboBox4.DataSource = baglanti.Gorevlendirmes.ToList();
            comboBox4.ValueMember = "görev_id";
            comboBox4.DisplayMember = "GorevAdi";

            comboBox5.DataSource = baglanti.Subelers.ToList();
            comboBox5.ValueMember = "sube_id";
            comboBox5.DisplayMember = "SubeAdi";

            comboBox6.DataSource = baglanti.Projelers.ToList();
            comboBox6.ValueMember = "proje_id";
            comboBox6.DisplayMember = "ProjeAdi";

            Temizle();


            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 git = new Form1();
            git.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hocalar ekle = new Hocalar();
            ekle.cocuk_id = Convert.ToInt32(comboBox2.SelectedValue);
            ekle.birim_id = Convert.ToInt32(comboBox3.SelectedValue);
            ekle.görev_id = Convert.ToInt32(comboBox4.SelectedValue);
            ekle.sube_id = Convert.ToInt32(comboBox5.SelectedValue);
            ekle.proje_id = Convert.ToInt32(comboBox6.SelectedValue);
            ekle.AdSoyad = textBox1.Text;
          
            baglanti.Hocalars.InsertOnSubmit(ekle);
            baglanti.SubmitChanges();
            Listele();
            Temizle();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewRow satir = dataGridView1.CurrentRow;
            comboBox1.Text = satir.Cells["hoca_id"].Value.ToString();
            comboBox1.Tag = satir.Cells["hoca_id"].Value;
            comboBox2.Text = satir.Cells["cocuk_id"].Value.ToString();
            comboBox3.Text = satir.Cells["birim_id"].Value.ToString();
            comboBox4.Text = satir.Cells["görev_id"].Value.ToString();
            comboBox5.Text = satir.Cells["sube_id"].Value.ToString();
            comboBox6.Text = satir.Cells["proje_id"].Value.ToString();
            textBox1.Text = satir.Cells["AdSoyad"].Value.ToString();



        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = (int)comboBox1.Tag;
            Hocalar sil = baglanti.Hocalars.SingleOrDefault(kaybol => kaybol.hoca_id == id);
            baglanti.Hocalars.DeleteOnSubmit(sil);
            baglanti.SubmitChanges();
            Listele();
            Temizle();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            int id = (int)comboBox1.Tag;
            Hocalar yenile = baglanti.Hocalars.SingleOrDefault(y => y.hoca_id == id);
            yenile.cocuk_id = Convert.ToInt32(comboBox2.SelectedValue);
            yenile.birim_id = Convert.ToInt32(comboBox3.SelectedValue);
            yenile.görev_id = Convert.ToInt32(comboBox4.SelectedValue);
            yenile.sube_id = Convert.ToInt32(comboBox5.SelectedValue);
            yenile.proje_id = Convert.ToInt32(comboBox6.SelectedValue);
            yenile.AdSoyad = textBox1.Text;

            baglanti.SubmitChanges();
            Listele();
            Temizle();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(comboBox1.Text);
            var arama = baglanti.Hocalars.Where(p => p.hoca_id == id);
            dataGridView1.DataSource = arama.ToList();
        }
    }
}
