using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using FIL;


    public partial class frmReportAccountLedger : Form
    {
        ReportDocument document = null;
        AccountManager manageAccount = new AccountManager();

        public frmReportAccountLedger(ReportDocument pdocument = null)
        {
            InitializeComponent();
            if (pdocument != null)
            {
                document = pdocument;
            }
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            try
            {   
                document = new ReportDocument();
                string path = Application.StartupPath + "/rpt/Accounts/rptGeneralLedger.rpt";
                document.Load(path);
                DataTable dtReport = new DataTable();
                if (chkAll.Checked)
                {
                    dtReport = manageAccount.GetReportGeneralLedger(txtFromAcc.Text, txtTAcc.Text, null, null);
                }
                else
                {
                    dtReport = manageAccount.GetReportGeneralLedger(txtFromAcc.Text, txtTAcc.Text, dtpFromDate.Value, dtpToDate.Value);
                }
                document.SetDataSource(dtReport);
                Utility.SetReportDefaultParameter(ref document);
                //if (document.ParameterFields["IsAllData"] != null)
                //{
                //    document.SetParameterValue("IsAllData", chkAll.Checked);
                //}
                CrViewer.ReportSource = document;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void crystalRptCustomerLedger_ReportRefresh(object source, CrystalDecisions.Windows.Forms.ViewerEventArgs e)
        {
            btnViewReport_Click(null, null);
            //if(document != null)
            //{
            //    Utility.SetReportDefaultParameter(ref document);
            //}
        }

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lblToDate_Click(object sender, EventArgs e)
        {

        }

        private void btnFPartySearch_Click(object sender, EventArgs e)
        {
            //frmSearch search = new frmSearch();
            //search.getattributes("GetAccountSearch", null, "Chart Of Accounts");
            //search.ShowDialog();
            //if (!string.IsNullOrEmpty(MainForm.Searched_Id))
            //{
            //    txtSalesAcc.Text = MainForm.Searched_Id;
            //    MainForm.Searched_Id = string.Empty;
            //}

            try
            {
                frmSearch search = new frmSearch();
                search.getattributes("GetCOASearch", null, "Chart Of Accounts");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtFromAcc.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                }
                else
                {
                    txtFromAcc.Text = string.Empty;
                    txtFAccName.Text = string.Empty;
                    txtFromAcc.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       

        private void btnFItemSearch_Click(object sender, EventArgs e)
        {
            try
            {

                frmSearch search = new frmSearch();
                search.getattributes("GetCOASearch", null, "Chart Of Accounts");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtTAcc.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                }
                else
                {
                    txtTAcc.Text = string.Empty;
                    txtTAccName.Text = string.Empty;
                    txtTAcc.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       

        //private void btnFBrokerSearch_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        frmSearch search = new frmSearch();
        //        search.getattributes("GetBrokerSearch", null, "Brokers");
        //        search.ShowDialog();
        //        if (!string.IsNullOrEmpty(MainForm.Searched_Id))
        //        {
        //            txtBroker.Text = MainForm.Searched_Id;
        //            MainForm.Searched_Id = string.Empty;
        //        }
        //        else
        //        {
        //            txtBroker.Text = string.Empty;
        //            txtBrokerName.Text = string.Empty;
        //            txtBroker.Focus();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        

        private void btnClear_Click(object sender, EventArgs e)
        {
            document = null;
            CrViewer.ReportSource = null;
            dtpFromDate.Value = DateTime.Now;
            dtpToDate.Value = DateTime.Now;
            
            txtTAcc.Text = string.Empty;
            txtTAccName.Text = string.Empty;

            //txtBroker.Text = string.Empty;
            //txtBrokerName.Text = string.Empty;

            txtFromAcc.Text = string.Empty;
            txtFAccName.Text = string.Empty;

            //txtFromInvoice.Text = string.Empty;
            //txtToInvoice.Text = string.Empty;

            dtpFromDate.Focus();

        }

        private void frmReportStockInn_Load(object sender, EventArgs e)
        {
            try
            {
                if (document != null)
                {
                    CrViewer.ReportSource = document;
                }
            }
            catch (Exception ex)
            {
            }
        }
        Smartworks.DAL dataAcess = new Smartworks.DAL();
        private void txtFromPartyCode_TextChanged(object sender, EventArgs e)
        {
            string AccountName = string.Empty;
            try
            {
                AccountName = manageAccount.GetChartOfAccounts(manageAccount.GetCOAIdByCode(txtFromAcc.Text)).Rows[0]["AccountName"].ToString();
                txtFAccName.Text = AccountName;
            }
            catch (Exception ex)
            {
                AccountName = string.Empty;
            }
            
        }

        private void txtItemCode_TextChanged(object sender, EventArgs e)
        {
            
            string AccountName = string.Empty;
            try
            {
                AccountName = manageAccount.GetChartOfAccounts(manageAccount.GetCOAIdByCode(txtTAcc.Text)).Rows[0]["AccountName"].ToString();
                txtTAccName.Text = AccountName;
            }
            catch (Exception ex)
            {
                AccountName = string.Empty;
            }

        }

       

        private void txtPartyCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                btnFAccSearch.PerformClick();
            }
        }

        private void txtItemCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                btnTAccSearch.PerformClick();
            }
        }

       
        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked)
            {
                dtpFromDate.Value = DateTime.Now;
                dtpToDate.Value = DateTime.Now;

                dtpFromDate.Enabled = false;
                dtpToDate.Enabled = false;


                txtFromAcc.Text = string.Empty;
                txtFAccName.Text = string.Empty;
                //txtFromAcc.Enabled = false;
                //txtFAccName.Enabled = false;
               

                txtTAcc.Text = string.Empty;
                txtTAccName.Text = string.Empty;
                //txtTAcc.Enabled = false;
                //txtTAccName.Enabled = false;

                //btnFAccSearch.Enabled = false;
                //btnTAccSearch.Enabled = false;
                

            }
            else
            {
                dtpFromDate.Enabled = true;
                dtpToDate.Enabled = true;

                //txtFromAcc.Enabled = true;
                //txtFAccName.Enabled = true;

                //txtTAcc.Enabled = true;
                //txtTAccName.Enabled = true;

                //btnFAccSearch.Enabled = true;
                //btnTAccSearch.Enabled = true;
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        //private void btnFromInvoiceSearch_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        frmSearch search = new frmSearch();
        //        search.getattributes("GetStockInnSearch", null, "Purchase Invoices");
        //        search.ShowDialog();
        //        if (!string.IsNullOrEmpty(MainForm.Searched_Id))
        //        {
        //            txtFromInvoice.Text = MainForm.Searched_Id;
        //            MainForm.Searched_Id = string.Empty;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        //private void btnToInvoieSearch_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        frmSearch search = new frmSearch();
        //        search.getattributes("GetStockInnSearch", null, "Purchase Invoices");
        //        search.ShowDialog();
        //        if (!string.IsNullOrEmpty(MainForm.Searched_Id))
        //        {
        //            //txtToInvoice.Text = MainForm.Searched_Id;
        //            MainForm.Searched_Id = string.Empty;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        //private void txtFromInvoice_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.F4)
        //    {
        //        //btnFromInvoiceSearch.PerformClick();
        //    }
        //}

        //private void txtToInvoice_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.F4)
        //    {
        //        //btnToInvoieSearch.PerformClick();
        //    }
        //}
    }

