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
    public partial class frmCustomer : Form
    {
        int CustomerId = -1;
        CustomerManager Customer = new CustomerManager();
        AccountManager manageAccount = new AccountManager();
        public frmCustomer()
        {
            InitializeComponent();
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            try
            {

                ButtonRights(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region Method



        private void ButtonRights(bool Enable)
        {
            btnAdd.Enabled = Enable;
            btnUpdate.Enabled = !Enable;
            btnDelete.Enabled = !Enable;
            txtCustomerCode.ReadOnly = !Enable;
        }

        private void ClearFeilds()
        {
            txtCustomerCode.Text = string.Empty;
            txtCustomeName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtContactPerson.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtAccountCode.Text = string.Empty;
            txtAccountName.Text = string.Empty;
            txtSTRegistration.Text = string.Empty;
            txtNTN.Text = string.Empty;
            chkIsActive.Checked = true;
            ButtonRights(true);
        }

        private bool Validation()
        {
            bool result = true;

            if (string.IsNullOrEmpty(txtCustomeName.Text))
            {
                MessageBox.Show("Please Enter Customer Name.", "Customer Name is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
                txtCustomeName.Focus();
                return result;
            }

            if (string.IsNullOrEmpty(txtAccountCode.Text))
            {
                MessageBox.Show("Please Select Chart of Account Code.", "Account Code is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
                txtAccountCode.Focus();
                return result;
            }

            return result;

        }

        private void LoadCustomer(int CustomerId)
        {
            DataTable dtCustomer = Customer.GetCustomer(CustomerId);
            if (dtCustomer.Rows.Count > 0)
            {
                txtCustomerCode.Text = dtCustomer.Rows[0]["Code"].ToString();
                txtCustomeName.Text = dtCustomer.Rows[0]["CustomerName"].ToString();
                txtPhone.Text = dtCustomer.Rows[0]["Phone"].ToString();
                txtAddress.Text = dtCustomer.Rows[0]["Address"].ToString();
                txtContactPerson.Text = dtCustomer.Rows[0]["ContactPerson"].ToString();
                if (!string.IsNullOrEmpty(dtCustomer.Rows[0]["COAId"].ToString()))
                {
                    txtAccountCode.Text = manageAccount.GetChartOfAccounts(Convert.ToInt32(dtCustomer.Rows[0]["COAId"])).Rows[0]["AccountCode"].ToString();
                }
                txtSTRegistration.Text = dtCustomer.Rows[0]["STRegistration"].ToString();
                txtNTN.Text = dtCustomer.Rows[0]["NTN"].ToString();
                //dtCustomer.Rows[0]["ContactPerson"].ToString();
                bool IsActive = true;
                bool IsPos = true;
                IsActive = (string.IsNullOrEmpty(dtCustomer.Rows[0]["IsActive"].ToString()) ? true : Convert.ToBoolean(dtCustomer.Rows[0]["IsActive"]));
                IsPos = (string.IsNullOrEmpty(dtCustomer.Rows[0]["IsPos"].ToString()) ? true : Convert.ToBoolean(dtCustomer.Rows[0]["IsPos"]));
                chkIsActive.Checked = IsActive;
                chkIsPos.Checked = IsPos;
                ButtonRights(false);
            }
        }


        private int InsertCustomer(string customerName, string Address, string phoneNumber, bool inactive, bool ispos, string contactPerson , int COAId ,string STRegistration, string NTN)
        {
            CustomerId = Customer.InsertCustomer(customerName, Address, phoneNumber, contactPerson, COAId , STRegistration , NTN ,  inactive, ispos, -1, DateTime.Now, "");
            return CustomerId;

        }

        private void UpdateCustomer(int customerId, string customerName, string Address, string phoneNumber, bool inactive, bool ispos, string contactPerson, int COAId, string STRegistration, string NTN)
        {
            Customer.UpdateCustomer(customerId, customerName, Address, phoneNumber, contactPerson, COAId , STRegistration , NTN ,   inactive, ispos, -1, DateTime.Now, "");
        }

        private void DeleteCustomer(string CustomerId)
        {

            Customer.DeleteCustomer(CustomerId);
            MessageBox.Show("Customer Record Delete Successfull.", "Customer Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFeilds();
        }

        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                int COAId = -1;
                COAId = manageAccount.GetCOAIdByCode(txtAccountCode.Text);
                if (COAId < 0)
                {
                    MessageBox.Show("Please Select Chart of Account Code.", "Account Code is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                CustomerId = InsertCustomer(txtCustomeName.Text, txtAddress.Text, txtPhone.Text, chkIsActive.Checked, chkIsPos.Checked == true ? true : false, txtContactPerson.Text, COAId , txtSTRegistration.Text , txtNTN.Text ) ;
                MessageBox.Show("Customer Record Insert Successfull.", "Record Inserted.", MessageBoxButtons.OK, MessageBoxIcon.Information);   
                if (CustomerId > 0)
                {
                    LoadCustomer(CustomerId);
                }


            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                int COAId = -1;
                COAId = manageAccount.GetCOAIdByCode(txtAccountCode.Text);
                if (COAId < 0)
                {
                    MessageBox.Show("Please Select Chart of Account Code.", "Account Code is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                UpdateCustomer(CustomerId, txtCustomeName.Text, txtAddress.Text, txtPhone.Text, chkIsActive.Checked, chkIsPos.Checked == true ? true : false, txtContactPerson.Text, COAId, txtSTRegistration.Text, txtNTN.Text);
                MessageBox.Show("Customer Record Updated.", "Customer Updated.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to Delete it?", "Customer Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.No:
                    {
                        return;
                        break;
                    }
                case DialogResult.Yes:
                    {

                        DeleteCustomer(CustomerId.ToString());
                        break;
                    }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFeilds();
        }

        private void txtCustomerCode_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCustomerCode.Text))
            {
                CustomerId = Customer.GetCustomerIdByCode(txtCustomerCode.Text);
                if (CustomerId > 0)
                {
                    LoadCustomer(CustomerId);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
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

        private void txtCustomerCode_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCustomerCode.Text))
            {
                CustomerId = Customer.GetCustomerIdByCode(txtCustomerCode.Text);
                if (CustomerId > 0)
                {
                    LoadCustomer(CustomerId);
                }
            }
        }

        private void frmCustomer_KeyDown(object sender, KeyEventArgs e)
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
                SendKeys.Send("{TAB}");
            }
            else if (e.KeyCode == Keys.F2)
            {
                btnSearch.PerformClick();
            }
        }

        private void txtCustomerCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                btnSearch.PerformClick();
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
                    txtAccountCode.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtAccountCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtAccountCode.Text))
                {
                    txtAccountName.Text = manageAccount.GetChartOfAccounts(manageAccount.GetCOAIdByCode(txtAccountCode.Text)).Rows[0]["AccountName"].ToString();
                }
                else
                {
                    txtAccountName.Text = string.Empty;
                }

            }
            catch (Exception ex)
            {
                txtAccountName.Text = string.Empty;
            }

        }
    }
}
