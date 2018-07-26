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
    public partial class frmProductSize : Form
    {
        int SizeId = -1;
        ProductManager ProductSize = new ProductManager();
        public frmProductSize()
        {
            InitializeComponent();
        }
        private void frmProductSize_Load(object sender, EventArgs e)
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
            txtSizeId.ReadOnly = !Enable;
        }

        private void ClearFeilds()
        {
            txtSizeId.Text = string.Empty;
            txtDescription.Text = string.Empty;
            ButtonRights(true);
            txtDescription.Focus();
        }


        private bool Validation()
        {
            bool result = true;

            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                MessageBox.Show("Please Enter Size Name.", "Size Name is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
                txtDescription.Focus();
                return result;
            }


            return result;

        }

        private void LoadProductSize(int SizeId)
        {
            DataTable dtProductSize = ProductSize.GetProductSize(SizeId); ;
            if (dtProductSize.Rows.Count > 0)
            {
                txtSizeId.Text = dtProductSize.Rows[0]["SizeId"].ToString();
                txtDescription.Text = dtProductSize.Rows[0]["SizeName"].ToString();
                ButtonRights(false);
            }
        }


        private int InsertColor(string Description, int AddedBy, DateTime AddedOn,
                                 string AddedIpAddr)
        {
            SizeId = ProductSize.InsertProductSize(Description, AddedBy, AddedOn, AddedIpAddr);
            return SizeId;

        }

        private void UpdateColor(int SizeId, string Description, int UpdatedBy, DateTime UpdatedOn, string UpdatedIpAddr)
        {
            ProductSize.UpdateProductSize(SizeId, Description, UpdatedBy, UpdatedOn, UpdatedIpAddr);
        }

        private void DeleteColor(int SizeId)
        {

            ProductSize.DeleteProductSize(SizeId);
            MessageBox.Show("Product Size Delete Successfull.", "ProductSize Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFeilds();
        }

        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                SizeId = InsertColor(txtDescription.Text, 0, DateTime.Now.Date, "0");
                MessageBox.Show("Product Size Insert Successfull.", "Record Inserted.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (SizeId > 0)
                {
                    LoadProductSize(SizeId);
                }
                ClearFeilds();

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                UpdateColor(SizeId, txtDescription.Text, 0, DateTime.Now.Date, "0");
                MessageBox.Show("Product Size Update Successfull.", "ProductSize Updated.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFeilds();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFeilds();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to Delete it?", "Product Size Delete.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.No:
                    {
                        return;
                        break;
                    }
                case DialogResult.Yes:
                    {
                        DeleteColor(SizeId);
                        break;
                    }

            }
        }

        private void txtSizeId_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSizeId.Text))
            {
                SizeId = ProductSize.GetProductSizeIdByCode(Convert.ToInt32(txtSizeId.Text));
                if (SizeId > 0)
                {
                    LoadProductSize(SizeId);
                }
            }
        }

        private void txtSizeId_KeyDown(object sender, KeyEventArgs e)
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
                search.getattributes("GetProductSizeSearch", null, "ProductSize");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtSizeId.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                }
                else
                {



                    txtSizeId.Text = string.Empty;
                    txtSizeId.Focus();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSizeId_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSizeId.Text))
            {
                SizeId = ProductSize.GetProductSizeIdByCode(Convert.ToInt32(txtSizeId.Text));
                if (SizeId > 0)
                {
                    LoadProductSize(SizeId);
                }
            }
        }

        


    }
}
