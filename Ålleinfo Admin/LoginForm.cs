using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ålleinfo_Admin
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        #region button_login

        private void login_MouseDown(object sender, MouseEventArgs e)
        {
            login.BackColor = Color.FromArgb(0, 55, 72);
        }

        private void login_MouseUp(object sender, MouseEventArgs e)
        {
            login.BackColor = Color.FromArgb(0, 85, 102);
        }
        #endregion

        #region button_exit

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void exit_Enter(object sender, EventArgs e)
        {
            exit.BackColor = Color.Red;
        }

        private void exit_Leave(object sender, EventArgs e)
        {
            exit.BackColor = Color.IndianRed;
        }

        #endregion

    }
}
