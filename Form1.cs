﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shop_Management_System
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            richTextBox2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(richTextBox1.Text ==" " && richTextBox2.Text =="")
                {
                    MessageBox.Show("Missing Information");
                }
                else if(richTextBox1.Text =="Admin" && richTextBox2.Text == "Password")
                {
                    home Home = new home();
                    Home.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Please Enter the correct password and username");
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
