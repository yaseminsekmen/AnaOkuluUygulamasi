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
    public partial class Sube : Form
    {
        public Sube()
        {
            InitializeComponent();
        }

        AnaOkuluDataContext baglanti = new AnaOkuluDataContext();
        public void Listele()
        {

            dataGridView1.DataSource = baglanti.Subelers.ToList();

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

        private void button1_Click(object sender, EventArgs e)
        {
            Listele();
        }
        public void Temizle()
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            textBox1.Text = "";
        }

        private void Sube_Load(object sender, EventArgs e)
        {
            comboBox3.DataSource = baglanti.Birimlers.ToList();
            comboBox3.ValueMember = "birim_id";
         //   comboBox3.DisplayMember = "BirimAdi";


            comboBox2.DataSource = baglanti.Cocuks.ToList();
            comboBox2.ValueMember = "cocuk_id";
          //  comboBox2.DisplayMember = "AdSoyad";

            comboBox1.DataSource = baglanti.Subelers.ToList();
            comboBox1.ValueMember = "sube_id";
            Temizle();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Subeler ekle = new Subeler();
            ekle.cocuk_id = Convert.ToInt32(comboBox2.SelectedValue);
            ekle.birim_id = Convert.ToInt32(comboBox3.SelectedValue);
          
            ekle.SubeAdi = textBox1.Text;

            baglanti.Subelers.InsertOnSubmit(ekle);
            baglanti.SubmitChanges();
            Listele();
            Temizle();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = (int)comboBox1.Tag;
            Subeler yenile = baglanti.Subelers.SingleOrDefault(y => y.sube_id == id);
            yenile.cocuk_id = Convert.ToInt32(comboBox2.SelectedValue);
            yenile.birim_id = Convert.ToInt32(comboBox3.SelectedValue);
            yenile.SubeAdi = textBox1.Text;

            baglanti.SubmitChanges();
            Listele();
            Temizle();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            comboBox1.Text = satir.Cells["sube_id"].Value.ToString();
            comboBox1.Tag = satir.Cells["sube_id"].Value;
            comboBox2.Text = satir.Cells["cocuk_id"].Value.ToString();
            comboBox3.Text = satir.Cells["birim_id"].Value.ToString();
        
            textBox1.Text = satir.Cells["SubeAdi"].Value.ToString();

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
