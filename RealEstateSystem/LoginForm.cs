using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealEstateSystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string correctUsername = "admin";
            string correctPassword = "admin123";

            
            string enteredUsername = txtUsername.Text;
            string enteredPassword = txtPassword.Text;

            
            if (enteredUsername == correctUsername && enteredPassword == correctPassword)
            {
                
                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

               
                MainDashboard dashboard = new MainDashboard();
                this.Hide();
                dashboard.Show();
            }
            else
            {
               
                MessageBox.Show("Invalid username or password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

               
                txtUsername.Clear();
                txtPassword.Clear();

                
                txtUsername.Focus();
            }
        }


        private void lblpassword_Click(object sender, EventArgs e)
        {

        }



        private void usernamelbl_Click(object sender, EventArgs e)
        {

        }

        private void lbllogin_Click(object sender, EventArgs e)
        {

        }
    }
}
