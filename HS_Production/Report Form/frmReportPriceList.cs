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

namespace FIL.Report_Form
{
    public partial class frmReportPriceList : Form
    {
        Smartworks.DAL dataAccess = new Smartworks.DAL();
        public frmReportPriceList()
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
            ProductManager PM = new ProductManager();
            DataTable dtProductCatagory = PM.GetAllProductCategory();
            if (dtProductCatagory.Rows.Count > 0)
            {
                DataRow dr = dtProductCatagory.NewRow();
                dr["ProductCategoryId"] = -1;
                dr["CategoryName"] =  "--- قسم منتخب کریں ---";
                dtProductCatagory.Rows.InsertAt(dr, 0);
                cmbProductCatagory.DataSource = dtProductCatagory;
                cmbProductCatagory.DisplayMember = "CategoryName";
                cmbProductCatagory.ValueMember = "ProductCategoryId";
            }
        }
        private void btnFromSearch_Click(object sender, EventArgs e)
        {
             try
            {
            
            frmSearch search = new frmSearch();
            search.getattributes("GetProductSearch", null, "Items");
            search.ShowDialog();
            if (!string.IsNullOrEmpty(MainForm.Searched_Id))
            {
                txtFromCode.Text = MainForm.Searched_Id;
                MainForm.Searched_Id = string.Empty;
            }
            else
            {
                txtFromCode.Text = string.Empty;
                txtFromCode.Focus();

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
            search.getattributes("GetProductSearch", null, "Items");
            search.ShowDialog();
            if (!string.IsNullOrEmpty(MainForm.Searched_Id))
            {
                txtToCode.Text = MainForm.Searched_Id;
                MainForm.Searched_Id = string.Empty;
            }
            else
            {
                txtToCode.Text = string.Empty;
                txtToCode.Focus();

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
                ProductManager p = new ProductManager();
                ReportDocument document = new ReportDocument();
                string path = Application.StartupPath + "/rpt/rptPriceList.rpt";
                //string path = @"E:\HandsomeSolution\GernalShop-PreviousWork\GernalShop-PreviousWork\GernalShopLastUpdate\FIL\rpt\Inventory\rptPriceList.rpt";
                document.Load(path);
                DataTable dtReport = new DataTable();
                dtReport = p.GetReportPriceList(Convert.ToInt32(cmbProductCatagory.SelectedValue), txtFromCode.Text, txtToCode.Text);
                document.SetDataSource(dtReport);
                document.SetParameterValue("ShowCategory", chkShowCetagory.Checked);
                document.SetParameterValue("ShowRates", chkShowRate.Checked);
                document.SetParameterValue("ShowColor", chkShowColor.Checked);
                document.SetParameterValue("ShowCName", chkShowCompany.Checked);
                Utility.SetReportDefaultParameter(ref document);
                crystalRptPriceList.ReportSource = document;
                crystalRptPriceList.Refresh();
                //document.PrintToPrinter(1, true, 0, 0);
            }
            catch (Exception ex)
            {
            }
        }

      
    }
}
