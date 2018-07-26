//using RiceMill.App_Code.ProductionStatusManager;
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
    public partial class frmProductionStatus : Form
    {
        int ProductionStatusId = -1;
        ProductionManager manageProductionStatus = new ProductionManager();
        public frmProductionStatus()
        {
            InitializeComponent();
        }

        private void frmProductionStatus_Load(object sender, EventArgs e)
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
            txtProductionStatusId.ReadOnly = !Enable;
        }

        private void ClearFeilds()
        {
            txtProductionStatusId.Text = string.Empty;
            txtProductionStatus.Text = string.Empty;
            ButtonRights(true);
            txtProductionStatus.Focus();
        }

        private bool Validation()
        {
            bool result = true;

            if (string.IsNullOrEmpty(txtProductionStatus.Text))
            {
                MessageBox.Show("Please Enter ProductionStatus Name", "ProductionStatus Name Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
                txtProductionStatus.Focus();
                return result;
            }


            return result;

        }

        private void LoadProductionStatus(int ProductionStatusId)
        {
            DataTable dtProductCategory = manageProductionStatus.GetProductionStatus(ProductionStatusId); ;
            if (dtProductCategory.Rows.Count > 0)
            {
                txtProductionStatusId.Text = dtProductCategory.Rows[0]["ProductionStatusId"].ToString();
                txtProductionStatus.Text = dtProductCategory.Rows[0]["ProductionStatus"].ToString();
                ButtonRights(false);
            }
        }


        private int InsertProductionStatus(string ProductionStatus, int AddedBy, DateTime AddedOn,
                                 string AddedIpAddr)
        {
            ProductionStatusId = manageProductionStatus.InsertProductionStatus(ProductionStatus, AddedBy, AddedOn, AddedIpAddr);
            return ProductionStatusId;

        }

        private void UpdateProductionStatus(int ProductionStatusId, string ProductionStatus, int UpdatedBy, DateTime UpdatedOn, string UpdatedIpAddr)
        {
            manageProductionStatus.UpdateProductionStatus(ProductionStatusId, ProductionStatus, UpdatedBy, UpdatedOn, UpdatedIpAddr);
        }

        private void DeleteProductionStatus(string ProductionStatusId)
        {

            manageProductionStatus.DeleteProductionStatus(ProductionStatusId);
            MessageBox.Show("ProductionStatus Record Delete Successfull.", "ProductionStatus Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFeilds();
        }

        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                ProductionStatusId = InsertProductionStatus(txtProductionStatus.Text, 0, DateTime.Now.Date, "0");
                MessageBox.Show("ProductionStatus Record Inserted.", "Record Inserted.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (ProductionStatusId > 0)
                {
                    LoadProductionStatus(ProductionStatusId);
                }
                ClearFeilds();

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                UpdateProductionStatus(ProductionStatusId, txtProductionStatus.Text, 0, DateTime.Now.Date, "0");
                MessageBox.Show("ProductionStatus Record Update", "ProductionStatus Updated.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFeilds();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFeilds();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to Delete it?", "ProductionStatus Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.No:
                    {
                        return;
                        break;
                    }
                case DialogResult.Yes:
                    {
                        DeleteProductionStatus(ProductionStatusId.ToString());
                        break;
                    }

            }
        }

        private void txtProductionStatusId_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtProductionStatusId.Text))
            {
                ProductionStatusId = manageProductionStatus.GetProductionStatusIdById(Convert.ToInt32(txtProductionStatusId.Text));
                if (ProductionStatusId > 0)
                {
                    LoadProductionStatus(ProductionStatusId);
                }
            }
        }

        private void txtProductionStatusId_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtProductionStatusId.Text))
            {
                ProductionStatusId = manageProductionStatus.GetProductionStatusIdById(Convert.ToInt32(txtProductionStatusId.Text));
                if (ProductionStatusId > 0)
                {
                    LoadProductionStatus(ProductionStatusId);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {

                frmSearch search = new frmSearch();
                search.getattributes("GetProductionStatusSearch", null, "ProductionStatus");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtProductionStatusId.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                }
                else
                {
                    txtProductionStatusId.Text = string.Empty;
                    txtProductionStatusId.Focus();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtProductionStatusId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void frmProductionStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6)
            {
                ClearFeilds();
            }
            else if (e.KeyCode == Keys.F3)
            {
                if (btnAdd.Enabled)
                {
                    btnAdd.PerformClick();
                }
                else if (btnUpdate.Enabled)
                {
                    btnUpdate.PerformClick();
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
            else if (e.KeyCode == Keys.F2)
            {
                btnSearch.PerformClick();
            }
        }


    }
}
