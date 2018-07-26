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
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using FIL;
using CrystalDecisions.CrystalReports.Engine;



public partial class frmBankJournalVoucher : Form
{
    Smartworks.DAL dataAcess = new Smartworks.DAL();
    AccountManager manageAccount = new AccountManager();
    BankManager manageBank = new BankManager();
    VoucherManager VM = new VoucherManager();
    BindingSource bsCOA = new BindingSource();
    BindingSource bsFlagDC = new BindingSource();
    RepositoryItemGridLookUpEdit repositoryGridLookup = new RepositoryItemGridLookUpEdit();
    RepositoryItemGridLookUpEdit repositoryAccountCodeGridLookup = new RepositoryItemGridLookUpEdit();
    RepositoryItemGridLookUpEdit repositoryFlagGridLookup = new RepositoryItemGridLookUpEdit();
    DataSet dsMain = null;
    int VoucherMasterId = -1;
    int BankVoucherDetailId = -1;
    //int VendorId = -1;
    DataRow drMaster;
    DataView dvCOA;
    DataViewManager dvm;
    string VoucherType = string.Empty;



    public frmBankJournalVoucher(string pVoucherType)
    {
        InitializeComponent();
        this.VoucherType = pVoucherType;
    }


    private void frmCashReceiptVoucher_Load(object sender, EventArgs e)
    {
        try
        {
            ButtonRights(true);
            setupGrip();
            setHeading();
            FillDropdown();
            btnNextInvioceNo.Enabled = false;
            btnPrevInvioceNo.Enabled = false;
            txtJVCode.Text = GetNewNextNumber();
            //txtAccCode.Focus();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
    #region Method

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

    private void setHeading()
    {
        if (!string.IsNullOrEmpty(this.VoucherType))
        {
            if (this.VoucherType == "CR")
            {
                lblHeaderEn.Text = "Cash Receipt";

            }
            else if (this.VoucherType == "CP")
            {
                lblHeaderEn.Text = "Cash Payment";
            }
            else if (this.VoucherType == "BR")
            {
                lblHeaderEn.Text = "Bank Receipt";
            }
            else if (this.VoucherType == "BP")
            {
                lblHeaderEn.Text = "Bank Payment";
            }
            else if (this.VoucherType == "JV")
            {
                lblHeaderEn.Text = "Journal Voucher";
            }
            else
            {
                lblHeaderEn.Text = "";
            }
        }
    }


    private void setupGrip()
    {
        dsMain = new DataSet();
        dsMain = VM.GetVoucherStructure(VoucherMasterId);

        dsMain.Tables[0].TableName = "VoucherMaster";
        dsMain.Tables[1].TableName = "VoucherDetail";
        dsMain.Tables[2].TableName = "FlagDC";
        dsMain.Tables[3].TableName = "ChartOfAccounts";
        dsMain.Tables[4].TableName = "BankVoucherDetail";

        dsMain.Tables["VoucherMaster"].Columns["VoucherMasterId"].AutoIncrement = true;
        dsMain.Tables["VoucherMaster"].Columns["VoucherMasterId"].AutoIncrementSeed = -1;
        dsMain.Tables["VoucherMaster"].Columns["VoucherMasterId"].AutoIncrementStep = -1;

        dsMain.Tables["VoucherDetail"].Columns["VoucherDetailId"].AutoIncrement = true;
        dsMain.Tables["VoucherDetail"].Columns["VoucherDetailId"].AutoIncrementSeed = -1;
        dsMain.Tables["VoucherDetail"].Columns["VoucherDetailId"].AutoIncrementStep = -1;


        dsMain.Relations.Add("MasterRelation", dsMain.Tables["VoucherMaster"].Columns["VoucherMasterId"], dsMain.Tables["VoucherDetail"].Columns["VoucherMasterId"]);
        drMaster = dsMain.Tables["VoucherMaster"].NewRow();
        dsMain.Tables["VoucherMaster"].Rows.Add(drMaster);
        dvm = new DataViewManager(dsMain);
        dvCOA = dvm.CreateDataView(dsMain.Tables["ChartOfAccounts"]);
        GCDetail.DataSource = dsMain.Tables["VoucherDetail"];
        GridSetting();
    }

    private void GridSetting()
    {
        gvDetail.Columns.ColumnByName("colVoucherDetailId").OptionsColumn.ReadOnly = true;
        gvDetail.Columns.ColumnByName("colVoucherMasterId").OptionsColumn.ReadOnly = true;

        gvDetail.Columns.ColumnByName("colVoucherDetailId").Visible = false;
        gvDetail.Columns.ColumnByName("colVoucherMasterId").Visible = false;
        gvDetail.Columns.ColumnByName("colCustomerCode").Visible = false;
        gvDetail.Columns.ColumnByName("colVendorCode").Visible = false;


        gvDetail.Columns.ColumnByName("colCOAId").Caption = "Account Name";
        gvDetail.Columns.ColumnByName("colAccountCode").Caption = "Account Code";
        gvDetail.Columns.ColumnByName("colFlagDC").Caption = "D/C";
        gvDetail.Columns.ColumnByName("colAmount").Caption = "Amount";
        gvDetail.Columns.ColumnByName("colRemarks").Caption = "Remarks";


        gvDetail.Columns.ColumnByName("colAccountCode").VisibleIndex = 0;
        gvDetail.Columns.ColumnByName("colCOAId").VisibleIndex = 1;
        gvDetail.Columns.ColumnByName("colFlagDC").VisibleIndex = 2;
        gvDetail.Columns.ColumnByName("colAmount").VisibleIndex = 3;
        gvDetail.Columns.ColumnByName("colRemarks").VisibleIndex = 4;

        gvDetail.Columns.ColumnByName("colCOAId").Width = 150;
        gvDetail.Columns.ColumnByName("colAccountCode").Width = 100;
        gvDetail.Columns.ColumnByName("colFlagDC").Width = 80;
        gvDetail.Columns.ColumnByName("colAmount").Width = 100;
        gvDetail.Columns.ColumnByName("colRemarks").Width = 200;


        bsCOA.DataSource = dsMain;
        bsCOA.DataMember = "ChartOfAccounts";

        bsFlagDC.DataSource = dsMain;
        bsFlagDC.DataMember = "FlagDC";

        repositoryGridLookup.DataSource = bsCOA;
        repositoryGridLookup.DisplayMember = "AccountName";
        repositoryGridLookup.ValueMember = "COAId";
        repositoryGridLookup.PopupFormSize = new Size(380, 150);
        repositoryGridLookup.NullText = "";
        repositoryGridLookup.ShowFooter = true;
        repositoryGridLookup.View.OptionsView.ColumnAutoWidth = false;
        repositoryGridLookup.PopulateViewColumns();
        GCDetail.RepositoryItems.Add(repositoryGridLookup);

        (GCDetail.MainView as GridView).Columns.ColumnByName("colCOAId").ColumnEdit = repositoryGridLookup;

        if (repositoryGridLookup.View.Columns.Count > 0)
        {

            repositoryGridLookup.View.Columns.ColumnByName("colCOAId").Visible = false;

            repositoryGridLookup.View.Columns.ColumnByName("colAccountCode").Caption = "Code";
            repositoryGridLookup.View.Columns.ColumnByName("colAccountName").Caption = "Account Name";

            repositoryGridLookup.View.Columns.ColumnByName("colAccountCode").Width = 80;
            repositoryGridLookup.View.Columns.ColumnByName("colAccountName").Width = 250;

            repositoryGridLookup.View.Columns.ColumnByName("colAccountCode").VisibleIndex = 0;
            repositoryGridLookup.View.Columns.ColumnByName("colAccountName").VisibleIndex = 1;
        }

        repositoryAccountCodeGridLookup.DataSource = bsCOA;
        repositoryAccountCodeGridLookup.DisplayMember = "AccountCode";
        repositoryAccountCodeGridLookup.ValueMember = "AccountCode";
        repositoryAccountCodeGridLookup.PopupFormSize = new Size(380, 150);
        repositoryAccountCodeGridLookup.NullText = "";
        repositoryAccountCodeGridLookup.ShowFooter = true;
        repositoryAccountCodeGridLookup.View.OptionsView.ColumnAutoWidth = false;
        repositoryAccountCodeGridLookup.PopulateViewColumns();
        GCDetail.RepositoryItems.Add(repositoryAccountCodeGridLookup);

        (GCDetail.MainView as GridView).Columns.ColumnByName("colAccountCode").ColumnEdit = repositoryAccountCodeGridLookup;

        if (repositoryAccountCodeGridLookup.View.Columns.Count > 0)
        {

            repositoryAccountCodeGridLookup.View.Columns.ColumnByName("colCOAId").Visible = false;

            repositoryAccountCodeGridLookup.View.Columns.ColumnByName("colAccountCode").Caption = "Code";
            repositoryAccountCodeGridLookup.View.Columns.ColumnByName("colAccountName").Caption = "Account Name";

            repositoryAccountCodeGridLookup.View.Columns.ColumnByName("colAccountCode").Width = 80;
            repositoryAccountCodeGridLookup.View.Columns.ColumnByName("colAccountName").Width = 250;

            repositoryAccountCodeGridLookup.View.Columns.ColumnByName("colAccountCode").VisibleIndex = 0;
            repositoryAccountCodeGridLookup.View.Columns.ColumnByName("colAccountName").VisibleIndex = 1;
        }




        repositoryFlagGridLookup.DataSource = bsFlagDC;
        repositoryFlagGridLookup.DisplayMember = "Flag";
        repositoryFlagGridLookup.ValueMember = "FlagDC";
        repositoryFlagGridLookup.PopupFormMinSize = new Size(100, 90);
        //repositoryFlagGridLookup. = new Size(50, 50);
        repositoryFlagGridLookup.PopupFormSize = new Size(100, 90);
        repositoryFlagGridLookup.NullText = "";
        repositoryFlagGridLookup.ShowFooter = true;
        repositoryFlagGridLookup.View.OptionsView.ColumnAutoWidth = false;
        repositoryFlagGridLookup.PopulateViewColumns();
        GCDetail.RepositoryItems.Add(repositoryFlagGridLookup);
        (GCDetail.MainView as GridView).Columns.ColumnByName("colFlagDC").ColumnEdit = repositoryFlagGridLookup;

        if (repositoryFlagGridLookup.View.Columns.Count > 0)
        {
            repositoryFlagGridLookup.View.Columns.ColumnByName("colFlagDC").Visible = false;
            repositoryFlagGridLookup.View.Columns.ColumnByName("colFlag").Width = 80;
        }
        //gvDetail.Columns.ColumnByName("colAccountCode").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
        //gvDetail.Columns.ColumnByName("colCOAId").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;

    }


    private void ButtonRights(bool Enable)
    {
        btnAdd.Enabled = Enable;
        btnUpdate.Enabled = !Enable;
        btnDelete.Enabled = !Enable;
        txtJVCode.ReadOnly = !Enable;
        //btnAccSearch.Enabled = Enable;
    }

    private void ClearFeilds()
    {

        txtJVCode.Text = string.Empty;
        txtNaration.Text = string.Empty;
        dtpVoucher.Value = DateTime.Now;
        dtpCheque.Value = DateTime.Now;
        dtpBillDate.Value = DateTime.Now;
        txtChequeAmount.Text = string.Empty;
        txtBillNo.Text = string.Empty;
        cmbChequeBank.SelectedIndex = 0;
        txtChequeNumber.Text = string.Empty;
        this.VoucherMasterId = -1;
        this.BankVoucherDetailId = -1;
        dsMain.Tables["VoucherDetail"].Rows.Clear();
        dsMain.Tables["VoucherMaster"].Rows.Clear();
        dsMain.RejectChanges();
        drMaster = dsMain.Tables["VoucherMaster"].NewRow();
        dsMain.Tables["VoucherMaster"].Rows.Add(drMaster);
        GCDetail.DataSource = dsMain.Tables["VoucherDetail"];
        GridSetting();
        PostedControls(false);
        ButtonRights(true);
        btnNextInvioceNo.Enabled = false;
        btnPrevInvioceNo.Enabled = false;

        txtJVCode.Text = GetNewNextNumber();
        dtpVoucher.Focus();
    }

    private bool Validation()
    {
        bool result = true;


        if (dsMain.Tables["VoucherDetail"].Rows.Count == 0)
        {
            MessageBox.Show("Detail does not found. Please Enter Voucher Detail", "Detail Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            result = false;
            GCDetail.Focus();
            return result;
        }

        if (Convert.ToDecimal(txtTotalDebit.Text) != Convert.ToDecimal(txtTotalCredit.Text))
        {
            MessageBox.Show("Detail should be Match. " + Environment.NewLine + " Total Debit Amount & Total Credit Amount must be equal.", "Miss Match Debit Credit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            result = false;
            GCDetail.Focus();
            return result;
        }
        if (string.IsNullOrEmpty(this.VoucherType))
        {
            MessageBox.Show("Voucher Type Not Found. " + Environment.NewLine + " Some thing is Invalid condition Current running Form.", "Voucher Type is Mising.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            result = false;
            return result;
        }

        if (dtpVoucher.Value.Date < MainForm.FicalYearStart.Date || dtpVoucher.Value.Date > MainForm.FicalYearEnd.Date)
        {
            MessageBox.Show("Invalid Date Selection. Selected Date is Out of Rang of Fical Year", "Invalid Date Selection.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            result = false;
        }
        return result;

    }

    private void LoadVoucher(int VoucherMasterId)
    {

        //dsMain = VM.GetVoucherStructure(VoucherMasterId);
        setupGrip();
        txtJVCode.Text = dsMain.Tables["VoucherMaster"].Rows[0]["VoucherNumber"].ToString();
        dtpVoucher.Text = dsMain.Tables["VoucherMaster"].Rows[0]["Date"].ToString();
        txtNaration.Text = dsMain.Tables["VoucherMaster"].Rows[0]["Narration"].ToString();
        if (dsMain.Tables["BankVoucherDetail"].Rows.Count > 0)
        {
            BankVoucherDetailId = Convert.ToInt32(dsMain.Tables["BankVoucherDetail"].Rows[0]["BankVoucherDetailId"]);
            dtpCheque.Value = Convert.ToDateTime(dsMain.Tables["BankVoucherDetail"].Rows[0]["ChequeDate"]);
            txtChequeAmount.Text = dsMain.Tables["BankVoucherDetail"].Rows[0]["ChequeAmount"].ToString();
            cmbChequeBank.SelectedValue = dsMain.Tables["BankVoucherDetail"].Rows[0]["ChequeBankId"];
            txtChequeNumber.Text = dsMain.Tables["BankVoucherDetail"].Rows[0]["ChequeNumber"].ToString();
            txtBillNo.Text = dsMain.Tables["BankVoucherDetail"].Rows[0]["BillNo"].ToString();
            if (!string.IsNullOrEmpty(dsMain.Tables["BankVoucherDetail"].Rows[0]["BillDate"].ToString()))
            {
                dtpBillDate.Value = Convert.ToDateTime(dsMain.Tables["BankVoucherDetail"].Rows[0]["BillDate"]);
            }
            else
            {
                dtpBillDate.Value = DateTime.Now;
            }

        }
        else
        {
            BankVoucherDetailId = -1;
        }



        if (Convert.ToBoolean(dsMain.Tables["VoucherMaster"].Rows[0]["Posted"]))
        {
            PostedControls(true);
        }
        else
        {
            PostedControls(false);
            lblPosted.Visible = false;
            ButtonRights(false);
        }

        //for Navigation Works*******
        try
        {
            //txtJVCode.Text = VM.GetMaxVoucherNo(this.VoucherType);
            string FirstTransNo = VM.GetMinVoucherNo(this.VoucherType ,MainForm.FYear);
            string LastTransNo = VM.GetMaxVoucherNo(this.VoucherType , MainForm.FYear);
            if (LastTransNo == txtJVCode.Text)
            {
                btnNextInvioceNo.Enabled = false;
            }
            else
            {
                btnNextInvioceNo.Enabled = true;
            }
            if (FirstTransNo == txtJVCode.Text)
            {
                btnPrevInvioceNo.Enabled = false;
            }
            else
            {
                btnPrevInvioceNo.Enabled = true;
            }
        }
        catch (Exception ex)
        {
        }
    }

    private void PostedControls(bool IsPosted)
    {
        btnAdd.Enabled = !IsPosted;
        btnUpdate.Enabled = !IsPosted;
        btnDelete.Enabled = !IsPosted;
        GCDetail.Enabled = !IsPosted;
        txtJVCode.Enabled = !IsPosted;
        dtpVoucher.Enabled = !IsPosted;
        txtNaration.Enabled = !IsPosted;
        lblPosted.Visible = IsPosted;

    }

    private void DeleteVoucher(int VoucherMasterId)
    {
        try
        {
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

                dataAcess.BeginTransaction();
                if (dataAcess.getDBCommand().Transaction == null)
                {
                    dataAcess.SetDBTransaction();
                }
                VoucherMasterId = Convert.ToInt32(VM.InsertVoucharMaster(Convert.ToDateTime(dtpVoucher.Value), this.VoucherType, "H", txtNaration.Text, Convert.ToDecimal(txtTotalDebit.Text), Convert.ToDecimal(txtTotalCredit.Text), MainForm.User_Id, DateTime.Now.Date, "", dataAcess).Rows[0]["VoucherMasterId"]);
                foreach (DataRow dr in dsMain.Tables["VoucherDetail"].Rows)
                {
                    VM.InsertVoucherDetail(VoucherMasterId, "", "", Convert.ToInt32(dr["COAId"]), dr["AccountCode"].ToString(), dr["FlagDC"].ToString(), Convert.ToDecimal(dr["Amount"]), dr["Remarks"].ToString(), dataAcess);
                }
                manageBank.InsertUpdateBankVoucherDetail(BankVoucherDetailId, dtpVoucher.Value, string.Empty, string.Empty, -1, -1, (string.IsNullOrEmpty(txtChequeAmount.Text) ? 0 : Convert.ToDecimal(txtChequeAmount.Text)), dtpCheque.Value, (cmbChequeBank.SelectedIndex > 0 ? Convert.ToInt32(cmbChequeBank.SelectedValue) : -1), txtChequeNumber.Text, ((this.VoucherType == "BR") ? "Receipt" : "Payment"), VoucherMasterId, this.VoucherType, txtBillNo.Text, dtpBillDate.Value, dataAcess);
                dataAcess.TransCommit();

                MessageBox.Show("Voucher Insert Successfull", "Record Inserted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFeilds();
            }
            catch (SqlException sqlex)
            {
                dataAcess.TransRollback();
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

                dataAcess.BeginTransaction();
                VM.DeleteVoucharDetailByMasterId(this.VoucherMasterId, dataAcess);
                VM.UpdateVoucharMaster(this.VoucherMasterId, Convert.ToDateTime(dtpVoucher.Value), this.VoucherType, "H", txtNaration.Text, Convert.ToDecimal(txtTotalDebit.Text), Convert.ToDecimal(txtTotalCredit.Text), MainForm.User_Id, DateTime.Now, "", dataAcess);
                foreach (DataRow dr in dsMain.Tables["VoucherDetail"].Rows)
                {
                    if (dr.RowState != DataRowState.Deleted)
                    {
                        VM.InsertVoucherDetail(VoucherMasterId, "", "", Convert.ToInt32(dr["COAId"]), dr["AccountCode"].ToString(), dr["FlagDC"].ToString(), Convert.ToDecimal(dr["Amount"]), dr["Remarks"].ToString(), dataAcess);
                    }
                }
                manageBank.InsertUpdateBankVoucherDetail(BankVoucherDetailId, dtpVoucher.Value, string.Empty, string.Empty, -1, -1, (string.IsNullOrEmpty(txtChequeAmount.Text) ? 0 : Convert.ToDecimal(txtChequeAmount.Text)), dtpCheque.Value, (cmbChequeBank.SelectedIndex > 0 ? Convert.ToInt32(cmbChequeBank.SelectedValue) : -1), txtChequeNumber.Text, ((this.VoucherType == "BR") ? "Receipt" : "Payment"), VoucherMasterId, this.VoucherType, txtBillNo.Text, dtpBillDate.Value, dataAcess);
                dataAcess.TransCommit();
                MessageBox.Show("Voucher Update Successfull", "Record Updated.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFeilds();
            }
            catch (SqlException sqlex)
            {
                dataAcess.TransRollback();
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
            sVoucher[0] = new Smartworks.ColumnField("@Type", this.VoucherType);

            search.getattributes("sp_GetVoucherSearch", sVoucher, "VoucherMaster");
            search.ShowDialog();
            if (!string.IsNullOrEmpty(MainForm.Searched_Id))
            {
                txtJVCode.Text = MainForm.Searched_Id;
                MainForm.Searched_Id = string.Empty;
            }
            //else
            //{
            //    txtReceiptVoucherCode.Text = string.Empty;
            //    txtReceiptVoucherCode.Focus();
            //}

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void btnCustomerSearch_Click(object sender, EventArgs e)
    {
        //try
        //{

        //    frmSearch search = new frmSearch();
        //    search.getattributes("GetAccountSearch", null, "Party Accounts");
        //    search.ShowDialog();
        //    if (!string.IsNullOrEmpty(MainForm.Searched_Id))
        //    {
        //        txtAccCode.Text = MainForm.Searched_Id;
        //        MainForm.Searched_Id = string.Empty;
        //    }
        //    else
        //    {
        //        txtAccCode.Text = string.Empty;
        //        txtAccCode.Focus();

        //    }
        //}
        //catch (Exception ex)
        //{
        //    MessageBox.Show(ex.Message);
        //}
    }

    private void txtReceiptVoucherCode_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.F4)
        {
            //btnAccSearch.PerformClick();
        }

    }

    private void txtReceiptVoucherCode_Leave(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtJVCode.Text))
        {
            VoucherMasterId = VM.GetVoucherMasterIdByCode(txtJVCode.Text, MainForm.FYear);
            if (VoucherMasterId > 0)
            {
                LoadVoucher(VoucherMasterId);
            }
        }
    }

    private void txtReceiptVoucherCode_TextChanged(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtJVCode.Text))
        {
            VoucherMasterId = VM.GetVoucherMasterIdByCode(txtJVCode.Text,MainForm.FYear);
            if (VoucherMasterId > 0)
            {
                LoadVoucher(VoucherMasterId);
            }
        }
    }

    VendorManager Vendor = new VendorManager();

    private void txtCustomerCode_TextChanged(object sender, EventArgs e)
    {
        //if (!string.IsNullOrEmpty(txtAccCode.Text))
        //{
        //    VendorId = Vendor.GetVendorIdByCode(txtAccCode.Text);
        //    if (VendorId > 0)
        //    {
        //        LoadVendor(VendorId);
        //    }
        //}
        //else
        //{
        //    txtAccountName.Text = string.Empty;
        //}
        //if (!string.IsNullOrEmpty(txtAccCode.Text))
        //{
        //    DataTable dtAccount = manageAccount.GetCOA(manageAccount.GetCOAIdByCode(txtAccCode.Text));
        //    if (dtAccount.Rows.Count > 0)
        //    {
        //        txtAccountName.Text = dtAccount.Rows[0]["AccountName"].ToString();
        //    }
        //    else
        //    {
        //        txtAccountName.Text = string.Empty;
        //    }
        //    txtBalance.Text = manageAccount.GetCOABalance(txtAccCode.Text, dtpVoucher.Value).ToString();
        //}
        //else
        //{
        //    txtAccountName.Text = string.Empty;
        //}
    }


    private void LoadVendor(int VendorId)
    {
        DataTable dtVendor = Vendor.GetVendor(VendorId);
        if (dtVendor.Rows.Count > 0)
        {
            //txtAccCode.Text = dtVendor.Rows[0]["Code"].ToString();
            //txtAccountName.Text = dtVendor.Rows[0]["VendorName"].ToString();
            //txtBalance.Text = dtVendor.Rows[0]["Balance"].ToString();
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
        //else if (!char.IsDigit(ch) && ch != '.' || !Decimal.TryParse(txtAmount.Text + ch, out x))
        //{
        //    e.Handled = true;
        //}
    }

    private void btnMaxInvioceNo_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(VM.GetMaxVoucherNo(this.VoucherType,MainForm.FYear)))
        {
            txtJVCode.Text = VM.GetMaxVoucherNo(this.VoucherType, MainForm.FYear);
            if (!string.IsNullOrEmpty(txtJVCode.Text))
            {
                //VoucherMasterId = VM.GetVoucherMasterIdByCode(txtJVCode.Text);
                //if (VoucherMasterId > 0)
                //{
                //    LoadVoucher(VoucherMasterId);
                //    btnNextInvioceNo.Enabled = false;
                //    btnPrevInvioceNo.Enabled = true;
                //}
            }
        }
        
    }

    private void btnNextInvioceNo_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtJVCode.Text))
        {
            string LastVoucherNo = VM.GetMaxVoucherNo(this.VoucherType,MainForm.FYear);
            txtJVCode.Text = VM.GetNextVoucherNo(txtJVCode.Text);
            //VoucherMasterId = VM.GetVoucherMasterIdByCode(txtJVCode.Text);
            //if (VoucherMasterId > 0)
            //{
            //LoadVoucher(VoucherMasterId);
            if (LastVoucherNo == txtJVCode.Text)
            {
                btnNextInvioceNo.Enabled = false;
            }
            else
            {
                btnPrevInvioceNo.Enabled = true;
            }
            //}


        }
    }

    private void btnPrevInvioceNo_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtJVCode.Text))
        {
            string LastInvioceNo = VM.GetMinVoucherNo(this.VoucherType,MainForm.FYear);
            txtJVCode.Text = VM.GetPrevVoucherNo(txtJVCode.Text);
            //VoucherMasterId = VM.GetVoucherMasterIdByCode(txtJVCode.Text);
            //if (VoucherMasterId > 0)
            //{
            //    LoadVoucher(VoucherMasterId);
            if (LastInvioceNo == txtJVCode.Text)
            {
                btnPrevInvioceNo.Enabled = false;
            }
            else
            {
                btnNextInvioceNo.Enabled = true;
            }
            //}
        }
    }

    private void btnMinInvioceNo_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(VM.GetMinVoucherNo(this.VoucherType, MainForm.FYear)))
        {
            txtJVCode.Text = VM.GetMinVoucherNo(this.VoucherType, MainForm.FYear);
            if (!string.IsNullOrEmpty(txtJVCode.Text))
            {
                //LoadVoucher(VoucherMasterId);
                //btnNextInvioceNo.Enabled = true;
                //btnPrevInvioceNo.Enabled = false;
            }
        }
        
    }

    private String GetNewNextNumber()
    {
        string NewInvoiceNo = "";
        NewInvoiceNo = VM.GetMaxVoucherNo(this.VoucherType , MainForm.FYear);
        if (!string.IsNullOrEmpty(NewInvoiceNo))
        {
            NewInvoiceNo = VM.GetNextVoucherNo(NewInvoiceNo);
        }
        else
        {
            NewInvoiceNo = this.VoucherType + "-000001";
        }
        return NewInvoiceNo;
    }

    private void CalculateSummary()
    {
        decimal TotalDebit = 0;
        decimal TotalCredit = 0;

        foreach (DataRow dr in dsMain.Tables["VoucherDetail"].Rows)
        {
            if (dr["FlagDC"].ToString().Trim() == "D")
            {
                TotalDebit += Convert.ToDecimal(dr["Amount"]);
            }
            else if (dr["FlagDC"].ToString().Trim() == "C")
            {
                TotalCredit += Convert.ToDecimal(dr["Amount"]);
            }
        }
        txtTotalDebit.Text = TotalDebit.ToString();
        txtTotalCredit.Text = TotalCredit.ToString();
    }
    private void frmCashReceiptVoucher_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.F6)
        {
            ClearFeilds();
        }
        else if (e.KeyCode == Keys.F3)
        {
            if (btnAdd.Enabled)
            {
                btnAdd.PerformClick();
            }
            else if (btnUpdate.Enabled)
            {
                btnUpdate.PerformClick();
            }
        }
        else if (e.KeyCode == Keys.Enter)
        {
            if (!GCDetail.Focus())
            {
                SendKeys.Send("{TAB}");
            }
        }
        else if (e.KeyCode == Keys.Escape)
        {
            this.Close();
        }
    }

    private void dtpVoucher_ValueChanged(object sender, EventArgs e)
    {
        try
        {
            //txtBalance.Text = manageAccount.GetCOABalance(txtAccCode.Text, dtpVoucher.Value).ToString();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    #region GridEvents

    private void gvDetail_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
    {
        if (e.Value != null)
        {
            switch (e.Column.Name.ToString())
            {
                case "colCOAId":
                    {
                        dvCOA.RowFilter = "COAId='" + e.Value.ToString() + "'";
                        break;
                    }
                case "colAccountCode":
                    {

                        dvCOA.RowFilter = "AccountCode='" + e.Value.ToString() + "'";
                        break;
                    }
            }
        }
    }

    private void gvDetail_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
    {
        try
        {
            DataRow dr = gvDetail.GetFocusedDataRow();
            switch (e.Column.Name.ToString())
            {
                case "colCOAId":
                    {
                        dr["COAId"] = dvCOA[0]["COAId"];
                        dr["AccountCode"] = dvCOA[0]["AccountCode"];
                        if (string.IsNullOrEmpty(dr["Amount"].ToString()))
                        {
                            dr["Amount"] = "0";
                        }


                        break;
                    }

                case "colAccountCode":
                    {
                        dr["COAId"] = dvCOA[0]["COAId"];
                        dr["AccountCode"] = dvCOA[0]["AccountCode"];
                        if (string.IsNullOrEmpty(dr["Amount"].ToString()))
                        {
                            dr["Amount"] = "0";
                        }
                        break;
                    }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

    }



    private void gvDetail_RowCountChanged(object sender, EventArgs e)
    {
        CalculateSummary();
    }

    private void gvDetail_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
    {
        DataRow dr = default(DataRow);
        dr = gvDetail.GetDataRow(e.RowHandle);

        if (decimal.Parse(dr["COAId"].ToString()) <= 0)
        {
            e.Valid = false;
            e.ErrorText = "Account Name Not Found.";
        }
        if (decimal.Parse(dr["Amount"].ToString()) <= 0)
        {

            e.Valid = false;
            e.ErrorText = "Amount Should be greater then zero";
        }
        if (string.IsNullOrEmpty(dr["FlagDC"].ToString()))
        {
            e.Valid = false;
            e.ErrorText = "Invalid Flag D/C";
        }


        //if (dr.RowState == DataRowState.Detached)
        //{
        //    if (dsMain.Tables["VoucherDetail"].Select("COAId =" + dr["COAId"].ToString()).Length > 0)
        //    {
        //        //MessageBox.Show("Account Already Exists", "Same Account can not be repeated.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        e.Valid = false;
        //        e.ErrorText = "Account Already Exists" + Environment.NewLine + "Same Account can not be repeated.";
        //    }
        //}
        //else
        //{
        e.Valid = true;
        gvDetail.GetDataRow(e.RowHandle)["VoucherMasterId"] = drMaster["VoucherMasterId"]; //SalesMasterId;
        //}
    }

    private void gvDetail_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
    {
        DataRow dr = gvDetail.GetFocusedDataRow();
        if ((dr != null))
        {
            if (!string.IsNullOrEmpty(dr["COAId"].ToString()))
            {

                if (!string.IsNullOrEmpty(dvCOA.RowFilter))
                {
                    if (!dvCOA.RowFilter.Contains("AccountCode"))
                    {
                        dvCOA.RowFilter = "COAId='" + dr["COAId"].ToString() + "'";
                    }
                }
                else
                {
                    dvCOA.RowFilter = "COAId='" + dr["COAId"].ToString() + "'";
                }
            }
        }
    }

    private void gvDetail_GotFocus(object sender, EventArgs e)
    {
        gvDetail_FocusedRowChanged(null, new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(0, gvDetail.FocusedRowHandle));
        CalculateSummary();
    }

    private void gvDetail_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
    {
        if (e.Value != null)
        {
            DataRowView dr = (DataRowView)gvDetail.GetFocusedRow();
            if ((dr != null))
            {
                try
                {
                    switch (gvDetail.FocusedColumn.Name)
                    {
                        case "colCOAId":
                            if (string.IsNullOrEmpty(e.Value.ToString()))
                            {
                                e.Valid = false;
                            }
                            else if (decimal.Parse(e.Value.ToString()) <= 0)
                            {
                                e.Valid = false;
                            }
                            break;
                        case "colAccountCode":
                            if (string.IsNullOrEmpty(e.Value.ToString()))
                            {
                                e.Valid = false;
                            }

                            break;

                    }
                }
                catch (Exception ex)
                {
                }
            }
        }
        else
        {
            gvDetail.CancelUpdateCurrentRow();
        }
    }

    private void gvDetail_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
    {
        MessageBox.Show(e.ErrorText, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    private void gvDetail_InvalidValueException(object sender, DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
    {
        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;

        switch (gvDetail.FocusedColumn.Name)
        {
            case "colCOAId":
                gvDetail.FocusedColumn = gvDetail.Columns.ColumnByName("colCOAId");
                break;
            case "colAccountCode":
                gvDetail.FocusedColumn = gvDetail.Columns.ColumnByName("colAccountCode");
                e.ErrorText = "error";
                break;
            case "colFlagDC":
                gvDetail.FocusedColumn = gvDetail.Columns.ColumnByName("colFlagDC");
                e.ErrorText = "Invalid Flag";
                break;
            case "colAmount":
                gvDetail.FocusedColumn = gvDetail.Columns.ColumnByName("colAmount");
                e.ErrorText = "Invalid Amount";
                MessageBox.Show(e.ErrorText, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                break;
        }
        gvDetail.HideEditor();
    }

    private void GCDetail_Click(object sender, EventArgs e)
    {

    }


    #endregion

    private void btnPrint_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(txtJVCode.Text))
            {
                return;
            }

            ReportDocument document = new ReportDocument();
            string path = Application.StartupPath + "/rpt/Accounts/rptBankVoucher.rpt";
            document.Load(path);
            DataTable dtReport = new DataTable();
            dtReport = manageAccount.GetReportBankVoucher(txtJVCode.Text, txtJVCode.Text, dtpVoucher.Value, dtpVoucher.Value, this.VoucherType);
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

    Utility clsUtility = new Utility();
    private void txtChequeAmount_KeyPress(object sender, KeyPressEventArgs e)
    {
        clsUtility.setOnlyNumberic((TextBox)sender, false, e);
    }
}

