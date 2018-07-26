using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;


public class AccountManager
{
    Smartworks.DAL dataAccess = new Smartworks.DAL();
    public AccountManager()
    {
        string connString = ConfigurationManager.ConnectionStrings["HSConnectionString"].ConnectionString;
        Smartworks.DAL.ConnectionString = connString;
    }

    #region Account Category
    public int InsertAccountCategory(string CategoryName, string Code,  int AddedBy, DateTime AddedOn,
                                   string AddedIpAddr)
    {
        int id = 0;
        Smartworks.ColumnField[] iAccountCategoryCatagory = new Smartworks.ColumnField[5];
        iAccountCategoryCatagory[0] = new Smartworks.ColumnField("@CategoryName", CategoryName);
        iAccountCategoryCatagory[1] = new Smartworks.ColumnField("@Code", Code);
        iAccountCategoryCatagory[2] = new Smartworks.ColumnField("@AddedBy", AddedBy);
        iAccountCategoryCatagory[3] = new Smartworks.ColumnField("@AddedOn", AddedOn);
        iAccountCategoryCatagory[4] = new Smartworks.ColumnField("@AddedIpAddr", AddedIpAddr);
        dataAccess.BeginTransaction();
        id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.InsertAccountCategory", iAccountCategoryCatagory));
        dataAccess.TransCommit();
        return id;

    }

    public void UpdateAccountCategory(int ACId, string CategoryName, string Code , int UpdatedBy, DateTime UpdatedOn, string UpdatedIpAddr)
    {
        Smartworks.ColumnField[] uAccountCategoryCatagory = new Smartworks.ColumnField[6];
        uAccountCategoryCatagory[0] = new Smartworks.ColumnField("@ACId", ACId);
        uAccountCategoryCatagory[1] = new Smartworks.ColumnField("@CategoryName", CategoryName);
        uAccountCategoryCatagory[2] = new Smartworks.ColumnField("@Code", Code);
        uAccountCategoryCatagory[3] = new Smartworks.ColumnField("@UpdatedBy", UpdatedBy);
        uAccountCategoryCatagory[4] = new Smartworks.ColumnField("@UpdatedOn", UpdatedOn);
        uAccountCategoryCatagory[5] = new Smartworks.ColumnField("@UpdatedIpAddr", UpdatedIpAddr);

        dataAccess.BeginTransaction();
        dataAccess.ExecuteStoredProcedure("dbo.UpdateAccountCategory", uAccountCategoryCatagory);
        dataAccess.TransCommit();
    }


    public int DeleteAccountCategory(string ACId)
    {
        int id;

        Smartworks.ColumnField[] dAccountCategory = new Smartworks.ColumnField[1];
        dAccountCategory[0] = new Smartworks.ColumnField("@ACId", ACId);
        dataAccess.BeginTransaction();
        id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.DeleteAccountCategory", dAccountCategory));
        dataAccess.TransCommit();
        return id;
    }
    public DataTable GetAllAccountCategory()
    {
        return dataAccess.getDataTable("select ACId , AccountCategory from AccountCategory");
    }
    public DataTable GetAccountCategory(int ACId)
    {

        DataTable dt;
        dt = dataAccess.getDataTable("Select * from AccountCategory where ACId  =" + ACId);
        return dt;
    }

    public DataTable GetAccountCategoryList()
    {
        DataTable dt = new DataTable();
        dt = dataAccess.getDataTable("Select ACId , upper(left(CategoryName, 1)) + right(CategoryName, len(CategoryName) - 1) as CategoryName  from AccountCategory Order by CategoryName ");
        return dt;
    }

    public int GetACIdById(int Id)
    {
        int ACId = -1;
        DataTable dt = new DataTable();
        dt = dataAccess.getDataTable("Select ACId from AccountCategory where ACId= '" + Id + "' ");
        if (dt.Rows.Count > 0)
        {
            ACId = (int)dt.Rows[0]["ACId"];
        }
        return ACId;
    }

    public int GetACIdByCode(string Code)
    {
        int ACId = -1;
        DataTable dt = new DataTable();
        dt = dataAccess.getDataTable("Select ACId from AccountCategory where Code= '" + Code + "' ");
        if (dt.Rows.Count > 0)
        {
            ACId = (int)dt.Rows[0]["ACId"];
        }
        return ACId;
    }
    #endregion

    #region Chart Of Accounts

    public string GetNewAccoutCodeByCategoryId(int CategoryId)
    {
        string Code = "";
        try
        {
            Smartworks.ColumnField[] gCode = new Smartworks.ColumnField[1];
            gCode[0] = new Smartworks.ColumnField("@CategoryId", CategoryId);
            dataAccess.BeginTransaction();
            Code = dataAccess.ExecuteStoredProcedure("GetNewCOACodeByCategoryId", gCode).ToString();
            dataAccess.TransCommit();
            return Code;
        }
        catch (Exception ex)
        {
            Code = "";
        }
        finally
        {
            dataAccess.ConnectionClose();
        }
        return Code;
    }

    public string GetNewAccoutCodeByParentCode(string ParentCode)
    {
        string Code = "";
        try
        {
            Smartworks.ColumnField[] gCode = new Smartworks.ColumnField[1];
            gCode[0] = new Smartworks.ColumnField("@ParentCode", ParentCode);
            dataAccess.BeginTransaction();
            Code = dataAccess.ExecuteStoredProcedure("GetNewCOACodeByParentCode", gCode).ToString();
            dataAccess.TransCommit();
            return Code;
        }
        catch (Exception ex)
        {
            Code = "";
        }
        finally
        {
            dataAccess.ConnectionClose();
        }
        return Code;
    }

    

    public int InsertChartOfAccount(string BranchCode, string AccountCode, string AccountName, int Category, string FlagDC, bool IsDetailAccount, bool IsBSTAccount  
        , string IsSubAccountOf , int AddedBy, DateTime AddedOn, string AddedIpAddr)
    {

        int id = 0;
        Smartworks.ColumnField[] iCOA = new Smartworks.ColumnField[11];
        iCOA[0] = new Smartworks.ColumnField("@BranchCode", BranchCode);
        iCOA[1] = new Smartworks.ColumnField("@AccountCode", AccountCode);
        iCOA[2] = new Smartworks.ColumnField("@AccountName", AccountName);
        iCOA[3] = new Smartworks.ColumnField("@Category", Category);
        iCOA[4] = new Smartworks.ColumnField("@FlagDC", FlagDC);
        iCOA[5] = new Smartworks.ColumnField("@IsDetailAccount", IsDetailAccount);
        iCOA[6] = new Smartworks.ColumnField("@IsBSTAccount", IsBSTAccount);
        iCOA[7] = new Smartworks.ColumnField("@IsSubAccountOf", IsSubAccountOf);
        iCOA[8] = new Smartworks.ColumnField("@AddedBy", AddedBy);
        iCOA[9] = new Smartworks.ColumnField("@AddedOn", AddedOn);
        iCOA[10] = new Smartworks.ColumnField("@AddedIpAddr", AddedIpAddr);
        dataAccess.BeginTransaction();
        id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.InsertCOA", iCOA));
        dataAccess.TransCommit();
        return id;
    }


    public int UpdateChartOfAccount(int COAId , string BranchCode, string AccountCode, string AccountName, int Category, string FlagDC, bool IsDetailAccount, bool IsBSTAccount
       , string IsSubAccountOf, int AddedBy, DateTime AddedOn, string AddedIpAddr)
    {

        int id = 0;
        Smartworks.ColumnField[] uCOA = new Smartworks.ColumnField[12];
        uCOA[0] = new Smartworks.ColumnField("@COAId", COAId);
        uCOA[1] = new Smartworks.ColumnField("@BranchCode", BranchCode);
        uCOA[2] = new Smartworks.ColumnField("@AccountCode", AccountCode);
        uCOA[3] = new Smartworks.ColumnField("@AccountName", AccountName);
        uCOA[4] = new Smartworks.ColumnField("@Category", Category);
        uCOA[5] = new Smartworks.ColumnField("@FlagDC", FlagDC);
        uCOA[6] = new Smartworks.ColumnField("@IsDetailAccount", IsDetailAccount);
        uCOA[7] = new Smartworks.ColumnField("@IsBSTAccount", IsBSTAccount);
        uCOA[8] = new Smartworks.ColumnField("@IsSubAccountOf", IsSubAccountOf);
        uCOA[9] = new Smartworks.ColumnField("@AddedBy", AddedBy);
        uCOA[10] = new Smartworks.ColumnField("@AddedOn", AddedOn);
        uCOA[11] = new Smartworks.ColumnField("@AddedIpAddr", AddedIpAddr);
        dataAccess.BeginTransaction();
        id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.UpdateCOA", uCOA));
        dataAccess.TransCommit();
        return id;
    }

    public DataTable GetChartOfAccounts(int COAId)
    {
        return dataAccess.getDataTable("Select * from ChartOfAccounts inner join AccountCategory on ChartofAccounts.Category = AccountCategory.ACId where COAId = '"+ COAId +"' ");
    }

    public int GetCOAIdByCode(string Code)
    {
        int Id = -1;
        DataTable dt = new DataTable();
        dt = dataAccess.getDataTable("Select COAId from ChartOfAccounts where AccountCode= '" + Code + "' ");
        if (dt.Rows.Count > 0)
        {
            Id = Convert.ToInt32(dt.Rows[0]["COAId"].ToString());
        }
        return Id;
    }

    #endregion

    #region AccountConfiguration

    public DataTable GetAccountConfiguration()
    {
        DataTable dtAccConfig = new DataTable();
        dtAccConfig = dataAccess.getDataTable("Select * from AccountConfig");
        return dtAccConfig;
    }

    public int InsertUpdateAccountConfiguration(string SalesAccount, string PurchaseAccount, string CashAccount, string SaleGSTAccount , string PurchaseGSTAccount )
    {
        int Id = 0;
        Smartworks.ColumnField[] iAccConfig = new Smartworks.ColumnField[5];
        iAccConfig[0] = new Smartworks.ColumnField("@SalesAccount", SalesAccount);
        iAccConfig[1] = new Smartworks.ColumnField("@PurchaseAccount", PurchaseAccount);
        iAccConfig[2] = new Smartworks.ColumnField("@CashAccount", CashAccount);
        iAccConfig[3] = new Smartworks.ColumnField("@SaleGSTAccount", SaleGSTAccount);
        iAccConfig[4] = new Smartworks.ColumnField("@PurchaseGSTAccount", PurchaseGSTAccount);
        dataAccess.BeginTransaction();
        Id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.InsertUpdateAccountConfig", iAccConfig));
        dataAccess.TransCommit();
        return Id;
    }


    #endregion


    #region Reporting

    public DataTable GetReportGeneralLedger(string AccountCodeFrom, string AccountCodeTo, Nullable<DateTime> DateFrom, Nullable<DateTime> DateTo)
    {
        DataTable dtReport = new DataTable();
        Smartworks.ColumnField[] rLedger = new Smartworks.ColumnField[4];
        rLedger[0] = new Smartworks.ColumnField("@AccountCodeFrom", AccountCodeFrom);
        rLedger[1] = new Smartworks.ColumnField("@AccountCodeTo", AccountCodeTo);
        if (DateFrom == null)
        {
            rLedger[2] = new Smartworks.ColumnField("@DateFrom", DBNull.Value);
        }
        else
        {
            rLedger[2] = new Smartworks.ColumnField("@DateFrom", DateFrom);
        }

        if (DateTo == null)
        {
            rLedger[3] = new Smartworks.ColumnField("@DateTo", DBNull.Value);
        }
        else
        {
            rLedger[3] = new Smartworks.ColumnField("@DateTo", DateTo);
        }


        dtReport = dataAccess.getDataTableByStoredProcedure("ReportGeneralLedger", rLedger);
        return dtReport;
    }

    public DataTable GetReportCashLedger(string CashAccountCode, Nullable<DateTime> DateFrom, Nullable<DateTime> DateTo)
    {
        DataTable dtReport = new DataTable();
        Smartworks.ColumnField[] rLedger = new Smartworks.ColumnField[3];
        rLedger[0] = new Smartworks.ColumnField("@CashAccountCode", CashAccountCode);

        if (DateFrom == null)
        {
            rLedger[1] = new Smartworks.ColumnField("@FromDate", DBNull.Value);
        }
        else
        {
            rLedger[1] = new Smartworks.ColumnField("@FromDate", DateFrom);
        }

        if (DateTo == null)
        {
            rLedger[2] = new Smartworks.ColumnField("@ToDate", DBNull.Value);
        }
        else
        {
            rLedger[2] = new Smartworks.ColumnField("@ToDate", DateTo);
        }


        dtReport = dataAccess.getDataTableByStoredProcedure("sp_ReportCashLedger", rLedger);
        return dtReport;
    }

    public DataTable GetReportAccountBalance(Nullable<DateTime> DateFrom, int CategoryId, int CityId)
    {
        DataTable dtReport = new DataTable();
        Smartworks.ColumnField[] rLedger = new Smartworks.ColumnField[3];

        if (DateFrom == null)
        {
            rLedger[0] = new Smartworks.ColumnField("@AsOnDate", DBNull.Value);
        }
        else
        {
            rLedger[0] = new Smartworks.ColumnField("@AsOnDate", DateFrom);
        }

        rLedger[1] = new Smartworks.ColumnField("@CityId", CityId);
        rLedger[2] = new Smartworks.ColumnField("@CategoryId", CategoryId);


        dtReport = dataAccess.getDataTableByStoredProcedure("sp_ReportAccountBalance", rLedger);
        return dtReport;
    }

    public DataTable GetReportTrialBalanceSheet(Nullable<DateTime> DateFrom, Nullable<DateTime> DateTo, bool OrderByCode)
    {
        DataTable dtReport = new DataTable();
        Smartworks.ColumnField[] rLedger = new Smartworks.ColumnField[3];

        if (DateFrom == null)
        {
            rLedger[0] = new Smartworks.ColumnField("@DateFrom", DBNull.Value);
        }
        else
        {
            rLedger[0] = new Smartworks.ColumnField("@DateFrom", DateFrom);
        }

        if (DateTo == null)
        {
            rLedger[1] = new Smartworks.ColumnField("@DateTo", DBNull.Value);
        }
        else
        {
            rLedger[1] = new Smartworks.ColumnField("@DateTo", DateTo);
        }
        rLedger[2] = new Smartworks.ColumnField("@OrderByCode", OrderByCode);

        dtReport = dataAccess.getDataTableByStoredProcedure("sp_ReportTrialLedger", rLedger);
        return dtReport;
    }


    public DataTable GetReportAgingBalanceSheet(Nullable<DateTime> DateFrom)
    {
        DataTable dtReport = new DataTable();
        Smartworks.ColumnField[] rLedger = new Smartworks.ColumnField[1];

        if (DateFrom == null)
        {
            rLedger[0] = new Smartworks.ColumnField("@AsOn", DBNull.Value);
        }
        else
        {
            rLedger[0] = new Smartworks.ColumnField("@AsOn", DateFrom);
        }
        dtReport = dataAccess.getDataTableByStoredProcedure("sp_ReportAgingSheet", rLedger);
        return dtReport;
    }


    public DataTable GetReportPriceList(int AccountCategoryId , string FromCOACode , string ToCOACode , bool OrderByCode)
    {
        DataTable dtReport = new DataTable();
        Smartworks.ColumnField[] rList = new Smartworks.ColumnField[4];
        rList[0] = new Smartworks.ColumnField("@ACId", AccountCategoryId);
        rList[1] = new Smartworks.ColumnField("@FromCOACode", FromCOACode);
        rList[2] = new Smartworks.ColumnField("@ToCOACode", ToCOACode);
        rList[3] = new Smartworks.ColumnField("@OrderByCode", OrderByCode);
        dtReport = dataAccess.getDataTableByStoredProcedure("sp_ReportCOAList", rList);
        return dtReport;
    }


    public DataTable GetReportVoucher(string FromVoucherNumber, string ToVoucherNumber, DateTime FromDate, DateTime ToDate, string VT)
    {
        DataTable dtReport = new DataTable();
        Smartworks.ColumnField[] reportVocuher = new Smartworks.ColumnField[5];
        reportVocuher[0] = new Smartworks.ColumnField("@FromVoucherNumber", FromVoucherNumber);
        reportVocuher[1] = new Smartworks.ColumnField("@ToVoucherNumber", ToVoucherNumber);
        reportVocuher[2] = new Smartworks.ColumnField("@FromDate", FromDate);
        reportVocuher[3] = new Smartworks.ColumnField("@ToDate", ToDate);
        reportVocuher[4] = new Smartworks.ColumnField("@VoucherType", VT);


        dtReport = dataAccess.getDataTableByStoredProcedure("sp_ReportVoucher", reportVocuher);
        return dtReport;
    }

    public DataTable GetReportBankVoucher(string FromVoucherNumber, string ToVoucherNumber, DateTime FromDate, DateTime ToDate, string VT)
    {
        DataTable dtReport = new DataTable();
        Smartworks.ColumnField[] reportVocuher = new Smartworks.ColumnField[5];
        reportVocuher[0] = new Smartworks.ColumnField("@FromVoucherNumber", FromVoucherNumber);
        reportVocuher[1] = new Smartworks.ColumnField("@ToVoucherNumber", ToVoucherNumber);
        reportVocuher[2] = new Smartworks.ColumnField("@FromDate", FromDate);
        reportVocuher[3] = new Smartworks.ColumnField("@ToDate", ToDate);
        reportVocuher[4] = new Smartworks.ColumnField("@VoucherType", VT);


        dtReport = dataAccess.getDataTableByStoredProcedure("sp_ReportBankVoucher", reportVocuher);
        return dtReport;
    }


    public DataTable GetReportCustomerBalance(DateTime Dated)
    {
        DataTable dtReport = new DataTable();
        Smartworks.ColumnField[] gReportBalance = new Smartworks.ColumnField[1];
        gReportBalance[0] = new Smartworks.ColumnField("@Dated", Dated);
        dtReport = dataAccess.getDataTableByStoredProcedure("sp_ReportGetCustomerBalance", gReportBalance);
        return dtReport;
    }

    public DataTable GetReportVendorBalance(DateTime Dated)
    {
        DataTable dtReport = new DataTable();
        Smartworks.ColumnField[] gReportBalance = new Smartworks.ColumnField[1];
        gReportBalance[0] = new Smartworks.ColumnField("@Dated", Dated);
        dtReport = dataAccess.getDataTableByStoredProcedure("sp_ReportGetVendorBalance", gReportBalance);
        return dtReport;
    }
    #endregion

}

