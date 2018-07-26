using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

namespace FIL.App_Code.CompanyManager
{
    class CompanyManager
    {

          Smartworks.DAL dataAccess = new Smartworks.DAL();
          public CompanyManager()
        {

            string connString = ConfigurationManager.ConnectionStrings["HSConnectionString"].ConnectionString;
            Smartworks.DAL.ConnectionString = connString;
        }
          public int InsertUpdateCampony(string Name, string Address, string Phone, string Fax,
                                  String Email, string ContactPerson, string GSTNumber, string NTN, string Description, string Logo,
                                  int AddedBy, DateTime AddedOn,string AddedIpAddr)
          {
              int id = 0;
              Smartworks.ColumnField[] iCompany = new Smartworks.ColumnField[13];
              iCompany[0] = new Smartworks.ColumnField("@Name", Name);
              iCompany[1] = new Smartworks.ColumnField("@Address", Address);
              iCompany[2] = new Smartworks.ColumnField("@Phone", Phone);
              iCompany[3] = new Smartworks.ColumnField("@Fax", Fax);
              iCompany[4] = new Smartworks.ColumnField("@Email", Email);
              iCompany[5] = new Smartworks.ColumnField("@ContactPerson", ContactPerson);
              iCompany[6] = new Smartworks.ColumnField("@GSTNumber", GSTNumber);
              iCompany[7] = new Smartworks.ColumnField("@NTN", NTN);
              iCompany[8] = new Smartworks.ColumnField("@Description", Description);
              iCompany[9] = new Smartworks.ColumnField("@Logo", Logo);
              iCompany[10] = new Smartworks.ColumnField("@AddedBy", AddedBy);
              iCompany[11] = new Smartworks.ColumnField("@AddedOn", AddedOn);
              iCompany[12] = new Smartworks.ColumnField("@AddedIpAddr", Address);
              dataAccess.BeginTransaction();
              id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.InsertCompany", iCompany));
              dataAccess.TransCommit();
              return id;
          }
          public DataTable GetCompany()
          {
              DataTable dt;
              dt = dataAccess.getDataTable("Select * from Company");
              return dt;
          }

    }
}
