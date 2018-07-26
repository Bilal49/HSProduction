using FIL.App_Code.EmployeeManager;
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
    public partial class frmWarehouse : Form
    {
        int WarehouseId = -1;
        WarehouseManager manageWarehouse = new WarehouseManager();
        Utility clsUtility = new Utility();
        public frmWarehouse()
        {
            InitializeComponent();
        }
        private void frmProductSize_Load(object sender, EventArgs e)
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
            txtWarehouseId.ReadOnly = !Enable;
        }

        private void FillDropDown()
        {
            EmployeeManager manageEmployee = new EmployeeManager();
            DataTable dtEmployee = new DataTable();
            dtEmployee = manageEmployee.GetEmployeeList();

            DataRow drEmployee = dtEmployee.NewRow();
            drEmployee["EmployeeName"] = "--Select Employee Name--";
            drEmployee["EmployeeId"] = "-1";
            dtEmployee.Rows.InsertAt(drEmployee, 0);

            cmbEmployee.DataSource = dtEmployee;
            cmbEmployee.DisplayMember = "EmployeeName";
            cmbEmployee.ValueMember = "EmployeeId";
        }

        private void ClearFeilds()
        {
            txtWarehouseId.Text = string.Empty;
            txtName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtPhone.Text = string.Empty;
            chkStore.Checked = false; 
            cmbEmployee.SelectedIndex = 0;
            ButtonRights(true);
            txtName.Focus();
        }

        private bool Validation()
        {
            bool result = true;

            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Please Enter Warehouse Name.", "Warehouse Name is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
                txtName.Focus();
                return result;
            }


            return result;

        }

        private void LoadWarehouse(int WarehouseId)
        {
            DataTable dtWarehouse = manageWarehouse.GetWarehouse(WarehouseId); ;
            if (dtWarehouse.Rows.Count > 0)
            {
                txtWarehouseId.Text = dtWarehouse.Rows[0]["WarehouseId"].ToString();
                txtName.Text = dtWarehouse.Rows[0]["Name"].ToString();
                txtAddress.Text = dtWarehouse.Rows[0]["Address"].ToString();
                txtPhone.Text = dtWarehouse.Rows[0]["Phone"].ToString();
                cmbEmployee.SelectedValue = dtWarehouse.Rows[0]["Manager"].ToString();
                chkStore.Checked = Convert.ToBoolean(dtWarehouse.Rows[0]["IsStore"]);
                ButtonRights(false);
            }
        }


        private int InsertWarehouse(string Name, string Address, int Manager, string Email, string Fax, string Phone, bool IsStore, int AddedBy, DateTime AddedOn,
                                 string AddedIpAddr)
        {
            WarehouseId = manageWarehouse.InsertWarehouse( Name,  Address,  Manager,  Email,  Fax,  Phone,  IsStore,  AddedBy, AddedOn, AddedIpAddr);
            return WarehouseId;

        }

        private void UpdateWarehouse(int WarehouseId, string Name, string Address, int Manager, string Email, string Fax, string Phone, bool IsStore, int UpdatedBy, DateTime UpdatedOn, string UpdatedIpAddr)
        {
            manageWarehouse.UpdateWarehouse(WarehouseId, Name, Address, Manager, Email, Fax, Phone, IsStore, UpdatedBy, UpdatedOn, UpdatedIpAddr);
        }

        private void DeleteWarehouse(int WarehouseId)
        {
            int result = -1;
            result = manageWarehouse.DeleteWarehouse(WarehouseId);
            if (result > 0)
            {
                MessageBox.Show("Warehouse Delete Successfull.", "Warehouse Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFeilds();
            }
            else
            {
                MessageBox.Show("Warehouse Can't Deleted because some Refrence are in Use.", "Error While Delete Warehouse", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                WarehouseId = InsertWarehouse(txtName.Text,txtAddress.Text , Convert.ToInt32(cmbEmployee.SelectedValue), "" ,"", txtPhone.Text , chkStore.Checked , MainForm.User_Id , DateTime.Now.Date, "0");
                if (WarehouseId > 0)
                {
                    MessageBox.Show("Warehouse Insert Successfull.", "Record Inserted.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFeilds();
                }
                

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                UpdateWarehouse(WarehouseId, txtName.Text, txtAddress.Text, Convert.ToInt32(cmbEmployee.SelectedValue), "", "", txtPhone.Text, chkStore.Checked , MainForm.User_Id, DateTime.Now.Date, "0");
                MessageBox.Show("Product Size Update Successfull.", "ProductSize Updated.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFeilds();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFeilds();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to Delete it?", "Warehouse Delete.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.No:
                    {
                        return;
                        break;
                    }
                case DialogResult.Yes:
                    {
                        DeleteWarehouse(WarehouseId);
                        break;
                    }

            }
        }

        private void txtWarehouseId_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtWarehouseId.Text))
            {
                WarehouseId = manageWarehouse.GetWarehouseIdIdByCode(Convert.ToInt32(txtWarehouseId.Text));
                if (WarehouseId > 0)
                {
                    LoadWarehouse(WarehouseId);
                }
            }
        }

        //private void txtWarehouseId_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        SendKeys.Send("{TAB}");
        //    }
        //}

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                frmSearch search = new frmSearch();
                search.getattributes("GetWarehouseSearch", null, "Warehouse");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtWarehouseId.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //private void txtWarehouseId_Leave(object sender, EventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(txtWarehouseId.Text))
        //    {
        //        WarehouseId = ProductSize.GetProductWarehouseIdByCode(Convert.ToInt32(txtWarehouseId.Text));
        //        if (WarehouseId > 0)
        //        {
        //            LoadProductSize(WarehouseId);
        //        }
        //    }
        //}

        private void frmWarehouse_KeyDown(object sender, KeyEventArgs e)
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
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }


        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsUtility.setOnlyNumberic((TextBox)sender, false, e);
        }

        


    }
}
