using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Shop_Management_System
{
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
            DisplayCustomer();
        }
        readonly SqlConnection Con = new SqlConnection(connectionString: @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\User\Documents\Mobile MS.mdf"";Integrated Security=True;Connect Timeout=30");
        private void DisplayCustomer()
        {


            try
            {
                Con.Open();
                string Query = "SELECT * FROM CTBL;";
                SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
                SqlCommandBuilder sql = new SqlCommandBuilder(sda);
                var ds = new DataSet();
                sda.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                Con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Con.Close();
            }

        }
        private void AddBtn_Click(object sender, EventArgs e)
        {

            try
            {
                if (textBox1.Text == " " || textBox5.Text == " " || comboBox2.Text == " " || textBox2.Text == " " || textBox3.Text == " "|| textBox4.Text == " ")
                {
                    MessageBox.Show("Missing Info");
                }
                else
                {
                    Con.Open();
                    string Query = "INSERT INTO CTBL VALUES('" + textBox1.Text + "','" + textBox5.Text + "','" + comboBox2.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','"+ textBox4.Text+"')";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Record Entered Successfully");
                    DisplayCustomer();
                }
            }
            catch (Exception ex)
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
            home home = new home();
            home.Show();
            this.Hide();

        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox5.Text = " ";
            comboBox2.Text= " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            textBox4.Text = " ";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {

            try
            {
                if (textBox1.Text == " " || textBox5.Text == " " || comboBox2.Text == " " || textBox2.Text == " " || textBox3.Text == " "||textBox4.Text=="")
                {
                    MessageBox.Show("Missing Info");
                }
                else
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update CTBL set CName=@CN,Gender=@G,Address=@A, PurchasedMobile=@PM, Bill=@B WHERE CId=@Key", Con);
                    cmd.Parameters.AddWithValue("@CN", textBox5.Text);
                    cmd.Parameters.AddWithValue("@G", comboBox2.Text);
                    cmd.Parameters.AddWithValue("@A", textBox2.Text);

                    cmd.Parameters.AddWithValue("@PM", textBox3.Text);
                    cmd.Parameters.AddWithValue("@B", textBox4.Text);

                    cmd.Parameters.AddWithValue("@Key", textBox1.Text);
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Record Updated Successfully");
                    DisplayCustomer();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Con.Close();
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            comboBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
        }
    }
}
