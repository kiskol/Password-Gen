using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace Password_Gen
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        







        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            int length = 0;
            if (!int.TryParse(metroTextBox2.Text, out length))
            {
                MessageBox.Show("Minimum length 5");
                return;
            }
            if (length > 50)
            {
                MessageBox.Show("Maximum length is 50 characters");
                return;
            }


            string characters = "";
            if (metroCheckBox3.Checked)
            {
                characters += "abcdefghijklmnopqrstuvwxyz";
            }

            if (metroCheckBox2.Checked)
            {
                characters += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            }

            if (metroCheckBox1.Checked) 
            {
                characters += "0123456789";
            }

            if (metroCheckBox4.Checked)
            {
                characters += "!@#$%^&*()_+";
            }
                
        

            string password = "";
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                password += characters[random.Next(characters.Length)];
            }


            metroTextBox1.Text = password;

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(metroTextBox1.Text);
            MessageBox.Show("Copied Password" + " - " + metroTextBox1.Text);
            string password = metroTextBox1.Text;
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            string password = metroTextBox1.Text;

            File.AppendAllText("password.txt", password + Environment.NewLine);

            MessageBox.Show("Password Saved to password.txt");


        }
    }
}
