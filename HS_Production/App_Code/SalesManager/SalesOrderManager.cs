using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;


public class SalesOrderManager
{
    Smartworks.DAL dataAccess = new Smartworks.DAL();
    public SalesOrderManager()
    {

        string connString = ConfigurationManager.ConnectionStrings["HSConnectionString"].ConnectionString;
        Smartworks.DAL.ConnectionString = connString;
    }

    #region Sales Order
    public DataSet GetSalesOrderStructure(int SOrderId)
    {
        DataSet ds = new DataSet();
        Smartworks.ColumnField[] getSO = new Smartworks.ColumnField[1];
        getSO[0] = new Smartworks.ColumnField("@SOrderId", SOrderId);
        ds = dataAccess.getDataSetByStoredProcedure("sp_GetSalesOrderStructure", getSO);
        return ds;
    }

    public int InsertSOMaster(DateTime OrderDate, DateTime DueDate, string BranchCode, string CustomerCode, string CustomerRef, string EmployeeCode, int TransportId, int CompanyId, int CurrencyId,
          decimal Rate, decimal TQuantity, decimal TAmount, decimal TDiscountPerc, decimal TDiscount, bool Closed, bool IsProductionClosed, string Remarks, string PONo, decimal GSTPerc, decimal GSTAmount, int AddedBy, DateTime AddedOn, string AddedIpAddr,
        bool IsDispatched, Smartworks.DAL customdataAcess = null)
    {
        int Id = -1;
        Smartworks.ColumnField[] iSalesOrder = new Smartworks.ColumnField[24];
        iSalesOrder[0] = new Smartworks.ColumnField("@OrderDate", OrderDate);
        iSalesOrder[1] = new Smartworks.ColumnField("@DueDate", DueDate);
        iSalesOrder[2] = new Smartworks.ColumnField("@BranchCode", BranchCode);
        iSalesOrder[3] = new Smartworks.ColumnField("@CustomerCode", CustomerCode);
        iSalesOrder[4] = new Smartworks.ColumnField("@CustomerRef", CustomerRef);
        iSalesOrder[5] = new Smartworks.ColumnField("@EmployeeCode", EmployeeCode);
        iSalesOrder[6] = new Smartworks.ColumnField("@TransportId", TransportId);
        iSalesOrder[7] = new Smartworks.ColumnField("@CompanyId", CompanyId);
        iSalesOrder[8] = new Smartworks.ColumnField("@CurrencyId", CurrencyId);
        iSalesOrder[9] = new Smartworks.ColumnField("@Rate", Rate);
        iSalesOrder[10] = new Smartworks.ColumnField("@TQuantity", TQuantity);
        iSalesOrder[11] = new Smartworks.ColumnField("@TAmount", TAmount);
        iSalesOrder[12] = new Smartworks.ColumnField("@TDiscountPerc", TDiscountPerc);
        iSalesOrder[13] = new Smartworks.ColumnField("@TDiscount", TDiscount);
        iSalesOrder[14] = new Smartworks.ColumnField("@Closed", Closed);
        iSalesOrder[15] = new Smartworks.ColumnField("@Remarks", Remarks);
        iSalesOrder[16] = new Smartworks.ColumnField("@PONo", PONo);
        iSalesOrder[17] = new Smartworks.ColumnField("@GSTPerc", GSTPerc);
        iSalesOrder[18] = new Smartworks.ColumnField("@GSTAmount", GSTAmount);
        iSalesOrder[19] = new Smartworks.ColumnField("@AddedBy", AddedBy);
        iSalesOrder[20] = new Smartworks.ColumnField("@AddedOn", AddedOn);
        iSalesOrder[21] = new Smartworks.ColumnField("@AddedIpAddr", AddedIpAddr);
        iSalesOrder[22] = new Smartworks.ColumnField("@IsProductionClosed", IsProductionClosed);
        iSalesOrder[23] = new Smartworks.ColumnField("@IsDispatched", IsDispatched);

        if (customdataAcess != null)
        {
            Id = Convert.ToInt32(customdataAcess.ExecuteStoredProcedure("dbo.InsertSOMaster", iSalesOrder));
        }
        else
        {
            dataAccess.BeginTransaction();
            Id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.InsertSOMaster", iSalesOrder));
            dataAccess.TransCommit();
        }
        return Id;
    }

    public void UpdateSOMaster(int SOrderId, DateTime OrderDate, DateTime DueDate, string BranchCode, string CustomerCode, string CustomerRef, string EmployeeCode, int TransportId, int CompanyId, int CurrencyId,
          decimal Rate, decimal TQuantity, decimal TAmount, decimal TDiscountPerc, decimal TDiscount, bool Closed, bool IsProductionClosed, string Remarks, string PONo, decimal GSTPerc, decimal GSTAmount, int AddedBy, DateTime AddedOn, string AddedIpAddr, bool IsDispatched, Smartworks.DAL customdataAcess = null)
    {
        int Id = -1;

        Smartworks.ColumnField[] uSalesOrder = new Smartworks.ColumnField[25];
        uSalesOrder[0] = new Smartworks.ColumnField("@SOrderId", SOrderId);
        uSalesOrder[1] = new Smartworks.ColumnField("@OrderDate", OrderDate);
        uSalesOrder[2] = new Smartworks.ColumnField("@DueDate", DueDate);
        uSalesOrder[3] = new Smartworks.ColumnField("@BranchCode", BranchCode);
        uSalesOrder[4] = new Smartworks.ColumnField("@CustomerCode", CustomerCode);
        uSalesOrder[5] = new Smartworks.ColumnField("@CustomerRef", CustomerRef);
        uSalesOrder[6] = new Smartworks.ColumnField("@EmployeeCode", EmployeeCode);
        uSalesOrder[7] = new Smartworks.ColumnField("@TransportId", TransportId);
        uSalesOrder[8] = new Smartworks.ColumnField("@CompanyId", CompanyId);
        uSalesOrder[9] = new Smartworks.ColumnField("@CurrencyId", CurrencyId);
        uSalesOrder[10] = new Smartworks.ColumnField("@Rate", Rate);
        uSalesOrder[11] = new Smartworks.ColumnField("@TQuantity", TQuantity);
        uSalesOrder[12] = new Smartworks.ColumnField("@TAmount", TAmount);
        uSalesOrder[13] = new Smartworks.ColumnField("@TDiscountPerc", TDiscountPerc);
        uSalesOrder[14] = new Smartworks.ColumnField("@TDiscount", TDiscount);
        uSalesOrder[15] = new Smartworks.ColumnField("@Closed", Closed);
        uSalesOrder[16] = new Smartworks.ColumnField("@Remarks", Remarks);
        uSalesOrder[17] = new Smartworks.ColumnField("@PONo", PONo);
        uSalesOrder[18] = new Smartworks.ColumnField("@GSTPerc", GSTPerc);
        uSalesOrder[19] = new Smartworks.ColumnField("@GSTAmount", GSTAmount);
        uSalesOrder[20] = new Smartworks.ColumnField("@AddedBy", AddedBy);
        uSalesOrder[21] = new Smartworks.ColumnField("@AddedOn", AddedOn);
        uSalesOrder[22] = new Smartworks.ColumnField("@AddedIpAddr", AddedIpAddr);
        uSalesOrder[23] = new Smartworks.ColumnField("@IsProductionClosed", IsProductionClosed);
        uSalesOrder[24] = new Smartworks.ColumnField("@IsDispatched", IsDispatched);

        if (customdataAcess != null)
        {
            customdataAcess.ExecuteStoredProcedure("dbo.UpdateSOMaster", uSalesOrder);
        }
        else
        {
            dataAccess.BeginTransaction();
            dataAccess.ExecuteStoredProcedure("dbo.UpdateSOMaster", uSalesOrder);
            dataAccess.TransCommit();
        }
    }


    public int InsertUpdateSODetail(int SOrderDetailId, int SOrderId, int ProductId, string StockType, decimal S39, decimal S40, decimal S41, decimal S42, decimal S43, decimal S44, decimal S45, decimal S46, decimal S47,
 decimal OrderQty, decimal ReceivedQty, decimal Price, decimal DiscountPercent, decimal DiscountAmount, decimal GSTPercent,
decimal GSTAmount, int AddedBy, DateTime AddedOn, string AddedIpAddr, Smartworks.DAL customdataAcess)
    {


        int Id = -1;
        Smartworks.ColumnField[] iuSalesOrderDetail = new Smartworks.ColumnField[23];
        iuSalesOrderDetail[0] = new Smartworks.ColumnField("@SOrderDetailId", SOrderDetailId);
        iuSalesOrderDetail[1] = new Smartworks.ColumnField("@SOrderId", SOrderId);
        iuSalesOrderDetail[2] = new Smartworks.ColumnField("@ProductId", ProductId);
        iuSalesOrderDetail[3] = new Smartworks.ColumnField("@StockType", StockType);
        iuSalesOrderDetail[4] = new Smartworks.ColumnField("@S39", S39);
        iuSalesOrderDetail[5] = new Smartworks.ColumnField("@S40", S40);
        iuSalesOrderDetail[6] = new Smartworks.ColumnField("@S41", S41);
        iuSalesOrderDetail[7] = new Smartworks.ColumnField("@S42", S42);
        iuSalesOrderDetail[8] = new Smartworks.ColumnField("@S43", S43);
        iuSalesOrderDetail[9] = new Smartworks.ColumnField("@S44", S44);
        iuSalesOrderDetail[10] = new Smartworks.ColumnField("@S45", S45);
        iuSalesOrderDetail[11] = new Smartworks.ColumnField("@S46", S46);
        iuSalesOrderDetail[12] = new Smartworks.ColumnField("@S47", S47);
        iuSalesOrderDetail[13] = new Smartworks.ColumnField("@OrderQty", OrderQty);
        iuSalesOrderDetail[14] = new Smartworks.ColumnField("@ReceivedQty", ReceivedQty);
        iuSalesOrderDetail[15] = new Smartworks.ColumnField("@Price", Price);
        iuSalesOrderDetail[16] = new Smartworks.ColumnField("@DiscountPercent", DiscountPercent);
        iuSalesOrderDetail[17] = new Smartworks.ColumnField("@DiscountAmount", DiscountAmount);
        iuSalesOrderDetail[18] = new Smartworks.ColumnField("@GSTPercent", GSTPercent);
        iuSalesOrderDetail[19] = new Smartworks.ColumnField("@GSTAmount", GSTAmount);
        iuSalesOrderDetail[20] = new Smartworks.ColumnField("@AddedBy", AddedBy);
        iuSalesOrderDetail[21] = new Smartworks.ColumnField("@AddedOn", AddedOn);
        iuSalesOrderDetail[22] = new Smartworks.ColumnField("@AddedIpAddr", AddedIpAddr);

        if (customdataAcess != null)
        {
            Id = Convert.ToInt32(customdataAcess.ExecuteStoredProcedure("dbo.InsertUpdateSOrderDetails", iuSalesOrderDetail));
        }
        else
        {
            dataAccess.BeginTransaction();
            Id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.InsertUpdateSOrderDetails", iuSalesOrderDetail));
            dataAccess.TransCommit();
        }
        return Id;
    }


    public void DeleteSOrderDetailByDetailId(int SOrderDetailId, Smartworks.DAL customdataAcess = null)
    {
        Smartworks.ColumnField[] dSOrderDetail = new Smartworks.ColumnField[1];
        dSOrderDetail[0] = new Smartworks.ColumnField("@SOrderDetailId", SOrderDetailId);
        if (customdataAcess != null)
        {
            customdataAcess.ExecuteStoredProcedure("dbo.DeleteSODetailByDetailId", dSOrderDetail);
        }
        else
        {
            dataAccess.BeginTransaction();
            dataAccess.ExecuteStoredProcedure("dbo.DeleteSODetailByDetailId", dSOrderDetail);
            dataAccess.TransCommit();
        }
    }

    public int DeleteSOrderMaster(int SOrderMasterId, Smartworks.DAL customdataAcess = null)
    {
        int Id = -1;
        Smartworks.ColumnField[] dSOrder = new Smartworks.ColumnField[1];
        dSOrder[0] = new Smartworks.ColumnField("@SOrderId", SOrderMasterId);
        if (customdataAcess != null)
        {
            Id = Convert.ToInt32(customdataAcess.ExecuteStoredProcedure("dbo.DeleteSOrderMaster", dSOrder));
        }
        else
        {
            dataAccess.BeginTransaction();
            Id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.DeleteSOrderMaster", dSOrder));
            dataAccess.TransCommit();
        }
        return Id;
    }

    public int GetSalesOrderMasterIdByCode(string Code) //int FYear , bool IsAllYear = false
    {
        int SOrderMasterId = -1;
        DataTable dt = new DataTable();
        dt = dataAccess.getDataTable("Select SOrderId from SOrderMaster where SOrderNo =  '"+ Code +"' ");
        if (dt.Rows.Count > 0)
        {
            SOrderMasterId = Convert.ToInt32(dt.Rows[0]["SOrderId"].ToString());
        }
        return SOrderMasterId;
    }

    public string GetSaleOrderNoBySOrderId(int SOrderId, Smartworks.DAL customdataAcess = null)
    {
        string SOrderNo = "";
        try
        {
            if (customdataAcess != null)
            {
                SOrderNo = customdataAcess.getDataTable("Select * FROM SOrderMaster WHERE  SOrderId =" + SOrderId).Rows[0]["SOrderNo"].ToString();
            }
            else
            {
                SOrderNo = dataAccess.getDataTable("Select * FROM SOrderMaster WHERE  SOrderId =" + SOrderId).Rows[0]["SOrderNo"].ToString();
            }

        }
        catch (Exception ex)
        {
            SOrderNo = "";
        }


        return SOrderNo;
    }

    public DataTable GetSaleOrderMaster(int SOrderId)
    {
        return dataAccess.getDataTable("Select * FROM SOrderMaster WHERE  SOrderId =" + SOrderId);
    }

    public DataTable GetOrderQtyBySOAndDetailProductId(int SOrderId, int DetailProductId, int PMId)
    {
        return dataAccess.getDataTable(" Select SOD.OrderQty  , ProcessQty = ( Select  isnull(sum(ProcessQty),0) as ProcessQty from ProductionMaster where SOrderNo = SOM.SOrderNo and ProductId = '" + DetailProductId + "' and PMId <> '" + PMId + "' ) from SOrderMaster SOM " +
" inner join SOrderDetails SOD on SOM.SOrderId = SOD.SOrderId where SOM.SOrderId = '" + SOrderId + "' and SOD.ProductId = '" + DetailProductId + "' ");
    }

    public DataTable GetOrderQtyBySOAndDetailProductIdForProcessing(int SOrderId, int DetailProductId, string SOrderNo)
    {
        return dataAccess.getDataTable(" Select SOD.OrderQty ,  DoneQty = Isnull((Select Sum(ProcessQty) as DoneQty  from ProcessMaster where SOrderNo = '" + SOrderNo + "'  and ProductId = '" + DetailProductId + "' ) ,0)" +
                                         "  from SOrderMaster SOM  inner join SOrderDetails SOD on SOM.SOrderId = SOD.SOrderId where SOM.SOrderId = '" + SOrderId + "' and SOD.ProductId = '" + DetailProductId + "' ");
    }

    public decimal GetOrderQtyBySONoandProductCode(string SOrderNo, string ProductCode)
    {
        decimal result = 0;
        try
        {
            result = Convert.ToDecimal(dataAccess.getDataTable(" Select SOD.OrderQty from SOrderMaster SOM inner join SOrderDetails SOD on SOM.SOrderID = SOD.SOrderId  inner join Product on SOD.ProductId = Product.ProductId " +
            " where SOM.SOrderNo = '" + SOrderNo + "' and Product.ProductCode = '" + ProductCode + "' ").Rows[0]["OrderQty"]);
        }
        catch (Exception ex)
        {
            result = 0;
        }
        return result;
    }

    public void UpdateSODetail_ProcessingComplete(string SOrderNo, int ProductId, Smartworks.DAL customDataAcess)
    {
        if (customDataAcess != null)
        {
            customDataAcess.ExecuteNonQuery("Update  SOD set SOD.ProcessingClosed = 1 from SOrderDetails SOD  inner join SOrderMaster SOM on SOM.SOrderId = SOD.SOrderId  where SOM.SOrderNo = '" + SOrderNo + "' and SOD.ProductId = '" + ProductId + "' ");
        }
        else
        {
            dataAccess.ExecuteNonQuery("Update  SOD set SOD.ProcessingClosed = 1 from SOrderDetails SOD  inner join SOrderMaster SOM on SOM.SOrderId = SOD.SOrderId  where SOM.SOrderNo = '" + SOrderNo + "' and SOD.ProductId = '" + ProductId + "' ");
        }
    }

    public void UpdateSODetail_ProcessingUnComplete(string SOrderNo, int ProductId, Smartworks.DAL customDataAcess)
    {
        if (customDataAcess != null)
        {
            customDataAcess.ExecuteNonQuery("Update  SOD set SOD.ProcessingClosed = 0 from SOrderDetails SOD  inner join SOrderMaster SOM on SOM.SOrderId = SOD.SOrderId  where SOM.SOrderNo = '" + SOrderNo + "' and SOD.ProductId = '" + ProductId + "' ");
        }
        else
        {
            dataAccess.ExecuteNonQuery("Update  SOD set SOD.ProcessingClosed = 0 from SOrderDetails SOD  inner join SOrderMaster SOM on SOM.SOrderId = SOD.SOrderId  where SOM.SOrderNo = '" + SOrderNo + "' and SOD.ProductId = '" + ProductId + "' ");
        }
    }

    public void Check_And_Update_SOMaster_ProcessingClosed(string SOrderNo, Smartworks.DAL customDataAcess)
    {
        //yeh Method is liye banaya hai k agr Sales Order Detail k all Item Processing Closed Mark hogye hain toh Sales Master ko bhi Processing Closed Mark maar do , q k bar bar search mai uska naam nh aye ga .
        Smartworks.ColumnField[] SOrderProcess = new Smartworks.ColumnField[1];
        SOrderProcess[0] = new Smartworks.ColumnField("@SOrderNo", SOrderNo);

        if (customDataAcess != null)
        {
            customDataAcess.ExecuteStoredProcedure("CheckAndUpdateSO_ProcessingClosed", SOrderProcess);
        }
        else
        {
            dataAccess.ExecuteStoredProcedure("CheckAndUpdateSO_ProcessingClosed", SOrderProcess);
        }
    }


    public DataTable GetSalesOrderListForLookupEdit()
    {
        return dataAccess.getDataTable("Select SOrderId  , SOrderNo , OrderDate , TQuantity , Customer.CustomerName as CustomerName  from SOrderMaster left join Customer on SOrderMaster.CustomerCode = Customer.Code");
    }
    #region Order Reports
    public DataTable GetSalesOrderReport(Nullable<DateTime> FromDate, Nullable<DateTime> ToDate, string FromSONo, string ToSONo, string FromCustomer, string ToCustomer, int SOrderId)
    {
        DataTable dtReport = new DataTable();
        Smartworks.ColumnField[] rPOrder = new Smartworks.ColumnField[7];
        if (FromDate == null)
        {
            rPOrder[0] = new Smartworks.ColumnField("@FromDate", DBNull.Value);
        }
        else
        {
            rPOrder[0] = new Smartworks.ColumnField("@FromDate", FromDate);
        }

        if (ToDate == null)
        {
            rPOrder[1] = new Smartworks.ColumnField("@ToDate", DBNull.Value);
        }
        else
        {
            rPOrder[1] = new Smartworks.ColumnField("@ToDate", ToDate);
        }
        rPOrder[2] = new Smartworks.ColumnField("@FromSOrderNo", FromSONo);
        rPOrder[3] = new Smartworks.ColumnField("@ToSOrderNo", ToSONo);

        rPOrder[4] = new Smartworks.ColumnField("@FromCustomer", FromCustomer);
        rPOrder[5] = new Smartworks.ColumnField("@ToCustomer", ToCustomer);

        rPOrder[6] = new Smartworks.ColumnField("@SOrderId", SOrderId);

        dtReport = dataAccess.getDataTableByStoredProcedure("dbo.sp_ReportSalesOrder", rPOrder);
        return dtReport;
    }
    #endregion

    #endregion


    #region Navigation

    public string GetMinInvioceNo()
    {
        string InvoiceNo = "";
        DataTable dt = new DataTable();

        dt = dataAccess.getDataTable("select min(SOrderNo) as 'InvoiceNo' from SOrderMaster");
        if (dt.Rows.Count > 0)
        {
            InvoiceNo = dt.Rows[0]["InvoiceNo"].ToString();
        }
        return InvoiceNo;
    }

    public string GetMaxInvioceNo()
    {
        string InvoiceNo = "";
        DataTable dt = new DataTable();

        dt = dataAccess.getDataTable("select max(SOrderNo) as 'InvoiceNo' from SOrderMaster ");
        if (dt.Rows.Count > 0)
        {
            InvoiceNo = dt.Rows[0]["InvoiceNo"].ToString();
        }
        return InvoiceNo;
    }


    public string GetNextInvioceNo(string Code)
    {
        string InvoiceNo = "";
        DataTable dt = new DataTable();
        dt = dataAccess.getDataTable("Select dbo.GetNextNumber('" + Code + "') as InvoiceNo ");
        if (dt.Rows.Count > 0)
        {
            InvoiceNo = (string)dt.Rows[0]["InvoiceNo"].ToString();
        }
        return InvoiceNo;
    }

    public string GetPrevInvioceNo(string Code)
    {
        string InvoiceNo = "";
        DataTable dt = new DataTable();
        dt = dataAccess.getDataTable("Select dbo.GetPreviousNumber('" + Code + "') as InvoiceNo");
        if (dt.Rows.Count > 0)
        {
            InvoiceNo = (string)dt.Rows[0]["InvoiceNo"].ToString();
        }
        return InvoiceNo;
    }


    #endregion


    #region Grade
    public DataTable GetGradeList()
    {
        return dataAccess.getDataTable("Select * from Grade");
    }
    #endregion

}

