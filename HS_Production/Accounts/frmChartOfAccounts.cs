using FIL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


public partial class frmChartOfAccounts : Form
{
    AccountManager manageAccount = new AccountManager();
    int COAId = -1;
    public frmChartOfAccounts()
    {
        InitializeComponent();
    }

    private void frmChartOfAccounts_Load(object sender, EventArgs e)
    {
        try
        {
            FillDropDown();
            ButtonRights(true);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


    }

    private void frmChartOfAccounts_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            SendKeys.Send("{TAB}");
        }
    }

    private void FillDropDown()
    {
        DataTable dtCategory = manageAccount.GetAccountCategoryList();
        DataRow drCategory = dtCategory.NewRow();
        drCategory["ACId"] = -1;
        drCategory["CategoryName"] = "--Select Account Category--";
        dtCategory.Rows.InsertAt(drCategory, 0);

        cmbCategory.DataSource = dtCategory;
        cmbCategory.DisplayMember = "CategoryName";
        cmbCategory.ValueMember = "ACId";

    }
    bool IsCOALoading = false;
    private void LoadCOA()
    {
        if (COAId <= 0)
        {
            return;
        }
        DataTable dtCOA = manageAccount.GetChartOfAccounts(COAId);
        if (dtCOA.Rows.Count > 0)
        {
            IsCOALoading = true;
            txtAccName.Text = dtCOA.Rows[0]["AccountName"].ToString();
            cmbCategory.SelectedValue = dtCOA.Rows[0]["Category"];
            cmbCategory.Enabled = false;
            txtAccCode.ReadOnly = true;

            txtPAccCode.Text = dtCOA.Rows[0]["IsSubAccountOf"].ToString();
            if (!string.IsNullOrEmpty(dtCOA.Rows[0]["FlagDC"].ToString()))
            {
                if (dtCOA.Rows[0]["FlagDC"].ToString() == "D")
                {
                    rbDebit.Checked = true;
                }
                else
                {
                    rbCredit.Checked = true;
                }
            }
            else
            {
                rbDebit.Checked = true;
            }

            ButtonRights(false);
            IsCOALoading = false;
        }
    }
    private void ButtonRights(bool Enable)
    {
        btnAdd.Enabled = Enable;
        btnUpdate.Enabled = !Enable;
        btnDelete.Enabled = !Enable;
        txtAccCode.ReadOnly = !Enable;
    }

    private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (IsCOALoading)
        {
            return;
        }
        if (Convert.ToInt32(cmbCategory.SelectedIndex) > 0)
        {
            txtAccCode.Text = manageAccount.GetNewAccoutCodeByCategoryId(Convert.ToInt32(cmbCategory.SelectedValue));
            txtPAccCode.Text = string.Empty;
        }
        else
        {
            txtAccCode.Text = string.Empty;
        }
    }

    private void ClearFeilds()
    {
        txtAccCode.Text = string.Empty;
        txtAccName.Text = string.Empty;
        cmbCategory.SelectedValue = -1;
        txtPAccCode.Text = string.Empty;
        txtPAccName.Text = string.Empty;
        rbDebit.Checked = true;

        cmbCategory.Enabled = true;
        txtAccCode.ReadOnly = false;

        ButtonRights(true);
    }


    private bool Validation()
    {
        bool result = true;
        if (string.IsNullOrEmpty(txtAccCode.Text))
        {
            MessageBox.Show("Account Code is Required. Please make sure Account Code is Genrated.", "Account Code Found Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            result = false;
            return result;
        }
        else if (string.IsNullOrEmpty(txtAccName.Text))
        {
            MessageBox.Show("Account Name is Required. Please Enter Account Name.", "Account Name Found Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtAccName.Focus();
            result = false;
            return result;
        }
        else if (Convert.ToInt32(cmbCategory.SelectedValue) < 0)
        {
            MessageBox.Show("Account Category is Required. Please Select Account Category.", "Account Category Found Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtAccName.Focus();
            result = false;
            return result;
        }
        return result;
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        if (Validation())
        {
            COAId = manageAccount.InsertChartOfAccount("H", txtAccCode.Text, txtAccName.Text, Convert.ToInt32(cmbCategory.SelectedValue), (rbDebit.Checked ? "D" : "C"), true, true, txtPAccCode.Text, MainForm.User_Id, DateTime.Now, "");
            if (COAId > 0)
            {
                MessageBox.Show("Chart Of Account Insert Sucessfull.", "Record Inserted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFeilds();
            }
        }
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
        if (Validation())
        {
            manageAccount.UpdateChartOfAccount(COAId, "H", txtAccCode.Text, txtAccName.Text, Convert.ToInt32(cmbCategory.SelectedValue), (rbDebit.Checked ? "D" : "C"), true, true, txtPAccCode.Text, MainForm.User_Id, DateTime.Now, "");
            MessageBox.Show("Chart Of Account Update Sucessfull.", "Record Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show("Work in Progress", "Pending", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    //DeleteAccountCategory(AccountCatagoryId.ToString());
                    break;
                }

        }
    }

    private void btnPAccSearch_Click(object sender, EventArgs e)
    {
        try
        {
            if (cmbCategory.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Account Category First.", "Account Category not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmSearch search = new frmSearch();
            Smartworks.ColumnField[] gCOA = new Smartworks.ColumnField[1];
            gCOA[0] = new Smartworks.ColumnField("@CategoryId", Convert.ToInt32(cmbCategory.SelectedValue));
            search.getattributes("GetCOASearchByCategory", gCOA, "Chart Of Accounts");
            search.ShowDialog();
            if (!string.IsNullOrEmpty(MainForm.Searched_Id))
            {
                txtPAccCode.Text = MainForm.Searched_Id;
                MainForm.Searched_Id = string.Empty;
            }

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void txtPAccCode_TextChanged(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtPAccCode.Text))
        {
            try
            {
                txtPAccName.Text = manageAccount.GetChartOfAccounts(manageAccount.GetCOAIdByCode(txtPAccCode.Text)).Rows[0]["AccountName"].ToString();
                if (!IsCOALoading)
                {
                    if (COAId > 0)
                    {
                        int ParentCOAId = manageAccount.GetCOAIdByCode(txtPAccCode.Text);
                        if (COAId == ParentCOAId)
                        {
                            MessageBox.Show("Same Account Code should not assign Parent Code.", "Make sure Parent & Child Account Code", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtPAccCode.Text = string.Empty;
                            txtPAccCode.Text = manageAccount.GetChartOfAccounts(COAId).Rows[0]["IsSubAccountOf"].ToString();

                        }
                        else
                        {
                            //txtAccCode.Text = manageAccount.GetNewAccoutCodeByParentCode(txtPAccCode.Text);
                        }
                    }
                    else
                    {
                        txtAccCode.Text = manageAccount.GetNewAccoutCodeByParentCode(txtPAccCode.Text);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                txtPAccName.Text = string.Empty;
            }

        }
        else
        {
            txtPAccName.Text = string.Empty;
        }
    }

    private void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            frmSearch search = new frmSearch();
            search.getattributes("GetCOASearch", null, "Chart Of Accounts");
            search.ShowDialog();
            if (!string.IsNullOrEmpty(MainForm.Searched_Id))
            {
                txtAccCode.Text = MainForm.Searched_Id;
                MainForm.Searched_Id = string.Empty;
            }

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void txtAccCode_TextChanged(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtAccCode.Text))
        {
            COAId = manageAccount.GetCOAIdByCode(txtAccCode.Text);
            if (COAId > 0)
            {
                LoadCOA();
            }
        }


    }
}

