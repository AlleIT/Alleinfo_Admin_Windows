using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Ålleinfo_Admin
{
    public partial class AdminForm : Form
    {
        public static Queue<String> errorMessages = new Queue<String>();


        public AdminForm()
        {
            InitializeComponent();
            usermessage.Text = "Välkomna, " + Webber.Username;
            ActionButton_Click(action_Hem, null);
        }

        #region defaults

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

        #endregion

        #region Loading of pages

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
            switch (setButtonFocus((Control)sender))
            {
                default:
                case "action_Hem":
                    ErrorReport.Height = 0;
                    action_error.Visible = false;

                    loadHome();
                    panel_home.Visible = true;
                    panel_home.Height = 510;
                    break;

                case "action_Create":
                    ErrorReport.Height = 0;
                    action_error.Visible = false;

                    loadNewNews();
                    break;

                case "action_administrate":
                    ErrorReport.Height = 0;
                    action_error.Visible = false;

                    loadAllNews();
                    break;

                case "action_error":
                    CheckForErrMsgs();
                    break;
            }
        }
        #endregion
        
        #region loadPages

        private void loadHome()
        {
            loading.Height = 510;

            new Task(() =>
            {
                HomeData data = Webber.GetHome();
                this.Invoke((MethodInvoker)delegate
                {
                    if (data.logo != null)
                    {
                        utskottsbild.Image = data.logo;
                        socUrlBox.Text = data.socialURL;
                        descBox.Text = simpleHTMLDecode(data.description);
                        loading.Height = 0;
                    }
                    else
                    {
                        CheckForErrMsgs();
                    }
                });

            }).Start();

        }

        private void loadNewNews()
        {
            loading.Height = 510;

            new Task(() =>
            {

                this.Invoke((MethodInvoker)delegate
                {

                    loading.Height = 0;
                });

            }).Start();

        }

        private void loadAllNews()
        {
            loading.Height = 510;

            new Task(() =>
            {

                this.Invoke((MethodInvoker)delegate
                {

                    loading.Height = 0;
                });

            }).Start();

        }

        private void loadEditNews()
        {
            loading.Height = 510;

            new Task(() =>
            {

                this.Invoke((MethodInvoker)delegate
                {

                    loading.Height = 0;
                });

            }).Start();

        }

        #endregion

        private String setButtonFocus(Control button)
        {
            foreach (Control con in AvailibleActions.Controls)
            {
                con.BackColor = Color.Transparent;
            }

            Label l = button as Label;

            Control c;

            if (l != null)
            {
                c = button.Parent;
            }
            else
            {
                c = button;
            }

            c.BackColor = Color.FromArgb(0, 85, 102);

            panel_home.Visible = false;

            return c.Name;
        }

        #endregion

        #region Pages

        #region Page_Home
        private void descBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                descBox.SelectAll();
            }
        }

        private void utskottsbild_Click(object sender, EventArgs e)
        {
            if (openNewLogo.ShowDialog() == DialogResult.OK)
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

                    if (response.Successful)
                    {
                        execHome.Text = "Sparat!";

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
                        AdminForm.errorMessages.Enqueue("Sparandet misslyckades! Försök igen."
                            + Environment.NewLine + Environment.NewLine
                            + "Felmeddelande:" + Environment.NewLine
                            + response.Message.ToString());

                        CheckForErrMsgs();

                        execHome.Text = "Verkställ";
                    }
                });

            }).Start();
        }

        #endregion

        #endregion

        #region errorDisplay

        private void CheckForErrMsgs()
        {
            if (AdminForm.errorMessages.Count == 0 && ErrorReport.Height == 0)
                return;
            else if (AdminForm.errorMessages.Count == 0)
            {
                ErrorReport.Height = 0;
                action_error.Visible = false;
                return;
            }

            setButtonFocus(action_error);

            ErrorReport.Height = 510;

            ReportText.Text = AdminForm.errorMessages.Dequeue();

            ReportText.Left = ErrorReport.Width / 2 - ReportText.Width / 2;
            ReportText.Top = ErrorReport.Height / 2 - ReportText.Height / 2;

            action_error.Visible = true;
        }

        private void errorOk_Click(object sender, EventArgs e)
        {
            CheckForErrMsgs();
        }
        #endregion

        #region HTML Encoder/Decoder

        // HTTPUTILITY fixar inte åäö så att de blir läsbara i textrutan :( Nedan: egen fix

        private String simpleHTMLEncode(String str)
        {
            str.Replace("å", "&aring;");
            str.Replace("Å", "&Aring;");
            str.Replace("ä", "&auml;");
            str.Replace("Ä", "&Auml;");
            str.Replace("ö", "&ouml;");
            str.Replace("Ö", "&Ouml;");

            String split = str;
            str = "";

            String[] divider = { Environment.NewLine };

            foreach (String s in split.Split(divider, StringSplitOptions.None))
            {
                str += s + "<br>";
            }

            str = str.Substring(0, str.Length - 4);

            return str;
        }

        private String simpleHTMLDecode(String str)
        {
            str = HttpUtility.HtmlDecode(str);

            String split = str;
            str = "";

            String[] divider = { "<br>" };

            foreach (String s in split.Split(divider, StringSplitOptions.None))
            {
                str += s + Environment.NewLine;
            }

            str = str.Substring(0, str.Length - Environment.NewLine.Length);

            return str;
        }

        #endregion

    }
}