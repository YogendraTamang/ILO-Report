using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Data ;
using System.Data .OleDb ;
using System.Data.Sql;
using System.Data.SqlClient;
using DBhandler;

namespace ILO_REPORT.businessLayer
{
    class businessClass
    {
        #region Microsoft Access Related functions 
        //public DataSet getContractDataset()
        //{
        //    DataSet ds = new DataSet();
        //    OleDbCommand cmd = new OleDbCommand();
        //    cmd.CommandType = CommandType.Text;
        //    cmd.CommandText = "SELECT t_contract.contract_no, t_contract.contract_date, t_contract.buyer, t_contract_dtl.po_no, t_contract_dtl.seller, t_contract_dtl.s_contract_no, t_contract_dtl.qty, mst_packet_type.type, mst_tea_garden.garden_name, mst_grade.type, t_contract_dtl.app_kg, t_contract_dtl.pallets, t_contract_dtl.b_price, t_contract_dtl.s_price"+
        //                       " FROM (((t_contract INNER JOIN t_contract_dtl ON t_contract.contract_no = t_contract_dtl.contract_no) INNER JOIN mst_grade ON t_contract_dtl.grade_code = mst_grade.grade_code) INNER JOIN mst_tea_garden ON t_contract_dtl.garden_code = mst_tea_garden.garden_code) INNER JOIN mst_packet_type ON t_contract_dtl.packet_code = mst_packet_type.packet_code";
        //    ds = DbFactory.GetDataSet(cmd);
        //    return ds;
        //}
        //public DataSet getTeaAllocationDataset()
        //{
        //    DataSet ds = new DataSet();
        //    OleDbCommand cmd = new OleDbCommand();
        //    cmd.CommandType = CommandType.Text;
        //    cmd.CommandText = "SELECT t_contract.contract_no, t_contract.contract_date, t_contract.contract_type,"+
        //        "t_contract.buyer, t_allocation_dtl.po_no, t_allocation_dtl.b_line_no, t_allocation_dtl.std, t_allocation_dtl.seller,"+
        //        "t_allocation_dtl.s_contract_no, t_allocation_dtl.s_inv_no, t_allocation_dtl.qty, t_allocation_dtl.packet_type,"+
        //        "t_allocation_dtl.grade_type, t_allocation_dtl.net_kg, t_allocation_dtl.pallets, t_allocation_dtl.b_price,"+
        //        "t_allocation_dtl.s_price, t_allocation_dtl.booked_rake, t_allocation_dtl.approved_date, t_allocation_dtl.rejected_date,"+
        //        "t_allocation_dtl.app_list_no FROM t_allocation_dtl INNER JOIN t_contract ON t_allocation_dtl.contract_no = t_contract.contract_no;";
        //    ds = DbFactory.GetDataSet(cmd);
        //    return ds;
        //}
        //public DataSet getProformaInvoiceDataset()
        //{
        //    DataSet ds = new DataSet();
        //    OleDbCommand cmd = new OleDbCommand();
        //    cmd.CommandType = CommandType.Text;
        //    cmd.CommandText = "SELECT t_invoice.pf_inv_no, t_invoice.pf_inv_date, t_invoice.to,"+
        //                      "t_invoice.country_origin, t_invoice.commodity, t_invoice.freight, "+
        //                      "t_invoice.insurance, Count(t_invoice_dtl.pf_inv_no) AS Record_Count "+
        //                      "FROM t_invoice INNER JOIN t_invoice_dtl ON t_invoice.pf_inv_no = t_invoice_dtl.pf_inv_no "+
        //                      "GROUP BY t_invoice.pf_inv_no, t_invoice.pf_inv_date, t_invoice.to, t_invoice.country_origin, t_invoice.commodity,"+ 
        //                      "t_invoice.freight, t_invoice.insurance HAVING (((t_invoice.pf_inv_no)<>0))"+
        //                      "ORDER BY Count(t_invoice_dtl.pf_inv_no)";
        //    ds = DbFactory.GetDataSet(cmd);
        //    return ds;
        //}
        //public DataSet getCBnotesDataset()
        //{
        //    DataSet ds = new DataSet();
        //    OleDbCommand cmd = new OleDbCommand();
        //    cmd.CommandType = CommandType.Text;
        //    cmd.CommandText = "SELECT t_commission.note_no, t_commission.type, t_commission.to, t_commission.issue_date,"+
        //                      "t_commission.comm_due_pct, "+
        //                      "Count(t_commission.note_no) AS CountOfnote_no FROM t_commission " +
        //                      "GROUP BY t_commission.note_no, t_commission.type, t_commission.to, t_commission.issue_date,"+
        //                      "t_commission.comm_due_pct";
        //    ds = DbFactory.GetDataSet(cmd);
        //    return ds;
        //}
        //public DataSet getDCnotesDataset()
        //{
        //    DataSet ds = new DataSet();
        //    OleDbCommand cmd = new OleDbCommand();
        //    cmd.CommandType = CommandType.Text;
        //    cmd.CommandText = "SELECT t_debit_credit.note_no, t_debit_credit.type, t_debit_credit.to, t_debit_credit.issue_date,"+
        //                      "t_debit_credit.t_claim_charge, Count(t_debit_credit.note_no) AS CountOfnote_no "+
        //                      "FROM t_debit_credit GROUP BY t_debit_credit.note_no, t_debit_credit.type, t_debit_credit.to,"+
        //                      "t_debit_credit.issue_date, t_debit_credit.t_claim_charge";

        //    ds = DbFactory.GetDataSet(cmd);
        //    return ds;
        //}
        //public DataSet getApprovalListDataset()
        //{
        //    DataSet ds = new DataSet();
        //    OleDbCommand cmd = new OleDbCommand();
        //    cmd.CommandType = CommandType.Text;
        //    cmd.CommandText = "SELECT t_approval.app_lisit_no,t_approval.contract_type,"+
        //                      "t_approval.issue_date, t_approval.buyer, Count(t_approval.app_lisit_no) "+ 
        //                      " AS CountOfapp_lisit_no FROM t_approval "+
        //                      "GROUP BY t_approval.app_lisit_no, t_approval.contract_type, "+
        //                      "t_approval.issue_date, t_approval.buyer";
        //    ds = DbFactory.GetDataSet(cmd);
        //    return ds;
        //}
        #endregion

        public String Find(String tableName, String filterField, String displayField, String filterValue)
        {
            SqlConnection con = DAO.GetSqlConnection(DAO.conString);
            if (con.State == ConnectionState.Closed)
                con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select " + displayField + " from " + tableName + " where " + filterField + " = @filterValue";
                cmd.Parameters.AddWithValue("@filterValue", filterValue);
                object obj = cmd.ExecuteScalar();
                if (obj != null)
                    return obj.ToString();

                return String.Empty;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        public bool Find(String tableName, String fieldName, String fieldValue)
        {
            SqlConnection con = DAO.GetSqlConnection(DAO.conString);
            if (con.State == ConnectionState.Closed)
                con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select " + fieldName + " from " + tableName + " where " + fieldName + " = '"+fieldValue+"'";
                //cmd.Parameters.AddWithValue("@fieldValue", fieldValue);
                Object obj = cmd.ExecuteScalar();
                if (obj != null)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        public bool Find(String tableName, String fieldName1, String fieldValue1,String fieldName2,String fieldValue2)
        {
            SqlConnection con = DAO.GetSqlConnection(DAO.conString);
            if (con.State == ConnectionState.Closed)
                con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select " + fieldName1 + " from " + tableName + " where " + fieldName1 + " = '" + fieldValue1 + "'" + " and " + fieldName2 + " = '" + fieldValue2 + "'";
                //cmd.Parameters.AddWithValue("@fieldValue", fieldValue);
                Object obj = cmd.ExecuteScalar();
                if (obj != null)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }
      
        public bool isUserNamePresent(string sUserName)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spIsUserNamePresent";
                command.Parameters.AddWithValue("@sUserName", sUserName);
                ds = DAO.GetDataSet(DAO.conString, command);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
              
        public int GetDateDiffInYear(string date)
        {
            try
            {
                int nResult;
                if (date == null || date == "")
                {
                    date = "1900/1/1";
                }
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spGetDateDifference";
                cmd.Parameters.AddWithValue("@Date", Convert.ToDateTime(date));
                nResult = DAO.ExecuteScalar(DAO.conString, cmd);
                return (nResult);
            }
            catch
            {
                return 101;
            }
        }      
       
        public DataSet userInfoDataSet()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spUserInfo";
                command.Parameters.AddWithValue("@sUserName", "");
                command.Parameters.AddWithValue("@sPassword", "");
                ds = DAO.GetDataSet(DAO.conString, command);
                return ds;
            }
            catch
            {
                return null;
            }
        }
        public DataSet userInfoDataSet(string sUserName, string sPassword)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spUserInfo";
                command.Parameters.AddWithValue("@sUserName", sUserName);
                command.Parameters.AddWithValue("@sPassword", sPassword);
                ds = DAO.GetDataSet(DAO.conString, command);
                return ds;
            }
            catch
            {
                return null;
            }
        }        
        public DataSet userInfoByUserNameDataSet(string sUserName)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spUserInfoByUserName";
                command.Parameters.AddWithValue("@sUserName", sUserName);
                ds = DAO.GetDataSet(DAO.conString, command);
                return ds;
            }
            catch
            {
                return null;
            }
        }
           
        public DataSet GetCompanyInfo()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spOfficeInfo";               
                ds = DAO.GetDataSet(DAO.conString, cmd);
                return ds;
            }
            catch
            {
                return null;
            }
        }

        public DataSet GetWorkSHourTimeChildLabour(int typeID)
        {

            try
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spReportWorkHour";
                cmd.Parameters.AddWithValue("@fldTypeID", typeID);
                ds = DAO.GetDataSet(DAO.conString, cmd);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public DataSet GetWorkTimeMorningChildLabour(int typeID)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = " SELECT fldWorkTimeDay N'काम शुरु गर्ने समय (बिहान)', count(fldWorkTimeDay)  AS N'जम्मा'" +
                 " FROM tblChildWorkState " +
                 " where tblChildWorkState.fldID in(select fldID from tblMain where fldTypeID=@fldTypeID) " +
                 "  GROUP BY tblChildWorkState.fldWorkTimeDay";
                cmd.Parameters.AddWithValue("@fldTypeID", typeID);
                ds = DAO.GetDataSet(DAO.conString, cmd);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet GetWorkTimeEveningChildLabour(int typeID)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = " SELECT fldWorkTimeEvening N'काम सकिने समय (बेलुका)', count(fldWorkTimeEvening)  AS N'जम्मा'" +
                " FROM tblChildWorkState " +
                " where tblChildWorkState.fldID in(select fldID from tblMain where fldTypeID=@fldTypeID) " +
                "  GROUP BY tblChildWorkState.fldWorkTimeEvening";
                cmd.Parameters.AddWithValue("@fldTypeID", typeID);
                ds = DAO.GetDataSet(DAO.conString, cmd);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet GetWorkStartTimeChildLabour(int typeID)
        {

            try
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spReportWorkStart";
                cmd.Parameters.AddWithValue("@fldTypeID", typeID);
                ds = DAO.GetDataSet(DAO.conString, cmd);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public DataSet GetLabourAgeGroup(string condition)
        {

            try
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select " +
                                " (select COUNT( fldChildage) from tblChildLabour where fldID in (select TM.fldID from tblChildLabourDetails TCL inner join tblMain TM on TM.fldID=TCL.fldID inner join tblStudyState TSS on TSS.fldStudyStateID=TCL.fldChildStudyStateID where 1=1 " + condition + " ) and (fldChildAge>4 and fldChildAge<11) and fldChildGenderID=1 or fldChildGenderID=4) to10N," +
                                " (select COUNT( fldChildage) from tblChildLabour where fldID in (select TM.fldID from tblChildLabourDetails TCL inner join tblMain TM on TM.fldID=TCL.fldID inner join tblStudyState TSS on TSS.fldStudyStateID=TCL.fldChildStudyStateID where 1=1 " + condition + " ) and (fldChildAge>4 and fldChildAge<11) and fldChildGenderID=2) to10M," +
                                " (select COUNT( fldChildage) from tblChildLabour where fldID in (select TM.fldID from tblChildLabourDetails TCL inner join tblMain TM on TM.fldID=TCL.fldID inner join tblStudyState TSS on TSS.fldStudyStateID=TCL.fldChildStudyStateID where 1=1 " + condition + " ) and (fldChildAge>4 and fldChildAge<11) and fldChildGenderID=3) to10F," +
                                " (select COUNT( fldChildage) from tblChildLabour where fldID in (select TM.fldID from tblChildLabourDetails TCL inner join tblMain TM on TM.fldID=TCL.fldID inner join tblStudyState TSS on TSS.fldStudyStateID=TCL.fldChildStudyStateID where 1=1 " + condition + " ) and (fldChildAge>10 and fldChildAge<14) and fldChildGenderID=1 or fldChildGenderID=4) to13N," +
                                " (select COUNT( fldChildage) from tblChildLabour where fldID in (select TM.fldID from tblChildLabourDetails TCL inner join tblMain TM on TM.fldID=TCL.fldID inner join tblStudyState TSS on TSS.fldStudyStateID=TCL.fldChildStudyStateID where 1=1 " + condition + " ) and (fldChildAge>10 and fldChildAge<14) and fldChildGenderID=2) to13M," +
                                " (select COUNT( fldChildage) from tblChildLabour where fldID in (select TM.fldID from tblChildLabourDetails TCL inner join tblMain TM on TM.fldID=TCL.fldID inner join tblStudyState TSS on TSS.fldStudyStateID=TCL.fldChildStudyStateID where 1=1 " + condition + " ) and (fldChildAge>10 and fldChildAge<14) and fldChildGenderID=3) to13F," +
                                " (select COUNT( fldChildage) from tblChildLabour where fldID in (select TM.fldID from tblChildLabourDetails TCL inner join tblMain TM on TM.fldID=TCL.fldID inner join tblStudyState TSS on TSS.fldStudyStateID=TCL.fldChildStudyStateID where 1=1 " + condition + " ) and (fldChildAge>13 and fldChildAge<18) and fldChildGenderID=1 or fldChildGenderID=4) to17N," +
                                " (select COUNT( fldChildage) from tblChildLabour where fldID in (select TM.fldID from tblChildLabourDetails TCL inner join tblMain TM on TM.fldID=TCL.fldID inner join tblStudyState TSS on TSS.fldStudyStateID=TCL.fldChildStudyStateID where 1=1 " + condition + " ) and (fldChildAge>13 and fldChildAge<18) and fldChildGenderID=2) to17M," +
                                " (select COUNT( fldChildage) from tblChildLabour where fldID in (select TM.fldID from tblChildLabourDetails TCL inner join tblMain TM on TM.fldID=TCL.fldID inner join tblStudyState TSS on TSS.fldStudyStateID=TCL.fldChildStudyStateID where 1=1 " + condition + " ) and (fldChildAge>13 and fldChildAge<18) and fldChildGenderID=3) to17F," +
                                " (select COUNT( fldChildage) from tblChildLabour where fldID in (select TM.fldID from tblChildLabourDetails TCL inner join tblMain TM on TM.fldID=TCL.fldID inner join tblStudyState TSS on TSS.fldStudyStateID=TCL.fldChildStudyStateID where 1=1 " + condition + " ) and (fldChildAge>17) and fldChildGenderID=1 or fldChildGenderID=4) plus18N," +
                                " (select COUNT( fldChildage) from tblChildLabour where fldID in (select TM.fldID from tblChildLabourDetails TCL inner join tblMain TM on TM.fldID=TCL.fldID inner join tblStudyState TSS on TSS.fldStudyStateID=TCL.fldChildStudyStateID where 1=1 " + condition + " ) and (fldChildAge>17) and fldChildGenderID=2) plus18M," +
                                " (select COUNT( fldChildage) from tblChildLabour where fldID in (select TM.fldID from tblChildLabourDetails TCL inner join tblMain TM on TM.fldID=TCL.fldID inner join tblStudyState TSS on TSS.fldStudyStateID=TCL.fldChildStudyStateID where 1=1 " + condition + " ) and (fldChildAge>17) and fldChildGenderID=3) plus18F," +
                                " (select COUNT( fldChildage) from tblChildLabour where fldID in (select TM.fldID from tblChildLabourDetails TCL inner join tblMain TM on TM.fldID=TCL.fldID inner join tblStudyState TSS on TSS.fldStudyStateID=TCL.fldChildStudyStateID where 1=1 " + condition + " ) and (fldChildAge<5) and fldChildGenderID=1 or fldChildGenderID=4) noDataN," +
                                " (select COUNT( fldChildage) from tblChildLabour where fldID in (select TM.fldID from tblChildLabourDetails TCL inner join tblMain TM on TM.fldID=TCL.fldID inner join tblStudyState TSS on TSS.fldStudyStateID=TCL.fldChildStudyStateID where 1=1 " + condition + " ) and (fldChildAge<5) and fldChildGenderID=2) noDataM," +
                                " (select COUNT( fldChildage) from tblChildLabour where fldID in (select TM.fldID from tblChildLabourDetails TCL inner join tblMain TM on TM.fldID=TCL.fldID inner join tblStudyState TSS on TSS.fldStudyStateID=TCL.fldChildStudyStateID where 1=1 " + condition + " ) and (fldChildAge<5) and fldChildGenderID=3) noDataF";
               
                ds = DAO.GetDataSet(DAO.conString, cmd);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public DataSet GetLabourCauseReport(int typeID)
        {
            
            try
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();              
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spReportLabourCause";
                cmd.Parameters.AddWithValue("@fldTypeID", typeID);
                ds = DAO.GetDataSet(DAO.conString, cmd);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
           
        }

        public DataSet GetLabourTakenReport(int typeID)
        {

            try
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spReportLabourTaken";
                cmd.Parameters.AddWithValue("@fldTypeID", typeID);
                ds = DAO.GetDataSet(DAO.conString, cmd);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public DataSet GetLabourWentHowReport(int typeID)
        {

            try
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spReportLabourWentHow";
                cmd.Parameters.AddWithValue("@fldTypeID", typeID);
                ds = DAO.GetDataSet(DAO.conString, cmd);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

       



        public DataSet GetJobAgreeMentPoints(int typeID)
        {

            try
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spReportJobAgreementPoints";
                cmd.Parameters.AddWithValue("@fldTypeID", typeID);
                ds = DAO.GetDataSet(DAO.conString, cmd);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public DataSet GetChildLabourDetails(String cond)
        {

            try
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spChildLabourDetailAll";
                cmd.Parameters.AddWithValue("@condition", cond);
                ds = DAO.GetDataSet(DAO.conString, cmd);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        //////////////

        public DataSet GetOccupation(string condition)
        {

            try
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT tblProfession.fldProfessionDesc as N'पेशा', COUNT(tblMain.fldMainProfessionID) AS N'जम्मा', CONVERT(DECIMAL(5,2), 100. * count(*) / sum(count(*)) over ()) AS N'प्रतिशत'  FROM tblProfession" +
                                    " INNER JOIN tblMain" +
                                    " ON tblProfession.fldProfessionId=tblMain.fldMainProfessionID where "+ condition +
                                    " GROUP BY fldProfessionDesc ";
                //cmd.Parameters.Add(new SqlParameter("@condition", condition));

                ds = DAO.GetDataSet(DAO.conString, cmd);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public DataSet GetEducation(string cond)
        {

            try
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select fldMainEducation as N'शैक्षिक अवस्था',count(*) AS N'जम्मा', CONVERT(DECIMAL(5,2), 100. * count(*) / sum(count(*)) over ()) AS N'प्रतिशत' " +
                                  "  from tblmain  where fldTypeID="+cond+" GROUP BY fldMainEducation ";
                
                ds = DAO.GetDataSet(DAO.conString, cmd);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public DataSet GetReligion(int typeID)
        {

            try
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT tblReligion.fldReligionDesc as N'धर्म', COUNT(tblMain.fldMainReligionID) AS N'जम्मा', CONVERT(DECIMAL(5,2), 100. * count(*) / sum(count(*)) over ()) AS N'प्रतिशत' "+
                    " FROM (tblReligion INNER JOIN tblMain ON tblReligion.fldReligionID=tblMain.fldMainReligionID) where fldTypeID=@fldTypeID GROUP BY fldReligionDesc";
                cmd.Parameters.AddWithValue("@fldTypeID", typeID);
                ds = DAO.GetDataSet(DAO.conString, cmd);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public DataSet GetStayType(int typeID)
        {

            try
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT tblStayTypeHome.fldStayTypeDesc as N'बसोबास अवस्था', COUNT(tblMain.fldMainStayTypeID) AS N'जम्मा', CONVERT(DECIMAL(5,2), 100. * count(*) / sum(count(*)) over ()) AS N'प्रतिशत' "+ 
                    " FROM (tblStayTypeHome INNER JOIN tblMain ON tblStayTypeHome.fldStayTypeID=tblMain.fldMainStayTypeID) where fldTypeID=@fldTypeID GROUP BY fldStayTypeDesc";
                cmd.Parameters.AddWithValue("@fldTypeID", typeID);
                ds = DAO.GetDataSet(DAO.conString, cmd);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public int InsertNewUser(string sUserName,string sPassword,string sFullName,string sEmail,bool AdminPriveleged,bool AccLocked,string sCreatedBy)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spInsertNewUser";
                command.Parameters.AddWithValue("@sUserName", sUserName);
                command.Parameters.AddWithValue("@sPassword", sPassword);
                command.Parameters.AddWithValue("@sFullName", sFullName);
                command.Parameters.AddWithValue("@sEmail", sEmail);
                command.Parameters.AddWithValue("@AdminPriveleged", AdminPriveleged);
                command.Parameters.AddWithValue("@AccLocked", AccLocked);
                command.Parameters.AddWithValue("@CreatedOn", DateTime.Now);
                command.Parameters.AddWithValue("@CreatedBy", sCreatedBy);
                int nRetVal = DAO.ExecuteQuery(DAO.conString, command);
                return nRetVal;
            }
            catch
            {
                return 0;
            }
        }
             
      
        public int UpdateUser(string sUserName, string sPassword, string sFullName, string sEmail, bool AdminPriveleged, bool AccLocked, string sModifiedBy, bool bEditPass, string OldUserName)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spUpdateUser";
                command.Parameters.AddWithValue("@sUserName", sUserName);
                command.Parameters.AddWithValue("@sPassword", sPassword);
                command.Parameters.AddWithValue("@sFullName", sFullName);
                command.Parameters.AddWithValue("@sEmail", sEmail);
                command.Parameters.AddWithValue("@AdminPriveleged", AdminPriveleged);
                command.Parameters.AddWithValue("@AccLocked", AccLocked);
                command.Parameters.AddWithValue("@ModifiedOn", DateTime.Now);
                command.Parameters.AddWithValue("@ModifiedBy", sModifiedBy);
                command.Parameters.AddWithValue("@IsPass",bEditPass);
                command.Parameters.AddWithValue("@OldUserName", OldUserName);
                int nRetVal = DAO.ExecuteQuery(DAO.conString, command);
                return nRetVal;
            }
            catch
            {
                return 0;
            }
        }

        public int UpdateCompany(string sCompanyName, string sAddress, string sHomePhone, string sFaxNo, string sPOB, string sEmail,
             string sVatNo, string sModifiedBy)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spUpdateOfficeInfo";
                command.Parameters.AddWithValue("@sAddress", sAddress);
                command.Parameters.AddWithValue("@sCompanyName", sCompanyName);
                command.Parameters.AddWithValue("@sEmail", sEmail);
                command.Parameters.AddWithValue("@sFaxNo", sFaxNo);
                command.Parameters.AddWithValue("@sPhone", sHomePhone);
                command.Parameters.AddWithValue("@sPOB", sPOB);
                command.Parameters.AddWithValue("@sVatNo", sVatNo);
                command.Parameters.AddWithValue("@ModifiedOn", DateTime.Now);
                command.Parameters.AddWithValue("@ModifiedBy", sModifiedBy);

                int nRetVal = DAO.ExecuteQuery(DAO.conString, command);
                return nRetVal;
            }
            catch
            {
                return 0;
            }
        }



        public DataSet GetCast(string cond)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT tblCast.fldCastDesc as N'जातजाती', COUNT(tblMain.fldMainCastID) AS N'जम्मा', CONVERT(DECIMAL(5,2), 100. * count(*) / sum(count(*)) over ()) AS N'प्रतिशत' "+ 
                                   " FROM (tblCast " +
                                  "INNER JOIN tblMain " +
                                  "ON tblCast.fldCastID=tblMain.fldMainCastID) where fldTypeID="+cond+
                                  "GROUP BY fldCastDesc";
                
                ds = DAO.GetDataSet(DAO.conString, cmd);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet GetCastChildLabour(int typeID)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT tblCast.fldCastDesc as N'जातजाती', COUNT(tblChildLabour.fldChildCastID) AS N'जम्मा', CONVERT(DECIMAL(5,2), 100. * count(*) / sum(count(*)) over ()) AS N'प्रतिशत' " +
                                   " FROM (tblCast " +
                                  "INNER JOIN tblChildLabour " +
                                  "ON tblCast.fldCastID=tblChildLabour.fldChildCastID) where tblChildLabour.fldID in(select fldID from tblMain where fldTypeID=@fldTypeID) " +
                                  "GROUP BY fldCastDesc";
                cmd.Parameters.AddWithValue("@fldTypeID", typeID);
                ds = DAO.GetDataSet(DAO.conString, cmd);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet GetBirthRegistraionChildLabour(string cond)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT Convert(varchar,fldChildBirthReg) as fldChildBirthReg, fldchildGenderID, count(fldchildGenderID) AS total " +
                                    " FROM tblChildLabour  where tblChildLabour.fldID in(select fldID from tblMain where fldTypeID="+cond+") " +
                                    " GROUP BY fldChildBirthReg,fldChildGenderID";
                                 
                //cmd.Parameters.AddWithValue("@fldTypeID", typeID);
                ds = DAO.GetDataSet(DAO.conString, cmd);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet GetStudyStateChildLabour(string cond)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT tblStudyState.fldStudyStateDesc as N'शैक्षिक अवस्था (पढ्न जानुभएको)', count(fldStudyStateID) AS N'जम्मा', CONVERT(DECIMAL(5,2), 100. * count(*) / sum(count(*)) over ()) AS N'प्रतिशत' " +
                " FROM tblchildLabourDetails inner join tblStudyState on tblStudyState.fldStudyStateID=tblChildLabourDetails.fldChildStudyStateID" +
                " where tblChildLabourDetails.fldID in(select fldID from tblMain where fldTypeID="+cond+") " +
                " GROUP BY tblChildLabourDetails.fldChildStudyStateID,tblStudyState.fldStudyStateDesc";
              
                ds = DAO.GetDataSet(DAO.conString, cmd);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet GetHealthFacilityChildLabour(int typeID)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT tblHealthStatus.fldHealthStatusDesc as N'स्वास्थ्य सम्बन्धी ब्यवस्था', count(tblMainFamilyBehaviour.fldHealthStatusID)  AS N'जम्मा',"+
                                  " CONVERT(DECIMAL(5,2), 100. * count(*) / sum(count(*)) over ()) AS N'प्रतिशत' " +
                                 " FROM tblMainFamilyBehaviour inner join tblHealthStatus on tblHealthStatus.fldHealthStatusID=tblMainFamilyBehaviour.fldHealthStatusID "+
                                  " where tblMainFamilyBehaviour.fldID in(select fldID from tblMain where fldTypeID=@fldTypeID) " +
                                  " GROUP BY tblMainFamilyBehaviour.fldHealthStatusID,tblHealthStatus.fldHealthStatusDesc";
                cmd.Parameters.AddWithValue("@fldTypeID", typeID);
                ds = DAO.GetDataSet(DAO.conString, cmd);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet GetStudyCertificateStateChildLabour(int typeID)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT Convert(Varchar,fldCertificate) as 'योग्यता प्रमाणपत्र', count(fldCertificate)  AS N'जम्मा',"+
                                 " CONVERT(DECIMAL(5,2), 100. * count(*) / sum(count(*)) over ()) AS N'प्रतिशत' "+
                                 " FROM tblMainFamilyBehaviour "+
                                 " where tblMainFamilyBehaviour.fldID in(select fldID from tblMain where fldTypeID=@fldTypeID) " +
                                 " GROUP BY tblMainFamilyBehaviour.fldCertificate";
                cmd.Parameters.AddWithValue("@fldTypeID", typeID);
                ds = DAO.GetDataSet(DAO.conString, cmd);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet GetStudyExpenseChildLabour(string cond)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT tblStudyExpense.fldStudyExpenseDesc as N'शैक्षिक खर्च', count(fldChildSchoolExpenseID)  AS N'जम्मा'," +
                     " CONVERT(DECIMAL(5,2), 100. * count(*) / sum(count(*)) over ()) AS N'प्रतिशत' " +
                    " FROM tblchildLabourDetails inner join tblStudyExpense on tblStudyExpense.fldStudyExpenseID=tblChildLabourDetails.fldChildSchoolExpenseID " +
                     " where tblChildLabourDetails.fldID in(select fldID from tblMain where fldTypeID="+cond+") " +
                     " GROUP BY tblChildLabourDetails.fldChildSchoolExpenseID,tblStudyExpense.fldStudyExpenseDesc";
              
                ds = DAO.GetDataSet(DAO.conString, cmd);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet GetHateWayChildLabour(int typeID)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spReportAbuseType";                
                cmd.Parameters.AddWithValue("@fldTypeID", typeID);
                ds = DAO.GetDataSet(DAO.conString, cmd);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet GetWhyNoReturenHomeChildLabour(int typeID)
        {

            try
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spReportNoReturnHOme";
                cmd.Parameters.AddWithValue("@fldTypeID", typeID);
                ds = DAO.GetDataSet(DAO.conString, cmd);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public DataSet GetFacilityOfChildLabour(int typeID)
        {

            try
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spReportLabourFacility";
                cmd.Parameters.AddWithValue("@fldTypeID", typeID);
                ds = DAO.GetDataSet(DAO.conString, cmd);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public DataSet GetWhyLeaveHomeChildLabour(int typeID)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT tblLabourCause.fldLcauseDesc as N'घर किन छाडेको', count(fldWhyLeaveHome)  AS N'जम्मा'," +
                             " CONVERT(DECIMAL(5,2), 100. * count(*) / sum(count(*)) over ()) AS N'प्रतिशत' "+
                             " FROM tblMainFamilyBehaviour inner join tblLabourCause on tblLabourCause.fldLcauseID=tblMainFamilyBehaviour.fldWhyLeaveHome " +
                            " where tblMainFamilyBehaviour.fldID in(select fldID from tblMain where fldTypeID=@fldTypeID) " +
                            " GROUP BY tblMainFamilyBehaviour.fldWhyLeaveHome,tblLabourCause.fldLcauseDesc";
                cmd.Parameters.AddWithValue("@fldTypeID", typeID);
                ds = DAO.GetDataSet(DAO.conString, cmd);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet GetSalaryTimeChildLabour(int typeID)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = " SELECT tblTimeInterval.fldTIntervalDesc as N'तलब पाउने समय', count(fldWorkPayTypeID)  AS N'जम्मा'," +
                "  CONVERT(DECIMAL(5,2), 100. * count(*) / sum(count(*)) over ()) AS N'प्रतिशत' " +
                " FROM tblChildWorkState inner join tblTimeInterval on tblTimeInterval.fldTIntervalID=tblChildWorkState.fldWorkPayTypeID " +
                " where tblChildWorkState.fldID in(select fldID from tblMain where fldTypeID=@fldTypeID) " +
                "  GROUP BY tblChildWorkState.fldWorkPayTypeID, tblTimeInterval.fldTIntervalDesc";
                cmd.Parameters.AddWithValue("@fldTypeID", typeID);
                ds = DAO.GetDataSet(DAO.conString, cmd);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
      public DataSet GetSalaryChildLabour(string cond)
      {
          try
          {
              DataSet ds = new DataSet();
              SqlCommand cmd = new SqlCommand();
              cmd.CommandType = CommandType.Text;
              cmd.CommandText = " SELECT fldWorkPayAmonunt N'पारिश्रमिक', count(fldWorkPayTypeID)  AS N'जम्मा'" +           
              " FROM tblChildWorkState " +
              " where tblChildWorkState.fldID in(select fldID from tblMain where fldTypeID="+cond+") " +
              "  GROUP BY tblChildWorkState.fldWorkPayAmonunt";
              ds = DAO.GetDataSet(DAO.conString, cmd);
              return ds;
          }
          catch (Exception ex)
          {
              return null;
          }
      }

      public DataSet GetSalaryReceiverChildLabour(int typeID)
      {
          try
          {
              DataSet ds = new DataSet();
              SqlCommand cmd = new SqlCommand();
              cmd.CommandType = CommandType.Text;
              cmd.CommandText = " SELECT tblPaymentReceiver.fldPReceiverDesc as N'पारिश्रमिक बुझ्ने', count(fldWorkPayReceiverID)  AS N'जम्मा'," +
              "  CONVERT(DECIMAL(5,2), 100. * count(*) / sum(count(*)) over ()) AS N'प्रतिशत' " +
              " FROM tblChildWorkState inner join tblPaymentReceiver on tblPaymentReceiver.fldPReceiverID=tblChildWorkState.fldWorkPayReceiverID " +
              " where tblChildWorkState.fldID in(select fldID from tblMain where fldTypeID=@fldTypeID) " +
              " GROUP BY tblChildWorkState.fldWorkPayReceiverID, tblPaymentReceiver.fldPReceiverDesc";
              cmd.Parameters.AddWithValue("@fldTypeID", typeID);
              ds = DAO.GetDataSet(DAO.conString, cmd);
              return ds;
          }
          catch (Exception ex)
          {
              return null;
          }
      }
      public DataSet GetContactHomeChildLabour(int typeID)
      {
          try
          { 
              DataSet ds = new DataSet();
              SqlCommand cmd = new SqlCommand();
              cmd.CommandType = CommandType.Text;
              cmd.CommandText = "  SELECT tblTimeInterval.fldTIntervalDesc as N'परिवार सँग भेटघाट वा सम्पर्क', count(fldWorkContactTypeID)  AS N'जम्मा'," +
              "  CONVERT(DECIMAL(5,2), 100. * count(*) / sum(count(*)) over ()) AS N'प्रतिशत' " +
              "  FROM tblChildWorkState inner join tblTimeInterval on tblTimeInterval.fldTIntervalID=tblChildWorkState.fldWorkContactTypeID  " +
              " where tblChildWorkState.fldID in(select fldID from tblMain where fldTypeID=@fldTypeID) " +
              " GROUP BY tblChildWorkState.fldWorkContactTypeID,tblTimeInterval.fldTIntervalDesc";
              cmd.Parameters.AddWithValue("@fldTypeID", typeID);
              ds = DAO.GetDataSet(DAO.conString, cmd);
              return ds;
          }
          catch (Exception ex)
          {
              return null;
          }
      }
        public DataSet GetReligionChildLabour(int typeID)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT fldReligionDesc as N'धर्म', COUNT(tblChildLabour.fldChildReligionID) AS N'जम्मा', CONVERT(DECIMAL(5,2), 100. * count(*) / sum(count(*)) over ()) AS N'प्रतिशत' " +
                                   " FROM (tblReligion " +
                                  "INNER JOIN tblChildLabour " +
                                  "ON tblReligion.fldReligionID=tblChildLabour.fldChildReligionID) where tblChildLabour.fldID in(select fldID from tblMain where fldTypeID=@fldTypeID) " +
                                  "GROUP BY fldReligionDesc";
                cmd.Parameters.AddWithValue("@fldTypeID", typeID);
                ds = DAO.GetDataSet(DAO.conString, cmd);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet GetStayTypeChildLabour(int typeID)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT fldStayTypeDesc as N'बसोबास अवस्था', COUNT(tblChildLabour.fldChildStayTypeID) AS N'जम्मा'," +
                     " CONVERT(DECIMAL(5,2), 100. * count(*) / sum(count(*)) over ()) AS N'प्रतिशत'  "+
                    " FROM (tblStayTypeHome INNER JOIN tblChildLabour ON tblStayTypeHome.fldStayTypeID=tblChildLabour.fldChildStayTypeID)"+
                    " where tblChildLabour.fldID in(select fldID from tblMain where fldTypeID=@fldTypeID) GROUP BY fldStayTypeDesc";
                cmd.Parameters.AddWithValue("@fldTypeID", typeID);
                ds = DAO.GetDataSet(DAO.conString, cmd);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
         public DataSet GetChildLabourStatusKa(string condition)
        {

            try
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select SUM(TAC.fldChildBoysNo) as boys,SUM(TAC.fldChildGirlsNo) as girls,SUM(TAC.fldChildBoysNo)+SUM(TAC.fldChildGirlsNo) as Total,"+
                            " Sum(TAC.fldChildSchoolYes) as schoolYes,SUM(TAC.fldChildSchoolNo) as schoolNo,"+
                            " (SUM(TAC.fldChildBoysNo)+SUM(TAC.fldChildGirlsNo)-Sum(TAC.fldChildSchoolYes)-SUM(TAC.fldChildSchoolNo)) as notKnown "+
                            " from tblAboutChildLabour TAC " +
                            " inner join tblmain TM on TAC.fldID=TM.fldID where " + condition;
                //cmd.Parameters.AddWithValue("@fldTypeID", typeID);
                ds = DAO.GetDataSet(DAO.conString, cmd);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        


     public DataSet GetJobAgreementInfo(int typeID)
        {

            try
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = " select TAC.fldJobAggrement N'रोजगारी सम्झौता',COUNT(*) AS N'जम्मा', CONVERT(DECIMAL(5,2), 100. * count(*) / sum(count(*)) over ()) AS N'प्रतिशत' "+ 
                                    " from tblAboutChildLabour TAC " +
                                    " inner join tblmain TM on TAC.fldID=TM.fldID " +
                                  "where  TM.fldTypeID=@fldTypeID group by TAC.fldJobAggrement";
                cmd.Parameters.AddWithValue("@fldTypeID", typeID);
                ds = DAO.GetDataSet(DAO.conString, cmd);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
     public DataSet GetChildLabourDetails_Kha(string cond)
     {
         try
         {
             DataSet ds = new DataSet();
             SqlCommand cmd = new SqlCommand();
             cmd.CommandType = CommandType.Text;
             cmd.CommandText = "select fldMainName,TM.fldLocation, TC.fldCastDesc, TP.fldProfessionDesc, TR.fldReligionDesc," +
                                " TAC.fldChildSchoolNo, TAC.fldChildSchoolYes, TM.fldMainMenNo, TM.fldMainWomenNo," +
                                " TM.fldMainBoysNo, TM.fldMainGirlsNo, TAC.fldChildBoysNo, TAC.fldChildGirlsNo" +
                                " from tblMain TM" +
                                " inner join tblCast TC on TM.fldMainCastID=TC.fldCastID" +
                                " inner join tblProfession TP on TM.fldMainProfessionID=TP.fldProfessionId" +
                                " inner join tblReligion TR on TM.fldMainReligionID=TR.fldReligionID" +
                                " inner join tblAboutChildLabour TAC on TM.fldID=TAC.fldID" +
                                " where " + cond;

                                //" inner join tblLabourType TLT on TLT.fldLabourTypeID=TCL.fldLabourTypeID"+
                                
             //cmd.Parameters.AddWithValue("@fldTypeID", typeID);
             ds = DAO.GetDataSet(DAO.conString, cmd);
             return ds;
         }
         catch (Exception ex)
         {
             return null;
         }

     }
        public DataSet GetFamilyInfo(int typeID)
        {

            try
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select SUM(fldMainMenNo) as Men,  SUM(fldMainWomenNo) AS WOMEN, SUM(fldMainBoysNo) as Boys, "+
                                  "SUM(fldMainGirlsNo) as Girls,TOTAL=SUM(fldMainMenNo)+SUM(fldMainWomenNo)+SUM(fldMainBoysNo)+SUM(fldMainBoysNo) "+
                                  "FROM tblMain where fldTypeID=@fldTypeID";
                cmd.Parameters.AddWithValue("@fldTypeID", typeID);
                ds = DAO.GetDataSet(DAO.conString, cmd);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }

        }


        public DataSet GetEmployerInfo(string cond)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select TM.fldMainName as N'घरमुलीको नाम', TM.fldLocation as N'स्थान', " +
                                    " TC.fldCastDesc as N'जातजाति'," +
                                    " TP.fldProfessionDesc as N'पेशा'," +
                                    " TR.fldReligionDesc as N'धर्म'," +
                                    " TCL.fldChildName as N'श्रमिकको नाम'," +
                                    " TCL.fldChildAge as N'श्रमिकको उमेर'" +
                                    " from tblMain TM" +
                                    " inner join tblCast TC on TM.fldMainCastID=TC.fldCastID" +
                                    " inner join tblProfession TP on TM.fldMainProfessionID=TP.fldProfessionId" +
                                    " inner join tblReligion TR on TM.fldMainReligionID=TR.fldReligionID" +
                                    " inner join tblChildLabour TCL on TM.fldID=TCL.fldID" +
                                    " where " + cond +
                                    " Order by TM.fldLocation, TM.fldMainCastID";
                //cmd.Parameters.AddWithValue("@fldTypeID", typeID);
                ds = DAO.GetDataSet(DAO.conString, cmd);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public DataSet GetChildLabourType(string cond)
        {

            try
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "declare @myTable table ( fldLabourType nvarchar(10))" +
                                    " insert into @myTable SELECT Split.a.value('.', 'VARCHAR(10)') AS Data" +
                                     " FROM ( SELECT CAST ('<M>' + REPLACE(LEFT(LTRIM(RTRIM(fldLabourTypeID))," +
                                    " CASE WHEN LEN(LTRIM(RTRIM(fldLabourTypeID))) - 1 < 0 THEN LEN(LTRIM(RTRIM(fldLabourTypeID)))" +
                                     " ELSE LEN(LTRIM(RTRIM(fldLabourTypeID))) - 1 END), ';', '</M><M>') + '</M>' AS XML) AS Data" +
                                     " FROM  tblAboutChildLabour inner join tblMain TM on tblAboutChildLabour.fldID=TM.fldID where fldTypeID="+cond +
                                     " ) AS A CROSS APPLY Data.nodes ('/M') AS Split(a);" +

                                    " SELECT Lc.fldLabourTypeDesc AS N'श्रमको प्रकृति', COUNT(*) AS N'जम्मा', CONVERT(DECIMAL(5,2), 100. * count(*) / sum(count(*)) over ()) AS N'प्रतिशत' FROM" +
                                    " @myTable M  LEFT JOIN tblLabourType LC" +
                                    " ON M.fldLabourType=LC.fldLabourTypeID" +
                                    " GROUP BY   LC.fldLabourTypeID,Lc.fldLabourTypeDesc order by LC.fldLabourTypeID asc";
                
                
                ds = DAO.GetDataSet(DAO.conString, cmd);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
