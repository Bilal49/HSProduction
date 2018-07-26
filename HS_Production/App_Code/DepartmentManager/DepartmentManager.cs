using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;

namespace FIL
{
    public class DepartmentManager
    {
        Smartworks.DAL dataAccess = new Smartworks.DAL();
        public DepartmentManager()
        {

            string connString = ConfigurationManager.ConnectionStrings["HSConnectionString"].ConnectionString;
            Smartworks.DAL.ConnectionString = connString;
        }
        public int InsertDepartment(string DepartmentName, int AddedBy, DateTime AddedOn,
                                     string AddedIpAddr)
        {
            int id = 0;

            Smartworks.ColumnField[] iDepartmentCatagory = new Smartworks.ColumnField[4];
            iDepartmentCatagory[0] = new Smartworks.ColumnField("@DepartmentName", DepartmentName);
            iDepartmentCatagory[1] = new Smartworks.ColumnField("@AddedBy", AddedBy);
            iDepartmentCatagory[2] = new Smartworks.ColumnField("@AddedOn", AddedOn);
            iDepartmentCatagory[3] = new Smartworks.ColumnField("@AddedIpAddr", AddedIpAddr);
            dataAccess.BeginTransaction();
            id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.InsertDepartment", iDepartmentCatagory));
            dataAccess.TransCommit();
            return id;

        }

        public void UpdateDepartment(int DepartmentId, string DepartmentName, int UpdatedBy, DateTime UpdatedOn, string UpdatedIpAddr)
        {
            Smartworks.ColumnField[] uDepartmentCatagory = new Smartworks.ColumnField[5];
            uDepartmentCatagory[0] = new Smartworks.ColumnField("@DepartmentId", DepartmentId);
            uDepartmentCatagory[1] = new Smartworks.ColumnField("@DepartmentName", DepartmentName);
            uDepartmentCatagory[2] = new Smartworks.ColumnField("@UpdatedBy", UpdatedBy);
            uDepartmentCatagory[3] = new Smartworks.ColumnField("@UpdatedOn", UpdatedOn);
            uDepartmentCatagory[4] = new Smartworks.ColumnField("@UpdatedIpAddr", UpdatedIpAddr);

            dataAccess.BeginTransaction();
            dataAccess.ExecuteStoredProcedure("dbo.UpdateDepartment", uDepartmentCatagory);
            dataAccess.TransCommit();
        }


        public int DeleteDepartment(string DepartmentId)
        {
            int id;

            Smartworks.ColumnField[] dDepartment = new Smartworks.ColumnField[1];
            dDepartment[0] = new Smartworks.ColumnField("@DepartmentId", DepartmentId);
            dataAccess.BeginTransaction();
            id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.DeleteDepartment", dDepartment));
            dataAccess.TransCommit();
            return id;
        }
        public DataTable GetAllDepartment()
        {
            return dataAccess.getDataTable("select DepartmentId , DepartmentName from Department");
        }
        public DataTable GetDepartment(int DepartmentId)
        {

            DataTable dt;
            dt = dataAccess.getDataTable("Select * from Department where DepartmentId  =" + DepartmentId);
            return dt;
        }

        public DataTable GetDepartmentList()
        {
            DataTable dt = new DataTable();
            dt = dataAccess.getDataTable("Select DepartmentId , upper(left(DepartmentName, 1)) + right(DepartmentName, len(DepartmentName) - 1) as DepartmentName  from Department Order by DepartmentName ");
            return dt;
        }

        public int GetDepartmentIdById(int Id)
        {
            int DepartmentId = -1;
            DataTable dt = new DataTable();
            dt = dataAccess.getDataTable("Select DepartmentId from Department where DepartmentId= '" + Id + "' ");
            if (dt.Rows.Count > 0)
            {
                DepartmentId = (int)dt.Rows[0]["DepartmentId"];
            }
            return DepartmentId;
        }

    }
}

