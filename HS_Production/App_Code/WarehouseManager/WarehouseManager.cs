using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;

namespace FIL
{
    public class WarehouseManager
    {
        Smartworks.DAL dataAccess = new Smartworks.DAL();
        public WarehouseManager()
        {
            string connString = ConfigurationManager.ConnectionStrings["HSConnectionString"].ConnectionString;
            Smartworks.DAL.ConnectionString = connString;
        }

        #region Warehouse Setup
        public int InsertWarehouse(string Name, string Address, int Manager, string Email, string Fax, string Phone, bool IsStore, int AddedBy, DateTime AddedOn, string AddedIpAddr)
        {
            int id = 0;

            Smartworks.ColumnField[] iWarehouse = new Smartworks.ColumnField[10];
            iWarehouse[0] = new Smartworks.ColumnField("@Name", Name);
            iWarehouse[1] = new Smartworks.ColumnField("@Address", Address);
            iWarehouse[2] = new Smartworks.ColumnField("@Manager", Manager);
            iWarehouse[3] = new Smartworks.ColumnField("@Email", Email);
            iWarehouse[4] = new Smartworks.ColumnField("@Fax", Fax);
            iWarehouse[5] = new Smartworks.ColumnField("@Phone", Phone);
            iWarehouse[6] = new Smartworks.ColumnField("@AddedBy", AddedBy);
            iWarehouse[7] = new Smartworks.ColumnField("@AddedOn", AddedOn);
            iWarehouse[8] = new Smartworks.ColumnField("@AddedIpAddr", AddedIpAddr);
            iWarehouse[9] = new Smartworks.ColumnField("@IsStore", IsStore);
            dataAccess.BeginTransaction();
            id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.InsertWarehouse", iWarehouse));
            dataAccess.TransCommit();
            return id;

        }
        public void UpdateWarehouse(int WarehouseId, string Name, string Address, int Manager, string Email, string Fax, string Phone, bool IsStore,
            int UpdatedBy, DateTime UpdatedOn, string UpdatedIpAddr)
        {
            Smartworks.ColumnField[] uWarehouse = new Smartworks.ColumnField[11];
            uWarehouse[0] = new Smartworks.ColumnField("@WarehouseId", WarehouseId);
            uWarehouse[1] = new Smartworks.ColumnField("@Name", Name);
            uWarehouse[2] = new Smartworks.ColumnField("@Address", Address);
            uWarehouse[3] = new Smartworks.ColumnField("@Manager", Manager);
            uWarehouse[4] = new Smartworks.ColumnField("@Email", Email);
            uWarehouse[5] = new Smartworks.ColumnField("@Fax", Fax);
            uWarehouse[6] = new Smartworks.ColumnField("@Phone", Phone);
            uWarehouse[7] = new Smartworks.ColumnField("@IsStore", IsStore);
            uWarehouse[8] = new Smartworks.ColumnField("@UpdatedBy", UpdatedBy);
            uWarehouse[9] = new Smartworks.ColumnField("@UpdatedOn", UpdatedOn);
            uWarehouse[10] = new Smartworks.ColumnField("@UpdatedIpAddr", UpdatedIpAddr);

            dataAccess.BeginTransaction();
            dataAccess.ExecuteStoredProcedure("dbo.UpdateWarehouse", uWarehouse);
            dataAccess.TransCommit();
        }

        public int DeleteWarehouse(int WarehouseId)
        {
            int id = -1;

            Smartworks.ColumnField[] dProductSize = new Smartworks.ColumnField[1];
            dProductSize[0] = new Smartworks.ColumnField("@WarehouseId", WarehouseId);

            dataAccess.BeginTransaction();
            id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.DeleteWarehouse", dProductSize));

            dataAccess.TransCommit();

            return id;
        }

        public DataTable GetAllWarehouse()
        {
            return dataAccess.getDataTable("select * from  Warehouse");
        }

        public int GetWarehouseStoreId()
        {
            int Id = -1;
            try
            {
                DataTable dt = new DataTable();
                dt = dataAccess.getDataTable("Select WarehouseId from Warehouse  where IsStore = 1");
                if (dt.Rows.Count > 0)
                {
                    Id = Convert.ToInt32(dt.Rows[0]["WarehouseId"]);
                }
            }
            catch (Exception ex)
            {
            }
            return Id;
        }

        public DataTable GetAllBatchBySONoAndProductId(string SOrderNo, int ProductId)
        {
            return dataAccess.getDataTable("Select Distinct BatchNo from WTMaster WTM where WTM.SOrderNo = '" + SOrderNo + "' and  ProductId = '" + ProductId + "' and BatchNo is not NULL");

        }




        public DataTable GetWarehouse(int WarehouseId)
        {
            DataTable dt;
            dt = dataAccess.getDataTable("Select * from Warehouse where WarehouseId  =" + WarehouseId);
            return dt;
        }

        public int GetWarehouseIdIdByCode(int WarehouseId)
        {
            int GetProductSizeId = -1;
            DataTable dt = new DataTable();
            dt = dataAccess.getDataTable("Select WarehouseId from Warehouse where WarehouseId  = '" + WarehouseId + "' ");
            if (dt.Rows.Count > 0)
            {
                GetProductSizeId = (int)dt.Rows[0]["WarehouseId"];
            }
            return GetProductSizeId;
        }

        public DataTable GetWarehouseList()
        {
            DataTable dt = new DataTable();
            dt = dataAccess.getDataTable("Select WarehouseId , upper(left(Name, 1)) + right(Name, len(Name) - 1) as Warehouse  from Warehouse Order by Name");
            return dt;

        }

        public DataTable GetWarehouseListSequance()
        {
            DataTable dt = new DataTable();
            dt = dataAccess.getDataTable("Select WarehouseId , upper(left(Name, 1)) + right(Name, len(Name) - 1) as Warehouse  from Warehouse Order by Sequance");
            return dt;

        }

        #endregion


        #region WarehouseTransfer

        public DataSet GetWarehouseTrasnferStructure(int warehouseId)
        {
            DataSet ds = new DataSet();
            Smartworks.ColumnField[] gWarehouseStructure = new Smartworks.ColumnField[1];
            gWarehouseStructure[0] = new Smartworks.ColumnField("@WTMasterId", warehouseId);
            ds = dataAccess.getDataSetByStoredProcedure("sp_GetWarehouseTransferStructure", gWarehouseStructure);
            return ds;
        }


        public DataTable InsertWTMaster(int RequestedBy, int WarehouseFrom, int WarehouseTo, DateTime TransferDate, string SOrderNo, int ProductId, string Narration, bool Hold, bool Posted, string BranchCode,
            int AddedBy, DateTime AddedOn, string AddedIpAddr, bool IsStartProcessing, decimal ProcessQty, string BatchNo, Smartworks.DAL customdataAcess = null)
        {
            DataTable dt = new DataTable();
            Smartworks.ColumnField[] iWTMaster = new Smartworks.ColumnField[16];
            iWTMaster[0] = new Smartworks.ColumnField("@RequestedBy", RequestedBy);
            iWTMaster[1] = new Smartworks.ColumnField("@WarehouseFrom", WarehouseFrom);
            iWTMaster[2] = new Smartworks.ColumnField("@WarehouseTo", WarehouseTo);
            iWTMaster[3] = new Smartworks.ColumnField("@TransferDate", TransferDate);
            iWTMaster[4] = new Smartworks.ColumnField("@SOrderNo", SOrderNo);
            iWTMaster[5] = new Smartworks.ColumnField("@ProductId", ProductId);
            iWTMaster[6] = new Smartworks.ColumnField("@Narration", Narration);
            iWTMaster[7] = new Smartworks.ColumnField("@Hold", Hold);
            iWTMaster[8] = new Smartworks.ColumnField("@Posted", Posted);
            iWTMaster[9] = new Smartworks.ColumnField("@BranchCode", BranchCode);
            iWTMaster[10] = new Smartworks.ColumnField("@AddedBy", AddedBy);
            iWTMaster[11] = new Smartworks.ColumnField("@AddedOn", AddedOn);
            iWTMaster[12] = new Smartworks.ColumnField("@AddedIpAddr", AddedIpAddr);
            iWTMaster[13] = new Smartworks.ColumnField("@IsStartProcessing", IsStartProcessing);
            iWTMaster[14] = new Smartworks.ColumnField("@ProcessQty", ProcessQty);
            iWTMaster[15] = new Smartworks.ColumnField("@BatchNo", BatchNo);

            if (customdataAcess != null)
            {
                dt = customdataAcess.getDataTableByStoredProcedure("dbo.InsertWTMaster", iWTMaster);
            }
            else
            {
                dataAccess.BeginTransaction();
                dt = customdataAcess.getDataTableByStoredProcedure("dbo.InsertWTMaster", iWTMaster);
                dataAccess.TransCommit();
            }
            return dt;
        }

        public int UpdateWTMaster(int WTMasterID, int RequestedBy, int WarehouseFrom, int WarehouseTo, DateTime TransferDate, string SOrderNo, int ProductId, string Narration, bool Hold, bool Posted, string BranchCode,
          int AddedBy, DateTime AddedOn, string AddedIpAddr, bool IsStartProcessing, decimal ProcessQty, string BatchNo, Smartworks.DAL customdataAcess = null)
        {
            int Id = -1;
            Smartworks.ColumnField[] uWTMaster = new Smartworks.ColumnField[17];
            uWTMaster[0] = new Smartworks.ColumnField("@WTMasterID", WTMasterID);
            uWTMaster[1] = new Smartworks.ColumnField("@RequestedBy", RequestedBy);
            uWTMaster[2] = new Smartworks.ColumnField("@WarehouseFrom", WarehouseFrom);
            uWTMaster[3] = new Smartworks.ColumnField("@WarehouseTo", WarehouseTo);
            uWTMaster[4] = new Smartworks.ColumnField("@TransferDate", TransferDate);
            uWTMaster[5] = new Smartworks.ColumnField("@SOrderNo", SOrderNo);
            uWTMaster[6] = new Smartworks.ColumnField("@ProductId", ProductId);
            uWTMaster[7] = new Smartworks.ColumnField("@Narration", Narration);
            uWTMaster[8] = new Smartworks.ColumnField("@Hold", Hold);
            uWTMaster[9] = new Smartworks.ColumnField("@Posted", Posted);
            uWTMaster[10] = new Smartworks.ColumnField("@BranchCode", BranchCode);
            uWTMaster[11] = new Smartworks.ColumnField("@UpdatedBy", AddedBy);
            uWTMaster[12] = new Smartworks.ColumnField("@UpdatedOn", AddedOn);
            uWTMaster[13] = new Smartworks.ColumnField("@UpdatedIpAddr", AddedIpAddr);
            uWTMaster[14] = new Smartworks.ColumnField("@IsStartProcessing", IsStartProcessing);
            uWTMaster[15] = new Smartworks.ColumnField("@ProcessQty", ProcessQty);
            uWTMaster[16] = new Smartworks.ColumnField("@BatchNo", BatchNo);


            if (customdataAcess != null)
            {
                Id = Convert.ToInt32(customdataAcess.ExecuteStoredProcedure("dbo.UpdateWTMaster", uWTMaster));
            }
            else
            {
                dataAccess.BeginTransaction();
                Id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.UpdateWTMaster", uWTMaster));
                dataAccess.TransCommit();
            }
            return Id;
        }

        public int InsertUpdateWTDetail(int WTDetailID, int WTMasterId, int ProductId, string Barcode, string StockType, string BatchNo,
            string TransferStockType, decimal QtyToTransfer, int AddedBy, DateTime AddedOn, string AddedIpAddr, Smartworks.DAL customdataAcess)
        {
            int Id = -1;
            Smartworks.ColumnField[] iuWTDetail = new Smartworks.ColumnField[11];
            iuWTDetail[0] = new Smartworks.ColumnField("@WTDetailID", WTDetailID);
            iuWTDetail[1] = new Smartworks.ColumnField("@WTMasterId", WTMasterId);
            iuWTDetail[2] = new Smartworks.ColumnField("@ProductId", ProductId);
            iuWTDetail[3] = new Smartworks.ColumnField("@Barcode", Barcode);
            iuWTDetail[4] = new Smartworks.ColumnField("@StockType", StockType);
            iuWTDetail[5] = new Smartworks.ColumnField("@BatchNo", BatchNo);
            iuWTDetail[6] = new Smartworks.ColumnField("@TransferStockType", TransferStockType);
            iuWTDetail[7] = new Smartworks.ColumnField("@QtyToTransfer", QtyToTransfer);
            iuWTDetail[8] = new Smartworks.ColumnField("@AddedBy", AddedBy);
            iuWTDetail[9] = new Smartworks.ColumnField("@AddedOn", AddedOn);
            iuWTDetail[10] = new Smartworks.ColumnField("@AddedIpAddr", AddedIpAddr);

            if (customdataAcess != null)
            {
                Id = Convert.ToInt32(customdataAcess.ExecuteStoredProcedure("dbo.sp_InsertUpdateWTDtail", iuWTDetail));
            }
            else
            {
                dataAccess.BeginTransaction();
                Id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.sp_InsertUpdateWTDtail", iuWTDetail));
                dataAccess.TransCommit();
            }
            return Id;
        }

        public void DeleteWTDetailByDetailId(int WTDetailId, Smartworks.DAL customdataAcess = null)
        {
            Smartworks.ColumnField[] dWTDetail = new Smartworks.ColumnField[1];
            dWTDetail[0] = new Smartworks.ColumnField("@WTDetailID", WTDetailId);
            if (customdataAcess != null)
            {
                customdataAcess.ExecuteStoredProcedure("dbo.DeleteWTDetailByDetailId", dWTDetail);
            }
            else
            {
                dataAccess.BeginTransaction();
                dataAccess.ExecuteStoredProcedure("dbo.DeleteWTDetailByDetailId", dWTDetail);
                dataAccess.TransCommit();
            }
        }

        public int DeleteWTMaster(int WTMasterId, Smartworks.DAL customdataAcess = null)
        {
            int Id = -1;
            Smartworks.ColumnField[] dWTMaster = new Smartworks.ColumnField[1];
            dWTMaster[0] = new Smartworks.ColumnField("@WTMasterId", WTMasterId);
            if (customdataAcess != null)
            {
                Id = Convert.ToInt32(customdataAcess.ExecuteStoredProcedure("dbo.DeleteWTMaster", dWTMaster));
            }
            else
            {
                dataAccess.BeginTransaction();
                Id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.DeleteWTMaster", dWTMaster));
                dataAccess.TransCommit();
            }
            return Id;
        }

        public int GetWTMasterIdByCode(string Code)
        {
            int WTMasterId = -1;
            DataTable dt = new DataTable();
            dt = dataAccess.getDataTable("Select WTMasterId from WTMaster where Code = '" + Code + "' ");
            if (dt.Rows.Count > 0)
            {
                WTMasterId = Convert.ToInt32(dt.Rows[0]["WTMasterId"].ToString());
            }
            return WTMasterId;
        }


        #region Navigation

        public string GetMinInvioceNo()
        {
            string InvoiceNo = "";
            DataTable dt = new DataTable();

            dt = dataAccess.getDataTable("select min(Code) as 'InvoiceNo' from WTMaster");
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

            dt = dataAccess.getDataTable("select max(Code) as 'InvoiceNo' from WTMaster");
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

        #endregion

        #region Reports

        public DataTable GetTransferSummaryReport(Nullable<DateTime> Date, int WarehouseId, string SOrderNo, int ProductId)
        {

            DataTable dt = new DataTable();
            Smartworks.ColumnField[] report = new Smartworks.ColumnField[4];
            if (Date == null)
            {
                report[0] = new Smartworks.ColumnField("@Date", DBNull.Value);
            }
            else
            {
                report[0] = new Smartworks.ColumnField("@Date", Date);
            }
            report[1] = new Smartworks.ColumnField("@FromWarehouse", WarehouseId);
            report[2] = new Smartworks.ColumnField("@SOrderNo", SOrderNo);
            report[3] = new Smartworks.ColumnField("@ProductId", ProductId);
            dt = dataAccess.getDataTableByStoredProcedure("sp_ReportWarehouseTransferSummary", report);
            return dt;
        }

        public DataTable GetTransferSummaryReportForArticle(Nullable<DateTime> Date, int WarehouseId, string SOrderNo, int ProductId)
        {

            DataTable dt = new DataTable();
            Smartworks.ColumnField[] report = new Smartworks.ColumnField[4];
            if (Date == null)
            {
                report[0] = new Smartworks.ColumnField("@Date", DBNull.Value);
            }
            else
            {
                report[0] = new Smartworks.ColumnField("@Date", Date);
            }
            report[1] = new Smartworks.ColumnField("@FromWarehouse", WarehouseId);
            report[2] = new Smartworks.ColumnField("@SOrderNo", SOrderNo);
            report[3] = new Smartworks.ColumnField("@ProductId", ProductId);
            dt = dataAccess.getDataTableByStoredProcedure("sp_ReportWarehouseTransferSummaryForArticle", report);
            return dt;
        }

        #endregion
    }
}
