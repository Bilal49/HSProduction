using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


public class AssetsManager
{
    #region AssetsCategoryMethods

    Smartworks.DAL dataAccess = new Smartworks.DAL();

    public int InsertAssetsCatagory(string CategoryName, int AddedBy, DateTime AddedOn, string AddedIpAddr)
    {
        int id = 0;

        Smartworks.ColumnField[] iAssetsCatagory = new Smartworks.ColumnField[4];
        iAssetsCatagory[0] = new Smartworks.ColumnField("@CategoryName", CategoryName);
        iAssetsCatagory[1] = new Smartworks.ColumnField("@AddedBy", AddedBy);
        iAssetsCatagory[2] = new Smartworks.ColumnField("@AddedOn", AddedOn);
        iAssetsCatagory[3] = new Smartworks.ColumnField("@AddedIpAddr", AddedIpAddr);
        dataAccess.BeginTransaction();
        id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.InsertAssetsCategory", iAssetsCatagory));
        dataAccess.TransCommit();
        return id;

    }



    public void UpdateAssetsCategory(int AssetsCategoryId, string CategoryName, int UpdatedBy, DateTime UpdatedOn, string UpdatedIpAddr)
    {
        Smartworks.ColumnField[] uAssetsCategory = new Smartworks.ColumnField[5];
        uAssetsCategory[0] = new Smartworks.ColumnField("@AssetsCategoryId", AssetsCategoryId);
        uAssetsCategory[1] = new Smartworks.ColumnField("@CategoryName", CategoryName);
        uAssetsCategory[2] = new Smartworks.ColumnField("@UpdatedBy", UpdatedBy);
        uAssetsCategory[3] = new Smartworks.ColumnField("@UpdatedOn", UpdatedOn);
        uAssetsCategory[4] = new Smartworks.ColumnField("@UpdatedIpAddr", UpdatedIpAddr);

        dataAccess.BeginTransaction();
        dataAccess.ExecuteStoredProcedure("dbo.UpdateAssetsCategory", uAssetsCategory);
        dataAccess.TransCommit();
    }


    public int DeleteAssetsCategory(string AssetsCategoryId)
    {
        int id;

        Smartworks.ColumnField[] dAssetsCategory = new Smartworks.ColumnField[1];
        dAssetsCategory[0] = new Smartworks.ColumnField("@AssetsCategoryId", AssetsCategoryId);

        dataAccess.BeginTransaction();
        id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.DeleteAssetsCategory", dAssetsCategory));

        dataAccess.TransCommit();

        return id;
    }
    public DataTable GetAllAssetsCategory()
    {
        return dataAccess.getDataTable("select AssetsCategoryId , CategoryName from AssetsCategory");
    }
    public DataTable GetAssetsCategory(int AssetsCategoryId)
    {

        DataTable dt;
        dt = dataAccess.getDataTable("Select * from AssetsCategory where AssetsCategoryId  =" + AssetsCategoryId);
        return dt;
    }
    public int GetAssetsCategoryIdByCode(int AssetsCategoryId)
    {
        int GetAssetsCategoryId = -1;
        DataTable dt = new DataTable();
        dt = dataAccess.getDataTable("Select AssetsCategoryId from AssetsCategory where AssetsCategoryId  = '" + AssetsCategoryId + "' ");
        if (dt.Rows.Count > 0)
        {
            GetAssetsCategoryId = Convert.ToInt32(dt.Rows[0]["AssetsCategoryId"]);
        }
        return GetAssetsCategoryId;
    }
    public DataTable GetAssetsCategoryList()
    {
        DataTable dt = new DataTable();
        dt = dataAccess.getDataTable("Select AssetsCategoryId , upper(left(CategoryName, 1)) + right(CategoryName, len(CategoryName) - 1) as CategoryName  from AssetsCategory Order by CategoryName ");
        return dt;
    }

    #endregion
}

