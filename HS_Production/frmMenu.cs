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
    public partial class frmMenu : Form
    {



        MenuManager MenuManager = new MenuManager();

        public frmMenu()
        {
            InitializeComponent();
        }

        private void frmArea_Load(object sender, EventArgs e)
        {
            try
            {

                ButtonRights(true);
            }
            catch (Exception ex)
            {

            }
        }

        #region Methods

        private void clear()
        {
            txtMenuId.Text = string.Empty;
            txtMenuName.Text = string.Empty;
            txtParentName.Text = string.Empty;
            chkParent.Checked = false;
            chkReport.Checked = false;
            ButtonRights(true);
        }

        private void ButtonRights(bool Enable)
        {
            btnAdd.Enabled = Enable;
            btnUpdate.Enabled = !Enable;
            btnDelete.Enabled = !Enable;
            //txtRoleId.ReadOnly = !Enable;
        }

        private bool Validation()
        {
            bool result = true;

            if (string.IsNullOrEmpty(txtMenuName.Text))
            {
                MessageBox.Show("Please Enter Menu Name", "Menu Name is Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMenuId.Focus();
                result = false;
                return result;
            }


            return result;
        }

        private int InsertMenu(string menu, string parentName, int parent, bool isParent, bool isReport)
        {
            int MenuId = MenuManager.InsertMenu(menu, parentName, parent, isParent, isReport);
            return MenuId;
        }

        private void UpdateMenu(int menuId, string menuName, string parentName, int parent, bool isParent, bool isReport)
        {
            MenuManager.UpdateMenu(menuId, menuName, parentName, parent, isParent, isReport);
        }

        private void LoadMenuById(int pMenuId)
        {

            DataTable dt = new DataTable();
            dt = MenuManager.GetMenuById(pMenuId);
            if (dt.Rows.Count > 0)
            {
                txtMenuId.Text = dt.Rows[0]["MenuId"].ToString();
                txtMenuName.Text = dt.Rows[0]["MenuItemTitle"].ToString();
                txtParentName.Text = dt.Rows[0]["ParentName"].ToString();
                chkParent.Checked = Convert.ToBoolean(dt.Rows[0]["IsParent"]);
                chkReport.Checked = Convert.ToBoolean(dt.Rows[0]["IsReport"]);
                ButtonRights(false);
            }
        }

        private void DeleteMenu(int pMenuId)
        {

            try
            {
                MenuManager.DeleteMenu(pMenuId);
                MessageBox.Show("Menu Delete Successfully...", "Menu Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                try
                {

                    InsertMenu(txtMenuName.Text, txtParentName.Text, (string.IsNullOrEmpty(txtParentName.Text) ? 0 : 1), chkParent.Checked, chkReport.Checked);
                    MessageBox.Show("Menu Inserted Successfully...", "Menu Inserted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear();
                }
                catch (Exception ex)
                {

                }


            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                UpdateMenu(Convert.ToInt32(txtMenuId.Text), txtMenuName.Text, txtParentName.Text, (string.IsNullOrEmpty(txtParentName.Text) ? 0 : 1), chkParent.Checked, chkReport.Checked);
                MessageBox.Show("Menu Updated Successfully...", "Menu Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clear();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to Delete?", "Menu Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.No:
                    {
                        return;
                        break;
                    }
                case DialogResult.Yes:
                    {

                        DeleteMenu(Convert.ToInt32(txtMenuId.Text));
                        break;
                    }

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                frmSearch search = new frmSearch();
                search.getattributes("GetMenuSearch", null, "Menus");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    LoadMenuById(Convert.ToInt32(MainForm.Searched_Id));
                    MainForm.Searched_Id = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
