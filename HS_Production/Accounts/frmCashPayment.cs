using FIL.App_Code.VoucherMananger;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using CrystalDecisions.CrystalReports.Engine;


namespace FIL
{
    public partial class frmCashPayment : Form
    {
        Smartworks.DAL dataAcess = new Smartworks.DAL();

        public frmCashPayment()
        {
            InitializeComponent();
            string connString = ConfigurationManager.ConnectionStrings["HSConnectionString"].ConnectionString;
            Smartworks.DAL.ConnectionString = connString;
        }
        int VoucherMasterId = -1;
        int VendorId = -1;

        VoucherManager VM = new VoucherManager();
        VendorManager Vendor = new VendorManager();
        AccountManager manageAccount = new AccountManager();

        private void frmCashReceiptVoucher_Load(object sender, EventArgs e)
        {
            try
            {
                ButtonRights(true);
                txtCashPaymentCode.Text = GetNewNextNumber();
                btnNextInvioceNo.Enabled = false;
                btnPrevInvioceNo.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #region Method

        private String GetNewNextNumber()
        {
            string NewInvoiceNo = "";
            NewInvoiceNo = VM.GetMaxVoucherNo("CP", MainForm.FYear);
            if (!string.IsNullOrEmpty(NewInvoiceNo))
            {
                NewInvoiceNo = VM.GetNextVoucherNo(NewInvoiceNo);
            }
            else
            {
                NewInvoiceNo = "CP-000001";
            }
            return NewInvoiceNo;
        }

        private void ButtonRights(bool Enable)
        {
            btnAdd.Enabled = Enable;
            btnUpdate.Enabled = !Enable;
            btnDelete.Enabled = !Enable;
            btnPrint.Enabled = !Enable;
            txtCashPaymentCode.ReadOnly = !Enable;
            btnVendorSearch.Enabled = Enable;
        }

        private void ClearFeilds()
        {

            txtCashPaymentCode.Text = string.Empty;
            txtVendorCode.Text = string.Empty;
            txtAmount.Text = "0.00";
            dtpVoucher.Text = string.Empty;
            txtRemarks.Text = string.Empty;
            txtBalance.Text = "0.00";
            txtAccCode.Text = string.Empty;
            txtAccName.Text = string.Empty;
            txtNaration.Text = string.Empty;
            txtVendorName.Text = string.Empty;
            txtCashAcc.Text = string.Empty;
            txtCashAccName.Text = string.Empty;
            btnVoucherSearch.Focus();
            ButtonRights(true);
            btnNextInvioceNo.Enabled = false;
            btnPrevInvioceNo.Enabled = false;
            txtCashPaymentCode.Text = GetNewNextNumber();

        }

        private bool Validation()
        {
            bool result = true;

            //if (string.IsNullOrEmpty(txtVendorCode.Text))
            //{
            //    MessageBox.Show("Please Select Party Code", "Need Party Code.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    result = false;
            //    txtVendorCode.Focus();
            //    return result;
            //}

            if (string.IsNullOrEmpty(txtAccCode.Text))
            {
                MessageBox.Show("Account Code Not Found", "Need Party Account.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
                txtAccCode.Focus();
                return result;
            }

            if (string.IsNullOrEmpty(txtCashAcc.Text))
            {
                MessageBox.Show("Cash Account Not Found", "Need Cash Account.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
                txtCashAcc.Focus();
                return result;
            }

            if (string.IsNullOrEmpty(txtAmount.Text))
            {
                MessageBox.Show("Please Enter Voucher Amount", "Need Voucher Amount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
                txtAmount.Focus();
                return result;
            }

            if (Decimal.Parse(txtAmount.Text) <= 0)
            {
                MessageBox.Show("Please Enter Voucher Amount", "Need Voucher Amount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
                txtAmount.Focus();
                return result;
            }
            return result;

        }

        private void LoadVoucher(int VoucherMasterId)
        {
            try
            {

                DataSet dsVocuher = VM.GetVoucherStructure(VoucherMasterId);
                dsVocuher.Tables[0].TableName = "VoucherMaster";
                dsVocuher.Tables[1].TableName = "VoucherDetail";
                dsVocuher.Tables[2].TableName = "FlagDC";
                dsVocuher.Tables[3].TableName = "ChartOfAccount";

                if (dsVocuher.Tables["VoucherMaster"].Rows.Count > 0)
                {
                    //txtCashPaymentCode.Text = dtVoucher.Rows[0]["VoucherNumber"].ToString();
                    dtpVoucher.Text = dsVocuher.Tables["VoucherMaster"].Rows[0]["Date"].ToString();
                    txtNaration.Text = dsVocuher.Tables["VoucherMaster"].Rows[0]["Narration"].ToString();
                    txtAmount.Text = dsVocuher.Tables["VoucherMaster"].Rows[0]["TotalDebit"].ToString();

                    DataRow drCredit = dsVocuher.Tables["VoucherDetail"].Select("FlagDC = 'C'")[0];
                    //txtVendorCode.Text = drCredit["VendorCode"].ToString();
                    txtAccCode.Text = drCredit["AccountCode"].ToString();

                    DataRow drDebit = dsVocuher.Tables["VoucherDetail"].Select("FlagDC = 'D'")[0];
                    txtCashAcc.Text = drDebit["AccountCode"].ToString();

                    txtRemarks.Text = drDebit["Remarks"].ToString();


                    ButtonRights(false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadVendor(int VendorId)
        {
            DataTable dtVendor = Vendor.GetVendor(VendorId);
            if (dtVendor.Rows.Count > 0)
            {
                txtVendorCode.Text = dtVendor.Rows[0]["Code"].ToString();
                txtVendorName.Text = dtVendor.Rows[0]["VendorName"].ToString();

                if (!string.IsNullOrEmpty(dtVendor.Rows[0]["COAId"].ToString()))
                {
                    txtAccCode.Text = manageAccount.GetChartOfAccounts(Convert.ToInt32(dtVendor.Rows[0]["COAId"])).Rows[0]["AccountCode"].ToString();
                }
            }
        }

        //private int InsertVoucher(DateTime Date, string VoucherType,
        //                             string BranchCode, string POrderNo, string Narration, decimal TotalDebit, decimal TotalCredit, bool Hold,
        //                             bool Posted, int AddedBy, DateTime AddedOn, string AddedIpAddr)
        //{
        //    VoucherMasterId = VoucherMaster.InsertVoucharMaster(Date,VoucherType, BranchCode, POrderNo, Narration, TotalDebit, TotalCredit, Hold, Posted, AddedBy, AddedOn, AddedIpAddr);
        //    return VoucherMasterId;

        //}

        //private void UpdateVoucher(int VoucherMasterId, DateTime Date, string VoucherType,
        //                             string BranchCode, string POrderNo, string Narration, decimal TotalDebit, decimal TotalCredit, bool Hold,
        //                             bool Posted, int UpdatedBy, DateTime UpdatedOn, string UpdatedIpAddr)
        //{
        //    VoucherMaster.UpdateVoucharMaster(VoucherMasterId, Date, VoucherType, BranchCode, POrderNo, Narration, TotalDebit, TotalCredit, Hold, Posted, UpdatedBy, UpdatedOn, UpdatedIpAddr);
        //}

        private void DeleteVoucher(int VoucherId)
        {
            try
            {
                //int VendorLedgerId = Convert.ToInt32(Vendor.GetVendorLedgerByCashPayment(txtCashPaymentCode.Text).Rows[0]["LedgerId"]);
                //Vendor.DeleteVendorLedger(VendorLedgerId);
                VM.DeleteVoucharMaster(VoucherId);
                MessageBox.Show("Voucher Record Delete Successfull.", "Record Deleted.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFeilds();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error To Delete Voucher", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        #endregion
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                DataTable dtVoucher = null;
                try
                {
                    int CashCOAId, VendorCOAId = -1;
                    VendorCOAId = manageAccount.GetCOAIdByCode(txtAccCode.Text); // yeh Creadit hoga yani "C"
                    CashCOAId = manageAccount.GetCOAIdByCode(txtCashAcc.Text); //yeh Debit hoga yani "D"

                    if (VendorCOAId <= 0 || CashCOAId <= 0)
                    {
                        MessageBox.Show("Error While Save Cash Payment. Account Code or Cash Account is missing", "Account Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (VendorCOAId == CashCOAId)
                    {
                        MessageBox.Show("Account Code and Cash Account should not be Same.", "Same Account Restriction", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    dataAcess.BeginTransaction();
                    if (dataAcess.getDBCommand().Transaction == null)
                    {
                        dataAcess.SetDBTransaction();
                    }
                    dtVoucher = VM.InsertVoucharMaster(Convert.ToDateTime(dtpVoucher.Value), "CP", "K", txtNaration.Text, Convert.ToDecimal(txtAmount.Text), Convert.ToDecimal(txtAmount.Text), MainForm.User_Id, DateTime.Now.Date, "", dataAcess);
                    VoucherMasterId = Convert.ToInt32(dtVoucher.Rows[0]["VoucherMasterId"]);
                    VM.InsertVoucherDetail(VoucherMasterId, "", "", CashCOAId, txtCashAcc.Text, "D", Convert.ToDecimal(txtAmount.Text), txtRemarks.Text, dataAcess);
                    VM.InsertVoucherDetail(VoucherMasterId, "", "" , VendorCOAId, txtAccCode.Text, "C", Convert.ToDecimal(txtAmount.Text), txtRemarks.Text, dataAcess);
                    
                    //int VendorId = Vendor.GetVendorIdByCode(txtVendorCode.Text);
                    //Vendor.InsertVendorLedger(VendorId, Convert.ToDateTime(dtpVoucher.Value), "", -1, 0, dtVoucher.Rows[0]["VoucherNumber"].ToString(), VoucherMasterId, Convert.ToDecimal(txtAmount.Text), dataAcess);
                    dataAcess.TransCommit();
                    MessageBox.Show("Cash Payment Record Insert Successfull", "Record Inserted.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //if (VoucherMasterId > 0)
                    //{
                    //    LoadVoucher(VoucherMasterId);
                    //}
                    ClearFeilds();
                }
                catch (SqlException sqlex)
                {
                    dataAcess.TransRollback();
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    dataAcess.ConnectionClose();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                try
                {
                    int CashCOAId, VendorCOAId = -1;
                    VendorCOAId = manageAccount.GetCOAIdByCode(txtAccCode.Text); // yeh Creadit hoga yani "C"
                    CashCOAId = manageAccount.GetCOAIdByCode(txtCashAcc.Text); //yeh Debit hoga yani "D"

                    if (VendorCOAId <= 0 || CashCOAId <= 0)
                    {
                        MessageBox.Show("Error While Save Cash Payment. Account Code or Cash Account is missing", "Account Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (VendorCOAId == CashCOAId)
                    {
                        MessageBox.Show("Account Code and Cash Account should not be Same.", "Same Account Restriction", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    dataAcess.BeginTransaction();
                    if (dataAcess.getDBCommand().Transaction == null)
                    {
                        dataAcess.SetDBTransaction();
                    }

                    VM.DeleteVoucharDetailByMasterId(this.VoucherMasterId, dataAcess);
                    VM.UpdateVoucharMaster(this.VoucherMasterId, Convert.ToDateTime(dtpVoucher.Value), "CP", "K", txtNaration.Text, Convert.ToDecimal(txtAmount.Text), Convert.ToDecimal(txtAmount.Text), MainForm.User_Id, DateTime.Now.Date, "", dataAcess);

                    VM.InsertVoucherDetail(this.VoucherMasterId, "", "", VendorCOAId, txtAccCode.Text, "C", Convert.ToDecimal(txtAmount.Text), txtRemarks.Text, dataAcess);
                    VM.InsertVoucherDetail(this.VoucherMasterId, "", "", CashCOAId, txtCashAcc.Text, "D", Convert.ToDecimal(txtAmount.Text), txtRemarks.Text, dataAcess);

                    //int VendorId = Vendor.GetVendorIdByCode(txtVendorCode.Text);
                    //int VendorLedgerId = Convert.ToInt32(Vendor.GetVendorLedgerByCashPayment(txtCashPaymentCode.Text).Rows[0]["LedgerId"]);
                    //Vendor.UpdateVendorLedger(VendorLedgerId, VendorId, Convert.ToDateTime(dtpVoucher.Value), "", -1, 0, txtCashPaymentCode.Text, this.VoucherMasterId, Convert.ToDecimal(txtAmount.Text), dataAcess);
                    dataAcess.TransCommit();
                    MessageBox.Show("Cash Payment Record Update Successfull.", "Record Updated.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //if (VoucherMasterId > 0)
                    //{
                    //    LoadVoucher(VoucherMasterId);
                    //}
                    ClearFeilds();
                }
                catch (SqlException sqlex)
                {
                    dataAcess.TransRollback();
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    dataAcess.ConnectionClose();
                }
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFeilds();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to Delete it?", "Voucher Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.No:
                    {
                        return;
                        break;
                    }
                case DialogResult.Yes:
                    {
                        DeleteVoucher(VoucherMasterId);
                        break;
                    }

            }
        }

        private void btnVoucherSearch_Click(object sender, EventArgs e)
        {
            try
            {

                frmSearch search = new frmSearch();
                Smartworks.ColumnField[] sVoucher = new Smartworks.ColumnField[1];
                sVoucher[0] = new Smartworks.ColumnField("@Type", "CP");

                search.getattributes("sp_GetVoucherSearch", sVoucher, "VoucherMaster");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtCashPaymentCode.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                }
                else
                {
                    txtCashPaymentCode.Text = string.Empty;
                    txtCashPaymentCode.Focus();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCustomerSearch_Click(object sender, EventArgs e)
        {
            try
            {

                frmSearch search = new frmSearch();
                search.getattributes("GetVendorSearch", null, "Vender");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtVendorCode.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                }
                else
                {
                    txtVendorCode.Text = string.Empty;
                    txtVendorCode.Focus();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtReceiptVoucherCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtReceiptVoucherCode_Leave(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtCashPaymentCode.Text))
            {
                VoucherMasterId = VM.GetVoucherMasterIdByCode(txtCashPaymentCode.Text, MainForm.FYear);
                if (VoucherMasterId > 0)
                {
                    LoadVoucher(VoucherMasterId);
                }
            }
        }

        private void txtReceiptVoucherCode_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCashPaymentCode.Text))
            {
                VoucherMasterId = VM.GetVoucherMasterIdByCode(txtCashPaymentCode.Text, MainForm.FYear);
                if (VoucherMasterId > 0)
                {
                    LoadVoucher(VoucherMasterId);
                }
            }
        }

        private void txtCustomerCode_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtVendorCode.Text))
            {
                VendorId = Vendor.GetVendorIdByCode(txtVendorCode.Text);
                if (VendorId > 0)
                {
                    LoadVendor(VendorId);
                }
            }
            else
            {
                txtVendorName.Text = string.Empty;
            }
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)) || (e.KeyChar == (char)Keys.Decimal) || (e.KeyChar == (char)Keys.Escape) || (e.KeyChar == (char)Keys.Enter))
            //    e.Handled = true;

            char ch = e.KeyChar;
            decimal x;
            if (ch == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else if (!char.IsDigit(ch) && ch != '.' || !Decimal.TryParse(txtAmount.Text + ch, out x))
            {
                e.Handled = true;
            }
        }

        private void btnMaxInvioceNo_Click(object sender, EventArgs e)
        {
            VoucherManager VM = new VoucherManager();
            txtCashPaymentCode.Text = VM.GetMaxVoucherNo("CP" ,MainForm.FYear);
            if (!string.IsNullOrEmpty(txtCashPaymentCode.Text))
            {
                VoucherMasterId = VM.GetVoucherMasterIdByCode(txtCashPaymentCode.Text, MainForm.FYear);
                if (VoucherMasterId > 0)
                {
                    LoadVoucher(VoucherMasterId);
                    btnNextInvioceNo.Enabled = false;
                    btnPrevInvioceNo.Enabled = true;
                }
            }
        }

        private void btnNextInvioceNo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCashPaymentCode.Text))
            {
                VoucherManager VM = new VoucherManager();
                string LastVoucherNo = VM.GetMaxVoucherNo("CP", MainForm.FYear);
                txtCashPaymentCode.Text = VM.GetNextVoucherNo(txtCashPaymentCode.Text);
                VoucherMasterId = VM.GetVoucherMasterIdByCode(txtCashPaymentCode.Text, MainForm.FYear);
                if (VoucherMasterId > 0)
                {
                    LoadVoucher(VoucherMasterId);
                    if (LastVoucherNo == txtCashPaymentCode.Text)
                    {
                        btnNextInvioceNo.Enabled = false;
                    }
                    else
                    {
                        btnPrevInvioceNo.Enabled = true;
                    }
                }


            }
        }

        private void btnPrevInvioceNo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCashPaymentCode.Text))
            {
                VoucherManager VM = new VoucherManager();
                string LastInvioceNo = VM.GetMinVoucherNo("CP", MainForm.FYear);
                txtCashPaymentCode.Text = VM.GetPrevVoucherNo(txtCashPaymentCode.Text);
                VoucherMasterId = VM.GetVoucherMasterIdByCode(txtCashPaymentCode.Text, MainForm.FYear);
                if (VoucherMasterId > 0)
                {
                    LoadVoucher(VoucherMasterId);
                    if (LastInvioceNo == txtCashPaymentCode.Text)
                    {
                        btnPrevInvioceNo.Enabled = false;
                    }
                    else
                    {
                        btnNextInvioceNo.Enabled = true;
                    }
                }
            }
        }

        private void btnMinInvioceNo_Click(object sender, EventArgs e)
        {
            VoucherManager VM = new VoucherManager();
            txtCashPaymentCode.Text = VM.GetMinVoucherNo("CP", MainForm.FYear);
            if (!string.IsNullOrEmpty(txtCashPaymentCode.Text))
            {
                LoadVoucher(VoucherMasterId);
                btnNextInvioceNo.Enabled = true;
                btnPrevInvioceNo.Enabled = false;
            }
        }

        private void frmCashPayment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtAccCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtAccCode.Text))
                {
                    txtAccName.Text = manageAccount.GetChartOfAccounts(manageAccount.GetCOAIdByCode(txtAccCode.Text)).Rows[0]["AccountName"].ToString();
                }
                else
                {
                    txtAccName.Text = string.Empty;
                }

            }
            catch (Exception ex)
            {
                txtAccName.Text = string.Empty;
            }
        }

        private void txtCashAcc_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtCashAcc.Text))
                {
                    txtCashAccName.Text = manageAccount.GetChartOfAccounts(manageAccount.GetCOAIdByCode(txtCashAcc.Text)).Rows[0]["AccountName"].ToString();
                }
                else
                {
                    txtCashAccName.Text = string.Empty;
                }

            }
            catch (Exception ex)
            {
                txtCashAccName.Text = string.Empty;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                frmSearch search = new frmSearch();
                search.getattributes("GetCOASearch", null, "Chart Of Accounts");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtCashAcc.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnACSearch_Click(object sender, EventArgs e)
        {
            try
            {
                frmSearch search = new frmSearch();
                search.getattributes("GetCOASearch", null, "Chart Of Accounts");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtAccCode.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCashPaymentCode.Text))
                {
                    return;
                }

                ReportDocument document = new ReportDocument();
                string path = Application.StartupPath + "/rpt/Accounts/rptVoucher.rpt";
                document.Load(path);
                DataTable dtReport = new DataTable();
                dtReport = manageAccount.GetReportVoucher(txtCashPaymentCode.Text, txtCashPaymentCode.Text , dtpVoucher.Value, dtpVoucher.Value , "CP");
                document.SetDataSource(dtReport);
                Utility.SetReportDefaultParameter(ref document);

                frmReportViewer Viewer = new frmReportViewer(document);
                Viewer.MdiParent = this.MdiParent;
                Viewer.WindowState = FormWindowState.Maximized;
                Viewer.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
