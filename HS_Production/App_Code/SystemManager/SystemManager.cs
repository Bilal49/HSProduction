using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;

namespace FIL.App_Code.SystemManager
{

   public class SystemManager
    {
       Smartworks.DAL dataAccess = new Smartworks.DAL();
       public SystemManager()
        {
            string connString = ConfigurationManager.ConnectionStrings["HSConnectionString"].ConnectionString;
            Smartworks.DAL.ConnectionString = connString;
        }

       public void UpdateSystemParameters(string PrinterGeneralReports, string PrinterForPOSSlip , string ReportFooterText , DateTime FicalYearStart , DateTime FicalYearEnd)
       {
           Smartworks.ColumnField[] iSystemPara = new Smartworks.ColumnField[5];
           iSystemPara[0] = new Smartworks.ColumnField("@PrinterGeneralReports", PrinterGeneralReports);
           iSystemPara[1] = new Smartworks.ColumnField("@PrinterForPOSSlip", PrinterForPOSSlip);
           iSystemPara[2] = new Smartworks.ColumnField("@ReportFooterText", ReportFooterText);
           iSystemPara[3] = new Smartworks.ColumnField("@FicalYearStart", FicalYearStart);
           iSystemPara[4] = new Smartworks.ColumnField("@FicalYearEnd", FicalYearEnd);
           dataAccess.BeginTransaction();
           dataAccess.ExecuteStoredProcedure("dbo.UpdateSystemParameters", iSystemPara);
           dataAccess.TransCommit();
       }

       public DataTable GetSystemInfo()
       {
           DataTable dt = new DataTable();
           dt =  dataAccess.getDataTable("Select * from SystemParameters");
           return dt;
       }


        #region Fiscal Year Setup

       public int GetFiscalYearIdById(int Id)
       {
           int FiscalId = -1;
           DataTable dt = new DataTable();
           dt = dataAccess.getDataTable("Select FiscalYearId from FiscalYear where FiscalYearId= '" + Id + "' ");
           if (dt.Rows.Count > 0)
           {
               FiscalId = Convert.ToInt32(dt.Rows[0]["FiscalYearId"]);
           }
           return FiscalId;
       }

       public DataTable GetFiscalYear(int FiscalId)
        {

            DataTable dt;
            dt = dataAccess.getDataTable("Select * from FiscalYear where FiscalYearId  =" + FiscalId);
            return dt;
        }

       
       public int InsertFiscalYear(DateTime FiscalYearStart, DateTime FiscalYearEnd, string FiscalName, int Year, bool IsActive)
       {
           int id = 0;

           Smartworks.ColumnField[] iFicalYear = new Smartworks.ColumnField[5];
           iFicalYear[0] = new Smartworks.ColumnField("@FiscalYearStart", FiscalYearStart);
           iFicalYear[1] = new Smartworks.ColumnField("@FiscalYearEnd", FiscalYearEnd);
           iFicalYear[2] = new Smartworks.ColumnField("@FiscalName", FiscalName);
           iFicalYear[3] = new Smartworks.ColumnField("@Year", Year);
           iFicalYear[4] = new Smartworks.ColumnField("@IsActive", IsActive);
           dataAccess.BeginTransaction();
           id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.InsertFiscalYear", iFicalYear));
           dataAccess.TransCommit();
           return id;
 
       }

       public void UpdateFicalYear(int FiscalYearId , DateTime FiscalYearStart, DateTime FiscalYearEnd, string FiscalName, int Year, bool IsActive)
       {
           Smartworks.ColumnField[] uFicalYear = new Smartworks.ColumnField[6];
           uFicalYear[0] = new Smartworks.ColumnField("@FiscalYearId", FiscalYearId);
           uFicalYear[1] = new Smartworks.ColumnField("@FiscalYearStart", FiscalYearStart);
           uFicalYear[2] = new Smartworks.ColumnField("@FiscalYearEnd", FiscalYearEnd);
           uFicalYear[3] = new Smartworks.ColumnField("@FiscalName", FiscalName);
           uFicalYear[4] = new Smartworks.ColumnField("@Year", Year);
           uFicalYear[5] = new Smartworks.ColumnField("@IsActive", IsActive);
           dataAccess.BeginTransaction();
           dataAccess.ExecuteStoredProcedure("dbo.UpdateFiscalYear", uFicalYear);
           dataAccess.TransCommit();

       }

       public void UpdateFicalYearActive(int FiscalYearId)
       {
           Smartworks.ColumnField[] uFicalYear = new Smartworks.ColumnField[1];
           uFicalYear[0] = new Smartworks.ColumnField("@FiscalYearId", FiscalYearId);
           dataAccess.BeginTransaction();
           dataAccess.ExecuteStoredProcedure("dbo.UpdateFicalYearActive", uFicalYear);
           dataAccess.TransCommit();
       }
        #endregion

    }
}
