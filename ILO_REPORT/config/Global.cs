using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using DBhandler;
using Microsoft.VisualBasic;

namespace ILO_REPORT.config
{
    public class Global
    {
        public Global()
        {
 
        }
        public static string loggedUser;
        public static bool isAdmin;
        public static string maskedEmail = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
        public static int GetDateDiffInYear(string date)
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
                cmd.Parameters.AddWithValue("@Date", date);
                nResult = DAO.ExecuteScalar(DAO.conString, cmd);
                return (nResult);
            }
            catch
            {
                return 101;
            }
        }
        public static int GetDateDiffInYear(string date1,string date2)
        {
            try
            {
                int nResult;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ILOGetDateDifferenceByDate";
                cmd.Parameters.AddWithValue("@Date1", date1);
                cmd.Parameters.AddWithValue("@Date2", date2);
                nResult = DAO.ExecuteScalar(DAO.conString, cmd);
                return (nResult);
            }
            catch
            {
                return 101;
            }
        }
        public static string FormatProperDate(string dateToFormat)
        {
            string formattedDate = "";
            if (Information.IsDate(dateToFormat))
            {
                formattedDate = Convert.ToDateTime(dateToFormat).ToString("dd/MM/yyyy");
            }
            return formattedDate;
        }
        public static string RemoveCommasFromString(string strParam)
        {
            string strRemovedString = "";
            string[] strRemovedArray = strParam.Split(',');
            for (int i = 0; i < strRemovedArray.Length; i++)
            {
                strRemovedString += strRemovedArray[i];
            }
            return strRemovedString;
        }
        
    }
}
