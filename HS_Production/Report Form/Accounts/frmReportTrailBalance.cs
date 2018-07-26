using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;


public partial class frmReportTrailBalance : Form
{
    ReportDocument document = null;
    AccountManager manageAccount = new AccountManager();


    public frmReportTrailBalance(ReportDocument pdocument = null)
    {
        InitializeComponent();
        if (pdocument != null)
        {
            document = pdocument;
        }
    }

    private void btnViewReport_Click(object sender, EventArgs e)
    {
        try
        {
            document = new ReportDocument();
            string path = Application.StartupPath + "/rpt/Accounts/rptTrailBalanceSheet.rpt";
            document.Load(path);
            DataTable dtReport = new DataTable();

            dtReport = manageAccount.GetReportTrialBalanceSheet(dtpFromDate.Value, dtpToDate.Value, ((rdCode.Checked) ? true : false));


            document.SetDataSource(dtReport);
            Utility.SetReportDefaultParameter(ref document);
            if (document.ParameterFields["CFromDate"] != null)
            {
                document.SetParameterValue("CFromDate", dtpFromDate.Value);
            }
            if (document.ParameterFields["CToDate"] != null)
            {
                document.SetParameterValue("CToDate", dtpToDate.Value);
            }

            CrViewer.ReportSource = document;

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void crystalRptCustomerLedger_ReportRefresh(object source, CrystalDecisions.Windows.Forms.ViewerEventArgs e)
    {
        btnViewReport_Click(null, null);

    }

    private void dtpToDate_ValueChanged(object sender, EventArgs e)
    {

    }

    private void lblToDate_Click(object sender, EventArgs e)
    {

    }

    private void btnClear_Click(object sender, EventArgs e)
    {
        document = null;
        CrViewer.ReportSource = null;
        dtpFromDate.Value = DateTime.Now;
        dtpFromDate.Focus();

    }

    private void frmReportStockInn_Load(object sender, EventArgs e)
    {
        try
        {
            if (document != null)
            {
                CrViewer.ReportSource = document;
            }
            //FillDropDown();

        }
        catch (Exception ex)
        {
        }
    }
    Smartworks.DAL dataAcess = new Smartworks.DAL();


    private void chkAll_CheckedChanged(object sender, EventArgs e)
    {
        if (chkAll.Checked)
        {
            dtpFromDate.Value = DateTime.Now;
            dtpFromDate.Enabled = false;
        }
        else
        {
            dtpFromDate.Enabled = true;
        }
    }

    private void FillDropDown()
    {
        //*******for Account Category
        //DataTable dtCategory = new DataTable();
        //dtCategory = manageAccount.GetAccountCategoryList();

        //DataRow drCategory = dtCategory.NewRow();
        //drCategory["Id"] = -1;
        //drCategory["CategoryName"] = "--Select All Category--";
        //dtCategory.Rows.InsertAt(drCategory, 0);

        //cmbCategory.DataSource = dtCategory;
        //cmbCategory.DisplayMember = "CategoryName";
        //cmbCategory.ValueMember = "Id";


        ////*****for City*********
        //CityManager manageCity = new CityManager();
        //DataTable dtCity = new DataTable();
        //dtCity = manageCity.GetCityList();

        //DataRow drCity = dtCity.NewRow();
        //drCity["CityId"] = -1;
        //drCity["CityName"] = "--Select All City--";
        //dtCity.Rows.InsertAt(drCity, 0);

        //cmbCity.DataSource = dtCity;
        //cmbCity.DisplayMember = "CityName";
        //cmbCity.ValueMember = "CityId";

    }
}

