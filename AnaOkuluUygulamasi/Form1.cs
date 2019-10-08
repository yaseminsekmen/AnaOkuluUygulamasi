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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Cocuklar git = new Cocuklar();
            git.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Cocuklar git = new Cocuklar();
            git.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Hoca git = new Hoca();
            git.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Hoca git = new Hoca();
            git.Show();
            this.Hide();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Birim git = new Birim();
            git.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Sube git = new Sube();
            git.Show();
            this.Hide();
        }
    }
}
