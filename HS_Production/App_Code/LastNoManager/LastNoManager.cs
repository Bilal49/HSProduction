using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;

namespace FIL
{
    public class LastNoManager
    {
        Smartworks.DAL dataAccess = new Smartworks.DAL();
        public LastNoManager()
        {

            string connString = ConfigurationManager.ConnectionStrings["HSConnectionString"].ConnectionString;
            Smartworks.DAL.ConnectionString = connString;
        }
        public int InsertLastNo(string LastNo, int AddedBy, DateTime AddedOn,
                                     string AddedIpAddr)
        {
            int id = 0;

            Smartworks.ColumnField[] iLastNoCatagory = new Smartworks.ColumnField[4];
            iLastNoCatagory[0] = new Smartworks.ColumnField("@LastNo", LastNo);
            iLastNoCatagory[1] = new Smartworks.ColumnField("@AddedBy", AddedBy);
            iLastNoCatagory[2] = new Smartworks.ColumnField("@AddedOn", AddedOn);
            iLastNoCatagory[3] = new Smartworks.ColumnField("@AddedIpAddr", AddedIpAddr);
            dataAccess.BeginTransaction();
            id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.InsertLastNo", iLastNoCatagory));
            dataAccess.TransCommit();
            return id;

        }

        public void UpdateLastNo(int LastNoId, string LastNo, int UpdatedBy, DateTime UpdatedOn, string UpdatedIpAddr)
        {
            Smartworks.ColumnField[] uLastNoCatagory = new Smartworks.ColumnField[5];
            uLastNoCatagory[0] = new Smartworks.ColumnField("@LastNoId", LastNoId);
            uLastNoCatagory[1] = new Smartworks.ColumnField("@LastNo", LastNo);
            uLastNoCatagory[2] = new Smartworks.ColumnField("@UpdatedBy    ", UpdatedBy);
            uLastNoCatagory[3] = new Smartworks.ColumnField("@UpdatedOn    ", UpdatedOn);
            uLastNoCatagory[4] = new Smartworks.ColumnField("@UpdatedIpAddr", UpdatedIpAddr);

            dataAccess.BeginTransaction();
            dataAccess.ExecuteStoredProcedure("dbo.UpdateLastNo", uLastNoCatagory);
            dataAccess.TransCommit();
        }


        public int DeleteLastNo(string LastNoId)
        {
            int id;

            Smartworks.ColumnField[] dLastNo = new Smartworks.ColumnField[1];
            dLastNo[0] = new Smartworks.ColumnField("@LastNoId", LastNoId);
            dataAccess.BeginTransaction();
            id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.DeleteLastNo", dLastNo));
            dataAccess.TransCommit();
            return id;
        }
        public DataTable GetAllLastNo()
        {
            return dataAccess.getDataTable("select LastNoId , LastNo from LastNo");
        }
        public DataTable GetLastNo(int LastNoId)
        {

            DataTable dt;
            dt = dataAccess.getDataTable("Select * from LastNo where LastNoId  =" + LastNoId);
            return dt;
        }

        public DataTable GetLastNoList()
        {
            DataTable dt = new DataTable();
            dt = dataAccess.getDataTable("Select LastNoId , upper(left(LastNo, 1)) + right(LastNo, len(LastNo) - 1) as LastNo  from LastNo Order by LastNo ");
            return dt;
        }

        public int GetLastNoIdById(int Id)
        {
            int LastNoId = -1;
            DataTable dt = new DataTable();
            dt = dataAccess.getDataTable("Select LastNoId from LastNo where LastNoId= '" + Id + "' ");
            if (dt.Rows.Count > 0)
            {
                LastNoId = (int)dt.Rows[0]["LastNoId"];
            }
            return LastNoId;
        }

    }
}

