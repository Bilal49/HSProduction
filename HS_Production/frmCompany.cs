using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FIL.App_Code.CompanyManager;
using System.IO;

namespace FIL
{
    public partial class frmCompany : Form
    {
        public frmCompany()
        {
            InitializeComponent();
        }
        CompanyManager CM = new CompanyManager();
        string ImageFilePath = string.Empty;
        private void frmCompany_Load(object sender, EventArgs e)
        {
            GetCampanyData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Please Enter Company Name.", "Company Name is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CM.InsertUpdateCampony(txtName.Text, txtAddress.Text, txtPhoneNo.Text, txtFax.Text, txtEmail.Text,
            txtContactPerson.Text, txtGSTNo.Text, txtNTN.Text, txtDescription.Text, ImageFilePath, 0, DateTime.Now.Date, "0");
            MessageBox.Show("Company Record Updated Successfull.", "Record Updated.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GetCampanyData();
        }

        public void GetCampanyData()
        {
            DataTable dt = CM.GetCompany();
            if (dt.Rows.Count > 0)
            {
                txtName.Text = dt.Rows[0]["Name"].ToString();
                txtAddress.Text = dt.Rows[0]["Address"].ToString();
                txtPhoneNo.Text = dt.Rows[0]["Phone"].ToString();
                txtFax.Text = dt.Rows[0]["Fax"].ToString();
                txtEmail.Text = dt.Rows[0]["Email"].ToString();
                txtContactPerson.Text = dt.Rows[0]["ContactPerson"].ToString();
                txtGSTNo.Text = dt.Rows[0]["GSTNumber"].ToString();
                txtNTN.Text = dt.Rows[0]["NTN"].ToString();
                txtDescription.Text = dt.Rows[0]["Description"].ToString();
                ImageFilePath = dt.Rows[0]["CompanyLogo"].ToString();
                if (!string.IsNullOrEmpty(ImageFilePath))
                {
                    if (File.Exists(ImageFilePath))
                    {
                        pbCampany.Image = new Bitmap(ImageFilePath);
                    }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog OD = new OpenFileDialog();
            OD.Filter = "jpg files (*.jpg)|*.jpg|png files (*.png)|*.png"; //"*.png || *.jgp || *.jpeg || *.bmp";
            OD.Multiselect = false;
            if (OD.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string iName = Application.StartupPath + "\\CompanyLogo.jpg";
                    string filepath = OD.FileName;

                    if (File.Exists(iName))
                    {
                        File.Delete(iName);
                    }
                    File.Copy(filepath, iName);
                    pbCampany.Image = new Bitmap(OD.OpenFile());
                    ImageFilePath = iName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }
    }
}
