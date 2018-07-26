using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Windows.Forms;


public class VendorManager
{
    Smartworks.DAL dataAccess = new Smartworks.DAL();
    public VendorManager()
    {

        string connString = ConfigurationManager.ConnectionStrings["HSConnectionString"].ConnectionString;
        Smartworks.DAL.ConnectionString = connString;
    }


    public int InsertVendor(string VendorName, string Address, string phoneNumber, string contactPerson, int COAId ,  string STRegistration , string NTN ,
                              bool inactive,
                             int AddedBy, DateTime AddedOn, string AddedIpAddr, Smartworks.DAL customdataAcess = null)
    {
        int id = 0;

        Smartworks.ColumnField[] iVendor = new Smartworks.ColumnField[11];

        iVendor[0] = new Smartworks.ColumnField("@VendorName", VendorName);
        iVendor[1] = new Smartworks.ColumnField("@Address", Address);
        iVendor[2] = new Smartworks.ColumnField("@Phone", phoneNumber);
        iVendor[3] = new Smartworks.ColumnField("@ContactPerson", contactPerson);
        iVendor[4] = new Smartworks.ColumnField("@COAId", COAId);
        iVendor[5] = new Smartworks.ColumnField("@STRegistration", STRegistration);
        iVendor[6] = new Smartworks.ColumnField("@NTN", NTN);
        iVendor[7] = new Smartworks.ColumnField("@IsActive", inactive);
        iVendor[8] = new Smartworks.ColumnField("@AddedBy", AddedBy);
        iVendor[9] = new Smartworks.ColumnField("@AddedOn", AddedOn);
        iVendor[10] = new Smartworks.ColumnField("@AddedIpAddr", AddedIpAddr);
        if (customdataAcess != null)
        {
            id = Convert.ToInt32(customdataAcess.ExecuteStoredProcedure("dbo.InsertVendor", iVendor));
        }
        else
        {
            dataAccess.BeginTransaction();
            id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.InsertVendor", iVendor));
            dataAccess.TransCommit();
        }
        return id;

    }



    public void UpdateVendor(int vendorId, string vendorName, string Address, string phoneNumber, string contactPerson, int COAId , string STRegistration, string NTN,
                              bool inactive, int UpdatedBy, DateTime UpdatedOn, string UpdatedIpAddr)
    {
        Smartworks.ColumnField[] uVendor = new Smartworks.ColumnField[12];


        uVendor[0] = new Smartworks.ColumnField("@VendorId", vendorId);
        uVendor[1] = new Smartworks.ColumnField("@VendorName", vendorName);
        uVendor[2] = new Smartworks.ColumnField("@Address", Address);
        uVendor[3] = new Smartworks.ColumnField("@Phone", phoneNumber);
        uVendor[4] = new Smartworks.ColumnField("@ContactPerson", contactPerson);
        uVendor[5] = new Smartworks.ColumnField("@COAId", COAId);
        uVendor[6] = new Smartworks.ColumnField("@STRegistration", STRegistration);
        uVendor[7] = new Smartworks.ColumnField("@NTN", NTN);
        uVendor[8] = new Smartworks.ColumnField("@IsActive", inactive);
        uVendor[9] = new Smartworks.ColumnField("@UpdatedBy", UpdatedBy);
        uVendor[10] = new Smartworks.ColumnField("@UpdatedOn", UpdatedOn);
        uVendor[11] = new Smartworks.ColumnField("@UpdatedIpAddr", UpdatedIpAddr);

        dataAccess.BeginTransaction();
        dataAccess.ExecuteStoredProcedure("dbo.UpdateVendor", uVendor);
        dataAccess.TransCommit();
    }


    public int DeleteVendor(string VendorId)
    {
        int id;
        Smartworks.ColumnField[] dVendor = new Smartworks.ColumnField[1];
        dVendor[0] = new Smartworks.ColumnField("@VendorId", VendorId);
        dataAccess.BeginTransaction();
        id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.DeleteVendor", dVendor));
        dataAccess.TransCommit();

        return id;
    }



    public DataTable GetVendor(int VendorId)
    {

        DataTable dt;
        dt = dataAccess.getDataTable("Select * from Vendor where VendorId =" + VendorId);
        return dt;
    }



    public int GetVendorIdByCode(string Code)
    {
        int VendorId = -1;
        DataTable dt = new DataTable();
        dt = dataAccess.getDataTable("Select VendorId from Vendor where Code = '" + Code + "' ");
        if (dt.Rows.Count > 0)
        {
            VendorId = (int)dt.Rows[0]["VendorId"];
        }
        return VendorId;
    }


    public DataTable GetVendorList()
    {
        DataTable dt = new DataTable();
        dt = dataAccess.getDataTable("Select VendorId , upper(left(VendorName, 1)) + right(Name, len(VendorName) - 1) as VendorName  from Vendor Order by VendorName ");
        return dt;

    }

    public DataTable GetVendorLedgerByCashPayment(string PaymentNo)
    {

        DataTable dt;
        dt = dataAccess.getDataTable("select * from [VendorLedger] where VoucherNo = '" + PaymentNo + "'");
        return dt;
    }



    public int DeleteVendorLedgerByTransNo(string PurchaseInvoiceNo, Smartworks.DAL customdataAcess = null)
    {
        int id = 0;
        Smartworks.ColumnField[] dVendorLedger = new Smartworks.ColumnField[1];
        dVendorLedger[0] = new Smartworks.ColumnField("@PurchaseInvoiceNo", PurchaseInvoiceNo);

        if (customdataAcess != null)
        {
            customdataAcess.ExecuteStoredProcedure("dbo.DeleteVendorLedgerByInvoiceNo", dVendorLedger);
        }
        else
        {
            dataAccess.BeginTransaction();
            id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.DeleteVendorLedgerByInvoiceNo", dVendorLedger));
            dataAccess.TransCommit();
        }
        return id;
    }

    public int DeleteVendorLedger(int LedgerId)
    {
        int id;
        Smartworks.ColumnField[] dVendorLedger = new Smartworks.ColumnField[1];
        dVendorLedger[0] = new Smartworks.ColumnField("@LedgerId", LedgerId);
        dataAccess.BeginTransaction();
        id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.DeleteVendorLedger", dVendorLedger));
        dataAccess.TransCommit();
        return id;
    }

    public int InsertVendorLedger(int VendorId, DateTime Date,
                            string PurchaseInvoiceNo, int PurchaseInvoiceId, decimal PurchaseAmount, string VoucherNo,
                            int VoucherId, decimal VoucherAmount,
                            Smartworks.DAL customdataAcess = null)
    {
        int id = 0;
        Smartworks.ColumnField[] iVendorLedger = new Smartworks.ColumnField[8];
        iVendorLedger[0] = new Smartworks.ColumnField("@VendorId", VendorId);
        iVendorLedger[1] = new Smartworks.ColumnField("@Date", Date);
        iVendorLedger[2] = new Smartworks.ColumnField("@PurchaseInvoiceNo", PurchaseInvoiceNo);
        iVendorLedger[3] = new Smartworks.ColumnField("@PurchaseInvoiceId", PurchaseInvoiceId);
        iVendorLedger[4] = new Smartworks.ColumnField("@PurchaseAmount", PurchaseAmount);
        iVendorLedger[5] = new Smartworks.ColumnField("@VoucherNo", VoucherNo);
        iVendorLedger[6] = new Smartworks.ColumnField("@VoucherId", VoucherId);
        iVendorLedger[7] = new Smartworks.ColumnField("@VoucherAmount", VoucherAmount);
        if (customdataAcess != null)
        {
            id = Convert.ToInt32(customdataAcess.ExecuteStoredProcedure("dbo.InsertVendorLedger", iVendorLedger));
        }
        else
        {
            dataAccess.BeginTransaction();
            id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.InsertVendorLedger", iVendorLedger));
            dataAccess.TransCommit();
        }

        return id;

    }



    public void UpdateVendorLedger(int LedgerId, int VendorId, DateTime Date,
                           string PurchaseInvoiceNo, int PurchaseInvoiceId, decimal PurchaseAmount, string VoucherNo,
                           int VoucherId, decimal VoucherAmount, Smartworks.DAL customdataAcess = null)
    {
        Smartworks.ColumnField[] uVendorLedger = new Smartworks.ColumnField[9];
        uVendorLedger[0] = new Smartworks.ColumnField("@LedgerId", LedgerId);
        uVendorLedger[1] = new Smartworks.ColumnField("@VendorId", VendorId);
        uVendorLedger[2] = new Smartworks.ColumnField("@Date", Date);
        uVendorLedger[3] = new Smartworks.ColumnField("@PurchaseInvoiceNo", PurchaseInvoiceNo);
        uVendorLedger[4] = new Smartworks.ColumnField("@PurchaseInvoiceId", PurchaseInvoiceId);
        uVendorLedger[5] = new Smartworks.ColumnField("@PurchaseAmount", PurchaseAmount);
        uVendorLedger[6] = new Smartworks.ColumnField("@VoucherNo", VoucherNo);
        uVendorLedger[7] = new Smartworks.ColumnField("@VoucherId", VoucherId);
        uVendorLedger[8] = new Smartworks.ColumnField("@VoucherAmount", VoucherAmount);

        if (customdataAcess != null)
        {
            customdataAcess.ExecuteStoredProcedure("dbo.UpdateVendorLedger", uVendorLedger);
        }
        else
        {
            dataAccess.BeginTransaction();
            dataAccess.ExecuteStoredProcedure("dbo.UpdateVendorLedger", uVendorLedger);
            dataAccess.TransCommit();
        }


    }





    public DataTable GetVendorLedgerByInvoiceNo(string PurchaseInvoiceNo)
    {
        DataTable dt;
        dt = dataAccess.getDataTable("select * from [VendorLedger] where PurchaseInvoiceNo = '" + PurchaseInvoiceNo + "'");
        return dt;
    }

    //public DataTable GetVendorLedgerByCashPayment(string PaymentNo)
    //{

    //    DataTable dt;
    //    dt = dataAccess.getDataTable("select * from [VendorLedger] where VoucherNo = '" + PaymentNo + "'");
    //    return dt;
    //}

    //public void DeleteVendorLedger(int LedgerId)
    //{
    //    dataAccess.ExecuteNonQuery("Delete from VendorLedger where LedgerId = " + LedgerId);
    //}

    #region ReportProduct
    public DataTable GetReportVendorLedger(String VendorCode, DateTime FromDate, DateTime ToDate)
    {
        DataTable dt = new DataTable();
        Smartworks.ColumnField[] Vendorledger = new Smartworks.ColumnField[3];
        Vendorledger[0] = new Smartworks.ColumnField("@VenderCode", VendorCode);
        Vendorledger[1] = new Smartworks.ColumnField("@FromDate", FromDate);
        Vendorledger[2] = new Smartworks.ColumnField("@ToDate", ToDate);
        dt = dataAccess.getDataTableByStoredProcedure("sp_ReportVenderLedger", Vendorledger);
        return dt;
    }
    #endregion
}

