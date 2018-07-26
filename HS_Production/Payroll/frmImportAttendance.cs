using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FIL.Payroll
{
    public partial class frmImportAttendance : Form
    {
        public frmImportAttendance()
        {
            InitializeComponent();
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            //FolderBrowserDialog fbb = new FolderBrowserDialog();
            //if (fbb.ShowDialog() == DialogResult.OK)
            //{
            //    txtPath.Text = fbb.SelectedPath.ToString();
            //}
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Excel Files|*.xls;*.xlsx;";
            of.Multiselect = false;
            if (of.ShowDialog() == DialogResult.OK)
            {
                string FilePath = of.FileName;
                txtPath.Text = FilePath;
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPath.Text))
            {
                MessageBox.Show("Please Select Import File Name", "File Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool IsImported = ImportExcelData(txtPath.Text);
            if (IsImported)
            {
                MessageBox.Show("Attendance Import Successfull.", "Record Imported", MessageBoxButtons.OK, MessageBoxIcon.Information);
                progressBar1.Value = 0;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPath.Text = string.Empty;
        }

        private bool ImportExcelData(string strFilePath)
        {
            progressBar1.Value = 0;
            bool result = true;
            string sSheetName = null;
            string sConnection = null;
            DataTable dtTablesList = new DataTable();


            OleDbCommand oleExcelCommand = new OleDbCommand();
            OleDbDataReader oleExcelReader;
            OleDbConnection oleExcelConnection = new OleDbConnection();
            DataTable dtExcelData = new DataTable();
            DataTable dtExcelDataFinal = new DataTable();
            Smartworks.DAL dataAccess = new Smartworks.DAL();

            string extension = Path.GetExtension(strFilePath);
            switch (extension)
            {
                case ".xls":
                    //sConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strFilePath + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
                    sConnection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strFilePath + ";Extended Properties=Excel 12.0;";
                    break;
                case ".xlsx":
                    sConnection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strFilePath + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1;'";
                    break;
                default:
                    sConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strFilePath + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
                    break;
            }
            //String constr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strFilePath + ";Extended Properties='Excel 8.0;HDR=YES;';";
            // sConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strFilePath + ";Extended Properties='Excel 8.0;HDR=YES;';";
            oleExcelConnection = new OleDbConnection(sConnection);
            try
            {
                oleExcelConnection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "File does not read.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            dtTablesList = oleExcelConnection.GetSchema("Tables");
            int SheetIndex = 0;
            foreach (DataRow drSheet in dtTablesList.Rows)
            {
                SheetIndex = SheetIndex + 1;
                sSheetName = drSheet["TABLE_NAME"].ToString();
                if (!sSheetName.Contains("$"))
                {
                    continue;
                }
                //dtTablesList.Clear();
                //dtTablesList.Dispose();

                if (!string.IsNullOrEmpty(sSheetName))
                {
                    oleExcelCommand = oleExcelConnection.CreateCommand();
                    oleExcelCommand.CommandText = "Select * From [" + sSheetName + "]";
                    oleExcelCommand.CommandType = CommandType.Text;
                    oleExcelReader = oleExcelCommand.ExecuteReader();
                    dtExcelData.Load(oleExcelReader, LoadOption.PreserveChanges);
                    oleExcelReader.Close();
                }

                if (SheetIndex == dtTablesList.Rows.Count)
                {
                    oleExcelConnection.Close();
                }
                if (dtExcelData.Rows.Count > 0)
                {
                    //Emp No.	AC-No.	 Name	 Date	 Clock In	 Clock Out

                    //if (dtExcelData.Columns.Count > 10 || dtExcelData.Columns.Count < 10)
                    //{
                    //    MessageBox.Show("File Format does not match. Make sure your format is as per Sample.", "Format does not match", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    oleExcelConnection.Close();
                    //    result = false;
                    //    return result;
                    //}


                    //dtExcelData.Rows.RemoveAt(0);
                    /* yeh New format file hai */
                    dtExcelData.Columns[0].ColumnName = "EmpNo";
                    dtExcelData.Columns[1].ColumnName = "AccNo";
                    dtExcelData.Columns[2].ColumnName = "Name";
                    dtExcelData.Columns[3].ColumnName = "Dated";
                    dtExcelData.Columns[4].ColumnName = "TimeInn";
                    dtExcelData.Columns[5].ColumnName = "TimeOut";

                    if (dtExcelDataFinal.Columns.Count == 0)
                    {
                        dtExcelDataFinal = dtExcelData.Clone();
                    }

                    foreach (DataRow dtRow in dtExcelData.Rows)
                    {
                        dtExcelDataFinal.ImportRow(dtRow);
                    }
                }

            }

            if (dtExcelDataFinal.Columns.Count > 0)
            {
                if (dtExcelDataFinal.Rows.Count > 0)
                {
                    int index = 0;
                    try
                    {
                        progressBar1.Maximum = dtExcelDataFinal.Rows.Count;
                        dataAccess.BeginTransaction();
                        for (int i = 0; i <= dtExcelDataFinal.Rows.Count - 1; i++)
                        {
                            index = i;
                            DataRow drImportRow = dtExcelDataFinal.Rows[i];
                            if (!string.IsNullOrEmpty(drImportRow["AccNo"].ToString()))
                            {
                                Smartworks.ColumnField[] importCustomer = new Smartworks.ColumnField[4];
                                importCustomer[0] = new Smartworks.ColumnField("@AccNo", drImportRow["AccNo"].ToString().Trim());
                                importCustomer[1] = new Smartworks.ColumnField("@Dated", drImportRow["Dated"].ToString().Trim());
                                importCustomer[2] = new Smartworks.ColumnField("@TimeIn", drImportRow["TimeInn"].ToString().Trim());
                                importCustomer[3] = new Smartworks.ColumnField("@TimeOut", drImportRow["TimeOut"].ToString().Trim());

                                dataAccess.ExecuteStoredProcedure("sp_ImportAttendance", importCustomer);
                                progressBar1.Value += 1;
                                Application.DoEvents();
                            }
                        }
                        dataAccess.TransCommit();
                        // dataAccess.TransRollback();
                    }
                    catch (SqlException sqlex)
                    {
                        dataAccess.TransRollback();
                        dataAccess.ConnectionClose();
                        //Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Error!!.. File Date not Import.');", true);
                        MessageBox.Show("Error!!.. File Data not Import", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        result = false;
                        return result;
                    }
                    catch (Exception ex)
                    {
                        dataAccess.ConnectionClose();
                        //Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Error!!.. File Date not Import.');", true);
                        MessageBox.Show("Error!!.. File Data not Import", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        result = false;
                        return result;
                    }
                }

            }
            return result;

        }
    }
}
