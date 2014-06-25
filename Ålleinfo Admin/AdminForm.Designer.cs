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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
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
            this.exit.Location = new System.Drawing.Point(696, 0);
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
            this.Minimize.Location = new System.Drawing.Point(643, 0);
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(750, 2);
            this.panel1.TabIndex = 8;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AdminForm_MouseDown);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(200, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(2, 510);
            this.panel2.TabIndex = 9;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AdminForm_MouseDown);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(85)))), ((int)(((byte)(102)))));
            this.ClientSize = new System.Drawing.Size(750, 550);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.usermessage);
            this.Controls.Add(this.Minimize);
            this.Controls.Add(this.exit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AdminForm";
            this.Text = "Ålleinfo - Administrationspanelen";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AdminForm_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label exit;
        private System.Windows.Forms.Label Minimize;
        private System.Windows.Forms.Label usermessage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}