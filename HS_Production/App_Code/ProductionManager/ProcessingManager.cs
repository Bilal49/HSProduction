using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;

namespace FIL
{
    public class ProcessingManager
    {
        Smartworks.DAL dataAccess = new Smartworks.DAL();
        public ProcessingManager()
        {
            string connString = ConfigurationManager.ConnectionStrings["HSConnectionString"].ConnectionString;
            Smartworks.DAL.ConnectionString = connString;
        }

        public DataSet GetProcessStructure(int ProcessId)
        {
            DataSet ds = new DataSet();
            Smartworks.ColumnField[] gProduction = new Smartworks.ColumnField[1];
            gProduction[0] = new Smartworks.ColumnField("@ProcessId", ProcessId);
            ds = dataAccess.getDataSetByStoredProcedure("sp_GetProcessStructure", gProduction);
            return ds;
        }

        public int GetProcessMasterIdByCode(string code)
        {
            int Id = -1;
            DataTable dt = new DataTable();
            dt = dataAccess.getDataTable("Select ProcessMasterId from ProcessMaster where Code = '" + code + "' ");
            if (dt.Rows.Count > 0)
            {
                Id = Convert.ToInt32(dt.Rows[0]["ProcessMasterId"].ToString());
            }

            return Id;
        }


        public DataTable InsertProcessMaster(DateTime Date, int ProductId, decimal ProcessQty,
                                      int WarehouseId, int TransferWarehouseId, string SOrderNo, string Remarks, Smartworks.DAL customedataAcess = null)
        {
            DataTable dt = null;

            Smartworks.ColumnField[] iProcessMaster = new Smartworks.ColumnField[7];
            iProcessMaster[0] = new Smartworks.ColumnField("@Date", Date);
            iProcessMaster[1] = new Smartworks.ColumnField("@ProductId", ProductId);
            iProcessMaster[2] = new Smartworks.ColumnField("@ProcessQty", ProcessQty);
            iProcessMaster[3] = new Smartworks.ColumnField("@WarehouseId", WarehouseId);
            iProcessMaster[4] = new Smartworks.ColumnField("@TransferWarehouseId", TransferWarehouseId);
            iProcessMaster[5] = new Smartworks.ColumnField("@SOrderNo", SOrderNo);
            iProcessMaster[6] = new Smartworks.ColumnField("@Remarks", Remarks);

            if (customedataAcess != null)
            {
                dt = customedataAcess.getDataTableByStoredProcedure("InsertProcessMaster", iProcessMaster);
            }
            else
            {
                dataAccess.BeginTransaction();
                dt = dataAccess.getDataTableByStoredProcedure("InsertProcessMaster", iProcessMaster);
                dataAccess.TransCommit();
            }

            return dt;
        }


        public int UpdateProcessMaster(int ProcessMasterId, DateTime Date, int ProductId, decimal ProcessQty,
                                    int WarehouseId, int TransferWarehouseId, string SOrderNo, string Remarks, Smartworks.DAL customedataAcess = null)
        {
            int Id = -1;

            Smartworks.ColumnField[] uProcessMaster = new Smartworks.ColumnField[8];
            uProcessMaster[0] = new Smartworks.ColumnField("@ProcessMasterId", ProcessMasterId);
            uProcessMaster[1] = new Smartworks.ColumnField("@Date", Date);
            uProcessMaster[2] = new Smartworks.ColumnField("@ProductId", ProductId);
            uProcessMaster[3] = new Smartworks.ColumnField("@ProcessQty", ProcessQty);
            uProcessMaster[4] = new Smartworks.ColumnField("@WarehouseId", WarehouseId);
            uProcessMaster[5] = new Smartworks.ColumnField("@TransferWarehouseId", TransferWarehouseId);
            uProcessMaster[6] = new Smartworks.ColumnField("@SOrderNo", SOrderNo);
            uProcessMaster[7] = new Smartworks.ColumnField("@Remarks", Remarks);

            if (customedataAcess != null)
            {
                Id = Convert.ToInt32(customedataAcess.ExecuteStoredProcedure("UpdateProcessMaster", uProcessMaster));
            }
            else
            {
                dataAccess.BeginTransaction();
                Id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("UpdateProcessMaster", uProcessMaster));
                dataAccess.TransCommit();
            }

            return Id;
        }


        public int InsertUpdateProcessMasterDetail(int ProcessDetailId, int ProcessMasterId, int SOrderId, int ProductId, int WarehouseId, DateTime ReceivedDate, decimal ReceivedQty,
          decimal ProcessQty, decimal RejectQty, int TransferWarehouseId, Nullable<DateTime> TransferDate, int StatusId, string Remarks, Smartworks.DAL customedataAcess = null)
        {
            int Id = -1;
            Smartworks.ColumnField[] iuProcessDetail = new Smartworks.ColumnField[13];
            iuProcessDetail[0] = new Smartworks.ColumnField("@ProcessDetailId", ProcessDetailId);
            iuProcessDetail[1] = new Smartworks.ColumnField("@ProcessMasterId", ProcessMasterId);
            iuProcessDetail[2] = new Smartworks.ColumnField("@SOrderId", SOrderId);
            iuProcessDetail[3] = new Smartworks.ColumnField("@ProductId", ProductId);
            iuProcessDetail[4] = new Smartworks.ColumnField("@WarehouseId", WarehouseId);
            iuProcessDetail[5] = new Smartworks.ColumnField("@ReceivedDate", ReceivedDate);
            iuProcessDetail[6] = new Smartworks.ColumnField("@ReceivedQty", ReceivedQty);
            iuProcessDetail[7] = new Smartworks.ColumnField("@ProcessQty", ProcessQty);
            iuProcessDetail[8] = new Smartworks.ColumnField("@RejectQty", RejectQty);
            iuProcessDetail[9] = new Smartworks.ColumnField("@TransferWarehouseId", TransferWarehouseId);
            if (TransferDate == null)
            {
                iuProcessDetail[10] = new Smartworks.ColumnField("@TransferDate", DBNull.Value);
            }
            else
            {
                iuProcessDetail[10] = new Smartworks.ColumnField("@TransferDate", TransferDate);
            }

            iuProcessDetail[11] = new Smartworks.ColumnField("@StatusId", StatusId);
            iuProcessDetail[12] = new Smartworks.ColumnField("@Remarks", Remarks);


            if (customedataAcess != null)
            {
                Id = Convert.ToInt32(customedataAcess.ExecuteStoredProcedure("InsertUpdateProcessDetail", iuProcessDetail));
            }
            else
            {
                dataAccess.BeginTransaction();
                Id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("InsertUpdateProcessDetail", iuProcessDetail));
                dataAccess.TransCommit();
            }

            return Id;
        }


        public void DeleteProcessDetailByDetailId(int ProcessDetailId, Smartworks.DAL customdataAcess = null)
        {
            Smartworks.ColumnField[] dProcessDetail = new Smartworks.ColumnField[1];
            dProcessDetail[0] = new Smartworks.ColumnField("@ProcessDetailId", ProcessDetailId);
            if (customdataAcess != null)
            {
                customdataAcess.ExecuteStoredProcedure("dbo.sp_DeleteProcessDetailByDetailId", dProcessDetail);
            }
            else
            {
                dataAccess.BeginTransaction();
                dataAccess.ExecuteStoredProcedure("dbo.sp_DeleteProcessDetailByDetailId", dProcessDetail);
                dataAccess.TransCommit();
            }
        }

        public int DeleteProcessLine(int ProcessMasterId, Smartworks.DAL customdataAcess = null)
        {
            int Id = -1;
            Smartworks.ColumnField[] dProcessline = new Smartworks.ColumnField[1];
            dProcessline[0] = new Smartworks.ColumnField("@ProcessMasterId", ProcessMasterId);
            if (customdataAcess != null)
            {
                Id = Convert.ToInt32(customdataAcess.ExecuteStoredProcedure("dbo.sp_DeleteProcessLine", dProcessline));
            }
            else
            {
                dataAccess.BeginTransaction();
                Id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.sp_DeleteProcessLine", dProcessline));
                dataAccess.TransCommit();
            }
            return Id;
        }


        public decimal GetRemainigQtyByWarehouseAndDate(string SOrderNo, int WarehouseId, Nullable<DateTime> Dated)
        {
            decimal Qty = 0;
            DataTable dt = new DataTable();
            Smartworks.ColumnField[] gRemainQty = new Smartworks.ColumnField[3];
            gRemainQty[0] = new Smartworks.ColumnField("@SOrderNo", SOrderNo);
            gRemainQty[1] = new Smartworks.ColumnField("@WarehouseId", WarehouseId);
            if (Dated == null)
            {
                gRemainQty[2] = new Smartworks.ColumnField("@Date", DBNull.Value);
            }
            else
            {
                gRemainQty[2] = new Smartworks.ColumnField("@Date", Dated);
            }

            dt = dataAccess.getDataTableByStoredProcedure("GetRemainingQtyForProcessLine", gRemainQty);
            if (dt.Rows.Count > 0)
            {
                Qty = Convert.ToDecimal(dt.Rows[0]["FinalQty"].ToString());
            }

            return Qty;
        }

        public decimal GetProcessingQtyBalance(int ProductId, DateTime Dated, int WarehouseId, string SONo, int ArticleId, Smartworks.DAL customdataAcess = null)
        {
            decimal qty = 0;
            DataTable dtQty = new DataTable();
            string qurey = "select dbo.GetProductionBalance('" + ProductId + "','" + Dated + "','" + WarehouseId + "','" + SONo + "', '" + ArticleId + "') as Qty";
            if (customdataAcess != null)
            {
                dtQty = customdataAcess.getDataTable(qurey);
            }
            else
            {
                dtQty = dataAccess.getDataTable(qurey);
            }
            
            if (dtQty.Rows.Count > 0)
            {
                qty = Convert.ToDecimal(dtQty.Rows[0][0]);
            }
            return qty;
        }

        #region Reporting

        public DataTable GetReportProcessing(string Code)
        {
            DataTable dt = null;
            Smartworks.ColumnField[] reportProcess = new Smartworks.ColumnField[1];
            reportProcess[0] = new Smartworks.ColumnField("@Code", Code);
            dt = dataAccess.getDataTableByStoredProcedure("sp_ReportProcessing", reportProcess);
            return dt;
        }
        public DataTable GetReportProcessingSummary(int WarehouseId, int ProductId, string SOrderNo, Nullable<DateTime> FromDate, Nullable<DateTime> ToDate, Nullable<DateTime> AsOnDate)
        {
            DataTable dt = null;
            Smartworks.ColumnField[] reportProcess = new Smartworks.ColumnField[6];

            reportProcess[0] = new Smartworks.ColumnField("@WarehouseId", WarehouseId);
            reportProcess[1] = new Smartworks.ColumnField("@ProductId", ProductId);
            reportProcess[2] = new Smartworks.ColumnField("@SOrderNo", SOrderNo);

            if (FromDate == null)
            {
                reportProcess[3] = new Smartworks.ColumnField("@FromDate", DBNull.Value);
            }
            else
            {
                reportProcess[3] = new Smartworks.ColumnField("@FromDate", FromDate);
            }

            if (ToDate == null)
            {
                reportProcess[4] = new Smartworks.ColumnField("@ToDate", DBNull.Value);
            }
            else
            {
                reportProcess[4] = new Smartworks.ColumnField("@ToDate", ToDate);
            }

            if (AsOnDate == null)
            {
                reportProcess[5] = new Smartworks.ColumnField("@AsOnDate", DBNull.Value);
            }
            else
            {
                reportProcess[5] = new Smartworks.ColumnField("@AsOnDate", AsOnDate);
            }

            dt = dataAccess.getDataTableByStoredProcedure("sp_ReportProcessingSummary", reportProcess);
            return dt;
        }

        public DataTable GetReportProcessingSummaryMerge(Nullable<DateTime> FromDate, Nullable<DateTime> ToDate)
        {
            DataTable dt = null;
            Smartworks.ColumnField[] reportProcess = new Smartworks.ColumnField[2];

            if (FromDate == null)
            {
                reportProcess[0] = new Smartworks.ColumnField("@FromDate", DBNull.Value);
            }
            else
            {
                reportProcess[0] = new Smartworks.ColumnField("@FromDate", FromDate);
            }

            if (ToDate == null)
            {
                reportProcess[1] = new Smartworks.ColumnField("@ToDate", DBNull.Value);
            }
            else
            {
                reportProcess[1] = new Smartworks.ColumnField("@ToDate", ToDate);
            }



            dt = dataAccess.getDataTableByStoredProcedure("sp_ReportProcessingSummaryMerge", reportProcess);
            return dt;
        }

        #endregion

        #region Navigation

        public string GetMinInvioceNo()
        {
            string InvoiceNo = "";
            DataTable dt = new DataTable();

            dt = dataAccess.getDataTable("select min(Code) as 'InvoiceNo' from ProcessMaster");
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

            dt = dataAccess.getDataTable("select max(Code) as 'InvoiceNo' from ProcessMaster");
            if (dt.Rows.Count > 0)
            {
                InvoiceNo = dt.Rows[0]["InvoiceNo"].ToString();
            }
            return InvoiceNo;
        }


        public string GetNextInvioceNo(string Code)
        {
            string InvoiceNo = "";
            try
            {
                DataTable dt = new DataTable();
                dt = dataAccess.getDataTable("Select dbo.GetNextNumber('" + Code + "') as InvoiceNo ");
                if (dt.Rows.Count > 0)
                {
                    InvoiceNo = (string)dt.Rows[0]["InvoiceNo"].ToString();
                }
                return InvoiceNo;
            }
            catch (Exception ex)
            {
                InvoiceNo = "";
            }
            return InvoiceNo;

        }

        public string GetPrevInvioceNo(string Code)
        {
            string InvoiceNo = "";
            try
            {
                DataTable dt = new DataTable();
                dt = dataAccess.getDataTable("Select dbo.GetPreviousNumber('" + Code + "') as InvoiceNo");
                if (dt.Rows.Count > 0)
                {
                    InvoiceNo = (string)dt.Rows[0]["InvoiceNo"].ToString();
                }
                return InvoiceNo;
            }
            catch (Exception ex)
            {
                InvoiceNo = "";
            }
            return InvoiceNo;
        }


        #endregion



        #region Production Ledger

        public int InsertProductionLedger(int WarehouseId, int ProductId, int ColorId, string SONo, Nullable<DateTime> Date, string TransNo,
          int TranDetailId, string FlagInOut, decimal Quantity, int SizeId, string Remarks, bool IsReject, Smartworks.DAL customedataAcess)
        {
            int Id = -1;

            Smartworks.ColumnField[] iuProductionLedger = new Smartworks.ColumnField[12];
            iuProductionLedger[0] = new Smartworks.ColumnField("@WarehouseId", WarehouseId);
            iuProductionLedger[1] = new Smartworks.ColumnField("@ProductId", ProductId);
            iuProductionLedger[2] = new Smartworks.ColumnField("@ColorId", ColorId);
            iuProductionLedger[3] = new Smartworks.ColumnField("@SONo", SONo);
            iuProductionLedger[4] = new Smartworks.ColumnField("@Date", Date);
            iuProductionLedger[5] = new Smartworks.ColumnField("@TransNo", TransNo);
            iuProductionLedger[6] = new Smartworks.ColumnField("@TranDetailId", TranDetailId);
            iuProductionLedger[7] = new Smartworks.ColumnField("@FlagInOut", FlagInOut);
            iuProductionLedger[8] = new Smartworks.ColumnField("@Quantity", Quantity);
            iuProductionLedger[9] = new Smartworks.ColumnField("@SizeId", SizeId);
            iuProductionLedger[10] = new Smartworks.ColumnField("@Remarks", Remarks);
            iuProductionLedger[11] = new Smartworks.ColumnField("@IsReject", IsReject);

            if (customedataAcess != null)
            {
                Id = Convert.ToInt32(customedataAcess.ExecuteStoredProcedure("InsertProductionLedger", iuProductionLedger));
            }
            else
            {
                dataAccess.BeginTransaction();
                Id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("InsertProductionLedger", iuProductionLedger));
                dataAccess.TransCommit();
            }

            return Id;
        }

        public int InsertUpdateProductionLedger(int WarehouseId, int ProductId, int ColorId, string SONo, Nullable<DateTime> Date, string TransNo,
            int TranDetailId, string FlagInOut, decimal Quantity, int SizeId, string Remarks, bool IsReject, Smartworks.DAL customedataAcess)
        {
            int Id = -1;

            Smartworks.ColumnField[] iuProductionLedger = new Smartworks.ColumnField[12];
            iuProductionLedger[0] = new Smartworks.ColumnField("@WarehouseId", WarehouseId);
            iuProductionLedger[1] = new Smartworks.ColumnField("@ProductId", ProductId);
            iuProductionLedger[2] = new Smartworks.ColumnField("@ColorId", ColorId);
            iuProductionLedger[3] = new Smartworks.ColumnField("@SONo", SONo);
            iuProductionLedger[4] = new Smartworks.ColumnField("@Date", Date);
            iuProductionLedger[5] = new Smartworks.ColumnField("@TransNo", TransNo);
            iuProductionLedger[6] = new Smartworks.ColumnField("@TranDetailId", TranDetailId);
            iuProductionLedger[7] = new Smartworks.ColumnField("@FlagInOut", FlagInOut);
            iuProductionLedger[8] = new Smartworks.ColumnField("@Quantity", Quantity);
            iuProductionLedger[9] = new Smartworks.ColumnField("@SizeId", SizeId);
            iuProductionLedger[10] = new Smartworks.ColumnField("@Remarks", Remarks);
            iuProductionLedger[11] = new Smartworks.ColumnField("@IsReject", IsReject);

            if (customedataAcess != null)
            {
                Id = Convert.ToInt32(customedataAcess.ExecuteStoredProcedure("InsertUpdateProductionLedger", iuProductionLedger));
            }
            else
            {
                dataAccess.BeginTransaction();
                Id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("InsertUpdateProductionLedger", iuProductionLedger));
                dataAccess.TransCommit();
            }

            return Id;
        }


        //public void DeleteProductionLedgerByTransNoAndDetailId(string TransNo, int DetailId, Smartworks.DAL customdataAccess = null)
        //{
        //    Smartworks.ColumnField[] dProductionLedger = new Smartworks.ColumnField[2];
        //    dProductionLedger[0] = new Smartworks.ColumnField("@TransNo", TransNo);
        //    dProductionLedger[1] = new Smartworks.ColumnField("@DetailId", DetailId);
        //    if (customdataAccess != null)
        //    {
        //        customdataAccess.ExecuteStoredProcedure("dbo.sp_DeleteProductionLedgerByTransNo", dProductionLedger);
        //    }
        //    else
        //    {
        //        dataAccess.BeginTransaction();
        //        dataAccess.ExecuteStoredProcedure("dbo.sp_DeleteProductionLedgerByTransNo", dProductionLedger);
        //        dataAccess.TransCommit();
        //    }

        //}

        public void DeleteProductionLedgerByTransNo(string TransNo, Smartworks.DAL customdataAccess = null)
        {
            Smartworks.ColumnField[] dProductionLedger = new Smartworks.ColumnField[1];
            dProductionLedger[0] = new Smartworks.ColumnField("@TransNo", TransNo);
            if (customdataAccess != null)
            {
                customdataAccess.ExecuteStoredProcedure("dbo.sp_DeleteProductionLedgerByTransNo", dProductionLedger);
            }
            else
            {
                dataAccess.BeginTransaction();
                dataAccess.ExecuteStoredProcedure("dbo.sp_DeleteProductionLedgerByTransNo", dProductionLedger);
                dataAccess.TransCommit();
            }

        }

        public void DeleteProductionLedgerByTransNo(string TransNo, bool IsAllYear , Smartworks.DAL customdataAccess = null)
        {
            Smartworks.ColumnField[] dProductionLedger = new Smartworks.ColumnField[1];
            dProductionLedger[0] = new Smartworks.ColumnField("@TransNo", TransNo);
            if (customdataAccess != null)
            {
                if (IsAllYear)
                {
                    customdataAccess.ExecuteStoredProcedure("dbo.sp_DeleteProductionLedgerByTransNoAllYear", dProductionLedger);
                }
                else
                {
                    customdataAccess.ExecuteStoredProcedure("dbo.sp_DeleteProductionLedgerByTransNo", dProductionLedger);
                }
                
            }
            else
            {
                dataAccess.BeginTransaction();
                if (IsAllYear)
                {
                    dataAccess.ExecuteStoredProcedure("dbo.sp_DeleteProductionLedgerByTransNoAllYear", dProductionLedger);
                }
                else
                {
                    dataAccess.ExecuteStoredProcedure("dbo.sp_DeleteProductionLedgerByTransNo", dProductionLedger);
                }
                
                dataAccess.TransCommit();
            }

        }


        #region reporting
        public DataTable GetProcessLedgerReport(Nullable<DateTime> FromDate, Nullable<DateTime> ToDate, string FromCode, string ToCode, int CategoryId, int WarehouseId)
        {

            DataTable dt = new DataTable();
            Smartworks.ColumnField[] report = new Smartworks.ColumnField[6];
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

            report[2] = new Smartworks.ColumnField("@FromProductCode", FromCode);
            report[3] = new Smartworks.ColumnField("@ToProductCode", ToCode);
            report[4] = new Smartworks.ColumnField("@CategoryId", CategoryId);
            report[5] = new Smartworks.ColumnField("@WarehouseId", WarehouseId);


            dt = dataAccess.getDataTableByStoredProcedure("sp_ReportProcessLedger", report);
            return dt;
        }
        #endregion



        #endregion
    }
}

