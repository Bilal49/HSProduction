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
    public partial class frmMesurementUnit : Form
    {
        int MesurementId = -1;
        ProductManager MesurementUnit = new ProductManager();
        public frmMesurementUnit()
        {
            InitializeComponent();
        }
        private void frmProductMesurementUnit_Load(object sender, EventArgs e)
        {
            try
            {

                ButtonRights(true);
                txtConversionRate.Text = "1";
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
             txtMesurementId.ReadOnly = !Enable;
        }

        private void ClearFeilds()
        {
            txtMesurementId.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtConversionRate.Text = "1";
            ButtonRights(true);
            txtDescription.Focus();
        }

        private bool Validation()
        {
            bool result = true;

            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                MessageBox.Show("Please Enter MesurementUnit Name.", "MesurementUnit Name is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
                txtDescription.Focus();
                return result;
            }


            return result;

        }

        private void LoadMesurementUnit(int MesurementId)
        {
            DataTable dtMesurementUnit = MesurementUnit.GetMesurementUnit(MesurementId); ;
            if (dtMesurementUnit.Rows.Count > 0)
            {
                txtMesurementId.Text = dtMesurementUnit.Rows[0]["MesurementId"].ToString();
                txtDescription.Text = dtMesurementUnit.Rows[0]["MesurementName"].ToString();
                txtConversionRate.Text = dtMesurementUnit.Rows[0]["ConversionRate"].ToString();
                ButtonRights(false);
            }
        }


        private int InsertMesurementUnit(string Description, int AddedBy, DateTime AddedOn,
                                 string AddedIpAddr)
        {
            decimal ConversionRate = 1; //Default Value Conversion Rate 1 hogi q k yeh age ja ker devide hoga formula mai ,or agr hum ne 0 divide ker dia toh runtime per error aye ga .Salman
            if (!string.IsNullOrEmpty(txtConversionRate.Text))
            {
                if (Convert.ToDecimal(txtConversionRate.Text) > 0)
                {
                    ConversionRate = Convert.ToDecimal(txtConversionRate.Text);
                }
            }
            MesurementId = MesurementUnit.InsertMesurementUnit(Description, ConversionRate ,  AddedBy, AddedOn, AddedIpAddr);
            return MesurementId;

        }

        private void UpdateMesurementUnit(int MesurementId, string Description, int UpdatedBy, DateTime UpdatedOn, string UpdatedIpAddr)
        {
            decimal ConversionRate = 1; //Default Value Conversion Rate 1 hogi q k yeh age ja ker devide hoga formula mai ,or agr hum ne 0 divide ker dia toh runtime per error aye ga .Salman
            if (!string.IsNullOrEmpty(txtConversionRate.Text))
            {
                if (Convert.ToDecimal(txtConversionRate.Text) > 0)
                {
                    ConversionRate = Convert.ToDecimal(txtConversionRate.Text);
                }
            }
            MesurementUnit.UpdateMesurementUnit(MesurementId, Description, ConversionRate , UpdatedBy, UpdatedOn, UpdatedIpAddr);
        }

        private void DeleteMesurementUnit(int MesurementId)
        {

            MesurementUnit.DeleteMesurementUnit(MesurementId);
            MessageBox.Show("MesurementUnit Delete Successfull.", "MesurementUnit Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFeilds();
        }

        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                MesurementId = InsertMesurementUnit(txtDescription.Text, MainForm.User_Id , DateTime.Now.Date, "0");
                MessageBox.Show("MesurementUnit Insert Successfull.", "Record Inserted.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (MesurementId > 0)
                {
                    LoadMesurementUnit(MesurementId);
                }
                ClearFeilds();

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                UpdateMesurementUnit(MesurementId, txtDescription.Text, MainForm.User_Id , DateTime.Now.Date, "0");
                MessageBox.Show("MesurementUnit Update Successfull.", "MesurementUnit Updated.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFeilds();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFeilds();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to Delete it?", "MesurementUnit Delete.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.No:
                    {
                        return;
                        break;
                    }
                case DialogResult.Yes:
                    {
                        DeleteMesurementUnit(MesurementId);
                        break;
                    }

            }
        }

        private void txtMesurementId_TextChanged(object sender, EventArgs e)
        {
            try
            {
            
            if (!string.IsNullOrEmpty(txtMesurementId.Text))
            {
                MesurementId = MesurementUnit.GetMesurementUnitIdByCode(Convert.ToInt32(txtMesurementId.Text));
                if (MesurementId > 0)
                {
                    LoadMesurementUnit(MesurementId);
                }
            }
            }
            catch (Exception ex)
            {
            }
        }

        private void txtMesurementId_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {

                frmSearch search = new frmSearch();
                search.getattributes("GetProductMesurementUnitSearch", null, "Mesurement Unit");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtMesurementId.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                }
                else
                {
                    txtMesurementId.Text = string.Empty;
                    txtMesurementId.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmMesurementUnit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        Utility clsUtility = new Utility();
        private void txtConversionRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsUtility.setOnlyNumberic((TextBox)sender, true, e);
        }
    }
}
