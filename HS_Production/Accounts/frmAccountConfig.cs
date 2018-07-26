using FIL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


    public partial class frmAccountConfig : Form
    {
        AccountManager manageAccount = new AccountManager();
        public frmAccountConfig()
        {
            InitializeComponent();
        }

        private void frmAccountConfig_Load(object sender, EventArgs e)
        {
            FillAccounts();
        }


        private void FillAccounts()
        {
            DataTable dtAccountsConfig = manageAccount.GetAccountConfiguration();
            if (dtAccountsConfig.Rows.Count > 0)
            {
                txtSalesAcc.Text = dtAccountsConfig.Rows[0]["SalesAccount"].ToString();
                txtPurchaseAcc.Text = dtAccountsConfig.Rows[0]["PurchaseAccount"].ToString();
                txtCashAcc.Text = dtAccountsConfig.Rows[0]["CashAccount"].ToString();
                txtSaleGSTAcc.Text = dtAccountsConfig.Rows[0]["SaleGSTAccount"].ToString();
                txtPurchaseGSTAcc.Text = dtAccountsConfig.Rows[0]["PurchaseGSTAccount"].ToString();
            }
        }

        private string GetAccountNameByAccoutCode(string AccountCode)
        {
            string AccountName = string.Empty;
            try
            {               
                AccountName = manageAccount.GetChartOfAccounts(manageAccount.GetCOAIdByCode(AccountCode)).Rows[0]["AccountName"].ToString();
            }
            catch (Exception ex)
            {
                AccountName = string.Empty;
            }

            return AccountName;
        }

        #region TextChangedEvents

        private void txtSalesAcc_TextChanged(object sender, EventArgs e)
        {
            txtSalesAccName.Text = GetAccountNameByAccoutCode(txtSalesAcc.Text);
        }

        private void txtPurchaseAcc_TextChanged(object sender, EventArgs e)
        {
            txtPurchaseAccName.Text = GetAccountNameByAccoutCode(txtPurchaseAcc.Text);
        }
        private void txtCashAcc_TextChanged(object sender, EventArgs e)
        {
            txtCashAccName.Text = GetAccountNameByAccoutCode(txtCashAcc.Text);
        }

        private void txtGSTAcc_TextChanged(object sender, EventArgs e)
        {
            txtSaleGSTAccName.Text = GetAccountNameByAccoutCode(txtSaleGSTAcc.Text);
        }

        private void txtPurchaseGSTAcc_TextChanged(object sender, EventArgs e)
        {
            txtPurchaseGSTAccName.Text = GetAccountNameByAccoutCode(txtPurchaseGSTAcc.Text);
        }

        #endregion

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int status = manageAccount.InsertUpdateAccountConfiguration(txtSalesAcc.Text, txtPurchaseAcc.Text, txtCashAcc.Text, txtSaleGSTAcc.Text ,txtPurchaseGSTAcc.Text);
            if (status >0 )
            {
                MessageBox.Show("Account Setting Saved Successfully.", "Account Configuration Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Search Buttons

        private void btnSalesSearch_Click(object sender, EventArgs e)
        {
            try
            {

                frmSearch search = new frmSearch();
                search.getattributes("GetCOASearch", null, "Chart Of Accounts");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtSalesAcc.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPurhaseSearch_Click(object sender, EventArgs e)
        {
            try
            {

                frmSearch search = new frmSearch();
                search.getattributes("GetCOASearch", null, "Chart Of Accounts");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtPurchaseAcc.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCashSearch_Click(object sender, EventArgs e)
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

        private void btnGSTSearch_Click(object sender, EventArgs e)
        {
            try
            {
                frmSearch search = new frmSearch();
                search.getattributes("GetCOASearch", null, "Chart Of Accounts");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtSaleGSTAcc.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnPurchaseGSTSearch_Click(object sender, EventArgs e)
        {
            try
            {
                frmSearch search = new frmSearch();
                search.getattributes("GetCOASearch", null, "Chart Of Accounts");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtPurchaseGSTAcc.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        #endregion

        #region KeyDown Events
        

        private void frmAccountConfig_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F3)
            {
                if (btnUpdate.Enabled)
                {
                    btnUpdate.PerformClick();
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }

        }

        private void txtSalesAcc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                btnSalesSearch.PerformClick();
            }
        }

        private void txtPurchaseAcc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                btnPurhaseSearch.PerformClick();
            }
        }

        private void txtCashAcc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                btnCashSearch.PerformClick();
            }
        }

        private void txtGSTAcc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                btnSaleGSTSearch.PerformClick();
            }
        }
        private void txtPurchaseGSTAcc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                btnPurchaseGSTSearch.PerformClick();
            }
        }

        
        #endregion

       

       


        






















    }

