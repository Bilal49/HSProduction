using FIL.App_Code.SystemManager;
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
    public partial class SystemParameter : Form
    {
        public SystemParameter()
        {
            InitializeComponent();
        }

        private void cmbPOSPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SystemParameter_Load(object sender, EventArgs e)
        {
            FillInstalledPrinter();
            LoadSystemInfo();
        }

        private void FillInstalledPrinter()
        {
            List<string> lstPrinter = new List<string>();
            List<string> lstPrinterPOS = new List<string>();
            lstPrinter.Add("--Select Printer--");
            lstPrinterPOS.Add("--Select Printer--");
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                lstPrinter.Add(printer);
                lstPrinterPOS.Add(printer);
            }
            cmbNormalPrinter.DataSource = lstPrinter;
            cmbPOSPrinter.DataSource = lstPrinterPOS;
        }


        private void LoadSystemInfo()
        {
            try
            {

                SystemManager SM = new SystemManager();
                DataTable dtSysinfo = SM.GetSystemInfo();
                if (dtSysinfo.Rows.Count > 0)
                {
                    cmbNormalPrinter.SelectedItem = dtSysinfo.Rows[0]["PrinterGeneralReports"].ToString();
                    cmbPOSPrinter.SelectedItem = dtSysinfo.Rows[0]["PrinterForPOSSlip"].ToString();
                    txtReportFooterText.Text = dtSysinfo.Rows[0]["ReportFooterText"].ToString();
                    if (!string.IsNullOrEmpty(dtSysinfo.Rows[0]["FiscalYearStart"].ToString()))
                    {
                        dtpFicalStart.Value = Convert.ToDateTime(dtSysinfo.Rows[0]["FiscalYearStart"]);
                    }
                    else
                    {
                        dtpFicalStart.Value = DateTime.Now;
                    }
                    if (!string.IsNullOrEmpty(dtSysinfo.Rows[0]["FiscalYearEnd"].ToString()))
                    {
                        dtpFiscalEnd.Value = Convert.ToDateTime(dtSysinfo.Rows[0]["FiscalYearEnd"]);
                    }
                    else
                    {
                        dtpFiscalEnd.Value = DateTime.Now;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error to Fill Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                SystemManager SM = new SystemManager();
                SM.UpdateSystemParameters(((cmbNormalPrinter.SelectedIndex == 0) ? "" : cmbNormalPrinter.SelectedValue.ToString()), ((cmbPOSPrinter.SelectedIndex == 0) ? "" : cmbPOSPrinter.SelectedValue.ToString()), txtReportFooterText.Text , dtpFicalStart.Value , dtpFiscalEnd.Value);
                MessageBox.Show("Record Saved Sucessfull.", "Setting Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private bool Validation()
        {
            bool result = true;
            int DayDiff = 0;
            DayDiff = Convert.ToInt32((dtpFiscalEnd.Value - dtpFicalStart.Value).TotalDays);
            if (DayDiff > 365)
            {
                MessageBox.Show("Fical Year Must be equal to 365 days", "Invalid Period Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
                return result;
            }
            //if (DayDiff < 365)
            //{
            //    MessageBox.Show("Fical Year Must be equal to 365 days", "Invalid Period Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    result = false;
            //    return result;
            //}
            return result;
        }
    }
}
