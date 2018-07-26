using FIL;
using FIL.App_Code.VoucherMananger;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


public partial class frmVoucherPosting : Form
{
    VoucherManager manageVoucher = new VoucherManager();
    DataTable dtVocherDetail = new DataTable();
    Smartworks.DAL dataAcess = new Smartworks.DAL();
    public frmVoucherPosting()
    {
        InitializeComponent();
    }

    private void frmVoucherPosting_Load(object sender, EventArgs e)
    {
        FillDropDown();
    }

    private void FillDropDown()
    {
        List<VoucherType> lstVoucherType = new List<VoucherType>();
        lstVoucherType.Add(new VoucherType { strVoucherType = "Cash Receipt", Prefix = "CR" });
        lstVoucherType.Add(new VoucherType { strVoucherType = "Cash Payment", Prefix = "CP" });
        lstVoucherType.Add(new VoucherType { strVoucherType = "Bank Receipt", Prefix = "BR" });
        lstVoucherType.Add(new VoucherType { strVoucherType = "Bank Payment", Prefix = "BP" });
        lstVoucherType.Add(new VoucherType { strVoucherType = "Journal Voucher", Prefix = "JV" });

        cmbVoucherType.DataSource = lstVoucherType;
        cmbVoucherType.DisplayMember = "strVoucherType";
        cmbVoucherType.ValueMember = "Prefix";
    }

    private void btnView_Click(object sender, EventArgs e)
    {
        try
        {
            dtVocherDetail = manageVoucher.GetVoucherListForPosting(dtpFromDate.Value, dtpToDate.Value, cmbVoucherType.SelectedValue.ToString());
            GCDetail.DataSource = dtVocherDetail;

            gvDetail.Columns.ColumnByName("colVoucherMasterId").Visible = false;

            gvDetail.Columns.ColumnByName("colIsSelect").Caption = "Selection";
            gvDetail.Columns.ColumnByName("colVoucherNumber").Caption = "Voucher #";
            gvDetail.Columns.ColumnByName("colDate").Caption = "Dated";
            gvDetail.Columns.ColumnByName("colNarration").Caption = "Narration";
            gvDetail.Columns.ColumnByName("colTotalDebit").Caption = "Total Debit";
            gvDetail.Columns.ColumnByName("colTotalCredit").Caption = "Total Credit";


            gvDetail.Columns.ColumnByName("colIsSelect").VisibleIndex = 0;
            gvDetail.Columns.ColumnByName("colVoucherNumber").VisibleIndex = 1;
            gvDetail.Columns.ColumnByName("colDate").VisibleIndex = 2;
            gvDetail.Columns.ColumnByName("colNarration").VisibleIndex = 3;
            gvDetail.Columns.ColumnByName("colTotalDebit").VisibleIndex = 4;
            gvDetail.Columns.ColumnByName("colTotalCredit").VisibleIndex = 5;

            gvDetail.Columns.ColumnByName("colIsSelect").Width = 50;
            gvDetail.Columns.ColumnByName("colVoucherNumber").Width = 80;
            gvDetail.Columns.ColumnByName("colDate").Width = 100;
            gvDetail.Columns.ColumnByName("colNarration").Width = 250;
            gvDetail.Columns.ColumnByName("colTotalDebit").Width = 80;
            gvDetail.Columns.ColumnByName("colTotalCredit").Width = 80;


            gvDetail.Columns.ColumnByName("colVoucherNumber").OptionsColumn.AllowEdit = false;
            gvDetail.Columns.ColumnByName("colDate").OptionsColumn.AllowEdit = false;
            gvDetail.Columns.ColumnByName("colNarration").OptionsColumn.AllowEdit = false;
            gvDetail.Columns.ColumnByName("colTotalDebit").OptionsColumn.AllowEdit = false;
            gvDetail.Columns.ColumnByName("colTotalCredit").OptionsColumn.AllowEdit = false;
        }
        catch (Exception ex)
        {
        }
    }

    private void chkAll_CheckedChanged(object sender, EventArgs e)
    {
        foreach (DataRow dr in dtVocherDetail.Rows)
        {
            dr["IsSelect"] = chkAll.Checked;
        }
    }

    private void button1_Click(object sender, EventArgs e)
    {
        dtpToDate.Value = DateTime.Now;
        dtpFromDate.Value = DateTime.Now;
        cmbVoucherType.SelectedIndex = 0;
        dtVocherDetail = new DataTable();
        GCDetail.DataSource = null;
        chkAll.Checked = false;
        pgBar.Value = 0;
    }

    private bool Validation()
    {
        bool result = true;

        bool RecordExists = false;
        foreach (DataRow dr in dtVocherDetail.Rows)
        {
            if (Convert.ToBoolean(dr["IsSelect"]))
            {
                RecordExists = true;
                break;
            }
        }

        if (!RecordExists)
        {
            MessageBox.Show("No Selected Record Found. Make sure any one rows Check Mark.", "Record Not Found For Posting", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            result = false;
            return result;
        }


        return result;
    }


    private void btnPost_Click(object sender, EventArgs e)
    {
        if (dtpFromDate.Value.Date < MainForm.FicalYearStart.Date || dtpFromDate.Value.Date > MainForm.FicalYearEnd.Date)
        {
            MessageBox.Show("Invalid From Date Selection. Selected Date is Out of Rang of Fical Year", "Invalid Date Selection.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (dtpToDate.Value.Date < MainForm.FicalYearStart.Date || dtpToDate.Value.Date > MainForm.FicalYearEnd.Date)
        {
            MessageBox.Show("Invalid To Date Selection. Selected Date is Out of Rang of Fical Year", "Invalid Date Selection.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        DialogResult result = MessageBox.Show("Are you sure want to Post it?", "Record Posting", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        switch (result)
        {
            case DialogResult.No:
                {
                    return;
                    
                }
            case DialogResult.Yes:
                {
                    if (Validation())
                    {
                        PostVoucher();
                    }
                    break;
                }
        }

        
    }

    private void PostVoucher()
    {
        try
        {
            dataAcess.BeginTransaction();
            int count = dtVocherDetail.Select("IsSelect = 1").Length;
            int current = 0;
            foreach (DataRow dr in dtVocherDetail.Rows)
            {
                if (Convert.ToBoolean(dr["IsSelect"]))
                {
                    if (!manageVoucher.PostVoucher(dr["VoucherNumber"].ToString(), dataAcess))
                    {
                        throw new Exception("Data Not Post on Voucher No :" + dr["VoucherNumber"].ToString());
                    }
                    current++;
                    pgBar.Value = current / count * 100;
                }
            }
            dataAcess.TransCommit();
            MessageBox.Show("Record Posting Sucessfully.", "Record Posted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            button1_Click(null, null);
        }
        catch (SqlException sqlex)
        {
            dataAcess.TransRollback();
            MessageBox.Show(sqlex.Message);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally
        {
            dataAcess.ConnectionClose();
            pgBar.Value = 0;
        }
    }
}

public class VoucherType
{
    public string strVoucherType { get; set; }
    public string Prefix { get; set; }

}

