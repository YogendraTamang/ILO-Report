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
    public partial class ucReportWorkingTimeME : UserControl
    {
        businessClass bl = new businessClass();
        private int pTypeID;
        //public ucReportReligion_ga()
        //{
        //    InitializeComponent();
        //}
        public ucReportWorkingTimeME(int fldTypeID)
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

            rowIndex = rowIndex + 4;
            columnIndex = 0;
            foreach (DataGridViewColumn column in dGridResult2.Columns)
            {
                if (column.HeaderText.Trim() != "" && column.Visible == true)
                {
                    columnIndex++;
                    excelSheet.Cells[rowIndex + 1, columnIndex] = column.HeaderText;
                }
            }

           
            foreach (DataGridViewRow row in dGridResult2.Rows)
            {
                rowIndex++;
                columnIndex = 0;
                foreach (DataGridViewColumn column in dGridResult2.Columns)
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
            DataSet ds = bl.GetWorkTimeMorningChildLabour(fldTypeID);
            DataSet ds1 = bl.GetWorkTimeEveningChildLabour(fldTypeID);
            //DataTable dtbl = new DataTable();
            //dtbl.Columns.Add("fldLabourCause");
            if (ds != null && ds.Tables.Count > 0)
            {
                dgridResult.DataSource = ds.Tables[0];
                                
            }
            if (ds1 != null && ds1.Tables.Count > 0)
            {
                dGridResult2.DataSource = ds1.Tables[0];
               
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
