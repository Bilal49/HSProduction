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
    public partial class frmProductCatagory : Form
    {
        int ProductCatagoryId = -1;
        ProductManager Product = new ProductManager();
        public frmProductCatagory()
        {
            InitializeComponent();
        }

        private void frmProductCatagory_Load(object sender, EventArgs e)
        {
            try
            {

                ButtonRights(true);
                FillDropDown();
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
            txtCategoryId.ReadOnly = !Enable;
        }

        private void FillDropDown()
        {
            DataTable dtCategory = new DataTable();
            dtCategory = Product.GetProductCategoryList();

            DataRow drCategory = dtCategory.NewRow();
            drCategory["CategoryName"] = "--Select Parent Category--";
            drCategory["ProductCategoryId"] = "-1";
            dtCategory.Rows.InsertAt(drCategory, 0);

            cmbParentCategory.DataSource = dtCategory;
            cmbParentCategory.DisplayMember = "CategoryName";
            cmbParentCategory.ValueMember = "ProductCategoryId";
        }

        private void ClearFeilds()
        {
            txtCategoryId.Text = string.Empty;
            txtCategoryName.Text = string.Empty;
            cmbParentCategory.SelectedIndex = 0;
            txtCategoryName.Focus();
            ButtonRights(true);
        }

        private bool Validation()
        {
            bool result = true;

            if (string.IsNullOrEmpty(txtCategoryName.Text))
            {
                MessageBox.Show("Please Enter Category Name", "CategoryName is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
                txtCategoryName.Focus();
                return result;
            }


            return result;

        }

        private void LoadProductCategory(int ProductCategoryId)
        {
            DataTable dtProductCategory = Product.GetProductCategory(ProductCategoryId); ;
            if (dtProductCategory.Rows.Count > 0)
            {
                txtCategoryId.Text = dtProductCategory.Rows[0]["ProductCategoryId"].ToString();
                txtCategoryName.Text = dtProductCategory.Rows[0]["CategoryName"].ToString();
                if (!string.IsNullOrEmpty(dtProductCategory.Rows[0]["ParentId"].ToString()))
                {
                    cmbParentCategory.SelectedValue = dtProductCategory.Rows[0]["ParentId"];
                }
                ButtonRights(false);
            }
        }

        private int InsertProductCategory(string CategoryName, int ParentId ,  int AddedBy, DateTime AddedOn,
                                 string AddedIpAddr)
        {
            ProductCatagoryId = Product.InsertProductCatagory(CategoryName, ParentId,  AddedBy, AddedOn, AddedIpAddr);
            return ProductCatagoryId;

        }

        private void UpdateProductCategory(int ProductCategoryId, string CategoryName, int ParentId, int UpdatedBy, DateTime UpdatedOn, string UpdatedIpAddr)
        {
            Product.UpdateProductCategory(ProductCategoryId, CategoryName, ParentId , UpdatedBy, UpdatedOn, UpdatedIpAddr);
        }

        private void DeleteProductCategory(string ProductCategoryId)
        {

            Product.DeleteProductCategory(ProductCategoryId);
            MessageBox.Show("ProductCategory Delete Successfull.", "ProductCategory Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFeilds();
        }

        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                ProductCatagoryId = InsertProductCategory(txtCategoryName.Text, Convert.ToInt32(cmbParentCategory.SelectedValue) ,  0, DateTime.Now.Date, "0");
                MessageBox.Show("ProductCategory Insert Successfull.", "Record Inserted.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FillDropDown();
                if (ProductCatagoryId > 0)
                {
                    LoadProductCategory(ProductCatagoryId);
                }
                ClearFeilds();

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                UpdateProductCategory(ProductCatagoryId, txtCategoryName.Text, Convert.ToInt32(cmbParentCategory.SelectedValue) ,  0, DateTime.Now.Date, "0");
                MessageBox.Show("Record Update Successfull.", "ProductCatagory Updated.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FillDropDown();
                ClearFeilds();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFeilds();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to Delete it?", "Product Category Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.No:
                    {
                        return;
                        break;
                    }
                case DialogResult.Yes:
                    {
                        DeleteProductCategory(ProductCatagoryId.ToString());
                        break;
                    }

            }
        }

        private void txtCategoryId_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCategoryId.Text))
            {
                ProductCatagoryId = Product.GetProductCategoryIdByCode(Convert.ToInt32(txtCategoryId.Text));
                if (ProductCatagoryId > 0)
                {
                    LoadProductCategory(ProductCatagoryId);
                }
            }
        }

        private void txtCategoryId_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCategoryId.Text))
            {
                ProductCatagoryId = Product.GetProductCategoryIdByCode(Convert.ToInt32(txtCategoryId.Text));
                if (ProductCatagoryId > 0)
                {
                    LoadProductCategory(ProductCatagoryId);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {

                frmSearch search = new frmSearch();
                search.getattributes("GetProductCategorySearch", null, "ProductCategory");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtCategoryId.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                }
                else
                {



                    txtCategoryId.Text = string.Empty;
                    txtCategoryId.Focus();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtCategoryId_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    SendKeys.Send("{TAB}");
            //}
        }

        private void frmProductCatagory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

    }
}
