using System;
using System.Runtime.InteropServices;
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
    public partial class AdminForm : Form
    {
        #region mouseMoveSettings

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void AdminForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        #endregion

        public AdminForm()
        {
            InitializeComponent();
            usermessage.Text = "Välkomna, " + Webber.Username;
        }

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

        #region button_Mini

        private void Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BlueButton_Enter(object sender, EventArgs e)
        {
            Label l = (Label)sender;
            l.BackColor = Color.FromArgb(0, 95, 112);
        }

        private void BlueButton_Leave(object sender, EventArgs e)
        {
            Label l = (Label)sender;
            l.BackColor = Color.FromArgb(0, 125, 142);
        }
        #endregion
    }
}
