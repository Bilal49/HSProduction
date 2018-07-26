using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;


public class PackingListManager
{
    Smartworks.DAL dataAccess = new Smartworks.DAL();
    public PackingListManager()
    {

        string connString = ConfigurationManager.ConnectionStrings["HSConnectionString"].ConnectionString;
        Smartworks.DAL.ConnectionString = connString;
    }

    #region Packing List

    public DataSet GetPackingListStructureBySOId(int SOrderId)
    {
        DataSet ds = new DataSet();
        Smartworks.ColumnField[] getPackingList = new Smartworks.ColumnField[1];
        getPackingList[0] = new Smartworks.ColumnField("@SOrderId", SOrderId);
        ds = dataAccess.getDataSetByStoredProcedure("sp_GetPackingListStructureBySOId", getPackingList);
        return ds;
    }

    public DataSet GetPackingListStructure(int PLId)
    {
        DataSet ds = new DataSet();
        Smartworks.ColumnField[] getPackingList = new Smartworks.ColumnField[1];
        getPackingList[0] = new Smartworks.ColumnField("@PackingListId", PLId);
        ds = dataAccess.getDataSetByStoredProcedure("sp_GetPackingListStructure", getPackingList);
        return ds;
    }

    public DataTable InsertPackingListMaster(string SOrderNo, DateTime Date, DateTime SODate,int WarehouseId , string CustomerCode, string EmployeeCode, decimal TQuantity, 
        bool Closed, string Remarks, string GatePassNo ,  int AddedBy, DateTime AddedOn, string AddedIpAddr, Smartworks.DAL customdataAcess = null)
    {
        DataTable dt = new DataTable();
        Smartworks.ColumnField[] iPackingList = new Smartworks.ColumnField[13];
        iPackingList[0] = new Smartworks.ColumnField("@SOrderNo", SOrderNo);
        iPackingList[1] = new Smartworks.ColumnField("@Date", Date);
        iPackingList[2] = new Smartworks.ColumnField("@SODate", SODate);
        iPackingList[3] = new Smartworks.ColumnField("@WarehouseId", WarehouseId);
        iPackingList[4] = new Smartworks.ColumnField("@CustomerCode", CustomerCode);
        iPackingList[5] = new Smartworks.ColumnField("@EmployeeCode", EmployeeCode);
        iPackingList[6] = new Smartworks.ColumnField("@TQuantity", TQuantity);
        iPackingList[7] = new Smartworks.ColumnField("@Closed", Closed);
        iPackingList[8] = new Smartworks.ColumnField("@Remarks", Remarks);
        iPackingList[9] = new Smartworks.ColumnField("@GatePassNo", GatePassNo);
        iPackingList[10] = new Smartworks.ColumnField("@AddedBy", AddedBy);
        iPackingList[11] = new Smartworks.ColumnField("@AddedOn", AddedOn);
        iPackingList[12] = new Smartworks.ColumnField("@AddedIpAddr", AddedIpAddr);
        if (customdataAcess != null)
        {
            dt = customdataAcess.getDataTableByStoredProcedure("dbo.InsertPackingListMaster", iPackingList);
        }
        else
        {
            dataAccess.BeginTransaction();
            dt = dataAccess.getDataTableByStoredProcedure("dbo.InsertPackingListMaster", iPackingList);
            dataAccess.TransCommit();
        }
        return dt;
    }

    public void UpdatePackingList(int PackingListId, string SOrderNo, DateTime Date, DateTime SODate , int WarehouseId , string CustomerCode, string EmployeeCode
        , decimal TQuantity, bool Closed, string Remarks, string GatePassNo ,  int AddedBy, DateTime AddedOn, string AddedIpAddr, Smartworks.DAL customdataAcess = null)
    {

        Smartworks.ColumnField[] uPackingList = new Smartworks.ColumnField[14];
        uPackingList[0] = new Smartworks.ColumnField("@PackingListId", PackingListId);
        uPackingList[1] = new Smartworks.ColumnField("@SOrderNo", SOrderNo);
        uPackingList[2] = new Smartworks.ColumnField("@Date", Date);
        uPackingList[3] = new Smartworks.ColumnField("@SODate", SODate);
        uPackingList[4] = new Smartworks.ColumnField("@WarehouseId", WarehouseId);
        uPackingList[5] = new Smartworks.ColumnField("@CustomerCode", CustomerCode);
        uPackingList[6] = new Smartworks.ColumnField("@EmployeeCode", EmployeeCode);
        uPackingList[7] = new Smartworks.ColumnField("@TQuantity", TQuantity);
        uPackingList[8] = new Smartworks.ColumnField("@Closed", Closed);
        uPackingList[9] = new Smartworks.ColumnField("@Remarks", Remarks);
        uPackingList[10] = new Smartworks.ColumnField("@GatePassNo", GatePassNo);
        uPackingList[11] = new Smartworks.ColumnField("@UpdatedBy", AddedBy);
        uPackingList[12] = new Smartworks.ColumnField("@UpdatedOn", AddedOn);
        uPackingList[13] = new Smartworks.ColumnField("@UpdatedIpAddr", AddedIpAddr);

        if (customdataAcess != null)
        {
            customdataAcess.ExecuteStoredProcedure("dbo.UpdatePackingListMaster", uPackingList);
        }
        else
        {
            dataAccess.BeginTransaction();
            dataAccess.ExecuteStoredProcedure("dbo.UpdatePackingListMaster", uPackingList);
            dataAccess.TransCommit();
        }
    }


    public int InsertUpdatePackingListDetail(int PLDetailId, int PackingListId, int SOrderId ,  int ProductId, decimal S39, decimal S40, decimal S41, decimal S42, decimal S43, decimal S44, decimal S45, decimal S46, decimal S47,
 decimal OrderQty, int AddedBy, DateTime AddedOn, string AddedIpAddr, int GradeId ,  Smartworks.DAL customdataAcess)
    {

        int Id = -1;
        Smartworks.ColumnField[] iuPackingDetail = new Smartworks.ColumnField[18];
        iuPackingDetail[0] = new Smartworks.ColumnField("@PLDetailId", PLDetailId);
        iuPackingDetail[1] = new Smartworks.ColumnField("@PackingListId", PackingListId);
        iuPackingDetail[2] = new Smartworks.ColumnField("@SOrderId", SOrderId);
        iuPackingDetail[3] = new Smartworks.ColumnField("@ProductId", ProductId);
        iuPackingDetail[4] = new Smartworks.ColumnField("@S39", S39);
        iuPackingDetail[5] = new Smartworks.ColumnField("@S40", S40);
        iuPackingDetail[6] = new Smartworks.ColumnField("@S41", S41);
        iuPackingDetail[7] = new Smartworks.ColumnField("@S42", S42);
        iuPackingDetail[8] = new Smartworks.ColumnField("@S43", S43);
        iuPackingDetail[9] = new Smartworks.ColumnField("@S44", S44);
        iuPackingDetail[10] = new Smartworks.ColumnField("@S45", S45);
        iuPackingDetail[11] = new Smartworks.ColumnField("@S46", S46);
        iuPackingDetail[12] = new Smartworks.ColumnField("@S47", S47);
        iuPackingDetail[13] = new Smartworks.ColumnField("@OrderQty", OrderQty);
        iuPackingDetail[14] = new Smartworks.ColumnField("@AddedBy", AddedBy);
        iuPackingDetail[15] = new Smartworks.ColumnField("@AddedOn", AddedOn);
        iuPackingDetail[16] = new Smartworks.ColumnField("@AddedIpAddr", AddedIpAddr);
        iuPackingDetail[17] = new Smartworks.ColumnField("@GradeId", GradeId);

        if (customdataAcess != null)
        {
            Id = Convert.ToInt32(customdataAcess.ExecuteStoredProcedure("dbo.InsertUpdatePackingListDetail", iuPackingDetail));
        }
        else
        {
            dataAccess.BeginTransaction();
            Id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.InsertUpdatePackingListDetail", iuPackingDetail));
            dataAccess.TransCommit();
        }
        return Id;
    }


    public void DeletePackingListDetailByDetailId(int PLDetailId, Smartworks.DAL customdataAcess = null)
    {
        Smartworks.ColumnField[] dPackingDetail = new Smartworks.ColumnField[1];
        dPackingDetail[0] = new Smartworks.ColumnField("@PLDetailId", PLDetailId);
        if (customdataAcess != null)
        {
            customdataAcess.ExecuteStoredProcedure("dbo.DeletePackingListDetailByDetailId", dPackingDetail);
        }
        else
        {
            dataAccess.BeginTransaction();
            dataAccess.ExecuteStoredProcedure("dbo.DeletePackingListDetailByDetailId", dPackingDetail);
            dataAccess.TransCommit();
        }
    }

    public int DeletePackingListMaster(int PackingListId, Smartworks.DAL customdataAcess = null)
    {
        int Id = -1;
        Smartworks.ColumnField[] dPackingList = new Smartworks.ColumnField[1];
        dPackingList[0] = new Smartworks.ColumnField("@PackingListId", PackingListId);
        if (customdataAcess != null)
        {
            Id = Convert.ToInt32(customdataAcess.ExecuteStoredProcedure("dbo.DeletePackingListMaster", dPackingList));
        }
        else
        {
            dataAccess.BeginTransaction();
            Id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.DeletePackingListMaster", dPackingList));
            dataAccess.TransCommit();
        }
        return Id;
    }

    public int GetPackingListMasterIdByCode(string Code) //, int FYear
    {
        int PackingListMasterId = -1;
        DataTable dt = new DataTable();
        dt = dataAccess.getDataTable("Select PackingListId from PackingListMaster where PackingListNo = '" + Code + "'");
        if (dt.Rows.Count > 0)
        {
            PackingListMasterId = Convert.ToInt32(dt.Rows[0]["PackingListId"].ToString());
        }
        return PackingListMasterId;
    }

    public int GetPendingPackingListMasterIdByCode(string Code)
    {
        int PackingListMasterId = -1;
        DataTable dt = new DataTable();
        dt = dataAccess.getDataTable("Select PackingListId from PackingListMaster where PackingListNo = '" + Code + "' and Closed <> 1 ");
        if (dt.Rows.Count > 0)
        {
            PackingListMasterId = Convert.ToInt32(dt.Rows[0]["PackingListId"].ToString());
        }
        return PackingListMasterId;
    }

    public DataTable GetPackingListMaster(int PackingListMasterId)
    {
        return dataAccess.getDataTable("Select * FROM PackingListMaster WHERE  PackingListId =" + PackingListMasterId);
    }


    public void UpdatePackingListClosed(int PackingListId, Smartworks.DAL customdataAcess= null)
    {
        if (customdataAcess != null)
        {
            customdataAcess.ExecuteNonQuery("Update PackingListMaster set Closed  = 1 where PackingListId =" + PackingListId );
        }
        else
        {
            dataAccess.ExecuteNonQuery("Update PackingListMaster set Closed  = 1 where PackingListId =" + PackingListId);
        }
    }

    public void UpdatePackingListUnClosed(int PackingListId, Smartworks.DAL customdataAcess = null)
    {
        if (customdataAcess != null)
        {
            customdataAcess.ExecuteNonQuery("Update PackingListMaster set Closed  = 0 where PackingListId =" + PackingListId);
        }
        else
        {
            dataAccess.ExecuteNonQuery("Update PackingListMaster set Closed  = 0 where PackingListId =" + PackingListId);
        }
    }

    public bool IsPackingListClosed(int PackingListMasterId)
    {
        bool result = false;
        result = Convert.ToBoolean(dataAccess.getDataTable("Select isnull(Closed,0) as Closed from PackingListMaster where PackingListId= " + PackingListMasterId).Rows[0]["Closed"]);
        return result;
    }

    public DataTable GetReportPackingList(int PackingListMasterId)
    {
        DataTable dtReport = new DataTable();
        Smartworks.ColumnField[] rList = new Smartworks.ColumnField[1];
        rList[0] = new Smartworks.ColumnField("@PackingListId", PackingListMasterId);
        dtReport = dataAccess.getDataTableByStoredProcedure("sp_ReportPackingList", rList);
        return dtReport;
    }


    public DataTable GetReportPackingListStatus(DateTime FromDate , DateTime ToDate , string FromSONo , string ToSONo , string FromProductCode , string ToProductCode)
    {
        DataTable dtReport = new DataTable();
        Smartworks.ColumnField[] rList = new Smartworks.ColumnField[6];
        rList[0] = new Smartworks.ColumnField("@FromDate", FromDate);
        rList[1] = new Smartworks.ColumnField("@ToDate", ToDate);
        rList[2] = new Smartworks.ColumnField("@FromSONo", FromSONo);
        rList[3] = new Smartworks.ColumnField("@ToSONo", ToSONo);
        rList[4] = new Smartworks.ColumnField("@FromProductCode", FromProductCode);
        rList[5] = new Smartworks.ColumnField("@ToProductCode", ToProductCode);
        dtReport = dataAccess.getDataTableByStoredProcedure("sp_ReportPendingPackingListStatus", rList);
        return dtReport;
    }

//    public DataTable GetOrderQtyBySOAndDetailProductId(int SOrderId, int DetailProductId , int PMId)
//    {
//        return dataAccess.getDataTable(" Select SOD.OrderQty  , ProcessQty = ( Select  isnull(sum(ProcessQty),0) as ProcessQty from ProductionMaster where SOrderNo = SOM.SOrderNo and ProductId = '" + DetailProductId + "' and PMId <> '"+ PMId +"' ) from SOrderMaster SOM " +
//" inner join SOrderDetails SOD on SOM.SOrderId = SOD.SOrderId where SOM.SOrderId = '" + SOrderId + "' and SOD.ProductId = '" + DetailProductId + "' ");
//    }


    //#region Order Reports
    //public DataTable GetSalesOrderReport(Nullable<DateTime> FromDate, Nullable<DateTime> ToDate, string FromSONo, string ToSONo, string FromCustomer, string ToCustomer, int SOrderId)
    //{
    //    DataTable dtReport = new DataTable();
    //    Smartworks.ColumnField[] rPOrder = new Smartworks.ColumnField[7];
    //    if (FromDate == null)
    //    {
    //        rPOrder[0] = new Smartworks.ColumnField("@FromDate", DBNull.Value);
    //    }
    //    else
    //    {
    //        rPOrder[0] = new Smartworks.ColumnField("@FromDate", FromDate);
    //    }

    //    if (ToDate == null)
    //    {
    //        rPOrder[1] = new Smartworks.ColumnField("@ToDate", DBNull.Value);
    //    }
    //    else
    //    {
    //        rPOrder[1] = new Smartworks.ColumnField("@ToDate", ToDate);
    //    }
    //    rPOrder[2] = new Smartworks.ColumnField("@FromSOrderNo", FromSONo);
    //    rPOrder[3] = new Smartworks.ColumnField("@ToSOrderNo", ToSONo);

    //    rPOrder[4] = new Smartworks.ColumnField("@FromCustomer", FromCustomer);
    //    rPOrder[5] = new Smartworks.ColumnField("@ToCustomer", ToCustomer);

    //    rPOrder[6] = new Smartworks.ColumnField("@SOrderId", SOrderId);

    //    dtReport = dataAccess.getDataTableByStoredProcedure("dbo.sp_ReportSalesOrder", rPOrder);
    //    return dtReport;
    //}
    //#endregion

    #endregion


    #region Navigation

    public string GetMinPLNo()
    {
        string InvoiceNo = "";
        DataTable dt = new DataTable();

        dt = dataAccess.getDataTable("select min(PackingListNo) as 'InvoiceNo' from PackingListMaster");
        if (dt.Rows.Count > 0)
        {
            InvoiceNo = dt.Rows[0]["InvoiceNo"].ToString();
        }
        return InvoiceNo;
    }

    public string GetMaxPLNo()
    {
        string InvoiceNo = "";
        DataTable dt = new DataTable();

        dt = dataAccess.getDataTable("select max(PackingListNo) as 'InvoiceNo' from PackingListMaster");
        if (dt.Rows.Count > 0)
        {
            InvoiceNo = dt.Rows[0]["InvoiceNo"].ToString();
        }
        return InvoiceNo;
    }


    public string GetNextPLNo(string Code)
    {
        string InvoiceNo = "";
        DataTable dt = new DataTable();
        dt = dataAccess.getDataTable("Select dbo.GetNextNumber('" + Code + "') as InvoiceNo ");
        if (dt.Rows.Count > 0)
        {
            InvoiceNo = dt.Rows[0]["InvoiceNo"].ToString();
        }
        return InvoiceNo;
    }

    public string GetPrevPLNo(string Code)
    {
        string InvoiceNo = "";
        DataTable dt = new DataTable();
        dt = dataAccess.getDataTable("Select dbo.GetPreviousNumber('" + Code + "') as InvoiceNo");
        if (dt.Rows.Count > 0)
        {
            InvoiceNo = dt.Rows[0]["InvoiceNo"].ToString();
        }
        return InvoiceNo;
    }


    #endregion

}

