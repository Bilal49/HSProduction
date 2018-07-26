using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;


public class MenuManager
{
    Smartworks.DAL dataAccess = new Smartworks.DAL();

    public MenuManager()
    {
        string connString = ConfigurationManager.ConnectionStrings["HSConnectionString"].ConnectionString;
        
        Smartworks.DAL.ConnectionString = connString;
    }


    public int InsertMenu(string menu, string parentName, int parent, bool isParent, bool isReport)
    {
        int Id = 0;

        Smartworks.ColumnField[] iMenu = new Smartworks.ColumnField[5];
        iMenu[0] = new Smartworks.ColumnField("@MenuName", menu);
        iMenu[1] = new Smartworks.ColumnField("@ParentName", parentName);
        iMenu[2] = new Smartworks.ColumnField("@Parent", parent);
        iMenu[3] = new Smartworks.ColumnField("@IsParent", isParent);
        iMenu[4] = new Smartworks.ColumnField("@IsReport", isReport);

        dataAccess.BeginTransaction();
        Id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.InsertMenu", iMenu));
        dataAccess.TransCommit();

        return Id;

    }

    public void DeleteMenu(int menuId)
    {
        Smartworks.ColumnField[] dMenu = new Smartworks.ColumnField[1];
        dMenu[0] = new Smartworks.ColumnField("@MenuId", menuId);

        dataAccess.BeginTransaction();
        dataAccess.ExecuteStoredProcedure("dbo.DeleteMenu", dMenu);
        dataAccess.TransCommit();
    }

    public void DeleteMenuByParent(string parentName)
    {
        Smartworks.ColumnField[] dMenu = new Smartworks.ColumnField[1];
        dMenu[0] = new Smartworks.ColumnField("@ParentName", parentName);

        dataAccess.BeginTransaction();
        dataAccess.ExecuteStoredProcedure("dbo.DeleteMenuByParent", dMenu);
        dataAccess.TransCommit();
    }



    public int UpdateMenu(int menuId, string menuName, string parentName, int parent, bool isParent , bool isReport)
    {
        int Id = 0;

        Smartworks.ColumnField[] uMenu = new Smartworks.ColumnField[6];
        uMenu[0] = new Smartworks.ColumnField("@MenuId", menuId);
        uMenu[1] = new Smartworks.ColumnField("@MenuName", menuName);
        uMenu[2] = new Smartworks.ColumnField("@ParentName", parentName);
        uMenu[3] = new Smartworks.ColumnField("@Parent", parent);
        uMenu[4] = new Smartworks.ColumnField("@IsParent", isParent);
        uMenu[5] = new Smartworks.ColumnField("@IsReport", isReport);



        dataAccess.BeginTransaction();
        Id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.UpdateMenu", uMenu));
        dataAccess.TransCommit();

        return Id;
    }

    public DataTable GetMenuById(int menuId)
    {
        DataSet ds;
        string queryString = "SELECT    * FROM         Menu WHERE MenuId=" + menuId;
        //iscrm=1 and
        dataAccess.ConnectionOpen();
        ds = dataAccess.getDataSet(queryString);
        dataAccess.ConnectionClose();

        return ds.Tables[0];
    }

    public DataTable GetMenu()
    {
        DataSet ds;

        string queryString = "SELECT    * FROM         Menu "; //where iscrm =1
        dataAccess.ConnectionOpen();
        ds = dataAccess.getDataSet(queryString);
        dataAccess.ConnectionClose();
        return ds.Tables[0];
    }

    public DataSet GetMenus()
    {
        DataSet ds;

        string queryString = "SELECT    * FROM         Menu "; //where iscrm =1
        dataAccess.ConnectionOpen();
        ds = dataAccess.getDataSet(queryString);
        dataAccess.ConnectionClose();
        return ds;
    }
}
