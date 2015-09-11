namespace ILO_REPORT.myForms.myMasters
{
    partial class frmNewUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewUser));
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.cbLocked = new System.Windows.Forms.CheckBox();
            this.cbAdministrator = new System.Windows.Forms.CheckBox();
            this.txtUserFullName = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.butAdd = new System.Windows.Forms.ToolStripButton();
            this.butCancel = new System.Windows.Forms.ToolStripButton();
            this.txtUserEmail = new System.Windows.Forms.MaskedTextBox();
            this.GroupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.AccessibleDescription = "Login Information";
            this.GroupBox1.AccessibleName = "Login Information";
            this.GroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Separator;
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.txtUserName);
            this.GroupBox1.Controls.Add(this.txtConfirmPassword);
            this.GroupBox1.Controls.Add(this.txtPassword);
            this.GroupBox1.Location = new System.Drawing.Point(10, 32);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(290, 136);
            this.GroupBox1.TabIndex = 9;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Login Information";
            // 
            // Label5
            // 
            this.Label5.AccessibleDescription = "Confirm Password";
            this.Label5.AccessibleName = "Confirm Password";
            this.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label5.Location = new System.Drawing.Point(24, 96);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(100, 16);
            this.Label5.TabIndex = 0;
            this.Label5.Text = "Confirm password:";
            // 
            // Label4
            // 
            this.Label4.AccessibleDescription = "Password";
            this.Label4.AccessibleName = "Password";
            this.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label4.Location = new System.Drawing.Point(24, 64);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(100, 16);
            this.Label4.TabIndex = 0;
            this.Label4.Text = "Password:";
            // 
            // Label3
            // 
            this.Label3.AccessibleDescription = "User name";
            this.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label3.Location = new System.Drawing.Point(24, 32);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(100, 16);
            this.Label3.TabIndex = 0;
            this.Label3.Text = "User name:";
            // 
            // txtUserName
            // 
            this.txtUserName.AccessibleDescription = "User Name";
            this.txtUserName.AccessibleName = "User Name";
            this.txtUserName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(194)))), ((int)(((byte)(226)))));
            this.txtUserName.Location = new System.Drawing.Point(128, 32);
            this.txtUserName.MaxLength = 16;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(120, 20);
            this.txtUserName.TabIndex = 1;
            this.txtUserName.Leave += new System.EventHandler(this.txtUserName_Leave);
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.AccessibleDescription = "Confirm password";
            this.txtConfirmPassword.AccessibleName = "Confirm password";
            this.txtConfirmPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(194)))), ((int)(((byte)(226)))));
            this.txtConfirmPassword.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtConfirmPassword.Location = new System.Drawing.Point(128, 96);
            this.txtConfirmPassword.MaxLength = 16;
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(120, 20);
            this.txtConfirmPassword.TabIndex = 3;
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            this.txtConfirmPassword.Leave += new System.EventHandler(this.txtConfirmPassword_Leave);
            // 
            // txtPassword
            // 
            this.txtPassword.AccessibleDescription = "Password";
            this.txtPassword.AccessibleName = "Password";
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(194)))), ((int)(((byte)(226)))));
            this.txtPassword.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtPassword.Location = new System.Drawing.Point(128, 64);
            this.txtPassword.MaxLength = 16;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(120, 20);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // cbLocked
            // 
            this.cbLocked.AccessibleDescription = "Account Locked";
            this.cbLocked.AccessibleName = "Account Locked";
            this.cbLocked.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbLocked.Location = new System.Drawing.Point(138, 264);
            this.cbLocked.Name = "cbLocked";
            this.cbLocked.Size = new System.Drawing.Size(104, 16);
            this.cbLocked.TabIndex = 7;
            this.cbLocked.Text = "Account locked";
            // 
            // cbAdministrator
            // 
            this.cbAdministrator.AccessibleDescription = "Administrator privilages";
            this.cbAdministrator.AccessibleName = "Administrator privilages";
            this.cbAdministrator.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbAdministrator.Location = new System.Drawing.Point(138, 240);
            this.cbAdministrator.Name = "cbAdministrator";
            this.cbAdministrator.Size = new System.Drawing.Size(144, 16);
            this.cbAdministrator.TabIndex = 6;
            this.cbAdministrator.Text = "Administrator privileges";
            // 
            // txtUserFullName
            // 
            this.txtUserFullName.AccessibleDescription = "Full name";
            this.txtUserFullName.AccessibleName = "Full name";
            this.txtUserFullName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(194)))), ((int)(((byte)(226)))));
            this.txtUserFullName.Location = new System.Drawing.Point(138, 176);
            this.txtUserFullName.MaxLength = 50;
            this.txtUserFullName.Name = "txtUserFullName";
            this.txtUserFullName.Size = new System.Drawing.Size(160, 20);
            this.txtUserFullName.TabIndex = 4;
            // 
            // Label2
            // 
            this.Label2.AccessibleDescription = "Email Address";
            this.Label2.AccessibleName = "Email Address";
            this.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label2.Location = new System.Drawing.Point(18, 208);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(100, 16);
            this.Label2.TabIndex = 0;
            this.Label2.Text = "Email address:";
            // 
            // Label1
            // 
            this.Label1.AccessibleDescription = "Full Name";
            this.Label1.AccessibleName = "Full Name";
            this.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label1.Location = new System.Drawing.Point(18, 184);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(100, 16);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Full name:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("toolStrip1.BackgroundImage")));
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.butAdd,
            this.butCancel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(312, 25);
            this.toolStrip1.TabIndex = 16;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // butAdd
            // 
            this.butAdd.Image = ((System.Drawing.Image)(resources.GetObject("butAdd.Image")));
            this.butAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.butAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(56, 22);
            this.butAdd.Text = "Save";
            this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
            // 
            // butCancel
            // 
            this.butCancel.Image = ((System.Drawing.Image)(resources.GetObject("butCancel.Image")));
            this.butCancel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.butCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(66, 22);
            this.butCancel.Text = "Cancel";
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // txtUserEmail
            // 
            this.txtUserEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(194)))), ((int)(((byte)(226)))));
            this.txtUserEmail.Location = new System.Drawing.Point(138, 205);
            this.txtUserEmail.Name = "txtUserEmail";
            this.txtUserEmail.Size = new System.Drawing.Size(160, 20);
            this.txtUserEmail.TabIndex = 5;
            // 
            // frmNewUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(160)))), ((int)(((byte)(205)))));
            this.ClientSize = new System.Drawing.Size(312, 291);
            this.Controls.Add(this.txtUserEmail);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.cbLocked);
            this.Controls.Add(this.cbAdministrator);
            this.Controls.Add(this.txtUserFullName);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNewUser";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New User";
            this.Load += new System.EventHandler(this.frmNewUser_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txtUserName;
        internal System.Windows.Forms.TextBox txtConfirmPassword;
        internal System.Windows.Forms.TextBox txtPassword;
        internal System.Windows.Forms.CheckBox cbLocked;
        internal System.Windows.Forms.CheckBox cbAdministrator;
        internal System.Windows.Forms.TextBox txtUserFullName;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton butAdd;
        private System.Windows.Forms.ToolStripButton butCancel;
        private System.Windows.Forms.MaskedTextBox txtUserEmail;
    }
}

