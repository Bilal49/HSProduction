using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace FIL
{
    public partial class frmBankAccount : Form
    {
        int BankAccountId = -1;
        BankManager manageBank = new BankManager();
        AccountManager manageAccount = new AccountManager();
        public frmBankAccount()
        {
            InitializeComponent();
        }

        private void frmBankAccount_Load(object sender, EventArgs e)
        {
            try
            {

                ButtonRights(true);
                FillDropDown();
                txtCode.Text = GetNewNextNumber();
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
            NewInvoiceNo = manageBank.GetMaxBACCode();
            if (!string.IsNullOrEmpty(NewInvoiceNo))
            {
                NewInvoiceNo = manageBank.GetNextBACCode(NewInvoiceNo);
            }
            else
            {
                NewInvoiceNo = "BAC-0001";
            }
            return NewInvoiceNo;
        }

        private void ButtonRights(bool Enable)
        {
            btnAdd.Enabled = Enable;
            btnUpdate.Enabled = !Enable;
            btnDelete.Enabled = !Enable;
            txtCode.ReadOnly = !Enable;
        }

        private void FillDropDown()
        {
            DataTable dtBank = new DataTable();
            dtBank = manageBank.GetBankList();

            DataRow drBank = dtBank.NewRow();
            drBank["BankName"] = "--Select Bank Name--";
            drBank["BankId"] = "-1";
            dtBank.Rows.InsertAt(drBank, 0);

            cmbBankName.DataSource = dtBank;
            cmbBankName.DisplayMember = "BankName";
            cmbBankName.ValueMember = "BankId";
        }

        private void ClearFeilds()
        {
            txtCode.Text = GetNewNextNumber();
            txtBranchCode.Text = string.Empty;
            txtACNumber.Text = string.Empty;
            txtACTitle.Text = string.Empty;
            cmbBankName.SelectedIndex = 0;
            txtCOACode.Text = string.Empty;
            txtBranchCode.Focus();
            ButtonRights(true);
        }

        private bool Validation()
        {
            bool result = true;

            //txtBranchCode  , txtACNumber , txtACTitle , cmbBankName , txtCOACode
            if (string.IsNullOrEmpty(txtBranchCode.Text))
            {
                MessageBox.Show("Please Enter Branch Code Number", "Branch Code is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
                txtBranchCode.Focus();
                return result;
            }
            else if (string.IsNullOrEmpty(txtACNumber.Text))
            {
                MessageBox.Show("Please Enter Account Number", "Account Number is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
                txtACNumber.Focus();
                return result;
            }
            else if (string.IsNullOrEmpty(txtACTitle.Text))
            {
                MessageBox.Show("Please Enter Account Title", "Account Title is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
                txtACTitle.Focus();
                return result;
            }
            else if (cmbBankName.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Bank Name", "Bank Name is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
                cmbBankName.Focus();
                return result;
            }
            else if (string.IsNullOrEmpty(txtCOACode.Text))
            {
                MessageBox.Show("Please Enter Chart of Account", "COA Code is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
                txtCOACode.Focus();
                return result;
            }
            return result;

        }

        private void LoadBankAccount(int BACId)
        {
            DataTable dtBankAC = manageBank.GetBankAccount(BACId); ;
            if (dtBankAC.Rows.Count > 0)
            {
                txtBranchCode.Text = dtBankAC.Rows[0]["BranchCode"].ToString();
                txtACNumber.Text = dtBankAC.Rows[0]["AccountNo"].ToString();
                txtACTitle.Text = dtBankAC.Rows[0]["AccountTitle"].ToString();
                cmbBankName.SelectedValue = dtBankAC.Rows[0]["BankId"].ToString();
                txtCOACode.Text = manageAccount.GetChartOfAccounts(Convert.ToInt32(dtBankAC.Rows[0]["COAId"])).Rows[0]["AccountCode"].ToString();
                txtBranchCode.Focus();
                ButtonRights(false);
            }
        }

        private int InsertBankAccount(string BranchCode, string AccountNo, string AccountTitle, int BankId, int COAId, int AddedBy, DateTime AddedOn,
                                    string AddedIpAddr)
        {
            BankAccountId = manageBank.InsertBankAccount(BranchCode, AccountNo, AccountTitle, BankId, COAId, AddedBy, AddedOn, AddedIpAddr);
            return BankAccountId;
        }

        private void UpdateBankAccount(int BankAccountId, string BranchCode, string AccountNo, string AccountTitle, int BankId, int COAId, int AddedBy, DateTime AddedOn,
                                  string AddedIpAddr)
        {
            manageBank.UpdateBankAccount(BankAccountId, BranchCode, AccountNo, AccountTitle, BankId, COAId, AddedBy, AddedOn, AddedIpAddr);
        }

        private void DeleteBankAccount(int BankAccountId)
        {

            manageBank.DeleteBankAccount(BankAccountId);
            MessageBox.Show("Bank Account Delete Successfull.", "Bank Account Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFeilds();
        }

        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Validation())
            {

                int COAId = -1;
                COAId = manageAccount.GetCOAIdByCode(txtCOACode.Text);
                if (COAId <= 0)
                {
                    MessageBox.Show("Chart Of Account Refrence does not found." + Environment.NewLine + "Make Sure Chart of Account Code is Proper Selected.", "COA Code found Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                BankAccountId = InsertBankAccount(txtBranchCode.Text, txtACNumber.Text, txtACTitle.Text, Convert.ToInt32(cmbBankName.SelectedValue), COAId, MainForm.User_Id, DateTime.Now.Date, "");
                MessageBox.Show("Bank Account Insert Successfull.", "Record Inserted.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFeilds();

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Validation())
            {

                int COAId = -1;
                COAId = manageAccount.GetCOAIdByCode(txtCOACode.Text);
                if (COAId <= 0)
                {
                    MessageBox.Show("Chart Of Account Refrence does not found." + Environment.NewLine + "Make Sure Chart of Account Code is Proper Selected.", "COA Code found Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                UpdateBankAccount(BankAccountId, txtBranchCode.Text, txtACNumber.Text, txtACTitle.Text, Convert.ToInt32(cmbBankName.SelectedValue), COAId, MainForm.User_Id, DateTime.Now.Date, "");
                MessageBox.Show("Record Update Successfull.", "BankAccount Updated.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFeilds();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFeilds();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to Delete it?", "Bank Account Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.No:
                    {
                        return;
                        break;
                    }
                case DialogResult.Yes:
                    {
                        DeleteBankAccount(BankAccountId);
                        break;
                    }

            }
        }

        //private void txtCategoryId_Leave(object sender, EventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(txtBACId.Text))
        //    {
        //        BankAccountId = Product.GetProductCategoryIdByCode(Convert.ToInt32(txtBACId.Text));
        //        if (BankAccountId > 0)
        //        {
        //            LoadProductCategory(BankAccountId);
        //        }
        //    }
        //}

        private void txtBACId_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCode.Text))
            {
                BankAccountId = manageBank.GetBankACIdByCode(txtCode.Text);
                if (BankAccountId > 0)
                {
                    LoadBankAccount(BankAccountId);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {

                frmSearch search = new frmSearch();
                search.getattributes("GetBankAccountSearch", null, "Bank Accounts");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtCode.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtCategoryId_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    SendKeys.Send("{TAB}");
            //}
        }

        private void frmBankAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtCOACode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtCOACode.Text))
                {
                    txtCOAName.Text = manageAccount.GetChartOfAccounts(manageAccount.GetCOAIdByCode(txtCOACode.Text)).Rows[0]["AccountName"].ToString();
                }
                else
                {
                    txtCOAName.Text = string.Empty;
                }

            }
            catch (Exception ex)
            {
                txtCOAName.Text = string.Empty;
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
                    txtCOACode.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
