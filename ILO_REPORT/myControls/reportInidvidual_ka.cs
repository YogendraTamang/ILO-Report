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
    public partial class ucReportIndividual : UserControl
    {
        businessClass bl = new businessClass();
        public ucReportIndividual()
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

        private void ucReport_Load(object sender, EventArgs e)
        {
            try
            {
               
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString(), "ILO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }
        private void loadData(string location,int wardNo) 
        {
            DataSet ds = new DataSet();// bl.GetLabourCauseReport(fldTypeID);
            //DataTable dtbl = new DataTable();
            //dtbl.Columns.Add("fldLabourCause");
            if (ds != null && ds.Tables.Count > 0)
            {
                dgridResult.DataSource = ds.Tables[0];
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    MessageBox.Show("No Records", "ILO");     
                }
               
            }   
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string sText = comboFormType.SelectedText;
            string sWardNo = comboWardNo.SelectedText;
            loadData(sText, int.Parse(sWardNo));
          

        }

    }
}
