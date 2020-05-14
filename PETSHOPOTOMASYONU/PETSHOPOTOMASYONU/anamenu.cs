using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PETSHOPOTOMASYONU
{
    public partial class anamenu : Form
    {
        public anamenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hayvanekle _h1 = new hayvanekle();
            _h1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            hayvanlarılistele _h2 = new hayvanlarılistele();
            _h2.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            hayvanlarıdüzenle _h3 = new hayvanlarıdüzenle();
            _h3.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            hayvanlarısil _h4 = new hayvanlarısil();
            _h4.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            satısislemi _s1 = new satısislemi();
            _s1.Show();
            this.Hide();
        }
    }
}
