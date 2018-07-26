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
    public partial class frmUserType : Form
    {


        
        RoleManager RoleManager = new RoleManager();
        public frmUserType()
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
            txtRoleId.Text = string.Empty;
            txtRoleName.Text = string.Empty;
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

            if (string.IsNullOrEmpty(txtRoleName.Text))
            {
                MessageBox.Show("Please Enter Role Name", "Role Name is Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRoleId.Focus();
                result = false;
                return result;
            }
            

            return result;
        }

        private int InsertRole(string RoleName)
        {
            int RoleId = RoleManager.InsertRole(RoleName);
            return RoleId;
        }

        private void UpdateRole(int RoleId, string RoleName)
        {
            RoleManager.UpdateRole(RoleId, RoleName);
        }

        private void LoadRoleById(int pRoleId)
        {   
            
            DataTable dt = new DataTable();
            dt = RoleManager.GetRolesById(pRoleId);
            if (dt.Rows.Count > 0)
            {
                txtRoleId.Text = dt.Rows[0]["TypeId"].ToString();
                txtRoleName.Text = dt.Rows[0]["Type"].ToString();
                ButtonRights(false);
            }
        }

        private void DeleteRole(int pRoleId)
        {

            RoleManager.DeleteRole(pRoleId);
            MessageBox.Show("Role Delete Successfully...", "Role Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            clear();
        }


        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                try
                {
                    InsertRole(txtRoleName.Text);
                    MessageBox.Show("Role Inserted Successfully...", "Role Inserted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear();
                }
                catch(Exception ex)
                {

                }
               

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                UpdateRole(Convert.ToInt32(txtRoleId.Text), txtRoleName.Text);
                MessageBox.Show("Role Updated Successfully...", "Role Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clear();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to Delete?", "Role Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.No:
                    {
                        return;
                        break;
                    }
                case DialogResult.Yes:
                    {

                        DeleteRole(Convert.ToInt32(txtRoleId.Text));
                        break;
                    }

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                frmSearch search = new frmSearch();
                search.getattributes("UserRolesSearch", null, "User Role");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    LoadRoleById(Convert.ToInt32(MainForm.Searched_Id));
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
