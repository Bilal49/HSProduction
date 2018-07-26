using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;

namespace FIL
{
    public class ProductionManager 
    {
        Smartworks.DAL dataAccess = new Smartworks.DAL();
        public ProductionManager()
        {

            string connString = ConfigurationManager.ConnectionStrings["HSConnectionString"].ConnectionString;
            Smartworks.DAL.ConnectionString = connString;
        }

        #region Production Status
        public int InsertProductionStatus(string ProductionStatus, int AddedBy, DateTime AddedOn,
                                    string AddedIpAddr)
        {
            int id = 0;

            Smartworks.ColumnField[] iProductionStatus = new Smartworks.ColumnField[4];
            iProductionStatus[0] = new Smartworks.ColumnField("@ProductionStatus", ProductionStatus);
            iProductionStatus[1] = new Smartworks.ColumnField("@AddedBy", AddedBy);
            iProductionStatus[2] = new Smartworks.ColumnField("@AddedOn", AddedOn);
            iProductionStatus[3] = new Smartworks.ColumnField("@AddedIpAddr", AddedIpAddr);
            dataAccess.BeginTransaction();
            id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.InsertProductionStatus", iProductionStatus));
            dataAccess.TransCommit();
            return id;

        }

        public void UpdateProductionStatus(int ProductionStatusId, string ProductionStatus, int UpdatedBy, DateTime UpdatedOn, string UpdatedIpAddr)
        {
            Smartworks.ColumnField[] uProductionStatusCatagory = new Smartworks.ColumnField[5];
            uProductionStatusCatagory[0] = new Smartworks.ColumnField("@ProductionStatusId", ProductionStatusId);
            uProductionStatusCatagory[1] = new Smartworks.ColumnField("@ProductionStatus", ProductionStatus);
            uProductionStatusCatagory[2] = new Smartworks.ColumnField("@UpdatedBy", UpdatedBy);
            uProductionStatusCatagory[3] = new Smartworks.ColumnField("@UpdatedOn", UpdatedOn);
            uProductionStatusCatagory[4] = new Smartworks.ColumnField("@UpdatedIpAddr", UpdatedIpAddr);

            dataAccess.BeginTransaction();
            dataAccess.ExecuteStoredProcedure("dbo.UpdateProductionStatus", uProductionStatusCatagory);
            dataAccess.TransCommit();
        }


        public int DeleteProductionStatus(string ProductionStatusId)
        {
            int id;

            Smartworks.ColumnField[] dProductionStatus = new Smartworks.ColumnField[1];
            dProductionStatus[0] = new Smartworks.ColumnField("@ProductionStatusId", ProductionStatusId);
            dataAccess.BeginTransaction();
            id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.DeleteProductionStatus", dProductionStatus));
            dataAccess.TransCommit();
            return id;
        }
        public DataTable GetAllProductionStatus()
        {
            return dataAccess.getDataTable("select ProductionStatusId , ProductionStatus from ProductionStatus");
        }
        public DataTable GetProductionStatus(int ProductionStatusId)
        {

            DataTable dt;
            dt = dataAccess.getDataTable("Select * from ProductionStatus where ProductionStatusId  =" + ProductionStatusId);
            return dt;
        }

        public DataTable GetProductionStatusList()
        {
            DataTable dt = new DataTable();
            dt = dataAccess.getDataTable("Select ProductionStatusId , upper(left(ProductionStatus, 1)) + right(ProductionStatus, len(ProductionStatus) - 1) as ProductionStatus  from ProductionStatus Order by ProductionStatus ");
            return dt;
        }

        public int GetProductionStatusIdById(int Id)
        {
            int ProductionStatusId = -1;
            DataTable dt = new DataTable();
            dt = dataAccess.getDataTable("Select ProductionStatusId from ProductionStatus where ProductionStatusId= '" + Id + "' ");
            if (dt.Rows.Count > 0)
            {
                ProductionStatusId = (int)dt.Rows[0]["ProductionStatusId"];
            }
            return ProductionStatusId;
        }
        #endregion


        #region Production


        public DataSet GetProductionStructure(int PMId)
        {
            DataSet ds = new DataSet();
            Smartworks.ColumnField[] gProduction = new Smartworks.ColumnField[1];
            gProduction[0] = new Smartworks.ColumnField("@PMId", PMId);
            ds = dataAccess.getDataSetByStoredProcedure("sp_GetProductionStructure", gProduction);
            return ds;
        }

        public DataTable InsertProductionMaster(DateTime Date, int ProductId, decimal ProcessQty, string Construction, string BatchNo,
            int LastNoId, string SizeRange, string ModelSize, int PFMId, int StatusId, int WarehouseId, string SOrderNo, string Remarks ,
            bool Posted, int TransferWarehouseId , int S39 , int S40, int S41, int S42, int S43, int S44, int S45, int S46, int S47 ,
             int A39, int A40, int A41, int A42, int A43, int A44, int A45, int A46, int A47,  int AddedBy, 
            DateTime AddedOn, string AddedIPAddr , int ToWarehouseId  , decimal ActualQty ,   DateTime ProcessDate , bool IsCompleteStage ,  Smartworks.DAL customedataAcess = null)
        {
            DataTable dt = null;

            Smartworks.ColumnField[] iProductionMaster = new Smartworks.ColumnField[40];
            iProductionMaster[0] = new Smartworks.ColumnField("@Date", Date);
            iProductionMaster[1] = new Smartworks.ColumnField("@ProductId", ProductId);
            iProductionMaster[2] = new Smartworks.ColumnField("@ProcessQty", ProcessQty);
            iProductionMaster[3] = new Smartworks.ColumnField("@Construction", Construction);
            iProductionMaster[4] = new Smartworks.ColumnField("@BatchNo", BatchNo);
            iProductionMaster[5] = new Smartworks.ColumnField("@LastNoId", LastNoId);
            iProductionMaster[6] = new Smartworks.ColumnField("@SizeRange", SizeRange);
            iProductionMaster[7] = new Smartworks.ColumnField("@ModelSize", ModelSize);
            iProductionMaster[8] = new Smartworks.ColumnField("@PFMId", PFMId);
            iProductionMaster[9] = new Smartworks.ColumnField("@StatusId", StatusId);
            iProductionMaster[10] = new Smartworks.ColumnField("@WarehouseId", WarehouseId);
            iProductionMaster[11] = new Smartworks.ColumnField("@SOrderNo", SOrderNo);
            iProductionMaster[12] = new Smartworks.ColumnField("@Remarks", Remarks);
            iProductionMaster[13] = new Smartworks.ColumnField("@Posted", Posted);
            iProductionMaster[14] = new Smartworks.ColumnField("@TransferWarehouseId", TransferWarehouseId);

            iProductionMaster[15] = new Smartworks.ColumnField("@S39", S39);
            iProductionMaster[16] = new Smartworks.ColumnField("@S40", S40);
            iProductionMaster[17] = new Smartworks.ColumnField("@S41", S41);
            iProductionMaster[18] = new Smartworks.ColumnField("@S42", S42);
            iProductionMaster[19] = new Smartworks.ColumnField("@S43", S43);
            iProductionMaster[20] = new Smartworks.ColumnField("@S44", S44);
            iProductionMaster[21] = new Smartworks.ColumnField("@S45", S45);
            iProductionMaster[22] = new Smartworks.ColumnField("@S46", S46);
            iProductionMaster[23] = new Smartworks.ColumnField("@S47", S47);

            iProductionMaster[24] = new Smartworks.ColumnField("@A39", A39);
            iProductionMaster[25] = new Smartworks.ColumnField("@A40", A40);
            iProductionMaster[26] = new Smartworks.ColumnField("@A41", A41);
            iProductionMaster[27] = new Smartworks.ColumnField("@A42", A42);
            iProductionMaster[28] = new Smartworks.ColumnField("@A43", A43);
            iProductionMaster[29] = new Smartworks.ColumnField("@A44", A44);
            iProductionMaster[30] = new Smartworks.ColumnField("@A45", A45);
            iProductionMaster[31] = new Smartworks.ColumnField("@A46", A46);
            iProductionMaster[32] = new Smartworks.ColumnField("@A47", A47);
            
            iProductionMaster[33] = new Smartworks.ColumnField("@AddedBy", AddedBy);
            iProductionMaster[34] = new Smartworks.ColumnField("@AddedOn", AddedOn);
            iProductionMaster[35] = new Smartworks.ColumnField("@AddedIPAddr", AddedIPAddr);

            iProductionMaster[36] = new Smartworks.ColumnField("@ToWarehouseId", ToWarehouseId);
            iProductionMaster[37] = new Smartworks.ColumnField("@ActualQty", ActualQty);
            iProductionMaster[38] = new Smartworks.ColumnField("@ProcessDate", ProcessDate);
            iProductionMaster[39] = new Smartworks.ColumnField("@IsCompleteStage", IsCompleteStage);




            if (customedataAcess != null)
            {
                dt = customedataAcess.getDataTableByStoredProcedure("InsertProductionMaster", iProductionMaster);
            }
            else
            {
                dataAccess.BeginTransaction();
                dt = dataAccess.getDataTableByStoredProcedure("InsertProductionMaster", iProductionMaster);
                dataAccess.TransCommit();
            }

            return dt;
        }


        public void UpdateProductionMaster(int PMID , DateTime Date, int ProductId, decimal ProcessQty, string Construction, string BatchNo,
           int LastNoId, string SizeRange, string ModelSize, int PFMId, int StatusId, int WarehouseId, string SOrderNo, string Remarks,
           bool Posted, int TransferWarehouseId, int S39, int S40, int S41, int S42, int S43, int S44, int S45, int S46, int S47 ,
            int A39, int A40, int A41, int A42, int A43, int A44, int A45, int A46, int A47,
            int AddedBy, DateTime AddedOn, string AddedIPAddr, int ToWarehouseId, decimal ActualQty, DateTime ProcessDate, bool IsCompleteStage, Smartworks.DAL customedataAcess = null)
        {
            int Id = -1;

            Smartworks.ColumnField[] uProductionMaster = new Smartworks.ColumnField[41];
            uProductionMaster[0] = new Smartworks.ColumnField("@PMID", PMID);
            uProductionMaster[1] = new Smartworks.ColumnField("@Date", Date);
            uProductionMaster[2] = new Smartworks.ColumnField("@ProductId", ProductId);
            uProductionMaster[3] = new Smartworks.ColumnField("@ProcessQty", ProcessQty);
            uProductionMaster[4] = new Smartworks.ColumnField("@Construction", Construction);
            uProductionMaster[5] = new Smartworks.ColumnField("@BatchNo", BatchNo);
            uProductionMaster[6] = new Smartworks.ColumnField("@LastNoId", LastNoId);
            uProductionMaster[7] = new Smartworks.ColumnField("@SizeRange", SizeRange);
            uProductionMaster[8] = new Smartworks.ColumnField("@ModelSize", ModelSize);
            uProductionMaster[9] = new Smartworks.ColumnField("@PFMId", PFMId);
            uProductionMaster[10] = new Smartworks.ColumnField("@StatusId", StatusId);
            uProductionMaster[11] = new Smartworks.ColumnField("@WarehouseId", WarehouseId);
            uProductionMaster[12] = new Smartworks.ColumnField("@SOrderNo", SOrderNo);
            uProductionMaster[13] = new Smartworks.ColumnField("@Remarks", Remarks);
            uProductionMaster[14] = new Smartworks.ColumnField("@Posted", Posted);
            uProductionMaster[15] = new Smartworks.ColumnField("@TransferWarehouseId", TransferWarehouseId);

            uProductionMaster[16] = new Smartworks.ColumnField("@S39", S39);
            uProductionMaster[17] = new Smartworks.ColumnField("@S40", S40);
            uProductionMaster[18] = new Smartworks.ColumnField("@S41", S41);
            uProductionMaster[19] = new Smartworks.ColumnField("@S42", S42);
            uProductionMaster[20] = new Smartworks.ColumnField("@S43", S43);
            uProductionMaster[21] = new Smartworks.ColumnField("@S44", S44);
            uProductionMaster[22] = new Smartworks.ColumnField("@S45", S45);
            uProductionMaster[23] = new Smartworks.ColumnField("@S46", S46);
            uProductionMaster[24] = new Smartworks.ColumnField("@S47", S47);

            uProductionMaster[25] = new Smartworks.ColumnField("@A39", A39);
            uProductionMaster[26] = new Smartworks.ColumnField("@A40", A40);
            uProductionMaster[27] = new Smartworks.ColumnField("@A41", A41);
            uProductionMaster[28] = new Smartworks.ColumnField("@A42", A42);
            uProductionMaster[29] = new Smartworks.ColumnField("@A43", A43);
            uProductionMaster[30] = new Smartworks.ColumnField("@A44", A44);
            uProductionMaster[31] = new Smartworks.ColumnField("@A45", A45);
            uProductionMaster[32] = new Smartworks.ColumnField("@A46", A46);
            uProductionMaster[33] = new Smartworks.ColumnField("@A47", A47);

            uProductionMaster[34] = new Smartworks.ColumnField("@AddedBy", AddedBy);
            uProductionMaster[35] = new Smartworks.ColumnField("@AddedOn", AddedOn);
            uProductionMaster[36] = new Smartworks.ColumnField("@AddedIPAddr", AddedIPAddr);

            uProductionMaster[37] = new Smartworks.ColumnField("@ToWarehouseId", ToWarehouseId);
            uProductionMaster[38] = new Smartworks.ColumnField("@ActualQty", ActualQty);
            uProductionMaster[39] = new Smartworks.ColumnField("@ProcessDate", ProcessDate);
            uProductionMaster[40] = new Smartworks.ColumnField("@IsCompleteStage", IsCompleteStage);

            if (customedataAcess != null)
            {
                customedataAcess.ExecuteStoredProcedure("UpdateProductionMaster", uProductionMaster);
            }
            else
            {
                dataAccess.BeginTransaction();
                dataAccess.ExecuteStoredProcedure("UpdateProductionMaster", uProductionMaster);
                dataAccess.TransCommit();
            }
        }


        public int InsertUpdateProductionDetail(int PDId , int PMId , int ProductId , int ActualProductId , int WarehouseId , int UnitId ,
            int ColorId, decimal AssumeQty, decimal AvailableQty, decimal ConsumeQty, decimal BalanceQty, decimal Rate, decimal Amount, string Remarks, Smartworks.DAL customedataAcess = null)
        {
            int Id = -1;

            Smartworks.ColumnField[] iProductionDetail = new Smartworks.ColumnField[14];
            iProductionDetail[0] = new Smartworks.ColumnField("@PDId", PDId);
            iProductionDetail[1] = new Smartworks.ColumnField("@PMId", PMId);
            iProductionDetail[2] = new Smartworks.ColumnField("@ProductId", ProductId);
            iProductionDetail[3] = new Smartworks.ColumnField("@ActualProductId", ActualProductId);
            iProductionDetail[4] = new Smartworks.ColumnField("@WarehouseId", WarehouseId);
            iProductionDetail[5] = new Smartworks.ColumnField("@UnitId", UnitId);
            iProductionDetail[6] = new Smartworks.ColumnField("@ColorId", ColorId);
            iProductionDetail[7] = new Smartworks.ColumnField("@AssumeQty", AssumeQty);
            iProductionDetail[8] = new Smartworks.ColumnField("@AvailableQty", AvailableQty);
            iProductionDetail[9] = new Smartworks.ColumnField("@ConsumeQty", ConsumeQty);
            iProductionDetail[10] = new Smartworks.ColumnField("@BalanceQty", BalanceQty);
            iProductionDetail[11] = new Smartworks.ColumnField("@Rate", Rate);
            iProductionDetail[12] = new Smartworks.ColumnField("@Amount", Amount);
            iProductionDetail[13] = new Smartworks.ColumnField("@Remarks", Remarks);

            if (customedataAcess != null)
            {
                Id = Convert.ToInt32(customedataAcess.ExecuteStoredProcedure("InsertUpdateProductionDetail", iProductionDetail));
            }
            else
            {
                dataAccess.BeginTransaction();
                Id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("InsertUpdateProductionDetail", iProductionDetail));
                dataAccess.TransCommit();
            }

            return Id;
        }


        public int InsertUpdateProductionSubDetail(int SubDetailId, int PMId, int SOrderId, int ProductId, int WarehouseId, DateTime ReceivedDate,
         decimal ProcessQty, int TransferWarehouseId, Nullable<DateTime> TransferDate, int StatusId, string Remarks, Smartworks.DAL customedataAcess = null)
        {
            int Id = -1;
            Smartworks.ColumnField[] iuProcessDetail = new Smartworks.ColumnField[11];
            iuProcessDetail[0] = new Smartworks.ColumnField("@SubDetailId", SubDetailId);
            iuProcessDetail[1] = new Smartworks.ColumnField("@PMId", PMId);
            iuProcessDetail[2] = new Smartworks.ColumnField("@SOrderId", SOrderId);
            iuProcessDetail[3] = new Smartworks.ColumnField("@ProductId", ProductId);
            iuProcessDetail[4] = new Smartworks.ColumnField("@WarehouseId", WarehouseId);
            iuProcessDetail[5] = new Smartworks.ColumnField("@ReceivedDate", ReceivedDate);
            iuProcessDetail[6] = new Smartworks.ColumnField("@ProcessQty", ProcessQty);
            iuProcessDetail[7] = new Smartworks.ColumnField("@TransferWarehouseId", TransferWarehouseId);

            if (TransferDate == null)
            {
                iuProcessDetail[8] = new Smartworks.ColumnField("@TransferDate", DBNull.Value);
            }
            else
            {
                iuProcessDetail[8] = new Smartworks.ColumnField("@TransferDate", TransferDate);
            }

            iuProcessDetail[9] = new Smartworks.ColumnField("@StatusId", StatusId);
            iuProcessDetail[10] = new Smartworks.ColumnField("@Remarks", Remarks);


            if (customedataAcess != null)
            {
                Id = Convert.ToInt32(customedataAcess.ExecuteStoredProcedure("InsertUpdateProductionSubDetail", iuProcessDetail));
            }
            else
            {
                dataAccess.BeginTransaction();
                Id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("InsertUpdateProductionSubDetail", iuProcessDetail));
                dataAccess.TransCommit();
            }

            return Id;
        }
        public void POSTProduction(int PMId, int AddedBy , DateTime AddedOn , string AddedIpAddr ,   Smartworks.DAL customedataAcess = null)
        {
            Smartworks.ColumnField[] pProduction = new Smartworks.ColumnField[4];
            pProduction[0] = new Smartworks.ColumnField("@PMId", PMId);
            pProduction[1] = new Smartworks.ColumnField("@AddedBy", AddedBy);
            pProduction[2] = new Smartworks.ColumnField("@AddedOn", AddedOn);
            pProduction[3] = new Smartworks.ColumnField("@AddedIpAddr", AddedIpAddr);

            if (customedataAcess != null)
            {
                customedataAcess.ExecuteStoredProcedure("sp_PostProduction", pProduction);
            }
            else
            {
                dataAccess.BeginTransaction();
                dataAccess.ExecuteStoredProcedure("sp_PostProduction", pProduction);
                dataAccess.TransCommit();
            }

        }


        public void UNPOSTProduction(int PMId, int AddedBy, DateTime AddedOn, string AddedIpAddr, Smartworks.DAL customedataAcess = null)
        {
            Smartworks.ColumnField[] pProduction = new Smartworks.ColumnField[4];
            pProduction[0] = new Smartworks.ColumnField("@PMId", PMId);
            pProduction[1] = new Smartworks.ColumnField("@AddedBy", AddedBy);
            pProduction[2] = new Smartworks.ColumnField("@AddedOn", AddedOn);
            pProduction[3] = new Smartworks.ColumnField("@AddedIpAddr", AddedIpAddr);

            if (customedataAcess != null)
            {
                customedataAcess.ExecuteStoredProcedure("sp_UNPostProduction", pProduction);
            }
            else
            {
                dataAccess.BeginTransaction();
                dataAccess.ExecuteStoredProcedure("sp_PostProduction", pProduction);
                dataAccess.TransCommit();
            }

        }

        public DataTable GetProductionDetailByMasterId(int PMId , int WarehouseId )
        {
            string qurey = "select * from ProductionDetail where PMId ='" + PMId + "' ";
            if (WarehouseId > 0)
            {
                qurey = qurey + " and WarehouseId = '" + WarehouseId + "' ";
            }
            return dataAccess.getDataTable(qurey);
        }

        public int GetProductionIdByCode(string Code)
        {
            int Id = -1;
            DataTable dt = new DataTable();
            dt = dataAccess.getDataTable("Select PMId from ProductionMaster where Code = '" + Code + "' ");
            if (dt.Rows.Count > 0)
            {
                Id = Convert.ToInt32(dt.Rows[0]["PMId"].ToString());
            }
            return Id;
        }



        public DataTable GetReportProductionStatus(Nullable<DateTime> FromDate, Nullable<DateTime> ToDate)
        {
            DataTable dtReport = new DataTable();
            Smartworks.ColumnField[] rPOrder = new Smartworks.ColumnField[2];
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

            dtReport = dataAccess.getDataTableByStoredProcedure("dbo.sp_ReportProductionStatus", rPOrder);
            return dtReport;
        }


        #region Navigation

        public string GetMinInvioceNo()
        {
            string InvoiceNo = "";
            DataTable dt = new DataTable();

            dt = dataAccess.getDataTable("select min(Code) as 'InvoiceNo' from ProductionMaster");
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

            dt = dataAccess.getDataTable("select max(Code) as 'InvoiceNo' from ProductionMaster");
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
        public DataTable GetProductionReportBySOandFinishProductId(string SOrderNo, int FinishProductId, string ProductionCode)
        {
            DataTable dt = new DataTable();
            Smartworks.ColumnField[] rProduction = new Smartworks.ColumnField[3];
            rProduction[0] = new Smartworks.ColumnField("@SOrderNo", SOrderNo);
            rProduction[1] = new Smartworks.ColumnField("@FinishProductId", FinishProductId);
            rProduction[2] = new Smartworks.ColumnField("@ProductionCode", ProductionCode);
            dt = dataAccess.getDataTableByStoredProcedure("sp_ReportProductionProcessWithAmount", rProduction);
            return dt;
        }
        #endregion

        #endregion

    }
}

