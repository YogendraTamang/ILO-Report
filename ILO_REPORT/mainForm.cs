using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration ;
using ILO_REPORT.myControls;
using ILO_REPORT.myForms.myMasters;
using ILO_REPORT.businessLayer;


namespace ILO_REPORT
{
    public partial class mainForm : Form
    {
        businessClass bl = new businessClass();
        public mainForm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
        private void mainForm_Load(object sender, EventArgs e)
        {
            
            disposeContainer();
            toolStripReport.Visible = true;
            toolStrip2.Visible = false;
            toolStrip3.Visible = false;
            combotypeSelect.SelectedText = "फारम ग";
            
            if (sender != null)
            {
                frmLogin frm = new frmLogin();
                frm.ShowDialog();
                if (frm.BClosed)
                {
                    this.Close();
                }
                lblStatus.Text = " " + config.Global.loggedUser + "  @ " + DateTime.Now.ToLongDateString() + "  " + DateTime.Now.ToShortTimeString();
              
            }
        }

        private void mainForm_Resize(object sender, EventArgs e)
        {
        }
        private void disposeContainer()
        {
            if (spliter.Panel2.Controls.Count > 0)
            {
                foreach (Control cntrl in this.spliter.Panel2.Controls)
                {
                    if (cntrl != null)
                    {
                        cntrl.Dispose();
                    }
                }
                GC.Collect();
            }
        }

              
        private void butLogOut_Click(object sender, EventArgs e)
        {
            config.Global.loggedUser = "";
            lblStatus.Text = "";
            this.mainForm_Load(null, null);
            frmLogin frm = new frmLogin();
            frm.ShowDialog();
            
            if (frm.BClosed)
            {
                this.Close();
            }
            lblStatus.Text = " " + config.Global.loggedUser + "  @ " + DateTime.Now.ToLongDateString() + "  " + DateTime.Now.ToShortTimeString();
        }

       
        private void toolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (config.Global.isAdmin)
            {
                disposeContainer();
                ucAdministration ucAdmin = new ucAdministration();
                ucAdmin.Dock = DockStyle.Fill;
                spliter.Panel2.Controls.Add(ucAdmin);
                ucAdmin.Show();
            }
            else
            {
                MessageBox.Show("You have not privilege to enter in administration section.\n Please contact to the system administrator.");

            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
             
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutUs abtUs = new AboutUs();
            abtUs.ShowDialog();
        }
        private void colorChange(object sender)
        {
            if (sender != null)
            {
                foreach (Object btnStrip in toolStripReport.Items)
                {
                    //btnToolStrip.BackColor = Color.FromArgb(120, 160, 205);
                    if (btnStrip.GetType().Name == "ToolStripDropDownButton")
                    {
                        ToolStripDropDownButton btnDrp = (ToolStripDropDownButton)btnStrip;
                        if (sender.GetType().Name == "ToolStripMenuItem")
                        {
                            if (btnDrp.Text.Trim() == "Incoming" && (sender.ToString().Trim() == "Having Reference No" || sender.ToString().Trim() == "Without Reference No"))
                                btnDrp.BackgroundImage = Image.FromFile("btnbgHover.png");
                            else if (btnDrp.Text.Trim() == "Reports" && (sender.ToString().Trim() == "Stock Report" || sender.ToString().Trim() == "Transaction Report"))
                                btnDrp.BackgroundImage = Image.FromFile("btnbgHover.png");
                            else
                                btnDrp.BackgroundImage = Image.FromFile("imsBgBar.png");
                        }
                        else
                            btnDrp.BackgroundImage = Image.FromFile("imsBgBar.png");
                    }
                    else
                    {
                        ToolStripButton btnToolStrip = (ToolStripButton)btnStrip;
                        btnToolStrip.BackgroundImage = Image.FromFile("imsBgBar.png");
                    }
                    //
                }
                if (sender.GetType().Name != "ToolStripMenuItem")
                {
                    ToolStripButton btn = (ToolStripButton)sender;
                    //btn.BackColor = Color.FromArgb(239, 239, 173);
                    btn.BackgroundImage = Image.FromFile("btnbgHover.png");
                }
            }
            else
            {
                foreach (Object btnStrip in toolStripReport.Items)
                {
                    //btnToolStrip.BackColor = Color.FromArgb(120, 160, 205);
                    if (btnStrip.GetType().Name == "ToolStripDropDownButton")
                    {
                        ToolStripDropDownButton btnDrp = (ToolStripDropDownButton)btnStrip;
                        if (sender.GetType().Name == "ToolStripMenuItem")
                            btnDrp.BackgroundImage = Image.FromFile("btnbgHover.png");
                        else
                            btnDrp.BackgroundImage = Image.FromFile("imsBgBar.png");
                    }
                    else
                    {
                        ToolStripButton btnToolStrip = (ToolStripButton)btnStrip;
                        btnToolStrip.BackgroundImage = Image.FromFile("imsBgBar.png");
                    }
                    //
                }
            }
        }

        private void colorChange_kha(object sender)
        {
            if (sender != null)
            {
                foreach (Object btnStrip in toolStrip3.Items)
                {
                    //btnToolStrip.BackColor = Color.FromArgb(120, 160, 205);
                    if (btnStrip.GetType().Name == "ToolStripDropDownButton")
                    {
                        ToolStripDropDownButton btnDrp = (ToolStripDropDownButton)btnStrip;
                        if (sender.GetType().Name == "ToolStripMenuItem")
                        {
                            if (btnDrp.Text.Trim() == "Incoming" && (sender.ToString().Trim() == "Having Reference No" || sender.ToString().Trim() == "Without Reference No"))
                                btnDrp.BackgroundImage = Image.FromFile("btnbgHover.png");
                            else if (btnDrp.Text.Trim() == "Reports" && (sender.ToString().Trim() == "Stock Report" || sender.ToString().Trim() == "Transaction Report"))
                                btnDrp.BackgroundImage = Image.FromFile("btnbgHover.png");
                            else
                                btnDrp.BackgroundImage = Image.FromFile("imsBgBar.png");
                        }
                        else
                            btnDrp.BackgroundImage = Image.FromFile("imsBgBar.png");
                    }
                    else
                    {
                        ToolStripButton btnToolStrip = (ToolStripButton)btnStrip;
                        btnToolStrip.BackgroundImage = Image.FromFile("imsBgBar.png");
                    }
                    //
                }
                if (sender.GetType().Name != "ToolStripMenuItem")
                {
                    ToolStripButton btn = (ToolStripButton)sender;
                    //btn.BackColor = Color.FromArgb(239, 239, 173);
                    btn.BackgroundImage = Image.FromFile("btnbgHover.png");
                }
            }
            else
            {
                foreach (Object btnStrip in toolStrip3.Items)
                {
                    //btnToolStrip.BackColor = Color.FromArgb(120, 160, 205);
                    if (btnStrip.GetType().Name == "ToolStripDropDownButton")
                    {
                        ToolStripDropDownButton btnDrp = (ToolStripDropDownButton)btnStrip;
                        if (sender.GetType().Name == "ToolStripMenuItem")
                            btnDrp.BackgroundImage = Image.FromFile("btnbgHover.png");
                        else
                            btnDrp.BackgroundImage = Image.FromFile("imsBgBar.png");
                    }
                    else
                    {
                        ToolStripButton btnToolStrip = (ToolStripButton)btnStrip;
                        btnToolStrip.BackgroundImage = Image.FromFile("imsBgBar.png");
                    }
                    //
                }
            }
        }

        private void colorChange_ka(object sender)
        {
            if (sender != null)
            {
                foreach (Object btnStrip in toolStrip2.Items)
                {
                    //btnToolStrip.BackColor = Color.FromArgb(120, 160, 205);
                    if (btnStrip.GetType().Name == "ToolStripDropDownButton")
                    {
                        ToolStripDropDownButton btnDrp = (ToolStripDropDownButton)btnStrip;
                        if (sender.GetType().Name == "ToolStripMenuItem")
                        {
                            if (btnDrp.Text.Trim() == "Incoming" && (sender.ToString().Trim() == "Having Reference No" || sender.ToString().Trim() == "Without Reference No"))
                                btnDrp.BackgroundImage = Image.FromFile("btnbgHover.png");
                            else if (btnDrp.Text.Trim() == "Reports" && (sender.ToString().Trim() == "Stock Report" || sender.ToString().Trim() == "Transaction Report"))
                                btnDrp.BackgroundImage = Image.FromFile("btnbgHover.png");
                            else
                                btnDrp.BackgroundImage = Image.FromFile("imsBgBar.png");
                        }
                        else
                            btnDrp.BackgroundImage = Image.FromFile("imsBgBar.png");
                    }
                    else
                    {
                        ToolStripButton btnToolStrip = (ToolStripButton)btnStrip;
                        btnToolStrip.BackgroundImage = Image.FromFile("imsBgBar.png");
                    }
                    //
                }
                if (sender.GetType().Name != "ToolStripMenuItem")
                {
                    ToolStripButton btn = (ToolStripButton)sender;
                    //btn.BackColor = Color.FromArgb(239, 239, 173);
                    btn.BackgroundImage = Image.FromFile("btnbgHover.png");
                }
            }
            else
            {
                foreach (Object btnStrip in toolStrip2.Items)
                {
                    //btnToolStrip.BackColor = Color.FromArgb(120, 160, 205);
                    if (btnStrip.GetType().Name == "ToolStripDropDownButton")
                    {
                        ToolStripDropDownButton btnDrp = (ToolStripDropDownButton)btnStrip;
                        if (sender.GetType().Name == "ToolStripMenuItem")
                            btnDrp.BackgroundImage = Image.FromFile("btnbgHover.png");
                        else
                            btnDrp.BackgroundImage = Image.FromFile("imsBgBar.png");
                    }
                    else
                    {
                        ToolStripButton btnToolStrip = (ToolStripButton)btnStrip;
                        btnToolStrip.BackgroundImage = Image.FromFile("imsBgBar.png");
                    }
                    //
                }
            }
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            colorChange(sender);
            disposeContainer();
            ucReport ucReportOne = new ucReport();
            ucReportOne.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ucReportOne);
            ucReportOne.Show();
        }

        private void combotypeSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sText = combotypeSelect.SelectedItem.ToString();
            if (sText == "फारम क")
            {
                toolStripReport.Visible = false;
                toolStrip2.Visible = true;
                toolStrip3.Visible = false;
            }
            else if (sText == "फारम ख")
            {
               
                toolStripReport.Visible = false;
                toolStrip2.Visible = false;
                toolStrip3.Visible = true;
            }
            else if (sText == "फारम ग")
            {
               
                toolStripReport.Visible = true;
                toolStrip2.Visible = false;
                toolStrip3.Visible = false;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            colorChange(sender);
            disposeContainer();
            ucReportOccupation_ga ReportOccupation_ga = new ucReportOccupation_ga(3);
            ReportOccupation_ga.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportOccupation_ga);
            ReportOccupation_ga.Show();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            colorChange(sender);
            disposeContainer();
            ucReportReligion_ga ReportReligion_ga = new ucReportReligion_ga(3);
            ReportReligion_ga.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportReligion_ga);
            ReportReligion_ga.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            colorChange(sender);
            disposeContainer();
            ucReportCast_ga ReportCast_ga = new ucReportCast_ga(3);
            ReportCast_ga.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportCast_ga);
            ReportCast_ga.Show();

        }

    

        private void toolStripButton13_Click_1(object sender, EventArgs e)
        {
             colorChange(sender);
            disposeContainer();
            ucReportStayType_ga ReportStayType_ga = new ucReportStayType_ga(3);
            ReportStayType_ga.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportStayType_ga);
            ReportStayType_ga.Show();
        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            colorChange(sender);
            disposeContainer();
            ucReportFamilyInfo_ga ReportFamilyInfo_ga = new ucReportFamilyInfo_ga();
            ReportFamilyInfo_ga.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportFamilyInfo_ga);
            ReportFamilyInfo_ga.Show();

        }

        private void toolStripButton15_Click(object sender, EventArgs e)
        {
            colorChange(sender);
            disposeContainer();
            ucReportLabourWentHow ReportLabourWentHow_ga = new ucReportLabourWentHow();
            ReportLabourWentHow_ga.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportLabourWentHow_ga);
            ReportLabourWentHow_ga.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            colorChange_ka(sender);
            disposeContainer();
            ucReportOccupation_ga ReportOccupation_Ka = new ucReportOccupation_ga(1);
            ReportOccupation_Ka.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportOccupation_Ka);
            ReportOccupation_Ka.Show();
            
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            colorChange_ka(sender);
            disposeContainer();
            ucReportEducation_Ka ReportEducation_Ka = new ucReportEducation_Ka(1);
            ReportEducation_Ka.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportEducation_Ka);
            ReportEducation_Ka.Show();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            colorChange_ka(sender);
            disposeContainer();
            ucReportChildLabourStatus_Ka ReportChildLabour_Ka = new ucReportChildLabourStatus_Ka(1);
            ReportChildLabour_Ka.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportChildLabour_Ka);
            ReportChildLabour_Ka.Show();
        }

        private void toolStripButton16_Click(object sender, EventArgs e)
        {
            colorChange(sender);
            disposeContainer();
            ucReportLabourTaken_Ka ReportLabourTaken_Ka = new ucReportLabourTaken_Ka(3);
            ReportLabourTaken_Ka.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportLabourTaken_Ka);
            ReportLabourTaken_Ka.Show();
        }

        private void toolStripButton17_Click(object sender, EventArgs e)
        {
            colorChange_ka(sender);
            disposeContainer();
            ucReportLabourTaken_Ka ReportLabourTaken_Ka = new ucReportLabourTaken_Ka(1);
            ReportLabourTaken_Ka.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportLabourTaken_Ka);
            ReportLabourTaken_Ka.Show();
        }

        private void toolStripButton20_Click(object sender, EventArgs e)
        {
            colorChange_ka(sender);
            disposeContainer();
            ucReportCast_ga ReportCast_ka = new ucReportCast_ga(1);
            ReportCast_ka.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportCast_ka);
            ReportCast_ka.Show();
        }

        private void toolStripButton18_Click(object sender, EventArgs e)
        {
            colorChange_ka(sender);
            disposeContainer();
            ucReportReligion_ga ReportReligion_ka = new ucReportReligion_ga(1);
            ReportReligion_ka.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportReligion_ka);
            ReportReligion_ka.Show();
        }

        private void toolStripButton19_Click(object sender, EventArgs e)
        {
            colorChange_ka(sender);
            disposeContainer();
            ucReportStayType_ga ReportStayType_ka = new ucReportStayType_ga(1);
            ReportStayType_ka.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportStayType_ka);
            ReportStayType_ka.Show();
        }

        private void toolStripButton21_Click(object sender, EventArgs e)
        {
            colorChange_ka(sender);
            disposeContainer();
            ucReportJobAgreeMent ReportJobAgreement_ka = new ucReportJobAgreeMent(1);
            ReportJobAgreement_ka.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportJobAgreement_ka);
            ReportJobAgreement_ka.Show();
        }

        private void toolStripButton22_Click(object sender, EventArgs e)
        {
            colorChange(sender);
            disposeContainer();
            ucReportJobAgreeMent ReportJobAgreement_ga = new ucReportJobAgreeMent(3);
            ReportJobAgreement_ga.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportJobAgreement_ga);
            ReportJobAgreement_ga.Show();
        }

        private void toolStripButton23_Click(object sender, EventArgs e)
        {
            colorChange_ka(sender);
            disposeContainer();
            ucReportJobAgreeMentPoints ReportJobAgreementPoints_ka = new ucReportJobAgreeMentPoints(1);
            ReportJobAgreementPoints_ka.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportJobAgreementPoints_ka);
            ReportJobAgreementPoints_ka.Show();
        }

        private void toolStripButton27_Click(object sender, EventArgs e)
        {
            colorChange_ka(sender);
            disposeContainer();
            ucReportCastChild ReportCastChild_ka = new ucReportCastChild(1);
            ReportCastChild_ka.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportCastChild_ka);
            ReportCastChild_ka.Show();
        }

        private void toolStripButton25_Click(object sender, EventArgs e)
        {
            colorChange_ka(sender);
            disposeContainer();
            ucReportReligionChild ReportReligionChild_ka = new ucReportReligionChild(1);
            ReportReligionChild_ka.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportReligionChild_ka);
            ReportReligionChild_ka.Show();
        }

        private void toolStripButton26_Click(object sender, EventArgs e)
        {
            colorChange_ka(sender);
            disposeContainer();
            ucReportStayTypeChild ReportStayTypeChild_ka = new ucReportStayTypeChild(1);
            ReportStayTypeChild_ka.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportStayTypeChild_ka);
            ReportStayTypeChild_ka.Show();
        }

        private void toolStripButton28_Click(object sender, EventArgs e)
        {
            colorChange_ka(sender);
            disposeContainer();
            ucReportAgeGroup ReportAgeGroupChild_ka = new ucReportAgeGroup(1);
            ReportAgeGroupChild_ka.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportAgeGroupChild_ka);
            ReportAgeGroupChild_ka.Show();
        }

        private void toolStripButton29_Click(object sender, EventArgs e)
        {
            colorChange_ka(sender);
            disposeContainer();
            ucReportBirthRegistration_ka ReportBRegChild_ka = new ucReportBirthRegistration_ka(1);
            ReportBRegChild_ka.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportBRegChild_ka);
            ReportBRegChild_ka.Show();
        }

        private void toolStripButton30_Click(object sender, EventArgs e)
        {
            colorChange_ka(sender);
            disposeContainer();
            ucReportEducationStatus ReportEStatusChild_ka = new ucReportEducationStatus(1);
            ReportEStatusChild_ka.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportEStatusChild_ka);
            ReportEStatusChild_ka.Show();
        }

        private void toolStripButton31_Click(object sender, EventArgs e)
        {
            colorChange_ka(sender);
            disposeContainer();
            ucReportEducationExpense ReportESExpenseChild_ka = new ucReportEducationExpense(1);
            ReportESExpenseChild_ka.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportESExpenseChild_ka);
            ReportESExpenseChild_ka.Show();
        }

        private void toolStripButton34_Click(object sender, EventArgs e)
        {
            colorChange_ka(sender);
            disposeContainer();
            ucReportSalaryTIme ReportSTimeChild_ka = new ucReportSalaryTIme(1);
            ReportSTimeChild_ka.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportSTimeChild_ka);
            ReportSTimeChild_ka.Show();
        }

        private void toolStripButton33_Click(object sender, EventArgs e)
        {
            colorChange_ka(sender);
            disposeContainer();
            ucReportSalaryReceiver ReportSalaryReceiverChild_ka = new ucReportSalaryReceiver(1);
            ReportSalaryReceiverChild_ka.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportSalaryReceiverChild_ka);
            ReportSalaryReceiverChild_ka.Show();
        }

        private void toolStripButton32_Click(object sender, EventArgs e)
        {
            colorChange_ka(sender);
            disposeContainer();
            ucReportSalary ReportSalaryChild_ka = new ucReportSalary(1);
            ReportSalaryChild_ka.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportSalaryChild_ka);
            ReportSalaryChild_ka.Show();
        }

        private void toolStripButton35_Click(object sender, EventArgs e)
        {
            colorChange_ka(sender);
            disposeContainer();
            ucReportFamilyCOntact ReportFamilyCOntact_ka = new ucReportFamilyCOntact(1);
            ReportFamilyCOntact_ka.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportFamilyCOntact_ka);
            ReportFamilyCOntact_ka.Show();
        }

        private void toolStripButton36_Click(object sender, EventArgs e)
        {
            //काम गर्न थालेको समय
            colorChange_ka(sender);
            disposeContainer();
            ucReportWorkingStart ReportWorkStart_ka = new ucReportWorkingStart(1);
            ReportWorkStart_ka.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportWorkStart_ka);
            ReportWorkStart_ka.Show();
        }

        private void toolStripButton37_Click(object sender, EventArgs e)
        {
            colorChange_ka(sender);
            disposeContainer();
            ucReportWorkingHour ReportWorkHour_ka = new ucReportWorkingHour(1);
            ReportWorkHour_ka.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportWorkHour_ka);
            ReportWorkHour_ka.Show();

        }

        private void toolStripButton38_Click(object sender, EventArgs e)
        {
            colorChange_ka(sender);
            disposeContainer();
            ucReportWorkingTimeME ReportWorkTimeME_ka = new ucReportWorkingTimeME(1);
            ReportWorkTimeME_ka.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportWorkTimeME_ka);
            ReportWorkTimeME_ka.Show();


        }

        private void toolStripButton39_Click(object sender, EventArgs e)
        {
            colorChange_ka(sender);
            disposeContainer();
            ucReportHateWay ReportHateWay_ka = new ucReportHateWay(1);
            ReportHateWay_ka.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportHateWay_ka);
            ReportHateWay_ka.Show();
        }

        private void toolStripButton24_Click(object sender, EventArgs e)
        {
            colorChange_ka(sender);
            disposeContainer();
            ucReportLabourLeaveHOme_Ka ReportLLeaveHome_ka = new ucReportLabourLeaveHOme_Ka(1);
            ReportLLeaveHome_ka.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportLLeaveHome_ka);
            ReportLLeaveHome_ka.Show();
        }

        private void toolStripButton40_Click(object sender, EventArgs e)
        {
            colorChange_ka(sender);
            disposeContainer();
            ucReportLabourNoReturnHOme_Ka ReportLNoReturnHome_ka = new ucReportLabourNoReturnHOme_Ka(1);
            ReportLNoReturnHome_ka.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportLNoReturnHome_ka);
            ReportLNoReturnHome_ka.Show();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            colorChange_kha(sender);
            disposeContainer();
            ucReportLabourNoReturnHOme_Ka ReportLNoReturnHome_kha = new ucReportLabourNoReturnHOme_Ka(2);
            ReportLNoReturnHome_kha.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportLNoReturnHome_kha);
            ReportLNoReturnHome_kha.Show();
        }

        private void toolStripButton41_Click(object sender, EventArgs e)
        {
            colorChange_ka(sender);
            disposeContainer();
            ucReportLabourFacility_Ka ReportFacility_ka = new ucReportLabourFacility_Ka(1);
            ReportFacility_ka.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportFacility_ka);
            ReportFacility_ka.Show();
        }

        private void toolStripButton42_Click(object sender, EventArgs e)
        {
            colorChange_ka(sender);
            disposeContainer();
            ucReportEducationCertificateStatus ReportCertificate_ka = new ucReportEducationCertificateStatus(1);
            ReportCertificate_ka.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportCertificate_ka);
            ReportCertificate_ka.Show();
        }

        private void toolStripButton43_Click(object sender, EventArgs e)
        {
            colorChange_ka(sender);
            disposeContainer();
            ucReportHealthFacility_Ka ReportHealthFacility_ka = new ucReportHealthFacility_Ka(1);
            ReportHealthFacility_ka.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportHealthFacility_ka);
            ReportHealthFacility_ka.Show();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            colorChange_ka(sender);
            disposeContainer();
            ucReportCLabourIndividualDetails ReportIndividuals_ka = new ucReportCLabourIndividualDetails(1);
            ReportIndividuals_ka.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportIndividuals_ka);
            ReportIndividuals_ka.Show();
        }

        private void toolStripButton45_Click(object sender, EventArgs e)
        {
            colorChange_ka(sender);
            disposeContainer();
            ucReportCLabourIndividualDetails_Kha ReportIndividuals_kha = new ucReportCLabourIndividualDetails_Kha(2);
            ReportIndividuals_kha.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportIndividuals_kha);
            ReportIndividuals_kha.Show();
        }

        private void toolStripButton9_Click_1(object sender, EventArgs e)
        {
            colorChange_kha(sender);
            disposeContainer();
            ucReportLabourNoReturnHOme_Ka ReportLNoReturnHome_kha = new ucReportLabourNoReturnHOme_Ka(2);
            ReportLNoReturnHome_kha.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportLNoReturnHome_kha);
            ReportLNoReturnHome_kha.Show();
        }

        private void toolStripButton46_Click(object sender, EventArgs e)
        {
            colorChange_ka(sender);
            disposeContainer();
            ucReportOccupation_ga ReportOccupation_Kha = new ucReportOccupation_ga(2);
            ReportOccupation_Kha.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportOccupation_Kha);
            ReportOccupation_Kha.Show();
        }

        private void toolStripButton47_Click(object sender, EventArgs e)
        {
            colorChange_ka(sender);
            disposeContainer();
            ucReportEducation_Ka ReportEducation_Ka = new ucReportEducation_Ka(2);
            ReportEducation_Ka.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportEducation_Ka);
            ReportEducation_Ka.Show();
        }

        private void toolStripButton48_Click(object sender, EventArgs e)
        {
            colorChange_ka(sender);
            disposeContainer();
            ucReportChildLabourStatus_Ka ReportChildLabour_Ka = new ucReportChildLabourStatus_Ka(2);
            ReportChildLabour_Ka.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportChildLabour_Ka);
            ReportChildLabour_Ka.Show();
        }

        private void toolStripButton49_Click(object sender, EventArgs e)
        {
            colorChange_ka(sender);
            disposeContainer();
            ucReportLabourTaken_Ka ReportLabourTaken_Ka = new ucReportLabourTaken_Ka(2);
            ReportLabourTaken_Ka.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportLabourTaken_Ka);
            ReportLabourTaken_Ka.Show();
        }

        private void toolStripButton50_Click(object sender, EventArgs e)
        {
            colorChange_ka(sender);
            disposeContainer();
            ucReportJobAgreeMent ReportJobAgreement_ka = new ucReportJobAgreeMent(2);
            ReportJobAgreement_ka.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportJobAgreement_ka);
            ReportJobAgreement_ka.Show();
        }

        private void toolStripButton51_Click(object sender, EventArgs e)
        {
            colorChange_ka(sender);
            disposeContainer();
            ucReportJobAgreeMentPoints ReportJobAgreementPoints_ka = new ucReportJobAgreeMentPoints(2);
            ReportJobAgreementPoints_ka.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportJobAgreementPoints_ka);
            ReportJobAgreementPoints_ka.Show();
        }

        private void toolStripButton52_Click(object sender, EventArgs e)
        {
            colorChange_ka(sender);
            disposeContainer();
            ucReportAgeGroup ReportAgeGroupChild_ka = new ucReportAgeGroup(2);
            ReportAgeGroupChild_ka.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportAgeGroupChild_ka);
            ReportAgeGroupChild_ka.Show();
        }

        private void toolStripButton53_Click(object sender, EventArgs e)
        {
            colorChange_ka(sender);
            disposeContainer();
            ucReportBirthRegistration_ka ReportBRegChild_ka = new ucReportBirthRegistration_ka(2);
            ReportBRegChild_ka.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportBRegChild_ka);
            ReportBRegChild_ka.Show();
        }

        private void toolStripButton54_Click(object sender, EventArgs e)
        {
            colorChange_ka(sender);
            disposeContainer();
            ucReportEducationStatus ReportEStatusChild_ka = new ucReportEducationStatus(2);
            ReportEStatusChild_ka.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportEStatusChild_ka);
            ReportEStatusChild_ka.Show();
        }

        private void toolStripButton55_Click(object sender, EventArgs e)
        {
            colorChange_ka(sender);
            disposeContainer();
            ucReportEducationExpense ReportESExpenseChild_ka = new ucReportEducationExpense(2);
            ReportESExpenseChild_ka.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportESExpenseChild_ka);
            ReportESExpenseChild_ka.Show();
        }

        private void toolStripButton56_Click(object sender, EventArgs e)
        {
            colorChange_ka(sender);
            disposeContainer();
            ucReportSalary ReportSalaryChild_ka = new ucReportSalary(2);
            ReportSalaryChild_ka.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportSalaryChild_ka);
            ReportSalaryChild_ka.Show();
        }

        private void toolStripButton57_Click(object sender, EventArgs e)
        {
            colorChange_ka(sender);
            disposeContainer();
            ucReportSalaryTIme ReportSTimeChild_ka = new ucReportSalaryTIme(2);
            ReportSTimeChild_ka.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportSTimeChild_ka);
            ReportSTimeChild_ka.Show();
        }

        private void toolStripButton58_Click(object sender, EventArgs e)
        {
            colorChange_ka(sender);
            disposeContainer();
            ucReportSalaryReceiver ReportSalaryReceiverChild_ka = new ucReportSalaryReceiver(2);
            ReportSalaryReceiverChild_ka.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportSalaryReceiverChild_ka);
            ReportSalaryReceiverChild_ka.Show();
        }

        private void toolStripButton59_Click(object sender, EventArgs e)
        {
            colorChange_ka(sender);
            disposeContainer();
            ucReportFamilyCOntact ReportFamilyCOntact_ka = new ucReportFamilyCOntact(2);
            ReportFamilyCOntact_ka.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportFamilyCOntact_ka);
            ReportFamilyCOntact_ka.Show();

        }

        private void toolStripButton60_Click(object sender, EventArgs e)
        {
            //काम गर्न थालेको समय
            colorChange_ka(sender);
            disposeContainer();
            ucReportWorkingStart ReportWorkStart_ka = new ucReportWorkingStart(2);
            ReportWorkStart_ka.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportWorkStart_ka);
            ReportWorkStart_ka.Show();
        }

        private void toolStripButton61_Click(object sender, EventArgs e)
        {
            colorChange_ka(sender);
            disposeContainer();
            ucReportWorkingHour ReportWorkHour_ka = new ucReportWorkingHour(2);
            ReportWorkHour_ka.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportWorkHour_ka);
            ReportWorkHour_ka.Show();

        }

        private void toolStripButton62_Click(object sender, EventArgs e)
        {
            colorChange_ka(sender);
            disposeContainer();
            ucReportWorkingTimeME ReportWorkTimeME_ka = new ucReportWorkingTimeME(2);
            ReportWorkTimeME_ka.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportWorkTimeME_ka);
            ReportWorkTimeME_ka.Show();
        }

        private void toolStripButton63_Click(object sender, EventArgs e)
        {
            colorChange_ka(sender);
            disposeContainer();
            ucReportLabourLeaveHOme_Ka ReportLLeaveHome_ka = new ucReportLabourLeaveHOme_Ka(2);
            ReportLLeaveHome_ka.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportLLeaveHome_ka);
            ReportLLeaveHome_ka.Show();
        }

        private void toolStripButton64_Click(object sender, EventArgs e)
        {
            colorChange_ka(sender);
            disposeContainer();
            ucReportHateWay ReportHateWay_ka = new ucReportHateWay(2);
            ReportHateWay_ka.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportHateWay_ka);
            ReportHateWay_ka.Show();
        }

        private void toolStripButton65_Click(object sender, EventArgs e)
        {
            colorChange_ka(sender);
            disposeContainer();
            ucReportLabourNoReturnHOme_Ka ReportLNoReturnHome_ka = new ucReportLabourNoReturnHOme_Ka(2);
            ReportLNoReturnHome_ka.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportLNoReturnHome_ka);
            ReportLNoReturnHome_ka.Show();
        }

        private void toolStripButton66_Click(object sender, EventArgs e)
        {
            colorChange_ka(sender);
            disposeContainer();
            ucReportLabourFacility_Ka ReportFacility_ka = new ucReportLabourFacility_Ka(2);
            ReportFacility_ka.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportFacility_ka);
            ReportFacility_ka.Show();
        }

        private void toolStripButton67_Click(object sender, EventArgs e)
        {
            colorChange_ka(sender);
            disposeContainer();
            ucReportEducationCertificateStatus ReportCertificate_ka = new ucReportEducationCertificateStatus(2);
            ReportCertificate_ka.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportCertificate_ka);
            ReportCertificate_ka.Show();
        }

        private void toolStripButton68_Click(object sender, EventArgs e)
        {
            colorChange_ka(sender);
            disposeContainer();
            ucReportHealthFacility_Ka ReportHealthFacility_ka = new ucReportHealthFacility_Ka(2);
            ReportHealthFacility_ka.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportHealthFacility_ka);
            ReportHealthFacility_ka.Show();
        }

        private void toolStripButton69_Click(object sender, EventArgs e)
        {
            colorChange_ka(sender);
            disposeContainer();
            ucReportReligion_ga ReportReligion_ka = new ucReportReligion_ga(2);
            ReportReligion_ka.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportReligion_ka);
            ReportReligion_ka.Show();

        }

        private void toolStripButton70_Click(object sender, EventArgs e)
        {
            colorChange_ka(sender);
            disposeContainer();
            ucReportStayType_ga ReportStayType_ka = new ucReportStayType_ga(2);
            ReportStayType_ka.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportStayType_ka);
            ReportStayType_ka.Show();
        }

        private void toolStripButton74_Click(object sender, EventArgs e)
        {
            colorChange_ka(sender);
            disposeContainer();
            ucReportCast_ga ReportCast_ka = new ucReportCast_ga(2);
            ReportCast_ka.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportCast_ka);
            ReportCast_ka.Show();
        }

        private void spliter_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            colorChange_ka(sender);
            disposeContainer();
            ucReportEmployer Report_Emp = new ucReportEmployer(1);
            Report_Emp.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(Report_Emp);
            Report_Emp.Show();

        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            colorChange_ka(sender);
            disposeContainer();
            ucReportLabourType ReportLabour = new ucReportLabourType(2);
            ReportLabour.Dock = DockStyle.Fill;
            spliter.Panel2.Controls.Add(ReportLabour);
            ReportLabour.Show();
        }
   

    }
}
