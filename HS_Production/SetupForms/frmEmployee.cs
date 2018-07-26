using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FIL.App_Code.EmployeeManager;
namespace FIL
{
    public partial class frmEmployee : Form
    {
        int EmployeeId = -1;
        EmployeeManager Employee = new EmployeeManager();
        public frmEmployee()
        {
            InitializeComponent();
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            try
            {
                SelectGender();
                SelectDepartment();
                SelectDesignation();
                cmbGender.SelectedIndex = 0;
                cmbDesignationId.SelectedIndex = 0;
                cmbDepartment.SelectedIndex = 0;
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
            txtEmployeeCode.ReadOnly = !Enable;
        }
        public void SelectGender()
        {
            cmbGender.DisplayMember = "Gender";
            cmbGender.ValueMember = "GenderId";
            var items = new[] { 
                new { Gender = "---Select---", GenderId = "0"},
                new { Gender = "Male", GenderId = "1" },
                new { Gender = "Female", GenderId = "2" }
            };
            cmbGender.DataSource = items;
        }

        public void SelectDepartment()
        {
            cmbDepartment.DisplayMember = "Department";
            cmbDepartment.ValueMember = "DepartmentId";
            var items = new[] { 
                new { Department = "---Select---", DepartmentId = "0"}
            };
            cmbDepartment.DataSource = items;
        }

        public void SelectDesignation()
        {
            cmbDesignationId.DisplayMember = "Designation";
            cmbDesignationId.ValueMember = "DesignationId";
            var items = new[] { 
                new { Designation = "---Select---", DesignationId = "0"}
            };
            cmbDesignationId.DataSource = items;
        }
        private void ClearFeilds()
        {
            cmbGender.SelectedIndex = 0;
            cmbDesignationId.SelectedIndex = 0;
            cmbDepartment.SelectedIndex = 0;
            txtEmployeeCode.Text = string.Empty;
            txtEmployeeName.Text = string.Empty;
            txtFatherName.Text = string.Empty;
            dTPHireDate.Text = string.Empty;
            txtNIC.Text = string.Empty; ;
            txtMaritalStatus.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtHomePhone.Text = string.Empty; ;
            txtCellPhone.Text = string.Empty;
            txtEmail.Text = string.Empty;
            dTPHireDate.Text = string.Empty;
            txtRemark.Text = string.Empty;
            txtPayrollId.Text = string.Empty;
            rdMontly.Checked = true;
            txtSalery.Text = "0";
            txtEmployeeCode.Focus();
            ButtonRights(true);
        }

        private bool Validation()
        {
            bool result = true;

            if (string.IsNullOrEmpty(txtEmployeeName.Text))
            {
                MessageBox.Show("Please Enter Employee Name", "Employee Name is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
                txtEmployeeName.Focus();
                return result;
            }


            return result;

        }

        private void LoadCustomer(int EmployeeId)
        {
            DataTable dtCustomer = Employee.GetEmployee(EmployeeId);
            if (dtCustomer.Rows.Count > 0)
            {
                txtEmployeeCode.Text = dtCustomer.Rows[0]["Code"].ToString();
                txtEmployeeName.Text = dtCustomer.Rows[0]["EmployeeName"].ToString();
                txtFatherName.Text = dtCustomer.Rows[0]["FatherName"].ToString();
                cmbDepartment.Text = dtCustomer.Rows[0]["DepartmentId"].ToString();
                cmbGender.Text = dtCustomer.Rows[0]["Gender"].ToString();
                dTPHireDate.Text = dtCustomer.Rows[0]["DOB"].ToString();
                txtNIC.Text = dtCustomer.Rows[0]["NIC"].ToString();
                txtMaritalStatus.Text = dtCustomer.Rows[0]["MaritalStatus"].ToString();
                txtAddress.Text = dtCustomer.Rows[0]["Address"].ToString();
                txtHomePhone.Text = dtCustomer.Rows[0]["HomePhone"].ToString();
                txtCellPhone.Text = dtCustomer.Rows[0]["CellPhone"].ToString();
                txtEmail.Text = dtCustomer.Rows[0]["Email"].ToString();
                dTPHireDate.Text = dtCustomer.Rows[0]["HireDate"].ToString();
                cmbDesignationId.Text = dtCustomer.Rows[0]["DesignationId"].ToString();
                txtRemark.Text = dtCustomer.Rows[0]["Remarks"].ToString();
                txtPayrollId.Text = dtCustomer.Rows[0]["PayrollId"].ToString();
                txtSalery.Text = dtCustomer.Rows[0]["Salery"].ToString();
                if (!string.IsNullOrEmpty(dtCustomer.Rows[0]["IsMontly"].ToString()))
                {
                    if (dtCustomer.Rows[0]["IsMontly"].ToString() == "1")
                    {
                        rdMontly.Checked = true;

                    }
                    else
                    {
                        rdPerDay.Checked = true;
                    }
                }
                else
                {
                    rdMontly.Checked = true;
                }

                ButtonRights(false);
            }
        }


        private int InsertEmployee(string EmployeeName, string FatherName, string DepartmentId, string Gender,
                                 DateTime DOB, string NIC, string MaritalStatus, string Address, string HomePhone, string CellPhone,
                                 string Email, DateTime HireDate, string DesignationId, string Remarks, int PayrollId, decimal Salery, bool IsMontly, int AddedBy, DateTime AddedOn,
                                 string AddedIpAddr)
        {
            EmployeeId = Employee.InsertEmployee(EmployeeName, FatherName, DepartmentId, Gender, DOB, NIC, MaritalStatus, Address, HomePhone, CellPhone, Email, HireDate, DesignationId, Remarks, PayrollId, Salery, IsMontly, AddedBy, AddedOn, AddedIpAddr);
            return EmployeeId;

        }

        private void UpdateEmployee(int EmployeeId, string EmployeeName, string FatherName, String DepartmentId, string Gender,
                                 DateTime DOB, string NIC, string MaritalStatus, string Address, string HomePhone, string CellPhone,
                                 string Email, DateTime HireDate, String DesignationId, string Remarks, int PayrollId, decimal Salery, bool IsMontly, int UpdatedBy, DateTime UpdatedOn, string UpdatedIpAddr)
        {
            Employee.UpdateEmployee(EmployeeId, EmployeeName, FatherName, DepartmentId, Gender, DOB, NIC, MaritalStatus, Address, HomePhone, CellPhone, Email, HireDate, DesignationId, Remarks, PayrollId, Salery, IsMontly, UpdatedBy, UpdatedOn, UpdatedIpAddr);
        }

        private void DeleteEmployee(string EmployeeId)
        {

            Employee.DeleteEmployee(EmployeeId);
            MessageBox.Show("Employee Record Deleted.", "Employee Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFeilds();
        }

        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                EmployeeId = InsertEmployee(txtEmployeeName.Text, txtFatherName.Text, cmbDepartment.Text, cmbGender.Text, Convert.ToDateTime(dTPDOB.Text), txtNIC.Text, txtMaritalStatus.Text, txtAddress.Text, txtHomePhone.Text, txtCellPhone.Text, txtEmail.Text, Convert.ToDateTime(dTPHireDate.Text), cmbDesignationId.Text, txtRemark.Text, (string.IsNullOrEmpty(txtPayrollId.Text) ? -1 : Convert.ToInt32(txtPayrollId.Text)), (string.IsNullOrEmpty(txtSalery.Text) ? -1 : Convert.ToDecimal(txtSalery.Text)), ((rdMontly.Checked) ? true : false), 0, DateTime.Now.Date, "0");
                MessageBox.Show("Employee Record Insert Successfull.", "Record Inserted.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (EmployeeId > 0)
                {
                    LoadCustomer(EmployeeId);
                }
                ClearFeilds();

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                UpdateEmployee(EmployeeId, txtEmployeeName.Text, txtFatherName.Text, cmbDepartment.Text, cmbGender.Text, Convert.ToDateTime(dTPDOB.Text), txtNIC.Text, txtMaritalStatus.Text, txtAddress.Text, txtHomePhone.Text, txtCellPhone.Text, txtEmail.Text, Convert.ToDateTime(dTPHireDate.Text), cmbDesignationId.Text, txtRemark.Text, (string.IsNullOrEmpty(txtPayrollId.Text) ? -1 : Convert.ToInt32(txtPayrollId.Text)), (string.IsNullOrEmpty(txtSalery.Text) ? -1 : Convert.ToDecimal(txtSalery.Text)), ((rdMontly.Checked) ? true : false), 0, DateTime.Now.Date, "0");
                MessageBox.Show("Employee Record Update Successfull.", "Employee Updated.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFeilds();
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to Delete", "Employee Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.No:
                    {
                        return;
                        break;
                    }
                case DialogResult.Yes:
                    {
                        DeleteEmployee(EmployeeId.ToString());
                        break;
                    }

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFeilds();
        }

        private void txtEmployeeCode_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEmployeeCode.Text))
            {
                EmployeeId = Employee.GetEmployeeIdByCode(txtEmployeeCode.Text);
                if (EmployeeId > 0)
                {
                    LoadCustomer(EmployeeId);
                }
            }
        }



        private void txtEmployeeCode_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEmployeeCode.Text))
            {
                EmployeeId = Employee.GetEmployeeIdByCode(txtEmployeeCode.Text);
                if (EmployeeId > 0)
                {
                    LoadCustomer(EmployeeId);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {

                frmSearch search = new frmSearch();
                search.getattributes("GetEmployeeSearch", null, "Employee");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtEmployeeCode.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                }
                else
                {
                    txtEmployeeCode.Text = string.Empty;
                    txtEmployeeCode.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtHomePhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmployeeCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                btnSearch.PerformClick();
            }
        }

        private void frmEmployee_KeyDown(object sender, KeyEventArgs e)
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

        Utility clsUtility = new Utility();
        private void txtPayrollId_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsUtility.setOnlyNumberic((TextBox)sender, false, e);
        }

        private void txtSalery_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsUtility.setOnlyNumberic((TextBox)sender, true, e);
        }



    }
}
