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
    public partial class ucReportFamilyInfo_ga : UserControl
    {
        businessClass bl = new businessClass();
        //public ucReportReligion_ga()
        //{
        //    InitializeComponent();
        //}
        public ucReportFamilyInfo_ga()
        {
            InitializeComponent();

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

        private void ucReportFamilyInfo_ga_Load(object sender, EventArgs e)
        {
            try
            {
                comboFormType.SelectedText = "फारम ग";
                loadData(3);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString(), "ILO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }
        private void loadData(int fldTypeID) 
        {
            DataSet ds = bl.GetFamilyInfo(fldTypeID);
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
                    dtTemp.Columns.Add("पारिवारिक बिवरण");
                    dtTemp.Columns.Add("जम्मा");
                    dtTemp.Columns.Add("प्रतिशत");

                    float total = float.Parse(ds.Tables[0].Rows[0]["Total"].ToString());
                    int men = int.Parse(ds.Tables[0].Rows[0]["Men"].ToString());
                    int women = int.Parse(ds.Tables[0].Rows[0]["Women"].ToString());
                    int boy = int.Parse(ds.Tables[0].Rows[0]["Boys"].ToString());
                    int girls = int.Parse(ds.Tables[0].Rows[0]["Girls"].ToString());

                    dtTemp.Rows.Add("पुरुष", men, ((men / total) * 100.0).ToString("0.00"));
                    dtTemp.Rows.Add("महिला", women, ((women / total) * 100.0).ToString("0.00"));
                    dtTemp.Rows.Add("बालक", boy, ((boy / total) * 100.0).ToString("0.00"));
                    dtTemp.Rows.Add("बालिका", girls, ((girls / total) * 100.0).ToString("0.00"));

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

    }
}
