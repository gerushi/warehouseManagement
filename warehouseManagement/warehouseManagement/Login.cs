using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace warehouseManagement
{
    public partial class Login : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=warehouseuserinfo");
        MySqlCommand command;
        MySqlDataReader mdr;
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string adminUser = "admin";
            string adminPass = "test123";

            string username = textBox1.Text;
            string password = textBox2.Text;

            connection.Open();
            string query = "SELECT password FROM users WHERE username = @username";
            command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@username", username);

            mdr = command.ExecuteReader();
            try
            {
                

                if (mdr.Read())
                {
                    string dbPasswordHash = mdr["password"].ToString();


                    if (VerifyPassword(password, dbPasswordHash))
                    {
                        // NAG LOG IN NA GUYS!!
                        if (username == adminUser && password == adminPass)
                        {
                            // show admin
                            this.Hide();
                            Admin adminPanel = new Admin();
                            adminPanel.Show();
                        }
                        else
                        {
                            // show customre apnel
                            this.Hide();
                            CustomerPanel customerPanel = new CustomerPanel();
                            customerPanel.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Wrong password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Username does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (mdr != null)
                    mdr.Close();
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Register reg = new Register();
            reg.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // show password magic
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = '\0'; // show password
            }
            else
            {
                textBox2.PasswordChar = '*'; // hide WOW
            }
        }

        private bool VerifyPassword(string enteredPassword, string storedPassword)
        {
            return enteredPassword == storedPassword;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.Icon = null;
            this.BackgroundImageLayout = ImageLayout.Stretch; //stretches background image

            //makes background colors transparent on labels, images, and etc.
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            pictureBox1.BackColor = Color.Transparent;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox3.BackColor = Color.Transparent;  
            checkBox1.BackColor = Color.Transparent;
            linkLabel1.BackColor = Color.Transparent;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
