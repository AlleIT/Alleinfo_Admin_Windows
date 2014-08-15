using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ålleinfo_Admin
{
    public class NewsItem
    {
        public NewsData data;

        public Panel container;

        public NewsItem(NewsData ND, SizeF scale)
        {
            this.data = ND;

            #region Panel container
            container = new Panel();
            container.Size = new Size((int)(518 * scale.Width), (int)(100 * scale.Height));
            container.Margin = new Padding(10);
            container.Left = 0;
            container.BackColor = Color.FromArgb(54, 54, 54);
            container.Cursor = Cursors.Hand;
            container.Click += new EventHandler(NewsItem_OnClick);
            container.Enter += new EventHandler(NewsItem_Enter);
            container.Leave += new EventHandler(NewsItem_Leave);
            container.MouseEnter += new EventHandler(NewsItem_Enter);
            container.MouseLeave += new EventHandler(NewsItem_Leave);
            #endregion

            #region Label headline
            Label headline = new Label();
            headline.AutoSize = true;
            headline.Font = new Font("Calibri", 18f, FontStyle.Regular);
            headline.Text = data.headline;
            headline.Top = container.Height / 4 - headline.Height / 2;
            headline.Left = 10;
            headline.Cursor = Cursors.Hand;
            headline.ForeColor = Color.White;
            headline.BackColor = Color.Transparent;
            headline.Click += new EventHandler(NewsItem_OnClick);
            headline.Enter += new EventHandler(NewsItem_Enter);
            headline.Leave += new EventHandler(NewsItem_Leave);
            headline.MouseEnter += new EventHandler(NewsItem_Enter);
            headline.MouseLeave += new EventHandler(NewsItem_Leave);
            #endregion

            #region Label type
            Label type = new Label();
            type.AutoSize = true;
            type.Font = new Font("Calibri", 16, FontStyle.Italic);
            type.Text = data.type;
            type.Top = container.Height * 3 / 4 - type.Height;
            type.Left = 10;
            type.Cursor = Cursors.Hand;
            type.ForeColor = Color.White;
            type.BackColor = Color.Transparent;
            type.Click += new EventHandler(NewsItem_OnClick);
            type.Enter += new EventHandler(NewsItem_Enter);
            type.Leave += new EventHandler(NewsItem_Leave);
            type.MouseEnter += new EventHandler(NewsItem_Enter);
            type.MouseLeave += new EventHandler(NewsItem_Leave);
            #endregion

            #region Label pubDate
            Label pubDate = new Label();
            pubDate.AutoSize = true;
            pubDate.Font = new Font("Calibri", 16, FontStyle.Italic);
            pubDate.Text = "Publicerades den " + data.pubDate;
            pubDate.Top = container.Height - pubDate.Height - 5;
            pubDate.Left = (int)(230 * scale.Width);
            pubDate.Cursor = Cursors.Hand;
            pubDate.ForeColor = Color.White;
            pubDate.BackColor = Color.Transparent;
            pubDate.Click += new EventHandler(NewsItem_OnClick);
            pubDate.Enter += new EventHandler(NewsItem_Enter);
            pubDate.Leave += new EventHandler(NewsItem_Leave);
            pubDate.MouseEnter += new EventHandler(NewsItem_Enter);
            pubDate.MouseLeave += new EventHandler(NewsItem_Leave);
            #endregion

            #region Labelbutton remBut
            Label remBut = new Label();
            remBut.AutoSize = true;
            remBut.Font = new Font("Calibri", 20, FontStyle.Regular);
            remBut.Text = "Radera";
            remBut.Padding = new Padding(10);
            remBut.Top = container.Height / 4 - remBut.Height / 2;
            remBut.Left = (int)(400 * scale.Width);
            remBut.Cursor = Cursors.Hand;
            remBut.ForeColor = Color.White;
            remBut.BackColor = Color.FromArgb(0, 85, 102);
            remBut.Click += new EventHandler(remBut_OnClick);
            remBut.Enter += new EventHandler(remBut_Enter);
            remBut.Leave += new EventHandler(remBut_Leave);
            remBut.MouseEnter += new EventHandler(remBut_Enter);
            remBut.MouseLeave += new EventHandler(remBut_Leave);
            #endregion

            #region addControls
            container.Controls.Add(headline);
            container.Controls.Add(type);
            container.Controls.Add(pubDate);
            container.Controls.Add(remBut);
            AdminForm.adminForm.addNews(this);
            #endregion
        }

        #region wholeNewsItem
        public void NewsItem_OnClick(Object sender, EventArgs e)
        {
            AdminForm.adminForm.loadCreateNewsWithData(data);
        }

        public void NewsItem_Enter(Object sender, EventArgs e)
        {
            container.BackColor = Color.FromArgb(34, 34, 34);
        }

        public void NewsItem_Leave(Object sender, EventArgs e)
        {
            container.BackColor = Color.FromArgb(54, 54, 54);
        }
        #endregion

        #region RemoveButton
        public void remBut_OnClick(Object sender, EventArgs e)
        {
            new Task(() =>
            {
                try
                {
                    Webber.removeNews((int)data.id);

                    AdminForm.adminForm.removeNewsDisplay(this);
                }
                catch (GeneralWebberException)
                {
                    AdminForm.adminForm.Invoke((MethodInvoker)delegate
                    {
                        AdminForm.adminForm.CheckForErrMsgs();
                    });
                }

            }).Start();
        }

        public void remBut_Enter(Object sender, EventArgs e)
        {
            ((Control)sender).BackColor = Color.FromArgb(0, 55, 72);
        }

        public void remBut_Leave(Object sender, EventArgs e)
        {
            ((Control)sender).BackColor = Color.FromArgb(0, 85, 102);
        }
        #endregion
    }
}
