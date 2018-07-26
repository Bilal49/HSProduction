using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;

namespace FIL
{
    public class CityManager : Test
    {
        Smartworks.DAL dataAccess = new Smartworks.DAL();
        public CityManager()
        {

            string connString = ConfigurationManager.ConnectionStrings["HSConnectionString"].ConnectionString;
            Smartworks.DAL.ConnectionString = connString;
        }

        public override string GetUserName()
        {
            CityManager city = new CityManager();
            city.GetCityVirt();
            city.AddTwoNumbers(1, 1);
            return "ok";
        }
        public void StepA()
        {

        }

        public virtual void GetCityVirt()
        {
 
        }

       

        

        public int InsertCity(string CityName, int AddedBy, DateTime AddedOn,
                                     string AddedIpAddr)
        {
            int id = 0;

            Smartworks.ColumnField[] iCityCatagory = new Smartworks.ColumnField[4];
            iCityCatagory[0] = new Smartworks.ColumnField("@CityName", CityName);
            iCityCatagory[1] = new Smartworks.ColumnField("@AddedBy", AddedBy);
            iCityCatagory[2] = new Smartworks.ColumnField("@AddedOn", AddedOn);
            iCityCatagory[3] = new Smartworks.ColumnField("@AddedIpAddr", AddedIpAddr);
            dataAccess.BeginTransaction();
            id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.InsertCity", iCityCatagory));
            dataAccess.TransCommit();
            return id;

        }

        public void UpdateCity(int CityId, string CityName, int UpdatedBy, DateTime UpdatedOn, string UpdatedIpAddr)
        {
            Smartworks.ColumnField[] uCityCatagory = new Smartworks.ColumnField[5];
            uCityCatagory[0] = new Smartworks.ColumnField("@CityId", CityId);
            uCityCatagory[1] = new Smartworks.ColumnField("@CityName", CityName);
            uCityCatagory[2] = new Smartworks.ColumnField("@UpdatedBy    ", UpdatedBy);
            uCityCatagory[3] = new Smartworks.ColumnField("@UpdatedOn    ", UpdatedOn);
            uCityCatagory[4] = new Smartworks.ColumnField("@UpdatedIpAddr", UpdatedIpAddr);

            dataAccess.BeginTransaction();
            dataAccess.ExecuteStoredProcedure("dbo.UpdateCity", uCityCatagory);
            dataAccess.TransCommit();
        }


        public int DeleteCity(string CityId)
        {
            int id;

            Smartworks.ColumnField[] dCity = new Smartworks.ColumnField[1];
            dCity[0] = new Smartworks.ColumnField("@CityId", CityId);
            dataAccess.BeginTransaction();
            id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.DeleteCity", dCity));
            dataAccess.TransCommit();
            return id;
        }
        public DataTable GetAllCity()
        {
            return dataAccess.getDataTable("select CityId , City from City");
        }
        public DataTable GetCity(int CityId)
        {

            DataTable dt;
            dt = dataAccess.getDataTable("Select * from City where CityId  =" + CityId);
            return dt;
        }

        public DataTable GetCityList()
        {
            DataTable dt = new DataTable();
            dt = dataAccess.getDataTable("Select CityId , upper(left(CityName, 1)) + right(CityName, len(CityName) - 1) as CityName  from City Order by CityName ");
            return dt;
        }

        public int GetCityIdById(int Id)
        {
            int CityId = -1;
            DataTable dt = new DataTable();
            dt = dataAccess.getDataTable("Select CityId from City where CityId= '" + Id + "' ");
            if (dt.Rows.Count > 0)
            {
                CityId = (int)dt.Rows[0]["CityId"];
            }
            return CityId;
        }

    }
}

