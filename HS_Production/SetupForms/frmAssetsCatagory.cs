using FIL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;




    public partial class frmAssetsCatagory : Form
    {
        int AssetsCatagoryId = -1;
        AssetsManager manageAssets = new AssetsManager();
        public frmAssetsCatagory()
        {
            InitializeComponent();
        }

        private void frmAssetsCatagory_Load(object sender, EventArgs e)
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
            txtAssetsCategoryId.ReadOnly = !Enable;
        }

      
        private void ClearFeilds()
        {
            txtAssetsCategoryId.Text = string.Empty;
            txtCategoryName.Text = string.Empty;
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

        private void LoadAssetsCategory(int AssetsCategoryId)
        {
            DataTable dtAssetsCategory = manageAssets.GetAssetsCategory(AssetsCategoryId); ;
            if (dtAssetsCategory.Rows.Count > 0)
            {
                txtAssetsCategoryId.Text = dtAssetsCategory.Rows[0]["AssetsCategoryId"].ToString();
                txtCategoryName.Text = dtAssetsCategory.Rows[0]["CategoryName"].ToString();
                ButtonRights(false);
            }
        }

        private int InsertAssetsCategory(string CategoryName,   int AddedBy, DateTime AddedOn,
                                 string AddedIpAddr)
        {
            AssetsCatagoryId = manageAssets.InsertAssetsCatagory(CategoryName,  AddedBy, AddedOn, AddedIpAddr);
            return AssetsCatagoryId;

        }

        private void UpdateAssetsCategory(int AssetsCategoryId, string CategoryName, int UpdatedBy, DateTime UpdatedOn, string UpdatedIpAddr)
        {
            manageAssets.UpdateAssetsCategory(AssetsCategoryId, CategoryName , UpdatedBy, UpdatedOn, UpdatedIpAddr);
        }

        private void DeleteAssetsCategory(string AssetsCategoryId)
        {

            manageAssets.DeleteAssetsCategory(AssetsCategoryId);
            MessageBox.Show("AssetsCategory Delete Successfull.", "AssetsCategory Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFeilds();
        }

        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                AssetsCatagoryId = InsertAssetsCategory(txtCategoryName.Text,MainForm.User_Id, DateTime.Now.Date, "0");
                MessageBox.Show("AssetsCategory Insert Successfull.", "Record Inserted.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (AssetsCatagoryId > 0)
                {
                    LoadAssetsCategory(AssetsCatagoryId);
                }
                ClearFeilds();

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                UpdateAssetsCategory(AssetsCatagoryId, txtCategoryName.Text, 0, DateTime.Now.Date, "0");
                MessageBox.Show("Record Update Successfull.", "AssetsCatagory Updated.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFeilds();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFeilds();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to Delete it?", "Assets Category Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.No:
                    {
                        return;
                        break;
                    }
                case DialogResult.Yes:
                    {
                        DeleteAssetsCategory(AssetsCatagoryId.ToString());
                        break;
                    }

            }
        }

        private void txtCategoryId_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtAssetsCategoryId.Text))
            {
                AssetsCatagoryId = manageAssets.GetAssetsCategoryIdByCode(Convert.ToInt32(txtAssetsCategoryId.Text));
                if (AssetsCatagoryId > 0)
                {
                    LoadAssetsCategory(AssetsCatagoryId);
                }
            }
        }

        private void txtCategoryId_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtAssetsCategoryId.Text))
            {
                AssetsCatagoryId = manageAssets.GetAssetsCategoryIdByCode(Convert.ToInt32(txtAssetsCategoryId.Text));
                if (AssetsCatagoryId > 0)
                {
                    LoadAssetsCategory(AssetsCatagoryId);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {

                frmSearch search = new frmSearch();
                search.getattributes("GetAssetsCategorySearch", null, "AssetsCategory");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtAssetsCategoryId.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                }
                else
                {
                    txtAssetsCategoryId.Text = string.Empty;
                    txtAssetsCategoryId.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtCategoryId_KeyDown(object sender, KeyEventArgs e)
        {   
        }

        private void frmAssetsCatagory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
    }