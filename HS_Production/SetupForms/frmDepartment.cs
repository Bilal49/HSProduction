//using RiceMill.App_Code.DepartmentManager;
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
    public partial class frmDepartment : Form
    {
        int DepartmentId = -1;
        DepartmentManager Department = new DepartmentManager();
        public frmDepartment()
        {
            InitializeComponent();
        }

        private void frmDepartment_Load(object sender, EventArgs e)
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
            txtDepartmentId.ReadOnly = !Enable;
        }

        private void ClearFeilds()
        {
            txtDepartmentId.Text = string.Empty;
            txtDepartmentName.Text = string.Empty;
            ButtonRights(true);
        }

        private bool Validation()
        {
            bool result = true;

            if (string.IsNullOrEmpty(txtDepartmentName.Text))
            {
                MessageBox.Show("Please Enter Department Name", "Department Name Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
                txtDepartmentName.Focus();
                return result;
            }


            return result;

        }

        private void LoadDepartment(int DepartmentId)
        {
            DataTable dtProductCategory = Department.GetDepartment(DepartmentId); ;
            if (dtProductCategory.Rows.Count > 0)
            {
                txtDepartmentId.Text = dtProductCategory.Rows[0]["DepartmentId"].ToString();
                txtDepartmentName.Text = dtProductCategory.Rows[0]["DepartmentName"].ToString();
                ButtonRights(false);
            }
        }


        private int InsertDepartment(string DepartmentName, int AddedBy, DateTime AddedOn,
                                 string AddedIpAddr)
        {
            DepartmentId = Department.InsertDepartment(DepartmentName, AddedBy, AddedOn, AddedIpAddr);
            return DepartmentId;

        }

        private void UpdateDepartment(int DepartmentId, string DepartmentName, int UpdatedBy, DateTime UpdatedOn, string UpdatedIpAddr)
        {
            Department.UpdateDepartment(DepartmentId, DepartmentName, UpdatedBy, UpdatedOn, UpdatedIpAddr);
        }

        private void DeleteDepartment(string DepartmentId)
        {

            Department.DeleteDepartment(DepartmentId);
            MessageBox.Show("Department Record Delete Successfull.", "Department Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFeilds();
        }

        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                DepartmentId = InsertDepartment(txtDepartmentName.Text, MainForm.User_Id , DateTime.Now.Date, "");
                MessageBox.Show("Department Record Inserted.", "Record Inserted.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (DepartmentId > 0)
                {
                    LoadDepartment(DepartmentId);
                }
                ClearFeilds();

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                UpdateDepartment(DepartmentId, txtDepartmentName.Text, 0, DateTime.Now.Date, "0");
                MessageBox.Show("Department Record Update", "Department Updated.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFeilds();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFeilds();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to Delete it?", "Department Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.No:
                    {
                        return;
                        break;
                    }
                case DialogResult.Yes:
                    {
                        DeleteDepartment(DepartmentId.ToString());
                        break;
                    }

            }
        }

        private void txtDepartmentId_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDepartmentId.Text))
            {
                DepartmentId = Department.GetDepartmentIdById(Convert.ToInt32(txtDepartmentId.Text));
                if (DepartmentId > 0)
                {
                    LoadDepartment(DepartmentId);
                }
            }
        }

        private void txtDepartmentId_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDepartmentId.Text))
            {
                DepartmentId = Department.GetDepartmentIdById(Convert.ToInt32(txtDepartmentId.Text));
                if (DepartmentId > 0)
                {
                    LoadDepartment(DepartmentId);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {

                frmSearch search = new frmSearch();
                search.getattributes("GetDepartmentSearch", null, "Department");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtDepartmentId.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                }
                else
                {
                    txtDepartmentId.Text = string.Empty;
                    txtDepartmentId.Focus();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtDepartmentId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void frmDepartment_KeyDown(object sender, KeyEventArgs e)
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
