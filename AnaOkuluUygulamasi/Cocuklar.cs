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
    public partial class Cocuklar : Form
    {
        public Cocuklar()
        {
            InitializeComponent();
        }
        AnaOkuluDataContext baglanti = new AnaOkuluDataContext();

        public void Listele()
        {

            dataGridView1.DataSource = baglanti.Cocuks.ToList();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        public void Temizle()
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 git = new Form1();
            git.Show();
            this.Hide();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            comboBox1.Text = satir.Cells["cocuk_id"].Value.ToString();
            comboBox1.Tag = satir.Cells["cocuk_id"].Value;
            textBox1.Text = satir.Cells["Tc"].Value.ToString();
            textBox2.Text = satir.Cells["AdSoyad"].Value.ToString();
            comboBox2.Text = satir.Cells["Yas"].Value.ToString();
            comboBox3.Text = satir.Cells["Cinsiyet"].Value.ToString();
          
        }

        private void Cocuklar_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = baglanti.Cocuks.ToList();
            comboBox1.ValueMember = "cocuk_id";
            comboBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cocuk ekle = new Cocuk();
            ekle.Tc = textBox1.Text;
            ekle.AdSoyad = textBox2.Text;
            ekle.Yas = Convert.ToInt32(comboBox2.SelectedItem.ToString());
            ekle.Cinsiyet = comboBox3.SelectedItem.ToString();
            baglanti.Cocuks.InsertOnSubmit(ekle);
            baglanti.SubmitChanges();
            Listele();
            Temizle();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = (int)comboBox1.Tag;
            Cocuk sil = baglanti.Cocuks.SingleOrDefault(kaybol => kaybol.cocuk_id == id);
            baglanti.Cocuks.DeleteOnSubmit(sil);
            baglanti.SubmitChanges();
            Listele();
            Temizle();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = (int)comboBox1.Tag;
            Cocuk yenile = baglanti.Cocuks.SingleOrDefault(y => y.cocuk_id == id);
            yenile.Tc = textBox1.Text;
            yenile.AdSoyad = textBox2.Text;
            yenile.Yas = Convert.ToInt32(comboBox2.SelectedItem.ToString());
            yenile.Cinsiyet = comboBox3.SelectedItem.ToString();

            baglanti.SubmitChanges();
            Listele();
            Temizle();

        }

        private void button8_Click(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(comboBox1.Text);
            var arama = baglanti.Cocuks.Where(p =>p.cocuk_id == id);
            dataGridView1.DataSource = arama.ToList();

        }
    }
}
