using FIL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


    public partial class frmAccountCategory : Form
    {
        int AccountCatagoryId = -1;
        AccountManager manageAccount = new AccountManager();
        public frmAccountCategory()
        {
            InitializeComponent();
        }

        private void frmAccountCatagory_Load(object sender, EventArgs e)
        {
            try
            {

                ButtonRights(true);
                //FillDropDown();
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
            txtCode.ReadOnly = !Enable;
        }

        //private void FillDropDown()
        //{
        //    DataTable dtCategory = new DataTable();
        //    dtCategory = Account.GetAccountCategoryList();

        //    DataRow drCategory = dtCategory.NewRow();
        //    drCategory["CategoryName"] = "--Select Parent Category--";
        //    drCategory["AccountCategoryId"] = "-1";
        //    dtCategory.Rows.InsertAt(drCategory, 0);

        //    cmbParentCategory.DataSource = dtCategory;
        //    cmbParentCategory.DisplayMember = "CategoryName";
        //    cmbParentCategory.ValueMember = "AccountCategoryId";
        //}

        private void ClearFeilds()
        {
            txtCode.Text = string.Empty;
            txtCategoryName.Text = string.Empty;
            txtCategoryName.Focus();
            AccountCatagoryId = -1;
            ButtonRights(true);
        }

        private bool Validation()
        {
            bool result = true;

            if (string.IsNullOrEmpty(txtCode.Text))
            {
                MessageBox.Show("Please Enter Account Category Code", "Code is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
                txtCategoryName.Focus();
                return result;
            }

            if (string.IsNullOrEmpty(txtCategoryName.Text))
            {
                MessageBox.Show("Please Enter Category Name", "CategoryName is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
                txtCategoryName.Focus();
                return result;
            }



            return result;

        }

        private void LoadAccountCategory(int AccountCategoryId)
        {
            DataTable dtAccountCategory = manageAccount.GetAccountCategory(AccountCategoryId); ;
            if (dtAccountCategory.Rows.Count > 0)
            {
                txtCode.Text = dtAccountCategory.Rows[0]["Code"].ToString();
                txtCategoryName.Text = dtAccountCategory.Rows[0]["CategoryName"].ToString();
                ButtonRights(false);
            }
        }

        private int InsertAccountCategory(string Code ,  string CategoryName  , int AddedBy, DateTime AddedOn,
                                 string AddedIpAddr)
        {
            AccountCatagoryId = manageAccount.InsertAccountCategory(CategoryName , Code ,  AddedBy, AddedOn, AddedIpAddr);
            return AccountCatagoryId;

        }

        private void UpdateAccountCategory(int AccountCategoryId, string Code , string CategoryName , int UpdatedBy, DateTime UpdatedOn, string UpdatedIpAddr)
        {
            manageAccount.UpdateAccountCategory(AccountCategoryId, CategoryName, Code , UpdatedBy, UpdatedOn, UpdatedIpAddr);
        }

        private void DeleteAccountCategory(string AccountCategoryId)
        {

            manageAccount.DeleteAccountCategory(AccountCategoryId);
            MessageBox.Show("AccountCategory Delete Successfull.", "AccountCategory Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFeilds();
        }

        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                AccountCatagoryId = InsertAccountCategory(txtCode.Text, txtCategoryName.Text, MainForm.User_Id  , DateTime.Now.Date, "0");
                MessageBox.Show("AccountCategory Insert Successfull.", "Record Inserted.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (AccountCatagoryId > 0)
                {
                    LoadAccountCategory(AccountCatagoryId);
                }
                ClearFeilds();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                UpdateAccountCategory(AccountCatagoryId, txtCode.Text ,  txtCategoryName.Text, MainForm.User_Id , DateTime.Now.Date, "0");
                MessageBox.Show("Record Update Successfull.", "AccountCatagory Updated.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearFeilds();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFeilds();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to Delete it?", "Account Category Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.No:
                    {
                        return;
                        break;
                    }
                case DialogResult.Yes:
                    {
                        DeleteAccountCategory(AccountCatagoryId.ToString());
                        break;
                    }

            }
        }

        //private void txtCategoryId_Leave(object sender, EventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(txtCode.Text))
        //    {
        //        AccountCatagoryId = Account.GetAccountCategoryIdByCode(Convert.ToInt32(txtCode.Text));
        //        if (AccountCatagoryId > 0)
        //        {
        //            LoadAccountCategory(AccountCatagoryId);
        //        }
        //    }
        //}

        private void txtCategoryId_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCode.Text))
            {
                AccountCatagoryId = manageAccount.GetACIdByCode(txtCode.Text);
                if (AccountCatagoryId > 0)
                {
                    LoadAccountCategory(AccountCatagoryId);
                }
                //else
                //{
                //    AccountCatagoryId = -1;
                //    txtCategoryName.Text = string.Empty;
                //    ButtonRights(true);
                //}
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {

                frmSearch search = new frmSearch();
                search.getattributes("GetAccountCategorySearch", null, "AccountCategory");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtCode.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                }
                else
                {



                    txtCode.Text = string.Empty;
                    txtCode.Focus();


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

        private void frmAccountCatagory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        Utility clsUtility = new Utility();
        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsUtility.setOnlyNumberic((TextBox)sender, false, e);
        }

    }
