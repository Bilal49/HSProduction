using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;


public class StockRequisitionManager
{
    Smartworks.DAL dataAccess = new Smartworks.DAL();
    public StockRequisitionManager()
    {
        string connString = ConfigurationManager.ConnectionStrings["HSConnectionString"].ConnectionString;
        Smartworks.DAL.ConnectionString = connString;
    }

    public DataSet GetRequisitionStructure(int RequisitionId)
    {
        DataSet ds = new DataSet();
        Smartworks.ColumnField[] getREQ = new Smartworks.ColumnField[1];
        getREQ[0] = new Smartworks.ColumnField("@StockReqMasterId", RequisitionId);
        ds = dataAccess.getDataSetByStoredProcedure("sp_GetRequisitionStructure", getREQ);
        return ds;
    }

    public DataTable InsertStockRequisition(DateTime Date, string OrderedBy, string DeliveredBy, int FromWarehouseId, int ToWarehouseId,
        string Remarks, string BranchCode, bool Closed, bool IsApproved,  string ReqType , Smartworks.DAL customdataAccess = null)
    {
        DataTable dt = new DataTable();
        Smartworks.ColumnField[] iREQ = new Smartworks.ColumnField[10];
        iREQ[0] = new Smartworks.ColumnField("@Date", Date);
        iREQ[1] = new Smartworks.ColumnField("@OrderedBy", OrderedBy);
        iREQ[2] = new Smartworks.ColumnField("@DeliveredBy", DeliveredBy);
        iREQ[3] = new Smartworks.ColumnField("@FromWarehouseId", FromWarehouseId);
        iREQ[4] = new Smartworks.ColumnField("@ToWarehouseId", ToWarehouseId);
        iREQ[5] = new Smartworks.ColumnField("@Remarks", Remarks);
        iREQ[6] = new Smartworks.ColumnField("@BranchCode", BranchCode);
        iREQ[7] = new Smartworks.ColumnField("@Closed", Closed);
        iREQ[8] = new Smartworks.ColumnField("@IsApproved", IsApproved);
        iREQ[9] = new Smartworks.ColumnField("@ReqType", ReqType);
        

        if (customdataAccess != null)
        {
            dt = customdataAccess.getDataTableByStoredProcedure("InsertStockReqMaster", iREQ);
        }
        else
        {
            dataAccess.BeginTransaction();
            dt = dataAccess.getDataTableByStoredProcedure("InsertStockReqMaster", iREQ);
            dataAccess.TransCommit();
        }

        return dt;
    }


    public void UpdateStockRequisition(int StockReqMasterId, DateTime Date, string OrderedBy, string DeliveredBy, int FromWarehouseId, int ToWarehouseId,
       string Remarks, string BranchCode, bool Closed, bool IsApproved, Smartworks.DAL customdataAccess = null)
    {   
        Smartworks.ColumnField[] uREQ = new Smartworks.ColumnField[10];
        uREQ[0] = new Smartworks.ColumnField("@StockReqMasterId", StockReqMasterId);
        uREQ[1] = new Smartworks.ColumnField("@Date", Date);
        uREQ[2] = new Smartworks.ColumnField("@OrderedBy", OrderedBy);
        uREQ[3] = new Smartworks.ColumnField("@DeliveredBy", DeliveredBy);
        uREQ[4] = new Smartworks.ColumnField("@FromWarehouseId", FromWarehouseId);
        uREQ[5] = new Smartworks.ColumnField("@ToWarehouseId", ToWarehouseId);
        uREQ[6] = new Smartworks.ColumnField("@Remarks", Remarks);
        uREQ[7] = new Smartworks.ColumnField("@BranchCode", BranchCode);
        uREQ[8] = new Smartworks.ColumnField("@Closed", Closed);
        uREQ[9] = new Smartworks.ColumnField("@IsApproved", IsApproved);

        if (customdataAccess != null)
        {
            customdataAccess.ExecuteStoredProcedure("UpdateStockReqMaster", uREQ);
        }
        else
        {
            dataAccess.BeginTransaction();
            dataAccess.ExecuteStoredProcedure("UpdateStockReqMaster", uREQ);
            dataAccess.TransCommit();
        }

        
    }


    public int InsertUpdateRequisitionDetail(int StockReqDetailId , int StockReqMasterId , int ProductId , decimal Qty , Smartworks.DAL customdataAccess  = null )
    {
        int Id = -1;
         Smartworks.ColumnField[] iuREQDetail = new Smartworks.ColumnField[4];
         iuREQDetail[0] = new Smartworks.ColumnField("@StockReqDetailId", StockReqDetailId);
         iuREQDetail[1] = new Smartworks.ColumnField("@StockReqMasterId", StockReqMasterId);
         iuREQDetail[2] = new Smartworks.ColumnField("@ProductId", ProductId);
         iuREQDetail[3] = new Smartworks.ColumnField("@Qty", Qty);

        if (customdataAccess != null)
        {
            Id = Convert.ToInt32(customdataAccess.ExecuteStoredProcedure("InsertUpdateStockReqDetail", iuREQDetail));
        }
        else
        {
            dataAccess.BeginTransaction();
            Id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("InsertUpdateStockReqDetail", iuREQDetail));
            dataAccess.TransCommit();
           
        }

        return Id;
    }


    public int DeleteRequisitionMaster(int StockReqMasterId, Smartworks.DAL customdataAccess = null)
    {
        int Id = -1;

        Smartworks.ColumnField[] dREQ = new Smartworks.ColumnField[1];
        dREQ[0] = new Smartworks.ColumnField("@StockReqMasterId", StockReqMasterId);
        if (customdataAccess != null)
        {
            Id = Convert.ToInt32(customdataAccess.ExecuteStoredProcedure("dbo.DeleteStockReqMaster", dREQ));
        }
        else
        {
            dataAccess.BeginTransaction();
            Id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.DeleteStockReqMaster", dREQ));
            dataAccess.TransCommit();
        }
        return Id;
    }

    public void DeleteRequisitionDetailByDetailId(int StockReqDetailId , Smartworks.DAL customdataAcess = null)
    {
        Smartworks.ColumnField[] dReqDetail = new Smartworks.ColumnField[1];
        dReqDetail[0] = new Smartworks.ColumnField("@StockReqDetailId", StockReqDetailId);
        if (customdataAcess != null)
        {
            customdataAcess.ExecuteStoredProcedure("dbo.DeleteReqDetailByDetailId", dReqDetail);
        }
        else
        {
            dataAccess.BeginTransaction();
            dataAccess.ExecuteStoredProcedure("dbo.DeleteReqDetailByDetailId", dReqDetail);
            dataAccess.TransCommit();
        }
    }


    public int GetReqMasterIdByCode(string Code)
    {
        int ReqMasterId = -1;
        DataTable dt = new DataTable();
        dt = dataAccess.getDataTable("Select StockReqMasterId from StockReqMaster where StockReqNo = '" + Code + "' ");
        if (dt.Rows.Count > 0)
        {
            ReqMasterId = (int)dt.Rows[0]["StockReqMasterId"];
        }
        return ReqMasterId;
    }


    #region Requisition Approval 

    public bool UpdateRequisitionApproved(int RequisitionId , Smartworks.DAL customdataAcess) 
    {
        bool result = false;
        if (customdataAcess != null)
        {
            result = Convert.ToBoolean(customdataAcess.ExecuteNonQuery("Update [StockReqMaster]  set  IsApproved = 1 where StockReqMasterId = " + RequisitionId));
        }
        else
        {
           result = Convert.ToBoolean(dataAccess.ExecuteNonQuery("Update [StockReqMaster]  set  IsApproved = 1 where StockReqMasterId = " + RequisitionId));
        }
        return result;
    }

    #endregion


    #region Navigation

    public string GetMinInvioceNo()
    {
        string InvoiceNo = "";
        DataTable dt = new DataTable();

        dt = dataAccess.getDataTable("select min(StockReqNo) as 'InvoiceNo' from StockReqMaster");
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

        dt = dataAccess.getDataTable("select max(StockReqNo) as 'InvoiceNo' from StockReqMaster");
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


}

