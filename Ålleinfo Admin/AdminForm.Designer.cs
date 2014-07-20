namespace Ålleinfo_Admin
{
    partial class AdminForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm));
            this.exit = new System.Windows.Forms.Label();
            this.Minimize = new System.Windows.Forms.Label();
            this.usermessage = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.AvailibleActions = new System.Windows.Forms.FlowLayoutPanel();
            this.action_Hem = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.action_Create = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.action_administrate = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel_home = new System.Windows.Forms.Panel();
            this.socUrlBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.execHome = new System.Windows.Forms.Label();
            this.descBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.utskottsbild = new System.Windows.Forms.PictureBox();
            this.openNewLogo = new System.Windows.Forms.OpenFileDialog();
            this.AvailibleActions.SuspendLayout();
            this.action_Hem.SuspendLayout();
            this.action_Create.SuspendLayout();
            this.action_administrate.SuspendLayout();
            this.panel_home.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.utskottsbild)).BeginInit();
            this.SuspendLayout();
            // 
            // exit
            // 
            this.exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exit.AutoSize = true;
            this.exit.BackColor = System.Drawing.Color.IndianRed;
            this.exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exit.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exit.ForeColor = System.Drawing.Color.White;
            this.exit.Location = new System.Drawing.Point(746, 0);
            this.exit.Name = "exit";
            this.exit.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.exit.Size = new System.Drawing.Size(54, 39);
            this.exit.TabIndex = 4;
            this.exit.Text = "X";
            this.exit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            this.exit.Enter += new System.EventHandler(this.exit_Enter);
            this.exit.Leave += new System.EventHandler(this.exit_Leave);
            this.exit.MouseEnter += new System.EventHandler(this.exit_Enter);
            this.exit.MouseLeave += new System.EventHandler(this.exit_Leave);
            // 
            // Minimize
            // 
            this.Minimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Minimize.AutoSize = true;
            this.Minimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(125)))), ((int)(((byte)(142)))));
            this.Minimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Minimize.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Minimize.ForeColor = System.Drawing.Color.White;
            this.Minimize.Location = new System.Drawing.Point(693, 0);
            this.Minimize.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.Minimize.Name = "Minimize";
            this.Minimize.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.Minimize.Size = new System.Drawing.Size(53, 39);
            this.Minimize.TabIndex = 6;
            this.Minimize.Text = "_";
            this.Minimize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Minimize.Click += new System.EventHandler(this.Minimize_Click);
            this.Minimize.Enter += new System.EventHandler(this.BlueButton_Enter);
            this.Minimize.Leave += new System.EventHandler(this.BlueButton_Leave);
            this.Minimize.MouseEnter += new System.EventHandler(this.BlueButton_Enter);
            this.Minimize.MouseLeave += new System.EventHandler(this.BlueButton_Leave);
            // 
            // usermessage
            // 
            this.usermessage.AutoSize = true;
            this.usermessage.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usermessage.ForeColor = System.Drawing.Color.White;
            this.usermessage.Location = new System.Drawing.Point(12, 4);
            this.usermessage.Name = "usermessage";
            this.usermessage.Size = new System.Drawing.Size(347, 33);
            this.usermessage.TabIndex = 7;
            this.usermessage.Text = "Ålleinfos Administrationspanel";
            this.usermessage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AdminForm_MouseDown);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(240, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(2, 510);
            this.panel2.TabIndex = 9;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AdminForm_MouseDown);
            // 
            // AvailibleActions
            // 
            this.AvailibleActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.AvailibleActions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.AvailibleActions.Controls.Add(this.action_Hem);
            this.AvailibleActions.Controls.Add(this.action_Create);
            this.AvailibleActions.Controls.Add(this.action_administrate);
            this.AvailibleActions.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.AvailibleActions.Location = new System.Drawing.Point(0, 40);
            this.AvailibleActions.Margin = new System.Windows.Forms.Padding(0);
            this.AvailibleActions.Name = "AvailibleActions";
            this.AvailibleActions.Size = new System.Drawing.Size(240, 510);
            this.AvailibleActions.TabIndex = 10;
            // 
            // action_Hem
            // 
            this.action_Hem.BackColor = System.Drawing.Color.Transparent;
            this.action_Hem.Controls.Add(this.label1);
            this.action_Hem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.action_Hem.Location = new System.Drawing.Point(0, 5);
            this.action_Hem.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.action_Hem.Name = "action_Hem";
            this.action_Hem.Size = new System.Drawing.Size(240, 70);
            this.action_Hem.TabIndex = 0;
            this.action_Hem.Click += new System.EventHandler(this.ActionButton_Click);
            this.action_Hem.Enter += new System.EventHandler(this.ActionButton_Enter);
            this.action_Hem.Leave += new System.EventHandler(this.ActionButton_Leave);
            this.action_Hem.MouseEnter += new System.EventHandler(this.ActionButton_Enter);
            this.action_Hem.MouseLeave += new System.EventHandler(this.ActionButton_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(5, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hem";
            this.label1.Click += new System.EventHandler(this.ActionButton_Click);
            this.label1.Enter += new System.EventHandler(this.ActionButton_Enter);
            this.label1.Leave += new System.EventHandler(this.ActionButton_Leave);
            this.label1.MouseEnter += new System.EventHandler(this.ActionButton_Enter);
            this.label1.MouseLeave += new System.EventHandler(this.ActionButton_Leave);
            // 
            // action_Create
            // 
            this.action_Create.BackColor = System.Drawing.Color.Transparent;
            this.action_Create.Controls.Add(this.label2);
            this.action_Create.Cursor = System.Windows.Forms.Cursors.Hand;
            this.action_Create.Location = new System.Drawing.Point(0, 80);
            this.action_Create.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.action_Create.Name = "action_Create";
            this.action_Create.Size = new System.Drawing.Size(240, 70);
            this.action_Create.TabIndex = 1;
            this.action_Create.Click += new System.EventHandler(this.ActionButton_Click);
            this.action_Create.Enter += new System.EventHandler(this.ActionButton_Enter);
            this.action_Create.Leave += new System.EventHandler(this.ActionButton_Leave);
            this.action_Create.MouseEnter += new System.EventHandler(this.ActionButton_Enter);
            this.action_Create.MouseLeave += new System.EventHandler(this.ActionButton_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(5, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 39);
            this.label2.TabIndex = 0;
            this.label2.Text = "Skapa nyhet";
            this.label2.Click += new System.EventHandler(this.ActionButton_Click);
            this.label2.Enter += new System.EventHandler(this.ActionButton_Enter);
            this.label2.Leave += new System.EventHandler(this.ActionButton_Leave);
            this.label2.MouseEnter += new System.EventHandler(this.ActionButton_Enter);
            this.label2.MouseLeave += new System.EventHandler(this.ActionButton_Leave);
            // 
            // action_administrate
            // 
            this.action_administrate.BackColor = System.Drawing.Color.Transparent;
            this.action_administrate.Controls.Add(this.label3);
            this.action_administrate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.action_administrate.Location = new System.Drawing.Point(0, 155);
            this.action_administrate.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.action_administrate.Name = "action_administrate";
            this.action_administrate.Size = new System.Drawing.Size(240, 70);
            this.action_administrate.TabIndex = 2;
            this.action_administrate.Click += new System.EventHandler(this.ActionButton_Click);
            this.action_administrate.Enter += new System.EventHandler(this.ActionButton_Enter);
            this.action_administrate.Leave += new System.EventHandler(this.ActionButton_Leave);
            this.action_administrate.MouseEnter += new System.EventHandler(this.ActionButton_Enter);
            this.action_administrate.MouseLeave += new System.EventHandler(this.ActionButton_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(5, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(229, 39);
            this.label3.TabIndex = 0;
            this.label3.Text = "Hantera nyheter";
            this.label3.Click += new System.EventHandler(this.ActionButton_Click);
            this.label3.Enter += new System.EventHandler(this.ActionButton_Enter);
            this.label3.Leave += new System.EventHandler(this.ActionButton_Leave);
            this.label3.MouseEnter += new System.EventHandler(this.ActionButton_Enter);
            this.label3.MouseLeave += new System.EventHandler(this.ActionButton_Leave);
            // 
            // panel_home
            // 
            this.panel_home.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(85)))), ((int)(((byte)(102)))));
            this.panel_home.Controls.Add(this.socUrlBox);
            this.panel_home.Controls.Add(this.label6);
            this.panel_home.Controls.Add(this.execHome);
            this.panel_home.Controls.Add(this.descBox);
            this.panel_home.Controls.Add(this.label5);
            this.panel_home.Controls.Add(this.label4);
            this.panel_home.Controls.Add(this.utskottsbild);
            this.panel_home.Location = new System.Drawing.Point(242, 40);
            this.panel_home.Name = "panel_home";
            this.panel_home.Size = new System.Drawing.Size(558, 0);
            this.panel_home.TabIndex = 11;
            // 
            // socUrlBox
            // 
            this.socUrlBox.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.socUrlBox.Location = new System.Drawing.Point(232, 29);
            this.socUrlBox.Name = "socUrlBox";
            this.socUrlBox.Size = new System.Drawing.Size(314, 31);
            this.socUrlBox.TabIndex = 10;
            this.socUrlBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.socUrlBox_MouseDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(228, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(163, 19);
            this.label6.TabIndex = 9;
            this.label6.Text = "Länk till sociala medier:";
            // 
            // execHome
            // 
            this.execHome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.execHome.AutoSize = true;
            this.execHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(85)))), ((int)(((byte)(102)))));
            this.execHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.execHome.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.execHome.ForeColor = System.Drawing.Color.White;
            this.execHome.Location = new System.Drawing.Point(423, -65);
            this.execHome.Name = "execHome";
            this.execHome.Padding = new System.Windows.Forms.Padding(10);
            this.execHome.Size = new System.Drawing.Size(128, 53);
            this.execHome.TabIndex = 8;
            this.execHome.Text = "Verkställ";
            this.execHome.Click += new System.EventHandler(this.execHome_Click);
            // 
            // descBox
            // 
            this.descBox.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descBox.Location = new System.Drawing.Point(7, 281);
            this.descBox.MaxLength = 5000;
            this.descBox.Multiline = true;
            this.descBox.Name = "descBox";
            this.descBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.descBox.Size = new System.Drawing.Size(410, 217);
            this.descBox.TabIndex = 3;
            this.descBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.descBox_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(7, 258);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 19);
            this.label5.TabIndex = 2;
            this.label5.Text = "Beskrivning:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(6, 224);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(215, 19);
            this.label4.TabIndex = 1;
            this.label4.Text = "Klicka på bilden för att byta den";
            // 
            // utskottsbild
            // 
            this.utskottsbild.BackColor = System.Drawing.Color.Transparent;
            this.utskottsbild.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.utskottsbild.Cursor = System.Windows.Forms.Cursors.Hand;
            this.utskottsbild.Location = new System.Drawing.Point(6, 6);
            this.utskottsbild.Name = "utskottsbild";
            this.utskottsbild.Size = new System.Drawing.Size(215, 215);
            this.utskottsbild.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.utskottsbild.TabIndex = 0;
            this.utskottsbild.TabStop = false;
            this.utskottsbild.Click += new System.EventHandler(this.utskottsbild_Click);
            // 
            // openNewLogo
            // 
            this.openNewLogo.DefaultExt = "png";
            this.openNewLogo.Filter = "PNG Image|*.png";
            this.openNewLogo.ShowReadOnly = true;
            this.openNewLogo.Title = "Välj en ny bild";
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(85)))), ((int)(((byte)(102)))));
            this.ClientSize = new System.Drawing.Size(800, 550);
            this.Controls.Add(this.panel_home);
            this.Controls.Add(this.AvailibleActions);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.usermessage);
            this.Controls.Add(this.Minimize);
            this.Controls.Add(this.exit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AdminForm";
            this.Text = "Ålleinfo - Administrationspanelen";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AdminForm_MouseDown);
            this.AvailibleActions.ResumeLayout(false);
            this.action_Hem.ResumeLayout(false);
            this.action_Hem.PerformLayout();
            this.action_Create.ResumeLayout(false);
            this.action_Create.PerformLayout();
            this.action_administrate.ResumeLayout(false);
            this.action_administrate.PerformLayout();
            this.panel_home.ResumeLayout(false);
            this.panel_home.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.utskottsbild)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label exit;
        private System.Windows.Forms.Label Minimize;
        private System.Windows.Forms.Label usermessage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel AvailibleActions;
        private System.Windows.Forms.Panel action_Hem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel action_Create;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel action_administrate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel_home;
        private System.Windows.Forms.TextBox socUrlBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label execHome;
        private System.Windows.Forms.TextBox descBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox utskottsbild;
        private System.Windows.Forms.OpenFileDialog openNewLogo;
    }
}