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
    public partial class CustomerPanel : Form
    {
        public CustomerPanel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void SignOut()
        {

            DialogResult result = MessageBox.Show("Do you want to sign out?", "Sign Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                

                // Back to login
                Login loginForm = new Login();
                loginForm.Show();

                // Close customer planel
                this.Close();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SignOut();
        }

        private void CustomerPanel_Load(object sender, EventArgs e)
        {

        }
    }
}
