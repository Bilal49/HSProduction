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
    public partial class frmProductType : Form
    {
        int ProductTypeId = -1;
        ProductManager ProductType = new ProductManager();
        public frmProductType()
        {
            InitializeComponent();
        }

        private void frmProductType_Load(object sender, EventArgs e)
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
            txtTypeId.ReadOnly = !Enable;
        }

        private void ClearFeilds()
        {
            txtTypeId.Text = string.Empty;
            txtDescription.Text = string.Empty;
            ButtonRights(true);
            txtDescription.Focus();
        }

        private bool Validation()
        {
            bool result = true;

            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                MessageBox.Show("Please Enter Product Type.", "Product Type is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
                txtDescription.Focus();
                return result;
            }


            return result;

        }

        private void LoadProductType(int ProductTypeId)
        {
            DataTable dtProductType = ProductType.GetProductType(ProductTypeId); ;
            if (dtProductType.Rows.Count > 0)
            {
                txtTypeId.Text = dtProductType.Rows[0]["ProductTypeId"].ToString();
                txtDescription.Text = dtProductType.Rows[0]["Description"].ToString();
                ButtonRights(false);
            }
        }


        private int InsertEmployee(string Description, int AddedBy, DateTime AddedOn,
                                 string AddedIpAddr)
        {
            ProductTypeId = ProductType.InsertProductType(Description, AddedBy, AddedOn, AddedIpAddr);
            return ProductTypeId;

        }

        private void UpdateEmployee(int ProductTypeId, string Description, int UpdatedBy, DateTime UpdatedOn, string UpdatedIpAddr)
        {
            ProductType.UpdateProductType(ProductTypeId, Description, UpdatedBy, UpdatedOn, UpdatedIpAddr);
        }

        private void DeleteEmployee(string ProductTypeId)
        {

            ProductType.DeleteProductType(ProductTypeId);
            MessageBox.Show("Product Type Delete Successfull.", "ProductType Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFeilds();
        }

        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                ProductTypeId = InsertEmployee(txtDescription.Text, 0, DateTime.Now.Date, "0");
                MessageBox.Show("Product Type Insert Successfull.", "Record Inserted.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (ProductTypeId > 0)
                {
                    LoadProductType(ProductTypeId);
                }
                ClearFeilds();

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                UpdateEmployee(ProductTypeId, txtDescription.Text, 0, DateTime.Now.Date, "0");
                MessageBox.Show("Product Type Update Successfull.", "ProductType Updated.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFeilds();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFeilds();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to Delete it?", "Product Type Delete.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.No:
                    {
                        return;
                        break;
                    }
                case DialogResult.Yes:
                    {
                        DeleteEmployee(ProductTypeId.ToString());
                        break;
                    }

            }
        }

        private void txtTypeId_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTypeId.Text))
            {
                ProductTypeId = ProductType.GetProductTypeIdByCode(Convert.ToInt32(txtTypeId.Text));
                if (ProductTypeId > 0)
                {
                    LoadProductType(ProductTypeId);
                }
            }
        }

        private void txtTypeId_KeyDown(object sender, KeyEventArgs e)
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
                search.getattributes("GetProductTypeSearch", null, "ProductType");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtTypeId.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                }
                else
                {



                    txtTypeId.Text = string.Empty;
                    txtTypeId.Focus();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtTypeId_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTypeId.Text))
            {
                ProductTypeId = ProductType.GetProductTypeIdByCode(Convert.ToInt32(txtTypeId.Text));
                if (ProductTypeId > 0)
                {
                    LoadProductType(ProductTypeId);
                }
            }
        }



    }
}
