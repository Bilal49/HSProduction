using CrystalDecisions.CrystalReports.Engine;
using FIL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


    public partial class frmReportVoucher : Form
    {
        public string VoucherType = "";
        AccountManager manageAccount = new AccountManager();
        public frmReportVoucher(string Type)
        {
            InitializeComponent();
            this.VoucherType =  Type;
        }

        private void frmReportVoucher_Load(object sender, EventArgs e)
        {

        }

        private void btnVoucherSearch_Click(object sender, EventArgs e)
        {
            try
            {

                frmSearch search = new frmSearch();
                Smartworks.ColumnField[] sVoucher = new Smartworks.ColumnField[1];
                sVoucher[0] = new Smartworks.ColumnField("@Type", VoucherType);

                search.getattributes("sp_GetVoucherSearch", sVoucher, "Voucher");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtFromVoucherNumber.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                }
                else
                {
                    txtFromVoucherNumber.Text = string.Empty;
                    txtFromVoucherNumber.Focus();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFromVoucherNumber.Text = string.Empty;
            CrViewer.ReportSource = null;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {

                ReportDocument document = new ReportDocument();
                string path = string.Empty;
                if (VoucherType == "BP" || VoucherType == "BR") // Bank Voucher
                {
                    path = Application.StartupPath + "/rpt/Accounts/rptBankVoucher.rpt";
                }
                else
                {
                    path = Application.StartupPath + "/rpt/Accounts/rptVoucher.rpt";
                }
                
                document.Load(path);
                DataTable dtReport = new DataTable();
                if (VoucherType == "BP" || VoucherType == "BR") // Bank Voucher
                {
                    dtReport = manageAccount.GetReportBankVoucher(txtFromVoucherNumber.Text, txtToVoucherNumber.Text, dtpFrom.Value, dtpTo.Value, this.VoucherType);
                }
                else
                {
                    dtReport = manageAccount.GetReportVoucher(txtFromVoucherNumber.Text, txtToVoucherNumber.Text, dtpFrom.Value, dtpTo.Value, this.VoucherType);
                }
               
                document.SetDataSource(dtReport);
                Utility.SetReportDefaultParameter(ref document);
                CrViewer.ReportSource = document;
                CrViewer.Refresh();
            }
            catch (Exception ex)
            {
            }
        }

        private void btnToVoucher_Click(object sender, EventArgs e)
        {
            try
            {
                frmSearch search = new frmSearch();
                Smartworks.ColumnField[] sVoucher = new Smartworks.ColumnField[1];
                sVoucher[0] = new Smartworks.ColumnField("@Type", VoucherType);
                search.getattributes("sp_GetVoucherSearch", sVoucher, "Voucher");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtToVoucherNumber.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                }
                else
                {
                    txtToVoucherNumber.Text = string.Empty;
                    txtToVoucherNumber.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }

