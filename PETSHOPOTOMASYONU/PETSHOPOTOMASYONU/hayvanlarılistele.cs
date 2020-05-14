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
    public partial class hayvanlarılistele : Form
    {
        public hayvanlarılistele()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection(@"Data Source=DESKTOP-OPLNUNQ;Initial Catalog=ecempetshop;Integrated Security=True");
        private void verilerigoster()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("select * from hayvandostlarimiz", baglan);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["HayvanNumarasi"].ToString();
                ekle.SubItems.Add(oku["HayvaninCinsi"].ToString());
                ekle.SubItems.Add(oku["HayvaninYasi"].ToString());
                ekle.SubItems.Add(oku["HayvaninRengi"].ToString());
                ekle.SubItems.Add(oku["HayvaninSatisFiyati"].ToString());
                ekle.SubItems.Add(oku["HayvaninAdedi"].ToString());
                listView1.Items.Add(ekle);
            }
            baglan.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            anamenu _h1 = new anamenu();
            _h1.Show();
            this.Hide();
        }

        private void hayvanlarılistele_Load(object sender, EventArgs e)
        {
            verilerigoster();
        }
    }
}
