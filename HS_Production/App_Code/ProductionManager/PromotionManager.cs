using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;

public class PromotionManager
{
    Smartworks.DAL dataAccess = new Smartworks.DAL();
    public PromotionManager()
    {

        string connString = ConfigurationManager.ConnectionStrings["HSConnectionString"].ConnectionString;
        Smartworks.DAL.ConnectionString = connString;
    }

    public DataSet GetPromotionStructure(int PromotionId)
    {
        DataSet ds = new DataSet();
        Smartworks.ColumnField[] getPromotion = new Smartworks.ColumnField[1];
        getPromotion[0] = new Smartworks.ColumnField("@PromotionId", PromotionId);
        ds = dataAccess.getDataSetByStoredProcedure("sp_GetPromotionStructure", getPromotion);
        return ds;
    }

    public DataSet GetPromotionStructureBySONoAndProductCode(string SOrderNo, int ProductId)
    {
        DataSet ds = new DataSet();
        Smartworks.ColumnField[] getPromotion = new Smartworks.ColumnField[2];
        getPromotion[0] = new Smartworks.ColumnField("@SOrderNo", SOrderNo);
        getPromotion[1] = new Smartworks.ColumnField("@ProductId", ProductId);
        ds = dataAccess.getDataSetByStoredProcedure("sp_GetPromotionStructureBySONoAndProductId", getPromotion);
        return ds;
    }

    public int GetPromotionIdByCode(string Code)
    {
        int Id = -1;
        DataTable dt = new DataTable();
        dt = dataAccess.getDataTable("Select PromotionId from PromotionMaster where PromotionNo = '"+ Code +"'");
        if (dt.Rows.Count > 0)
        {
            Id = Convert.ToInt32(dt.Rows[0]["PromotionId"].ToString());
        }
        return Id;
    }

    public DataTable InsertPromotionMaster(DateTime Date, string SOrderNo, int ProductId, string Remarks, int GradeId, int WarehouseFrom  , int WarehouseTo , int AddedBy,
        DateTime AddedOn, string AddedIPAddr, Smartworks.DAL customdataAcess= null)
    {
        DataTable dt = new DataTable();
        Smartworks.ColumnField[] iPromotion = new Smartworks.ColumnField[10];
        iPromotion[0] = new Smartworks.ColumnField("@Date", Date);
        iPromotion[1] = new Smartworks.ColumnField("@SOrderNo", SOrderNo);
        iPromotion[2] = new Smartworks.ColumnField("@ProductId", ProductId);
        iPromotion[3] = new Smartworks.ColumnField("@Remarks", Remarks);
        iPromotion[4] = new Smartworks.ColumnField("@GradeId", GradeId);
        iPromotion[5] = new Smartworks.ColumnField("@WarehouseFrom", WarehouseFrom);
        iPromotion[6] = new Smartworks.ColumnField("@WarehouseTo", WarehouseTo);
        iPromotion[7] = new Smartworks.ColumnField("@AddedBy", AddedBy);
        iPromotion[8] = new Smartworks.ColumnField("@AddedOn", AddedOn);
        iPromotion[9] = new Smartworks.ColumnField("@AddedIPAddr", AddedIPAddr);

        if (customdataAcess != null)
        {
            dt = customdataAcess.getDataTableByStoredProcedure("dbo.InsertPromotionMaster", iPromotion);
        }
        else
        {
            dataAccess.BeginTransaction();
            dt = dataAccess.getDataTableByStoredProcedure("dbo.InsertPromotionMaster", iPromotion);
            dataAccess.TransCommit();
        }
        return dt;
    }

    public int  UpdatePromotionMaster(int PromotionId , DateTime Date, string SOrderNo, int ProductId, string Remarks, int GradeId, int WarehouseFrom  , int WarehouseTo ,  int AddedBy,
    DateTime AddedOn, string AddedIPAddr, Smartworks.DAL customdataAcess = null)
    {
        int Id = -1;
        Smartworks.ColumnField[] uPromotion = new Smartworks.ColumnField[11];
        uPromotion[0] = new Smartworks.ColumnField("@PromotionId", PromotionId);
        uPromotion[1] = new Smartworks.ColumnField("@Date", Date);
        uPromotion[2] = new Smartworks.ColumnField("@SOrderNo", SOrderNo);
        uPromotion[3] = new Smartworks.ColumnField("@ProductId", ProductId);
        uPromotion[4] = new Smartworks.ColumnField("@Remarks", Remarks);
        uPromotion[5] = new Smartworks.ColumnField("@GradeId", GradeId);
        uPromotion[6] = new Smartworks.ColumnField("@WarehouseFrom", WarehouseFrom);
        uPromotion[7] = new Smartworks.ColumnField("@WarehouseTo", WarehouseTo);
        uPromotion[8] = new Smartworks.ColumnField("@AddedBy", AddedBy);
        uPromotion[9] = new Smartworks.ColumnField("@AddedOn", AddedOn);
        uPromotion[10] = new Smartworks.ColumnField("@AddedIPAddr", AddedIPAddr);

        if (customdataAcess != null)
        {
            Id = Convert.ToInt32(customdataAcess.ExecuteStoredProcedure("dbo.UpdatePromotionMaster", uPromotion));
        }
        else
        {
            dataAccess.BeginTransaction();
            Id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.UpdatePromotionMaster", uPromotion));
            dataAccess.TransCommit();
        }
        return Id;
    }


    public int InsertUpdatePromotionDetail(int PromotionDetailId, int PromotionId, int S39, int S40, int S41, int S42, int S43, int S44, int S45, int S46, int S47, Smartworks.DAL customdataAcess = null)
    {
        int Id = -1;
        Smartworks.ColumnField[] iuPromotionDetail = new Smartworks.ColumnField[11];
        iuPromotionDetail[0] = new Smartworks.ColumnField("@PromotionDetailId", PromotionDetailId);
        iuPromotionDetail[1] = new Smartworks.ColumnField("@PromotionId", PromotionId);
        iuPromotionDetail[2] = new Smartworks.ColumnField("@S39", S39);
        iuPromotionDetail[3] = new Smartworks.ColumnField("@S40", S40);
        iuPromotionDetail[4] = new Smartworks.ColumnField("@S41", S41);
        iuPromotionDetail[5] = new Smartworks.ColumnField("@S42", S42);
        iuPromotionDetail[6] = new Smartworks.ColumnField("@S43", S43);
        iuPromotionDetail[7] = new Smartworks.ColumnField("@S44", S44);
        iuPromotionDetail[8] = new Smartworks.ColumnField("@S45", S45);
        iuPromotionDetail[9] = new Smartworks.ColumnField("@S46", S46);
        iuPromotionDetail[10] = new Smartworks.ColumnField("@S47", S47);

        if (customdataAcess != null)
        {
            Id = Convert.ToInt32(customdataAcess.ExecuteStoredProcedure("dbo.sp_InsertUpdatePromotionDetail", iuPromotionDetail));
        }
        else
        {
            dataAccess.BeginTransaction();
            Id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.sp_InsertUpdatePromotionDetail", iuPromotionDetail));
            dataAccess.TransCommit();
        }
        return Id;
    }

    #region Order Reports
    public DataTable GetReportPromotionStatus(Nullable<DateTime> FromDate, Nullable<DateTime> ToDate, string FromSONo, string ToSONo, string FromCustomer, string ToCustomer)
    {
        DataTable dtReport = new DataTable();
        Smartworks.ColumnField[] rPOrder = new Smartworks.ColumnField[6];
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

        dtReport = dataAccess.getDataTableByStoredProcedure("dbo.sp_ReportPromotionStatus", rPOrder);
        return dtReport;
    }
    #endregion

    #region Navigation

    public string GetMinInvioceNo()
    {
        string InvoiceNo = "";
        DataTable dt = new DataTable();

        dt = dataAccess.getDataTable("select min(PromotionNo) as 'InvoiceNo' from PromotionMaster");
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

        dt = dataAccess.getDataTable("select max(PromotionNo) as 'InvoiceNo' from PromotionMaster");
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
            InvoiceNo = dt.Rows[0]["InvoiceNo"].ToString();
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
            InvoiceNo = dt.Rows[0]["InvoiceNo"].ToString();
        }
        return InvoiceNo;
    }


    #endregion

}

