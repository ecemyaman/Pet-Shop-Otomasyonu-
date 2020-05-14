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
    public partial class hayvanlarısil : Form
    {
        public hayvanlarısil()
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

        private void button3_Click(object sender, EventArgs e)
        {
            anamenu _h1 = new anamenu();
            _h1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("delete from hayvandostlarimiz where HayvanNumarasi=@HayvanNumarasi", baglan);
            komut.Parameters.AddWithValue("@HayvanNumarasi", textBox1.Text);
            komut.ExecuteNonQuery();
            verilerigoster("select * from hayvandostlarimiz");
            textBox1.Clear();
            baglan.Close();
        }

        private void hayvanlarısil_Load(object sender, EventArgs e)
        {

        }
    }

}
