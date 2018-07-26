
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
    public partial class frmExpense : Form
    {
        int ExpenseId = -1;
        ExpenseManager EM = new ExpenseManager();
        public frmExpense()
        {
            InitializeComponent();
        }
        private void frmExpense_Load(object sender, EventArgs e)
        {
            try
            {
                FillDropDown();
                ButtonRights(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #region Method


        private void FillDropDown()
        {
            DataTable dtProductCatagory = EM.GetAllExpenseCatagory();
            if (dtProductCatagory.Rows.Count > 0)
            {
                DataRow dr = dtProductCatagory.NewRow();
                dr["ExpenseCatagoryId"] = -1;
                dr["DESCRIPTION"] = "---Select Catagory---";
                dtProductCatagory.Rows.InsertAt(dr, 0);
                cmbExpenseCategory.DataSource = dtProductCatagory;
                cmbExpenseCategory.DisplayMember = "DESCRIPTION";
                cmbExpenseCategory.ValueMember = "ExpenseCatagoryId";
            }
        }

        private void ButtonRights(bool Enable)
        {
            btnAdd.Enabled = Enable;
            btnUpdate.Enabled = !Enable;
            btnDelete.Enabled = !Enable;
            txtExpenseCode.ReadOnly = !Enable;
        }

        private void ClearFeilds()
        {
            ExpenseId = -1;
            txtExpenseCode.Text = string.Empty;
            txtAmount.Text = string.Empty;
            dTPDate.Text = string.Empty;
            txtRemarks.Text = string.Empty;
            cmbExpenseCategory.SelectedValue = -1;
            ButtonRights(true);
        }



        private void LoadExpense(int ExpenseId)
        {
            DataTable dtExpense = EM.GetExpenseById(ExpenseId);
            if (dtExpense.Rows.Count > 0)
            {
                txtExpenseCode.Text = dtExpense.Rows[0]["ExpenseId"].ToString();
                dTPDate.Text = dtExpense.Rows[0]["Date"].ToString();
                cmbExpenseCategory.SelectedValue = dtExpense.Rows[0]["ExpenseCatagoryId"].ToString();
                txtAmount.Text = dtExpense.Rows[0]["Amount"].ToString();
                txtRemarks.Text = dtExpense.Rows[0]["Remarks"].ToString();
                ButtonRights(false);
            }
        }


        private int InsertExpense(DateTime Date, int ExpenseCatagoryId, decimal Amount, string Remarks,
             int AddedBy, DateTime AddedOn, string AddedIpAddr)
        {
            ExpenseId = EM.InsertExpense(Date, ExpenseCatagoryId, Amount, Remarks, AddedBy, AddedOn, AddedIpAddr);
            return ExpenseId;
        }

        private void UpdateExpense(int ExpenseId, DateTime Date, int ExpenseCatagoryId, decimal Amount, string Remarks,
             int UpdatedBy, DateTime UpdatedOn, string UpdatedIpAddr)
        {
            EM.UpdateExpense(ExpenseId, Date, ExpenseCatagoryId, Amount, Remarks, UpdatedBy, UpdatedOn, UpdatedIpAddr);
        }

        private void DeleteProduct(int ExpenseId)
        {

            EM.DeleteExpense(ExpenseId);
            MessageBox.Show("Expense Record Delete Successfull.", "Expense Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFeilds();
        }

        #endregion
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {

                frmSearch search = new frmSearch();
                search.getattributes("GetExpenseSearch", null, "Expense");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtExpenseCode.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                }
                else
                {
                    txtExpenseCode.Text = string.Empty;
                    txtExpenseCode.Focus();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtExpenseCode_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtExpenseCode.Text))
            {
                ExpenseId = EM.GetExpenseIdById(Convert.ToInt32(txtExpenseCode.Text));
                if (ExpenseId > 0)
                {
                    LoadExpense(ExpenseId);
                }
            }
        }

        private void txtExpenseCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtExpenseCode_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtExpenseCode.Text))
            {
                ExpenseId = EM.GetExpenseIdById(Convert.ToInt32(txtExpenseCode.Text));
                if (ExpenseId > 0)
                {
                    LoadExpense(ExpenseId);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ExpenseId = InsertExpense(Convert.ToDateTime(dTPDate.Text), Convert.ToInt32(cmbExpenseCategory.SelectedValue), (string.IsNullOrEmpty(txtAmount.Text) ? 0 : Convert.ToDecimal(txtAmount.Text)), txtRemarks.Text, 0, DateTime.Now.Date, "0");
            MessageBox.Show("Expense Record Insert Successfull.", "Record Inserted.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFeilds();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateExpense(ExpenseId, Convert.ToDateTime(dTPDate.Text), Convert.ToInt32(cmbExpenseCategory.SelectedValue), (string.IsNullOrEmpty(txtAmount.Text) ? 0 : Convert.ToDecimal(txtAmount.Text)), txtRemarks.Text, 0, DateTime.Now.Date, "0");
            MessageBox.Show("Expense Record Update Successfull.", "Expense Updated.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFeilds();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFeilds();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to Delete it?", "Expense Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.No:
                    {
                        return;
                        break;
                    }
                case DialogResult.Yes:
                    {
                        DeleteProduct(ExpenseId);
                        break;
                    }

            }
        }

        private void frmExpense_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void frmExpense_KeyDown(object sender, KeyEventArgs e)
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
        Utility ul = new Utility();
        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            ul.setOnlyNumberic((TextBox)sender, true, e);
        }

    }
}
