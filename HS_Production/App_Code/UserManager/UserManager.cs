using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Security.Cryptography;
using System.IO;



public class UserManager
{
    Smartworks.DAL dataAccess = new Smartworks.DAL();
    public UserManager()
    {
        string connString = ConfigurationManager.ConnectionStrings["HSConnectionString"].ConnectionString;
        Smartworks.DAL.ConnectionString = connString;
    }

    public DataTable GetUserName(string userName, string password)
    {
        DataTable dt = new DataTable();
        Smartworks.ColumnField[] GetUserManager = new Smartworks.ColumnField[2];
        GetUserManager[0] = new Smartworks.ColumnField("@UserName", userName);
        GetUserManager[1] = new Smartworks.ColumnField("@Password", Encrypt(password));
        try
        {
            dataAccess.ConnectionOpen();
            dt = dataAccess.getDataTableByStoredProcedure("dbo.GetUserName", GetUserManager);
            dataAccess.ConnectionClose();
        }
        catch (Exception ex)
        {
        }
        finally
        {
            dataAccess.ConnectionClose();
        }
        return dt;

    }

    public int InsertUserMaster(string UserName, string Password, string Name, int RoleId, bool IsActive)
    {
        int id;
        Smartworks.ColumnField[] iUserManager = new Smartworks.ColumnField[5];

        iUserManager[0] = new Smartworks.ColumnField("@UserName", UserName);
        iUserManager[1] = new Smartworks.ColumnField("@Password", Encrypt(Password));
        iUserManager[2] = new Smartworks.ColumnField("@Name", Name);
        iUserManager[3] = new Smartworks.ColumnField("@RoleId", RoleId);
        iUserManager[4] = new Smartworks.ColumnField("@IsActive", IsActive);


        dataAccess.BeginTransaction();
        id = Convert.ToInt32(dataAccess.ExecuteStoredProcedure("dbo.InsertUser", iUserManager));
        dataAccess.TransCommit();

        return id;
    }

    public void UpdateUserMaster(int UserId, string UserName, string Password, string Name, int RoleId, bool IsActive)
    {
        Smartworks.ColumnField[] uUserManager = new Smartworks.ColumnField[6];

        uUserManager[0] = new Smartworks.ColumnField("@UserId", UserId);
        uUserManager[1] = new Smartworks.ColumnField("@UserName", UserName);
        uUserManager[2] = new Smartworks.ColumnField("@Password", Encrypt(Password));
        uUserManager[3] = new Smartworks.ColumnField("@Name", Name);
        uUserManager[4] = new Smartworks.ColumnField("@RoleId", RoleId);
        uUserManager[5] = new Smartworks.ColumnField("@IsActive", IsActive);


        dataAccess.BeginTransaction();
        dataAccess.ExecuteStoredProcedure("dbo.UpdateUser ", uUserManager);
        dataAccess.TransCommit();
    }


    public DataTable GetUserByName(string UserName)
    {
        DataTable dt = new DataTable();
        dt = dataAccess.getDataTable("Select * from dbo.[User] where UserName = '" + UserName + "'");
        return dt;
    }

    public void DeleteUserId(int UserId)
    {
        Smartworks.ColumnField[] dUserManager = new Smartworks.ColumnField[1];
        dUserManager[0] = new Smartworks.ColumnField("UserId", UserId);
        dataAccess.BeginTransaction();
        dataAccess.ExecuteStoredProcedure("dbo.DeleteUser", dUserManager);
        dataAccess.TransCommit();
    }

    public void DeleteUsersByRole(int roleId)
    {
        Smartworks.ColumnField[] dUserManager = new Smartworks.ColumnField[1];
        dUserManager[0] = new Smartworks.ColumnField("RoleId", roleId);
        dataAccess.BeginTransaction();
        dataAccess.ExecuteStoredProcedure("dbo.DeleteUserByRole", dUserManager);
        dataAccess.TransCommit();
    }

    public DataTable GetUsersById(int userId)
    {

        DataTable dt;
        Smartworks.ColumnField[] gUser = new Smartworks.ColumnField[1];
        gUser[0] = new Smartworks.ColumnField("@UserId", userId);

        dt = dataAccess.getDataTableByStoredProcedure("dbo.GetUserByUserId", gUser);

        return dt;
    }

    public DataTable GetUsers(int subCompanyId)
    {

        DataTable dt;
        string queryString = " Select *  From [User]";
        dataAccess.ConnectionOpen();
        dt = dataAccess.getDataTable(queryString);
        dataAccess.ConnectionClose();

        return dt;
    }

    public DataTable GetUsers()
    {

        DataTable dt;
        string queryString = " Select *  From [User] ";

        dataAccess.ConnectionOpen();
        dt = dataAccess.getDataTable(queryString);
        dataAccess.ConnectionClose();

        return dt;
    }
    public DataTable GetUserType()
    {

        DataTable dt;
        Smartworks.ColumnField[] gUser = new Smartworks.ColumnField[1];
        gUser[0] = new Smartworks.ColumnField("@result", true);

        dt = dataAccess.getDataTableByStoredProcedure("dbo.GetUserType", gUser);

        return dt;
    }

    private string Encrypt(string clearText)
    {
        string EncryptionKey = "MAKV2SPBNI99212";
        byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(clearBytes, 0, clearBytes.Length);
                    cs.Close();
                }
                clearText = Convert.ToBase64String(ms.ToArray());
            }
        }
        return clearText;
    }

    public string Decrypt(string cipherText)
    {
        string EncryptionKey = "MAKV2SPBNI99212";
        byte[] cipherBytes = Convert.FromBase64String(cipherText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cipherBytes, 0, cipherBytes.Length);
                    cs.Close();
                }
                cipherText = Encoding.Unicode.GetString(ms.ToArray());
            }
        }
        return cipherText;
    }
    //public bool AuthenticateUser(string pageName)
    //{
    //    DataTable dt = null;
    //    bool status;

    //    if (HttpContext.Current.Session["UserInformation"] != null)
    //    {
    //        dt = (DataTable)HttpContext.Current.Session["UserInformation"];
    //        //formName = "SetUp";
    //        if (dt.Rows.Count > 0)
    //        {
    //            if (dt.Select("MenuName = '" + pageName + "'").Length > 0)
    //            {

    //                status = true;

    //            }

    //            else
    //            {
    //                status = false;
    //            }
    //        }
    //        else
    //        {
    //            status = false;

    //        }
    //    }
    //    else
    //    {
    //        status = false;
    //    }

    //    return status;
    //}

    public bool ApplicationExpire()
    {
        bool result = false;
        DataTable dtInfo = dataAccess.getDataTable("Select  DATEDIFF(DAY , CAST(GETDATE() as Date) , CAST(ExpiryDate as Date) ) as ValidRemain from SystemParameters");
        DataTable dtInfoValidity = dataAccess.getDataTable("Select ValidityDays from SystemParameters");

        if (Convert.ToInt32(dtInfo.Rows[0]["ValidRemain"]) <= Convert.ToInt32(dtInfoValidity.Rows[0]["ValidityDays"]))
        {
            try
            {
                dataAccess.BeginTransaction();
                dataAccess.ExecuteNonQuery("Update SystemParameters set ValidityDays = " + dtInfo.Rows[0]["ValidRemain"].ToString());
                dataAccess.TransCommit();
            }
            catch(Exception ex)
            {
            }
            finally
            {
                dataAccess.ConnectionClose();
            }
            
        }

        if (Convert.ToInt32(dtInfo.Rows[0]["ValidRemain"]) < 0)
        {

            result = true;
            return result;
        }
        else if (Convert.ToInt32(dtInfoValidity.Rows[0]["ValidityDays"]) < 0)
        {
            result = true;
            return result;
        }

        

        
        return result;
    }
}


