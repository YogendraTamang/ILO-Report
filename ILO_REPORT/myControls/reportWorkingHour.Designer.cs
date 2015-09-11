namespace ILO_REPORT.myControls
{
    partial class ucReportWorkingHour
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucReportWorkingHour));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStripFilter3 = new System.Windows.Forms.ToolStrip();
            this.toolStripFilter2 = new System.Windows.Forms.ToolStrip();
            this.btnExport = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.comboFormType = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.dgridResult = new System.Windows.Forms.DataGridView();
            this.toolStripFilter2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgridResult)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripFilter3
            // 
            this.toolStripFilter3.AutoSize = false;
            this.toolStripFilter3.BackColor = System.Drawing.Color.SteelBlue;
            this.toolStripFilter3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripFilter3.Location = new System.Drawing.Point(0, 26);
            this.toolStripFilter3.Name = "toolStripFilter3";
            this.toolStripFilter3.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStripFilter3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStripFilter3.Size = new System.Drawing.Size(1135, 27);
            this.toolStripFilter3.TabIndex = 4;
            // 
            // toolStripFilter2
            // 
            this.toolStripFilter2.AutoSize = false;
            this.toolStripFilter2.BackColor = System.Drawing.Color.SteelBlue;
            this.toolStripFilter2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripFilter2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExport,
            this.toolStripLabel1,
            this.comboFormType,
            this.toolStripButton1});
            this.toolStripFilter2.Location = new System.Drawing.Point(0, 0);
            this.toolStripFilter2.Name = "toolStripFilter2";
            this.toolStripFilter2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStripFilter2.Size = new System.Drawing.Size(1135, 26);
            this.toolStripFilter2.TabIndex = 5;
            // 
            // btnExport
            // 
            this.btnExport.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExport.Margin = new System.Windows.Forms.Padding(15, 1, 20, 2);
            this.btnExport.Name = "btnExport";
            this.btnExport.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnExport.Size = new System.Drawing.Size(60, 23);
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(84, 23);
            this.toolStripLabel1.Text = "फारमको किसिम";
            this.toolStripLabel1.Visible = false;
            // 
            // comboFormType
            // 
            this.comboFormType.Items.AddRange(new object[] {
            "फारम क",
            "फारम ख",
            "फारम ग"});
            this.comboFormType.Margin = new System.Windows.Forms.Padding(15, 0, 1, 0);
            this.comboFormType.Name = "comboFormType";
            this.comboFormType.Size = new System.Drawing.Size(121, 26);
            this.comboFormType.Visible = false;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::ILO_REPORT.Properties.Resources.opsSearch;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Margin = new System.Windows.Forms.Padding(20, 1, 0, 2);
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(62, 23);
            this.toolStripButton1.Text = "Search";
            this.toolStripButton1.Visible = false;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // dgridResult
            // 
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgridResult.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgridResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgridResult.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(194)))), ((int)(((byte)(226)))));
            this.dgridResult.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(194)))), ((int)(((byte)(226)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgridResult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgridResult.ColumnHeadersHeight = 30;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgridResult.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgridResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgridResult.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgridResult.EnableHeadersVisualStyles = false;
            this.dgridResult.Location = new System.Drawing.Point(0, 53);
            this.dgridResult.Name = "dgridResult";
            this.dgridResult.ReadOnly = true;
            this.dgridResult.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(194)))), ((int)(((byte)(226)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgridResult.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgridResult.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgridResult.RowTemplate.Height = 18;
            this.dgridResult.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgridResult.Size = new System.Drawing.Size(1135, 356);
            this.dgridResult.StandardTab = true;
            this.dgridResult.TabIndex = 6;
            // 
            // ucReportWorkingHour
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgridResult);
            this.Controls.Add(this.toolStripFilter3);
            this.Controls.Add(this.toolStripFilter2);
            this.Name = "ucReportWorkingHour";
            this.Size = new System.Drawing.Size(1135, 409);
            this.Load += new System.EventHandler(this.ucAgeGroup_Load);
            this.toolStripFilter2.ResumeLayout(false);
            this.toolStripFilter2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgridResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripFilter3;
        private System.Windows.Forms.ToolStrip toolStripFilter2;
        private System.Windows.Forms.ToolStripButton btnExport;
        private System.Windows.Forms.DataGridView dgridResult;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox comboFormType;
        private System.Windows.Forms.ToolStripButton toolStripButton1;

    }
}
