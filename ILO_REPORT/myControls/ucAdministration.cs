using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ILO_REPORT.myForms.myMasters;

namespace ILO_REPORT.myControls
{
    public partial class ucAdministration : UserControl
    {
        public ucAdministration()
        {
            InitializeComponent();
        }

        private void butUserAdd_Click(object sender, EventArgs e)
        {
            frmNewUser frmUser = new frmNewUser();
            frmUser.ShowDialog();
        }      

        private void butManageUser_Click(object sender, EventArgs e)
        {
            frmManageUser frmMUser = new frmManageUser();
            frmMUser.ShowDialog();
        }

       
        private void butOfficeInfo_Click(object sender, EventArgs e)
        {
            frmCompanyInfo frm = new frmCompanyInfo();
            frm.ShowDialog();
        }



    }
}
