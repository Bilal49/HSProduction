using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace FIL.App_Code.SaleMasterManager
{
    class SalesManager
    {
        Smartworks.DAL dataAccess = new Smartworks.DAL();
        public SalesManager()
        {

            string connString = ConfigurationManager.ConnectionStrings["HSConnectionString"].ConnectionString;
            Smartworks.DAL.ConnectionString = connString;
        }

        public DataTable InsertSalesMaster(int SalesMasterId, string PackingListNo, DateTime Date, DateTime DueDate, string CustomerCode, string OrderedBy,
                                string Phone, decimal TAmount, decimal TDiscountPerc, decimal TDiscount, decimal AmountReceived,
                                 decimal GSTPercent, decimal GSTAmount, string Remarks, bool Hold, int AddedBy, bool Posted,
                                 DateTime AddedOn, string AddedIpAddr, decimal CashReceived, decimal CashBack, decimal BankAmount, int TiltId, bool IsGSTInvoice , int FYear
                                 , Smartworks.DAL customdataAcess = null)
        {

            DataTable dt = new DataTable();
            Smartworks.ColumnField[] iSalesMaster = new Smartworks.ColumnField[25];
            iSalesMaster[0] = new Smartworks.ColumnField("@SalesMasterId", SalesMasterId);
            iSalesMaster[1] = new Smartworks.ColumnField("@PackingListNo", PackingListNo);
            iSalesMaster[2] = new Smartworks.ColumnField("@Date", Date);
            iSalesMaster[3] = new Smartworks.ColumnField("@DueDate", DueDate);
            iSalesMaster[4] = new Smartworks.ColumnField("@CustomerCode", CustomerCode);
            iSalesMaster[5] = new Smartworks.ColumnField("@OrderedBy", OrderedBy);
            iSalesMaster[6] = new Smartworks.ColumnField("@Phone", Phone);
            iSalesMaster[7] = new Smartworks.ColumnField("@TAmount", TAmount);
            iSalesMaster[8] = new Smartworks.ColumnField("@TDiscountPerc", TDiscountPerc);
            iSalesMaster[9] = new Smartworks.ColumnField("@TDiscount", TDiscount);
            iSalesMaster[10] = new Smartworks.ColumnField("@AmountReceived", AmountReceived);
            iSalesMaster[11] = new Smartworks.ColumnField("@GSTPercent", GSTPercent);
            iSalesMaster[12] = new Smartworks.ColumnField("@GSTAmount", GSTAmount);
            iSalesMaster[13] = new Smartworks.ColumnField("@Remarks", Remarks);
            iSalesMaster[14] = new Smartworks.ColumnField("@Hold", Hold);
            iSalesMaster[15] = new Smartworks.ColumnField("@AddedBy", AddedBy);
            iSalesMaster[16] = new Smartworks.ColumnField("@Posted", Posted);
            iSalesMaster[17] = new Smartworks.ColumnField("@AddedOn", AddedOn);
            iSalesMaster[18] = new Smartworks.ColumnField("@AddedIpAddr", AddedIpAddr);
            iSalesMaster[19] = new Smartworks.ColumnField("@CashReceived", CashReceived);
            iSalesMaster[20] = new Smartworks.ColumnField("@CashBack", CashBack);
            iSalesMaster[21] = new Smartworks.ColumnField("@BankAmount", BankAmount);
            iSalesMaster[22] = new Smartworks.ColumnField("@TiltId", TiltId);
            iSalesMaster[23] = new Smartworks.ColumnField("@IsGSTInvoice", IsGSTInvoice);
            iSalesMaster[24] = new Smartworks.ColumnField("@FYear", FYear);
            if (customdataAcess != null)
            {
                dt = customdataAcess.getDataTableByStoredProcedure("dbo.InsertSaleMaster", iSalesMaster);
            }
            else
            {
                dataAccess.BeginTransaction();
                dt = dataAccess.getDataTableByStoredProcedure("dbo.InsertSaleMaster", iSalesMaster);
                dataAccess.TransCommit();
            }
            return dt;

        }

        public int InsertReceivedPayment(Int32 SaleMasterId, String TYPE, Decimal TotalAmount,
            Decimal AmountReceived, Decimal CashBack, DateTime Date, Smartworks.DAL customdataAcess = null)
        {
            int id = 0;
            Smartworks.ColumnField[] iReceivedPayment = new Smartworks.ColumnField[6];
            iReceivedPayment[0] = new Smartworks.ColumnField("@SalesMasterId", SaleMasterId);
            iReceivedPayment[1] = new Smartworks.ColumnField("@Type", TYPE);
            iReceivedPayment[2] = new Smartworks.ColumnField("@TotalAmount", TotalAmount);
            iReceivedPayment[3] = new Smartworks.ColumnField("@AmountReceived", AmountReceived);
            iReceivedPayment[4] = new Smartworks.ColumnField("@CashBack", CashBack);
            iReceivedPayment[5] = new Smartworks.ColumnField("@Date", Date);
            if (customdataAcess != null)
            {
                id = Convert.ToInt32(customdataAcess.ExecuteStoredProcedure("dbo.InsertPaymentReceived", iReceivedPayment));
            }
            else
            {
                dataAccess.BeginTransaction();
                id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.InsertPaymentReceived", iReceivedPayment));
                dataAccess.TransCommit();
            }

            return id;
        }



        public void UpdateSalesMaster(int SalesMasterId, DateTime Date, DateTime DueDate, string CustomerCode,
                                 String CustomerName, string Phone, Decimal TAmount, Decimal TDiscountPerc, Decimal TDiscount, Decimal AmountReceived,
                                 string Remarks, bool Hold, int AddedBy, bool Posted,
                                 DateTime AddedOn, String AddedIpAddr, Decimal CashReceived, Decimal CashBack, Decimal BankAmount, int TiltId)
        {
            Smartworks.ColumnField[] uSalesMaster = new Smartworks.ColumnField[20];


            uSalesMaster[0] = new Smartworks.ColumnField("@SalesMasterId", SalesMasterId);
            uSalesMaster[1] = new Smartworks.ColumnField("@Date", Date);
            uSalesMaster[2] = new Smartworks.ColumnField("@DueDate", DueDate);
            uSalesMaster[3] = new Smartworks.ColumnField("@CustomerCode", CustomerCode);
            uSalesMaster[4] = new Smartworks.ColumnField("@CustomerName", CustomerName);
            uSalesMaster[5] = new Smartworks.ColumnField("@Phone", Phone);
            uSalesMaster[6] = new Smartworks.ColumnField("@TAmount", TAmount);
            uSalesMaster[7] = new Smartworks.ColumnField("@TDiscountPerc", TDiscountPerc);
            uSalesMaster[8] = new Smartworks.ColumnField("@TDiscount", TDiscount);
            uSalesMaster[9] = new Smartworks.ColumnField("@AmountReceived", AmountReceived);
            uSalesMaster[10] = new Smartworks.ColumnField("@Remarks", Remarks);
            uSalesMaster[11] = new Smartworks.ColumnField("@Hold", Hold);
            uSalesMaster[12] = new Smartworks.ColumnField("@AddedBy", AddedBy);
            uSalesMaster[13] = new Smartworks.ColumnField("@Posted", Posted);
            uSalesMaster[14] = new Smartworks.ColumnField("@AddedOn", AddedOn);
            uSalesMaster[15] = new Smartworks.ColumnField("@AddedIpAddr", AddedIpAddr);
            uSalesMaster[16] = new Smartworks.ColumnField("@CashReceived", CashReceived);
            uSalesMaster[17] = new Smartworks.ColumnField("@CashBack", CashBack);
            uSalesMaster[18] = new Smartworks.ColumnField("@BankAmount", BankAmount);
            uSalesMaster[19] = new Smartworks.ColumnField("@TiltId", TiltId);
            dataAccess.BeginTransaction();
            dataAccess.ExecuteStoredProcedure("dbo.UpdateSaleMaster", uSalesMaster);
            dataAccess.TransCommit();
        }


        public int DeleteSalesMaster(string SalesMasterId)
        {
            int id;

            Smartworks.ColumnField[] dSaleMasater = new Smartworks.ColumnField[1];
            dSaleMasater[0] = new Smartworks.ColumnField("@SalesMasterId", SalesMasterId);

            dataAccess.BeginTransaction();
            id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.DeleteSaleMaster", dSaleMasater));

            dataAccess.TransCommit();

            return id;
        }

        public void DeleteSalesByInvoiceNo(string SalesInvoiceNo, Smartworks.DAL customdataAcess = null)
        {


            Smartworks.ColumnField[] dSaleMasater = new Smartworks.ColumnField[1];
            dSaleMasater[0] = new Smartworks.ColumnField("@SalesInvoiceNo", SalesInvoiceNo);

            if (customdataAcess != null)
            {
                
                customdataAcess.ExecuteStoredProcedure("dbo.DeleteSalesByInvoiceNo", dSaleMasater);
            }
            else
            {
                dataAccess.BeginTransaction();
                dataAccess.ExecuteStoredProcedure("dbo.DeleteSalesByInvoiceNo", dSaleMasater);
                dataAccess.TransCommit();
            }


        }

        public DataTable GetSaleMaster(int SalesMasterId)
        {

            DataTable dt;
            dt = dataAccess.getDataTable("Select * from SalesMaster where SalesMasterId =" + SalesMasterId);
            return dt;
        }
        public int GetSalesMasterIdByCode(string Code , bool IsGSTInvoice , int Fyear)
        {
            int SalesMasterId = -1;
            DataTable dt = new DataTable();
            dt = dataAccess.getDataTable("Select SalesMasterId from SalesMaster where SalesInvoiceNo = '" + Code + "' and IsGSTInvoice =" + ((IsGSTInvoice) ? "1" : "0") + " and (SalesMaster.FYear = '"+ Fyear +"') ");
            if (dt.Rows.Count > 0)
            {
                SalesMasterId = (int)dt.Rows[0]["SalesMasterId"];
            }
            return SalesMasterId;
        }
        public DataTable GetSalesMasterList()
        {
            DataTable dt = new DataTable();
            dt = dataAccess.getDataTable("Select SalesMasterId , upper(left(Name, 1)) + right(Name, len(Name) - 1) as CustomerName  from SalesMaster Order by Name ");
            return dt;

        }

        public DataSet GetSalesStructure(int SalesMasterId)
        {
            DataSet ds = new DataSet();
            Smartworks.ColumnField[] getSales = new Smartworks.ColumnField[1];
            getSales[0] = new Smartworks.ColumnField("@SalesMasterId", SalesMasterId);
            ds = dataAccess.getDataSetByStoredProcedure("sp_GetDirectSalesStructure", getSales);
            return ds;
        }

        public DataSet GetSalesStructureByPackingListId(int PackingListId)
        {
            DataSet ds = new DataSet();
            Smartworks.ColumnField[] getSales = new Smartworks.ColumnField[1];
            getSales[0] = new Smartworks.ColumnField("@PackingListId", PackingListId);
            ds = dataAccess.getDataSetByStoredProcedure("sp_GetDirectSalesStructureByPackingListId", getSales);
            return ds;
        }

        public DataSet GetInvoiceByNo(string InvoiceNo)
        {
            DataSet ds = new DataSet();
            Smartworks.ColumnField[] getSales = new Smartworks.ColumnField[1];
            getSales[0] = new Smartworks.ColumnField("@SalesInvoiceNo", InvoiceNo);

            ds = dataAccess.getDataSetByStoredProcedure("sp_GetDirectSalesByInvoiceNo", getSales);
            return ds;
        }


        public void PostSalesInvoice(int SalesMasterId, int AddedBy, DateTime AddedOn, string AddedIpAddr, Smartworks.DAL customdataAcess = null)
        {
            Smartworks.ColumnField[] pSales = new Smartworks.ColumnField[4];
            pSales[0] = new Smartworks.ColumnField("@SalesMasterId", SalesMasterId);
            pSales[1] = new Smartworks.ColumnField("@AddedBy", AddedBy);
            pSales[2] = new Smartworks.ColumnField("@AddedOn", AddedOn);
            pSales[3] = new Smartworks.ColumnField("@AddedIpAddr", AddedIpAddr);
            if (customdataAcess != null)
            {   
                customdataAcess.ExecuteStoredProcedure("dbo.sp_PostSalesInvoice", pSales);
             
            }
            else
            {
                dataAccess.BeginTransaction();
                dataAccess.ExecuteStoredProcedure("dbo.sp_PostSalesInvoice", pSales);
                dataAccess.TransCommit();
            }
            
        }

        public void UNPostSalesInvoice(int SalesMasterId, int AddedBy, DateTime AddedOn, string AddedIpAddr, Smartworks.DAL customdataAcess = null)
        {
            Smartworks.ColumnField[] pSales = new Smartworks.ColumnField[4];
            pSales[0] = new Smartworks.ColumnField("@SalesMasterId", SalesMasterId);
            pSales[1] = new Smartworks.ColumnField("@AddedBy", AddedBy);
            pSales[2] = new Smartworks.ColumnField("@AddedOn", AddedOn);
            pSales[3] = new Smartworks.ColumnField("@AddedIpAddr", AddedIpAddr);
            if (customdataAcess != null)
            {
                customdataAcess.ExecuteStoredProcedure("dbo.sp_UNPostSalesInvoice", pSales);

            }
            else
            {
                dataAccess.BeginTransaction();
                dataAccess.ExecuteStoredProcedure("dbo.sp_UNPostSalesInvoice", pSales);
                dataAccess.TransCommit();
            }

        }


        public DataTable GetUnPostedSales(DateTime FromDate , DateTime ToDate )
        {
            return dataAccess.getDataTable("Select * from SalesMaster where (Cast(Date as Date) between Cast('" + FromDate + "' as Date) and Cast('" + ToDate + "' as Date)) and (Posted = 0 ) ");
        }

        #region SalesDetailMethods

        public int InsertSalesDetail(Int32 SalesDetailId, Int32 SalesMasterId, Int32 ProductId, String StockType,
                                 String BatchNo, string ExpiryDate, Int32 WarehouseId, Decimal Quantity, Decimal Price, Decimal DiscountPercent,
                                 Decimal DiscountAmount, Decimal GSTPercent, Decimal GSTAmount, Int32 ReturnedQty,
                                 Int32 AddedBy, DateTime AddedOn, Decimal AddedIpAddr, decimal RetailPrice ,  Smartworks.DAL customdataAcess = null)
        {
            Int32 id = 0;
            Smartworks.ColumnField[] iSalesDetail = new Smartworks.ColumnField[18];
            iSalesDetail[0] = new Smartworks.ColumnField("@SalesDetailId", SalesDetailId);
            iSalesDetail[1] = new Smartworks.ColumnField("@SalesMasterId", SalesMasterId);
            iSalesDetail[2] = new Smartworks.ColumnField("@ProductId", ProductId);
            iSalesDetail[3] = new Smartworks.ColumnField("@StockType", StockType);
            iSalesDetail[4] = new Smartworks.ColumnField("@BatchNo", BatchNo);
            iSalesDetail[5] = new Smartworks.ColumnField("@ExpiryDate", (string.IsNullOrEmpty(ExpiryDate) ? (object)DBNull.Value : ExpiryDate));
            iSalesDetail[6] = new Smartworks.ColumnField("@WarehouseId", WarehouseId);
            iSalesDetail[7] = new Smartworks.ColumnField("@Quantity", Quantity);
            iSalesDetail[8] = new Smartworks.ColumnField("@Price", Price);
            iSalesDetail[9] = new Smartworks.ColumnField("@DiscountPercent", DiscountPercent);
            iSalesDetail[10] = new Smartworks.ColumnField("@DiscountAmount ", DiscountAmount);
            iSalesDetail[11] = new Smartworks.ColumnField("@GSTPercent", GSTPercent);
            iSalesDetail[12] = new Smartworks.ColumnField("@GSTAmount", GSTAmount);
            iSalesDetail[13] = new Smartworks.ColumnField("@ReturnedQty", ReturnedQty);
            iSalesDetail[14] = new Smartworks.ColumnField("@AddedBy", AddedBy);
            iSalesDetail[15] = new Smartworks.ColumnField("@AddedOn", AddedOn);
            iSalesDetail[16] = new Smartworks.ColumnField("@AddedIpAddr", AddedIpAddr);
            iSalesDetail[17] = new Smartworks.ColumnField("@RetailPrice", RetailPrice);
            
            if (customdataAcess != null)
            {
                id = Convert.ToInt32(customdataAcess.ExecuteStoredProcedure("dbo.InsertSaleDetail", iSalesDetail));
            }
            else
            {
                dataAccess.BeginTransaction();
                id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.InsertSaleDetail", iSalesDetail));
            }

            return id;
        }
        public void UpdateSalesDetail(int SalesDetailId, Int32 ProductId, String StockType,
                               String BatchNo, DateTime ExpiryDate, Int32 WarehouseId, Decimal Quantity, Decimal Price, Decimal AmountReceived,
                               Decimal DiscountAmount, Decimal GSTPercent, Decimal GSTAmount, Int32 ReturnedQty,
                               Int32 UpdatedBy, DateTime UpdatedOn, Decimal UpdatedIpAddr)
        {
            Smartworks.ColumnField[] uSalesDetail = new Smartworks.ColumnField[20];


            uSalesDetail[1] = new Smartworks.ColumnField("@ProductId  ", ProductId);
            uSalesDetail[2] = new Smartworks.ColumnField("@StockType  ", StockType);
            uSalesDetail[3] = new Smartworks.ColumnField("@BatchNo    ", BatchNo);
            uSalesDetail[4] = new Smartworks.ColumnField("@ExpiryDate ", ExpiryDate);
            uSalesDetail[5] = new Smartworks.ColumnField("@WarehouseId", WarehouseId);
            uSalesDetail[6] = new Smartworks.ColumnField("@Quantity   ", Quantity);
            uSalesDetail[7] = new Smartworks.ColumnField("@Price      ", Price);
            uSalesDetail[8] = new Smartworks.ColumnField("@DiscountPercent", AmountReceived);
            uSalesDetail[9] = new Smartworks.ColumnField("@DiscountAmount ", DiscountAmount);
            uSalesDetail[10] = new Smartworks.ColumnField("@GSTPercent     ", GSTPercent);
            uSalesDetail[11] = new Smartworks.ColumnField("@GSTAmount 	 ", GSTAmount);
            uSalesDetail[12] = new Smartworks.ColumnField("@ReturnedQty    ", ReturnedQty);
            uSalesDetail[13] = new Smartworks.ColumnField("@UpdatedBy        ", UpdatedBy);
            uSalesDetail[14] = new Smartworks.ColumnField("@UpdatedOn        ", UpdatedOn);
            uSalesDetail[15] = new Smartworks.ColumnField("@UpdatedIpAddr    ", UpdatedIpAddr);

            dataAccess.BeginTransaction();
            dataAccess.ExecuteStoredProcedure("dbo.UpdateSalesDetail", uSalesDetail);
            dataAccess.TransCommit();
        }


        public int DeleteSalesDetail(int SalesDetailId, Smartworks.DAL customdataAcess = null)
        {
            int id = 0;

            Smartworks.ColumnField[] dSalesDetail = new Smartworks.ColumnField[1];
            dSalesDetail[0] = new Smartworks.ColumnField("@SalesDetailId", SalesDetailId);

            if (customdataAcess != null)
            {
                customdataAcess.ExecuteStoredProcedure("dbo.DeleteSalesDetail", dSalesDetail);
            }
            else
            {
                dataAccess.BeginTransaction();
                id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.DeleteSalesDetail", dSalesDetail));
                dataAccess.TransCommit();
            }



            return id;
        }

        public DataTable GetSalesDetailById(int SalesMasterId)
        {

            DataTable dt;
            dt = dataAccess.getDataTable("Select * from SalesDetail where SalesMasterId =" + SalesMasterId);
            return dt;
        }
        public int GetSalesDetailIdByCode(int SalesDetailId)
        {
            int SalesGetId = -1;
            DataTable dt = new DataTable();
            dt = dataAccess.getDataTable("Select SalesDetailId from SalesDetail where SalesDetailId = '" + SalesDetailId + "' ");
            if (dt.Rows.Count > 0)
            {
                SalesGetId = (int)dt.Rows[0]["SalesDetailId"];
            }
            return SalesGetId;
        }
        public DataTable GetSalesDetailList()
        {
            DataTable dt = new DataTable();
            dt = dataAccess.getDataTable("Select SalesDetailId , upper(left(Name, 1)) + right(Name, len(Name) - 1) as ProductId  from SalesDetail Order by Name ");
            return dt;

        }


        #endregion

        #region Navigation
        public string GetNextSaleInvioceNo(string Code)
        {
            string SalesInvoiceNo = "";
            DataTable dt = new DataTable();

            //dt = dataAccess.getDataTable("Select(select SalesInvoiceNo  from SalesMaster where SalesMasterId = s.SalesMasterId + 1) as 'SalesInvoiceNo' from SalesMaster s where SalesInvoiceNo =  '" + Code + "'");
            dt = dataAccess.getDataTable("Select dbo.GetNextNumber('" + Code + "') as SalesInvoiceNo ");
            if (dt.Rows.Count > 0)
            {
                SalesInvoiceNo = (string)dt.Rows[0]["SalesInvoiceNo"].ToString();
            }
            return SalesInvoiceNo;
        }

        public string GetPrevSaleInvioceNo(string Code)
        {
            string SalesInvoiceNo = "";
            DataTable dt = new DataTable();

            //dt = dataAccess.getDataTable("Select(select SalesInvoiceNo from SalesMaster where SalesMasterId = s.SalesMasterId - 1) as 'SalesInvoiceNo' from SalesMaster s where SalesInvoiceNo =  '" + Code + "'");
            dt = dataAccess.getDataTable("Select dbo.GetPreviousNumber('" + Code + "') as SalesInvoiceNo");
            if (dt.Rows.Count > 0)
            {

                SalesInvoiceNo = (string)dt.Rows[0]["SalesInvoiceNo"].ToString();
            }
            return SalesInvoiceNo;
        }

        public string GetMaxSaleInvioceNo(bool IsGSTInvoice , int FYear)
        {
            string SalesInvoiceNo = "";
            DataTable dt = new DataTable();

            dt = dataAccess.getDataTable("select max(SalesInvoiceNo)as 'SalesInvoiceNo' from SalesMaster where IsGSTInvoice = " + ((IsGSTInvoice) ? "1" : "0") + " and (SalesMaster.FYear = '" + FYear + "') ");
            if (dt.Rows.Count > 0)
            {
                SalesInvoiceNo = dt.Rows[0]["SalesInvoiceNo"].ToString();
            }
            //else
            //{
            //    if (IsGSTInvoice)
            //    {
            //        SalesInvoiceNo = "STI-000001"; //for Sales Tax Invoice
            //    }
            //    else
            //    {
            //        SalesInvoiceNo = "SI-000001";  //for Local Sales Invoice
            //    }
            //}
            return SalesInvoiceNo;
        }

        public string GetMinSaleInvioceNo(bool IsGSTInvoice, int FYear )
        {
            string SalesInvoiceNo = "";
            DataTable dt = new DataTable();

            dt = dataAccess.getDataTable("select min(SalesInvoiceNo) as 'SalesInvoiceNo' from SalesMaster where IsGSTInvoice = " + ((IsGSTInvoice) ? "1" : "0") + " and (SalesMaster.FYear = '" + FYear + "') ");
            if (dt.Rows.Count > 0)
            {
                SalesInvoiceNo = dt.Rows[0]["SalesInvoiceNo"].ToString();
            }
            return SalesInvoiceNo;
        }
        #endregion

        #region Report Works

        public DataTable GetPOSReport(string SalesInvoiceNo)
        {
            DataTable dt = new DataTable();
            Smartworks.ColumnField[] report = new Smartworks.ColumnField[1];
            report[0] = new Smartworks.ColumnField("@SaleInvoiceNo", SalesInvoiceNo);

            dt = dataAccess.getDataTableByStoredProcedure("sp_ReportPOSSlip", report);

            return dt;

        }

        public DataTable GetSalesInvoiceReport(Nullable<DateTime> FromDate, Nullable<DateTime> ToDate, string FromInvoice, string ToInvoice, string FromCustomer, string ToCustomer, string SalesInvoiceNo = "")
        {

            DataTable dt = new DataTable();
            Smartworks.ColumnField[] report = new Smartworks.ColumnField[7];
            if (FromDate == null)
            {
                report[0] = new Smartworks.ColumnField("@FromDate", DBNull.Value);
            }
            else
            {
                report[0] = new Smartworks.ColumnField("@FromDate", FromDate);
            }
            if (ToDate == null)
            {
                report[1] = new Smartworks.ColumnField("@ToDate", DBNull.Value);
            }
            else
            {
                report[1] = new Smartworks.ColumnField("@ToDate", ToDate);
            }

            report[2] = new Smartworks.ColumnField("@FromInvoice", FromInvoice);
            report[3] = new Smartworks.ColumnField("@ToInvoice", ToInvoice);

            report[4] = new Smartworks.ColumnField("@FromCustomer", FromCustomer);
            report[5] = new Smartworks.ColumnField("@ToCustomer", ToCustomer);


            report[6] = new Smartworks.ColumnField("@SalesInvoiceNo", SalesInvoiceNo);

            dt = dataAccess.getDataTableByStoredProcedure("sp_ReportSalesInvoiceNoByInvoiceNo", report);
            return dt;
        }

        public DataTable GetSalesInvoiceReport(string SalesInvoiceNo)
        {
            DataTable dt = new DataTable();
            Smartworks.ColumnField[] report = new Smartworks.ColumnField[1];
            report[0] = new Smartworks.ColumnField("@SalesInvoiceNo", SalesInvoiceNo);
            dt = dataAccess.getDataTableByStoredProcedure("sp_ReportSalesInvoice", report);
            return dt;
        }

        public DataTable GetSalesInvoiceReportWithGST(string SalesInvoiceNo)
        {
            DataTable dt = new DataTable();
            Smartworks.ColumnField[] report = new Smartworks.ColumnField[1];
            report[0] = new Smartworks.ColumnField("@SalesInvoiceNo", SalesInvoiceNo);
            dt = dataAccess.getDataTableByStoredProcedure("sp_ReportSalesInvoiceWithGST", report);
            return dt;
        }

        public DataTable GetSalesInvoiceSummaryReport(Nullable<DateTime> FromDate, Nullable<DateTime> ToDate, string FromInvoice, string ToInvoice, string FromCustomer, string ToCustomer, bool IsDetailWise)
        {

            DataTable dt = new DataTable();
            Smartworks.ColumnField[] report = new Smartworks.ColumnField[7];
            if (FromDate == null)
            {
                report[0] = new Smartworks.ColumnField("@FromDate", DBNull.Value);
            }
            else
            {
                report[0] = new Smartworks.ColumnField("@FromDate", FromDate);
            }
            if (ToDate == null)
            {
                report[1] = new Smartworks.ColumnField("@ToDate", DBNull.Value);
            }
            else
            {
                report[1] = new Smartworks.ColumnField("@ToDate", ToDate);
            }

            report[2] = new Smartworks.ColumnField("@FromInvoice", FromInvoice);
            report[3] = new Smartworks.ColumnField("@ToInvoice", ToInvoice);

            report[4] = new Smartworks.ColumnField("@FromCustomer", FromCustomer);
            report[5] = new Smartworks.ColumnField("@ToCustomer", ToCustomer);


            report[6] = new Smartworks.ColumnField("@IsDetailWise", IsDetailWise);

            dt = dataAccess.getDataTableByStoredProcedure("sp_ReportSalesInvoiceSummary", report);
            return dt;
        }

        public DataTable GetSalesDetailTypeReport(Nullable<DateTime> FromDate, Nullable<DateTime> ToDate, string FromCustomer, string ToCustomer, int ProductTypeId)
        {

            DataTable dt = new DataTable();
            Smartworks.ColumnField[] report = new Smartworks.ColumnField[5];
            if (FromDate == null)
            {
                report[0] = new Smartworks.ColumnField("@FromDate", DBNull.Value);
            }
            else
            {
                report[0] = new Smartworks.ColumnField("@FromDate", FromDate);
            }
            if (ToDate == null)
            {
                report[1] = new Smartworks.ColumnField("@ToDate", DBNull.Value);
            }
            else
            {
                report[1] = new Smartworks.ColumnField("@ToDate", ToDate);
            }
            report[2] = new Smartworks.ColumnField("@FromCustomer", FromCustomer);
            report[3] = new Smartworks.ColumnField("@ToCustomer", ToCustomer);
            report[4] = new Smartworks.ColumnField("@ProductTypeId", ProductTypeId);

            dt = dataAccess.getDataTableByStoredProcedure("sp_ReportSalesDetailByProductType", report);
            return dt;
        }

        #endregion
    }
}
