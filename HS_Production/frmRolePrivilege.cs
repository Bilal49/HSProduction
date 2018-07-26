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
    public partial class frmRolePrivilege : Form
    {


        
        int RoleId = -1;
        public frmRolePrivilege()
        {
            InitializeComponent();
        }

        private void frmArea_Load(object sender, EventArgs e)
        {
            try
            {
                
                ButtonRights(false);
            }
            catch (Exception ex)
            {

            }
        }

        #region Methods

        private void clear()
        {
            RoleId = -1;
            txtRoleName.Text = string.Empty;
            dtPrivilege.Rows.Clear();
            ButtonRights(false);

        }

        private void ButtonRights(bool Enable)
        {
            //btnAdd.Enabled = Enable;
            btnUpdate.Enabled = !Enable;
            //btnDelete.Enabled = !Enable;
            
        }

        private bool Validation()
        {
            bool result = true;

            if (gvPrivilege.Rows.Count == 0)
            {
                MessageBox.Show("Please Select Role Name. Detail Not Found", "Role Name is Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRoleName.Focus();
                result = false;
                return result;
            }
            

            return result;
        }

        


        #endregion

        

       
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {

                frmSearch search = new frmSearch();
                search.getattributes("UserRolesSearch", null, "User Role");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    RoleId = Convert.ToInt32(MainForm.Searched_Id);
                    LoadMenuById(Convert.ToInt32(MainForm.Searched_Id));
                    MainForm.Searched_Id = string.Empty;
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        DataTable dtPrivilege = new DataTable();
        private void LoadMenuById(int RoleId)
        {
            RolePrivilegeManager PrivilegeManager = new RolePrivilegeManager();
            RoleManager Roles = new RoleManager();
            DataTable dtRoles = Roles.GetRolesById(RoleId);
            txtRoleName.Text = dtRoles.Rows[0]["Type"].ToString();
            dtPrivilege = PrivilegeManager.GetRolePrivilege(RoleId);
            if (dtPrivilege.Rows.Count > 0)
            {
                gvPrivilege.DataSource = dtPrivilege;
            }

                //GetRolePrivilege
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

            clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            RolePrivilegeManager PrivilegeManager = new RolePrivilegeManager();
            bool isAllEmpty = false;
            bool isAllowEmpty = false;
            for (int i = 0; i < gvPrivilege.Rows.Count; i++)
            
            
            {
                bool chkAllow = (bool)gvPrivilege.Rows[i].Cells["Privilege_Allow"].Value;
                bool chkAdd = (bool)gvPrivilege.Rows[i].Cells["Privilege_Add"].Value;
                bool chkEdit = (bool)gvPrivilege.Rows[i].Cells["Privilege_Edit"].Value;
                bool chkDelete = (bool)gvPrivilege.Rows[i].Cells["Privilege_Delete"].Value;
                bool chkPost = (bool)gvPrivilege.Rows[i].Cells["Privilege_Post"].Value;


                int privilegeId = (int)gvPrivilege.Rows[i].Cells["Privilege_Id"].Value;
                int Id = (int)gvPrivilege.Rows[i].Cells["Menu_Id"].Value;

                if (privilegeId > 0)
                {
                    if (chkAllow)
                    {
                        PrivilegeManager.UpdateRolePrivilege(privilegeId, chkAllow, chkAdd, chkEdit, chkDelete, chkPost);
                    }

                    else
                    {
                        PrivilegeManager.DeleteRolePrivilege(privilegeId);
                    }

                    isAllEmpty = true;
                }

                else
                {
                    if (chkAllow)
                    {
                        isAllEmpty = true;
                        PrivilegeManager.InsertRolePrivilege(RoleId, Id, chkAllow, chkAdd, chkEdit, chkDelete, chkPost);
                    }

                    else if (chkAdd || chkEdit || chkDelete || chkPost)
                    {

                        isAllowEmpty = true;
                        break;
                        

                    }
                }
            }
            MessageBox.Show("Role Updated Successfully...", "Role Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            clear();

            ////////if (isAllowEmpty)
            ////////{
            ////////    FillDefaultGrId();
            ////////    panel.Visible = true;
            ////////    lbl_Msg.Text = "Select check allow to assign menu.";
            ////////}
            ////////else
            ////////{
            ////////    if (isAllEmpty)
            ////////    {
            ////////        Response.Redirect("~/ManageRolePrivilege.aspx");
            ////////    }

            ////////    else
            ////////    {
            ////////        FillDefaultGrId();
            ////////        panel.Visible = true;
            ////////        lbl_Msg.Text = "Select atleast one menu.";


            ////////    }
            ////////}
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked)
            {
                if (dtPrivilege.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtPrivilege.Rows)
                    {
                        dr["Privilege_Allow"] = true;
                        dr["Privilege_Add"] = true;
                        dr["Privilege_Edit"] = true;
                        dr["Privilege_Delete"] = true;
                        dr["Privilege_Post"] = true;

                    }
                }
            }
            else
            {
                if (dtPrivilege.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtPrivilege.Rows)
                    {
                        dr["Privilege_Allow"] = false;
                        dr["Privilege_Add"] = false;
                        dr["Privilege_Edit"] = false;
                        dr["Privilege_Delete"] = false;
                        dr["Privilege_Post"] = false;

                    }
                }
 
            }
        }

        private void gvPrivilege_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                {
                    return;
                }
                DataGridViewRow dgv = gvPrivilege.Rows[e.RowIndex];
                string columnsName = gvPrivilege.Columns[e.ColumnIndex].Name;
                if (columnsName == "Privilege_Allow")
                {
                    if (Convert.ToBoolean(dgv.Cells["Privilege_Allow"].Value))
                    {
                        dgv.Cells["Privilege_Add"].Value = true;
                        dgv.Cells["Privilege_Edit"].Value = true;
                        dgv.Cells["Privilege_Delete"].Value = true;
                        dgv.Cells["Privilege_Post"].Value = true;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
