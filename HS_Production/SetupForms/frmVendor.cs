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
    public partial class frmVendor : Form
    {
        int VendorId = -1;
        VendorManager Vendor = new VendorManager();
        AccountManager manageAccount = new AccountManager();

        public frmVendor()
        {
            InitializeComponent();
        }

        private void frmVendor_Load(object sender, EventArgs e)
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
            txtVendorCode.ReadOnly = !Enable;
        }

        private void ClearFeilds()
        {
            txtVendorCode.Text = string.Empty;
            txtVendorName.Text = string.Empty;
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

            if (string.IsNullOrEmpty(txtVendorName.Text))
            {
                MessageBox.Show("Please Enter Party Name.", "Party Name is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
                txtVendorName.Focus();
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

        private void LoadVendor(int VendorId)
        {
            DataTable dtVendor = Vendor.GetVendor(VendorId);
            if (dtVendor.Rows.Count > 0)
            {
                txtVendorCode.Text = dtVendor.Rows[0]["Code"].ToString();
                txtVendorName.Text = dtVendor.Rows[0]["VendorName"].ToString();
                txtPhone.Text = dtVendor.Rows[0]["Phone"].ToString();
                txtAddress.Text = dtVendor.Rows[0]["Address"].ToString();
                txtContactPerson.Text = dtVendor.Rows[0]["ContactPerson"].ToString();
                if (!string.IsNullOrEmpty(dtVendor.Rows[0]["COAId"].ToString()))
                {
                    try
                    {
                        txtAccountCode.Text = manageAccount.GetChartOfAccounts(Convert.ToInt32(dtVendor.Rows[0]["COAId"])).Rows[0]["AccountCode"].ToString();
                    }
                    catch (Exception eex)
                    {
                        txtAccountCode.Text = string.Empty;
                    }

                }
                else
                {
                    txtAccountCode.Text = string.Empty;
                }
                txtSTRegistration.Text = dtVendor.Rows[0]["STRegistration"].ToString();
                txtNTN.Text = dtVendor.Rows[0]["NTN"].ToString();
                bool IsActive = true;
                IsActive = (string.IsNullOrEmpty(dtVendor.Rows[0]["IsActive"].ToString()) ? true : Convert.ToBoolean(dtVendor.Rows[0]["IsActive"]));
                chkIsActive.Checked = IsActive;
                ButtonRights(false);
            }
        }


        private int InsertVendor(string VendorName, string Address, string phoneNumber, bool inactive, string contactPerson , int COAId , string STRegistration, string NTN)
        {
            VendorId = Vendor.InsertVendor(VendorName, Address, phoneNumber, contactPerson, COAId , STRegistration , NTN , inactive, -1, DateTime.Now, "");
            return VendorId;

        }

        private void UpdateVendor(int VendorId, string VendorName, string Address, string phoneNumber, bool inactive, string contactPerson , int COAId , string STRegistration, string NTN)
        {
            Vendor.UpdateVendor(VendorId, VendorName, Address, phoneNumber, contactPerson, COAId , STRegistration , NTN ,   inactive, -1, DateTime.Now, "");
        }

        private void DeleteVendor(string VendorId)
        {

            Vendor.DeleteVendor(VendorId);
            MessageBox.Show("Party Record Deleted", "Party Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                VendorId = InsertVendor(txtVendorName.Text, txtAddress.Text, txtPhone.Text, chkIsActive.Checked, txtContactPerson.Text, COAId , txtSTRegistration.Text , txtNTN.Text);
                MessageBox.Show("Party Record Insert Succesfully.", "Party Inserted.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (VendorId > 0)
                {
                    LoadVendor(VendorId);
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
                UpdateVendor(VendorId, txtVendorName.Text, txtAddress.Text, txtPhone.Text, chkIsActive.Checked, txtContactPerson.Text ,COAId , txtSTRegistration.Text , txtNTN.Text);
                MessageBox.Show("Party Record Updated.", "Party Updated.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to Delete it?", "Vendor Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.No:
                    {
                        return;
                        break;
                    }
                case DialogResult.Yes:
                    {

                        DeleteVendor(VendorId.ToString());
                        break;
                    }

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFeilds();
        }

        private void txtVendorCode_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtVendorCode.Text))
            {
                VendorId = Vendor.GetVendorIdByCode(txtVendorCode.Text);
                if (VendorId > 0)
                {
                    LoadVendor(VendorId);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
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

        private void txtVendorCode_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtVendorCode.Text))
            {
                VendorId = Vendor.GetVendorIdByCode(txtVendorCode.Text);
                if (VendorId > 0)
                {
                    LoadVendor(VendorId);
                }
            }
        }

        private void frmVendor_KeyDown(object sender, KeyEventArgs e)
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
