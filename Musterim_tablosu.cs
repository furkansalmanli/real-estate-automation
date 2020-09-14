using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Emlak_Uygulaması
{
    public partial class Musterim_tablosu : Form
    {
        public Musterim_tablosu()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=TOSHIBA\\SQLEXPRESS;Initial Catalog=emlak3;Integrated Security=True");

        private void Musterim_tablosu_Load(object sender, EventArgs e)
        {

            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select *From emlak_tablo,adres_tablo where emlak_tablo.emlak_id = adres_tablo.emlak_id", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Kayit_Paneli kayit = new Kayit_Paneli();
            kayit.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            iletisim kayit = new iletisim();
            kayit.Show();
            this.Hide();
        }
    }
    }
    

