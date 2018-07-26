using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;


    public class RememberCache
    {
        #region CacheWork

        string strFilePath = Application.StartupPath + "\\Session.xml";
        string strFilePathtemp = Application.StartupPath + "\\Sessiontemp.xml";
        public string GetSessionValue(string keyname)
        {
            DataSet ds = GetSessionData();
            string str = string.Empty;
            if (ds.Tables[0].Select("keyname ='" + keyname + "'").Length > 0)
            {
                str = ds.Tables[0].Select("keyname ='" + keyname + "'")[0]["keyvalue"].ToString();
            }
            return str;
        }
        public void SetSessionValue(string keyname, string keyvalue)
        {
            DataSet ds = GetSessionData();
            if (ds.Tables[0].Select("keyname ='" + keyname + "'").Length > 0)
            {
                DataRow dr = ds.Tables[0].Select("keyname ='" + keyname + "'")[0];
                dr.BeginEdit();
                dr["keyvalue"] = keyvalue;
                dr.EndEdit();
            }
            //New keyname and keyvalue insert
            else
            {
                DataRow drnew = ds.Tables[0].NewRow();
                drnew["keyname"] = keyname;
                drnew["keyvalue"] = keyvalue;
                ds.Tables[0].Rows.Add(drnew);
            }
            SaveSession(ds);
        }

        private DataSet GetSessionData()
        {
            DataSet ds = new DataSet();
            try
            {

                if (!File.Exists(strFilePath))
                {
                    CreateSessionXml();
                }
                DecryptFile(strFilePath);
                ds.ReadXml(strFilePathtemp, XmlReadMode.ReadSchema);
                EncryptFile(strFilePathtemp);
                return ds;
            }
            catch (Exception ex)
            {
                return ds;
            }
        }

        private void SaveSession(DataSet Session)
        {
            Session.WriteXml(strFilePathtemp, XmlWriteMode.WriteSchema);
            EncryptFile(strFilePathtemp);
        }
        private void CreateSessionXml()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("keyname", typeof(string));
            dt.Columns.Add("keyvalue", typeof(string));

            DataSet dsSession = new DataSet();
            dsSession.Tables.Add(dt);
            dsSession.WriteXml(strFilePathtemp, XmlWriteMode.WriteSchema);
            EncryptFile(strFilePathtemp);
        }


        private void ExceptionFileControl()
        {
            if (File.Exists(strFilePathtemp))
            {
                File.Delete(strFilePathtemp);
            }
        }
        private void EncryptFile(string inputFile)
        {
            try
            {
                string password = @"smartwor"; // Your Key Here
                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(password);

                string cryptFile = strFilePath;
                FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create);

                RijndaelManaged RMCrypto = new RijndaelManaged();

                CryptoStream cs = new CryptoStream(fsCrypt,
                    RMCrypto.CreateEncryptor(key, key),
                    CryptoStreamMode.Write);

                FileStream fsIn = new FileStream(inputFile, FileMode.Open);

                int data;
                while ((data = fsIn.ReadByte()) != -1)
                    cs.WriteByte((byte)data);


                fsIn.Close();
                cs.Close();
                fsCrypt.Close();
                ExceptionFileControl();
            }
            catch
            {
                MessageBox.Show("Encryption failed!", "Error");
            }
        }

        private void DecryptFile(string inputFile)
        {

            {
                File.Copy(inputFile, strFilePathtemp);
                string password = @"smartwor"; // Your Key Here

                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(password);

                FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);

                RijndaelManaged RMCrypto = new RijndaelManaged();

                CryptoStream cs = new CryptoStream(fsCrypt,
                    RMCrypto.CreateDecryptor(key, key),
                    CryptoStreamMode.Read);

                FileStream fsOut = new FileStream(strFilePathtemp, FileMode.Create);

                int data;
                while ((data = cs.ReadByte()) != -1)
                    fsOut.WriteByte((byte)data);

                fsOut.Close();
                cs.Close();
                fsCrypt.Close();

            }
        }



        #endregion
    }

