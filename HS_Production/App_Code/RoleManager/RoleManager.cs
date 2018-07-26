using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;

using System.Xml.Linq;
using System.Data.SqlClient;


    /// <summary>
    /// Summary description for RoleManager
    /// </summary>
    public class RoleManager
    {
        Smartworks.DAL dataAccess = new Smartworks.DAL();
        public RoleManager()
        {
            string connString = ConfigurationManager.ConnectionStrings["HSConnectionString"].ConnectionString;
            Smartworks.DAL.ConnectionString = connString;
        }

        public int InsertRole(string RoleName)
        {
            int intValue;
            Smartworks.ColumnField[] iRoleManager = new Smartworks.ColumnField[1];
            iRoleManager[0] = new Smartworks.ColumnField("@RoleName", RoleName);

            dataAccess.BeginTransaction();
            intValue = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.InsertRole", iRoleManager));
            dataAccess.TransCommit();
            return intValue;
        }

        public void UpdateRole(int RoleId, string RoleName)
        {

            Smartworks.ColumnField[] uRoleManager = new Smartworks.ColumnField[2];
            uRoleManager[0] = new Smartworks.ColumnField("@RoleId", RoleId);
            uRoleManager[1] = new Smartworks.ColumnField("@RoleName", RoleName);

            dataAccess.BeginTransaction();
            dataAccess.ExecuteStoredProcedure("dbo.UpdateRole", uRoleManager);
            dataAccess.TransCommit();
        }



        public void DeleteRole(int RoleId)
        {


            Smartworks.ColumnField[] dRoleManager = new Smartworks.ColumnField[1];
            dRoleManager[0] = new Smartworks.ColumnField("@RoleId", RoleId);
            dataAccess.BeginTransaction();
            dataAccess.ExecuteStoredProcedure("dbo.DeleteRole", dRoleManager);
            dataAccess.TransCommit();


        }

        public DataTable GetAllRoles()
        {
            return dataAccess.getDataTable("select * from usertype ");
        }

        public DataTable GetRolesById(int roleId)
        {

            DataTable dt;
            Smartworks.ColumnField[] gRole = new Smartworks.ColumnField[1];
            gRole[0] = new Smartworks.ColumnField("@RoleId", roleId);


            dt = dataAccess.getDataTableByStoredProcedure("dbo.GetRolesByRoleId", gRole);


            return dt;



        }

        #region RoleIntoUserId


        public int GetRoleIntoUserIdAgainstRole(int roleid)
        {
            int id;
            Smartworks.ColumnField[] GetRoleManager = new Smartworks.ColumnField[1];
            GetRoleManager[0] = new Smartworks.ColumnField("@RoleId", roleid);
            dataAccess.BeginTransaction();
            id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.GetRoleIntoUserIdAgainstRole", GetRoleManager));
            dataAccess.TransCommit();
            return id;



        }

        #endregion

        public DataTable GetRolesAgainstRolePrivilege()
        {


            DataTable dt;
            string queryString = " SELECT dbo.Roles.RoleName, dbo.Roles.RoleId" +
                                 " FROM dbo.RolePrivilege INNER JOIN" +
                                 " dbo.Roles ON dbo.RolePrivilege.RoleId = dbo.Roles.RoleId" +
                                 " GROUP BY dbo.Roles.RoleName, dbo.Roles.RoleId ";
            dataAccess.ConnectionOpen();
            dt = dataAccess.getDataTable(queryString);
            dataAccess.ConnectionClose();

            return dt;




            return dt;

        }

        public void DeleteRolesAgainstRolePrivilege(int RoleId)
        {


            Smartworks.ColumnField[] dRoleManager = new Smartworks.ColumnField[1];
            dRoleManager[0] = new Smartworks.ColumnField("@RoleId", RoleId);
            dataAccess.BeginTransaction();
            dataAccess.ExecuteStoredProcedure("dbo.DeleteRoleAgainstRolePrivilege", dRoleManager);
            dataAccess.TransCommit();

        }

    }

