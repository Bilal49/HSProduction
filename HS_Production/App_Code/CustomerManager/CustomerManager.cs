using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Windows.Forms;


    public class CustomerManager
    {
        Smartworks.DAL dataAccess = new Smartworks.DAL();
        public CustomerManager()
        {
          
            string connString = ConfigurationManager.ConnectionStrings["HSConnectionString"].ConnectionString;
            Smartworks.DAL.ConnectionString = connString;
        }


        public int InsertCustomer(string customerName, string Address, string phoneNumber, string contactPerson, int COAId , string STRegistration , string NTN  ,
                                  bool inactive ,bool inPos,
                                 int AddedBy, DateTime AddedOn, string AddedIpAddr)
        {
            int id = 0;

            Smartworks.ColumnField[] iCustomer = new Smartworks.ColumnField[12];
                       
            iCustomer[0] = new Smartworks.ColumnField("@CustomerName", customerName);
            iCustomer[1] = new Smartworks.ColumnField("@Address", Address);
            iCustomer[2] = new Smartworks.ColumnField("@Phone", phoneNumber);
            iCustomer[3] = new Smartworks.ColumnField("@ContactPerson", contactPerson);
            iCustomer[4] = new Smartworks.ColumnField("@COAId", COAId);
            iCustomer[5] = new Smartworks.ColumnField("@STRegistration", STRegistration);
            iCustomer[6] = new Smartworks.ColumnField("@NTN", NTN);
            iCustomer[7] = new Smartworks.ColumnField("@IsActive", inactive);
            iCustomer[8] = new Smartworks.ColumnField("@IsPos", inPos);
            iCustomer[9] = new Smartworks.ColumnField("@AddedBy", AddedBy);
            iCustomer[10] = new Smartworks.ColumnField("@AddedOn", AddedOn);
            iCustomer[11] = new Smartworks.ColumnField("@AddedIpAddr", AddedIpAddr);
            dataAccess.BeginTransaction();
            id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.InsertCustomer", iCustomer));
            dataAccess.TransCommit();
            if(inPos == true)
            {
            UpdatePosCustomer(id);
            }
            return id;
        }

       public void UpdatePosCustomer(int CustomerId)
        {
            //dataAccess.BeginTransaction();
            //dataAccess.TransCommit();
            dataAccess.ConnectionOpen();
            dataAccess.ExecuteNonQuery("UPDATE  dbo.Customer SET Ispos = 0 WHERE CustomerId != "+ CustomerId);
        }

       public void UpdateCustomer(int customerId, string customerName, string Address, string phoneNumber, string contactPerson, int COAId, string STRegistration, string NTN,
                                  bool inactive,bool inPos, int UpdatedBy, DateTime UpdatedOn, string UpdatedIpAddr)
        {
            Smartworks.ColumnField[] uCustomer = new Smartworks.ColumnField[13];


            uCustomer[0] = new Smartworks.ColumnField("@CustomerId", customerId);
            uCustomer[1] = new Smartworks.ColumnField("@CustomerName", customerName);
            uCustomer[2] = new Smartworks.ColumnField("@Address", Address);
            uCustomer[3] = new Smartworks.ColumnField("@Phone", phoneNumber);
            uCustomer[4] = new Smartworks.ColumnField("@ContactPerson", contactPerson);
            uCustomer[5] = new Smartworks.ColumnField("@COAId", COAId);
            uCustomer[6] = new Smartworks.ColumnField("@STRegistration", STRegistration);
            uCustomer[7] = new Smartworks.ColumnField("@NTN", NTN);
            uCustomer[8] = new Smartworks.ColumnField("@IsActive", inactive);
            uCustomer[9] = new Smartworks.ColumnField("@IsPos", inPos);
            uCustomer[10] = new Smartworks.ColumnField("@UpdateBy", UpdatedBy);
            uCustomer[11] = new Smartworks.ColumnField("@UpdatedOn", UpdatedOn);
            uCustomer[12] = new Smartworks.ColumnField("@UpdatedIpAddr", UpdatedIpAddr);

            dataAccess.BeginTransaction();
            dataAccess.ExecuteStoredProcedure("dbo.UpdateCustomer", uCustomer);
            dataAccess.TransCommit();

            if (inPos == true)
            {
                UpdatePosCustomer(customerId);
            }
        }


        public int DeleteCustomer(string CustomerId)
        {
            int id ;
          
            Smartworks.ColumnField[] dCustomer = new Smartworks.ColumnField[1];
            dCustomer[0] = new Smartworks.ColumnField("@CustomerId", CustomerId);

            dataAccess.BeginTransaction();
            id= Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.DeleteCustomer", dCustomer));

            dataAccess.TransCommit();

            return id;
        }


       
        public DataTable GetCustomerByUserId(int UserId)
        {

            DataTable dt;
            Smartworks.ColumnField[] gCustomer = new Smartworks.ColumnField[1];
            gCustomer[0] = new Smartworks.ColumnField("@UserId", UserId);
            dt = dataAccess.getDataTableByStoredProcedure("dbo.GetCustomer", gCustomer);
            return dt;
        }


        public DataTable GetCustomer(int CustomerId)
        {

            DataTable dt;
            dt = dataAccess.getDataTable("Select * from Customer where CustomerId =" + CustomerId);
            return dt;
        }

       

        public int GetCustomerIdByCode(string Code)
        {
            int CustomerId = -1;
            DataTable dt = new DataTable();
            dt = dataAccess.getDataTable("Select CustomerId from Customer where Code = '" + Code + "' ");
            if (dt.Rows.Count > 0)
            {
                CustomerId = (int)dt.Rows[0]["CustomerId"];
            }
            return CustomerId;
        }

          public DataTable GetCustomer()
          {

              DataTable dt;
              Smartworks.ColumnField[] gCustomer = new Smartworks.ColumnField[1];
              gCustomer[0] = new Smartworks.ColumnField("@result", true);

              dt = dataAccess.getDataTableByStoredProcedure("dbo.GetAllCustomer", gCustomer);

              return dt;
          }

       

        public DataTable GetCustomerList()
        {
            DataTable dt = new DataTable();
            dt = dataAccess.getDataTable("Select CustomerId , upper(left(Name, 1)) + right(Name, len(Name) - 1) as CustomerName  from Customer Order by Name ");
            return dt;

        }

        #region CustomerLedgerMethods

        public int InsertCustomerLedger(int CustomerId, DateTime Date,
                                  string SalesInvoiceNo, int SalesInvoiceId, decimal SalesAmount, string VoucherNo,
                                  int VoucherId, decimal VoucherAmount,
                                  Smartworks.DAL customdataAcess = null)
        {
            int id = 0;
            Smartworks.ColumnField[] iCustomerLedger = new Smartworks.ColumnField[8];
            iCustomerLedger[0] = new Smartworks.ColumnField("@CustomerId", CustomerId);
            iCustomerLedger[1] = new Smartworks.ColumnField("@Date", Date);
            iCustomerLedger[2] = new Smartworks.ColumnField("@SalesInvoiceNo", SalesInvoiceNo);
            iCustomerLedger[3] = new Smartworks.ColumnField("@SalesInvoiceId", SalesInvoiceId);
            iCustomerLedger[4] = new Smartworks.ColumnField("@SalesAmount", SalesAmount);
            iCustomerLedger[5] = new Smartworks.ColumnField("@VoucherNo", VoucherNo);
            iCustomerLedger[6] = new Smartworks.ColumnField("@VoucherId", VoucherId);
            iCustomerLedger[7] = new Smartworks.ColumnField("@VoucherAmount", VoucherAmount);
            if (customdataAcess != null)
            {
                id = Convert.ToInt32(customdataAcess.ExecuteStoredProcedure("dbo.InsertCustomerLedger", iCustomerLedger));
            }
            else
            {
                dataAccess.BeginTransaction();
                id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.InsertCustomerLedger", iCustomerLedger));
                dataAccess.TransCommit();
            }

            return id;

        }

        public void UpdateCustomerLedger(int LedgerId, int CustomerId, DateTime Date,
                                 string SalesInvoiceNo, int SalesInvoiceId, decimal SalesAmount, string VoucherNo,
                                 int VoucherId, decimal VoucherAmount, Smartworks.DAL customdataAcess=null)
        {
            Smartworks.ColumnField[] uCustomerLedger = new Smartworks.ColumnField[9];
            uCustomerLedger[0] = new Smartworks.ColumnField("@LedgerId", LedgerId);
            uCustomerLedger[1] = new Smartworks.ColumnField("@CustomerId", CustomerId);
            uCustomerLedger[2] = new Smartworks.ColumnField("@Date", Date);
            uCustomerLedger[3] = new Smartworks.ColumnField("@SalesInvoiceNo", SalesInvoiceNo);
            uCustomerLedger[4] = new Smartworks.ColumnField("@SalesInvoiceId", SalesInvoiceId);
            uCustomerLedger[5] = new Smartworks.ColumnField("@SalesAmount", SalesAmount);
            uCustomerLedger[6] = new Smartworks.ColumnField("@VoucherNo", VoucherNo);
            uCustomerLedger[7] = new Smartworks.ColumnField("@VoucherId", VoucherId);
            uCustomerLedger[8] = new Smartworks.ColumnField("@VoucherAmount", VoucherAmount);

            if (customdataAcess != null)
            {
                customdataAcess.ExecuteStoredProcedure("dbo.UpdateCustomerLedger", uCustomerLedger);
            }
            else
            {
                dataAccess.BeginTransaction();
                dataAccess.ExecuteStoredProcedure("dbo.UpdateCustomerLedger", uCustomerLedger);
                dataAccess.TransCommit();
            }

           
        }


        public int DeleteCustomerLedger(string LedgerId)
        {
            int id;
            Smartworks.ColumnField[] dCustomerLedger = new Smartworks.ColumnField[1];
            dCustomerLedger[0] = new Smartworks.ColumnField("@LedgerId", LedgerId);
            dataAccess.BeginTransaction();
            id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.DeleteCustomerLedger", dCustomerLedger));
            dataAccess.TransCommit();
            return id;
        }

        public int DeleteCustomerLedgerByTransNo(string SalesInvoiceNo , Smartworks.DAL customdataAcess = null)
        {
            int id=0;
            Smartworks.ColumnField[] dCustomerLedger = new Smartworks.ColumnField[1];
            dCustomerLedger[0] = new Smartworks.ColumnField("@SalesInvoiceNo", SalesInvoiceNo);

            if (customdataAcess != null)
            {
                customdataAcess.ExecuteStoredProcedure("dbo.DeleteCustomerLedgerByInvoiceNo", dCustomerLedger);
            }
            else
            {
                dataAccess.BeginTransaction();
                id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.DeleteCustomerLedgerByInvoiceNo", dCustomerLedger));
                dataAccess.TransCommit();
            }
            return id;
        }

        public DataTable GetCustomerLedger(int LedgerId)
        {

            DataTable dt;
            dt = dataAccess.getDataTable("Select * from CustomerLedger where LedgerId =" + LedgerId);
            return dt;
        }

        public DataTable GetCustomerLedgerByInvoiceNo(string SalesInvoiceNo)
        {

            DataTable dt;
            dt = dataAccess.getDataTable("select * from [CustomerLedger] where SalesInvoiceNo = '" + SalesInvoiceNo + "'");
            return dt;
        }

        public DataTable GetCustomerLedgerByCashRecipt(string ReciptNo)
        {

            DataTable dt;
            dt = dataAccess.getDataTable("select * from [CustomerLedger] where VoucherNo = '" + ReciptNo + "'");
            return dt;
        }

        #endregion


        #region CustomerReoprt
        public DataTable GetReportCustomerLedger(String CustomerCode, DateTime FromDate, DateTime ToDate)
        {
            DataTable dt = new DataTable();
            Smartworks.ColumnField[] Customerledger = new Smartworks.ColumnField[3];
            Customerledger[0] = new Smartworks.ColumnField("@CustomerCode", CustomerCode);
            Customerledger[1] = new Smartworks.ColumnField("@FromDate", FromDate);
            Customerledger[2] = new Smartworks.ColumnField("@ToDate", ToDate);
            dt = dataAccess.getDataTableByStoredProcedure("sp_ReportCustomerLedger", Customerledger);
            return dt;
        }
        #endregion
    }

