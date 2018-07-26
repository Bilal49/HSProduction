using FIL.App_Code.PurchaseManager;
using FIL.App_Code.SaleMasterManager;
using FIL.App_Code.SystemManager;
using FIL.App_Code.VoucherMananger;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


    public partial class frmFicalYearClosing : Form
    {
        bool IsValidSales = false;
        bool IsValidPurchase = false;
        bool IsValidVoucher = false;

        SalesManager manageSales = new SalesManager();
        PurchaseManager managePurchase = new PurchaseManager();
        VoucherManager manageVoucher = new VoucherManager();
        public frmFicalYearClosing()
        {
            InitializeComponent();
        }

        private void frmFicalYearClosing_Load(object sender, EventArgs e)
        {
            LoadSystemInfo();
        }

        private void LoadSystemInfo()
        {
            try
            {

                SystemManager SM = new SystemManager();
                DataTable dtSysinfo = SM.GetSystemInfo();
                if (dtSysinfo.Rows.Count > 0)
                {   
                    if (!string.IsNullOrEmpty(dtSysinfo.Rows[0]["FiscalYearStart"].ToString()))
                    {
                        dtpFicalStart.Value = Convert.ToDateTime(dtSysinfo.Rows[0]["FiscalYearStart"]);
                        dtpFicalStart.Enabled = false;
                    }
                    else
                    {
                        dtpFicalStart.Value = DateTime.Now;
                    }
                    if (!string.IsNullOrEmpty(dtSysinfo.Rows[0]["FiscalYearEnd"].ToString()))
                    {
                        dtpFiscalEnd.Value = Convert.ToDateTime(dtSysinfo.Rows[0]["FiscalYearEnd"]);
                        dtpFiscalEnd.Enabled = false;
                    }
                    else
                    {
                        dtpFiscalEnd.Value = DateTime.Now;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error to Fill Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalesCheck_Click(object sender, EventArgs e)
        {
            DataTable dtSales = new DataTable();
            dtSales =  manageSales.GetUnPostedSales(dtpFicalStart.Value ,dtpFiscalEnd.Value);
            if (dtSales.Rows.Count > 0)
            {
                pbSalesInvalid.Visible = true;
                pbSalesValid.Visible = false;
                IsValidSales = false;
            }
            else
            {
                pbSalesInvalid.Visible = false;
                pbSalesValid.Visible = true;
                IsValidSales = true;
            }


        }

        private void btnPurchaseCheck_Click(object sender, EventArgs e)
        {
            DataTable dtPurchase = new DataTable();
            dtPurchase = managePurchase.GetUnPostedPurchase(dtpFicalStart.Value, dtpFiscalEnd.Value);
            if (dtPurchase.Rows.Count > 0)
            {
                pbPurchaseInvalid .Visible = true;
                pbPurchaseValid.Visible = false;
                IsValidPurchase = false;
            }
            else
            {
                pbPurchaseInvalid.Visible = false;
                pbPurchaseValid.Visible = true;
                IsValidPurchase = true;
            }
        }

        private void btnVoucherCheck_Click(object sender, EventArgs e)
        {
            DataTable dtVoucher = new DataTable();
            dtVoucher = manageVoucher.GetUnPostedVoucher(dtpFicalStart.Value, dtpFiscalEnd.Value);
            if (dtVoucher.Rows.Count > 0)
            {
                pbVoucherInvalid.Visible = true;
                pbVoucherValid .Visible = false;
                IsValidVoucher = false;
            }
            else
            {
                pbVoucherInvalid.Visible = false;
                pbVoucherValid.Visible = true;
                IsValidVoucher = true;
            }
        }
       
    }

