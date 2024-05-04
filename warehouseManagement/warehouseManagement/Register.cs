using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace warehouseManagement
{
    public partial class Register : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        

        public Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }       

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private bool CreateAccount(String username, string password)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=warehouseuserinfo"))
                {
                    connection.Open();

                    // check if the username already exists
                    string checkQuery = "SELECT COUNT(*) FROM users WHERE username = @username";
                    MySqlCommand checkCommand = new MySqlCommand(checkQuery, connection);
                    checkCommand.Parameters.AddWithValue("@username", username);

                    int usernameCount = Convert.ToInt32(checkCommand.ExecuteScalar());

                    if (usernameCount > 0)
                    {
                        MessageBox.Show("Username already exists.", "Error");
                        return false;
                    }

                    // insert the user into the database
                    string insertQuery = "INSERT INTO users (username, password) VALUES (@username, @password)";
                    MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection);
                    insertCommand.Parameters.AddWithValue("@username", username);
                    insertCommand.Parameters.AddWithValue("@password", password);

                    int rowsAffected = insertCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        this.Hide();
                        Login log = new Login();
                        log.Show();
                        MessageBox.Show("Account created successfully.", "Success");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Failed to create account.", "Error");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                // exception handling tangina
                MessageBox.Show("An error occurred: " + ex.Message, "Error");
                return false;
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Register_Load(object sender, EventArgs e)
        {
            this.Icon = null;
            this.BackgroundImageLayout = ImageLayout.Stretch; //stretches background image
            
            //makes background colors transparent on labels, images, and etc.
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            checkBox2.BackColor = Color.Transparent;
            pictureBox1.BackColor = Color.Transparent;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox3.BackColor = Color.Transparent; 
            linkLabel1.BackColor = Color.Transparent;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Please fill up the information.", "Error");
            }
            else if (CreateAccount(textBox3.Text, textBox4.Text))
            {
                MessageBox.Show("Account has been created!", "Notice");
            }
            else
            {
                MessageBox.Show("Failed to create an account.");
            }
        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle password visibility based on the CheckBox state
            if (checkBox2.Checked)
            {
                textBox4.PasswordChar = '\0'; // show password
            }
            else
            {
                textBox4.PasswordChar = '*'; // hide
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Login log = new Login();
            log.Show();
        }
    }
}
