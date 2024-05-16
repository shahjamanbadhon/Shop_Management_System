﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shop_Management_System
{
    public partial class View : Form
    {
        public View()
        {
            InitializeComponent();
        }
        readonly SqlConnection Con = new SqlConnection(connectionString: @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\User\Documents\Mobile MS.mdf"";Integrated Security=True;Connect Timeout=30");
        private void FetchCus()
        {
            try
            {
                Con.Open();
                string query ="select * from CTBL WHERE CId = '" +textBox5.Text+"'";
                    SqlCommand Sql = new SqlCommand(query, Con);
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(Sql);
                sda.Fill(dt);
                foreach ( DataRow dr in dt.Rows)
                {
                    label14.Text = dr["CId"].ToString();
                    label13.Text = dr["CName"].ToString();
                    label12.Text = dr["Gender"].ToString();
                    label11.Text = dr["Address"].ToString();
                    label10.Text = dr["PurchasedMobile"].ToString();
                    label9.Text = dr["Bill"].ToString();
                    label14.Visible = true;
                    label13.Visible = true;
                    label12.Visible = true;
                    label11.Visible = true;
                    label10.Visible = true;
                    label9.Visible = true;

                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Con.Close();
            }




        }
        private void HomeBtn_Click(object sender, EventArgs e)
        {

            home obj = new home();
            obj.Show();
            this.Hide();
        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            FetchCus();
        }

        private void HomeBtn_Click_1(object sender, EventArgs e)
        {
            home home = new home();
            home.Show();
            this.Hide();
        }




        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {



            FetchCus();

            // Define the color for the document background
            Color backgroundColor = Color.LightYellow;

            // Calculate the size of the expanded rectangle
            float expandWidth = e.Graphics.VisibleClipBounds.Width + 2 * e.Graphics.DpiX;
            float expandHeight = e.Graphics.VisibleClipBounds.Height + 2 * e.Graphics.DpiY;

            // Fill the expanded area with the background color
            e.Graphics.FillRectangle(new SolidBrush(backgroundColor), -e.Graphics.DpiX, -e.Graphics.DpiY, expandWidth, expandHeight);

            // Title
            e.Graphics.DrawString("Medical Report", new Font("Century Gothic", 30, FontStyle.Bold), Brushes.Red, new Point(230, 20));

            // Patient Information
            e.Graphics.DrawString("Patient Information:", new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Black, new Point(50, 80));

            // Patient Name
            e.Graphics.DrawString("Customer ID:", new Font("Century Gothic", 14, FontStyle.Regular), Brushes.Black, new Point(50, 120));
            e.Graphics.DrawString(label14.Text, new Font("Century Gothic", 14, FontStyle.Regular), Brushes.DarkBlue, new Point(200, 120));

            // Symptoms
            e.Graphics.DrawString("Customer Name:", new Font("Century Gothic", 14, FontStyle.Regular), Brushes.Black, new Point(50, 160));
            e.Graphics.DrawString(label13.Text, new Font("Century Gothic", 14, FontStyle.Regular), Brushes.DarkBlue, new Point(200, 160));

            // Diagnosis
            e.Graphics.DrawString("Gender:", new Font("Century Gothic", 14, FontStyle.Regular), Brushes.Black, new Point(50, 200));
            e.Graphics.DrawString(label12.Text, new Font("Century Gothic", 14, FontStyle.Regular), Brushes.DarkBlue, new Point(200, 200));

            // Medicine
            e.Graphics.DrawString("Address:", new Font("Century Gothic", 14, FontStyle.Regular), Brushes.Black, new Point(50, 240));
            e.Graphics.DrawString(label11.Text, new Font("Century Gothic", 14, FontStyle.Regular), Brushes.DarkBlue, new Point(200, 240));

            // Date
            e.Graphics.DrawString("Purches Mobile:", new Font("Century Gothic", 14, FontStyle.Regular), Brushes.Black, new Point(50, 280));
            e.Graphics.DrawString(label10.Text, new Font("Century Gothic", 14, FontStyle.Regular), Brushes.DarkBlue, new Point(200, 280));

            // Doctor Name
            e.Graphics.DrawString("Bill:", new Font("Century Gothic", 14, FontStyle.Regular), Brushes.Black, new Point(50, 320));
            e.Graphics.DrawString(label14.Text, new Font("Century Gothic", 14, FontStyle.Regular), Brushes.DarkBlue, new Point(200, 320));

            /*   string summary = txtSymptoms.Text + "\n" +
                         txtDiagmosis.Text + "\n" +
                         txtMedicine.Text;

               e.Graphics.DrawString(summary, new Font("Century Gothic", 12, FontStyle.Regular), Brushes.Black, new Point(100, 100));
            */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {
            //  e.Graphics.DrawString(txtSummery.Text + lvl1.Text + lvl2.Text + lvl3.Text + lvl4.Text, new Font("Century Gothic", 12, FontStyle.Regular), Brushes.Black, new Point(130));
        }
    }
}
