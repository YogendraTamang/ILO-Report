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
    public partial class ucReportEmployer : UserControl
    {
        businessClass bl = new businessClass();
        private int pTypeID;
        //public ucReportReligion_ga()
        //{
        //    InitializeComponent();
        //}
        public ucReportEmployer(int fldTypeID)
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

        private void ucAgeGroup_Load(object sender, EventArgs e)
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
            string cond = " fldTypeID=" + fldTypeID.ToString();
            DataSet ds = bl.GetEmployerInfo(cond);
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
                    //dtTemp.Columns.Add("उमेर समुह");
                    //dtTemp.Columns.Add("बालक");
                    //dtTemp.Columns.Add("बालिका");
                    //dtTemp.Columns.Add("लिङ्ग प्राप्त नभएको");
                    //dtTemp.Columns.Add("प्रतिशत");
                   
                    //int to10N = int.Parse(ds.Tables[0].Rows[0]["to10N"].ToString());
                    //int to10M = int.Parse(ds.Tables[0].Rows[0]["to10M"].ToString());
                    //int to10F = int.Parse(ds.Tables[0].Rows[0]["to10F"].ToString());
                    //int to13N = int.Parse(ds.Tables[0].Rows[0]["to13N"].ToString());
                    //int to13M = int.Parse(ds.Tables[0].Rows[0]["to13M"].ToString());
                    //int to13F = int.Parse(ds.Tables[0].Rows[0]["to13F"].ToString());
                    //int to17N = int.Parse(ds.Tables[0].Rows[0]["to17N"].ToString());
                    //int to17M = int.Parse(ds.Tables[0].Rows[0]["to17M"].ToString());
                    //int to17F = int.Parse(ds.Tables[0].Rows[0]["to17F"].ToString());
                    //int plus18N = int.Parse(ds.Tables[0].Rows[0]["plus18N"].ToString());
                    //int plus18M = int.Parse(ds.Tables[0].Rows[0]["plus18M"].ToString());
                    //int plus18F = int.Parse(ds.Tables[0].Rows[0]["plus18F"].ToString());
                    //int noDataN = int.Parse(ds.Tables[0].Rows[0]["noDataN"].ToString());
                    //int noDataM = int.Parse(ds.Tables[0].Rows[0]["noDataM"].ToString());
                    //int noDataF = int.Parse(ds.Tables[0].Rows[0]["noDataF"].ToString());
                    //float total = float.Parse((to10M + to10F + to10N + to13M + to13F + to13N + to17M + to17F + to17N + plus18M + plus18F + plus18N + noDataM + noDataF + noDataN).ToString());

                    //dtTemp.Rows.Add("5-10", to10M,to10F,to10N, (((to10M+to10F+to10N) / total) * 100.0).ToString("0.00"));
                    //dtTemp.Rows.Add("11-13", to13M,to13F,to13N, (((to13M+to13F+to13N) / total) * 100.0).ToString("0.00"));
                    //dtTemp.Rows.Add("14-17", to17M , to17F , to17N, (((to17M + to17F + to17N) / total) * 100.0).ToString("0.00"));
                    //dtTemp.Rows.Add("18+", plus18M , plus18F , plus18N, (((plus18M + plus18F + plus18N) / total) * 100.0).ToString("0.00"));
                    //dtTemp.Rows.Add("उमेर प्राप्त नभएको", noDataM, noDataF, noDataN, (((noDataM + noDataF + noDataN) / total) * 100.0).ToString("0.00"));
                   

                    dgridResult.DataSource = ds.Tables[0];
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
            string condition = "fldTypeID=" + pTypeID.ToString();

            int sPlace = comboLocation.SelectedIndex;
            if (sPlace == 0)
                condition += " and TM.fldLocation=N'धुलिखेल'";
            else if (sPlace == 1)
                condition += " and TM.fldLocation=N'पनौती'";
        }

    }
}
