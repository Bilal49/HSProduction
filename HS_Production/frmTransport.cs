using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using RiceMill.App_Code.TransportManager;

namespace FIL
{
    public partial class frmTransport : Form
    {
        int TransportId = -1;
        TransportManager Transport = new TransportManager();
        public frmTransport()
        {
            InitializeComponent();
        }

        private void frmTransport_Load(object sender, EventArgs e)
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
            txtTransportId.ReadOnly = !Enable;
        }

        private void ClearFeilds()
        {
            txtTransportId.Text = string.Empty;
            txtTransportName.Text = string.Empty;
            ButtonRights(true);
        }

        private bool Validation()
        {
            bool result = true;

            if (string.IsNullOrEmpty(txtTransportName.Text))
            {
                MessageBox.Show("Please Enter Transport Name.", "Transport Name is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
                txtTransportName.Focus();
                return result;
            }


            return result;

        }

        private void LoadTransport(int TransportId)
        {
            DataTable dtProductCategory = Transport.GetTransport(TransportId); ;
            if (dtProductCategory.Rows.Count > 0)
            {
                txtTransportId.Text = dtProductCategory.Rows[0]["TransportId"].ToString();
                txtTransportName.Text = dtProductCategory.Rows[0]["TransportName"].ToString();
                ButtonRights(false);
            }
        }


        private int InsertTransport(string TransportName, int AddedBy, DateTime AddedOn,
                                 string AddedIpAddr)
        {
            TransportId = Transport.InsertTransport(TransportName, AddedBy, AddedOn, AddedIpAddr);
            return TransportId;

        }

        private void UpdateTransport(int CityId, string CityName, int UpdatedBy, DateTime UpdatedOn, string UpdatedIpAddr)
        {
            Transport.UpdateTransport(CityId, CityName, UpdatedBy, UpdatedOn, UpdatedIpAddr);
        }

        private void DeleteTransport(string CityId)
        {

            Transport.DeleteTransport(CityId);
            MessageBox.Show("Transport Record Delete Susscefull.", "Transport Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFeilds();
        }

        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                TransportId = InsertTransport(txtTransportName.Text, 0, DateTime.Now.Date, "0");
                MessageBox.Show("Transport Record Insert Sucessfull.", "Transport Inserted.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (TransportId > 0)
                {
                    LoadTransport(TransportId);
                }
                ClearFeilds();

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                UpdateTransport(TransportId, txtTransportName.Text, 0, DateTime.Now.Date, "0");
                MessageBox.Show("Transport Record Update Successfull.", "Transport Updated.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFeilds();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFeilds();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to Delete it?", "Transport Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.No:
                    {
                        return;
                        break;
                    }
                case DialogResult.Yes:
                    {
                        DeleteTransport(TransportId.ToString());
                        break;
                    }

            }
        }

        private void txtTransportId_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTransportId.Text))
            {
                TransportId = Transport.GetTransportIdById(Convert.ToInt32(txtTransportId.Text));
                if (TransportId > 0)
                {
                    LoadTransport(TransportId);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {

                frmSearch search = new frmSearch();
                search.getattributes("GetTransportSearch", null, "Transport");
                search.ShowDialog();
                if (!string.IsNullOrEmpty(MainForm.Searched_Id))
                {
                    txtTransportId.Text = MainForm.Searched_Id;
                    MainForm.Searched_Id = string.Empty;
                }
                else
                {
                    txtTransportId.Text = string.Empty;
                    txtTransportId.Focus();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtTransportId_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTransportId.Text))
            {
                TransportId = Transport.GetTransportIdById(Convert.ToInt32(txtTransportId.Text));
                if (TransportId > 0)
                {
                    LoadTransport(TransportId);
                }
            }
        }

        private void txtTransportId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void frmTransport_KeyDown(object sender, KeyEventArgs e)
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
