using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ILO_REPORT.businessLayer;
using ILO_REPORT.myForms;
using ILO_REPORT.myForms.myMasters;
using ILO_REPORT.myControls;
using Microsoft.VisualBasic;
using Excel = Microsoft.Office.Interop.Excel;
using ILO_REPORT.config;

namespace ILO_REPORT.myControls
{
    public partial class ucReportBirthRegistration_ka : UserControl
    {
        businessClass bl = new businessClass();
        private int pTypeID;
        //public ucReportReligion_ga()
        //{
        //    InitializeComponent();
        //}
        public ucReportBirthRegistration_ka(int fldTypeID)
        {
            InitializeComponent();
            pTypeID = fldTypeID;
        }
               
        private void btnExport_Click(object sender, EventArgs e)
        {
            Excel.ApplicationClass excelSheet = new Excel.ApplicationClass();
            excelSheet.Application.Workbooks.Add(true);
            int columnIndex = 0;
            foreach (DataGridViewColumn column in dgridResult.Columns)
            {
                if (column.HeaderText.Trim() != "" && column.Visible == true)
                {
                    columnIndex++;
                    excelSheet.Cells[1, columnIndex] = column.HeaderText;
                }
            }
            int rowIndex = 0;
            foreach (DataGridViewRow row in dgridResult.Rows)
            {
                rowIndex++;
                columnIndex = 0;
                foreach (DataGridViewColumn column in dgridResult.Columns)
                {
                    if (column.HeaderText.Trim() != "" && column.Visible == true)
                    {
                        columnIndex++;
                        excelSheet.Cells[rowIndex + 1, columnIndex] = row.Cells[column.Name].FormattedValue;
                       
                    }
                }
            }
            excelSheet.Visible = true;
            Excel.Worksheet workSheet = (Excel.Worksheet)excelSheet.ActiveSheet;
            Excel.Range titleRange = excelSheet.get_Range(workSheet.Cells[1, 1], workSheet.Cells[1, columnIndex]);
            titleRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);
        }

        private void ucReportBirthRegistration_Load(object sender, EventArgs e)
        {
            try
            {
                comboFormType.SelectedText = "फारम ग";
                loadData(pTypeID);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString(), "ILO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }
        private void loadData(int fldTypeID)
        {
            string cond = fldTypeID.ToString();
            DataSet ds = bl.GetBirthRegistraionChildLabour(cond);
            //DataTable dtbl = new DataTable();
            //dtbl.Columns.Add("fldLabourCause");
            if (ds != null && ds.Tables.Count > 0)
            {

                if (ds.Tables[0].Rows.Count <= 0)
                {
                    dgridResult.DataSource = ds.Tables[0];
                    MessageBox.Show("No Records", "ILO");
                }
                else
                {
                    DataTable dtTemp = new DataTable();
                    dtTemp.Columns.Add("जन्म दर्ता");
                    dtTemp.Columns.Add("बालक");
                    dtTemp.Columns.Add("बालिका");
                    dtTemp.Columns.Add("लिङ्ग प्राप्त नभएको");
                    dtTemp.Columns.Add("प्रतिशत");

                    DataRow[] drM = ds.Tables[0].Select("fldchildGenderID=2");
                    DataRow[] drF = ds.Tables[0].Select("fldchildGenderID=3");
                    DataRow[] drN = ds.Tables[0].Select("fldchildGenderID=1");


                    int YchildM = int.Parse(drM[0]["total"].ToString());
                    int NchildM = int.Parse(drM[1]["total"].ToString());

                    int YchildF = int.Parse(drF[0]["total"].ToString());
                    int NchildF = int.Parse(drF[1]["total"].ToString());

                    int YchildN = int.Parse(drN[0]["total"].ToString());
                    int NchildN = int.Parse(drN[1]["total"].ToString());

                    float total = float.Parse((YchildF + YchildM + YchildN + NchildF + NchildM + NchildN).ToString());


                    dtTemp.Rows.Add("छ", YchildM, YchildF, YchildN, (((YchildF + YchildM + YchildN) / total) * 100.0).ToString("0.00"));
                    dtTemp.Rows.Add("छैन", NchildM, NchildF, NchildN, (((NchildF + NchildM + NchildN) / total) * 100.0).ToString("0.00"));
                   

                    dgridResult.DataSource = dtTemp;
                   
                }
               

            }
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string sText = comboFormType.SelectedText;
            if(sText=="फारम क"){
                loadData(1);
            }
            else if (sText == "फारम ख") {
                loadData(2);
            }
            else if (sText == "फारम ग") {
                loadData(3);
            }
          

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string condition = pTypeID.ToString();

            int sPlace = comboLocation.SelectedIndex;
            if (sPlace == 0)
                condition += " and fldLocation=N'धुलिखेल'";
            else if (sPlace == 1)
                condition += " and fldLocation=N'पनौती'";
            DataSet ds = bl.GetBirthRegistraionChildLabour(condition);
            //DataTable dtbl = new DataTable();
            //dtbl.Columns.Add("fldLabourCause");
            if (ds != null && ds.Tables.Count > 0)
            {

                if (ds.Tables[0].Rows.Count <= 0)
                {
                    dgridResult.DataSource = ds.Tables[0];
                    MessageBox.Show("No Records", "ILO");
                }
                else
                {
                    DataTable dtTemp = new DataTable();
                    dtTemp.Columns.Add("जन्म दर्ता");
                    dtTemp.Columns.Add("बालक");
                    dtTemp.Columns.Add("बालिका");
                    dtTemp.Columns.Add("लिङ्ग प्राप्त नभएको");
                    dtTemp.Columns.Add("प्रतिशत");

                    DataRow[] drM = ds.Tables[0].Select("fldchildGenderID=2");
                    DataRow[] drF = ds.Tables[0].Select("fldchildGenderID=3");
                    DataRow[] drN = ds.Tables[0].Select("fldchildGenderID=1");


                    int YchildM = int.Parse(drM[0]["total"].ToString());
                    int NchildM = int.Parse(drM[1]["total"].ToString());

                    int YchildF = int.Parse(drF[0]["total"].ToString());
                    int NchildF = int.Parse(drF[1]["total"].ToString());

                    int YchildN = int.Parse(drN[0]["total"].ToString());
                    int NchildN = int.Parse(drN[1]["total"].ToString());

                    float total = float.Parse((YchildF + YchildM + YchildN + NchildF + NchildM + NchildN).ToString());


                    dtTemp.Rows.Add("छ", YchildM, YchildF, YchildN, (((YchildF + YchildM + YchildN) / total) * 100.0).ToString("0.00"));
                    dtTemp.Rows.Add("छैन", NchildM, NchildF, NchildN, (((NchildF + NchildM + NchildN) / total) * 100.0).ToString("0.00"));


                    dgridResult.DataSource = dtTemp;

                }


            }
        }

    }
}
