using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PETSHOPOTOMASYONU
{
    public partial class hayvanlarıdüzenle : Form
    {
        public hayvanlarıdüzenle()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection(@"Data Source=DESKTOP-OPLNUNQ;Initial Catalog=ecempetshop;Integrated Security=True");
        public void verilerigoster(string veriler)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler, baglan);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

        }

        private void button1_Click(object sender, EventArgs e)
        {
            verilerigoster("select * from hayvandostlarimiz");
        }

        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilialan = dataGridView1.SelectedCells[0].RowIndex;
            string HayvanNumarasi = dataGridView1.Rows[secilialan].Cells[0].Value.ToString();
            string HayvaninCinsi = dataGridView1.Rows[secilialan].Cells[1].Value.ToString();
            string HayvaninYasi = dataGridView1.Rows[secilialan].Cells[2].Value.ToString();
            string HayvaninRengi = dataGridView1.Rows[secilialan].Cells[3].Value.ToString();
            string HayvaninSatisFiyati = dataGridView1.Rows[secilialan].Cells[4].Value.ToString();
            string HayvaninAdedi = dataGridView1.Rows[secilialan].Cells[5].Value.ToString();
            textBox1.Text = HayvanNumarasi;
            textBox2.Text = HayvaninCinsi;
            textBox3.Text = HayvaninYasi;
            textBox4.Text = HayvaninRengi;
            textBox5.Text = HayvaninSatisFiyati;
            textBox6.Text = HayvaninAdedi;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            anamenu _h1 = new anamenu();
            _h1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("update hayvandostlarimiz set HayvanNumarasi='" + textBox1.Text + "', HayvaninYasi='" + textBox3.Text + "',HayvaninRengi='" + textBox4.Text + "',HayvaninSatisFiyati='" + textBox5.Text + "',HayvaninAdedi='" + textBox6.Text + "' where HayvaninCinsi='" + textBox2.Text + "'", baglan);
            komut.ExecuteNonQuery();
            verilerigoster("select * from hayvandostlarimiz");
            baglan.Close();
        }


    }
}
