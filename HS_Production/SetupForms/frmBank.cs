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
    public partial class frmBank : Form
    {
        int BankId = -1;
        BankManager manageBank = new BankManager();
        public frmBank()
        {
            InitializeComponent();
        }
        private void frmBank_Load(object sender, EventArgs e)
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
            txtBankId.ReadOnly = !Enable;
        }

        private void ClearFeilds()
        {
            txtBankId.Text = string.Empty;
            txtDescription.Text = string.Empty;

            ButtonRights(true);
            txtDescription.Focus();
        }

        private bool Validation()
        {
            bool result = true;

            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                MessageBox.Show("Please Enter Bank Name.", "Bank Name is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
                txtDescription.Focus();
                return result;
            }


            return result;

        }

        private void LoadProductBank(int BankId)
        {
            DataTable dtBank = manageBank.GetBank(BankId); ;
            if (dtBank.Rows.Count > 0)
            {
                txtBankId.Text = dtBank.Rows[0]["BankId"].ToString();
                txtDescription.Text = dtBank.Rows[0]["BankName"].ToString();
                ButtonRights(false);
            }
        }


        private int InsertBank(string Description, int AddedBy, DateTime AddedOn,
                                 string AddedIpAddr)
        {
            BankId = manageBank.InsertBank(Description, AddedBy, AddedOn, AddedIpAddr);
            return BankId;

        }

        private void UpdateBank(int BankId, string Description, int UpdatedBy, DateTime UpdatedOn, string UpdatedIpAddr)
        {
            manageBank.UpdateBank(BankId, Description, UpdatedBy, UpdatedOn, UpdatedIpAddr);
        }

        private void DeleteBank(int BankId)
        {

            manageBank.DeleteBank(BankId);
            MessageBox.Show("Bank Name Delete Successfull.", "Bank Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFeilds();
        }

        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                BankId = InsertBank(txtDescription.Text, MainForm.User_Id , DateTime.Now.Date, "");
                MessageBox.Show("Bank Insert Successfull.", "Record Inserted.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //if (BankId > 0)
                //{
                //    LoadProductBank(BankId);
                //}
                ClearFeilds();

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                UpdateBank(BankId, txtDescription.Text, MainForm.User_Id , DateTime.Now.Date, "0");
                MessageBox.Show("Bank Update Successfull.", "Bank Updated.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFeilds();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFeilds();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to Delete it?", "Bank Delete.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.No:
                    {
                        return;
                        break;
                    }
                case DialogResult.Yes:
                    {
                        DeleteBank(BankId);
                        break;
                    }

            }
        }

        private void txtBankId_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBankId.Text))
            {
                BankId = manageBank.GetBankIdById(Convert.ToInt32(txtBankId.Text));
                if (BankId > 0)
                {
                    LoadProductBank(BankId);
                }
            }
        }

        private void txtBankId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                frmSearch search = new frmSearch();
                search.getattributes("GetBankSearch", null, "Bank Name");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtBankId.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                }
                else
                {
                    txtBankId.Text = string.Empty;
                    txtBankId.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtBankId_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBankId.Text))
            {
                BankId = manageBank.GetBankIdById(Convert.ToInt32(txtBankId.Text));
                if (BankId > 0)
                {
                    LoadProductBank(BankId);
                }
            }
        }

        


    }
}
