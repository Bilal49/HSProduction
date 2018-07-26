using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FIL
{
    public partial class frmDBBackup : Form
    {
        public frmDBBackup()
        {
            InitializeComponent();
        }

        RememberCache clsRemember = new RememberCache();
        private void frmDBBackup_Load(object sender, EventArgs e)
        {
            txtPath.Text = clsRemember.GetSessionValue("DatabaseFilePath");
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbb = new FolderBrowserDialog();
            if (fbb.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = fbb.SelectedPath.ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(txtPath.Text))
                {
                    MessageBox.Show("File Path does not Found.", "Error File Path", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!Directory.Exists(txtPath.Text))
                {
                    MessageBox.Show("File Path does not Match or Location Error.", "Location does not Match", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (Directory.Exists(txtPath.Text))
                {
                    string FileName = DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;
                    string Path = txtPath.Text + "\\" +  FileName + ".bak";

                    if (File.Exists(Path))
                    {
                        File.Delete(Path);
                    }

                    Smartworks.DAL dataAcess = new Smartworks.DAL();
                    string connString = ConfigurationManager.ConnectionStrings["HSConnectionString"].ConnectionString;
                    //ConfigurationManager.ConnectionStrings["HSConnectionString"].
                    IDbConnection connection = new SqlConnection(connString);
                    string dbName = connection.Database;
                    if (!string.IsNullOrEmpty(dbName))
                    {
                        bool result = false;
                        var status = dataAcess.getDataTable("BACKUP DATABASE " + dbName + "  TO DISK = '" + Path + "'");
                        if (status != null)
                        {
                            result = true;
                        }
                        if (result)
                        {
                            if (File.Exists(Path))
                            {
                                ZipFile zip = new ZipFile();
                                try
                                {
                                    zip.AddFile(Path);
                                    zip.Save(txtPath.Text + "\\" + FileName + ".zip");
                                    if (File.Exists(Path))
                                    {
                                        File.Delete(Path);
                                    }
                                    clsRemember.SetSessionValue("DatabaseFilePath", txtPath.Text);
                                }
                                catch (Exception ex)
                                {

                                }
                                finally
                                {
                                    zip.Dispose();
                                }
                            }
                            MessageBox.Show("Database Backup Create Sucessfully.", "Backup Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error to Create Database Backup.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Connection Instance does not Found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
 
                    }
                    
                    

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
