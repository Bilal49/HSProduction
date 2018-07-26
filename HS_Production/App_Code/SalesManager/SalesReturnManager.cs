using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;

namespace FIL.App_Code.SalesManager
{
    public class SalesReturnManager
    {
        Smartworks.DAL dataAccess = new Smartworks.DAL();
        public SalesReturnManager()
        {
            string connString = ConfigurationManager.ConnectionStrings["HSConnectionString"].ConnectionString;
            Smartworks.DAL.ConnectionString = connString;
        }


        public DataSet GetSalesReturnStructure(int SalesReturnId)
        {
            DataSet ds = new DataSet();
            Smartworks.ColumnField[] getSales = new Smartworks.ColumnField[1];
            getSales[0] = new Smartworks.ColumnField("@SalesReturnId", SalesReturnId);
            ds = dataAccess.getDataSetByStoredProcedure("sp_GetSalesReturnStructure", getSales);
            return ds;
        }

        public DataSet GetSalesReturnStructureBySalesInvoiceId(int SalesMasterId)
        {
            DataSet ds = new DataSet();
            Smartworks.ColumnField[] getSales = new Smartworks.ColumnField[1];
            getSales[0] = new Smartworks.ColumnField("@SalesMasterId", SalesMasterId);
            ds = dataAccess.getDataSetByStoredProcedure("sp_GetSalesReturnStructureBySalesInvoiceId", getSales);
            return ds;
        }

        public DataTable InsertSalesReturnMaster(string SalesInvoiceNo, DateTime Date, string BranchCode, int WarehouseId, string CustomerCode, string ReturnedBy, string ReceivedBy,
            decimal TAmount, decimal TDiscountPerc, decimal TDiscount, decimal FreightCharges, decimal GSTPercent , decimal GSTAmount ,string Remarks, string VoucherNo, bool Posted, int AddedBy, DateTime AddedOn, string AddedIpAddr, 
            Smartworks.DAL customdataAcess)
        {
            DataTable dt = new DataTable();
            Smartworks.ColumnField[] iSalesReturn = new Smartworks.ColumnField[19];
            iSalesReturn[0] = new Smartworks.ColumnField("@SalesInvoiceNo", SalesInvoiceNo);
            iSalesReturn[1] = new Smartworks.ColumnField("@Date", Date);
            iSalesReturn[2] = new Smartworks.ColumnField("@BranchCode", BranchCode);
            iSalesReturn[3] = new Smartworks.ColumnField("@WarehouseId", WarehouseId);
            iSalesReturn[4] = new Smartworks.ColumnField("@CustomerCode", CustomerCode);
            iSalesReturn[5] = new Smartworks.ColumnField("@ReturnedBy", ReturnedBy);
            iSalesReturn[6] = new Smartworks.ColumnField("@ReceivedBy", ReceivedBy);
            iSalesReturn[7] = new Smartworks.ColumnField("@TAmount", TAmount);
            iSalesReturn[8] = new Smartworks.ColumnField("@TDiscountPerc", TDiscountPerc);
            iSalesReturn[9] = new Smartworks.ColumnField("@TDiscount", TDiscount);
            iSalesReturn[10] = new Smartworks.ColumnField("@FreightCharges", FreightCharges);
            iSalesReturn[11] = new Smartworks.ColumnField("@GSTPercent", GSTPercent);
            iSalesReturn[12] = new Smartworks.ColumnField("@GSTAmount", GSTAmount);
            iSalesReturn[13] = new Smartworks.ColumnField("@Remarks", Remarks);
            iSalesReturn[14] = new Smartworks.ColumnField("@VoucherNo", VoucherNo);
            iSalesReturn[15] = new Smartworks.ColumnField("@Posted", Posted);
            iSalesReturn[16] = new Smartworks.ColumnField("@AddedBy", AddedBy);
            iSalesReturn[17] = new Smartworks.ColumnField("@AddedOn", AddedOn);
            iSalesReturn[18] = new Smartworks.ColumnField("@AddedIpAddr", AddedIpAddr);

            if (customdataAcess != null)
            {
                dt = customdataAcess.getDataTableByStoredProcedure("InsertSalesReturnMaster", iSalesReturn);
            }
            else
            {
                dataAccess.BeginTransaction();
                dt = dataAccess.getDataTableByStoredProcedure("InsertSalesReturnMaster", iSalesReturn);
                dataAccess.TransCommit();
            }
            return dt;

        }


        public int UpdateSalesReturnMaster(int SalesReturnMasterId, string SalesInvoiceNo, DateTime Date, string BranchCode, int WarehouseId, string CustomerCode, string ReturnedBy, string ReceivedBy,
            decimal TAmount, decimal TDiscountPerc, decimal TDiscount, decimal FreightCharges, decimal GSTPercent , decimal GSTAmount , string Remarks, string VoucherNo, bool Posted, int UpdatedBy, DateTime UpdatedOn, string UpdatedIpAddr, Smartworks.DAL customdataAcess)
        {
            int Id = -1;
            Smartworks.ColumnField[] uSalesReturn = new Smartworks.ColumnField[20];
            uSalesReturn[0] = new Smartworks.ColumnField("@SalesReturnMasterId", SalesReturnMasterId);
            uSalesReturn[1] = new Smartworks.ColumnField("@SalesInvoiceNo", SalesInvoiceNo);
            uSalesReturn[2] = new Smartworks.ColumnField("@Date", Date);
            uSalesReturn[3] = new Smartworks.ColumnField("@BranchCode", BranchCode);
            uSalesReturn[4] = new Smartworks.ColumnField("@WarehouseId", WarehouseId);
            uSalesReturn[5] = new Smartworks.ColumnField("@CustomerCode", CustomerCode);
            uSalesReturn[6] = new Smartworks.ColumnField("@ReturnedBy", ReturnedBy);
            uSalesReturn[7] = new Smartworks.ColumnField("@ReceivedBy", ReceivedBy);
            uSalesReturn[8] = new Smartworks.ColumnField("@TAmount", TAmount);
            uSalesReturn[9] = new Smartworks.ColumnField("@TDiscountPerc", TDiscountPerc);
            uSalesReturn[10] = new Smartworks.ColumnField("@TDiscount", TDiscount);
            uSalesReturn[11] = new Smartworks.ColumnField("@FreightCharges", FreightCharges);
            uSalesReturn[12] = new Smartworks.ColumnField("@GSTPercent", GSTPercent);
            uSalesReturn[13] = new Smartworks.ColumnField("@GSTAmount", GSTAmount);
            uSalesReturn[14] = new Smartworks.ColumnField("@Remarks", Remarks);
            uSalesReturn[15] = new Smartworks.ColumnField("@VoucherNo", VoucherNo);
            uSalesReturn[16] = new Smartworks.ColumnField("@Posted", Posted);
            uSalesReturn[17] = new Smartworks.ColumnField("@UpdatedBy", UpdatedBy);
            uSalesReturn[18] = new Smartworks.ColumnField("@UpdatedOn", UpdatedOn);
            uSalesReturn[19] = new Smartworks.ColumnField("@UpdatedIpAddr", UpdatedIpAddr);

            if (customdataAcess != null)
            {
                Id = Convert.ToInt32(customdataAcess.ExecuteStoredProcedure("UpdateSalesReturnMaster", uSalesReturn));
            }
            else
            {
                dataAccess.BeginTransaction();
                Id = Convert.ToInt32(dataAccess.getDataTableByStoredProcedure("UpdateSalesReturnMaster", uSalesReturn));
                dataAccess.TransCommit();
            }

            return Id;
        }


        public int InsertUpdateSalesReturnDetail(int SalesReturnDetailId, int SalesReturnMasterId, int SalesDetailId ,  int ProductId, string StockType, string BatchNo, int WarehouseId, decimal Quantity,
           decimal Price, decimal DiscountPercent, decimal DiscountAmount, decimal GSTPercent, decimal GSTAmount, int AddedBy, DateTime AddedOn, string AddedIpAddr, string Grade , Smartworks.DAL customdataAcess = null)
        {
            int Id = -1;
            Smartworks.ColumnField[] iuSalesReturnDetail = new Smartworks.ColumnField[17];

            iuSalesReturnDetail[0] = new Smartworks.ColumnField("@SalesReturnDetailId", SalesReturnDetailId);
            iuSalesReturnDetail[1] = new Smartworks.ColumnField("@SalesReturnMasterId", SalesReturnMasterId);
            iuSalesReturnDetail[2] = new Smartworks.ColumnField("@SalesDetailId", SalesDetailId);
            iuSalesReturnDetail[3] = new Smartworks.ColumnField("@ProductId", ProductId);
            iuSalesReturnDetail[4] = new Smartworks.ColumnField("@StockType", StockType);
            iuSalesReturnDetail[5] = new Smartworks.ColumnField("@BatchNo", BatchNo);
            iuSalesReturnDetail[6] = new Smartworks.ColumnField("@WarehouseId", WarehouseId);
            iuSalesReturnDetail[7] = new Smartworks.ColumnField("@Quantity", Quantity);
            iuSalesReturnDetail[8] = new Smartworks.ColumnField("@Price", Price);
            iuSalesReturnDetail[9] = new Smartworks.ColumnField("@DiscountPercent", DiscountPercent);
            iuSalesReturnDetail[10] = new Smartworks.ColumnField("@DiscountAmount", DiscountAmount);
            iuSalesReturnDetail[11] = new Smartworks.ColumnField("@GSTPercent", GSTPercent);
            iuSalesReturnDetail[12] = new Smartworks.ColumnField("@GSTAmount", GSTAmount);
            iuSalesReturnDetail[13] = new Smartworks.ColumnField("@AddedBy", AddedBy);
            iuSalesReturnDetail[14] = new Smartworks.ColumnField("@AddedOn", AddedOn);
            iuSalesReturnDetail[15] = new Smartworks.ColumnField("@AddedIpAddr", AddedIpAddr);
            iuSalesReturnDetail[16] = new Smartworks.ColumnField("@Grade", Grade);

            if (customdataAcess != null)
            {
                Id = Convert.ToInt32(customdataAcess.ExecuteStoredProcedure("InsertUpdateSalesRetrunDetail", iuSalesReturnDetail));
            }
            else
            {
                dataAccess.BeginTransaction();
                Id = Convert.ToInt32(dataAccess.getDataTableByStoredProcedure("InsertUpdateSalesRetrunDetail", iuSalesReturnDetail));
                dataAccess.TransCommit();
            }
            return Id;
        }


        public bool DeleteSalesReturnDetail(int DetailId, Smartworks.DAL customdataAcess = null)
        {

            bool result = true;
            Smartworks.ColumnField[] dSalesReturnDetail = new Smartworks.ColumnField[1];
            dSalesReturnDetail[0] = new Smartworks.ColumnField("@SalesReturnDetailId", DetailId);

            if (customdataAcess != null)
            {
                customdataAcess.ExecuteStoredProcedure("DeleteSaleReturnDetailByDetailId", dSalesReturnDetail);
            }
            else
            {
                dataAccess.BeginTransaction();
                dataAccess.ExecuteStoredProcedure("DeleteSaleReturnDetailByDetailId", dSalesReturnDetail);
                dataAccess.TransCommit();
            }
            return result;
        }

        public int GetSalesReturnMasterIdByCode(string Code , int Fyear)
        {
            int Id = -1;
            DataTable dt = new DataTable();
            dt = dataAccess.getDataTable("Select SalesReturnMasterId  from SalesReturnMaster where SalesReturnNo  ='" + Code + "' and Fyear= '" + Fyear + "' ");
            if (dt.Rows.Count > 0)
            {
                Id = Convert.ToInt32(dt.Rows[0]["SalesReturnMasterId"].ToString());
            }
            return Id;
        }

        #region Navigation
        public string GetNextSaleReturnInvioceNo(string Code)
        {
            string SalesInvoiceNo = "";
            DataTable dt = new DataTable();
            dt = dataAccess.getDataTable("Select dbo.GetNextNumber('" + Code + "') as SalesInvoiceNo ");
            if (dt.Rows.Count > 0)
            {
                SalesInvoiceNo = (string)dt.Rows[0]["SalesInvoiceNo"].ToString();
            }
            return SalesInvoiceNo;
        }

        public string GetPrevSaleReturnInvioceNo(string Code)
        {
            string SalesInvoiceNo = "";
            DataTable dt = new DataTable();
            dt = dataAccess.getDataTable("Select dbo.GetPreviousNumber('" + Code + "') as SalesInvoiceNo ");
            if (dt.Rows.Count > 0)
            {

                SalesInvoiceNo = dt.Rows[0]["SalesInvoiceNo"].ToString();
            }
            return SalesInvoiceNo;
        }

        public string GetMaxSaleReturnInvioceNo(int FYear)
        {
            string SalesInvoiceNo = "";
            DataTable dt = new DataTable();

            dt = dataAccess.getDataTable("select max(SalesReturnNo)as 'SalesInvoiceNo' from SalesReturnMaster where FYear = '" + FYear + "' ");
            if (dt.Rows.Count > 0)
            {
                SalesInvoiceNo = dt.Rows[0]["SalesInvoiceNo"].ToString();
            }
            return SalesInvoiceNo;
        }

        public string GetMinSaleReturnInvioceNo(int FYear)
        {
            string SalesInvoiceNo = "";
            DataTable dt = new DataTable();

            dt = dataAccess.getDataTable("select min(SalesReturnNo) as 'SalesInvoiceNo' from SalesReturnMaster where FYear = '" + FYear + "' ");
            if (dt.Rows.Count > 0)
            {
                SalesInvoiceNo = dt.Rows[0]["SalesInvoiceNo"].ToString();
            }
            return SalesInvoiceNo;
        }
        #endregion
    }
}
