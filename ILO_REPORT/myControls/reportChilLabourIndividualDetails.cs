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
    public partial class ucReportCLabourIndividualDetails : UserControl
    {
        businessClass bl = new businessClass();
        private int pTypeID;
        public ucReportCLabourIndividualDetails(int fldTypeID)
        {
            pTypeID = fldTypeID;
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
                loadData(pTypeID);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString(), "ILO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }
        private void loadData(int fldTypeID) 
        {
            DataSet ds = bl.GetChildLabourDetails(" and TM.fldTypeID="+fldTypeID.ToString());          
            if (ds != null && ds.Tables.Count > 0)
            {
                dgridResult.DataSource = ds.Tables[0];
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    MessageBox.Show("No Records", "ILO");     
                }
               
            }   
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string condition = " and TM.fldTypeID="+pTypeID.ToString();
        
            int sPlace = comboPlace.SelectedIndex;
            if (sPlace == 0)
                condition += " and TM.fldLocation=N'पनौती'";
            else if (sPlace == 1)
                condition += " and TM.fldLocation=N'धुलिखेल'";
            int sAgeGroup = comboAgeGroup.SelectedIndex;
            if (sAgeGroup == 0)
                condition += " and CL.fldChildAge>4 and CL.fldChildAge<11";
            else if (sAgeGroup == 1)
                condition += " and CL.fldChildAge>10 and CL.fldChildAge<14";
            else if (sAgeGroup == 2)
                condition += " and CL.fldChildAge>13 and CL.fldChildAge<18";
            else if (sAgeGroup == 3)
                condition += " and CL.fldChildAge>17";
            else if (sAgeGroup == 4)
                condition += " and CL.fldChildAge>=0 and CL.fldChildAge<5";

            int sWorkHour = comboWorkHour.SelectedIndex;

            if (sWorkHour == 0)
                condition += " and CW.fldWorkTimePerDay >0 and CW.fldWorkTimePerDay<5";
            else if (sWorkHour == 1)
                condition += " and CW.fldWorkTimePerDay >4 and CW.fldWorkTimePerDay<9";
            else if (sWorkHour == 2)
                condition += " and CW.fldWorkTimePerDay >8 and CW.fldWorkTimePerDay<11";
            else if (sWorkHour == 3)
                condition += " and CW.fldWorkTimePerDay >10 and CW.fldWorkTimePerDay<13";
            else if (sWorkHour == 4)
                condition += " and CW.fldWorkTimePerDay >12";
            else if (sWorkHour == 5)
                condition += " and CW.fldWorkTimePerDay <=0";


            int sBirthReg = comboBirthReg.SelectedIndex;
            if (sBirthReg == 0)
                condition += " and CL.fldchildBirthReg=1";
            else if (sBirthReg == 1)
                condition += " and CL.fldchildBirthReg=0";

            DataSet ds = bl.GetChildLabourDetails(condition);
            if (ds != null && ds.Tables.Count > 0)
            {
              
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    MessageBox.Show("No Records", "ILO");
                }
                else
                { 

                }
                dgridResult.DataSource = ds.Tables[0];

            }   

        }
    
    }
}
