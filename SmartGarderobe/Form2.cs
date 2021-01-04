using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Xml;
using System.Xml.Linq;

namespace SmartGarderobe
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private const string api = "30f976b553e840654ec47bdc791279c0";
        private const string baglantim = "http://api.openweathermap.org/data/2.5/weather?q=Turkey,Samsun&mode=xml&units=metric&APPID=" + api;
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Ace.OleDB.12.0;Data Source=database.accdb");
        
       
        DataTable tablo = new DataTable();
        DataTable tablo2 = new DataTable();
        DataTable tablo3 = new DataTable();
        DataTable tablo4 = new DataTable();
        DataTable tablo5 = new DataTable();
        DataTable tablo6 = new DataTable();
        DataTable tablo7 = new DataTable();
        OleDbCommand cmd;

        string kontrol = "";


        private void whatShoultIDressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
        }

        private void whatsİnMyWardrobeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel1.Visible = false;
            panel3.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 FRM3 = new Form3();
            FRM3.Show();
            this.Hide();

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           
            listele();
            listele2();
            listele3();
            listele4();
            listele5();
            listele6();
            listele7();
            //hava durumu api çekek
            XDocument hava = XDocument.Load(baglantim);
            var sicaklik = hava.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            label_derece.Text = sicaklik.ToString() + "°";
            var durum = hava.Descendants("clouds").ElementAt(0).Attribute("name").Value;
            label_durum.Text = durum.ToString();
            if (durum.Contains("clouds") == true)
            {
                picture_bulutlu.Visible = true;
            }
            else if (durum.Contains("sun") == true)
            {
                picture_bulutlu.Visible = false;
                picture_gunesli.Visible = true;
            }


            // tabloları ingilizce ettik ya başlıkları türkçe çekek
            dataGridView3.Columns[1].HeaderText = "Markası";
            dataGridView3.Columns[2].HeaderText = "Tipi";
            dataGridView3.Columns[3].HeaderText = "Rengi";
            dataGridView2.Columns[1].HeaderText = "Markası";
            dataGridView2.Columns[2].HeaderText = "Tipi";
            dataGridView2.Columns[3].HeaderText = "Rengi";
            dataGridView1.Columns[1].HeaderText = "Markası";
            dataGridView1.Columns[2].HeaderText = "Tipi";
            dataGridView1.Columns[3].HeaderText = "Rengi";
            //
            dataGridView6.Columns[1].HeaderText = "Markası";
            dataGridView6.Columns[2].HeaderText = "Tipi";
            dataGridView6.Columns[3].HeaderText = "Rengi";
            dataGridView5.Columns[1].HeaderText = "Markası";
            dataGridView5.Columns[2].HeaderText = "Tipi";
            dataGridView5.Columns[3].HeaderText = "Rengi";
            dataGridView4.Columns[1].HeaderText = "Markası";
            dataGridView4.Columns[2].HeaderText = "Tipi";
            dataGridView4.Columns[3].HeaderText = "Rengi";

            dataGridView7.Columns[1].HeaderText = "Markası";
            dataGridView7.Columns[2].HeaderText = "Tipi";
            dataGridView7.Columns[3].HeaderText = "Rengi";
        }
        void listele7()
        {
            
            tablo7.Clear();
            listeleAll("durum", "clean", tablo7, dataGridView7);


        }
        void listele6()
        {
          
     
            tablo6.Clear();
            listeleAll("durum", "ironed", tablo6, dataGridView1);


        }
        void listele5()
        {
          
            tablo5.Clear();
            listeleAll("durum", "dirty", tablo5, dataGridView2);

        }
        void listeleAll(String s1, String cond, DataTable dt, DataGridView grd)
        {
            OleDbDataAdapter adtr4 = new OleDbDataAdapter
          ("select * from clothes where "+s1+"= '" + cond + "'", con);
            adtr4.Fill(dt);
            grd.DataSource = dt;

            grd.Columns[0].Visible = false;

            grd.Columns[4].Visible = false;

            grd.Columns[2].Width = 60;
            grd.Columns[3].Width = 70;
            grd.Columns[1].Width = 60;
        }
        void listele4()
        {
           
          
            tablo4.Clear();
            listeleAll("durum", "clean", tablo4, dataGridView3);
        }
        void listele()
        {

            tablo2.Clear();
            listeleAll("type", "Ceketler", tablo2, dataGridView6);
            //Ceketler
        }
        void listele2()
        {

          
           
            
            tablo.Clear();
            listeleAll("type", "Pantolonlar", tablo, dataGridView5);
        }
        void listele3()
        {        
          
            listeleAll("type", "Paltolar", tablo3, dataGridView4);
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
        }

        private void dataGridView7_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView7.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView7.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView7.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView7.CurrentRow.Cells[4].Value.ToString();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            con.Open();
            cmd = new OleDbCommand("update clothes set durum='" + "dirty" + "'where mark='" + textBox1.Text + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            tablo7.Clear();
            listele();
            listele2();
            listele3();
            listele4();
            listele5();
            listele6();
            listele7();

            listBox1.Items.Add(textBox1.Text + " " + textBox2.Text + " " + textBox3.Text + " " + textBox4.Text);
            int derece = int.Parse(label_derece.Text.Substring(0,1));
            if (textBox4.Text=="Normal")
            {
                if (derece>10 || derece<25)
                {
                    MessageBox.Show("İyi Karar Giyim İçin!");

                }
                else
                {
                    MessageBox.Show("Umarım Böyle Dışarı Çıkmazsın!");
                }
               
            }
            else if (textBox4.Text=="İnce")
            {
                if (derece > 15)
                {
                    MessageBox.Show("İyi Karar Giyim İçin!");

                }
                else
                {
                    MessageBox.Show("Umarım Böyle Dışarı Çıkmazsın! Doncan Doncan ! Zatüre Olcan !");
                }
              
            }
            else if(textBox4.Text=="Kalın")
            {

                if (derece > 10)
                {
                    
                    MessageBox.Show("Umarım Böyle Dışarı Çıkmazsın Yanacan sıcakdan!");
                }
                else
                {
                    MessageBox.Show("İyi Karar Giyim İçin!");
                }
            }
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new OleDbCommand("update clothes set durum='" + "clean" + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Temizletme İşlemi Başarılı !");
            listele();
            listele2();
            listele3();
            listele4();
            listele5();
            listele6();
            listele7();
        }

      

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

       

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                kontrol = dataGridView3.CurrentRow.Cells[1].Value.ToString();
            }
            catch 
            {

                ;
            }
         
        }

        private void button6_Click_1(object sender, EventArgs e)
        {

            con.Open();
            cmd = new OleDbCommand("update clothes set durum='" + "ironed" + "'where mark='" + kontrol + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            tablo7.Clear();
            listele();
            listele2();
            listele3();
            listele4();
            listele5();
            listele6();
            listele7();
            MessageBox.Show("Başarılı !");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://ramazanakbuz.com/category/soft/");
        }
    }
}
