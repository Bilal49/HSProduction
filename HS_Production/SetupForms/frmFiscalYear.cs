using FIL;
using FIL.App_Code.SystemManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;



public partial class frmFiscalYear : Form
{
    int FiscalYearId = -1;
    SystemManager manageSystem = new SystemManager();
    public frmFiscalYear()
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
        txtFiscalYearId.ReadOnly = !Enable;
    }

    private void ClearFeilds()
    {
        txtFiscalYearId.Text = string.Empty;
        txtFiscalName.Text = string.Empty;
        FiscalYearId = -1;
        dtpFicalStart.Value = DateTime.Now;
        dtpFiscalEnd.Value = DateTime.Now;
        chkActive.Checked = false;
        txtYear.Text = string.Empty;

        ButtonRights(true);
        txtFiscalName.Focus();
    }

    private bool Validation()
    {
        bool result = true;

        if (string.IsNullOrEmpty(txtFiscalName.Text))
        {
            MessageBox.Show("Please Enter Fiscal Year Name.", "Fiscal Name is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            result = false;
            txtFiscalName.Focus();
            return result;
        }
        if (string.IsNullOrEmpty(txtYear.Text))
        {
            MessageBox.Show("Please Enter Year Of Fiscal.", "Fiscal Year is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            result = false;
            txtYear.Focus();
            return result;
        }

        int DayDiff = 0;
        DayDiff = Convert.ToInt32((dtpFiscalEnd.Value - dtpFicalStart.Value).TotalDays);
        if (DayDiff > 365)
        {
            MessageBox.Show("Fical Year Must be equal to 365 days", "Invalid Period Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            result = false;
            return result;
        }


        return result;

    }

    private void LoadFiscalYear(int FiscalId)
    {
        DataTable dtFiscal = manageSystem.GetFiscalYear(FiscalId); ;
        if (dtFiscal.Rows.Count > 0)
        {
            txtFiscalYearId.Text = dtFiscal.Rows[0]["FiscalYearId"].ToString();
            txtFiscalName.Text = dtFiscal.Rows[0]["FiscalName"].ToString();
            dtpFicalStart.Value = Convert.ToDateTime(dtFiscal.Rows[0]["FiscalYearStart"]);
            dtpFiscalEnd.Value = Convert.ToDateTime(dtFiscal.Rows[0]["FiscalYearEnd"]);
            txtYear.Text = dtFiscal.Rows[0]["Year"].ToString();
            chkActive.Checked = Convert.ToBoolean(dtFiscal.Rows[0]["IsActive"]);
            ButtonRights(false);
        }
    }





    #endregion

    private void btnAdd_Click(object sender, EventArgs e)
    {
        if (Validation())
        {
            try
            {
                FiscalYearId = manageSystem.InsertFiscalYear(dtpFicalStart.Value, dtpFiscalEnd.Value, txtFiscalName.Text, Convert.ToInt32(txtYear.Text), false);
                if (chkActive.Checked)
                {
                    manageSystem.UpdateFicalYearActive(FiscalYearId);
                    MessageBox.Show("Please Restart your Application.", "Application Must be Restart", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                MessageBox.Show("Fical Year Insert Successfull.", "Record Inserted.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFeilds();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
        if (Validation())
        {
            manageSystem.UpdateFicalYear(FiscalYearId, dtpFicalStart.Value, dtpFiscalEnd.Value, txtFiscalName.Text, Convert.ToInt32(txtYear.Text), false);
            if (chkActive.Checked)
            {
                manageSystem.UpdateFicalYearActive(FiscalYearId);
                MessageBox.Show("Please Restart your Application.", "Application Must be Restart", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            MessageBox.Show("Fical Year Update Successfull.", "Bank Updated.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFeilds();
        }
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
        ClearFeilds();
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        DialogResult result = MessageBox.Show("Are you sure want to Delete it?", "Fiscal Year Delete.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        switch (result)
        {
            case DialogResult.No:
                {
                    return;
                    break;
                }
            case DialogResult.Yes:
                {
                    //DeleteBank(BankId);
                    break;
                }

        }
    }

    private void txtBankId_TextChanged(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtFiscalYearId.Text))
        {
            FiscalYearId = manageSystem.GetFiscalYearIdById(Convert.ToInt32(txtFiscalYearId.Text));
            if (FiscalYearId > 0)
            {
                LoadFiscalYear(FiscalYearId);
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
            search.getattributes("GetFiscalYearSearch", null, "Fiscal Year");
            search.ShowDialog();
            if (!string.IsNullOrEmpty(MainForm.Searched_Id))
            {
                txtFiscalYearId.Text = MainForm.Searched_Id;
                MainForm.Searched_Id = string.Empty;
            }
            else
            {
                txtFiscalYearId.Text = string.Empty;
                txtFiscalYearId.Focus();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void txtBankId_Leave(object sender, EventArgs e)
    {
        //if (!string.IsNullOrEmpty(txtFiscalYearId.Text))
        //{
        //    BankId = manageBank.GetBankIdById(Convert.ToInt32(txtFiscalYearId.Text));
        //    if (BankId > 0)
        //    {
        //        LoadProductBank(BankId);
        //    }
        //}
    }
    Utility clsUtility = new Utility();
    private void txtYear_KeyPress(object sender, KeyPressEventArgs e)
    {
        clsUtility.setOnlyNumberic((TextBox)sender, false, e);
    }




}

