using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DBhandler;
using System.Security.Cryptography;
using ILO_REPORT.businessLayer;
using ILO_REPORT.config;

namespace ILO_REPORT.myForms.myMasters
{
    public partial class frmLogin : Form
    {
        businessClass bl = new businessClass();
        private bool bClosed;
        private bool bOk;
        public bool BClosed
        {
            get { return bClosed; }
            set { bClosed = value; }
        }
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            bClosed = false;
            bOk = false;
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!bOk)
            {
                bClosed = true;
            }
        }

        private void butClear_Click(object sender, EventArgs e)
        {
            txtUserName.Text = "";
            txtPassword.Text = "";
        }
               
        private void invalidUserMessage()
        {
            MessageBox.Show("Invalid User Name/Password.", "ILO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            txtPassword.SelectAll();
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

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                butLogIn_Click(null, null);
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                butLogIn_Click(null, null);
            }
        }

        private void butLogIn_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string sUserName = txtUserName.Text.Trim();
            string sPassword = txtPassword.Text.Trim();
            if (sUserName == "")
            {
                MessageBox.Show("Please Input User Name Before Processing.", "ILO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               
                return;
            }
            string sEncrypPass = encryptedText(sPassword);
            ds = bl.userInfoDataSet(sUserName, sEncrypPass);
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (!(ds.Tables[0].Rows[0]["is_acc_locked"] is DBNull ? false : Convert.ToBoolean(ds.Tables[0].Rows[0]["is_acc_locked"])))
                        {
                            bOk = true;
                            Global.loggedUser = ds.Tables[0].Rows[0]["name"].ToString();
                            Global.isAdmin = ds.Tables[0].Rows[0]["is_admin"] is DBNull ? false : Convert.ToBoolean(ds.Tables[0].Rows[0]["is_admin"]);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Your account is locked.Please contact to the system administrator.", "ILO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else { invalidUserMessage(); }
                }
                else { invalidUserMessage(); }
            }
            else
            {
                invalidUserMessage();

            }
        }
        //////////////////
    }
       
}