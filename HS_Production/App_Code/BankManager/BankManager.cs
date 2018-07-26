using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;

namespace FIL
{
    public class BankManager 
    {
        Smartworks.DAL dataAccess = new Smartworks.DAL();
        public BankManager()
        {

            string connString = ConfigurationManager.ConnectionStrings["HSConnectionString"].ConnectionString;
            Smartworks.DAL.ConnectionString = connString;
        }

        #region Bank Setup

        public int InsertBank(string BankName, int AddedBy, DateTime AddedOn,
                                     string AddedIpAddr)
        {
            int id = 0;

            Smartworks.ColumnField[] iBankCatagory = new Smartworks.ColumnField[4];
            iBankCatagory[0] = new Smartworks.ColumnField("@BankName", BankName);
            iBankCatagory[1] = new Smartworks.ColumnField("@AddedBy", AddedBy);
            iBankCatagory[2] = new Smartworks.ColumnField("@AddedOn", AddedOn);
            iBankCatagory[3] = new Smartworks.ColumnField("@AddedIpAddr", AddedIpAddr);
            dataAccess.BeginTransaction();
            id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.InsertBank", iBankCatagory));
            dataAccess.TransCommit();
            return id;

        }

        public void UpdateBank(int BankId, string BankName, int UpdatedBy, DateTime UpdatedOn, string UpdatedIpAddr)
        {
            Smartworks.ColumnField[] uBankCatagory = new Smartworks.ColumnField[5];
            uBankCatagory[0] = new Smartworks.ColumnField("@BankId", BankId);
            uBankCatagory[1] = new Smartworks.ColumnField("@BankName", BankName);
            uBankCatagory[2] = new Smartworks.ColumnField("@UpdatedBy    ", UpdatedBy);
            uBankCatagory[3] = new Smartworks.ColumnField("@UpdatedOn    ", UpdatedOn);
            uBankCatagory[4] = new Smartworks.ColumnField("@UpdatedIpAddr", UpdatedIpAddr);

            dataAccess.BeginTransaction();
            dataAccess.ExecuteStoredProcedure("dbo.UpdateBank", uBankCatagory);
            dataAccess.TransCommit();
        }


        public int DeleteBank(int BankId)
        {
            int id;

            Smartworks.ColumnField[] dBank = new Smartworks.ColumnField[1];
            dBank[0] = new Smartworks.ColumnField("@BankId", BankId);
            dataAccess.BeginTransaction();
            id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.DeleteBank", dBank));
            dataAccess.TransCommit();
            return id;
        }
        public DataTable GetAllBank()
        {
            return dataAccess.getDataTable("select BankId , BankName from Bank");
        }
        public DataTable GetBank(int BankId)
        {

            DataTable dt;
            dt = dataAccess.getDataTable("Select * from Bank where BankId  =" + BankId);
            return dt;
        }

        public DataTable GetBankList()
        {
            DataTable dt = new DataTable();
            dt = dataAccess.getDataTable("Select BankId , upper(left(BankName, 1)) + right(BankName, len(BankName) - 1) as BankName  from Bank Order by BankName ");
            return dt;
        }

        public int GetBankIdById(int Id)
        {
            int BankId = -1;
            DataTable dt = new DataTable();
            dt = dataAccess.getDataTable("Select BankId from Bank where BankId= '" + Id + "' ");
            if (dt.Rows.Count > 0)
            {
                BankId = (int)dt.Rows[0]["BankId"];
            }
            return BankId;
        }

        #endregion

        #region Bank Account Setup

        public int InsertBankAccount(string BranchCode, string AccountNo , string AccountTitle , int BankId , int COAId ,   int AddedBy, DateTime AddedOn,
                                    string AddedIpAddr)
        {
            int id = 0;

            Smartworks.ColumnField[] iBankAC = new Smartworks.ColumnField[8];
            iBankAC[0] = new Smartworks.ColumnField("@BranchCode", BranchCode);
            iBankAC[1] = new Smartworks.ColumnField("@AccountNo", AccountNo);
            iBankAC[2] = new Smartworks.ColumnField("@AccountTitle", AccountTitle);
            iBankAC[3] = new Smartworks.ColumnField("@BankId", BankId);
            iBankAC[4] = new Smartworks.ColumnField("@COAId", COAId);
            iBankAC[5] = new Smartworks.ColumnField("@AddedBy", AddedBy);
            iBankAC[6] = new Smartworks.ColumnField("@AddedOn", AddedOn);
            iBankAC[7] = new Smartworks.ColumnField("@AddedIpAddr", AddedIpAddr);
            dataAccess.BeginTransaction();
            id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.InsertBankAccount", iBankAC));
            dataAccess.TransCommit();
            return id;

        }

        public void UpdateBankAccount(int BankAccountId , string BranchCode, string AccountNo, string AccountTitle, int BankId, int COAId, int AddedBy, DateTime AddedOn,
                                  string AddedIpAddr)
        {
            Smartworks.ColumnField[] uBankAC = new Smartworks.ColumnField[9];
            uBankAC[0] = new Smartworks.ColumnField("@BankAccountId", BankAccountId);
            uBankAC[1] = new Smartworks.ColumnField("@BranchCode", BranchCode);
            uBankAC[2] = new Smartworks.ColumnField("@AccountNo", AccountNo);
            uBankAC[3] = new Smartworks.ColumnField("@AccountTitle", AccountTitle);
            uBankAC[4] = new Smartworks.ColumnField("@BankId", BankId);
            uBankAC[5] = new Smartworks.ColumnField("@COAId", COAId);
            uBankAC[6] = new Smartworks.ColumnField("@UpdatedBy", AddedBy);
            uBankAC[7] = new Smartworks.ColumnField("@UpdatedOn", AddedOn);
            uBankAC[8] = new Smartworks.ColumnField("@UpdatedIPAddr", AddedIpAddr);
            dataAccess.BeginTransaction();
            dataAccess.ExecuteStoredProcedure("dbo.UpdateBankAccount", uBankAC);
            dataAccess.TransCommit();
        }


        public void DeleteBankAccount(int BankAccountId)

        {
            Smartworks.ColumnField[] dBankAC = new Smartworks.ColumnField[1];
            dBankAC[0] = new Smartworks.ColumnField("@BankAccountId", BankAccountId);
            dataAccess.BeginTransaction();
            dataAccess.ExecuteStoredProcedure("dbo.DeleteBankAccount", dBankAC);
            dataAccess.TransCommit();
        }


        public int GetBankACIdByCode(string Code)
        {
            int BankACId = -1;
            DataTable dt = new DataTable();
            dt = dataAccess.getDataTable("Select BankAccountId from BankAccount where Code= '" + Code + "' ");
            if (dt.Rows.Count > 0)
            {
                BankACId = (int)dt.Rows[0]["BankAccountId"];
            }
            return BankACId;
        }

        public DataTable GetBankAccount(int Id)
        {
            return dataAccess.getDataTable("Select * from BankAccount where BankAccountId= '" + Id + "' ");
        }


        #region Navigation

        public string GetMaxBACCode()
        {
            string InvoiceNo = "";
            DataTable dt = new DataTable();
            dt = dataAccess.getDataTable("select max(Code) as 'VoucherNo' from BankAccount");
            if (dt.Rows.Count > 0)
            {
                InvoiceNo = (string)dt.Rows[0]["VoucherNo"].ToString();
            }
            return InvoiceNo;
        }

        public string GetMinBACCode()
        {
            string InvoiceNo = "";
            DataTable dt = new DataTable();
            dt = dataAccess.getDataTable("select min(Code) as 'VoucherNo' from BankAccount ");
            if (dt.Rows.Count > 0)
            {
                InvoiceNo = (string)dt.Rows[0]["VoucherNo"].ToString();
            }
            return InvoiceNo;
        }


        public string GetNextBACCode(string BACCode)
        {
            string VoucherNo = "";
            DataTable dt = new DataTable();
            dt = dataAccess.getDataTable("Select dbo.GetNextNumber('" + BACCode + "') as VoucherNo ");
            if (dt.Rows.Count > 0)
            {
                VoucherNo = (string)dt.Rows[0]["VoucherNo"].ToString();
            }
            return VoucherNo;
        }

        public string GetPrevBACCode(string BACCode)
        {
            string VoucherNo = "";
            DataTable dt = new DataTable();
            dt = dataAccess.getDataTable("Select dbo.GetPreviousNumber('" + BACCode + "') as VoucherNo");
            if (dt.Rows.Count > 0)
            {
                VoucherNo = (string)dt.Rows[0]["VoucherNo"].ToString();
            }
            return VoucherNo;
        }


        #endregion


        #endregion


        #region BankVoucherDetail

        public int InsertUpdateBankVoucherDetail(int BankVoucherDetailId, DateTime Date, string CustomerCode, string VendorCode, int BankId, int BankAccountId, decimal ChequeAmount ,
           DateTime ChequeDate, int ChequeBankId, string ChequeNumber, string VoucherNature, int VoucherId, string VoucherType , string BillNo , DateTime BillDate , Smartworks.DAL customdataAcess = null)
        {
            
            int BVDId = -1;
            Smartworks.ColumnField[] iuBankVoucherDetail = new Smartworks.ColumnField[15];
            iuBankVoucherDetail[0] = new Smartworks.ColumnField("@BankVoucherDetailId", BankVoucherDetailId);
            iuBankVoucherDetail[1] = new Smartworks.ColumnField("@Date", Date);
            iuBankVoucherDetail[2] = new Smartworks.ColumnField("@CustomerCode", CustomerCode);
            iuBankVoucherDetail[3] = new Smartworks.ColumnField("@VendorCode", VendorCode);
            iuBankVoucherDetail[4] = new Smartworks.ColumnField("@BankId", BankId);
            iuBankVoucherDetail[5] = new Smartworks.ColumnField("@BankAccountId", BankAccountId);
            iuBankVoucherDetail[6] = new Smartworks.ColumnField("@ChequeAmount", ChequeAmount);
            iuBankVoucherDetail[7] = new Smartworks.ColumnField("@ChequeDate", ChequeDate);
            iuBankVoucherDetail[8] = new Smartworks.ColumnField("@ChequeBankId", ChequeBankId);
            iuBankVoucherDetail[9] = new Smartworks.ColumnField("@ChequeNumber", ChequeNumber);
            iuBankVoucherDetail[10] = new Smartworks.ColumnField("@VoucherNature", VoucherNature);
            iuBankVoucherDetail[11] = new Smartworks.ColumnField("@VoucherId", VoucherId);
            iuBankVoucherDetail[12] = new Smartworks.ColumnField("@VoucherType", VoucherType);
            iuBankVoucherDetail[13] = new Smartworks.ColumnField("@BillNo", BillNo);
            iuBankVoucherDetail[14] = new Smartworks.ColumnField("@BillDate", BillDate);

            if (customdataAcess != null)
            {
                BVDId = Convert.ToInt32(customdataAcess.getDataTableByStoredProcedure("dbo.InsertUpdateBankVoucherDetail", iuBankVoucherDetail).Rows[0]["Id"]);

            }
            else
            {
                dataAccess.BeginTransaction();
                BVDId = Convert.ToInt32(dataAccess.getDataTableByStoredProcedure("dbo.InsertVoucharMaster", iuBankVoucherDetail));
                dataAccess.TransCommit();
            }
            return BVDId;

        }


        public DataTable GetBankVoucherDetailByVoucherMasterId(int VoucherMasterId)
        {
            return dataAccess.getDataTable("Select * from BankVoucherDetail where VoucherId = '" + VoucherMasterId + "'");
        }

        public void DeleteBankVoucherDetailByVoucherMasterId(int VoucherMasterId, Smartworks.DAL customdataAcess = null)
        {
            Smartworks.ColumnField[] dVoucherDetail = new Smartworks.ColumnField[1];

            dVoucherDetail[0] = new Smartworks.ColumnField("@VoucherMasterId", VoucherMasterId);
            if (customdataAcess != null)
            {
                customdataAcess.ExecuteStoredProcedure("sp_DeleteBankVoucherDetail", dVoucherDetail);
            }
            else
            {
                dataAccess.BeginTransaction();
                dataAccess.ExecuteStoredProcedure("sp_DeleteBankVoucherDetail", dVoucherDetail);
                dataAccess.TransCommit();
            }

        }

        #endregion

    }
}

