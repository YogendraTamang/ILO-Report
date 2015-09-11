using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ILO_REPORT.myForms.myMasters;
using ILO_REPORT.businessLayer;

namespace ILO_REPORT.myForms.myMasters
{
    public partial class frmManageUser : Form
    {
        businessClass bl = new businessClass();
        public frmManageUser()
        {
            InitializeComponent();
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            frmNewUser frmUser = new frmNewUser();
            frmUser.ShowDialog();
            frmManageUser_Load(null, null);
        }

        private void frmManageUser_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds = bl.userInfoDataSet();
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dgridManageUser.DataSource = ds.Tables[0];
                    }
                }
            }
        }

        private void dgridManageUser_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int nRow = dgridManageUser.CurrentRow.Index;
            string sUserName = dgridManageUser.Rows[nRow].Cells["User Name"].Value.ToString();
            if (sUserName.Trim().Length > 0)
            {
                frmNewUser frm = new frmNewUser();
                frm.SGUserName = sUserName;
                frm.ShowDialog();
                frmManageUser_Load(null, null);
            }
        }

        private void butEdit_Click(object sender, EventArgs e)
        {
            int nRow = dgridManageUser.CurrentRow.Index;
            string sUserName = dgridManageUser.Rows[nRow].Cells["User Name"].Value.ToString();
            if (sUserName.Trim().Length > 0)
            {
                frmNewUser frm = new frmNewUser();
                frm.SGUserName = sUserName;
                frm.ShowDialog();
                frmManageUser_Load(null, null);
            }
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}