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
    public partial class frmUser : Form
    {

        int UserId = -1;
        public frmUser()
        {
            InitializeComponent();
        }

        private void frmArea_Load(object sender, EventArgs e)
        {
            try
            {
                FillDropDown();
                ButtonRights(true);
            }
            catch (Exception ex)
            {

            }
        }

        #region Methods


        private void FillDropDown()
        {
            RoleManager rolemanager = new RoleManager();
            DataTable dtRoles = rolemanager.GetAllRoles();
            if (dtRoles.Rows.Count > 0)
            {
                DataRow dr = dtRoles.NewRow();
                dr["TypeId"] = -1;
                dr["Type"] = "---Select Role---";
                dtRoles.Rows.InsertAt(dr, 0);
                cmbRoles.DataSource = dtRoles;
                cmbRoles.DisplayMember = "Type";
                cmbRoles.ValueMember = "TypeId";
            }

           
           


        }

        private void clear()
        {
            txtUserName.Text = string.Empty;
            txtUserPass.Text = string.Empty;
           
            txtName.Text = string.Empty;
            cmbRoles.SelectedIndex = 0;
            
            chkActive.Checked = true;
            UserId = -1;
            txtUserName.ReadOnly = false;
            ButtonRights(true);
        }

        private void ButtonRights(bool Enable)
        {
            btnAdd.Enabled = Enable;
            btnUpdate.Enabled = !Enable;
            btnDelete.Enabled = !Enable;

        }

        private bool Validation()
        {
            bool result = true;


            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                MessageBox.Show("Please Enter User", "User is Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUserName.Focus();
                result = false;
                return result;
            }


            if (string.IsNullOrEmpty(txtUserPass.Text))
            {
                MessageBox.Show("Please Enter User Password", "User Password is Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUserPass.Focus();
                result = false;
                return result;
            }


            if (cmbRoles.SelectedIndex <= 0)
            {
                MessageBox.Show("Please Select Role Name", "Role Name is Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUserName.Focus();
                result = false;
                return result;
            }

            

            return result;
        }

        private int InsertUser(string UserName, string Password, string Name, int RoleId, string EmailAddress, int EmployeeId, bool IsActive, int DistributorId, byte[] UserImage = null)
        {
            UserManager UserManager = new UserManager();
            UserId = UserManager.InsertUserMaster(UserName,  Password,  Name,  RoleId,  !IsActive );
            return UserId;
            
        }

        private void UpdateUser(int UserId, string UserName, string Password, string Name, int RoleId, string EmailAddress, int EmployeeId, bool IsActive, int DistributorId, byte[] UserImage = null)
        {
            UserManager UserManager = new UserManager();
            UserManager.UpdateUserMaster( UserId,  UserName,  Password,  Name,  RoleId,   !IsActive  );
        }

       

        private void LoadUserById(int pUserId)
        {
            UserManager UserManager = new UserManager();
            DataTable dt = new DataTable();
            dt = UserManager.GetUsersById(pUserId);
            if (dt.Rows.Count > 0)
            {
                txtUserName.Text = dt.Rows[0]["UserName"].ToString();
                txtUserName.ReadOnly = true; // User Name change nh ho sakta.
                txtUserPass.Text = UserManager.Decrypt(dt.Rows[0]["Password"].ToString());
                txtName.Text = dt.Rows[0]["Name"].ToString();
                cmbRoles.SelectedValue = dt.Rows[0]["UserType"];
               
                UserId = pUserId;
                ButtonRights(false);
            }
        }

        private void DeleteUser(int pUserId)
        {
            UserManager UserManager = new UserManager();
            UserManager.DeleteUserId(pUserId);
            MessageBox.Show("User Delete Successfully...", "User Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            clear();
        }


        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                try
                {
                    UserManager UM = new UserManager();
                    DataTable dt =  UM.GetUserByName(txtUserName.Text.ToString().Trim().ToLower());
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("User ' "+ txtUserName.Text +" ' alredy exists in System. Please enter different User Name.", "User Name Must be Unique", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    InsertUser(txtUserName.Text, txtUserPass.Text, txtName.Text, Convert.ToInt32(cmbRoles.SelectedValue), "", -1, chkActive.Checked, -1);
                    MessageBox.Show("User Added Successfully...", "User Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
               
                UpdateUser(UserId, txtUserName.Text, txtUserPass.Text, txtName.Text, Convert.ToInt32(cmbRoles.SelectedValue), "", -1, chkActive.Checked, -1);
                MessageBox.Show("User Updated Successfully...", "User Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clear();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to Delete?", "User Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.No:
                    {
                        return;
                        break;
                    }
                case DialogResult.Yes:
                    {

                        DeleteUser(UserId);
                        break;
                    }

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {

                frmSearch search = new frmSearch();
                search.getattributes("sp_GetUserSearch", null, "User");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    LoadUserById(Convert.ToInt32(MainForm.Searched_Id));
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
