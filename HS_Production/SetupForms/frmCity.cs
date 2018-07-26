//using RiceMill.App_Code.CityManager;
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
    public partial class frmCity : Form
    {
        int CityId = -1;
        CityManager City = new CityManager();
        public frmCity()
        {
            InitializeComponent();
        }

        private void frmCity_Load(object sender, EventArgs e)
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
            txtCityId.ReadOnly = !Enable;
        }

        private void ClearFeilds()
        {
            txtCityId.Text = string.Empty;
            txtCityName.Text = string.Empty;
            ButtonRights(true);
        }

        private bool Validation()
        {
            bool result = true;

            if (string.IsNullOrEmpty(txtCityName.Text))
            {
                MessageBox.Show("Please Enter City Name", "City Name Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
                txtCityName.Focus();
                return result;
            }


            return result;

        }

        private void LoadCity(int CityId)
        {
            DataTable dtProductCategory = City.GetCity(CityId); ;
            if (dtProductCategory.Rows.Count > 0)
            {
                txtCityId.Text = dtProductCategory.Rows[0]["CityId"].ToString();
                txtCityName.Text = dtProductCategory.Rows[0]["CityName"].ToString();
                ButtonRights(false);
            }
        }


        private int InsertCity(string CityName, int AddedBy, DateTime AddedOn,
                                 string AddedIpAddr)
        {
            CityId = City.InsertCity(CityName, AddedBy, AddedOn, AddedIpAddr);
            return CityId;

        }

        private void UpdateCity(int CityId, string CityName, int UpdatedBy, DateTime UpdatedOn, string UpdatedIpAddr)
        {
            City.UpdateCity(CityId, CityName, UpdatedBy, UpdatedOn, UpdatedIpAddr);
        }

        private void DeleteCity(string CityId)
        {

            City.DeleteCity(CityId);
            MessageBox.Show("City Record Delete Successfull.", "City Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFeilds();
        }

        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                CityId = InsertCity(txtCityName.Text, 0, DateTime.Now.Date, "0");
                MessageBox.Show("City Record Inserted.", "Record Inserted.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (CityId > 0)
                {
                    LoadCity(CityId);
                }
                ClearFeilds();

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                UpdateCity(CityId, txtCityName.Text, 0, DateTime.Now.Date, "0");
                MessageBox.Show("City Record Update", "City Updated.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFeilds();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFeilds();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to Delete it?", "City Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.No:
                    {
                        return;
                        break;
                    }
                case DialogResult.Yes:
                    {
                        DeleteCity(CityId.ToString());
                        break;
                    }

            }
        }

        private void txtCityId_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCityId.Text))
            {
                CityId = City.GetCityIdById(Convert.ToInt32(txtCityId.Text));
                if (CityId > 0)
                {
                    LoadCity(CityId);
                }
            }
        }

        private void txtCityId_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCityId.Text))
            {
                CityId = City.GetCityIdById(Convert.ToInt32(txtCityId.Text));
                if (CityId > 0)
                {
                    LoadCity(CityId);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {

                frmSearch search = new frmSearch();
                search.getattributes("GetCitySearch", null, "City");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtCityId.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                }
                else
                {
                    txtCityId.Text = string.Empty;
                    txtCityId.Focus();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtCityId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void frmCity_KeyDown(object sender, KeyEventArgs e)
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
