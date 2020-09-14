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
    public partial class Kayit_Paneli : Form
    {
        public Kayit_Paneli()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=TOSHIBA\\SQLEXPRESS;Initial Catalog=emlak3;Integrated Security=True");
        private void verilerigöster()
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select *From emlak_tablo ", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            
            
            while (oku.Read())
            {
                 ListViewItem kaydet = new ListViewItem();
                 kaydet.Text = oku["emlak_id"].ToString();
                 kaydet.SubItems.Add(oku["durum"].ToString());
                 kaydet.SubItems.Add(oku["metre_kare"].ToString());
                 kaydet.SubItems.Add(oku["oda_sayisi"].ToString());
                 kaydet.SubItems.Add(oku["bina_yasi"].ToString());
                 kaydet.SubItems.Add(oku["bulundugu_kat"].ToString());
                 kaydet.SubItems.Add(oku["kat_no"].ToString());
                 kaydet.SubItems.Add(oku["fiyat"].ToString());
                 listView1.Items.Add(kaydet); 
               
            }
            baglanti.Close();
        }
        private void Btnlist_Click(object sender, EventArgs e)
        {
            verilerigöster();
        }
        private void Btnkayıt_Click(object sender, EventArgs e)
            {
            
           
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into emlak_tablo(emlak_id,durum,metre_kare,oda_sayisi,bina_yasi,bulundugu_kat,kat_no,fiyat) values ('" + textBox1.Text.ToString() + "','" + comboBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + comboBox2.Text.ToString() + "','" + comboBox3.Text.ToString() + "','" + comboBox4.Text.ToString() + "','" + comboBox5.Text.ToString() + "','" + textBox3.Text.ToString() + "')", baglanti);
            komut.ExecuteNonQuery();
            
            baglanti.Close();
            verilerigöster();
           /* baglanti.Open();
            SqlCommand komut1 = new SqlCommand("insert into emlak_durum(durum)values('" + comboBox1.Text.ToString() + "')", baglanti);
            komut1.ExecuteNonQuery();
            baglanti.Close();
            verilerigöster(); */

        }
        int emlak_id = 0;
        private void Btnsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();          
            SqlCommand komut = new SqlCommand("Delete from emlak_tablo where emlak_id =(" + emlak_id +")" , baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            verilerigöster();


        }

        

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            emlak_id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
            comboBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[2].Text;
            comboBox2.Text = listView1.SelectedItems[0].SubItems[3].Text;
            comboBox3.Text = listView1.SelectedItems[0].SubItems[4].Text;
            comboBox4.Text = listView1.SelectedItems[0].SubItems[5].Text;
            comboBox5.Text = listView1.SelectedItems[0].SubItems[6].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[7].Text;


        }

        private void Btngüncel_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            

            SqlCommand komut = new SqlCommand("update emlak_tablo set emlak_id ='" + textBox1.Text.ToString()  + "',durum ='" + comboBox1.Text.ToString()+ "',metre_kare ='" + textBox2.Text.ToString() + "',oda_sayisi ='" + comboBox2.Text.ToString() + "',bina_yasi ='" + comboBox3.Text.ToString() + "',bulundugu_kat ='" + comboBox4.Text.ToString() + "',kat_no ='" + comboBox5.Text.ToString() + "',fiyat ='" + textBox3.Text.ToString() + "'where emlak_id =" + emlak_id + "", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            verilerigöster();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Musteri_kayit kayit = new Musteri_kayit();
            kayit.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Adres_kayit kayit = new Adres_kayit();
            kayit.Show();
            this.Hide();
        }

        private void Kayit_Paneli_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Musterim_tablosu kayit = new Musterim_tablosu();
            kayit.Show();
            this.Hide();
        }

        /*private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            emlak_id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
            comboBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[2].Text;
            comboBox2.Text = listView1.SelectedItems[0].SubItems[3].Text;
            comboBox3.Text = listView1.SelectedItems[0].SubItems[4].Text;
            comboBox4.Text = listView1.SelectedItems[0].SubItems[5].Text;
            comboBox5.Text = listView1.SelectedItems[0].SubItems[6].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[7].Text;
        }*/
    }
    }

