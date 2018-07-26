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
using FIL;



public partial class frmBankPayment : Form
{
    Smartworks.DAL dataAcess = new Smartworks.DAL();
    int VoucherMasterId = -1;
    int VendorId = -1;
    int BankACId = -1;
    int BankVoucherDetailId = -1;
    int BankId = -1;
    AccountManager manageAccount = new AccountManager();
    VoucherManager VM = new VoucherManager();
    BankManager manageBank = new BankManager();
    public frmBankPayment()
    {
        InitializeComponent();
    }


    private void frmCashPaymentVoucher_Load(object sender, EventArgs e)
    {
        try
        {
            ButtonRights(true);
            FillDropdown();
            txtPaymentVoucherCode.Text = GetNewNextNumber();
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
        NewInvoiceNo = VM.GetMaxVoucherNo("BP", MainForm.FYear);
        if (!string.IsNullOrEmpty(NewInvoiceNo))
        {
            NewInvoiceNo = VM.GetNextVoucherNo(NewInvoiceNo);
        }
        else
        {
            NewInvoiceNo = "BP-000001";
        }
        return NewInvoiceNo;
    }

    private void FillDropdown()
    {
        //BankId , BankName
        DataTable dtBank = manageBank.GetAllBank();
        DataRow drBank = dtBank.NewRow();
        drBank["BankId"] = -1;
        drBank["BankName"] = "--Select Bank--";
        dtBank.Rows.InsertAt(drBank, 0);

        cmbChequeBank.DataSource = dtBank;
        cmbChequeBank.DisplayMember = "BankName";
        cmbChequeBank.ValueMember = "BankId";
    }



    private void ButtonRights(bool Enable)
    {
        btnAdd.Enabled = Enable;
        btnUpdate.Enabled = !Enable;
        btnDelete.Enabled = !Enable;
        txtPaymentVoucherCode.ReadOnly = !Enable;
        btnVendorSearch.Enabled = Enable;
    }

    private void ClearFeilds()
    {

        txtPaymentVoucherCode.Text = string.Empty;
        txtVendorCode.Text = string.Empty;
        txtAmount.Text = "0.00";
        dtpVoucher.Text = string.Empty;
        //txtRemarks.Text = string.Empty;
        txtAccCode.Text = string.Empty;
        txtAccName.Text = string.Empty;
        txtBalance.Text = "0.00";
        txtNaration.Text = string.Empty;
        txtBankAcc.Text = string.Empty;
        txtBankAccName.Text = string.Empty;
        txtVendorName.Text = string.Empty;
        txtBankAccountCode.Text = string.Empty;
        txtBACTitle.Text = string.Empty;
        cmbChequeBank.SelectedIndex = 0;
        dtpCheque.Value = DateTime.Now;
        txtChequeNumber.Text = string.Empty;
        VoucherMasterId = -1;
        VendorId = -1;
        BankACId = -1;
        BankVoucherDetailId = -1;
        BankId = -1;

        txtPaymentVoucherCode.Text = GetNewNextNumber();
        btnVoucherSearch.Focus();
        ButtonRights(true);
        btnNextInvioceNo.Enabled = false;
        btnPrevInvioceNo.Enabled = false;
    }

    private bool Validation()
    {
        bool result = true;

        if (string.IsNullOrEmpty(txtVendorCode.Text))
        {
            MessageBox.Show("Please Enter Vendor Code", "Need Vendor Code.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            result = false;
            txtVendorCode.Focus();
            return result;
        }
        if (string.IsNullOrEmpty(txtAccCode.Text))
        {
            MessageBox.Show("Vendor Account does not found.", "Make sure Vendor Account Code is Map.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            result = false;
            txtVendorCode.Focus();
            return result;
        }

        if (string.IsNullOrEmpty(txtBankAcc.Text))
        {
            MessageBox.Show("Bank Account does not found.", "Make sure Bank Account Code is Map.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            result = false;
            txtBankAccountCode.Focus();
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

                DataRow drDebit = dsVocuher.Tables["VoucherDetail"].Select("FlagDC = 'C'")[0];
                txtVendorCode.Text = drDebit["VendorCode"].ToString();
                txtAccCode.Text = drDebit["AccountCode"].ToString();

                DataRow drCredit = dsVocuher.Tables["VoucherDetail"].Select("FlagDC = 'D'")[0];
                txtBankAcc.Text = drCredit["AccountCode"].ToString();
                //txtBankAccountCode

                //txtRemarks.Text = drCredit["Remarks"].ToString();
                DataTable dtVoucherDetail = manageBank.GetBankVoucherDetailByVoucherMasterId(VoucherMasterId);
                if (dtVoucherDetail.Rows.Count > 0)
                {
                    try
                    {
                        BankVoucherDetailId = Convert.ToInt32(dtVoucherDetail.Rows[0]["BankVoucherDetailId"]);
                        BankACId = Convert.ToInt32(dtVoucherDetail.Rows[0]["BankAccountId"]);
                        txtBankAccountCode.Text = manageBank.GetBankAccount(BankACId).Rows[0]["Code"].ToString();
                        txtChequeNumber.Text = dtVoucherDetail.Rows[0]["ChequeNumber"].ToString();
                        cmbChequeBank.SelectedValue = dtVoucherDetail.Rows[0]["ChequeBankId"].ToString();
                        dtpCheque.Value = Convert.ToDateTime(dtVoucherDetail.Rows[0]["ChequeDate"]);
                    }
                    catch (Exception ex)
                    {
                    }
                }

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

        VendorManager manageVendor = new VendorManager();
        DataTable dtVendor = manageVendor.GetVendor(VendorId);
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
    private void LoadBankAccount(int BankACId)
    {
        BankManager manageBank = new BankManager();
        DataTable dtBankAccount = manageBank.GetBankAccount(BankACId);
        if (dtBankAccount.Rows.Count > 0)
        {
            txtBACTitle.Text = dtBankAccount.Rows[0]["AccountTitle"].ToString();
            if (!string.IsNullOrEmpty(dtBankAccount.Rows[0]["COAId"].ToString()))
            {
                txtBankAcc.Text = manageAccount.GetChartOfAccounts(Convert.ToInt32(dtBankAccount.Rows[0]["COAId"])).Rows[0]["AccountCode"].ToString();
            }
            BankId = Convert.ToInt32(dtBankAccount.Rows[0]["BankId"]);
        }
    }
    private void DeleteVoucher(int VoucherMasterId)
    {
        try
        {

            dataAcess.BeginTransaction();
            manageBank.DeleteBankVoucherDetailByVoucherMasterId(VoucherMasterId, dataAcess);
            VM.DeleteVoucharMaster(VoucherMasterId, dataAcess);
            dataAcess.TransCommit();
            MessageBox.Show("Voucher Record Delete Successfull.", "Record Deleted.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFeilds();
        }
        catch (SqlException sqlex)
        {
            dataAcess.TransRollback();
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

                int BankCOAId, VendorCOAId = -1;
                VendorCOAId = manageAccount.GetCOAIdByCode(txtAccCode.Text); // yeh Debit hoga yani "C"
                BankCOAId = manageAccount.GetCOAIdByCode(txtBankAcc.Text); //yeh Credit hoga yani "D"

                if (VendorCOAId <= 0 || BankCOAId <= 0)
                {
                    MessageBox.Show("Error While Save Bank Payment. Vendor Account or Bank Account is missing", "Account Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (VendorCOAId == BankCOAId)
                {
                    MessageBox.Show("Vendor Account and Bank Account should not be Same.", "Same Account Restriction", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                dataAcess.BeginTransaction();
                if (dataAcess.getDBCommand().Transaction == null)
                {
                    dataAcess.SetDBTransaction();
                }

                dtVoucher = VM.InsertVoucharMaster(dtpVoucher.Value, "BP", "K", txtNaration.Text, Convert.ToDecimal(txtAmount.Text), Convert.ToDecimal(txtAmount.Text), MainForm.User_Id, DateTime.Now.Date, "", dataAcess);
                VoucherMasterId = Convert.ToInt32(dtVoucher.Rows[0]["VoucherMasterId"]);
                VM.InsertVoucherDetail(VoucherMasterId, "", txtVendorCode.Text, VendorCOAId, txtAccCode.Text, "C", Convert.ToDecimal(txtAmount.Text), "", dataAcess);
                VM.InsertVoucherDetail(VoucherMasterId, "", "", BankCOAId, txtBankAcc.Text, "D", Convert.ToDecimal(txtAmount.Text), "", dataAcess);
                manageBank.InsertUpdateBankVoucherDetail(BankVoucherDetailId, dtpVoucher.Value, string.Empty, txtVendorCode.Text, BankId, BankACId, Convert.ToDecimal(txtAmount.Text), dtpCheque.Value, (cmbChequeBank.SelectedIndex > 0 ? Convert.ToInt32(cmbChequeBank.SelectedValue) : -1), txtChequeNumber.Text, "Payment", VoucherMasterId, "BP", "", DateTime.Now ,  dataAcess);
                dataAcess.TransCommit();
                MessageBox.Show("Bank Payment Insert Successfull", "Record Inserted", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                int BankCOAId, VendorCOAId = -1;
                VendorCOAId = manageAccount.GetCOAIdByCode(txtAccCode.Text); // yeh Debit hoga yani "C"
                BankCOAId = manageAccount.GetCOAIdByCode(txtBankAcc.Text); //yeh Credit hoga yani "D"

                if (VendorCOAId <= 0 || BankCOAId <= 0)
                {
                    MessageBox.Show("Error While Save Bank Payment. Vendor Account or Bank Account is missing", "Account Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (VendorCOAId == BankCOAId)
                {
                    MessageBox.Show("Vendor Account and Bank Account should not be Same.", "Same Account Restriction", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                dataAcess.BeginTransaction();
                if (dataAcess.getDBCommand().Transaction == null)
                {
                    dataAcess.SetDBTransaction();
                }

                VM.DeleteVoucharDetailByMasterId(this.VoucherMasterId, dataAcess);
                VM.UpdateVoucharMaster(this.VoucherMasterId, Convert.ToDateTime(dtpVoucher.Value), "BP", "H", txtNaration.Text, Convert.ToDecimal(txtAmount.Text), Convert.ToDecimal(txtAmount.Text), MainForm.User_Id, DateTime.Now.Date, "", dataAcess);
                VM.InsertVoucherDetail(this.VoucherMasterId, "", txtVendorCode.Text, VendorCOAId, txtAccCode.Text, "C", Convert.ToDecimal(txtAmount.Text), "", dataAcess);
                VM.InsertVoucherDetail(this.VoucherMasterId, "", "", BankCOAId, txtBankAcc.Text, "D", Convert.ToDecimal(txtAmount.Text), "", dataAcess);
                manageBank.InsertUpdateBankVoucherDetail(BankVoucherDetailId, dtpVoucher.Value, txtVendorCode.Text, string.Empty, BankId, BankACId, Convert.ToDecimal(txtAmount.Text), dtpCheque.Value, (cmbChequeBank.SelectedIndex > 0 ? Convert.ToInt32(cmbChequeBank.SelectedValue) : -1), txtChequeNumber.Text, "Payment", VoucherMasterId, "BP" , "" , DateTime.Now  ,  dataAcess);
                dataAcess.TransCommit();
                MessageBox.Show("Bank Payment Updated Successfull", "Record Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            sVoucher[0] = new Smartworks.ColumnField("@Type", "BP");

            search.getattributes("sp_GetVoucherSearch", sVoucher, "VoucherMaster");
            search.ShowDialog();
            if (!string.IsNullOrEmpty(MainForm.Searched_Id))
            {
                txtPaymentVoucherCode.Text = MainForm.Searched_Id;
                MainForm.Searched_Id = string.Empty;
            }
            //else
            //{
            //    txtPaymentVoucherCode.Text = string.Empty;
            //    txtPaymentVoucherCode.Focus();
            //}

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
            search.getattributes("GetVendorSearch", null, "Vendor");
            search.ShowDialog();
            if (!string.IsNullOrEmpty(MainForm.Searched_Id))
            {
                txtVendorCode.Text = MainForm.Searched_Id;
                MainForm.Searched_Id = string.Empty;
            }
            //else
            //{
            //    txtVendorCode.Text = string.Empty;
            //    txtVendorCode.Focus();

            //}
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void txtPaymentVoucherCode_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            SendKeys.Send("{TAB}");
        }
    }

    private void txtPaymentVoucherCode_Leave(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtPaymentVoucherCode.Text))
        {
            VoucherMasterId = VM.GetVoucherMasterIdByCode(txtPaymentVoucherCode.Text , MainForm.FYear);
            if (VoucherMasterId > 0)
            {
                LoadVoucher(VoucherMasterId);
            }
        }
    }

    private void txtPaymentVoucherCode_TextChanged(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtPaymentVoucherCode.Text))
        {
            VoucherMasterId = VM.GetVoucherMasterIdByCode(txtPaymentVoucherCode.Text , MainForm.FYear);
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
            VendorManager manageVendor = new VendorManager();
            VendorId = manageVendor.GetVendorIdByCode(txtVendorCode.Text);
            if (VendorId > 0)
            {
                LoadVendor(VendorId);
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

        txtPaymentVoucherCode.Text = VM.GetMaxVoucherNo("BP", MainForm.FYear);
        if (!string.IsNullOrEmpty(txtPaymentVoucherCode.Text))
        {
            VoucherMasterId = VM.GetVoucherMasterIdByCode(txtPaymentVoucherCode.Text, MainForm.FYear);
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
        if (!string.IsNullOrEmpty(txtPaymentVoucherCode.Text))
        {

            string LastVoucherNo = VM.GetMaxVoucherNo("BP", MainForm.FYear);
            txtPaymentVoucherCode.Text = VM.GetNextVoucherNo(txtPaymentVoucherCode.Text);
            VoucherMasterId = VM.GetVoucherMasterIdByCode(txtPaymentVoucherCode.Text, MainForm.FYear);
            if (VoucherMasterId > 0)
            {
                LoadVoucher(VoucherMasterId);
                if (LastVoucherNo == txtPaymentVoucherCode.Text)
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
        if (!string.IsNullOrEmpty(txtPaymentVoucherCode.Text))
        {
            string LastInvioceNo = VM.GetMinVoucherNo("BP", MainForm.FYear);
            txtPaymentVoucherCode.Text = VM.GetPrevVoucherNo(txtPaymentVoucherCode.Text);
            VoucherMasterId = VM.GetVoucherMasterIdByCode(txtPaymentVoucherCode.Text, MainForm.FYear);
            if (VoucherMasterId > 0)
            {
                LoadVoucher(VoucherMasterId);
                if (LastInvioceNo == txtPaymentVoucherCode.Text)
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
        txtPaymentVoucherCode.Text = VM.GetMinVoucherNo("BP", MainForm.FYear);
        if (!string.IsNullOrEmpty(txtPaymentVoucherCode.Text))
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

    private void frmCashPaymentVoucher_KeyDown(object sender, KeyEventArgs e)
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
                txtBankAcc.Text = MainForm.Searched_Id;
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
            if (!string.IsNullOrEmpty(txtBankAcc.Text))
            {
                txtBankAccName.Text = manageAccount.GetChartOfAccounts(manageAccount.GetCOAIdByCode(txtBankAcc.Text)).Rows[0]["AccountName"].ToString();
            }
            else
            {
                txtBankAccName.Text = string.Empty;
            }

        }
        catch (Exception ex)
        {
            txtBankAccName.Text = string.Empty;
        }
    }

    private void btnBACSearch_Click(object sender, EventArgs e)
    {
        try
        {

            frmSearch search = new frmSearch();
            search.getattributes("GetBankAccountSearch", null, "Bank Accounts");
            search.ShowDialog();
            if (!string.IsNullOrEmpty(MainForm.Searched_Id))
            {
                txtBankAccountCode.Text = MainForm.Searched_Id;
                MainForm.Searched_Id = string.Empty;
            }

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void txtBankAccountCode_TextChanged(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtBankAccountCode.Text))
        {
            BankManager manageBank = new BankManager();
            BankACId = manageBank.GetBankACIdByCode(txtBankAccountCode.Text);
            if (BankACId > 0)
            {
                LoadBankAccount(BankACId);
            }
        }
        else
        {
            txtBACTitle.Text = string.Empty;
        }
    }


}

