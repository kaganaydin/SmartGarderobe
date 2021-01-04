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
namespace SmartGarderobe
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Ace.OleDB.12.0;Data Source=database.accdb");
        OleDbCommand cmd;
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 FRM2 = new Form2();
            FRM2.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            con.Open();
            cmd = new OleDbCommand("insert into clothes(type,color,mark,thickness,durum) values('" + comboBox1.Text + "','" + comboBox2.Text + "','"+textBox1.Text+"','" + comboBox3.Text + "','" + "clean" + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Ekleme İşlemi Başarılı");
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
