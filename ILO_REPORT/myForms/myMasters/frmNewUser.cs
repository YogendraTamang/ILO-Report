using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using ILO_REPORT.businessLayer;
using ILO_REPORT.config;

namespace ILO_REPORT.myForms.myMasters
{
    public partial class frmNewUser : Form
    {
        private string sGUserName;
        private string sPass;
        public string SGUserName
        {
            get { return sGUserName; }
            set { sGUserName = value; }
        }
        businessClass bl = new businessClass();
        public frmNewUser()
        {
            InitializeComponent();
        }
        private string encryptedText(string txtForEncryption)
        {
            Encoder enc = System.Text.Encoding.Unicode.GetEncoder();
            byte[] unicodeText = new byte[txtForEncryption.Length * 2];
            enc.GetBytes(txtForEncryption.ToCharArray(), 0, txtForEncryption.Length, unicodeText, 0, true);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(unicodeText);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                sb.Append(result[i].ToString("X2"));
            }

            return sb.ToString();

        }

        private void txtConfirmPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text.Trim() != txtConfirmPassword.Text.Trim() && txtConfirmPassword.Text.Trim()!="")
            {
                MessageBox.Show("Password Mismatch", "ILO");
                txtConfirmPassword.SelectAll();
                txtConfirmPassword.Focus();
                return;
            }
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            if (nErrorCheck() != 0)
            {
                int nResult;
                string sUserName = txtUserName.Text.Trim();
                string sPassword = txtPassword.Text.Trim();
                string sEncrypPassword = encryptedText(sPassword);
                string sFullName = txtUserFullName.Text.Trim();
                string sEmail = txtUserEmail.Text.Trim();
                bool bAdminPrevilege, bAccLocked;
                bAdminPrevilege = (cbAdministrator.Checked) ? true : false;
                bAccLocked =(cbLocked.Checked) ? true : false;
                if (sGUserName != null && sGUserName != "" && sGUserName.Trim().Length > 0)
                {
                    bool bEditPass=true;
                    if (sPass == sPassword)
                    {
                        bEditPass = false;
                    }
                    nResult = bl.UpdateUser(sUserName, sEncrypPassword, sFullName, sEmail, bAdminPrevilege, bAccLocked, Global.loggedUser, bEditPass, sGUserName);
                    if (nResult == 1)
                    {
                        nResult = 5;
                    }
                }
                else
                {
                    nResult = bl.InsertNewUser(sUserName, sEncrypPassword, sFullName, sEmail, bAdminPrevilege, bAccLocked, Global.loggedUser);
                }
                if (nResult == 1)
                {
                    MessageBox.Show("New user is successfully added.","ILO");
                    this.Close();
                }
                else if (nResult == 5)
                {

                    MessageBox.Show("User is successfully edited.","ILO");
                    this.Close();
                }
            }
        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {

            if (txtUserName.Text.Trim() != "")
            {
                if (txtUserName.Text.Trim() != sGUserName)
                {
                    if (bl.isUserNamePresent(txtUserName.Text.Trim()))
                    {
                        MessageBox.Show("User Name Already Exist.\nChoose Another User Name", "ILO");
                        txtUserName.Focus();
                        return;
                    }
                }
            }
        }

        private void frmNewUser_Load(object sender, EventArgs e)
        {
            if (sGUserName != null && sGUserName != "")
            {
                if (sGUserName.Trim().Length > 0)
                {
                    this.Text = "Edit User";
                    butAdd.Text = "Save";
                    DataSet ds = new DataSet();
                    ds = bl.userInfoByUserNameDataSet(sGUserName);
                    if (ds != null)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            txtUserName.Text = ds.Tables[0].Rows[0]["name"].ToString ();
                            txtPassword.Text = (ds.Tables[0].Rows[0]["password"] is DBNull) ? "" : ds.Tables[0].Rows[0]["password"].ToString();
                            sPass = (ds.Tables[0].Rows[0]["password"] is DBNull) ? "" : ds.Tables[0].Rows[0]["password"].ToString();
                            txtConfirmPassword.Text = (ds.Tables[0].Rows[0]["password"] is DBNull) ? "" : ds.Tables[0].Rows[0]["password"].ToString();
                            txtUserFullName.Text = (ds.Tables[0].Rows[0]["full_name"] is DBNull)?"":ds.Tables[0].Rows[0]["full_name"].ToString();
                            txtUserEmail.Text = (ds.Tables[0].Rows[0]["email"] is DBNull) ? "" : ds.Tables[0].Rows[0]["email"].ToString();
                            cbAdministrator.Checked = (ds.Tables[0].Rows[0]["is_admin"] is DBNull) ? false : Convert.ToBoolean(ds.Tables[0].Rows[0]["is_admin"]);
                            cbLocked.Checked = (ds.Tables[0].Rows[0]["is_acc_locked"] is DBNull) ? false : Convert.ToBoolean(ds.Tables[0].Rows[0]["is_acc_locked"]);
                        }
                    }
                }
            }
        }
        private int nErrorCheck()
        {
            if (txtUserName.Text.Trim() == "")
            {
                MessageBox.Show("User Name Can't be blank", "ILO");
                txtUserName.Focus();
                return 0;
            }
            if (txtPassword.Text.Trim() != txtConfirmPassword.Text.Trim())
            {
                MessageBox.Show("Password Mismatch", "ILO");
                txtConfirmPassword.SelectAll();
                txtConfirmPassword.Focus();
                return 0;
            }
            return 1;
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}