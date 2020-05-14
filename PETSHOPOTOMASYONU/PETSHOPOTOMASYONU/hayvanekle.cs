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
    public partial class hayvanekle : Form
    {
        public hayvanekle()
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
            baglan.Open();
            SqlCommand komut = new SqlCommand("insert into hayvandostlarimiz (HayvanNumarasi,HayvaninCinsi,HayvaninYasi,HayvaninRengi,HayvaninSatisFiyati,HayvaninAdedi) values (@HayvanNumarasi,@HayvaninCinsi,@HayvaninYasi,@HayvaninRengi,@HayvaninSatisFiyati,@HayvaninAdedi)", baglan);
            komut.Parameters.AddWithValue("@HayvanNumarasi", textBox1.Text);
            komut.Parameters.AddWithValue("@HayvaninCinsi", textBox2.Text);
            komut.Parameters.AddWithValue("@HayvaninYasi", textBox3.Text);
            komut.Parameters.AddWithValue("@HayvaninRengi", textBox4.Text);
            komut.Parameters.AddWithValue("@HayvaninSatisFiyati", textBox5.Text);
            komut.Parameters.AddWithValue("@HayvaninAdedi", textBox6.Text);
            komut.ExecuteNonQuery();
            verilerigoster("select * from hayvandostlarimiz");
            baglan.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            anamenu _h1 = new anamenu();
            _h1.Show();
            this.Hide();
        }
    }
}
