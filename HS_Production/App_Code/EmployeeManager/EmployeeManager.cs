using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;

namespace FIL.App_Code.EmployeeManager
{
    class EmployeeManager
    {
        Smartworks.DAL dataAccess = new Smartworks.DAL();
        public EmployeeManager()
        {

            string connString = ConfigurationManager.ConnectionStrings["HSConnectionString"].ConnectionString;
            Smartworks.DAL.ConnectionString = connString;
        }


        public int InsertEmployee(string EmployeeName, string FatherName, string DepartmentId, string Gender,
                                 DateTime DOB, string NIC, string MaritalStatus, string Address, string HomePhone, string CellPhone,
                                 string Email, DateTime HireDate, string DesignationId, string Remarks, int PayrollId  , decimal Salery , bool IsMontly ,  int AddedBy, DateTime AddedOn,
                                 string AddedIpAddr)
        {
            int id = 0;

            Smartworks.ColumnField[] iEmployee = new Smartworks.ColumnField[20];
            iEmployee[0] = new Smartworks.ColumnField("@EmployeeName", EmployeeName);
            iEmployee[1] = new Smartworks.ColumnField("@FatherName", FatherName);
            iEmployee[2] = new Smartworks.ColumnField("@DepartmentId", DepartmentId);
            iEmployee[3] = new Smartworks.ColumnField("@Gender", Gender);
            iEmployee[4] = new Smartworks.ColumnField("@DOB", DOB);
            iEmployee[5] = new Smartworks.ColumnField("@NIC", NIC);
            iEmployee[6] = new Smartworks.ColumnField("@MaritalStatus", MaritalStatus);
            iEmployee[7] = new Smartworks.ColumnField("@Address", Address);
            iEmployee[8] = new Smartworks.ColumnField("@HomePhone", HomePhone);
            iEmployee[9] = new Smartworks.ColumnField("@CellPhone", CellPhone);
            iEmployee[10] = new Smartworks.ColumnField("@Email", Email);
            iEmployee[11] = new Smartworks.ColumnField("@HireDate", HireDate);
            iEmployee[12] = new Smartworks.ColumnField("@DesignationId", DesignationId);
            iEmployee[13] = new Smartworks.ColumnField("@Remarks", Remarks);
            iEmployee[14] = new Smartworks.ColumnField("@PayrollId", PayrollId);
            iEmployee[15] = new Smartworks.ColumnField("@Salery", Salery);
            iEmployee[16] = new Smartworks.ColumnField("@IsMontly", IsMontly);
            iEmployee[17] = new Smartworks.ColumnField("@AddedBy", AddedBy);
            iEmployee[18] = new Smartworks.ColumnField("@AddedOn", AddedOn);
            iEmployee[19] = new Smartworks.ColumnField("@AddedIpAddr", Address);
            dataAccess.BeginTransaction();
            id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.InsertEmployee", iEmployee));
            dataAccess.TransCommit();
            return id;

        }



        public void UpdateEmployee(int EmployeeId, string EmployeeName, string FatherName, String DepartmentId, string Gender,
                                 DateTime DOB, string NIC, string MaritalStatus, string Address, string HomePhone, string CellPhone,
                                 string Email, DateTime HireDate, String DesignationId, string Remarks, int PayrollId, decimal Salery, bool IsMontly, int UpdatedBy, DateTime UpdatedOn, string UpdatedIpAddr)
        {
            Smartworks.ColumnField[] uEmployee = new Smartworks.ColumnField[21];

            uEmployee[0] = new Smartworks.ColumnField("@EmployeeId", EmployeeId);
            uEmployee[1] = new Smartworks.ColumnField("@EmployeeName", EmployeeName);
            uEmployee[2] = new Smartworks.ColumnField("@FatherName", FatherName);
            uEmployee[3] = new Smartworks.ColumnField("@DepartmentId", DepartmentId);
            uEmployee[4] = new Smartworks.ColumnField("@Gender", Gender);
            uEmployee[5] = new Smartworks.ColumnField("@DOB", DOB);
            uEmployee[6] = new Smartworks.ColumnField("@NIC", NIC);
            uEmployee[7] = new Smartworks.ColumnField("@MaritalStatus", MaritalStatus);
            uEmployee[8] = new Smartworks.ColumnField("@Address", Address);
            uEmployee[9] = new Smartworks.ColumnField("@HomePhone", HomePhone);
            uEmployee[10] = new Smartworks.ColumnField("@CellPhone", CellPhone);
            uEmployee[11] = new Smartworks.ColumnField("@Email", Email);
            uEmployee[12] = new Smartworks.ColumnField("@HireDate", HireDate);
            uEmployee[13] = new Smartworks.ColumnField("@DesignationId", DesignationId);
            uEmployee[14] = new Smartworks.ColumnField("@Remarks", Remarks);
            uEmployee[15] = new Smartworks.ColumnField("@PayrollId", PayrollId);
            uEmployee[16] = new Smartworks.ColumnField("@Salery", Salery);
            uEmployee[17] = new Smartworks.ColumnField("@IsMontly", IsMontly);
            uEmployee[18] = new Smartworks.ColumnField("@UpdatedBy", UpdatedBy);
            uEmployee[19] = new Smartworks.ColumnField("@UpdatedOn", UpdatedOn);
            uEmployee[20] = new Smartworks.ColumnField("@UpdatedIpAddr", UpdatedIpAddr);

            dataAccess.BeginTransaction();
            dataAccess.ExecuteStoredProcedure("dbo.UpdateEmployee", uEmployee);
            dataAccess.TransCommit();
        }


        public int DeleteEmployee(string EmployeeId)
        {
            int id;

            Smartworks.ColumnField[] dEmployee = new Smartworks.ColumnField[1];
            dEmployee[0] = new Smartworks.ColumnField("@EmployeeId", EmployeeId);

            dataAccess.BeginTransaction();
            id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.DeleteEmployee", dEmployee));

            dataAccess.TransCommit();

            return id;
        }



        //public DataTable GetEmployeeByUserId(int UserId)
        //{

        //    DataTable dt;
        //    Smartworks.ColumnField[] gEmployee = new Smartworks.ColumnField[1];
        //    gEmployee[0] = new Smartworks.ColumnField("@UserId", UserId);
        //    dt = dataAccess.getDataTableByStoredProcedure("dbo.GetEmployee", gEmployee);
        //    return dt;
        //}


        public DataTable GetEmployee(int EmployeeId)
        {

            DataTable dt;
            dt = dataAccess.getDataTable("Select * from Employee where EmployeeId =" + EmployeeId);
            return dt;
        }



        public int GetEmployeeIdByCode(string Code)
        {
            int EmployeeId = -1;
            DataTable dt = new DataTable();
            dt = dataAccess.getDataTable("Select EmployeeId from Employee where Code = '" + Code + "' ");
            if (dt.Rows.Count > 0)
            {
                EmployeeId = (int)dt.Rows[0]["EmployeeId"];
            }
            return EmployeeId;
        }

        //public DataTable GetEmployee()
        //{

        //    DataTable dt;
        //    Smartworks.ColumnField[] gEmployee = new Smartworks.ColumnField[1];
        //    gEmployee[0] = new Smartworks.ColumnField("@result", true);

        //    dt = dataAccess.getDataTableByStoredProcedure("dbo.GetAllEmployee", gEmployee);

        //    return dt;
        //}



        public DataTable GetEmployeeList()
        {
            DataTable dt = new DataTable();
            dt = dataAccess.getDataTable("Select EmployeeId , upper(left(EmployeeName, 1)) + right(EmployeeName, len(EmployeeName) - 1) as EmployeeName  from Employee Order by EmployeeName ");
            return dt;

        }


    }
}
