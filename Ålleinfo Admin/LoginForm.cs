using System;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Ålleinfo_Admin
{
    public partial class LoginForm : Form
    {
        #region mouseMoveSettings

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void LoginForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        #endregion

        public LoginForm()
        {
            InitializeComponent();
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

        #region button_login

        private void login_MouseDown(object sender, MouseEventArgs e)
        {
            login.BackColor = Color.FromArgb(0, 55, 72);
        }

        private void login_MouseUp(object sender, MouseEventArgs e)
        {
            login.BackColor = Color.FromArgb(0, 85, 102);
        }

        private void login_Click(object sender, EventArgs e)
        {
            if(UsernameBox.Text.Length < 2 || PasswordBox.Text.Length < 2)
            {
                if (UsernameBox.Text.Length < 2)
                    UsernameBox.BackColor = Color.FromArgb(255, 200, 200);

                if (PasswordBox.Text.Length < 2)
                    PasswordBox.BackColor = Color.FromArgb(255, 200, 200);

                SystemSounds.Beep.Play();
                return;
            }

            Webresponse WR = Webber.Login(UsernameBox.Text, PasswordBox.Text);

            if (!WR.Successful)
            {
                if (WR.Message.Contains("Inloggningen misslyckades."))
                {
                    SystemSounds.Asterisk.Play();
                    UsernameBox.BackColor = Color.FromArgb(255, 200, 200);
                    PasswordBox.BackColor = Color.FromArgb(255, 200, 200);
                }
                else
                {
                    MessageBox.Show(WR.Message, "Inloggningen misslyckades", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return;
            }

            AdminForm af = new AdminForm();
            this.Hide();
            af.FormClosed += (s, a) => this.Close();
            af.Show();

        }
        #endregion

        private void Box_TextChanged(object sender, EventArgs e)
        {
            UsernameBox.BackColor = Color.White;
            PasswordBox.BackColor = Color.White;
        }

        private void Box_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                login_Click(null, null);
            }

        }

    }
}
