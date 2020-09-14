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


namespace Emlak_Uygulaması
{
    public partial class Musteri_kayit : Form
    {
        public Musteri_kayit()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=TOSHIBA\\SQLEXPRESS;Initial Catalog=emlak3;Integrated Security=True");
        private void verilerigöster()
        {

            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select *From musteri_tablo", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem kaydet = new ListViewItem();
                kaydet.Text = oku["emlak_id"].ToString();
                kaydet.SubItems.Add(oku["ad"].ToString());
                kaydet.SubItems.Add(oku["soyad"].ToString());
                kaydet.SubItems.Add(oku["tc_no"].ToString());
                kaydet.SubItems.Add(oku["cep_no"].ToString());
                kaydet.SubItems.Add(oku["mail"].ToString());
                kaydet.SubItems.Add(oku["durumu"].ToString());

                listView1.Items.Add(kaydet);
            }
            baglanti.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kayit_Paneli kayit = new Kayit_Paneli();
            kayit.Show();
            this.Hide();
        }

        private void kaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into musteri_tablo(emlak_id,ad,soyad,tc_no,cep_no,mail,durumu) values ('" + textBox1.Text.ToString() + "','" + textBox9.Text.ToString() + "','" + textBox10.Text.ToString() + "','" + textBox11.Text.ToString() + "','" + textBox12.Text.ToString() + "','" + textBox13.Text.ToString() + "','" + comboBox1.Text.ToString() + "')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            verilerigöster();
        }

        private void listele_Click(object sender, EventArgs e)
        {
            verilerigöster();
        }
        int emlak_id = 0;

        private void sil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Delete from musteri_tablo where emlak_id =(" + emlak_id + ")", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            verilerigöster();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            emlak_id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textBox9.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox10.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textBox11.Text = listView1.SelectedItems[0].SubItems[3].Text;
            textBox12.Text = listView1.SelectedItems[0].SubItems[4].Text;
            textBox13.Text = listView1.SelectedItems[0].SubItems[5].Text;
            comboBox1.Text = listView1.SelectedItems[0].SubItems[6].Text;
        }

        private void güncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update musteri_tablo set emlak_id ='" + textBox1.Text.ToString() + "',ad ='" + textBox9.Text.ToString() + "',soyad ='" + textBox10.Text.ToString() + "',tc_no ='" + textBox11.Text.ToString() + "',cep_no ='" + textBox12.Text.ToString() + "',mail ='" + textBox13.Text.ToString() + "',durumu ='" + comboBox1.Text.ToString() + "'where emlak_id =" + emlak_id + "", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            verilerigöster();
        }

        private void Musteri_kayit_Load(object sender, EventArgs e)
        {

        }
    }
}
