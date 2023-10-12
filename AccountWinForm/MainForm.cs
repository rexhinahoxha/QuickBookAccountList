using Authentication.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountWinForm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Create and show the new form
            LogInForm logInForm = new LogInForm();
            logInForm.ShowDialog();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
             if (LocalAuth.Tokens!=null)
            {
                CompaniesForm compInForm = new CompaniesForm();
                compInForm.ShowDialog();
            }
             else
            {
                // show pop up message 
                MessageBox.Show("Please Log in into Quick Books first!", "Attention", MessageBoxButtons.OK);
            }
        }
        }
}
