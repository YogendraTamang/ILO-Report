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
    public partial class ucReportChildLabourStatus_Ka : UserControl
    {
        businessClass bl = new businessClass();
        private int pTypeID;
        public ucReportChildLabourStatus_Ka(int fldTypeID)
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

        private void ucChildLabourStatus_ka_Load(object sender, EventArgs e)
        {
            try
            {
                loadData(pTypeID);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString(), "ILO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }
        private void loadData(int fldTypeID) 
        {
            string cond = "fldTypeID="+fldTypeID.ToString();
            DataSet ds = bl.GetChildLabourStatusKa(cond);
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
                    dtTemp.Columns.Add("बाल श्रमिकको बिवरण");
                    dtTemp.Columns.Add("जम्मा");
                    dtTemp.Columns.Add("प्रतिशत");

                    float total = float.Parse(ds.Tables[0].Rows[0]["Total"].ToString());
                    int boys = int.Parse(ds.Tables[0].Rows[0]["boys"].ToString());
                    int girls = int.Parse(ds.Tables[0].Rows[0]["girls"].ToString());
                    int schoolYes = int.Parse(ds.Tables[0].Rows[0]["schoolYes"].ToString());
                    int schoolNo = int.Parse(ds.Tables[0].Rows[0]["schoolNo"].ToString());
                    int NoschoolStatus = int.Parse(ds.Tables[0].Rows[0]["notKnown"].ToString());
                   
                    dtTemp.Rows.Add("बालक", boys, ((boys / total) * 100.0).ToString("0.00"));
                    dtTemp.Rows.Add("बालिका", girls, ((girls / total) * 100.0).ToString("0.00"));
                    dtTemp.Rows.Add("बिद्दालय जाने", schoolYes, ((schoolYes / total) * 100.0).ToString("0.00"));
                    dtTemp.Rows.Add("बिद्दालय नजाने", schoolNo, ((schoolNo / total) * 100.0).ToString("0.00"));
                    dtTemp.Rows.Add("प्राप्त नभएका", NoschoolStatus, ((NoschoolStatus / total) * 100.0).ToString("0.00"));

                    dgridResult.DataSource = dtTemp;
                }

            }

        }


        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            string condition = "fldTypeID=" + pTypeID.ToString();

            int sPlace = comboEthnicity.SelectedIndex;
            if (sPlace == 0)
                condition += " and TM.fldLocation=N'धुलिखेल'";
            else if (sPlace == 1)
                condition += " and TM.fldLocation=N'पनौती'";
            DataSet ds = bl.GetChildLabourStatusKa(condition);
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
                    dtTemp.Columns.Add("बाल श्रमिकको बिवरण");
                    dtTemp.Columns.Add("जम्मा");
                    dtTemp.Columns.Add("प्रतिशत");

                    float total = float.Parse(ds.Tables[0].Rows[0]["Total"].ToString());
                    int boys = int.Parse(ds.Tables[0].Rows[0]["boys"].ToString());
                    int girls = int.Parse(ds.Tables[0].Rows[0]["girls"].ToString());
                    int schoolYes = int.Parse(ds.Tables[0].Rows[0]["schoolYes"].ToString());
                    int schoolNo = int.Parse(ds.Tables[0].Rows[0]["schoolNo"].ToString());
                    int NoschoolStatus = int.Parse(ds.Tables[0].Rows[0]["notKnown"].ToString());
                   
                    dtTemp.Rows.Add("बालक", boys, ((boys / total) * 100.0).ToString("0.00"));
                    dtTemp.Rows.Add("बालिका", girls, ((girls / total) * 100.0).ToString("0.00"));
                    dtTemp.Rows.Add("बिद्दालय जाने", schoolYes, ((schoolYes / total) * 100.0).ToString("0.00"));
                    dtTemp.Rows.Add("बिद्दालय नजाने", schoolNo, ((schoolNo / total) * 100.0).ToString("0.00"));
                    dtTemp.Rows.Add("प्राप्त नभएका", NoschoolStatus, ((NoschoolStatus / total) * 100.0).ToString("0.00"));

                    dgridResult.DataSource = dtTemp;
                }

            }
        }
      
    }
}
