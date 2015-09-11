namespace ILO_REPORT.myControls
{
    partial class ucAdministration
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucAdministration));
            this.butOfficeInfo = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.butManageUser = new System.Windows.Forms.Button();
            this.butUserAdd = new System.Windows.Forms.Button();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // butOfficeInfo
            // 
            this.butOfficeInfo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("butOfficeInfo.BackgroundImage")));
            this.butOfficeInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.butOfficeInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butOfficeInfo.Location = new System.Drawing.Point(39, 12);
            this.butOfficeInfo.Name = "butOfficeInfo";
            this.butOfficeInfo.Size = new System.Drawing.Size(100, 100);
            this.butOfficeInfo.TabIndex = 8;
            this.butOfficeInfo.Text = "Office Info";
            this.butOfficeInfo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.butOfficeInfo.UseVisualStyleBackColor = true;
            this.butOfficeInfo.Click += new System.EventHandler(this.butOfficeInfo_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Desktop;
            this.toolStrip1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("toolStrip1.BackgroundImage")));
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(797, 25);
            this.toolStrip1.TabIndex = 15;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.toolStripLabel1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(70, 22);
            this.toolStripLabel1.Text = "User Setting";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.butManageUser);
            this.panel1.Controls.Add(this.butUserAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(797, 125);
            this.panel1.TabIndex = 16;
            // 
            // butManageUser
            // 
            this.butManageUser.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("butManageUser.BackgroundImage")));
            this.butManageUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.butManageUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butManageUser.Location = new System.Drawing.Point(39, 12);
            this.butManageUser.Name = "butManageUser";
            this.butManageUser.Size = new System.Drawing.Size(100, 100);
            this.butManageUser.TabIndex = 6;
            this.butManageUser.Text = "Manage User";
            this.butManageUser.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.butManageUser.UseVisualStyleBackColor = true;
            this.butManageUser.Click += new System.EventHandler(this.butManageUser_Click);
            // 
            // butUserAdd
            // 
            this.butUserAdd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("butUserAdd.BackgroundImage")));
            this.butUserAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.butUserAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butUserAdd.Location = new System.Drawing.Point(188, 12);
            this.butUserAdd.Name = "butUserAdd";
            this.butUserAdd.Size = new System.Drawing.Size(100, 100);
            this.butUserAdd.TabIndex = 4;
            this.butUserAdd.Text = "Add User";
            this.butUserAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.butUserAdd.UseVisualStyleBackColor = true;
            this.butUserAdd.Click += new System.EventHandler(this.butUserAdd_Click);
            // 
            // toolStrip3
            // 
            this.toolStrip3.BackColor = System.Drawing.SystemColors.Desktop;
            this.toolStrip3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("toolStrip3.BackgroundImage")));
            this.toolStrip3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel3});
            this.toolStrip3.Location = new System.Drawing.Point(0, 150);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(797, 25);
            this.toolStrip3.TabIndex = 20;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.toolStripLabel3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(41, 22);
            this.toolStripLabel3.Text = "Profile";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.butOfficeInfo);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 175);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(797, 125);
            this.panel3.TabIndex = 21;
            // 
            // ucAdministration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.toolStrip3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ucAdministration";
            this.Size = new System.Drawing.Size(797, 458);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butOfficeInfo;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button butManageUser;
        private System.Windows.Forms.Button butUserAdd;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.Panel panel3;
    }
}
