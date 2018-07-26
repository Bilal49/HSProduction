using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;

namespace FIL.App_Code.PurchaseManager
{
    public class PurchaseOrderManager
    {
        Smartworks.DAL dataAccess = new Smartworks.DAL();
        public PurchaseOrderManager()
        {

            string connString = ConfigurationManager.ConnectionStrings["HSConnectionString"].ConnectionString;
            Smartworks.DAL.ConnectionString = connString;
        }

        #region Purchase Order
        

        public DataSet GetPurchaseOrderStructure(int POrderId)
        {
            DataSet ds = new DataSet();
            Smartworks.ColumnField[] getPO = new Smartworks.ColumnField[1];
            getPO[0] = new Smartworks.ColumnField("@POrderId", POrderId);
            ds = dataAccess.getDataSetByStoredProcedure("sp_GetPurchaseOrderStructure", getPO);
            return ds;
        }

        public int InsertPOMaster(DateTime OrderDate, DateTime DueDate, string BranchCode, string VendorCode, string VendorRef, string EmployeeCode, int CompanyId, int CurrencyId,
            decimal Rate, decimal TAmount, decimal TDiscountPerc, decimal TDiscount, bool Closed, string Remarks, string VoucherNo, int AddedBy, DateTime AddedOn, string AddedIpAddr, Smartworks.DAL customdataAcess = null)
        {
            int Id = -1;

            Smartworks.ColumnField[] iPurchaseOrder = new Smartworks.ColumnField[18];
            iPurchaseOrder[0] = new Smartworks.ColumnField("@OrderDate", OrderDate);
            iPurchaseOrder[1] = new Smartworks.ColumnField("@DueDate", DueDate);
            iPurchaseOrder[2] = new Smartworks.ColumnField("@BranchCode", BranchCode);
            iPurchaseOrder[3] = new Smartworks.ColumnField("@VendorCode", VendorCode);
            iPurchaseOrder[4] = new Smartworks.ColumnField("@VendorRef", VendorRef);
            iPurchaseOrder[5] = new Smartworks.ColumnField("@EmployeeCode", EmployeeCode);
            iPurchaseOrder[6] = new Smartworks.ColumnField("@CompanyId", CompanyId);
            iPurchaseOrder[7] = new Smartworks.ColumnField("@CurrencyId", CurrencyId);
            iPurchaseOrder[8] = new Smartworks.ColumnField("@Rate", Rate);
            iPurchaseOrder[9] = new Smartworks.ColumnField("@TAmount", TAmount);
            iPurchaseOrder[10] = new Smartworks.ColumnField("@TDiscountPerc", TDiscountPerc);
            iPurchaseOrder[11] = new Smartworks.ColumnField("@TDiscount", TDiscount);
            iPurchaseOrder[12] = new Smartworks.ColumnField("@Closed", Closed);
            iPurchaseOrder[13] = new Smartworks.ColumnField("@Remarks", Remarks);
            iPurchaseOrder[14] = new Smartworks.ColumnField("@VoucherNo", VoucherNo);
            iPurchaseOrder[15] = new Smartworks.ColumnField("@AddedBy", AddedBy);
            iPurchaseOrder[16] = new Smartworks.ColumnField("@AddedOn", AddedOn);
            iPurchaseOrder[17] = new Smartworks.ColumnField("@AddedIpAddr", AddedIpAddr);

            if (customdataAcess != null)
            {
                Id = Convert.ToInt32(customdataAcess.ExecuteStoredProcedure("dbo.InsertPOMaster", iPurchaseOrder));
            }
            else
            {
                dataAccess.BeginTransaction();
                Id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.InsertPOMaster", iPurchaseOrder));
                dataAccess.TransCommit();
            }

            return Id;
        }

        public void UpdatePOMaster(int POrderId, DateTime OrderDate, DateTime DueDate, string BranchCode, string VendorCode, string VendorRef, string EmployeeCode, int CompanyId, int CurrencyId,
           decimal Rate, decimal TAmount, decimal TDiscountPerc, decimal TDiscount, bool Closed, string Remarks, string VoucherNo, int UpdatedBy, DateTime UpdatedOn, string UpdatedIpAddr, Smartworks.DAL customdataAcess = null)
        {
            int Id = -1;

            Smartworks.ColumnField[] uPurchaseOrder = new Smartworks.ColumnField[19];
            uPurchaseOrder[0] = new Smartworks.ColumnField("@POrderId", POrderId);
            uPurchaseOrder[1] = new Smartworks.ColumnField("@OrderDate", OrderDate);
            uPurchaseOrder[2] = new Smartworks.ColumnField("@DueDate", DueDate);
            uPurchaseOrder[3] = new Smartworks.ColumnField("@BranchCode", BranchCode);
            uPurchaseOrder[4] = new Smartworks.ColumnField("@VendorCode", VendorCode);
            uPurchaseOrder[5] = new Smartworks.ColumnField("@VendorRef", VendorRef);
            uPurchaseOrder[6] = new Smartworks.ColumnField("@EmployeeCode", EmployeeCode);
            uPurchaseOrder[7] = new Smartworks.ColumnField("@CompanyId", CompanyId);
            uPurchaseOrder[8] = new Smartworks.ColumnField("@CurrencyId", CurrencyId);
            uPurchaseOrder[9] = new Smartworks.ColumnField("@Rate", Rate);
            uPurchaseOrder[10] = new Smartworks.ColumnField("@TAmount", TAmount);
            uPurchaseOrder[11] = new Smartworks.ColumnField("@TDiscountPerc", TDiscountPerc);
            uPurchaseOrder[12] = new Smartworks.ColumnField("@TDiscount", TDiscount);
            uPurchaseOrder[13] = new Smartworks.ColumnField("@Closed", Closed);
            uPurchaseOrder[14] = new Smartworks.ColumnField("@Remarks", Remarks);
            uPurchaseOrder[15] = new Smartworks.ColumnField("@VoucherNo", VoucherNo);
            uPurchaseOrder[16] = new Smartworks.ColumnField("@UpdatedBy", UpdatedBy);
            uPurchaseOrder[17] = new Smartworks.ColumnField("@UpdatedOn", UpdatedOn);
            uPurchaseOrder[18] = new Smartworks.ColumnField("@UpdatedIpAddr", UpdatedIpAddr);

            if (customdataAcess != null)
            {
                customdataAcess.ExecuteStoredProcedure("dbo.UpdatePOMaster", uPurchaseOrder);
            }
            else
            {
                dataAccess.BeginTransaction();
                dataAccess.ExecuteStoredProcedure("dbo.UpdatePOMaster", uPurchaseOrder);
                dataAccess.TransCommit();
            }
        }

        public int InsertUpdatePODetail(int POrderDetailId, int POrderId, int ProductId, int ColorId ,  string StockType, int WarehouseId,
 decimal OrderQty, decimal Price, decimal DiscountPercent, decimal DiscountAmount, decimal GSTPercent,
decimal GSTAmount, int AddedBy, DateTime AddedOn, string AddedIpAddr, Smartworks.DAL customdataAcess)
        {
            int Id = -1;
            Smartworks.ColumnField[] iuPurchaseOrderDetail = new Smartworks.ColumnField[15];
            iuPurchaseOrderDetail[0] = new Smartworks.ColumnField("@POrderDetailId", POrderDetailId);
            iuPurchaseOrderDetail[1] = new Smartworks.ColumnField("@POrderId", POrderId);
            iuPurchaseOrderDetail[2] = new Smartworks.ColumnField("@ProductId", ProductId);
            iuPurchaseOrderDetail[3] = new Smartworks.ColumnField("@ColorId", ColorId);
            iuPurchaseOrderDetail[4] = new Smartworks.ColumnField("@StockType", StockType);
            iuPurchaseOrderDetail[5] = new Smartworks.ColumnField("@WarehouseId", WarehouseId);
            iuPurchaseOrderDetail[6] = new Smartworks.ColumnField("@OrderQty", OrderQty);
            iuPurchaseOrderDetail[7] = new Smartworks.ColumnField("@Price", Price);
            iuPurchaseOrderDetail[8] = new Smartworks.ColumnField("@DiscountPercent", DiscountPercent);
            iuPurchaseOrderDetail[9] = new Smartworks.ColumnField("@DiscountAmount", DiscountAmount);
            iuPurchaseOrderDetail[10] = new Smartworks.ColumnField("@GSTPercent", GSTPercent);
            iuPurchaseOrderDetail[11] = new Smartworks.ColumnField("@GSTAmount", GSTAmount);
            iuPurchaseOrderDetail[12] = new Smartworks.ColumnField("@AddedBy", AddedBy);
            iuPurchaseOrderDetail[13] = new Smartworks.ColumnField("@AddedOn", AddedOn);
            iuPurchaseOrderDetail[14] = new Smartworks.ColumnField("@AddedIpAddr", AddedIpAddr);
            if (customdataAcess != null)
            {
                Id = Convert.ToInt32(customdataAcess.ExecuteStoredProcedure("dbo.InsertUpdatePODetail", iuPurchaseOrderDetail));
            }
            else
            {
                dataAccess.BeginTransaction();
                Id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.InsertUpdatePODetail", iuPurchaseOrderDetail));
                dataAccess.TransCommit();
            }
            return Id;
        }


        public bool IsPurchaseOrderInUsed(string PONo)
        {
            bool result = false;
            DataTable dtRPO = new DataTable();
            dtRPO = dataAccess.getDataTable("Select * from RPOMaster with(nolock) where POrderNo = '" + PONo + "'");
            if (dtRPO.Rows.Count > 0)
            {
                result = true;
            }
            return result;
        }
        public int DeletePOrderMaster(int POrderMasterId, Smartworks.DAL customdataAcess = null)
        {
            int Id = -1;

            Smartworks.ColumnField[] dPOrder = new Smartworks.ColumnField[1];
            dPOrder[0] = new Smartworks.ColumnField("@POrderId", POrderMasterId);
            if (customdataAcess != null)
            {
                Id = Convert.ToInt32(customdataAcess.ExecuteStoredProcedure("dbo.DeletePOrderMaster", dPOrder));
            }
            else
            {
                dataAccess.BeginTransaction();
                Id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.DeletePOrderMaster", dPOrder));
                dataAccess.TransCommit();
            }
            return Id;
        }

        public void DeletePOrderDetailByDetailId(int POrderDetailId, Smartworks.DAL customdataAcess = null)
        {
            Smartworks.ColumnField[] dPOrderDetail = new Smartworks.ColumnField[1];
            dPOrderDetail[0] = new Smartworks.ColumnField("@POrderDetailId", POrderDetailId);
            if (customdataAcess != null)
            {
                customdataAcess.ExecuteStoredProcedure("dbo.DeletePODetailByDetailId", dPOrderDetail);
            }
            else
            {
                dataAccess.BeginTransaction();
                dataAccess.ExecuteStoredProcedure("dbo.DeletePODetailByDetailId", dPOrderDetail);
                dataAccess.TransCommit();
            }
        }


        //yeh wo Method hai jo over all hum normally sab jaga use kerty hain
        public int GetPurchaseOrderMasterIdByCode(string Code)
        {
            int POrderMasterId = -1;
            DataTable dt = new DataTable();
            dt = dataAccess.getDataTable("Select POrderId from POrderMaster where POrderNo = '" + Code + "'");
            if (dt.Rows.Count > 0)
            {
                POrderMasterId = Convert.ToInt32(dt.Rows[0]["POrderId"]);
            }
            return POrderMasterId;
        }

        //yeh wo method hai jo hum RPO form mai IsClose= 0 wale yani Pending PO jo ab RPO form mai show hongy.
         public int GetPendingPurchaseOrderMasterIdByCode(string Code )
        {
            int POrderMasterId = -1;
            DataTable dt = new DataTable();
            dt = dataAccess.getDataTable("Select POrderId from POrderMaster where POrderNo = '" + Code + "' and Closed = 0");
            if (dt.Rows.Count > 0)
            {
                POrderMasterId = Convert.ToInt32(dt.Rows[0]["POrderId"]);
            }
            return POrderMasterId;
        }

        

        public void UpdatePOrderMasterClosedMarked(int POrderMasterId, Smartworks.DAL customdataAcess = null)
        {
            if (customdataAcess != null)
            {
                customdataAcess.ExecuteNonQuery("Update POrderMaster set Closed  = 1 where POrderId =" + POrderMasterId);
            }
            else
            {
                dataAccess.ExecuteNonQuery("Update POrderMaster set Closed  = 1 where POrderId =" + POrderMasterId);
            }
        }



        #region Navigation

        public string GetMinInvioceNo()
        {
            string InvoiceNo = "";
            DataTable dt = new DataTable();

            dt = dataAccess.getDataTable("select min(POrderNo) as 'InvoiceNo' from POrderMaster");
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

            dt = dataAccess.getDataTable("select max(POrderNo) as 'InvoiceNo' from POrderMaster");
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


        #region Reporting


        public DataTable GetPurchaseOrderReport(Nullable<DateTime> FromDate, Nullable<DateTime> ToDate, string FromPONo, string ToPONo, string FromVendor , string ToVendor ,  int POrderId)
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
            rPOrder[2] = new Smartworks.ColumnField("@FromPONo", FromPONo);
            rPOrder[3] = new Smartworks.ColumnField("@ToPONo", ToPONo);

            rPOrder[4] = new Smartworks.ColumnField("@FromVendor", FromVendor);
            rPOrder[5] = new Smartworks.ColumnField("@ToVendor", ToVendor);

            rPOrder[6] = new Smartworks.ColumnField("@POrderId", POrderId);

            dtReport = dataAccess.getDataTableByStoredProcedure("dbo.sp_ReportPurchaseOrder", rPOrder);
            return dtReport;
        }
        #endregion

        #endregion

        #region Receiving PO

        public DataSet GetReceivingPOStructure(int RPOId)
        {
            DataSet ds = new DataSet();
            Smartworks.ColumnField[] getRPO = new Smartworks.ColumnField[1];
            getRPO[0] = new Smartworks.ColumnField("@RPOId", RPOId);
            ds = dataAccess.getDataSetByStoredProcedure("sp_GetRecivingPOStructure", getRPO);
            return ds;
        }

        public DataSet GetReceivingPOStructureByPOId(int POrderMasterId)
        {
            DataSet ds = new DataSet();
            Smartworks.ColumnField[] getPOrder = new Smartworks.ColumnField[1];
            getPOrder[0] = new Smartworks.ColumnField("@POrderMasterId", POrderMasterId);
            ds = dataAccess.getDataSetByStoredProcedure("sp_GetRecivingPOStructureByPOrderMasterId", getPOrder);
            return ds;
        }

        public int InsertRecivingPOMaster(string POrderNo , DateTime RPODate ,  DateTime OrderDate,  string BranchCode, string VendorCode, string VendorRef, string EmployeeCode, int CompanyId, int CurrencyId,
          decimal Rate, decimal TAmount, decimal TDiscountPerc, decimal TDiscount, decimal TDutyAmount , bool Closed, string Remarks, string VoucherNo, int AddedBy, DateTime AddedOn, string AddedIpAddr, Smartworks.DAL customdataAcess = null)
        {
            int Id = -1;

            Smartworks.ColumnField[] iRPO = new Smartworks.ColumnField[20];
            iRPO[0] = new Smartworks.ColumnField("@POrderNo", POrderNo);
            iRPO[1] = new Smartworks.ColumnField("@RPODate", RPODate);
            iRPO[2] = new Smartworks.ColumnField("@OrderDate", OrderDate);
            iRPO[3] = new Smartworks.ColumnField("@BranchCode", BranchCode);
            iRPO[4] = new Smartworks.ColumnField("@VendorCode", VendorCode);
            iRPO[5] = new Smartworks.ColumnField("@VendorRef", VendorRef);
            iRPO[6] = new Smartworks.ColumnField("@EmployeeCode", EmployeeCode);
            iRPO[7] = new Smartworks.ColumnField("@CompanyId", CompanyId);
            iRPO[8] = new Smartworks.ColumnField("@CurrencyId", CurrencyId);
            iRPO[9] = new Smartworks.ColumnField("@Rate", Rate);
            iRPO[10] = new Smartworks.ColumnField("@TAmount", TAmount);
            iRPO[11] = new Smartworks.ColumnField("@TDiscountPerc", TDiscountPerc);
            iRPO[12] = new Smartworks.ColumnField("@TDiscount", TDiscount);
            iRPO[13] = new Smartworks.ColumnField("@TDutyAmount", TDutyAmount);
            iRPO[14] = new Smartworks.ColumnField("@Closed", Closed);
            iRPO[15] = new Smartworks.ColumnField("@Remarks", Remarks);
            iRPO[16] = new Smartworks.ColumnField("@VoucherNo", VoucherNo);
            iRPO[17] = new Smartworks.ColumnField("@AddedBy", AddedBy);
            iRPO[18] = new Smartworks.ColumnField("@AddedOn", AddedOn);
            iRPO[19] = new Smartworks.ColumnField("@AddedIpAddr", AddedIpAddr);

            if (customdataAcess != null)
            {
                Id = Convert.ToInt32(customdataAcess.ExecuteStoredProcedure("dbo.InsertRecivingPOMaster", iRPO));
            }
            else
            {
                dataAccess.BeginTransaction();
                Id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.InsertRecivingPOMaster", iRPO));
                dataAccess.TransCommit();
            }

            return Id;
        }


        public void UpdateRecivingPOMaster(int RPOId, string POrderNo, DateTime RPODate, DateTime OrderDate, string BranchCode, string VendorCode, string VendorRef, string EmployeeCode, int CompanyId, int CurrencyId,
       decimal Rate, decimal TAmount, decimal TDiscountPerc, decimal TDiscount, decimal TDutyAmount ,  bool Closed, string Remarks, string VoucherNo, int UpdatedBy, DateTime UpdatedOn, string UpdatedIpAddr, Smartworks.DAL customdataAcess = null)
        {
            int Id = -1;

            Smartworks.ColumnField[] uRPO = new Smartworks.ColumnField[21];
            uRPO[0] = new Smartworks.ColumnField("@RPOId", RPOId);
            uRPO[1] = new Smartworks.ColumnField("@POrderNo", POrderNo);
            uRPO[2] = new Smartworks.ColumnField("@RPODate", RPODate);
            uRPO[3] = new Smartworks.ColumnField("@OrderDate", OrderDate);
            uRPO[4] = new Smartworks.ColumnField("@BranchCode", BranchCode);
            uRPO[5] = new Smartworks.ColumnField("@VendorCode", VendorCode);
            uRPO[6] = new Smartworks.ColumnField("@VendorRef", VendorRef);
            uRPO[7] = new Smartworks.ColumnField("@EmployeeCode", EmployeeCode);
            uRPO[8] = new Smartworks.ColumnField("@CompanyId", CompanyId);
            uRPO[9] = new Smartworks.ColumnField("@CurrencyId", CurrencyId);
            uRPO[10] = new Smartworks.ColumnField("@Rate", Rate);
            uRPO[11] = new Smartworks.ColumnField("@TAmount", TAmount);
            uRPO[12] = new Smartworks.ColumnField("@TDiscountPerc", TDiscountPerc);
            uRPO[13] = new Smartworks.ColumnField("@TDiscount", TDiscount);
            uRPO[14] = new Smartworks.ColumnField("@TDutyAmount", TDutyAmount);
            uRPO[15] = new Smartworks.ColumnField("@Closed", Closed);
            uRPO[16] = new Smartworks.ColumnField("@Remarks", Remarks);
            uRPO[17] = new Smartworks.ColumnField("@VoucherNo", VoucherNo);
            uRPO[18] = new Smartworks.ColumnField("@UpdatedBy", UpdatedBy);
            uRPO[19] = new Smartworks.ColumnField("@UpdatedOn", UpdatedOn);
            uRPO[20] = new Smartworks.ColumnField("@UpdatedIpAddr", UpdatedIpAddr);

            if (customdataAcess != null)
            {
                customdataAcess.ExecuteStoredProcedure("dbo.UpdateRecivingPOMaster", uRPO);
            }
            else
            {
                dataAccess.BeginTransaction();
                dataAccess.ExecuteStoredProcedure("dbo.UpdateRecivingPOMaster", uRPO);
                dataAccess.TransCommit();
            }
        }

        public int InsertUpdateRecivingPODetail(int RPODetailId , int RPOId ,  int POrderDetailId, int ProductId, string StockType, int WarehouseId,
decimal OrderQty, decimal TotalReceived , decimal ReceivedQty , decimal Price, decimal DiscountPercent, decimal DiscountAmount, decimal GSTPercent,
decimal GSTAmount, int AddedBy, DateTime AddedOn, string AddedIpAddr, Smartworks.DAL customdataAcess)
        {
            int Id = -1;
            Smartworks.ColumnField[] iuRecivingPODetail = new Smartworks.ColumnField[17];
            iuRecivingPODetail[0] = new Smartworks.ColumnField("@RPODetailId", RPODetailId);
            iuRecivingPODetail[1] = new Smartworks.ColumnField("@RPOId", RPOId);
            iuRecivingPODetail[2] = new Smartworks.ColumnField("@POrderDetailId", POrderDetailId);
            iuRecivingPODetail[3] = new Smartworks.ColumnField("@ProductId", ProductId);
            iuRecivingPODetail[4] = new Smartworks.ColumnField("@StockType", StockType);
            iuRecivingPODetail[5] = new Smartworks.ColumnField("@WarehouseId", WarehouseId);
            iuRecivingPODetail[6] = new Smartworks.ColumnField("@OrderQty", OrderQty);
            iuRecivingPODetail[7] = new Smartworks.ColumnField("@TotalReceived", TotalReceived);
            iuRecivingPODetail[8] = new Smartworks.ColumnField("@ReceivedQty", ReceivedQty);
            iuRecivingPODetail[9] = new Smartworks.ColumnField("@Price", Price);
            iuRecivingPODetail[10] = new Smartworks.ColumnField("@DiscountPercent", DiscountPercent);
            iuRecivingPODetail[11] = new Smartworks.ColumnField("@DiscountAmount", DiscountAmount);
            iuRecivingPODetail[12] = new Smartworks.ColumnField("@GSTPercent", GSTPercent);
            iuRecivingPODetail[13] = new Smartworks.ColumnField("@GSTAmount", GSTAmount);
            iuRecivingPODetail[14] = new Smartworks.ColumnField("@AddedBy", AddedBy);
            iuRecivingPODetail[15] = new Smartworks.ColumnField("@AddedOn", AddedOn);
            iuRecivingPODetail[16] = new Smartworks.ColumnField("@AddedIpAddr", AddedIpAddr);
            if (customdataAcess != null)
            {
                Id = Convert.ToInt32(customdataAcess.ExecuteStoredProcedure("dbo.InsertUpdateRecivingPODetail", iuRecivingPODetail));
            }
            else
            {
                dataAccess.BeginTransaction();
                Id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.InsertUpdateRecivingPODetail", iuRecivingPODetail));
                dataAccess.TransCommit();
            }
            return Id;
        }

        public int DeleteRecivingPOMaster(int RPOId, Smartworks.DAL customdataAcess = null)
        {
            int Id = -1;
            Smartworks.ColumnField[] dRPO = new Smartworks.ColumnField[1];
            dRPO[0] = new Smartworks.ColumnField("@RPOId", @RPOId);
            if (customdataAcess != null)
            {
                Id = Convert.ToInt32(customdataAcess.ExecuteStoredProcedure("dbo.DeleteRecivingPOMaster", dRPO));
            }
            else
            {
                dataAccess.BeginTransaction();
                Id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.DeleteRecivingPOMaster", dRPO));
                dataAccess.TransCommit();
            }
            return Id;
        }

        public void DeleteRecivingPODetailByDetailId(int RPODetailId, Smartworks.DAL customdataAcess = null)
        {
            Smartworks.ColumnField[] dRPOrderDetail = new Smartworks.ColumnField[1];
            dRPOrderDetail[0] = new Smartworks.ColumnField("@RPODetailId", RPODetailId);
            if (customdataAcess != null)
            {
                customdataAcess.ExecuteStoredProcedure("dbo.DeleteRecivingPODetailByDetailId", dRPOrderDetail);
            }
            else
            {
                dataAccess.BeginTransaction();
                dataAccess.ExecuteStoredProcedure("dbo.DeleteRecivingPODetailByDetailId", dRPOrderDetail);
                dataAccess.TransCommit();
            }
        }

        public int GetRecivingPOIdByCode(string Code)
        {
            int POrderMasterId = -1;
            DataTable dt = new DataTable();
            dt = dataAccess.getDataTable("Select RPOId from RPOMaster where RPONo = '" + Code + "'");
            if (dt.Rows.Count > 0)
            {
                POrderMasterId = Convert.ToInt32(dt.Rows[0]["RPOId"]);
            }
            return POrderMasterId;
        }

        public int GetPendingRecivingPOIdByCode(string Code)
        {
            int POrderMasterId = -1;
            DataTable dt = new DataTable();
            dt = dataAccess.getDataTable("Select RPOId from RPOMaster where RPONo = '" + Code + "' and Closed= 0");
            if (dt.Rows.Count > 0)
            {
                POrderMasterId = Convert.ToInt32(dt.Rows[0]["RPOId"]);
            }
            return POrderMasterId;
        }

        #region Reporting


        public DataTable GetReceivingPurchaseOrderReport(Nullable<DateTime> FromDate, Nullable<DateTime> ToDate, string FromRPONo, string ToRPONo, string FromVendor, string ToVendor, int RPOId)
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
            rPOrder[2] = new Smartworks.ColumnField("@FromRPONo", FromRPONo);
            rPOrder[3] = new Smartworks.ColumnField("@ToRPONo", ToRPONo);

            rPOrder[4] = new Smartworks.ColumnField("@FromVendor", FromVendor);
            rPOrder[5] = new Smartworks.ColumnField("@ToVendor", ToVendor);

            rPOrder[6] = new Smartworks.ColumnField("@RPOId", RPOId);

            dtReport = dataAccess.getDataTableByStoredProcedure("dbo.sp_ReportRecevingPurchaseOrder", rPOrder);
            return dtReport;
        }

        public DataTable GetReceivingPOSummaryReport(Nullable<DateTime> FromDate, Nullable<DateTime> ToDate, string FromRPONo, string ToRPONo, string FromVendor, bool IsDetailReport )
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
            rPOrder[2] = new Smartworks.ColumnField("@FromRPONo", FromRPONo);
            rPOrder[3] = new Smartworks.ColumnField("@ToRPONo", ToRPONo);
            rPOrder[4] = new Smartworks.ColumnField("@VendorCode", FromVendor);
            rPOrder[5] = new Smartworks.ColumnField("@IsDetailWise", IsDetailReport);
            dtReport = dataAccess.getDataTableByStoredProcedure("dbo.sp_ReportReceivingPOSummary", rPOrder);

            return dtReport;
        }


        #endregion

        #region Navigation

        public string GetMinRPONo()
        {
            string InvoiceNo = "";
            DataTable dt = new DataTable();

            dt = dataAccess.getDataTable("select min(RPONo) as 'InvoiceNo' from RPOMaster");
            if (dt.Rows.Count > 0)
            {
                InvoiceNo = dt.Rows[0]["InvoiceNo"].ToString();
            }
            return InvoiceNo;
        }

        public string GetMaxRPONo()
        {
            string InvoiceNo = "";
            DataTable dt = new DataTable();

            dt = dataAccess.getDataTable("select max(RPONo) as 'InvoiceNo' from RPOMaster");
            if (dt.Rows.Count > 0)
            {
                InvoiceNo = dt.Rows[0]["InvoiceNo"].ToString();
            }
            return InvoiceNo;
        }


        public string GetNextRPONo(string Code)
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

        public string GetPrevRPNo(string Code)
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


       
        public bool IsRPOPurchaseInvoiceCreated(string RPONo)
        {
            bool result = false;
            if (dataAccess.getDataTable("Select * from PurchaseMaster where RPONo = '" + RPONo + "'").Rows.Count > 0)
            {
                result = true;
            }
            return result;
        }

        public void setRPOIsClosed(string RPONumber  ,  Smartworks.DAL customdataAcess)
        {
            customdataAcess.ExecuteNonQuery("Update RPOMaster set Closed = 1 where RPONo = '" + RPONumber + "'");
        }
    }
}
