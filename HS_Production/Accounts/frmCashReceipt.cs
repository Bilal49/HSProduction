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
    public partial class frmCashReceiptVoucher : Form
    {
        Smartworks.DAL dataAcess = new Smartworks.DAL();
        int VoucherMasterId = -1;
        int CustomerId = -1;
        AccountManager manageAccount = new AccountManager();
        VoucherManager VM = new VoucherManager();
        public frmCashReceiptVoucher()
        {
            InitializeComponent();
        }


        private void frmCashReceiptVoucher_Load(object sender, EventArgs e)
        {
            try
            {
                ButtonRights(true);
                txtReceiptVoucherCode.Text = GetNewNextNumber();
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
            NewInvoiceNo = VM.GetMaxVoucherNo("CR",MainForm.FYear);
            if (!string.IsNullOrEmpty(NewInvoiceNo))
            {
                NewInvoiceNo = VM.GetNextVoucherNo(NewInvoiceNo);
            }
            else
            {
                NewInvoiceNo = "CR-000001";
            }
            return NewInvoiceNo;
        }



        private void ButtonRights(bool Enable)
        {
            btnAdd.Enabled = Enable;
            btnUpdate.Enabled = !Enable;
            btnDelete.Enabled = !Enable;
            btnPrint.Enabled = !Enable;
            txtReceiptVoucherCode.ReadOnly = !Enable;
            btnCustomerSearch.Enabled = Enable;
        }

        private void ClearFeilds()
        {

            txtReceiptVoucherCode.Text = string.Empty;
            txtCustomerCode.Text = string.Empty;
            txtAmount.Text = "0.00";
            dtpVoucher.Text = string.Empty;
            txtRemarks.Text = string.Empty;
            txtAccCode.Text = string.Empty;
            txtAccName.Text = string.Empty;
            txtBalance.Text = "0.00";
            txtNaration.Text = string.Empty;
            txtCashAcc.Text = string.Empty;
            txtCashAccName.Text = string.Empty;
            txtCustomerName.Text = string.Empty;
            txtReceiptVoucherCode.Text = GetNewNextNumber();
            btnVoucherSearch.Focus();
            ButtonRights(true);
            btnNextInvioceNo.Enabled = false;
            btnPrevInvioceNo.Enabled = false;
        }

        private bool Validation()
        {
            bool result = true;

            if (string.IsNullOrEmpty(txtAccCode.Text))
            {
                MessageBox.Show("Please Enter Account Code", "Need Account Code.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
                txtAccCode.Focus();
                return result;
            }

            if (string.IsNullOrEmpty(txtCashAcc.Text))
            {
                MessageBox.Show("Please Enter Cash Account", "Need Cash Account.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            if (Convert.ToDecimal(txtAmount.Text) <= 0)
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
                    
                    dtpVoucher.Text = dsVocuher.Tables["VoucherMaster"].Rows[0]["Date"].ToString();
                    txtNaration.Text = dsVocuher.Tables["VoucherMaster"].Rows[0]["Narration"].ToString();
                    txtAmount.Text = dsVocuher.Tables["VoucherMaster"].Rows[0]["TotalDebit"].ToString();

                    DataRow drDebit = dsVocuher.Tables["VoucherDetail"].Select("FlagDC = 'D'")[0];
                    txtCustomerCode.Text = drDebit["CustomerCode"].ToString();
                    txtAccCode.Text = drDebit["AccountCode"].ToString();

                    DataRow drCredit = dsVocuher.Tables["VoucherDetail"].Select("FlagDC = 'C'")[0];
                    txtCashAcc.Text = drCredit["AccountCode"].ToString();

                    txtRemarks.Text = drCredit["Remarks"].ToString();


                    ButtonRights(false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadCustomer(int CustomerId)
        {

            CustomerManager Customer = new CustomerManager();
            DataTable dtCustomer = Customer.GetCustomer(CustomerId);
            if (dtCustomer.Rows.Count > 0)
            {
                txtCustomerCode.Text = dtCustomer.Rows[0]["Code"].ToString();
                txtCustomerName.Text = dtCustomer.Rows[0]["CustomerName"].ToString();
                if (!string.IsNullOrEmpty(dtCustomer.Rows[0]["COAId"].ToString()))
                {
                    txtAccCode.Text = manageAccount.GetChartOfAccounts(Convert.ToInt32(dtCustomer.Rows[0]["COAId"])).Rows[0]["AccountCode"].ToString();
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

        private void DeleteVoucher(int VoucherMasterId)
        {
            try
            {
               
                CustomerManager Customer = new CustomerManager();
                int CustomerLedgerId = Convert.ToInt32(Customer.GetCustomerLedgerByCashRecipt(txtReceiptVoucherCode.Text).Rows[0]["LedgerId"]);
                Customer.DeleteCustomerLedger(CustomerLedgerId.ToString());
                VM.DeleteVoucharMaster(VoucherMasterId);
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
                DataTable dtVoucher = new DataTable();
                try
                {

                    int CashCOAId, CustomerCOAId = -1;
                    CustomerCOAId = manageAccount.GetCOAIdByCode(txtAccCode.Text); // yeh Debit hoga yani "D"
                    CashCOAId = manageAccount.GetCOAIdByCode(txtCashAcc.Text); //yeh Credit hoga yani "C"

                    if (CustomerCOAId <= 0 || CashCOAId <= 0)
                    {
                        MessageBox.Show("Error While Save Cash Receipt. Account Code or Cash Account is missing", "Account Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (CustomerCOAId == CashCOAId)
                    {
                        MessageBox.Show("Account Code and Cash Account should not be Same.", "Same Account Restriction", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                   
                    dataAcess.BeginTransaction();
                    if (dataAcess.getDBCommand().Transaction == null)
                    {
                        dataAcess.SetDBTransaction();
                    }

                    dtVoucher = VM.InsertVoucharMaster(dtpVoucher.Value, "CR", "K", txtNaration.Text, Convert.ToDecimal(txtAmount.Text), Convert.ToDecimal(txtAmount.Text), MainForm.User_Id , DateTime.Now.Date, "", dataAcess);
                    VoucherMasterId = Convert.ToInt32(dtVoucher.Rows[0]["VoucherMasterId"]);
                    VM.InsertVoucherDetail(VoucherMasterId, "", "" , CustomerCOAId, txtAccCode.Text, "D", Convert.ToDecimal(txtAmount.Text), txtRemarks.Text, dataAcess);
                    VM.InsertVoucherDetail(VoucherMasterId, "", "", CashCOAId, txtCashAcc.Text, "C", Convert.ToDecimal(txtAmount.Text), txtRemarks.Text, dataAcess);
                    dataAcess.TransCommit();
                    MessageBox.Show("Cash Receipt Insert Successfull", "Record Inserted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFeilds();

                }
                catch (SqlException sqlex)
                {
                    dataAcess.TransRollback();
                    MessageBox.Show(sqlex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
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
                    int CashCOAId, CustomerCOAId = -1;
                    CustomerCOAId = manageAccount.GetCOAIdByCode(txtAccCode.Text); // yeh Debit hoga yani "D"
                    CashCOAId = manageAccount.GetCOAIdByCode(txtCashAcc.Text); //yeh Credit hoga yani "C"

                    if (CustomerCOAId <= 0 || CashCOAId <= 0)
                    {
                        MessageBox.Show("Error While Save Cash Receipt. Customer Account or Cash Account is missing", "Account Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (CustomerCOAId == CashCOAId)
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
                    VM.UpdateVoucharMaster(this.VoucherMasterId, Convert.ToDateTime(dtpVoucher.Value), "CR", "K", txtNaration.Text, Convert.ToDecimal(txtAmount.Text), Convert.ToDecimal(txtAmount.Text) , MainForm.User_Id , DateTime.Now.Date, "", dataAcess);
                    VM.InsertVoucherDetail(this.VoucherMasterId, "" , "", CustomerCOAId, txtAccCode.Text, "D", Convert.ToDecimal(txtAmount.Text), txtRemarks.Text, dataAcess);
                    VM.InsertVoucherDetail(this.VoucherMasterId, "", "", CashCOAId, txtCashAcc.Text, "C", Convert.ToDecimal(txtAmount.Text), txtRemarks.Text, dataAcess);
                    dataAcess.TransCommit();
                    MessageBox.Show("Cash Receipt Updated Successfull", "Record Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            DialogResult result = MessageBox.Show("Are you sure want to Delete it?", "VoucherMaster Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                sVoucher[0] = new Smartworks.ColumnField("@Type", "CR");

                search.getattributes("sp_GetVoucherSearch", sVoucher, "VoucherMaster");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtReceiptVoucherCode.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                }
                else
                {
                    txtReceiptVoucherCode.Text = string.Empty;
                    txtReceiptVoucherCode.Focus();
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
                search.getattributes("GetCustomerSearch", null, "Customer");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtCustomerCode.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                }
                else
                {
                    txtCustomerCode.Text = string.Empty;
                    txtCustomerCode.Focus();

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
            if (!string.IsNullOrEmpty(txtReceiptVoucherCode.Text))
            {
                VoucherMasterId = VM.GetVoucherMasterIdByCode(txtReceiptVoucherCode.Text, MainForm.FYear);
                if (VoucherMasterId > 0)
                {
                    LoadVoucher(VoucherMasterId);
                }
            }
        }

        private void txtReceiptVoucherCode_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtReceiptVoucherCode.Text))
            {
                VoucherMasterId = VM.GetVoucherMasterIdByCode(txtReceiptVoucherCode.Text, MainForm.FYear);
                if (VoucherMasterId > 0)
                {
                    LoadVoucher(VoucherMasterId);
                }
            }
        }

        private void txtCustomerCode_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCustomerCode.Text))
            {
                CustomerManager Customer = new CustomerManager();
                CustomerId = Customer.GetCustomerIdByCode(txtCustomerCode.Text);
                if (CustomerId > 0)
                {
                    LoadCustomer(CustomerId);
                }
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

            txtReceiptVoucherCode.Text = VM.GetMaxVoucherNo("CR", MainForm.FYear);
            if (!string.IsNullOrEmpty(txtReceiptVoucherCode.Text))
            {
                VoucherMasterId = VM.GetVoucherMasterIdByCode(txtReceiptVoucherCode.Text, MainForm.FYear);
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
            if (!string.IsNullOrEmpty(txtReceiptVoucherCode.Text))
            {

                string LastVoucherNo = VM.GetMaxVoucherNo("CR", MainForm.FYear);
                txtReceiptVoucherCode.Text = VM.GetNextVoucherNo(txtReceiptVoucherCode.Text);
                VoucherMasterId = VM.GetVoucherMasterIdByCode(txtReceiptVoucherCode.Text, MainForm.FYear);
                if (VoucherMasterId > 0)
                {
                    LoadVoucher(VoucherMasterId);
                    if (LastVoucherNo == txtReceiptVoucherCode.Text)
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
            if (!string.IsNullOrEmpty(txtReceiptVoucherCode.Text))
            {
                string LastInvioceNo = VM.GetMinVoucherNo("CR", MainForm.FYear);
                txtReceiptVoucherCode.Text = VM.GetPrevVoucherNo(txtReceiptVoucherCode.Text);
                VoucherMasterId = VM.GetVoucherMasterIdByCode(txtReceiptVoucherCode.Text, MainForm.FYear);
                if (VoucherMasterId > 0)
                {
                    LoadVoucher(VoucherMasterId);
                    if (LastInvioceNo == txtReceiptVoucherCode.Text)
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
            txtReceiptVoucherCode.Text = VM.GetMinVoucherNo("CR", MainForm.FYear);
            if (!string.IsNullOrEmpty(txtReceiptVoucherCode.Text))
            {
                LoadVoucher(VoucherMasterId);
                btnNextInvioceNo.Enabled = true;
                btnPrevInvioceNo.Enabled = false;
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

        private void frmCashReceiptVoucher_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void btnCOASearch_Click(object sender, EventArgs e)
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

        private void btnAccSearch_Click(object sender, EventArgs e)
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
                if (string.IsNullOrEmpty(txtReceiptVoucherCode.Text))
                {
                    return;
                }

                ReportDocument document = new ReportDocument();
                string path = Application.StartupPath + "/rpt/Accounts/rptVoucher.rpt";
                document.Load(path);
                DataTable dtReport = new DataTable();
                dtReport = manageAccount.GetReportVoucher(txtReceiptVoucherCode.Text, txtReceiptVoucherCode.Text, dtpVoucher.Value, dtpVoucher.Value, "CR");
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
