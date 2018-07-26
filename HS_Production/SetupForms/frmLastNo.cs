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
    public partial class frmLastNo : Form
    {
        int LastNoId = -1;
        LastNoManager manageLastNo = new LastNoManager();
        public frmLastNo()
        {
            InitializeComponent();
        }

        private void frmLastNo_Load(object sender, EventArgs e)
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
            txtLastNoId.ReadOnly = !Enable;
        }

        private void ClearFeilds()
        {
            txtLastNoId.Text = string.Empty;
            txtLastNo.Text = string.Empty;
            ButtonRights(true);
            txtLastNo.Focus();
        }

        private bool Validation()
        {
            bool result = true;

            if (string.IsNullOrEmpty(txtLastNo.Text))
            {
                MessageBox.Show("Please Enter LastNo", "LastNo Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
                txtLastNo.Focus();
                return result;
            }


            return result;

        }

        private void LoadLastNo(int LastNoId)
        {
            DataTable dtProductCategory = manageLastNo.GetLastNo(LastNoId); ;
            if (dtProductCategory.Rows.Count > 0)
            {
                txtLastNoId.Text = dtProductCategory.Rows[0]["LastNoId"].ToString();
                txtLastNo.Text = dtProductCategory.Rows[0]["LastNo"].ToString();
                ButtonRights(false);
            }
        }


        private int InsertLastNo(string LastNo, int AddedBy, DateTime AddedOn,
                                 string AddedIpAddr)
        {
            LastNoId = manageLastNo.InsertLastNo(LastNo, AddedBy, AddedOn, AddedIpAddr);
            return LastNoId;

        }

        private void UpdateLastNo(int LastNoId, string LastNo, int UpdatedBy, DateTime UpdatedOn, string UpdatedIpAddr)
        {
            manageLastNo.UpdateLastNo(LastNoId, LastNo, UpdatedBy, UpdatedOn, UpdatedIpAddr);
        }

        private void DeleteLastNo(string LastNoId)
        {

            manageLastNo.DeleteLastNo(LastNoId);
            MessageBox.Show("LastNo Record Delete Successfull.", "LastNo Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFeilds();
        }

        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                LastNoId = InsertLastNo(txtLastNo.Text, MainForm.User_Id , DateTime.Now.Date, "0");
                MessageBox.Show("LastNo Record Inserted.", "Record Inserted.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (LastNoId > 0)
                {
                    LoadLastNo(LastNoId);
                }
                ClearFeilds();

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                UpdateLastNo(LastNoId, txtLastNo.Text, MainForm.User_Id , DateTime.Now.Date, "0");
                MessageBox.Show("LastNo Record Update", "LastNo Updated.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFeilds();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFeilds();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to Delete it?", "LastNo Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.No:
                    {
                        return;
                        break;
                    }
                case DialogResult.Yes:
                    {
                        DeleteLastNo(LastNoId.ToString());
                        break;
                    }

            }
        }

        private void txtLastNoId_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtLastNoId.Text))
            {
                LastNoId = manageLastNo.GetLastNoIdById(Convert.ToInt32(txtLastNoId.Text));
                if (LastNoId > 0)
                {
                    LoadLastNo(LastNoId);
                }
            }
        }

        private void txtLastNoId_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtLastNoId.Text))
            {
                LastNoId = manageLastNo.GetLastNoIdById(Convert.ToInt32(txtLastNoId.Text));
                if (LastNoId > 0)
                {
                    LoadLastNo(LastNoId);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {

                frmSearch search = new frmSearch();
                search.getattributes("GetLastNoSearch", null, "LastNo");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtLastNoId.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                }
                else
                {
                    txtLastNoId.Text = string.Empty;
                    txtLastNoId.Focus();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtLastNoId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void frmLastNo_KeyDown(object sender, KeyEventArgs e)
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
