
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
    public partial class frmExpenseCatagory : Form
    {
        int ExpenseCatagoryId = -1;
        ExpenseManager Expense = new ExpenseManager();
        public frmExpenseCatagory()
        {
            InitializeComponent();
        }

        private void frmExpenseCatagory_Load(object sender, EventArgs e)
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
            txtCategoryId.ReadOnly = !Enable;
        }

        private void ClearFeilds()
        {
            txtCategoryId.Text = string.Empty;
            txtCategoryName.Text = string.Empty;
            ButtonRights(true);
        }

        private bool Validation()
        {
            bool result = true;

            if (string.IsNullOrEmpty(txtCategoryName.Text))
            {
                MessageBox.Show("Please Enter Name of Expense Head.", "Expense Head is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
                txtCategoryName.Focus();
                return result;
            }


            return result;

        }

        private void LoadProductCategory(int ExpenseCatagoryId)
        {
            DataTable dtProductCategory = Expense.GetExpenseCatagory(ExpenseCatagoryId); ;
            if (dtProductCategory.Rows.Count > 0)
            {
                txtCategoryId.Text = dtProductCategory.Rows[0]["ExpenseCatagoryId"].ToString();
                txtCategoryName.Text = dtProductCategory.Rows[0]["DESCRIPTION"].ToString();
                ButtonRights(false);
            }
        }


        private int InsertExpense(string DESCRIPTION, int AddedBy, DateTime AddedOn,
                                 string AddedIpAddr)
        {
            ExpenseCatagoryId = Expense.InsertExpenseCatagory(DESCRIPTION, AddedBy, AddedOn, AddedIpAddr);
            return ExpenseCatagoryId;

        }

        private void UpdateExpense(int ExpenseCatagoryId, string DESCRIPTION, int UpdatedBy, DateTime UpdatedOn, string UpdatedIpAddr)
        {
            Expense.UpdateExpenseCatagory(ExpenseCatagoryId, DESCRIPTION, UpdatedBy, UpdatedOn, UpdatedIpAddr);
        }

        private void DeleteExpense(string ExpenseCatagoryId)
        {

            Expense.DeleteExpenseCatagory(ExpenseCatagoryId);
            MessageBox.Show("ExpenseCatagory Delete Successfull.", "ExpenseCatagory Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFeilds();
        }

        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                ExpenseCatagoryId = InsertExpense(txtCategoryName.Text, 0, DateTime.Now.Date, "0");
                MessageBox.Show("ExpenseCatagory Insert Successfull.", "Record Inserted.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (ExpenseCatagoryId > 0)
                {
                    LoadProductCategory(ExpenseCatagoryId);
                }
                ClearFeilds();

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                UpdateExpense(ExpenseCatagoryId, txtCategoryName.Text, 0, DateTime.Now.Date, "0");
                MessageBox.Show("Expense Head Update Successfull.", "ExpenseCatagory Updated.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFeilds();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFeilds();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to Delete it?", "Expense Head Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.No:
                    {
                        return;
                        break;
                    }
                case DialogResult.Yes:
                    {
                        DeleteExpense(ExpenseCatagoryId.ToString());
                        break;
                    }

            }
        }

        private void txtCategoryId_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCategoryId.Text))
            {
                //ExpenseCatagoryId = Expense.GetProductCategoryIdByCode(Convert.ToInt32(txtCategoryId.Text));
                ExpenseCatagoryId = Convert.ToInt32(txtCategoryId.Text);
                if (ExpenseCatagoryId > 0)
                {
                    LoadProductCategory(ExpenseCatagoryId);
                }
            }
        }

        private void txtCategoryId_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCategoryId.Text))
            {
                ExpenseCatagoryId = Convert.ToInt32(txtCategoryId.Text);
                if (ExpenseCatagoryId > 0)
                {
                    LoadProductCategory(ExpenseCatagoryId);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {

                frmSearch search = new frmSearch();
                search.getattributes("GetExpenseCatagorySearch", null, "ExpenseCatagory");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtCategoryId.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                }
                else
                {



                    txtCategoryId.Text = string.Empty;
                    txtCategoryId.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtCategoryId_KeyDown(object sender, KeyEventArgs e)
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


    }
}
