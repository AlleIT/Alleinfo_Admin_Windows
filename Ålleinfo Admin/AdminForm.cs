using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Ålleinfo_Admin
{
    public partial class AdminForm : Form
    {
        public static AdminForm adminForm;

        public static Queue<String> errorMessages = new Queue<String>();

        private actionPage currentPage;

        private NewsData currentNewsData;

        private Boolean isErrorShowing
        {
            get
            {
                return ErrorReport.Height > 0;
            }
        }

        public AdminForm()
        {
            InitializeComponent();
            usermessage.Text = "Välkomna, " + Webber.Username;
            ActionButton_Click(action_Hem, null);

            newsPresenter.VerticalScroll.Maximum = 0;
            newsPresenter.AutoScroll = true;

            adminForm = this;
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
            if (isErrorShowing)
            {

                errorMessages.Clear();

                switch (setButtonFocus((Control)sender))
                {
                    default:
                    case "action_Hem":
                        if (currentPage == actionPage.Home)
                        {
                            ErrorReport.Height = 0;
                            action_error.Visible = false;
                            panel_home.Height = 510;
                            return;
                        }
                        else
                            break;

                    case "action_Create":
                        if (currentPage == actionPage.Create)
                        {
                            ErrorReport.Height = 0;
                            action_error.Visible = false;
                            return;
                        }
                        else
                            break;

                    case "action_administrate":
                        if (currentPage == actionPage.Administrate)
                        {
                            ErrorReport.Height = 0;
                            action_error.Visible = false;
                            return;
                        }
                        else
                            break;

                    case "action_error":
                        return;
                }
            }
            panel_home.Height = 0;
            panel_create.Height = 0;
            panel_administrate.Height = 0;
            loading.Height = 0;
            currentNewsData = null;

            switch (setButtonFocus((Control)sender))
            {
                default:
                case "action_Hem":
                    ErrorReport.Height = 0;
                    action_error.Visible = false;
                    currentPage = actionPage.Home;

                    loadHome();
                    panel_home.Height = 510;
                    break;

                case "action_Create":
                    ErrorReport.Height = 0;
                    action_error.Visible = false;
                    currentPage = actionPage.Create;

                    loadCreateNews();
                    panel_create.Height = 510;
                    break;

                case "action_administrate":
                    ErrorReport.Height = 0;
                    action_error.Visible = false;
                    currentPage = actionPage.Administrate;

                    loadAllNews();
                    panel_administrate.Height = 510;
                    newsPresenter.Focus();
                    break;

                case "action_error":
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
                try
                {
                    HomeData data = Webber.GetHome();

                    this.Invoke((MethodInvoker)delegate
                    {
                        logo.Image = data.logo;
                        socUrlBox.Text = data.socialURL;
                        descBox.Text = Webber.simpleHTMLDecode(data.description);
                        colorBut.BackColor = ColorTranslator.FromHtml(data.hexaColor);
                        hexcolor.Text = data.hexaColor.ToUpper();
                        loading.Height = 0;
                    });

                }
                catch (GeneralWebberException)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        loading.Height = 0;
                        CheckForErrMsgs();
                    });
                }

            }).Start();

        }

        private void loadCreateNews()
        {
            loading.Height = 0;

            headline.Text = "";
            Type.Text = "";
            shortDesc.Text = "";
            buttonUrl.Text = "";
            CreateDescription.Text = "";

            headline.BackColor = Color.White;
            Type.BackColor = Color.White;
            CreateDescription.BackColor = Color.White;
        }

        public void loadCreateNewsWithData(NewsData data)
        {
            ErrorReport.Height = 0;
            action_error.Visible = false;
            currentPage = actionPage.Create;
            loading.Height = 0;
            panel_administrate.Height = 0;

            headline.Text = data.headline;
            Type.Text = data.type;
            shortDesc.Text = data.shortInfo;
            buttonUrl.Text = data.butURL;
            CreateDescription.Text = data.description;

            headline.BackColor = Color.White;
            Type.BackColor = Color.White;
            CreateDescription.BackColor = Color.White;

            currentNewsData = data;

            setButtonFocus(action_Create);

            panel_create.Height = 510;
        }

        private void loadAllNews()
        {
            loading.Height = 510;
            clearNews();
            noNewsLabel.Visible = false;

            new Task(() =>
            {
                try
                {
                    Webber.GetAllNews();

                    this.Invoke((MethodInvoker)delegate
                    {
                        if (newsPresenter.Controls.Count == 0)
                            noNewsLabel.Visible = true;

                        loading.Height = 0;
                    });

                }
                catch (GeneralWebberException)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        loading.Height = 0;
                        CheckForErrMsgs();
                    });
                }

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

            return c.Name;
        }

        #endregion

        #region Pages

        #region Page_Home

        private void utskottsbild_Click(object sender, EventArgs e)
        {
            if (openNewLogo.ShowDialog() == DialogResult.OK)
            {
                logo.Image = Bitmap.FromFile(openNewLogo.FileName);
            }
        }

        private void execHome_Click(object sender, EventArgs e)
        {
            if (execHome.Text == "Vänta...")
                return;

            execHome.Text = "Vänta...";

            HomeData data = new HomeData(logo.Image, Webber.simpleHTMLEncode(descBox.Text), socUrlBox.Text, HexConverter(colorBut.BackColor));

            new Task(() =>
            {
                try
                {
                    Webresponse response = Webber.SetHome(data);

                    this.Invoke((MethodInvoker)delegate
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
                    });

                }
                catch (GeneralWebberException)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        execHome.Text = "Verkställ";

                        CheckForErrMsgs();
                    });
                }

            }).Start();
        }

        private void colorBut_Click(object sender, EventArgs e)
        {
            colorPicker.Color = colorBut.BackColor;

            if (colorPicker.ShowDialog() == DialogResult.OK)
            {
                colorBut.BackColor = colorPicker.Color;
                hexcolor.Text = HexConverter(colorPicker.Color).ToUpper();
            }
        }

        private void hexcolor_KeyDown(object sender, KeyEventArgs e)
        {
            Keys[] allowedChars = { Keys.D0, Keys.NumPad0, Keys.D1, Keys.NumPad1, Keys.D2, Keys.NumPad2, Keys.D3, Keys.NumPad3, Keys.D4, Keys.NumPad4,
                                  Keys.D5, Keys.NumPad5, Keys.D6, Keys.NumPad6, Keys.D7, Keys.NumPad7, Keys.D8, Keys.NumPad8, Keys.D9, Keys.NumPad9,
                                  Keys.A, Keys.B, Keys.C, Keys.D, Keys.E, Keys.F, Keys.Left, Keys.Right, Keys.Back, Keys.Delete };

            Boolean allowed = false;

            foreach (Keys key in allowedChars)
            {
                if (e.KeyCode == key)
                {
                    allowed = true;
                    break;
                }
            }

            if (!allowed
                && e.KeyCode != Keys.Control
                && e.KeyCode != Keys.V)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void hexcolor_KeyUp(object sender, KeyEventArgs e)
        {
            if (hexcolor.TextLength == 0)
            {
                hexcolor.Text = "#";
                hexcolor.Select(1, 0);
            }
            
            while (hexcolor.Text.Substring(1).Contains("#"))
            {
                if (hexcolor.SelectionStart > hexcolor.Text.IndexOf("#", 1))
                    hexcolor.Select(hexcolor.SelectionStart - 1, 0);

                hexcolor.Text = hexcolor.Text.Substring(0, hexcolor.Text.IndexOf("#", 1)) + hexcolor.Text.Substring(hexcolor.Text.IndexOf("#", 1) + 1);
            }

            if (hexcolor.Text.Substring(0, 1) != "#")
            {
                hexcolor.Text = "#" + hexcolor.Text;
                hexcolor.Select(hexcolor.SelectionStart + 1, 0);
            }

            if (hexcolor.Text.Length > 7)
                hexcolor.Text = hexcolor.Text.Substring(0, 7);

            if (hexcolor.Text.Length == 7)
                colorBut.BackColor = ColorTranslator.FromHtml(hexcolor.Text);
        }

        #endregion

        #region Page_Create

        private void saveExec_Click(object sender, EventArgs e)
        {
            if (saveExec.Text == "Vänta...")
                return;

            if (headline.Text.Length < 2
                || Type.Text.Length < 2
                || CreateDescription.Text.Length < 2)
            {
                if (headline.Text.Length < 2)
                    headline.BackColor = Color.FromArgb(255, 200, 200);

                if (Type.Text.Length < 2)
                    Type.BackColor = Color.FromArgb(255, 200, 200);

                if (CreateDescription.Text.Length < 2)
                    CreateDescription.BackColor = Color.FromArgb(255, 200, 200);

                SystemSounds.Beep.Play();
                return;
            }

            saveExec.Text = "Vänta...";

            NewsData data;

            if (currentNewsData != null)
                data = currentNewsData;
            else
                data = new NewsData();

            data.changeData(Webber.simpleHTMLEncode(headline.Text), Webber.simpleHTMLEncode(shortDesc.Text), Webber.simpleHTMLEncode(Type.Text), buttonUrl.Text, Webber.simpleHTMLEncode(CreateDescription.Text));

            new Task(() =>
            {
                try
                {
                    Webresponse response = Webber.SetNews(data);

                    this.Invoke((MethodInvoker)delegate
                    {
                        saveExec.Text = "Spara";
                        ActionButton_Click(action_administrate, null);
                    });

                }
                catch (GeneralWebberException)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        saveExec.Text = "Spara";

                        CheckForErrMsgs();
                    });
                }

            }).Start();

        }

        private void createTextBoxChange(object sender, EventArgs e)
        {
            headline.BackColor = Color.White;
            Type.BackColor = Color.White;
            CreateDescription.BackColor = Color.White;
        }

        #endregion

        #region Page_Administrate

        public void addNews(NewsItem NI)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate
                {
                    newsPresenter.Controls.Add(NI.container);
                });
            }
            else
                newsPresenter.Controls.Add(NI.container);
        }

        public void removeNewsDisplay(NewsItem NI)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate
                {
                    newsPresenter.Controls.Remove(NI.container);
                });
            }
            else
                newsPresenter.Controls.Remove(NI.container);
        }

        public void clearNews()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate
                {
                    newsPresenter.Controls.Clear();
                });
            }
            else
                newsPresenter.Controls.Clear();
        }

        #endregion

        #endregion

        #region errorDisplay

        public void CheckForErrMsgs()
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

            action_error.Visible = true;

            ErrorReport.Height = 510;

            ReportText.Text = AdminForm.errorMessages.Dequeue();

            ReportText.Left = ErrorReport.Width / 2 - ReportText.Width / 2;
            ReportText.Top = ErrorReport.Height / 2 - ReportText.Height / 2;
        }

        #endregion

        #region utilities

        private static String HexConverter(Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }
        
        #endregion

        #region Generic texbox behaviours

        // Linked to: Home, Create
        private void descBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                ((TextBox)sender).SelectAll();
            }
        }
        private void UrlBox_MouseDown(object sender, MouseEventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        #endregion


    }
}