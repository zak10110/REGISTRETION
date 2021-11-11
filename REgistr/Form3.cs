using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace REgistr
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (File.Exists($"{textBox1.Text}.txt"))
            {
                string pass = File.ReadAllText($"{textBox1.Text}.txt");


                if (pass == ComputeSha256Hash(textBox2.Text))
                {

                    MessageBox.Show("Ого!Мужик,Ты чего? Ты помнишь свой пароль? Молодец! ты Вошел в Систему");

                }
                else
                {

                    MessageBox.Show("Мужик Иди Вспоминай Логин ИЛИ ПАРОЛЬ,Емае!");


                }

            }
            else
            {

                MessageBox.Show("The is No Such User Go Fuck And LogIn");
                Form2 GGWP = new Form2();
                GGWP.Show();

            }

        }


        static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
