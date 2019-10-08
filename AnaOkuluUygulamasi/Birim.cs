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
    public partial class Birim : Form
    {
        public Birim()
        {
            InitializeComponent();
        }
        AnaOkuluDataContext baglanti = new AnaOkuluDataContext();
        private void Birim_Load(object sender, EventArgs e)
        {
            comboBox3.DataSource = baglanti.Birimlers.ToList();
            comboBox3.ValueMember = "birim_id";

        }

        public void Listele()
        {

            dataGridView1.DataSource = baglanti.Birimlers.ToList();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            comboBox3.Text = satir.Cells["birim_id"].Value.ToString();
            comboBox3.Tag = satir.Cells["birim_id"].Value;
            textBox1.Text = satir.Cells["BirimAdi"].Value.ToString();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = (int)comboBox3.Tag;
            Birimler yenile = baglanti.Birimlers.SingleOrDefault(y => y.birim_id == id);
            yenile.BirimAdi = textBox1.Text;

            baglanti.SubmitChanges();
            Listele();
          
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

        private void button8_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(comboBox3.Text);
            var arama = baglanti.Birimlers.Where(p => p.birim_id == id);
            dataGridView1.DataSource = arama.ToList();
        }
    }
}
