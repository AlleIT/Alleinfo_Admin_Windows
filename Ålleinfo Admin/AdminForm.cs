using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Media;
using System.Threading.Tasks;
using System.Web;
using System.IO;
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
            ActionButton_Click(action_Hem, null);
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
            Control c = (Control)sender;
            c.BackColor = Color.FromArgb(0, 95, 112);
        }

        private void BlueButton_Leave(object sender, EventArgs e)
        {
            Control c = (Control)sender;
            c.BackColor = Color.FromArgb(0, 125, 142);
        }
        #endregion

        #region actionbutton

        private void ActionButton_Enter(object sender, EventArgs e)
        {
            Label l = sender as Label;

            Control c;

            if (l != null)
            {
                c = ((Control)sender).Parent;
            }
            else
            {
                c = (Control)sender;
            }

            if (c.BackColor != Color.Transparent && c.BackColor != Color.FromArgb(54, 54, 54))
                return;

            c.BackColor = Color.FromArgb(54, 54, 54);
        }

        private void ActionButton_Leave(object sender, EventArgs e)
        {
            Label l = sender as Label;

            Control c;

            if (l != null)
            {
                c = ((Control)sender).Parent;
            }
            else
            {
                c = (Control)sender;
            }

            if (c.BackColor != Color.Transparent && c.BackColor != Color.FromArgb(54, 54, 54))
                return;

            c.BackColor = Color.Transparent;
        }

        private void ActionButton_Click(object sender, EventArgs e)
        {
            foreach (Control con in AvailibleActions.Controls)
            {
                con.BackColor = Color.Transparent;
            }

            Label l = sender as Label;

            Control c;

            if (l != null)
            {
                c = ((Control)sender).Parent;
            }
            else
            {
                c = (Control)sender;
            }

            c.BackColor = Color.FromArgb(0, 85, 102);

            panel_home.Visible = false;

            switch (c.Name)
            {
                case "action_Hem":
                    panel_home.Visible = true;
                    panel_home.Height = 510;
                    new Task(loadHome).Start();
                    break;

                case "action_Create":
                    break;

                case "action_administrate":

                    break;

                default:
                    break;
            }
        }
        #endregion

        #region loadPages

        private void loadHome()
        {
            HomeData data = Webber.GetHome();
            this.Invoke((MethodInvoker)delegate
            {
                if (data.logo != null)
                {
                    utskottsbild.Image = data.logo;
                    socUrlBox.Text = data.socialURL;
                    descBox.Text = HttpUtility.HtmlDecode(data.description);
                }
            });

        }

        #endregion

        private void descBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                descBox.SelectAll();
            }
        }

        private void utskottsbild_Click(object sender, EventArgs e)
        {
            if(openNewLogo.ShowDialog() == DialogResult.OK)
            {
                utskottsbild.Image = Bitmap.FromFile(openNewLogo.FileName);
            }
        }

        private void socUrlBox_MouseDown(object sender, MouseEventArgs e)
        {
            socUrlBox.SelectAll();
        }

        private void execHome_Click(object sender, EventArgs e)
        {
            if (execHome.Text == "Vänta...")
                return;

            execHome.Text = "Vänta...";

            HomeData data = new HomeData(utskottsbild.Image, simpleHTMLEncode(descBox.Text), socUrlBox.Text);


            new Task(() =>
            {
                Webresponse response = Webber.SetHome(data);

                this.Invoke((MethodInvoker)delegate
                {

                    if(response.Successful)
                    {
                        execHome.Text = "Sparat!";
                        SystemSounds.Beep.Play();

                        new Task(() =>
                        {
                            System.Threading.Thread.Sleep(4000);
                            Invoke((MethodInvoker)delegate
                            {
                                execHome.Text = "Verkställ";
                                
                            });
                        }).Start();
                    }
                    else
                    {
                        execHome.Text = "Misslyckades";

                        MessageBox.Show("Sparandet misslyckades! Försök igen."
                            + Environment.NewLine + Environment.NewLine
                            + "Felmeddelande:" + Environment.NewLine
                            + response.Message.ToString(),
                            "Kunde inte spara.",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);

                        execHome.Text = "Verkställ";
                    }
                });

            }).Start();
        }

        // HTTPUTILITY fixar inte åäö så att de blir läsbara i textrutan :( Nedan: egen fix
        private String simpleHTMLEncode(String str)
        {
            str.Replace("å", "&aring;");
            str.Replace("Å", "&Aring;");
            str.Replace("ä", "&auml;");
            str.Replace("Ä", "&Auml;");
            str.Replace("ö", "&ouml;");
            str.Replace("Ö", "&Ouml;");

            return str;
        }
    }
}