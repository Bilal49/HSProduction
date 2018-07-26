using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;

namespace FIL
{
    class ExpenseManager
    {
        Smartworks.DAL dataAccess = new Smartworks.DAL();
        public ExpenseManager()
        {
            string connString = ConfigurationManager.ConnectionStrings["HSConnectionString"].ConnectionString;
            Smartworks.DAL.ConnectionString = connString;
        }
        public int InsertExpense(DateTime Date, int ExpenseCatagoryId, decimal Amount, string Remarks,
            int AddedBy, DateTime AddedOn, string AddedIpAddr)
        {
            int id = 0;

            Smartworks.ColumnField[] iExpense = new Smartworks.ColumnField[7];
            iExpense[0] = new Smartworks.ColumnField("@Date", Date);
            iExpense[1] = new Smartworks.ColumnField("@ExpenseCatagoryId", ExpenseCatagoryId);
            iExpense[2] = new Smartworks.ColumnField("@Amount", Amount);
            iExpense[3] = new Smartworks.ColumnField("@Remarks", Remarks);
            iExpense[4] = new Smartworks.ColumnField("@AddedBy", AddedBy);
            iExpense[5] = new Smartworks.ColumnField("@AddedOn", AddedOn);
            iExpense[6] = new Smartworks.ColumnField("@AddedIpAddr", AddedIpAddr);
            dataAccess.BeginTransaction();
            id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.InsertExpense", iExpense));
            dataAccess.TransCommit();
            return id;
        }



        public void UpdateExpense(int ExpenseId, DateTime Date, int ExpenseCatagoryId, decimal Amount, string Remarks,
            int UpdatedBy, DateTime UpdatedOn, string UpdatedIpAddr)
        {
            Smartworks.ColumnField[] uExpense = new Smartworks.ColumnField[8];

            uExpense[0] = new Smartworks.ColumnField("@ExpenseId", ExpenseId);
            uExpense[1] = new Smartworks.ColumnField("@Date", Date);
            uExpense[2] = new Smartworks.ColumnField("@ExpenseCatagoryId", ExpenseCatagoryId);
            uExpense[3] = new Smartworks.ColumnField("@Amount", Amount);
            uExpense[4] = new Smartworks.ColumnField("@Remarks", Remarks);
            uExpense[5] = new Smartworks.ColumnField("@UpdatedBy", UpdatedBy);
            uExpense[6] = new Smartworks.ColumnField("@UpdatedOn", UpdatedOn);
            uExpense[7] = new Smartworks.ColumnField("@UpdatedIpAddr", UpdatedIpAddr);
            dataAccess.BeginTransaction();
            dataAccess.ExecuteStoredProcedure("dbo.UpdateExpense", uExpense);
            dataAccess.TransCommit();
        }


        public int DeleteExpense(int ExpenseId)
        {
            int id;

            Smartworks.ColumnField[] dExpense = new Smartworks.ColumnField[1];
            dExpense[0] = new Smartworks.ColumnField("@ExpenseId", ExpenseId);
            dataAccess.BeginTransaction();
            id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.DeleteExpense", dExpense));
            dataAccess.TransCommit();
            return id;
        }


        public DataTable GetExpenseById(int ExpenseId)
        {

            DataTable dt;
            dt = dataAccess.getDataTable("Select * from Expense where ExpenseId =" + ExpenseId);
            return dt;
        }



        public int GetExpenseIdById(int ExpenseId)
        {
            int ProductId = -1;
            DataTable dt = new DataTable();
            dt = dataAccess.getDataTable("Select ExpenseId from Expense where ExpenseId= '" + ExpenseId + "' ");
            if (dt.Rows.Count > 0)
            {
                ProductId = (int)dt.Rows[0]["ExpenseId"];
            }
            return ProductId;
        }

        #region ExpenseCategoryMethods

        public int InsertExpenseCatagory(string DESCRIPTION, int AddedBy, DateTime AddedOn,
                                   string AddedIpAddr)
        {
            int id = 0;

            Smartworks.ColumnField[] iECatagory = new Smartworks.ColumnField[4];
            iECatagory[0] = new Smartworks.ColumnField("@DESCRIPTION", DESCRIPTION);
            iECatagory[1] = new Smartworks.ColumnField("@AddedBy", AddedBy);
            iECatagory[2] = new Smartworks.ColumnField("@AddedOn", AddedOn);
            iECatagory[3] = new Smartworks.ColumnField("@AddedIpAddr", AddedIpAddr);
            dataAccess.BeginTransaction();
            id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.InsertExpenseCatagory", iECatagory));
            dataAccess.TransCommit();
            return id;

        }



        public void UpdateExpenseCatagory(int ExpenseCatagoryId, string DESCRIPTION, int UpdatedBy, DateTime UpdatedOn, string UpdatedIpAddr)
        {
            Smartworks.ColumnField[] uExpenseCatagory = new Smartworks.ColumnField[5];
            uExpenseCatagory[0] = new Smartworks.ColumnField("@ExpenseCatagoryId", ExpenseCatagoryId);
            uExpenseCatagory[1] = new Smartworks.ColumnField("@DESCRIPTION", DESCRIPTION);
            uExpenseCatagory[2] = new Smartworks.ColumnField("@UpdatedBy    ", UpdatedBy);
            uExpenseCatagory[3] = new Smartworks.ColumnField("@UpdatedOn    ", UpdatedOn);
            uExpenseCatagory[4] = new Smartworks.ColumnField("@UpdatedIpAddr", UpdatedIpAddr);

            dataAccess.BeginTransaction();
            dataAccess.ExecuteStoredProcedure("dbo.UpdateExpenseCatagory", uExpenseCatagory);
            dataAccess.TransCommit();
        }


        public int DeleteExpenseCatagory(string ExpenseCatagoryId)
        {
            int id;

            Smartworks.ColumnField[] dExpenseCatagory = new Smartworks.ColumnField[1];
            dExpenseCatagory[0] = new Smartworks.ColumnField("@ExpenseCatagoryId", ExpenseCatagoryId);
            dataAccess.BeginTransaction();
            id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.DeleteExpenseCatagory", dExpenseCatagory));
            dataAccess.TransCommit();
            return id;
        }
        public DataTable GetAllExpenseCatagory()
        {
            return dataAccess.getDataTable("select ExpenseCatagoryId , DESCRIPTION from ExpenseCatagory");
        }
        public DataTable GetExpenseCatagory(int ExpenseCatagoryId)
        {

            DataTable dt;
            dt = dataAccess.getDataTable("Select * from ExpenseCatagory where ExpenseCatagoryId  =" + ExpenseCatagoryId);
            return dt;
        }

        public DataTable GetExpenseCatagoryList()
        {
            DataTable dt = new DataTable();
            dt = dataAccess.getDataTable("Select ExpenseCatagoryId , upper(left(Name, 1)) + right(Name, len(Name) - 1) as DESCRIPTION  from ExpenseCatagory Order by Name ");
            return dt;
        }

        #endregion
    }
}

