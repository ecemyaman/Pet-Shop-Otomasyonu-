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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection(@"Data Source=DESKTOP-OPLNUNQ;Initial Catalog=ecempetshop;Integrated Security=True");
        
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();
            string giris = "Select *From parola where kullaniciadi=@kadi AND sifre=@sifre";
            SqlParameter pmr1 = new SqlParameter("kadi", textBox1.Text.Trim());
            SqlParameter pmr2 = new SqlParameter("sifre", textBox2.Text.Trim());
            SqlCommand komut = new SqlCommand(giris, baglan);
            komut.Parameters.Add(pmr1);
            komut.Parameters.Add(pmr2);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                anamenu _a1 = new anamenu();
                _a1.Show();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı/Şifre Tekrar Deneyin");
            }
            baglan.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
