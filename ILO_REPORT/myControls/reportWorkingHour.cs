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
    public partial class ucReportWorkingHour : UserControl
    {
        businessClass bl = new businessClass();
        private int pTypeID;
        //public ucReportReligion_ga()
        //{
        //    InitializeComponent();
        //}
        public ucReportWorkingHour(int fldTypeID)
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
            DataSet ds = bl.GetWorkSHourTimeChildLabour(fldTypeID);
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
                    dtTemp.Columns.Add("काम गर्ने समय (घण्टा)");
                    dtTemp.Columns.Add("जम्मा");
                    dtTemp.Columns.Add("प्रतिशत");

                    int dataN = int.Parse(ds.Tables[0].Rows[0]["dataN"].ToString());
                    int to3 = int.Parse(ds.Tables[0].Rows[0]["to3"].ToString());
                    int to6 = int.Parse(ds.Tables[0].Rows[0]["to6"].ToString());
                    int to12 = int.Parse(ds.Tables[0].Rows[0]["to12"].ToString());
                    int to24 = int.Parse(ds.Tables[0].Rows[0]["to24"].ToString());
                    int plus24 = int.Parse(ds.Tables[0].Rows[0]["plus24"].ToString());
                    float total = float.Parse((dataN + to3 + to6 + to12 + to24 + plus24).ToString());

                    dtTemp.Rows.Add("प्राप्त नभएको", dataN, ((dataN / total) * 100.0).ToString("0.00"));
                    dtTemp.Rows.Add("0-3 घण्टा", to3, ((to3 / total) * 100.0).ToString("0.00"));
                    dtTemp.Rows.Add("4-7 घण्टा", to6, ((to6 / total) * 100.0).ToString("0.00"));
                    dtTemp.Rows.Add("8-9 घण्टा", to12, ((to12 / total) * 100.0).ToString("0.00"));
                    dtTemp.Rows.Add("10-12 घण्टा ", to24, ((to24 / total) * 100.0).ToString("0.00"));
                    dtTemp.Rows.Add("12 घण्टा भन्दा बढी", plus24, ((plus24 / total) * 100.0).ToString("0.00"));

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
