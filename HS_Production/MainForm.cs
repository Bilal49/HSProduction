using DevExpress.XtraBars.Alerter;
using FIL.Payroll;
using FIL.Production;
using FIL.Report_Form;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FIL
{
    public partial class MainForm : Form
    {
        Smartworks.DAL dataAcess = new Smartworks.DAL();
        public static string Searched_Id;
        public static int User_Id = -1;
        public static int StoreId = -1;
        public static DateTime FicalYearStart;
        public static DateTime FicalYearEnd;
        public static int FYear;
        public static string User_Nature = string.Empty;
        private DataTable UserInformation;
        public static DataTable globelInfo;
        private List<ToolStripMenuItem> AllMenuItem = new List<ToolStripMenuItem>();
        public MainForm(DataTable dtUserInfo)
        {
            string connString = ConfigurationManager.ConnectionStrings["HSConnectionString"].ConnectionString;
            Smartworks.DAL.ConnectionString = connString;
            InitializeComponent();
            UserInformation = dtUserInfo;
            foreach (ToolStripMenuItem toolItem in menuStrip1.Items)
            {
                AllMenuItem.Add(toolItem);
                //add sub items
                //AllMenuItem.AddRange(GetItems(toolItem));
                AllMenuItem.AddRange(GetItems(toolItem));
            }
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            foreach (Control ctl in this.Controls)
            {
                if (ctl is MdiClient)
                {
                    //PictureBox pb = new PictureBox();
                    //pb.SizeMode = PictureBoxSizeMode.StretchImage;
                    //pb.Image = Properties.Resources.arino_logo_256;
                    //pb.Size = new Size(250,300);
                    //pb.Location = new Point(250 , 250);
                    //ctl.Controls.Add(pb);
                    //yeh Backgroud image sahi kaam ker raha hai lakin image ko resoulation set nh ho rhi filhl isko off kara hua hai Salman.
                    //ctl.BackgroundImage = Properties.Resources.arino_logo_256;
                    //ctl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    break;
                }
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.Refresh();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is MdiClient)
                {
                    ctrl.BackColor = Color.WhiteSmoke;

                    //ctrl.BackgroundImage = FIL.Properties.Resources.CompanyLogo;
                    ctrl.BackgroundImageLayout = ImageLayout.Center;
                    ctrl.Refresh();
                }
            }
            SetMenus(UserInformation);
            globelInfo = FillSystemInfo();
            this.Text = globelInfo.Rows[0]["WelcomeNote"].ToString();
            if (!string.IsNullOrEmpty(globelInfo.Rows[0]["FiscalYearStart"].ToString()))
            {
                FicalYearStart = Convert.ToDateTime(globelInfo.Rows[0]["FiscalYearStart"]);
            }
            if (!string.IsNullOrEmpty(globelInfo.Rows[0]["FiscalYearEnd"].ToString()))
            {
                FicalYearEnd = Convert.ToDateTime(globelInfo.Rows[0]["FiscalYearEnd"]);
            }

            if (!string.IsNullOrEmpty(globelInfo.Rows[0]["FYear"].ToString()))
            {
                FYear = Convert.ToInt32(globelInfo.Rows[0]["FYear"]);
            }


            Thread t = new Thread(new ThreadStart(NotificationThread));
            t.IsBackground = true;
            t.Start();

            //yahan per notification wala kaam kerna hai.
            //alertControl1.Show(this, "Warning", "Test Data" ,FIL.Properties.Resources.warning);
            //AlertControl crtl = new AlertControl();
            //crtl.Show(this , )
        }

        public delegate void ShowNotification();
        private void NotificationThread()
        {
            Invoke(new ShowNotification(ShowItemShortNotification));
        }

        private void ShowItemShortNotification()
        {
            //alertControl1.Show(this, "Warning", "Test Data", FIL.Properties.Resources.warning);
            ProductManager manageProduct = new ProductManager();
            DataTable dtShortItems = manageProduct.GetShortItemList();
            foreach (DataRow dr in dtShortItems.Rows)
            {
                AlertControl crtl = new AlertControl();
                crtl.Show(this, "Warning", dr["ProductName"].ToString() + " \n is Out of Stock", FIL.Properties.Resources.warning);
                Application.DoEvents();
            }

            WarehouseManager manageWarehouse = new WarehouseManager();
            StoreId = manageWarehouse.GetWarehouseStoreId();


        }
        private DataTable FillSystemInfo()
        {
            DataTable dt = new DataTable();
            try
            {
                //dt = dataAcess.getDataTable("Select PoweredBy = ( Select PoweredBy  from SystemParameters) , Company = (Select Name from Company) , WelcomeNote = ( Select WelcomeNote  from SystemParameters)");
                dt = dataAcess.getDataTable("Select  PoweredBy =  PoweredBy  , Company = (Select Name from Company) , WelcomeNote ,FooterText = ReportFooterText  , FiscalYearStart , FiscalYearEnd , FYear from SystemParameters");

            }
            catch (Exception ex)
            {
                MessageBox.Show("System Info does not Found.", "System Info not Found.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return dt;
        }

        private IEnumerable<ToolStripMenuItem> GetItems(ToolStripMenuItem item)
        {

            foreach (ToolStripItem sitem in item.DropDownItems)
            {
                if (sitem.GetType().Name == "ToolStripMenuItem")
                {
                    ToolStripMenuItem dropDownItem = (ToolStripMenuItem)sitem;
                    if (dropDownItem.DropDownItems.Count > 0) //(dropDownItem.HasDropDownItems)
                    {
                        foreach (ToolStripMenuItem subItem in GetItems(dropDownItem))
                            yield return subItem;
                    }
                    yield return dropDownItem;
                }


            }
        }

        private IEnumerable<ToolStripItem> GetItems(ToolStripItem item)
        {
            if (item is ToolStripMenuItem)
            {
                foreach (ToolStripItem tsi in (item as ToolStripMenuItem).DropDownItems)
                {
                    if (tsi is ToolStripMenuItem)
                    {
                        if ((tsi as ToolStripMenuItem).HasDropDownItems)
                        {
                            foreach (ToolStripItem subItem in GetItems((tsi as ToolStripMenuItem)))
                                yield return subItem;
                        }
                        yield return (tsi as ToolStripMenuItem);
                    }
                    else if (tsi is ToolStripSeparator)
                    {
                        yield return (tsi as ToolStripSeparator);
                    }
                }
            }
            else if (item is ToolStripSeparator)
            {
                yield return (item as ToolStripSeparator);
            }
        }

        private void SetMenus(DataTable dtMenu)
        {
            for (int i = 0; i < dtMenu.Rows.Count; i++)
            {
                SetMenu(dtMenu.Rows[i]["MenuName"].ToString());
            }

        }

        private void SetMenu(string menu)
        {
            var ItemMenus = AllMenuItem.Find(s => s.Name == menu);
            if (ItemMenus != null)
            {
                ItemMenus.Visible = true;
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to Exist ?", "Application Close.", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.Cancel:
                    {
                        return;
                    }
            }

            Application.Exit();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you want to Log Out?", "Logg Off", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.Cancel:
                    {
                        return;
                    }
            }

            Application.Restart();



        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Setup_Click(object sender, EventArgs e)
        {

        }

        private void rolePriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRolePrivilege RolePrivilege = new frmRolePrivilege();
            RolePrivilege.MdiParent = this;
            RolePrivilege.Show();
        }

        private void UserRole_Click(object sender, EventArgs e)
        {
            frmUserType UserType = new frmUserType();
            UserType.MdiParent = this;
            UserType.Show();
        }

        private void User_Click(object sender, EventArgs e)
        {
            frmUser User = new frmUser();
            User.MdiParent = this;
            User.Show();
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            frmMenu Menu = new frmMenu();
            Menu.MdiParent = this;
            Menu.Show();
        }

        private void Customer_Click(object sender, EventArgs e)
        {
            frmCustomer Customer = new frmCustomer();
            Customer.MdiParent = this;
            Customer.Show();
        }

        private void Vendor_Click(object sender, EventArgs e)
        {
            frmVendor Vendor = new frmVendor();
            Vendor.MdiParent = this;
            Vendor.Show();
        }

        private void Item_Click(object sender, EventArgs e)
        {
            //frmItem Item = new frmItem();
            //Item.MdiParent = this;
            //Item.Show();
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployee Employee = new frmEmployee();
            Employee.MdiParent = this;
            Employee.Show();
        }


        private void ProductType_Click(object sender, EventArgs e)
        {
            frmProductType ProductType = new frmProductType();
            ProductType.MdiParent = this;
            ProductType.Show();
        }
        private void ProductCategory_Click_1(object sender, EventArgs e)
        {
            frmProductCatagory ProductCatagory = new frmProductCatagory();
            ProductCatagory.MdiParent = this;
            ProductCatagory.Show();
        }

        private void ProductColor_Click(object sender, EventArgs e)
        {
            frmProductColor ProductColor = new frmProductColor();
            ProductColor.MdiParent = this;
            ProductColor.Show();
        }

        private void ProductSize_Click(object sender, EventArgs e)
        {
            frmProductSize ProductSize = new frmProductSize();
            ProductSize.MdiParent = this;
            ProductSize.Show();
        }


        private void POS_Click(object sender, EventArgs e)
        {
            DataTable dtCustomer = dataAcess.getDataTable("SELECT * FROM dbo.Customer WHERE IsPos = 1");
            if (dtCustomer.Rows.Count > 0)
            {
                //frmPOS frmPOS = new frmPOS();
                //frmPOS.ShowDialog();
            }
            else
            {
                MessageBox.Show("Default Customer Does Not Found." + Environment.NewLine + " Please Set Default POS Customer. ", "Contact to Admisitrator.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DirectSales_Click(object sender, EventArgs e)
        {
            //frmDirectSales Sales = new frmDirectSales();
            //Sales.MdiParent = this;
            //Sales.Show();
        }

        private void directPurchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmDirectPurchase Purchase = new frmDirectPurchase();
            //Purchase.MdiParent = this;
            //Purchase.Show();
        }

        private void CashReceipt_Click(object sender, EventArgs e)
        {
            frmCashReceiptVoucher CashReceipt = new frmCashReceiptVoucher();
            CashReceipt.MdiParent = this;
            CashReceipt.Show();

        }

        private void PriceList_Click(object sender, EventArgs e)
        {
            frmReportPriceList PriceList = new frmReportPriceList();
            PriceList.MdiParent = this;
            PriceList.Show();
        }

        private void ItemStock_Click(object sender, EventArgs e)
        {
            frmReportProductStock ItemStock = new frmReportProductStock(false);
            ItemStock.MdiParent = this;
            ItemStock.WindowState = FormWindowState.Maximized;
            ItemStock.Show();
        }

        private void SystemParameter_Click(object sender, EventArgs e)
        {
            SystemParameter sysinfo = new SystemParameter();
            sysinfo.MdiParent = this;
            sysinfo.Show();
        }

        private void Company_Click(object sender, EventArgs e)
        {
            frmCompany company = new frmCompany();
            company.MdiParent = this;
            company.Show();
        }
        private void CashPayment_Click(object sender, EventArgs e)
        {
            frmCashPayment frmCashPayment = new frmCashPayment();
            frmCashPayment.MdiParent = this;
            frmCashPayment.Show();
        }

        private void ReportCashRecipt_Click(object sender, EventArgs e)
        {
            frmReportCashRecipt frmReportCashRecipt = new frmReportCashRecipt();
            frmReportCashRecipt.MdiParent = this;
            frmReportCashRecipt.Show();
        }

        private void ReportCashPayment_Click(object sender, EventArgs e)
        {
            frmReportCashPayment frmReportCashPayment = new frmReportCashPayment();
            frmReportCashPayment.MdiParent = this;
            frmReportCashPayment.Show();
        }

        private void ReportCustomerLedger_Click(object sender, EventArgs e)
        {
            frmReportCustomerLedger frmReportCustomerLedger = new frmReportCustomerLedger();
            frmReportCustomerLedger.MdiParent = this;
            frmReportCustomerLedger.Show();
        }

        private void ReportVendorledger_Click(object sender, EventArgs e)
        {
            frmReportVenderLedger frmReportVenderLedger = new frmReportVenderLedger();
            frmReportVenderLedger.MdiParent = this;
            frmReportVenderLedger.Show();
        }

        private void VendorReports_Click(object sender, EventArgs e)
        {

        }

        private void City_Click(object sender, EventArgs e)
        {
            frmCity City = new frmCity();
            City.MdiParent = this;
            City.Show();
        }

        private void Transport_Click(object sender, EventArgs e)
        {
            frmTransport Transport = new frmTransport();
            Transport.MdiParent = this;
            Transport.Show();
        }

        private void ExpenseHead_Click(object sender, EventArgs e)
        {
            frmExpenseCatagory ExpenseCatagory = new frmExpenseCatagory();
            ExpenseCatagory.MdiParent = this;
            ExpenseCatagory.Show();
        }

        private void Expense_Click(object sender, EventArgs e)
        {
            frmExpense Expense = new frmExpense();
            Expense.MdiParent = this;
            Expense.Show();
        }

        private void ReportSalesInvoice_Click(object sender, EventArgs e)
        {
            frmReportSalesInvoice ReportSales = new frmReportSalesInvoice();
            ReportSales.WindowState = FormWindowState.Maximized;
            ReportSales.MdiParent = this;
            ReportSales.Show();
        }

        private void ReportPurchaseInvoice_Click(object sender, EventArgs e)
        {
            frmReportPurchaseInvoice ReportPurchase = new frmReportPurchaseInvoice();
            ReportPurchase.MdiParent = this;
            ReportPurchase.WindowState = FormWindowState.Maximized;
            ReportPurchase.Show();
        }

        private void ReportItemLedger_Click(object sender, EventArgs e)
        {
            frmReportProductLedger ReportProductLedger = new frmReportProductLedger();
            ReportProductLedger.MdiParent = this;
            ReportProductLedger.WindowState = FormWindowState.Maximized;
            ReportProductLedger.Show();
        }

        private void Warehouse_Click(object sender, EventArgs e)
        {
            frmWarehouse warehouse = new frmWarehouse();
            warehouse.MdiParent = this;
            warehouse.Show();
        }

        private void MesurementUnit_Click(object sender, EventArgs e)
        {
            frmMesurementUnit Unit = new frmMesurementUnit();
            Unit.MdiParent = this;
            Unit.Show();

        }

        private void Product_Click(object sender, EventArgs e)
        {
            frmItem item = new frmItem();
            item.MdiParent = this;
            item.WindowState = FormWindowState.Normal;
            item.Show();
        }

        private void ProductFormula_Click(object sender, EventArgs e)
        {
            frmProductFormula ProductFormula = new frmProductFormula();
            ProductFormula.MdiParent = this;
            ProductFormula.WindowState = FormWindowState.Maximized;
            ProductFormula.Show();
        }

        private void PurchaseOrder_Click(object sender, EventArgs e)
        {
            frmPurchaseOrder Order = new frmPurchaseOrder();
            Order.MdiParent = this;
            Order.WindowState = FormWindowState.Maximized;
            Order.Show();
        }

        private void ReceivingPO_Click(object sender, EventArgs e)
        {
            frmReceivingPO Order = new frmReceivingPO();
            Order.MdiParent = this;
            Order.WindowState = FormWindowState.Maximized;
            Order.Show();
        }

        private void Department_Click(object sender, EventArgs e)
        {
            frmDepartment Dept = new frmDepartment();
            Dept.MdiParent = this;
            Dept.WindowState = FormWindowState.Normal;
            Dept.Show();
        }

        private void LastNo_Click(object sender, EventArgs e)
        {
            frmLastNo LastNo = new frmLastNo();
            LastNo.MdiParent = this;
            LastNo.WindowState = FormWindowState.Normal;
            LastNo.Show();
        }

        private void StockRequisition_Click(object sender, EventArgs e)
        {
            frmStockRequisition Requisition = new frmStockRequisition();
            Requisition.MdiParent = this;
            Requisition.WindowState = FormWindowState.Normal;
            Requisition.Show();

        }

        private void RequisitionApproval_Click(object sender, EventArgs e)
        {
            frmStockRequisitionApproval Requisition = new frmStockRequisitionApproval();
            Requisition.MdiParent = this;
            Requisition.WindowState = FormWindowState.Normal;
            Requisition.Show();
        }

        private void ProductionStatus_Click(object sender, EventArgs e)
        {
            frmProductionStatus PStatus = new frmProductionStatus();
            PStatus.MdiParent = this;
            PStatus.WindowState = FormWindowState.Normal;
            PStatus.Show();
        }

        private void ProductOpening_Click(object sender, EventArgs e)
        {
            frmProductOpening POpening = new frmProductOpening();
            POpening.MdiParent = this;
            POpening.WindowState = FormWindowState.Normal;
            POpening.Show();

        }

        private void FormulaConfiguration_Click(object sender, EventArgs e)
        {
            frmProductFormulaConfig FormulaConfig = new frmProductFormulaConfig();
            FormulaConfig.MdiParent = this;
            FormulaConfig.WindowState = FormWindowState.Normal;
            FormulaConfig.Show();

        }

        private void SalesOrder_Click(object sender, EventArgs e)
        {
            frmSalesOrder SalesOrder = new frmSalesOrder();
            SalesOrder.MdiParent = this;
            SalesOrder.WindowState = FormWindowState.Maximized;
            SalesOrder.Show();
        }

        private void DepartmentTransfer_Click(object sender, EventArgs e)
        {
            frmWarehouseTransfer WT = new frmWarehouseTransfer();
            WT.MdiParent = this;
            WT.WindowState = FormWindowState.Maximized;
            WT.Show();
        }

        private void TransferSummary_Click(object sender, EventArgs e)
        {
            frmReportWarehouseTransferSummary ReportWTransferSummary = new frmReportWarehouseTransferSummary();
            ReportWTransferSummary.MdiParent = this;
            ReportWTransferSummary.WindowState = FormWindowState.Maximized;
            ReportWTransferSummary.Show();
        }

        private void AccountCategory_Click(object sender, EventArgs e)
        {
            frmAccountCategory AccountCategory = new frmAccountCategory();
            AccountCategory.MdiParent = this;
            AccountCategory.WindowState = FormWindowState.Normal;
            AccountCategory.Show();

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to Exit.", "Application Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.No:
                    {
                        e.Cancel = true;
                        break;
                    }
                case DialogResult.Yes:
                    {
                        e.Cancel = false;
                        break;
                    }

            }

        }

        private void ProductAssumption_Click(object sender, EventArgs e)
        {
            frmProductAssumption ProductAssumption = new frmProductAssumption();
            ProductAssumption.MdiParent = this;
            ProductAssumption.WindowState = FormWindowState.Maximized;
            ProductAssumption.Show();
        }

        private void ProductionProcess_Click(object sender, EventArgs e)
        {
            frmProduction ProductProcess = new frmProduction();
            ProductProcess.MdiParent = this;
            ProductProcess.WindowState = FormWindowState.Maximized;
            ProductProcess.Show();
        }

        private void DatabaseBakup_Click(object sender, EventArgs e)
        {
            frmDBBackup Backup = new frmDBBackup();
            Backup.MdiParent = this;
            Backup.WindowState = FormWindowState.Normal;
            Backup.Show();
        }

        private void ChartOfAccounts_Click(object sender, EventArgs e)
        {
            frmChartOfAccounts COA = new frmChartOfAccounts();
            COA.MdiParent = this;
            COA.WindowState = FormWindowState.Normal;
            COA.Show();
        }

        private void JournalVoucher_Click(object sender, EventArgs e)
        {
            frmJournalVoucher JV = new frmJournalVoucher("JV");
            JV.MdiParent = this;
            JV.WindowState = FormWindowState.Normal;
            JV.Show();


        }

        private void CashReceipt_Click_1(object sender, EventArgs e)
        {
            //frmCashReceiptVoucher ReceiptVoucher = new frmCashReceiptVoucher();
            //ReceiptVoucher.MdiParent = this;
            //ReceiptVoucher.WindowState = FormWindowState.Normal;
            //ReceiptVoucher.Show();
            frmJournalVoucher JV = new frmJournalVoucher("CR");
            JV.MdiParent = this;
            JV.WindowState = FormWindowState.Normal;
            JV.Show();
        }

        private void CashPayment_Click_1(object sender, EventArgs e)
        {
            //frmCashPayment PaymentVoucher = new frmCashPayment();
            //PaymentVoucher.MdiParent = this;
            //PaymentVoucher.WindowState = FormWindowState.Normal;
            //PaymentVoucher.Show();
            frmJournalVoucher JV = new frmJournalVoucher("CP");
            JV.MdiParent = this;
            JV.WindowState = FormWindowState.Normal;
            JV.Show();
        }

        private void GeneralLedger_Click(object sender, EventArgs e)
        {
            frmReportAccountLedger GeneralLedger = new frmReportAccountLedger();
            GeneralLedger.MdiParent = this;
            GeneralLedger.WindowState = FormWindowState.Maximized;
            GeneralLedger.Show();

        }

        private void Bank_Click(object sender, EventArgs e)
        {
            frmBank BankName = new frmBank();
            BankName.MdiParent = this;
            BankName.WindowState = FormWindowState.Normal;
            BankName.Show();
        }

        private void BankAccount_Click(object sender, EventArgs e)
        {
            frmBankAccount BankAccount = new frmBankAccount();
            BankAccount.MdiParent = this;
            BankAccount.WindowState = FormWindowState.Normal;
            BankAccount.Show();

        }

        private void ReportProductFormulaWithAmount_Click(object sender, EventArgs e)
        {

            frmReportProductFormulaWithAmount ProductFormulaWithAmount = new frmReportProductFormulaWithAmount();
            ProductFormulaWithAmount.MdiParent = this;
            ProductFormulaWithAmount.WindowState = FormWindowState.Maximized;
            ProductFormulaWithAmount.Show();
        }

        private void PurchaseInvoice_Click(object sender, EventArgs e)
        {
            frmPurchaseInvoice PurchaseInvoice = new frmPurchaseInvoice();
            PurchaseInvoice.MdiParent = this;
            PurchaseInvoice.WindowState = FormWindowState.Maximized;
            PurchaseInvoice.Show();
        }

        private void AccountConfig_Click(object sender, EventArgs e)
        {
            frmAccountConfig AccountConfig = new frmAccountConfig();
            AccountConfig.MdiParent = this;
            AccountConfig.WindowState = FormWindowState.Normal;
            AccountConfig.Show();
        }

        private void PackingList_Click(object sender, EventArgs e)
        {
            frmPackingList PackingList = new frmPackingList();
            PackingList.MdiParent = this;
            PackingList.WindowState = FormWindowState.Maximized;
            PackingList.Show();
        }

        private void SalesInvoice_Click(object sender, EventArgs e)
        {
            frmSaleInvoice Invoice = new frmSaleInvoice(false);
            Invoice.MdiParent = this;
            Invoice.WindowState = FormWindowState.Maximized;
            Invoice.Show();
        }

        private void ReportCOAList_Click(object sender, EventArgs e)
        {
            frmReportAccountList Invoice = new frmReportAccountList();
            Invoice.MdiParent = this;
            Invoice.WindowState = FormWindowState.Maximized;
            Invoice.Show();

        }
        #region Vocuher Print Menus
        private void ReportSalesVoucher_Click(object sender, EventArgs e)
        {
            frmReportVoucher Voucher = new frmReportVoucher("SV");
            Voucher.MdiParent = this;
            Voucher.WindowState = FormWindowState.Maximized;
            Voucher.Show();

        }
        private void ReportPurchaseVoucher_Click(object sender, EventArgs e)
        {
            frmReportVoucher Voucher = new frmReportVoucher("PJ");
            Voucher.MdiParent = this;
            Voucher.WindowState = FormWindowState.Maximized;
            Voucher.Show();

        }

        private void ReportCashReceiptVoucher_Click(object sender, EventArgs e)
        {
            frmReportVoucher Voucher = new frmReportVoucher("CR");
            Voucher.MdiParent = this;
            Voucher.WindowState = FormWindowState.Maximized;
            Voucher.Show();
        }

        private void ReportCashPaymentVoucher_Click(object sender, EventArgs e)
        {
            frmReportVoucher Voucher = new frmReportVoucher("CP");
            Voucher.MdiParent = this;
            Voucher.WindowState = FormWindowState.Maximized;
            Voucher.Show();
        }

        private void reportBankReceiptVoucher_Click(object sender, EventArgs e)
        {
            frmReportVoucher Voucher = new frmReportVoucher("BR");
            Voucher.MdiParent = this;
            Voucher.WindowState = FormWindowState.Maximized;
            Voucher.Show();
        }

        private void ReportBankPayment_Click(object sender, EventArgs e)
        {
            frmReportVoucher Voucher = new frmReportVoucher("BP");
            Voucher.MdiParent = this;
            Voucher.WindowState = FormWindowState.Maximized;
            Voucher.Show();
        }

        private void ReportJournalVoucher_Click(object sender, EventArgs e)
        {
            frmReportVoucher Voucher = new frmReportVoucher("JV");
            Voucher.MdiParent = this;
            Voucher.WindowState = FormWindowState.Maximized;
            Voucher.Show();
        }
        #endregion

        private void BankReceipt_Click(object sender, EventArgs e)
        {
            //frmBankReceipt BankReceipt = new frmBankReceipt();
            //BankReceipt.MdiParent = this;
            //BankReceipt.WindowState = FormWindowState.Normal;
            //BankReceipt.Show();

            frmBankJournalVoucher JV = new frmBankJournalVoucher("BR");
            JV.MdiParent = this;
            JV.WindowState = FormWindowState.Normal;
            JV.Show();

        }

        private void TrialBalance_Click(object sender, EventArgs e)
        {
            frmReportTrailBalance TrialBalance = new frmReportTrailBalance();
            TrialBalance.MdiParent = this;
            TrialBalance.WindowState = FormWindowState.Maximized;
            TrialBalance.Show();
        }

        private void BankPayment_Click(object sender, EventArgs e)
        {
            //frmBankPayment BankPayment = new frmBankPayment();
            //BankPayment.MdiParent = this;
            //BankPayment.WindowState = FormWindowState.Normal;
            //BankPayment.Show();

            frmBankJournalVoucher JV = new frmBankJournalVoucher("BP");
            JV.MdiParent = this;
            JV.WindowState = FormWindowState.Normal;
            JV.Show();

        }

        private void ProductionLine_Click(object sender, EventArgs e)
        {
            frmProcess ProcessLine = new frmProcess();
            ProcessLine.MdiParent = this;
            ProcessLine.WindowState = FormWindowState.Maximized;
            ProcessLine.Show();
        }

        private void ProcessSummary_Click(object sender, EventArgs e)
        {
            frmReportProcessingSummary ProcessLine = new frmReportProcessingSummary();
            ProcessLine.MdiParent = this;
            ProcessLine.WindowState = FormWindowState.Maximized;
            ProcessLine.Show();
        }

        private void VoucherPosting_Click(object sender, EventArgs e)
        {
            frmVoucherPosting VoucherPosting = new frmVoucherPosting();
            VoucherPosting.MdiParent = this;
            VoucherPosting.WindowState = FormWindowState.Normal;
            VoucherPosting.Show();
        }

        private void ProcessLedger_Click(object sender, EventArgs e)
        {

            frmReportProcessLedger ProcessLedger = new frmReportProcessLedger();
            ProcessLedger.MdiParent = this;
            ProcessLedger.WindowState = FormWindowState.Maximized;
            ProcessLedger.Show();
        }

        private void ReportSalesOrder_Click(object sender, EventArgs e)
        {
            frmReportSalesOrder ReportSales = new frmReportSalesOrder();
            ReportSales.WindowState = FormWindowState.Maximized;
            ReportSales.MdiParent = this;
            ReportSales.Show();
        }

        private void ReportProductFormula_Click(object sender, EventArgs e)
        {
            frmReportProductFormula ReportFormula = new frmReportProductFormula();
            ReportFormula.WindowState = FormWindowState.Maximized;
            ReportFormula.MdiParent = this;
            ReportFormula.Show();
        }

        private void ReportItemStockWithAmount_Click(object sender, EventArgs e)
        {
            frmReportProductStock ItemStock = new frmReportProductStock(true);
            ItemStock.MdiParent = this;
            ItemStock.WindowState = FormWindowState.Maximized;
            ItemStock.Show();
        }

        private void SalesReturnInvoice_Click(object sender, EventArgs e)
        {
            frmSaleReturnInvoice ReturnInvoice = new frmSaleReturnInvoice();
            ReturnInvoice.MdiParent = this;
            ReturnInvoice.WindowState = FormWindowState.Maximized;
            ReturnInvoice.Show();
        }

        private void ReportPurchaseOrder_Click(object sender, EventArgs e)
        {
            frmReportPurchaseOrder PurchaseOrder = new frmReportPurchaseOrder();
            PurchaseOrder.MdiParent = this;
            PurchaseOrder.WindowState = FormWindowState.Maximized;
            PurchaseOrder.Show();
        }

        private void ReportRecevingPO_Click(object sender, EventArgs e)
        {
            frmReportReceivingPurchaseOrder ReceivingPurchaseOrder = new frmReportReceivingPurchaseOrder();
            ReceivingPurchaseOrder.MdiParent = this;
            ReceivingPurchaseOrder.WindowState = FormWindowState.Maximized;
            ReceivingPurchaseOrder.Show();
        }

        private void ReportReceivingPOSummary_Click(object sender, EventArgs e)
        {
            frmReportReceivingPOSummary ReceivingPurchaseOrder = new frmReportReceivingPOSummary(true);
            ReceivingPurchaseOrder.MdiParent = this;
            ReceivingPurchaseOrder.WindowState = FormWindowState.Maximized;
            ReceivingPurchaseOrder.Show();
        }

        private void ReportReceivingPOSummary_Click_1(object sender, EventArgs e)
        {
            frmReportReceivingPOSummary ReceivingPurchaseOrder = new frmReportReceivingPOSummary(false);
            ReceivingPurchaseOrder.MdiParent = this;
            ReceivingPurchaseOrder.WindowState = FormWindowState.Maximized;
            ReceivingPurchaseOrder.Show();
        }

        private void ReportSalesInvoiceSummaryWithDetail_Click(object sender, EventArgs e)
        {
            frmReportSalesInvoiceSummary SummaryReport = new frmReportSalesInvoiceSummary(true);
            SummaryReport.MdiParent = this;
            SummaryReport.WindowState = FormWindowState.Maximized;
            SummaryReport.Show();
        }

        private void ReportSalesInvoiceSummary_Click(object sender, EventArgs e)
        {
            frmReportSalesInvoiceSummary SummaryReport = new frmReportSalesInvoiceSummary(false);
            SummaryReport.MdiParent = this;
            SummaryReport.WindowState = FormWindowState.Maximized;
            SummaryReport.Show();
        }

        private void ReportPackingListStatus_Click(object sender, EventArgs e)
        {
            frmReportPackingListStatus ReportPackingList = new frmReportPackingListStatus();
            ReportPackingList.MdiParent = this;
            ReportPackingList.WindowState = FormWindowState.Maximized;
            ReportPackingList.Show();
        }

        private void Promotion_Click(object sender, EventArgs e)
        {
            frmPromotion Promotion = new frmPromotion();
            Promotion.MdiParent = this;
            Promotion.WindowState = FormWindowState.Normal;
            Promotion.Show();
        }

        private void ReportPromotionStatus_Click(object sender, EventArgs e)
        {
            frmReportPromotionStatus ReportPromotionStatus = new frmReportPromotionStatus();
            ReportPromotionStatus.MdiParent = this;
            ReportPromotionStatus.WindowState = FormWindowState.Maximized;
            ReportPromotionStatus.Show();

        }

        private void SalesDetailByType_Click(object sender, EventArgs e)
        {
            frmReportSalesDetailByType ReportSalesDetail = new frmReportSalesDetailByType();
            ReportSalesDetail.MdiParent = this;
            ReportSalesDetail.WindowState = FormWindowState.Maximized;
            ReportSalesDetail.Show();

        }

        private void ReportProcessSummaryMerge_Click(object sender, EventArgs e)
        {
            frmReportProcessingSummaryMerge ReportProcessingMerge = new frmReportProcessingSummaryMerge();
            ReportProcessingMerge.MdiParent = this;
            ReportProcessingMerge.WindowState = FormWindowState.Maximized;
            ReportProcessingMerge.Show();
        }

        private void ReportTransferSummaryForArticle_Click(object sender, EventArgs e)
        {
            frmReportWarehouseTransferSummaryArticle ReportSummary = new frmReportWarehouseTransferSummaryArticle();
            ReportSummary.MdiParent = this;
            ReportSummary.WindowState = FormWindowState.Maximized;
            ReportSummary.Show();

        }

        private void ReportProductionStatus_Click(object sender, EventArgs e)
        {
            frmReportProductionStatus ProductionStatus = new frmReportProductionStatus();
            ProductionStatus.MdiParent = this;
            ProductionStatus.WindowState = FormWindowState.Maximized;
            ProductionStatus.Show();
        }

        private void TimeAttendancePolicy_Click(object sender, EventArgs e)
        {
            frmTimeAttendancePolicy TimePolicy = new frmTimeAttendancePolicy();
            TimePolicy.MdiParent = this;
            TimePolicy.WindowState = FormWindowState.Normal;
            TimePolicy.Show();

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ImportAttendance_Click(object sender, EventArgs e)
        {
            frmImportAttendance ImportAttendance = new frmImportAttendance();
            ImportAttendance.MdiParent = this;
            ImportAttendance.WindowState = FormWindowState.Normal;
            ImportAttendance.Show();

        }

        private void SalesTaxInvoice_Click(object sender, EventArgs e)
        {
            frmSaleInvoice Invoice = new frmSaleInvoice(true);
            Invoice.MdiParent = this;
            Invoice.WindowState = FormWindowState.Maximized;
            Invoice.Show();
        }

        private void ReportCustomerBalance_Click(object sender, EventArgs e)
        {
            frmReportCustomerBalance CustomerBalance = new frmReportCustomerBalance();
            CustomerBalance.MdiParent = this;
            CustomerBalance.WindowState = FormWindowState.Maximized;
            CustomerBalance.Show();
        }

        private void ReportVendorBalance_Click(object sender, EventArgs e)
        {
            frmReportVendorBalance VendorBalance = new frmReportVendorBalance();
            VendorBalance.MdiParent = this;
            VendorBalance.WindowState = FormWindowState.Maximized;
            VendorBalance.Show();
        }

        private void FiscalClose_Click(object sender, EventArgs e)
        {
            frmFicalYearClosing FiscalYearClosing = new frmFicalYearClosing();
            FiscalYearClosing.MdiParent = this;
            FiscalYearClosing.Show();
        }

        private void FiscalYear_Click(object sender, EventArgs e)
        {
            frmFiscalYear FiscalYear = new frmFiscalYear();
            FiscalYear.MdiParent = this;
            FiscalYear.Show();
        }

        private void StockAdjustment_Click(object sender, EventArgs e)
        {
            frmStockAdjustment StockAdjust = new frmStockAdjustment();
            StockAdjust.MdiParent = this;
            StockAdjust.WindowState = FormWindowState.Normal;
            StockAdjust.Show();
        }

        private void ReportAgingSheet_Click(object sender, EventArgs e)
        {
            frmReportAging Aging = new frmReportAging();
            Aging.MdiParent = this;
            Aging.WindowState = FormWindowState.Maximized;
            Aging.Show();
        }
    }
}
