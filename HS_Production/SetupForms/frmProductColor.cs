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
    public partial class frmProductColor : Form
    {
        int ColorId = -1;
        ProductManager ProductColor = new ProductManager();
        public frmProductColor()
        {
            InitializeComponent();
        }
        private void frmProductColor_Load(object sender, EventArgs e)
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
            txtColorId.ReadOnly = !Enable;
        }

        private void ClearFeilds()
        {
            txtColorId.Text = string.Empty;
            txtDescription.Text = string.Empty;

            ButtonRights(true);
            txtDescription.Focus();
        }

        private bool Validation()
        {
            bool result = true;

            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                MessageBox.Show("Please Enter Color Name.", "Color Name is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
                txtDescription.Focus();
                return result;
            }


            return result;

        }

        private void LoadProductColor(int ColorId)
        {
            DataTable dtProductColor = ProductColor.GetProductColor(ColorId); ;
            if (dtProductColor.Rows.Count > 0)
            {
                txtColorId.Text = dtProductColor.Rows[0]["ColorId"].ToString();
                txtDescription.Text = dtProductColor.Rows[0]["ColorName"].ToString();
                ButtonRights(false);
            }
        }


        private int InsertColor(string Description, int AddedBy, DateTime AddedOn,
                                 string AddedIpAddr)
        {
            ColorId = ProductColor.InsertProductColor(Description, AddedBy, AddedOn, AddedIpAddr);
            return ColorId;

        }

        private void UpdateColor(int ColorId, string Description, int UpdatedBy, DateTime UpdatedOn, string UpdatedIpAddr)
        {
            ProductColor.UpdateProductColor(ColorId, Description, UpdatedBy, UpdatedOn, UpdatedIpAddr);
        }

        private void DeleteColor(int ColorId)
        {

            ProductColor.DeleteProductColor(ColorId);
            MessageBox.Show("Product Color Delete Successfull.", "ProductColor Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFeilds();
        }

        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                ColorId = InsertColor(txtDescription.Text, 0, DateTime.Now.Date, "0");
                MessageBox.Show("Product Color Insert Successfull.", "Record Inserted.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (ColorId > 0)
                {
                    LoadProductColor(ColorId);
                }
                ClearFeilds();

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                UpdateColor(ColorId, txtDescription.Text, 0, DateTime.Now.Date, "0");
                MessageBox.Show("Product Color Update Successfull.", "ProductColor Updated.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFeilds();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFeilds();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to Delete it?", "Product Color Delete.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.No:
                    {
                        return;
                        break;
                    }
                case DialogResult.Yes:
                    {
                        DeleteColor(ColorId);
                        break;
                    }

            }
        }

        private void txtColorId_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtColorId.Text))
            {
                ColorId = ProductColor.GetProductColorIdByCode(Convert.ToInt32(txtColorId.Text));
                if (ColorId > 0)
                {
                    LoadProductColor(ColorId);
                }
            }
        }

        private void txtColorId_KeyDown(object sender, KeyEventArgs e)
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
                search.getattributes("GetProductColorSearch", null, "ProductColor");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtColorId.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                }
                else
                {



                    txtColorId.Text = string.Empty;
                    txtColorId.Focus();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtColorId_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtColorId.Text))
            {
                ColorId = ProductColor.GetProductColorIdByCode(Convert.ToInt32(txtColorId.Text));
                if (ColorId > 0)
                {
                    LoadProductColor(ColorId);
                }
            }
        }

        


    }
}
