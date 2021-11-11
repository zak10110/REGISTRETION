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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!File.Exists($"{textBox1.Text}.txt"))
            {
                if (textBox1.Text.Length >= 5 && textBox1.Text.Length <= 12)
                {

                    File.Create($"{textBox1.Text}.txt").Close();
                    if (textBox2.Text.Length > 5 && textBox2.Text.Length <= 15)
                    {
                        File.WriteAllText($"{textBox1.Text}.txt", $"{ComputeSha256Hash(textBox2.Text)}");
                    }
                    else
                    {
                        MessageBox.Show("Ты Дура ! Нужно Больше Символов Для Пароля,Порпробуй ЕЩЕ");
                    }
                }
                else
                {
                    MessageBox.Show("Ты Дура ! Нужно Больше Символов В Логине,Порпробуй ЕЩЕ");
                }
            }
            else
            {
                MessageBox.Show("Ты Дура ! Такой пользователь Уже есть!");
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
