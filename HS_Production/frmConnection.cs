using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FIL
{
    public partial class frmConnection : Form
    {
        ConnectionSettings objConnSetting = new ConnectionSettings();
        public frmConnection()
        {
            InitializeComponent();
        }

       public enum Mode
        {
            Encryption,
            Decryption
        }

        private void frmConnection_Load(object sender, EventArgs e)
        {
            try
            {
                string path = null;
                path = Application.ExecutablePath;
                objConnSetting.Start(Mode.Decryption);
                Configuration config = ConfigurationManager.OpenExeConfiguration(path);

                txtServerName.Text = Utility.GetConnectionStringValues(frmLogin._ConnectionString, "Data Source");
                txtDatabase.Text = Utility.GetConnectionStringValues(frmLogin._ConnectionString, "Initial Catalog");
                txtUserId.Text = Utility.GetConnectionStringValues(frmLogin._ConnectionString, "User ID");
                txtPass.Text = Utility.GetConnectionStringValues(frmLogin._ConnectionString, "Password");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void frmConnection_FormClosing(object sender, FormClosingEventArgs e)
        {
            objConnSetting.Start(Mode.Encryption);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string path = null;
                path = Application.ExecutablePath;
                objConnSetting.Start(Mode.Decryption);
                Configuration config = ConfigurationManager.OpenExeConfiguration(path);
                int tempInteger = config.ConnectionStrings.ConnectionStrings.Count;
                if (tempInteger == 2)
                {
                    config.ConnectionStrings.ConnectionStrings[1].ConnectionString = "Data Source=" + this.txtServerName.Text + ";Initial Catalog=" + this.txtDatabase.Text + ";User ID=" + txtUserId.Text + ";Password=" + txtPass.Text + ";Connection Timeout=500;";
                }
                else
                {
                    config.ConnectionStrings.ConnectionStrings[0].ConnectionString = "Data Source=" + this.txtServerName.Text + ";Initial Catalog=" + this.txtDatabase.Text + ";User ID=" + txtUserId.Text + ";Password=" + txtPass.Text + "";
                }

                string connectString = "";
                if (tempInteger == 2)
                {
                    connectString = config.ConnectionStrings.ConnectionStrings[1].ConnectionString;
                }
                else
                {
                    connectString = config.ConnectionStrings.ConnectionStrings[0].ConnectionString;
                }

                try
                {
                    System.Data.SqlClient.SqlConnection objConn = new System.Data.SqlClient.SqlConnection(connectString);
                    objConn.Open();
                    objConn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Connection Not Found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    objConnSetting.Start(Mode.Encryption);
                    return;
                }

                config.Save(ConfigurationSaveMode.Modified);
                objConnSetting.Start(Mode.Encryption);
                MessageBox.Show("Successfully connected to database!" + Environment.NewLine  + "Settings applied successfully.", "Connection Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (tempInteger == 2)
                {
                    frmLogin._ConnectionString = config.ConnectionStrings.ConnectionStrings[1].ConnectionString;
                }
                else
                {
                    frmLogin._ConnectionString = config.ConnectionStrings.ConnectionStrings[0].ConnectionString;
                }
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }


    public class ConnectionSettings
    {

        public void Start(frmConnection.Mode Mode)
        {
            try
            {
                string execonfigname = null;
                string strprovider = null;

                strprovider = "DataProtectionConfigurationProvider";

                string path = null;
                path = Application.ExecutablePath;
                execonfigname = Application.ExecutablePath;
                Configuration oconfig = ConfigurationManager.OpenExeConfiguration(path);
                //ConnectionStringsSection section = (oconfig.GetSection("connectionStrings"));
                ConfigurationSection section = (oconfig.GetSection("connectionStrings"));

                // Open the configuration file and retrieve 
                // the connectionStrings section.
                Configuration config = ConfigurationManager.OpenExeConfiguration(execonfigname);

                //ConnectionStringsSection section1 = (config.GetSection("connectionStrings"));
                ConfigurationSection section1 = (oconfig.GetSection("connectionStrings"));
                // Open the configuration file and retrieve 
                // the connectionStrings section.

                switch (Mode)
                {
                    case frmConnection.Mode.Decryption:
                        if (section1.SectionInformation.IsProtected)
                        {
                            // Remove encryption.
                            section1.SectionInformation.UnprotectSection();
                        }
                        break; // TODO: might not be correct. Was : Exit Select

                        break;
                    case frmConnection.Mode.Encryption:
                        if (!section1.SectionInformation.IsProtected)
                        {
                            // Apply encryption.
                            section1.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
                        }
                        break; // TODO: might not be correct. Was : Exit Select

                        break;
                }

                // Save the current configuration.
                config.Save();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
