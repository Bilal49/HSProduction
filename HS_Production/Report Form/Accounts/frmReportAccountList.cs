using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using FIL.App_Code.SaleMasterManager;
using FIL;


public partial class frmReportAccountList : Form
{
    Smartworks.DAL dataAccess = new Smartworks.DAL();
    AccountManager manageAccount = new AccountManager();
    public frmReportAccountList()
    {
        InitializeComponent();
        string connString = ConfigurationManager.ConnectionStrings["HSConnectionString"].ConnectionString;
        Smartworks.DAL.ConnectionString = connString;
    }

    private void frmReportPriceList_Load(object sender, EventArgs e)
    {
        FillDropDown();
    }
    private void FillDropDown()
    {

        DataTable dtAccCategory = manageAccount.GetAccountCategoryList();
        if (dtAccCategory.Rows.Count > 0)
        {
            DataRow dr = dtAccCategory.NewRow();
            dr["ACId"] = -1;
            dr["CategoryName"] = "---All Category---";
            dtAccCategory.Rows.InsertAt(dr, 0);
            cmbProductCatagory.DataSource = dtAccCategory;
            cmbProductCatagory.DisplayMember = "CategoryName";
            cmbProductCatagory.ValueMember = "ACId";
        }
    }
    private void btnFromSearch_Click(object sender, EventArgs e)
    {
        try
        {
            frmSearch search = new frmSearch();
            search.getattributes("GetCOASearch", null, "Chart Of Accounts");
            search.ShowDialog();
            if (!string.IsNullOrEmpty(MainForm.Searched_Id))
            {
                txtFromAccCode.Text = MainForm.Searched_Id;
                MainForm.Searched_Id = string.Empty;
            }

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }


    private void btnToSearch_Click(object sender, EventArgs e)
    {
        try
        {
            frmSearch search = new frmSearch();
            search.getattributes("GetCOASearch", null, "Chart Of Accounts");
            search.ShowDialog();
            if (!string.IsNullOrEmpty(MainForm.Searched_Id))
            {
                txtToAccCode.Text = MainForm.Searched_Id;
                MainForm.Searched_Id = string.Empty;
            }

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void btnView_Click(object sender, EventArgs e)
    {
        try
        {

            ReportDocument document = new ReportDocument();
            string path = Application.StartupPath + "/rpt/Accounts/rptCOAList.rpt";
            document.Load(path);
            DataTable dtReport = new DataTable();
            dtReport = manageAccount.GetReportPriceList(Convert.ToInt32(cmbProductCatagory.SelectedValue), txtFromAccCode.Text, txtToAccCode.Text, ((rdCode.Checked) ? true : false));
            document.SetDataSource(dtReport);
            Utility.SetReportDefaultParameter(ref document);
            //if (document.ParameterFields["OrderByCode"] != null)
            //{
            //    document.SetParameterValue("OrderByCode", ((rdCode.Checked) ? true : false));
            //}

            CRViewer.ReportSource = document;
            CRViewer.Refresh();
        }
        catch (Exception ex)
        {
        }
    }

    private void txtFromAccCode_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(txtFromAccCode.Text))
            {
                txtFromAccName.Text = manageAccount.GetChartOfAccounts(manageAccount.GetCOAIdByCode(txtFromAccCode.Text)).Rows[0]["AccountName"].ToString();
            }
            else
            {
                txtFromAccName.Text = string.Empty;
            }

        }
        catch (Exception ex)
        {
            txtFromAccName.Text = string.Empty;
        }
    }

    private void txtToAccCode_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(txtToAccCode.Text))
            {
                txtToAccName.Text = manageAccount.GetChartOfAccounts(manageAccount.GetCOAIdByCode(txtToAccCode.Text)).Rows[0]["AccountName"].ToString();
            }
            else
            {
                txtToAccName.Text = string.Empty;
            }

        }
        catch (Exception ex)
        {
            txtToAccName.Text = string.Empty;
        }
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
        try
        {
            cmbProductCatagory.SelectedIndex = 0;
            txtFromAccCode.Text = string.Empty;
            txtToAccCode.Text = string.Empty;
            txtFromAccName.Text = string.Empty;
            txtToAccName.Text = string.Empty;

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }


}

