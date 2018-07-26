using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Data.SqlClient;

    public class RolePrivilegeManager
    {
        Smartworks.DAL dataAccess = new Smartworks.DAL();

        public RolePrivilegeManager()
        {
            string connString = ConfigurationManager.ConnectionStrings["HSConnectionString"].ConnectionString;
            Smartworks.DAL.ConnectionString = connString;
        }

        public int InsertRolePrivilege(int roleId, int menuId, bool allowPrivilege, bool addPrivilege, bool editPrivilege, bool deletePrivilege, bool postPrivilege)
        {
            int Id = 0;

            Smartworks.ColumnField[] iRolePrivilege = new Smartworks.ColumnField[7];
            iRolePrivilege[0] = new Smartworks.ColumnField("@RoleId", roleId);
            iRolePrivilege[1] = new Smartworks.ColumnField("@MenuId", menuId);

            iRolePrivilege[2] = new Smartworks.ColumnField("@AllowPrivilege", allowPrivilege);
            iRolePrivilege[3] = new Smartworks.ColumnField("@AddPrivilege", addPrivilege);
            iRolePrivilege[4] = new Smartworks.ColumnField("@EditPrivilege", editPrivilege);
            iRolePrivilege[5] = new Smartworks.ColumnField("@DeletePrivilege", deletePrivilege);
            iRolePrivilege[6] = new Smartworks.ColumnField("@PostPrivilege", postPrivilege);
          

            dataAccess.BeginTransaction();
            Id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.InsertRolePrivilege", iRolePrivilege));
            dataAccess.TransCommit();

            return Id;
        }

        public void UpdateRolePrivilege(int rolePrivilegeId, bool allowPrivilege , bool addPrivilege, bool editPrivilege, bool deletePrivilege, bool postPrivilege)
        {
            Smartworks.ColumnField[] uRolePrivilege = new Smartworks.ColumnField[6];
            uRolePrivilege[0] = new Smartworks.ColumnField("@RolePrivilegeId", rolePrivilegeId);
            uRolePrivilege[1] = new Smartworks.ColumnField("@AllowPrivilege", rolePrivilegeId);            
            uRolePrivilege[2] = new Smartworks.ColumnField("@AddPrivilege", addPrivilege);
            uRolePrivilege[3] = new Smartworks.ColumnField("@EditPrivilege", editPrivilege);
            uRolePrivilege[4] = new Smartworks.ColumnField("@DeletePrivilege", deletePrivilege);
            uRolePrivilege[5] = new Smartworks.ColumnField("@PostPrivilege", postPrivilege);


            dataAccess.BeginTransaction();
            dataAccess.ExecuteStoredProcedure("UpdateRolePrivilege", uRolePrivilege);
            dataAccess.TransCommit();
        }

        public void DeleteRolePrivilege(int rolePrivilegeId)
        {
            Smartworks.ColumnField[] dRolePrivilege = new Smartworks.ColumnField[1];
            dRolePrivilege[0] = new Smartworks.ColumnField("@RolePrivilegeId", rolePrivilegeId);

            dataAccess.BeginTransaction();
            dataAccess.ExecuteStoredProcedure("dbo.DeleteRolePrivilege", dRolePrivilege);
            dataAccess.TransCommit();

        }

        public void DeleteRolePrivilegeByMenu(int menuId)
        {

            Smartworks.ColumnField[] dRolePrivilege = new Smartworks.ColumnField[1];
            dRolePrivilege[0] = new Smartworks.ColumnField("@MenuId", menuId);

            dataAccess.BeginTransaction();
            dataAccess.ExecuteStoredProcedure("dbo.DeleteRolePrivilegeByMenu", dRolePrivilege);
            dataAccess.TransCommit();

        }

        //public void DeleteRolePrivilegeBy(int menuId)
        //{

        //    Smartworks.ColumnField[] dRolePrivilege = new Smartworks.ColumnField[1];
        //    dRolePrivilege[0] = new Smartworks.ColumnField("@MenuId", menuId);

        //    dataAccess.BeginTransaction();
        //    dataAccess.ExecuteStoredProcedure("dbo.DeleteRolePrivilegeByMenu", dRolePrivilege);
        //    dataAccess.TransCommit();

        //}

        public DataSet GetMenu()
        {

            DataSet ds;
            string queryString = " Select *  From Menu where IsParent=1";
            dataAccess.ConnectionOpen();
            ds = dataAccess.getDataSet(queryString);
            dataAccess.ConnectionClose();

            return ds;
        }

  //      public DataTable GetRolePrivilege(int roleId)
  //      {
  //          DataTable dt;
  //          //string queryString = " SELECT dbo.Menu.MenuName, dbo.Menu.MenuId, dbo.RolePrivilege.* " +
  //          //                     " FROM dbo.RolePrivilege INNER JOIN " +
  //          //                     " dbo.Menu ON dbo.RolePrivilege.MenuId = dbo.Menu.MenuId and " +
  //          //                     " dbo.RolePrivilege.RoleId = " + roleId;

  //          string queryString = "  SELECT user_privilege.roleId, " +
  //" Isnull(dbo.user_privilege.Privilege_Id , -1) as Privilege_Id, " +
  // "  Isnull(dbo.user_privilege.Menu_Id , Menu.MenuId ) as Menu_Id," +
  //  " Isnull(dbo.user_privilege.Privilege_Allow , 0 ) as Privilege_Allow,  isnull(dbo.user_privilege.Privilege_Add , 0) as Privilege_Add, " +
  // " isnull(dbo.user_privilege.Privilege_Edit , 0) as Privilege_Edit, isnull(dbo.user_privilege.Privilege_Delete , 0) as Privilege_Delete, " +
  //  " isnull(dbo.user_privilege.Privilege_Post , 0) as Privilege_Post , Menu.MenuItemTitle as MenuName " +


  //  "    from Menu  " +
  //       " left join user_privilege on   user_privilege.Menu_Id =  Menu.MenuId   " +
  //         " left join usertype on usertype.typeid=user_privilege.roleId " +
  //        "    where dbo.user_privilege.RoleId = " + roleId + "  or dbo.user_privilege.RoleId  is null";

  //    //" FROM dbo.user_privilege"+
  //    // "       inner join usertype on usertype.typeid=user_privilege.roleId"+
  //    // " left  join Menu on  user_privilege.Menu_Id =  Menu.MenuId  " +
  //    //                            " where dbo.user_privilege.RoleId = " + roleId;

          

  //          dataAccess.ConnectionOpen();
  //          dt = dataAccess.getDataTable(queryString);
  //          dataAccess.ConnectionClose();

  //          return dt;

  //      }

        public DataTable GetRolePrivilege(int roleId)
        {
            DataTable dtRolePrivilege = new DataTable();
            Smartworks.ColumnField[] gUserPrivilege = new Smartworks.ColumnField[1];
            gUserPrivilege[0] = new Smartworks.ColumnField("@RoleId", roleId);
            dtRolePrivilege = dataAccess.getDataTableByStoredProcedure("GetPrivilegeByRoleId", gUserPrivilege);
            return dtRolePrivilege;
        }


        public int GetRoleByUserId(int userId)
        {
            DataTable dt;
            string queryString = " Select *  From [User_crm] where UserId=" + userId;
            dataAccess.ConnectionOpen();
            dt = dataAccess.getDataTable(queryString);
            dataAccess.ConnectionClose();

            return Convert.ToInt32(dt.Rows[0]["userId"]);
        }

    }



