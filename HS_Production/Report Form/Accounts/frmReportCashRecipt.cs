using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using FIL.App_Code.VoucherMananger;

namespace FIL.Report_Form
{
    public partial class frmReportCashRecipt : Form
    {
        Smartworks.DAL dataAccess = new Smartworks.DAL();
        public frmReportCashRecipt()
        {
            InitializeComponent();
            string connString = ConfigurationManager.ConnectionStrings["HSConnectionString"].ConnectionString;
            Smartworks.DAL.ConnectionString = connString;
        }

        private void btnVoucheFromCodeSearch_Click(object sender, EventArgs e)
        {
            try
            {

                frmSearch search = new frmSearch();
                Smartworks.ColumnField[] sVoucher = new Smartworks.ColumnField[1];
                sVoucher[0] = new Smartworks.ColumnField("@Type", "CR");
                search.getattributes("sp_GetVoucherSearch", sVoucher, "VoucherMaster");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtVoucherFromCode.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                }
                else
                {
                    txtVoucherFromCode.Text = string.Empty;
                    txtVoucherFromCode.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnVoucherToCodeSearch_Click(object sender, EventArgs e)
        {
            try
            {

                frmSearch search = new frmSearch();
                Smartworks.ColumnField[] sVoucher = new Smartworks.ColumnField[1];
                sVoucher[0] = new Smartworks.ColumnField("@Type", "CR");
                search.getattributes("sp_GetVoucherSearch", sVoucher, "VoucherMaster");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtVoucherToCode.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                }
                else
                {
                    txtVoucherToCode.Text = string.Empty;
                    txtVoucherToCode.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnViewRepot_Click(object sender, EventArgs e)
        {
            try
            {
                VoucherManager v = new VoucherManager();
                ReportDocument document = new ReportDocument();
                string path = Application.StartupPath + "/rpt/Accounts/rptVoucher.rpt";
                document.Load(path);
                DataTable dtReport = new DataTable();
                dtReport = v.GetReportCashRecipt("CR", Convert.ToDateTime(dtpFromDate.Text), Convert.ToDateTime(dtpToDate.Text), txtVoucherFromCode.Text, txtVoucherToCode.Text);
                document.SetDataSource(dtReport);
                crystalRptCashRecipt.ReportSource = document;
                crystalRptCashRecipt.Refresh();
                //document.PrintToPrinter(1, true, 0, 0);
            }
            catch (Exception ex)
            {
            }
        }

     

    }
}
