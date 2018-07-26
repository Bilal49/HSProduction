using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;

namespace FIL.App_Code.VoucherMananger
{
    public class VoucherManager
    {
        Smartworks.DAL dataAccess = new Smartworks.DAL();
        public VoucherManager()
        {
            string connString = ConfigurationManager.ConnectionStrings["HSConnectionString"].ConnectionString;
            Smartworks.DAL.ConnectionString = connString;
        }


        public DataSet GetVoucherStructure(int VoucherMasterId)
        {
            DataSet ds = new DataSet();
            Smartworks.ColumnField[] gVouchar = new Smartworks.ColumnField[1];
            gVouchar[0] = new Smartworks.ColumnField("@VoucherMasterId", VoucherMasterId);

            ds = dataAccess.getDataSetByStoredProcedure("sp_GetAccountStructure", gVouchar);
            return ds;
        }

        public DataTable InsertVoucharMaster(DateTime Date, string VoucherType,
                                   string BranchCode, string Narration, decimal TotalDebit, decimal TotalCredit,
                                   int AddedBy, DateTime AddedOn, string AddedIpAddr, Smartworks.DAL customdataAcess = null)
        {
            DataTable dt = new DataTable();
            Smartworks.ColumnField[] iVoucharMaster = new Smartworks.ColumnField[9];
            iVoucharMaster[0] = new Smartworks.ColumnField("@Date", Date);
            iVoucharMaster[1] = new Smartworks.ColumnField("@VoucherType", VoucherType);
            iVoucharMaster[2] = new Smartworks.ColumnField("@BranchCode", BranchCode);
            iVoucharMaster[3] = new Smartworks.ColumnField("@Narration", Narration);
            iVoucharMaster[4] = new Smartworks.ColumnField("@TotalDebit", TotalDebit);
            iVoucharMaster[5] = new Smartworks.ColumnField("@TotalCredit", TotalCredit);
            iVoucharMaster[6] = new Smartworks.ColumnField("@AddedBy", AddedBy);
            iVoucharMaster[7] = new Smartworks.ColumnField("@AddedOn", AddedOn);
            iVoucharMaster[8] = new Smartworks.ColumnField("@AddedIpAddr", AddedIpAddr);
            if (customdataAcess != null)
            {
                dt = customdataAcess.getDataTableByStoredProcedure("dbo.InsertVoucharMaster", iVoucharMaster);

            }
            else
            {
                dataAccess.BeginTransaction();
                dt = dataAccess.getDataTableByStoredProcedure("dbo.InsertVoucharMaster", iVoucharMaster);
                dataAccess.TransCommit();
            }

            return dt;

        }



        public void UpdateVoucharMaster(int VoucherMasterId, DateTime Date, string VoucherType,
                                 string BranchCode, string Narration, decimal TotalDebit, decimal TotalCredit
                                , int UpdatedBy, DateTime UpdatedOn, string UpdatedIpAddr, Smartworks.DAL customdataAccess = null)
        {
            Smartworks.ColumnField[] uVoucharMaster = new Smartworks.ColumnField[10];
            uVoucharMaster[0] = new Smartworks.ColumnField("@VoucherMasterId", VoucherMasterId);
            uVoucharMaster[1] = new Smartworks.ColumnField("@Date", Date);
            uVoucharMaster[2] = new Smartworks.ColumnField("@VoucherType", VoucherType);
            uVoucharMaster[3] = new Smartworks.ColumnField("@BranchCode", BranchCode);
            uVoucharMaster[4] = new Smartworks.ColumnField("@Narration", Narration);
            uVoucharMaster[5] = new Smartworks.ColumnField("@TotalDebit", TotalDebit);
            uVoucharMaster[6] = new Smartworks.ColumnField("@TotalCredit", TotalCredit);
            uVoucharMaster[7] = new Smartworks.ColumnField("@UpdatedBy", UpdatedBy);
            uVoucharMaster[8] = new Smartworks.ColumnField("@UpdatedOn", UpdatedOn);
            uVoucharMaster[9] = new Smartworks.ColumnField("@UpdatedIpAddr", UpdatedIpAddr);

            if (customdataAccess != null)
            {
                customdataAccess.ExecuteStoredProcedure("dbo.UpdateVoucharMaster", uVoucharMaster);
            }
            else
            {
                dataAccess.BeginTransaction();
                dataAccess.ExecuteStoredProcedure("dbo.UpdateVoucharMaster", uVoucharMaster);
                dataAccess.TransCommit();
            }

        }


        public int DeleteVoucharMaster(int VoucherMasterId, Smartworks.DAL customdataAcess = null)
        {
            int id;
            Smartworks.ColumnField[] dVoucherMaster = new Smartworks.ColumnField[1];
            dVoucherMaster[0] = new Smartworks.ColumnField("@VoucherMasterId", VoucherMasterId);
            if (customdataAcess != null)
            {
                id = Convert.ToInt32(customdataAcess.ExecuteStoredProcedure("dbo.DeleteVoucherMaster", dVoucherMaster));
            }
            else
            {
                dataAccess.BeginTransaction();
                id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.DeleteVoucherMaster", dVoucherMaster));
                dataAccess.TransCommit();
            }

            return id;
        }

        public void DeleteVoucharDetailByMasterId(int VoucherMasterId, Smartworks.DAL customdataAccess = null)
        {
            Smartworks.ColumnField[] dVoucherDetail = new Smartworks.ColumnField[1];
            dVoucherDetail[0] = new Smartworks.ColumnField("@VoucherMasterId", VoucherMasterId);

            if (customdataAccess != null)
            {
                customdataAccess.ExecuteStoredProcedure("dbo.DeleteVoucharDetailByMasterId", dVoucherDetail);
            }
            else
            {
                dataAccess.BeginTransaction();
                dataAccess.ExecuteStoredProcedure("dbo.DeleteVoucharDetailByMasterId", dVoucherDetail);
                dataAccess.TransCommit();
            }


        }

        public DataTable GetVoucherMaster(int VoucherMasterId, Smartworks.DAL customdataAcess = null)
        {

            DataTable dt;
            if (customdataAcess != null)
            {
                dt = customdataAcess.getDataTable("Select * from VoucherMaster where VoucherMasterId =" + VoucherMasterId);
            }
            else
            {
                dt = dataAccess.getDataTable("Select * from VoucherMaster where VoucherMasterId =" + VoucherMasterId);

            }
            return dt;
        }

        public int GetVoucherMasterIdByCode(string Code , int FYear)
        {
            int VoucherMasterId = -1;
            DataTable dt = new DataTable();
            dt = dataAccess.getDataTable("Select VoucherMasterId from VoucherMaster where VoucherNumber = '" + Code + "' and FYear = '"+ FYear +"'  ");
            if (dt.Rows.Count > 0)
            {
                VoucherMasterId = Convert.ToInt32(dt.Rows[0]["VoucherMasterId"]);
            }
            return VoucherMasterId;
        }
        public DataTable GetVoucherMasterList()
        {
            DataTable dt = new DataTable();
            dt = dataAccess.getDataTable("Select VoucherMasterId , upper(left(Name, 1)) + right(Name, len(Name) - 1) as VoucherType  from VoucherMaster Order by Name ");
            return dt;

        }

        public DataTable GetVoucherListForPosting(DateTime FromDate, DateTime ToDate, string VocuherType)
        {
            Smartworks.ColumnField[] gVoucherDetail = new Smartworks.ColumnField[3];
            gVoucherDetail[0] = new Smartworks.ColumnField("@FromDate", FromDate);
            gVoucherDetail[1] = new Smartworks.ColumnField("@ToDate", ToDate);
            gVoucherDetail[2] = new Smartworks.ColumnField("@VoucherType", VocuherType);

            DataTable dtVocherList = dataAccess.getDataTableByStoredProcedure("sp_GetVoucherListForPosting", gVoucherDetail);
            return dtVocherList;
        }

        public bool PostVoucher(string VoucherNo, Smartworks.DAL customdataAcess = null)
        {
            bool result = false;
            Smartworks.ColumnField[] pVoucher = new Smartworks.ColumnField[1];
            pVoucher[0] = new Smartworks.ColumnField("@VoucherNumber", VoucherNo);

            if (customdataAcess != null)
            {
                result = Convert.ToBoolean(customdataAcess.ExecuteStoredProcedure("sp_PostVoucher", pVoucher));
            }
            else
            {
                dataAccess.BeginTransaction();
                result = Convert.ToBoolean(dataAccess.ExecuteStoredProcedure("sp_PostVoucher", pVoucher));
                dataAccess.TransCommit();
            }
            return result;
        }

        public DataTable GetUnPostedVoucher(DateTime FromDate, DateTime ToDate)
        {
            return dataAccess.getDataTable("Select * from VoucherMaster where (Cast(Date as Date) between Cast('" + FromDate + "' as Date) and Cast('" + ToDate + "' as Date)) and (Posted = 0 ) ");
        }


        #region VoucherDetailMethods

        public int InsertVoucherDetail(int VoucherMasterId, string CustomerCode,
                                     string VendorCode, int COAId, string AccountCode, string FlagDC, decimal Amount, string Remarks, Smartworks.DAL customdataAcess = null)
        {
            int id = 0;

            Smartworks.ColumnField[] iVoucherDetail = new Smartworks.ColumnField[8];
            iVoucherDetail[0] = new Smartworks.ColumnField("@VoucherMasterId", VoucherMasterId);
            iVoucherDetail[1] = new Smartworks.ColumnField("@CustomerCode", (string.IsNullOrEmpty(CustomerCode) ? (object)DBNull.Value : CustomerCode));
            iVoucherDetail[2] = new Smartworks.ColumnField("@VendorCode", (string.IsNullOrEmpty(VendorCode) ? (object)DBNull.Value : VendorCode));
            iVoucherDetail[3] = new Smartworks.ColumnField("@COAId", COAId);
            iVoucherDetail[4] = new Smartworks.ColumnField("@AccountCode", AccountCode);
            iVoucherDetail[5] = new Smartworks.ColumnField("@FlagDC", FlagDC);
            iVoucherDetail[6] = new Smartworks.ColumnField("@Amount", Amount);
            iVoucherDetail[7] = new Smartworks.ColumnField("@Remarks", Remarks);
            if (customdataAcess != null)
            {
                id = Convert.ToInt32(customdataAcess.ExecuteStoredProcedure("dbo.InsertVoucherDetail", iVoucherDetail));
            }
            else
            {
                dataAccess.BeginTransaction();
                id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.InsertVoucherDetail", iVoucherDetail));
                dataAccess.TransCommit();
            }

            return id;

        }



        public void UpdateVoucherDetail(int VoucherDetailId, int VoucherMasterId, string CustomerCode,
                                 string VendorCode, string FlagDC, decimal Amount, string Remarks)
        {
            Smartworks.ColumnField[] uVoucherDetail = new Smartworks.ColumnField[7];
            uVoucherDetail[0] = new Smartworks.ColumnField("@VoucherDetailId", VoucherDetailId);
            uVoucherDetail[1] = new Smartworks.ColumnField("@VoucherMasterId", VoucherMasterId);
            uVoucherDetail[2] = new Smartworks.ColumnField("@CustomerCode", CustomerCode);
            uVoucherDetail[3] = new Smartworks.ColumnField("@VendorCode", VendorCode);
            uVoucherDetail[4] = new Smartworks.ColumnField("@FlagDC", FlagDC);
            uVoucherDetail[5] = new Smartworks.ColumnField("@Amount", Amount);
            uVoucherDetail[6] = new Smartworks.ColumnField("@Remarks", Remarks);
            dataAccess.BeginTransaction();
            dataAccess.ExecuteStoredProcedure("dbo.UpdateVoucherDetail", uVoucherDetail);
            dataAccess.TransCommit();
        }


        //public int DeleteVoucharMaster(string VoucherDetailId)
        //{
        //    int id;
        //    Smartworks.ColumnField[] dVoucherDetail = new Smartworks.ColumnField[1];
        //    dVoucherDetail[0] = new Smartworks.ColumnField("@VoucherDetailId", VoucherDetailId);
        //    dataAccess.BeginTransaction();
        //    id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.DeleteVoucherDetail", dVoucherDetail));
        //    dataAccess.TransCommit();
        //    return id;
        //}

        public DataTable GetVoucherMaster(int VoucherMasterId)
        {

            DataTable dt;
            dt = dataAccess.getDataTable("Select * from VoucherDetail where VoucherMasterId =" + VoucherMasterId);
            return dt;
        }

        public DataTable GetReceiptVoucher(int VoucherMasterId)
        {
            DataTable dt = null;
            Smartworks.ColumnField[] gVoucher = new Smartworks.ColumnField[1];
            gVoucher[0] = new Smartworks.ColumnField("@VoucherMasterId", VoucherMasterId);
            dt = dataAccess.getDataTableByStoredProcedure("sp_GetReceiptVoucher", gVoucher);
            return dt;
        }

        public DataTable GetPaymentVoucher(int VoucherMasterId)
        {
            DataTable dt = null;
            Smartworks.ColumnField[] gVoucher = new Smartworks.ColumnField[1];
            gVoucher[0] = new Smartworks.ColumnField("@VoucherMasterId", VoucherMasterId);
            dt = dataAccess.getDataTableByStoredProcedure("sp_GetPaymentVoucher", gVoucher);
            return dt;
        }



        #endregion

        #region VoucherReoprt
        public DataTable GetReportCashRecipt(String VoucherType, DateTime FromDate, DateTime ToDate, String FromVoucherNo, String ToVoucherNo)
        {
            DataTable dt = new DataTable();
            Smartworks.ColumnField[] CashRecipt = new Smartworks.ColumnField[5];
            CashRecipt[0] = new Smartworks.ColumnField("@VoucherType", VoucherType);
            CashRecipt[1] = new Smartworks.ColumnField("@FromDate", FromDate);
            CashRecipt[2] = new Smartworks.ColumnField("@ToDate", ToDate);
            CashRecipt[3] = new Smartworks.ColumnField("@FromVoucherNo", FromVoucherNo);
            CashRecipt[4] = new Smartworks.ColumnField("@ToVoucherNo", ToVoucherNo);
            dt = dataAccess.getDataTableByStoredProcedure("Sp_ReportCashRecipt", CashRecipt);
            return dt;
        }

        public DataTable GetReportCashPayment(String VoucherType, DateTime FromDate, DateTime ToDate, String FromVoucherNo, String ToVoucherNo)
        {
            DataTable dt = new DataTable();
            Smartworks.ColumnField[] CashPayment = new Smartworks.ColumnField[5];
            CashPayment[0] = new Smartworks.ColumnField("@VoucherType", VoucherType);
            CashPayment[1] = new Smartworks.ColumnField("@FromDate", FromDate);
            CashPayment[2] = new Smartworks.ColumnField("@ToDate", ToDate);
            CashPayment[3] = new Smartworks.ColumnField("@FromVoucherNo", FromVoucherNo);
            CashPayment[4] = new Smartworks.ColumnField("@ToVoucherNo", ToVoucherNo);
            dt = dataAccess.getDataTableByStoredProcedure("Sp_ReportCashPayment", CashPayment);
            return dt;
        }
        #endregion

        #region Navigation

        public string GetMaxVoucherNo(string Type , int FYear)
        {
            string InvoiceNo = "";
            DataTable dt = new DataTable();
            dt = dataAccess.getDataTable("select max(VoucherNumber) as 'VoucherNo' from VoucherMaster where VoucherType = '" + Type + "' and FYear = '"+ MainForm.FYear +"'");
            if (dt.Rows.Count > 0)
            {
                InvoiceNo = dt.Rows[0]["VoucherNo"].ToString();
            }
            return InvoiceNo;
        }

        public string GetMinVoucherNo(string Type, int FYear )
        {
            string InvoiceNo = "";
            DataTable dt = new DataTable();
            dt = dataAccess.getDataTable("select min(VoucherNumber) as 'VoucherNo' from VoucherMaster where VoucherType = '" + Type + "' and FYear = '"+ FYear+"' ");
            if (dt.Rows.Count > 0)
            {
                InvoiceNo = dt.Rows[0]["VoucherNo"].ToString();
            }
            return InvoiceNo;
        }


        public string GetNextVoucherNo(string VoucherCode)
        {
            string VoucherNo = "";
            DataTable dt = new DataTable();
            dt = dataAccess.getDataTable("Select dbo.GetNextNumber('" + VoucherCode + "') as VoucherNo ");
            if (dt.Rows.Count > 0)
            {
                VoucherNo = (string)dt.Rows[0]["VoucherNo"].ToString();
            }
            return VoucherNo;
        }

        public string GetPrevVoucherNo(string VoucherCode)
        {
            string VoucherNo = "";
            try
            {
                DataTable dt = new DataTable();
                dt = dataAccess.getDataTable("Select dbo.GetPreviousNumber('" + VoucherCode + "') as VoucherNo");
                if (dt.Rows.Count > 0)
                {
                    VoucherNo = (string)dt.Rows[0]["VoucherNo"].ToString();
                }
            }
            catch (Exception ex)
            {
                VoucherNo = "";
            }
            
            return VoucherNo;
        }


        #endregion


        #region CashReceipt
        public int InsertCashReceipt(DateTime Date, string VoucherType,
                                 string BranchCode, string Narration, decimal TotalDebit, decimal TotalCredit,
                                 int AddedBy, DateTime AddedOn, string AddedIpAddr, decimal Amount, string AccountCode, Smartworks.DAL customdataAcess = null)
        {
            int Id = 0;
            Smartworks.ColumnField[] iCashReceipt = new Smartworks.ColumnField[11];
            iCashReceipt[0] = new Smartworks.ColumnField("@Date", Date);
            iCashReceipt[1] = new Smartworks.ColumnField("@VoucherType", VoucherType);
            iCashReceipt[2] = new Smartworks.ColumnField("@BranchCode", BranchCode);
            iCashReceipt[3] = new Smartworks.ColumnField("@Narration", Narration);
            iCashReceipt[4] = new Smartworks.ColumnField("@TotalDebit", TotalDebit);
            iCashReceipt[5] = new Smartworks.ColumnField("@TotalCredit", TotalCredit);
            iCashReceipt[6] = new Smartworks.ColumnField("@AddedBy", AddedBy);
            iCashReceipt[7] = new Smartworks.ColumnField("@AddedOn", AddedOn);
            iCashReceipt[8] = new Smartworks.ColumnField("@AddedIpAddr", AddedIpAddr);
            iCashReceipt[9] = new Smartworks.ColumnField("@Amount", Amount);
            iCashReceipt[10] = new Smartworks.ColumnField("@AccountCode", AccountCode);

            if (customdataAcess != null)
            {
                Id = Convert.ToInt32(customdataAcess.ExecuteStoredProcedure("dbo.InsertCashReceipt", iCashReceipt));

            }
            else
            {
                dataAccess.BeginTransaction();
                Id = Convert.ToInt32(dataAccess.getDataTableByStoredProcedure("dbo.InsertCashReceipt", iCashReceipt));
                dataAccess.TransCommit();
            }
            return Id;
        }


        public int UpdateCashReceipt(int VoucherMasterId, DateTime Date, string VoucherType,
                                 string BranchCode, string Narration, decimal TotalDebit, decimal TotalCredit,
                                 int AddedBy, DateTime AddedOn, string AddedIpAddr, decimal Amount, string AccountCode, Smartworks.DAL customdataAcess = null)
        {
            int Id = 0;
            Smartworks.ColumnField[] uCashReceipt = new Smartworks.ColumnField[12];
            uCashReceipt[0] = new Smartworks.ColumnField("@VoucherMasterId", VoucherMasterId);
            uCashReceipt[1] = new Smartworks.ColumnField("@Date", Date);
            uCashReceipt[2] = new Smartworks.ColumnField("@VoucherType", VoucherType);
            uCashReceipt[3] = new Smartworks.ColumnField("@BranchCode", BranchCode);
            uCashReceipt[4] = new Smartworks.ColumnField("@Narration", Narration);
            uCashReceipt[5] = new Smartworks.ColumnField("@TotalDebit", TotalDebit);
            uCashReceipt[6] = new Smartworks.ColumnField("@TotalCredit", TotalCredit);
            uCashReceipt[7] = new Smartworks.ColumnField("@AddedBy", AddedBy);
            uCashReceipt[8] = new Smartworks.ColumnField("@AddedOn", AddedOn);
            uCashReceipt[9] = new Smartworks.ColumnField("@AddedIpAddr", AddedIpAddr);
            uCashReceipt[10] = new Smartworks.ColumnField("@Amount", Amount);
            uCashReceipt[11] = new Smartworks.ColumnField("@AccountCode", AccountCode);

            if (customdataAcess != null)
            {
                Id = Convert.ToInt32(customdataAcess.ExecuteStoredProcedure("dbo.UpdateCashReceipt", uCashReceipt));

            }
            else
            {
                dataAccess.BeginTransaction();
                Id = Convert.ToInt32(dataAccess.getDataTableByStoredProcedure("dbo.UpdateCashReceipt", uCashReceipt));
                dataAccess.TransCommit();
            }
            return Id;
        }

        #endregion

        #region CashPayment

        public int InsertCashPayment(DateTime Date, string VoucherType,
                              string BranchCode, string Narration, decimal TotalDebit, decimal TotalCredit,
                              int AddedBy, DateTime AddedOn, string AddedIpAddr, decimal Amount, string AccountCode, Smartworks.DAL customdataAcess = null)
        {
            int Id = 0;
            Smartworks.ColumnField[] iCashPayment = new Smartworks.ColumnField[11];
            iCashPayment[0] = new Smartworks.ColumnField("@Date", Date);
            iCashPayment[1] = new Smartworks.ColumnField("@VoucherType", VoucherType);
            iCashPayment[2] = new Smartworks.ColumnField("@BranchCode", BranchCode);
            iCashPayment[3] = new Smartworks.ColumnField("@Narration", Narration);
            iCashPayment[4] = new Smartworks.ColumnField("@TotalDebit", TotalDebit);
            iCashPayment[5] = new Smartworks.ColumnField("@TotalCredit", TotalCredit);
            iCashPayment[6] = new Smartworks.ColumnField("@AddedBy", AddedBy);
            iCashPayment[7] = new Smartworks.ColumnField("@AddedOn", AddedOn);
            iCashPayment[8] = new Smartworks.ColumnField("@AddedIpAddr", AddedIpAddr);
            iCashPayment[9] = new Smartworks.ColumnField("@Amount", Amount);
            iCashPayment[10] = new Smartworks.ColumnField("@AccountCode", AccountCode);

            if (customdataAcess != null)
            {
                Id = Convert.ToInt32(customdataAcess.ExecuteStoredProcedure("dbo.InsertCashPayment", iCashPayment));
            }
            else
            {
                dataAccess.BeginTransaction();
                Id = Convert.ToInt32(dataAccess.getDataTableByStoredProcedure("dbo.InsertCashPayment", iCashPayment));
                dataAccess.TransCommit();
            }
            return Id;
        }


        public int UpdateCashPayment(int VoucherMasterId, DateTime Date, string VoucherType,
                                string BranchCode, string Narration, decimal TotalDebit, decimal TotalCredit,
                                int AddedBy, DateTime AddedOn, string AddedIpAddr, decimal Amount, string AccountCode, Smartworks.DAL customdataAcess = null)
        {
            int Id = 0;
            Smartworks.ColumnField[] uCashPayment = new Smartworks.ColumnField[12];
            uCashPayment[0] = new Smartworks.ColumnField("@VoucherMasterId", VoucherMasterId);
            uCashPayment[1] = new Smartworks.ColumnField("@Date", Date);
            uCashPayment[2] = new Smartworks.ColumnField("@VoucherType", VoucherType);
            uCashPayment[3] = new Smartworks.ColumnField("@BranchCode", BranchCode);
            uCashPayment[4] = new Smartworks.ColumnField("@Narration", Narration);
            uCashPayment[5] = new Smartworks.ColumnField("@TotalDebit", TotalDebit);
            uCashPayment[6] = new Smartworks.ColumnField("@TotalCredit", TotalCredit);
            uCashPayment[7] = new Smartworks.ColumnField("@AddedBy", AddedBy);
            uCashPayment[8] = new Smartworks.ColumnField("@AddedOn", AddedOn);
            uCashPayment[9] = new Smartworks.ColumnField("@AddedIpAddr", AddedIpAddr);
            uCashPayment[10] = new Smartworks.ColumnField("@Amount", Amount);
            uCashPayment[11] = new Smartworks.ColumnField("@AccountCode", AccountCode);
            if (customdataAcess != null)
            {
                Id = Convert.ToInt32(customdataAcess.ExecuteStoredProcedure("dbo.UpdateCashPayment", uCashPayment));
            }
            else
            {
                dataAccess.BeginTransaction();
                Id = Convert.ToInt32(dataAccess.getDataTableByStoredProcedure("dbo.UpdateCashPayment", uCashPayment));
                dataAccess.TransCommit();
            }
            return Id;
        }
        #endregion
    }
}
