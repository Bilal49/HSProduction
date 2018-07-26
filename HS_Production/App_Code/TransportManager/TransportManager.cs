using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;

namespace FIL
{
    class TransportManager
    {
  
            Smartworks.DAL dataAccess = new Smartworks.DAL();
            public TransportManager()
            {

                string connString = ConfigurationManager.ConnectionStrings["HSConnectionString"].ConnectionString;
                Smartworks.DAL.ConnectionString = connString;
            }

            public int InsertTransport(string TransportName, int AddedBy, DateTime AddedOn,
                                         string AddedIpAddr)
            {
                int id = 0;

                Smartworks.ColumnField[] iTransportCatagory = new Smartworks.ColumnField[4];
                iTransportCatagory[0] = new Smartworks.ColumnField("@TransportName", TransportName);
                iTransportCatagory[1] = new Smartworks.ColumnField("@AddedBy", AddedBy);
                iTransportCatagory[2] = new Smartworks.ColumnField("@AddedOn", AddedOn);
                iTransportCatagory[3] = new Smartworks.ColumnField("@AddedIpAddr", AddedIpAddr);
                dataAccess.BeginTransaction();
                id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.InsertTransport", iTransportCatagory));
                dataAccess.TransCommit();
                return id;

            }

            public void UpdateTransport(int TransportId, string TransportName, int UpdatedBy, DateTime UpdatedOn, string UpdatedIpAddr)
            {
                Smartworks.ColumnField[] uTransportCatagory = new Smartworks.ColumnField[5];
                uTransportCatagory[0] = new Smartworks.ColumnField("@TransportId", TransportId);
                uTransportCatagory[1] = new Smartworks.ColumnField("@TransportName", TransportName);
                uTransportCatagory[2] = new Smartworks.ColumnField("@UpdatedBy    ", UpdatedBy);
                uTransportCatagory[3] = new Smartworks.ColumnField("@UpdatedOn    ", UpdatedOn);
                uTransportCatagory[4] = new Smartworks.ColumnField("@UpdatedIpAddr", UpdatedIpAddr);

                dataAccess.BeginTransaction();
                dataAccess.ExecuteStoredProcedure("dbo.UpdateTransport", uTransportCatagory);
                dataAccess.TransCommit();
            }


            public int DeleteTransport(string TransportId)
            {
                int id;

                Smartworks.ColumnField[] dTransport = new Smartworks.ColumnField[1];
                dTransport[0] = new Smartworks.ColumnField("@TransportId", TransportId);
                dataAccess.BeginTransaction();
                id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.DeleteTransport", dTransport));
                dataAccess.TransCommit();
                return id;
            }
            public DataTable GetAllTransport()
            {
                return dataAccess.getDataTable("select TransportId , TransportName from Transport");
            }
            public DataTable GetTransport(int TransportId)
            {

                DataTable dt;
                dt = dataAccess.getDataTable("Select * from Transport where TransportId  =" + TransportId);
                return dt;
            }

            public DataTable GetTransportList()
            {
                DataTable dt = new DataTable();
                dt = dataAccess.getDataTable("Select TransportId , upper(left(TransportName, 1)) + right(TransportName, len(TransportName) - 1) as TransportName  from Transport Order by TransportName");
                return dt;
            }

            public int GetTransportIdById(int Id)
            {
                int TransportId = -1;
                DataTable dt = new DataTable();
                dt = dataAccess.getDataTable("Select TransportId from Transport where TransportId = '" + Id + "' ");
                if (dt.Rows.Count > 0)
                {
                    TransportId = (int)dt.Rows[0]["TransportId"];
                }
                return TransportId;
            }
        
    }
}
