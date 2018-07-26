using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace FIL.App_Code.PurchaseManager
{
    class PurchaseManager
    {
        Smartworks.DAL dataAccess = new Smartworks.DAL();
        public PurchaseManager()
        {

            string connString = ConfigurationManager.ConnectionStrings["HSConnectionString"].ConnectionString;
            Smartworks.DAL.ConnectionString = connString;
        }

        public DataSet GetPurchaseStructure(int PurchaseMasterId)
        {
            DataSet ds = new DataSet();
            Smartworks.ColumnField[] getPurchaseInvoice = new Smartworks.ColumnField[1];
            getPurchaseInvoice[0] = new Smartworks.ColumnField("@PurchaseMasterId", PurchaseMasterId);
            ds = dataAccess.getDataSetByStoredProcedure("sp_GetPurchaseInvoiceStructure", getPurchaseInvoice); 
            return ds;
        }

        public DataSet GetPurchaseStructureRPOId(int RPOId)
        {
            DataSet ds = new DataSet();
            Smartworks.ColumnField[] getRPOrder = new Smartworks.ColumnField[1];
            getRPOrder[0] = new Smartworks.ColumnField("@RPOId", RPOId);
            ds = dataAccess.getDataSetByStoredProcedure("sp_GetPurchaseInvoiceStructureByRPOId", getRPOrder);
            return ds;
        }
        

        public DataSet GetInvoiceByNo(string InvoiceNo)
        {
            DataSet ds = new DataSet();
            Smartworks.ColumnField[] getPurchase = new Smartworks.ColumnField[1];
            getPurchase[0] = new Smartworks.ColumnField("@PurchaseInvoiceNo", InvoiceNo);

            ds = dataAccess.getDataSetByStoredProcedure("sp_GetDirectPurchaseByInvoiceNo", getPurchase);
            return ds;
        }

        public DataTable InsertPurchaseMaster(string RPONo ,  DateTime ReceivedOn, DateTime DueDate, string VendorCode,
                                 String EmployeeCode, decimal TAmount, decimal TDiscountPerc, decimal TDiscount,  decimal GSTPercent , decimal GSTAmount ,  decimal AmountPaid,
                                 string Remarks, string VoucherNo, int AddedBy
                                 , DateTime AddedOn, String AddedIpAddr, bool Hold, bool Posted
                                 , Smartworks.DAL customdataAcess = null)
        {
            
            DataTable dt = new DataTable();
            Smartworks.ColumnField[] iPurchaseMaster = new Smartworks.ColumnField[18];
            iPurchaseMaster[0] = new Smartworks.ColumnField("@RPONo", RPONo);
            iPurchaseMaster[1] = new Smartworks.ColumnField("@ReceivedOn", ReceivedOn);
            iPurchaseMaster[2] = new Smartworks.ColumnField("@DueDate", DueDate);
            iPurchaseMaster[3] = new Smartworks.ColumnField("@VendorCode", VendorCode);
            iPurchaseMaster[4] = new Smartworks.ColumnField("@EmployeeCode", EmployeeCode);
            iPurchaseMaster[5] = new Smartworks.ColumnField("@TAmount", TAmount);
            iPurchaseMaster[6] = new Smartworks.ColumnField("@TDiscountPerc", TDiscountPerc);
            iPurchaseMaster[7] = new Smartworks.ColumnField("@TDiscount", TDiscount);
            iPurchaseMaster[8] = new Smartworks.ColumnField("@GSTPercent", GSTPercent);
            iPurchaseMaster[9] = new Smartworks.ColumnField("@GSTAmount", GSTAmount);
            iPurchaseMaster[10] = new Smartworks.ColumnField("@AmountPaid", AmountPaid);
            iPurchaseMaster[11] = new Smartworks.ColumnField("@Remarks", Remarks);
            iPurchaseMaster[12] = new Smartworks.ColumnField("@VoucherNo", VoucherNo);
            iPurchaseMaster[13] = new  Smartworks.ColumnField("@AddedBy", AddedBy);
            iPurchaseMaster[14] =  new  Smartworks.ColumnField("@AddedOn", AddedOn);
            iPurchaseMaster[15] =  new  Smartworks.ColumnField("@AddedIpAddr", AddedIpAddr);
            iPurchaseMaster[16] = new Smartworks.ColumnField("@Hold", Hold);
            iPurchaseMaster[17] = new Smartworks.ColumnField("@Posted", Posted);
            if (customdataAcess != null)
            {
                dt = customdataAcess.getDataTableByStoredProcedure("dbo.InsertPurchaseMaster", iPurchaseMaster);
            }
            else
            {
                dataAccess.BeginTransaction();
                dt = dataAccess.getDataTableByStoredProcedure("dbo.InsertPurchaseMaster", iPurchaseMaster);
                dataAccess.TransCommit();
            }
            return dt;
           
        }

        public void UpdatePurchaseMaster(int PurchaseMasterId, string RPONo ,  DateTime ReceivedOn, DateTime DueDate, string VendorCode,
                                 string EmployeeCode, decimal TAmount, decimal TDiscountPerc, decimal TDiscount,  decimal AmountPaid, decimal GSTPercent , decimal GSTAmount , 
                                 string Remarks, string VoucherNo, int AddedBy
                                 , DateTime AddedOn, string AddedIpAddr, bool Hold, bool Posted , Smartworks.DAL customdataAcess = null )
        {
            Smartworks.ColumnField[] uPurchaseMaster = new Smartworks.ColumnField[19];
            uPurchaseMaster[0] = new Smartworks.ColumnField("@PurchaseMasterId", PurchaseMasterId);
            uPurchaseMaster[1] = new Smartworks.ColumnField("@RPONo", RPONo);
            uPurchaseMaster[2] = new Smartworks.ColumnField("@ReceivedOn", ReceivedOn);
            uPurchaseMaster[3] = new Smartworks.ColumnField("@DueDate", DueDate);
            uPurchaseMaster[4] = new Smartworks.ColumnField("@VendorCode", VendorCode);
            uPurchaseMaster[5] = new Smartworks.ColumnField("@EmployeeCode", EmployeeCode);
            uPurchaseMaster[6] = new Smartworks.ColumnField("@TAmount", TAmount);
            uPurchaseMaster[7] = new Smartworks.ColumnField("@TDiscountPerc", TDiscountPerc);
            uPurchaseMaster[8] = new Smartworks.ColumnField("@TDiscount", TDiscount);
            uPurchaseMaster[9] = new Smartworks.ColumnField("@GSTPercent", GSTPercent);
            uPurchaseMaster[10] = new Smartworks.ColumnField("@GSTAmount", GSTAmount);
            uPurchaseMaster[11] = new Smartworks.ColumnField("@AmountPaid", AmountPaid);
            uPurchaseMaster[12] = new Smartworks.ColumnField("@Remarks", Remarks);
            uPurchaseMaster[13] = new Smartworks.ColumnField("@VoucherNo", VoucherNo);
            uPurchaseMaster[14] = new Smartworks.ColumnField("@UpdatedBy", AddedBy);
            uPurchaseMaster[15] = new Smartworks.ColumnField("@UpdatedOn", AddedOn);
            uPurchaseMaster[16] = new Smartworks.ColumnField("@UpdatedIpAddr", AddedIpAddr);
            uPurchaseMaster[17] = new Smartworks.ColumnField("@Hold", Hold);
            uPurchaseMaster[18] = new Smartworks.ColumnField("@Posted", Posted);

            if (customdataAcess != null)
            {
                customdataAcess.ExecuteStoredProcedure("dbo.UpdatePurchaseMaster", uPurchaseMaster);
            }
            else
            {
                dataAccess.BeginTransaction();
                dataAccess.ExecuteStoredProcedure("dbo.UpdatePurchaseMaster", uPurchaseMaster);
                dataAccess.TransCommit();
            }

            
        }

        public int DeletePurchaseMaster(string PurchaseMasterId)
        {
            int id;

            Smartworks.ColumnField[] dPurchaseMaster = new Smartworks.ColumnField[1];
            dPurchaseMaster[0] = new Smartworks.ColumnField("@PurchaseMasterId", PurchaseMasterId);
            dataAccess.BeginTransaction();
            id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.DeletePurchaseMaster", dPurchaseMaster));
            dataAccess.TransCommit();

            return id;
        }

        public void DeletePurchaseByInvoiceNo(string PurchaseInvoiceNo, Smartworks.DAL customdataAcess = null)
        {
            Smartworks.ColumnField[] dPurchaseMasater = new Smartworks.ColumnField[1];
            dPurchaseMasater[0] = new Smartworks.ColumnField("@PurhcaseInvoiceNo", PurchaseInvoiceNo);
            if (customdataAcess != null)
            {
                customdataAcess.ExecuteStoredProcedure("dbo.DeletePurchaseByInvoiceNo", dPurchaseMasater);
            }
            else
            {
                dataAccess.BeginTransaction();
                dataAccess.ExecuteStoredProcedure("dbo.DeletePurchaseByInvoiceNo", dPurchaseMasater);
                dataAccess.TransCommit();
            }
        }

        public DataTable GetPurchaseMaster(int PurchaseMasterId)
        {

            DataTable dt;
            dt = dataAccess.getDataTable("Select * from PurchaseMaster where PurchaseMasterId =" + PurchaseMasterId);
            return dt;
        }

        public int GetPurchaseMasterIdByCode(string Code , int Fyear)
        {
            int SalesMasterId = -1;
            DataTable dt = new DataTable();
            dt = dataAccess.getDataTable("Select PurchaseMasterId from PurchaseMaster where PurchaseInvoiceNo = '" + Code + "' and FYear = '" + Fyear + "' ");
            if (dt.Rows.Count > 0)
            {
                SalesMasterId = (int)dt.Rows[0]["PurchaseMasterId"];
            }
            return SalesMasterId;
        }

        
            public DataTable GetUnPostedPurchase(DateTime FromDate , DateTime ToDate )
        {
            return dataAccess.getDataTable("Select * from PurchaseMaster where (Cast(ReceivedOn as Date) between Cast('" + FromDate + "' as Date) and Cast('" + ToDate + "' as Date)) and (Posted = 0 ) ");
        }

        //public DataTable GetPurchaseMasterList()
        //{
        //    DataTable dt = new DataTable();
        //    dt = dataAccess.getDataTable("Select PurchaseMasterId , upper(left(Name, 1)) + right(Name, len(Name) - 1) as VendorCode  from PurchaseMaster Order by Name ");
        //    return dt;

        //}


        #region PurchaseDetailMethods

        public int InsertPurchaseDetail(int PurchaseDetailId , int PurchaseMasterId,  int RPODetailId , int ProductId, decimal ReceivedQty, decimal Price,
                                 decimal DiscountPercent, decimal DiscountAmount, decimal ReturnedQty,
                                 int AddedBy, DateTime AddedOn, string AddedIpAddr, Smartworks.DAL customdataAcess = null)
        {
            Int32 id = 0;
            Smartworks.ColumnField[] iPurchaseDetail = new Smartworks.ColumnField[12];
            iPurchaseDetail[0] = new Smartworks.ColumnField("@PurchaseDetailId", PurchaseDetailId);
            iPurchaseDetail[1] = new Smartworks.ColumnField("@PurchaseMasterId", PurchaseMasterId);
            iPurchaseDetail[2] = new Smartworks.ColumnField("@RPODetailId", RPODetailId);
            iPurchaseDetail[3] = new Smartworks.ColumnField("@ProductId", ProductId);
            iPurchaseDetail[4] = new Smartworks.ColumnField("@ReceivedQty", ReceivedQty);
            iPurchaseDetail[5] = new Smartworks.ColumnField("@Price", Price);
            iPurchaseDetail[6] = new Smartworks.ColumnField("@DiscountPercent", DiscountPercent);
            iPurchaseDetail[7] = new Smartworks.ColumnField("@DiscountAmount", DiscountAmount);
            iPurchaseDetail[8] = new Smartworks.ColumnField("@ReturnedQty", ReturnedQty);
            iPurchaseDetail[9] = new Smartworks.ColumnField("@AddedBy", AddedBy);
            iPurchaseDetail[10] = new Smartworks.ColumnField("@AddedOn", AddedOn);
            iPurchaseDetail[11] = new Smartworks.ColumnField("@AddedIpAddr", AddedIpAddr);
            if (customdataAcess != null)
            {
                id = Convert.ToInt32(customdataAcess.ExecuteStoredProcedure("dbo.InsertPurchaseDetail", iPurchaseDetail));
            }
            else
            {
                dataAccess.BeginTransaction();
                id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.InsertPurchaseDetail", iPurchaseDetail));
            }
            return id;
        }
        public void UpdatePurchaseDetail(int PurchaseDetailId, Int32 PurchaseMasterId, Int32 ProductId, decimal ReceivedQty, decimal Price,
                                 decimal DiscountPercent, decimal DiscountAmount, decimal ReturnedQty, 
                                     Int32 UpdatedBy, DateTime UpdatedOn, Decimal UpdatedIpAddr)
        {
            Smartworks.ColumnField[] uPurchaseDetail = new Smartworks.ColumnField[11];
            uPurchaseDetail[0] = new Smartworks.ColumnField("@PurchaseDetailId", PurchaseDetailId);
            uPurchaseDetail[1] = new Smartworks.ColumnField("@PurchaseMasterId", PurchaseMasterId);
            uPurchaseDetail[2] = new Smartworks.ColumnField("@ProductId", ProductId);
            uPurchaseDetail[3] = new Smartworks.ColumnField("@ReceivedQty", ReceivedQty);
            uPurchaseDetail[4] = new Smartworks.ColumnField("@Price", Price);
            uPurchaseDetail[5] = new Smartworks.ColumnField("@DiscountPercent", DiscountPercent);
            uPurchaseDetail[6] = new Smartworks.ColumnField("@DiscountAmount", DiscountAmount);
            uPurchaseDetail[7] = new Smartworks.ColumnField("@ReturnedQty", ReturnedQty);
            uPurchaseDetail[8] = new Smartworks.ColumnField("@UpdatedBy", UpdatedBy);
            uPurchaseDetail[9] = new Smartworks.ColumnField("@UpdatedOn", UpdatedOn);
            uPurchaseDetail[10] = new Smartworks.ColumnField("@UpdatedIpAddr", UpdatedIpAddr);
            dataAccess.BeginTransaction();
            dataAccess.ExecuteStoredProcedure("dbo.UpdatePurchaseDetail", uPurchaseDetail);
            dataAccess.TransCommit();
        }



        public void PostPurchaseInvoice(int PurchaseMasterId, int AddedBy, DateTime AddedOn, string AddedIpAddr ,  Smartworks.DAL customdataAcess = null)
        {
            Smartworks.ColumnField[] pPurchase = new Smartworks.ColumnField[4];
            pPurchase[0] = new Smartworks.ColumnField("@PurchaseMasterId", PurchaseMasterId);
            pPurchase[1] = new Smartworks.ColumnField("@AddedBy", AddedBy);
            pPurchase[2] = new Smartworks.ColumnField("@AddedOn", AddedOn);
            pPurchase[3] = new Smartworks.ColumnField("@AddedIpAddr", AddedIpAddr);
            if (customdataAcess != null)
            {
                customdataAcess.ExecuteStoredProcedure("dbo.sp_PostPurchaseInvoice", pPurchase);
            }
            else
            {
                dataAccess.BeginTransaction();
                dataAccess.ExecuteStoredProcedure("dbo.sp_PostPurchaseInvoice", pPurchase);
                dataAccess.TransCommit();
            }
            
        }

        public void UNPostPurchaseInvoice(int PurchaseMasterId, int AddedBy, DateTime AddedOn, string AddedIpAddr, Smartworks.DAL customdataAcess = null)
        {
            Smartworks.ColumnField[] pPurchase = new Smartworks.ColumnField[4];
            pPurchase[0] = new Smartworks.ColumnField("@PurchaseMasterId", PurchaseMasterId);
            pPurchase[1] = new Smartworks.ColumnField("@AddedBy", AddedBy);
            pPurchase[2] = new Smartworks.ColumnField("@AddedOn", AddedOn);
            pPurchase[3] = new Smartworks.ColumnField("@AddedIpAddr", AddedIpAddr);
            if (customdataAcess != null)
            {
                customdataAcess.ExecuteStoredProcedure("dbo.sp_UNPostPurchaseInvoice", pPurchase);
            }
            else
            {
                dataAccess.BeginTransaction();
                dataAccess.ExecuteStoredProcedure("dbo.sp_UNPostPurchaseInvoice", pPurchase);
                dataAccess.TransCommit();
            }

        }

        public int DeletePurchaseDetail(int PurchaseDetailId , Smartworks.DAL customdataAccess = null)
        {
            int id = -1 ;

            Smartworks.ColumnField[] dPurchaseDetail = new Smartworks.ColumnField[1];
            dPurchaseDetail[0] = new Smartworks.ColumnField("@PurchaseDetailId", PurchaseDetailId);

            if (customdataAccess != null)
            {
                customdataAccess.ExecuteStoredProcedure("dbo.DeletePurchaseDetail", dPurchaseDetail);
            }
            else
            {
                dataAccess.BeginTransaction();
                id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.DeletePurchaseDetail", dPurchaseDetail));
                dataAccess.TransCommit();
            }
            return id;
        }

        public DataTable GetPurchaseDetailById(int PurchaseDetailId)
        {

            DataTable dt;
            dt = dataAccess.getDataTable("Select * from PurchaseDetail where PurchaseDetailId =" + PurchaseDetailId);
            return dt;
        }
        //public DataTable GetPurchaseDetailList()
        //{
        //    DataTable dt = new DataTable();
        //    dt = dataAccess.getDataTable("Select PurchaseDetailId , upper(left(Name, 1)) + right(Name, len(Name) - 1) as ProductId  from PurchaseDetail Order by Name ");
        //    return dt;

        //}
        #endregion


        #region Navigation

        public string GetMinInvioceNo(int FYear)
        {
            string InvoiceNo = "";
            DataTable dt = new DataTable();

            dt = dataAccess.getDataTable("select min(PurchaseInvoiceNo) as 'InvoiceNo' from PurchaseMaster  where FYear= '" + FYear + "' ");
            if (dt.Rows.Count > 0)
            {
                InvoiceNo = dt.Rows[0]["InvoiceNo"].ToString();
            }
            return InvoiceNo;
        }

        public string GetMaxInvioceNo(int Fyear)
        {
            string InvoiceNo = "";
            DataTable dt = new DataTable();

            dt = dataAccess.getDataTable("select max(PurchaseInvoiceNo) as 'InvoiceNo' from PurchaseMaster where FYear= '" + Fyear + "' ");
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


     



        #region Reports

        public DataTable GetPurchaseInvoiceReport(Nullable<DateTime> FromDate, Nullable<DateTime> ToDate, string FromInvoice, string ToInvoice, string FromVendor, string ToVendor, string PurchaseInvoiceNo = "")
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

            report[4] = new Smartworks.ColumnField("@FromVendor", FromVendor);
            report[5] = new Smartworks.ColumnField("@ToVendor", ToVendor);


            report[6] = new Smartworks.ColumnField("@PurchaseInvoiceNo", PurchaseInvoiceNo);

            dt = dataAccess.getDataTableByStoredProcedure("sp_ReportPurhcaseInvoiceNoByInvoiceNo", report);
            return dt;
        }


        #endregion
    }
}
