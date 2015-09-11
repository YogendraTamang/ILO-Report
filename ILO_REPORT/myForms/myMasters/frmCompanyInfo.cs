using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ILO_REPORT.businessLayer;
using ILO_REPORT.config;

namespace ILO_REPORT.myForms.myMasters
{
    public partial class frmCompanyInfo : Form
    {
        businessClass bl = new businessClass();
        public frmCompanyInfo()
        {
            InitializeComponent();
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butClear_Click(object sender, EventArgs e)
        {
            txtCompanyName.Text = "";
            txtAddress.Text = "";
            txtCountry.Text = "";
            txtEmail.Text = "";
            txtFaxNo.Text = "";
            txtPhone.Text = "";
            txtPOB.Text = "";
            txtTownCity.Text = "";
            txtVatNo.Text = "";
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            int nResult = bl.UpdateCompany(txtCompanyName.Text, 
                txtAddress.Text,txtPhone.Text, txtFaxNo.Text, txtPOB.Text, txtEmail.Text, txtVatNo.Text,Global.loggedUser);

            frmCompanyInfo_Load(null, null);
            MessageBox.Show("Data Successfully updated.", "ILO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }
         
        private void frmCompanyInfo_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds = bl.GetCompanyInfo();
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtCompanyName.Text = (ds.Tables[0].Rows[0]["company_name"] is DBNull) ? "" : ds.Tables[0].Rows[0]["company_name"].ToString();
                        txtAddress.Text = (ds.Tables[0].Rows[0]["address"] is DBNull) ? "" : ds.Tables[0].Rows[0]["address"].ToString();
                        txtCountry.Text = (ds.Tables[0].Rows[0]["country_name"] is DBNull) ? "" : ds.Tables[0].Rows[0]["country_name"].ToString();
                        txtEmail.Text = (ds.Tables[0].Rows[0]["email"] is DBNull) ? "" : ds.Tables[0].Rows[0]["email"].ToString();
                        txtFaxNo.Text = (ds.Tables[0].Rows[0]["fax"] is DBNull) ? "" : ds.Tables[0].Rows[0]["fax"].ToString();
                        txtPhone.Text = (ds.Tables[0].Rows[0]["phone"] is DBNull) ? "" : ds.Tables[0].Rows[0]["phone"].ToString();
                        txtPOB.Text = (ds.Tables[0].Rows[0]["pobox"] is DBNull) ? "" : ds.Tables[0].Rows[0]["pobox"].ToString();
                        txtTownCity.Text = (ds.Tables[0].Rows[0]["town_city"] is DBNull) ? "" : ds.Tables[0].Rows[0]["town_city"].ToString();
                        txtVatNo.Text = (ds.Tables[0].Rows[0]["vat_no"] is DBNull) ? "" : ds.Tables[0].Rows[0]["vat_no"].ToString();
                    }
                }
            }
        }
    }
}