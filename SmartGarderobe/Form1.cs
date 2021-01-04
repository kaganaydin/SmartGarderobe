using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartGarderobe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string şifre = textBox1.Text;
            if (şifre == "123")
            {
                Form2 frm = new Form2();
                MessageBox.Show("Hoşgeldiniz", "Akıllı Gardolap Sistemi");
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Şifre Doğru Değil!");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu proje Eren Kağan AYDIN Tarafından İleri Nesne Tabanlı Programlama dersi öğretmeni Mahmut Sami DÖVEN için Geliştirilmiştir.");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.PasswordChar = '*';
            this.AcceptButton = this.button1;
        }
    }
}
