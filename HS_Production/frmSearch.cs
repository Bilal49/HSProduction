using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FIL
{
    public partial class frmSearch : Form
    {
        string query;
        Smartworks.ColumnField[] SearchParameterField;
        string ProcedureName;
        DataSet dset;
        object value;
        public DataRow dr;
        Smartworks.DAL dataAccess = new Smartworks.DAL();

        public frmSearch()
        {
            InitializeComponent();
            string connString = ConfigurationManager.ConnectionStrings["HSConnectionString"].ConnectionString;
            Smartworks.DAL.ConnectionString = connString;
        }

        private void frmSearch_Load(object sender, EventArgs e)
        {
            try
            {
                dset = dataAccess.getDataSetByStoredProcedure(ProcedureName, SearchParameterField);
                gridControl1.DataSource = dset.Tables[0];
                foreach (DevExpress.XtraGrid.Columns.GridColumn col in gridView1.Columns)
                {
                    col.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, Messages.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F7)
            {
                if (gridView1.RowCount > 0)
                {
                    dr = gridView1.GetFocusedDataRow();
                    if (dr != null)
                    {
                        value = dr[0].ToString();
                    }
                    this.Close();
                }
            }
        }

        private void frmSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.Dispose();
            }
        }

        public void getattributes(string StoredProcedure, Smartworks.ColumnField[] SearchField, string Heading)
        {
            ProcedureName = StoredProcedure;
            SearchParameterField = SearchField;

        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            dr = gridView1.GetFocusedDataRow();
            value = dr[0].ToString();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                MainForm.Searched_Id = value.ToString();
                this.Close();
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            dr = gridView1.GetFocusedDataRow();
            if (dr != null)
            {
                value = dr[0].ToString();
            }
        }

        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            dr = gridView1.GetFocusedDataRow();
            value = dr[0].ToString();
        }

        private void gridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar.ToString().Trim() == "13")
            //{
            //    if (gridView1.RowCount > 0)
            //    {
            //        MainForm.Searched_Id = value.ToString();
            //        this.Close();
            //    }
            //}

        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (gridView1.RowCount > 0)
                {
                    MainForm.Searched_Id = value.ToString();
                    this.Close();
                }
            }
        }


    }
}
