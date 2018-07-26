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
    public partial class frmLogin : Form
    {

        private Dropshadow shadow;
        RememberCache clsRemember = new RememberCache();
        public static string _ConnectionString = ConfigurationManager.ConnectionStrings["HSConnectionString"].ConnectionString;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            FormLoadShadow();
            try
            {
                GetRememberInfo();
            }
            catch (Exception ex)
            { 
            }
            
        }

        #region Shadow Works
        private void FormLoadShadow()
        {
            try
            {
                Width = this.Width + 20;
                Height = this.Height + 20;
                if (!DesignMode)
                {
                    shadow = new Dropshadow(this)
                    {
                        ShadowBlur = 16,
                        ShadowSpread = -10,
                        ShadowColor = Color.FromArgb(141, 206, 252), //Color.Black,
                        ShadowV = 0,
                        ShadowH = 0
                    };
                    shadow.RefreshShadow();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        private void GetRememberInfo()
        {
            if (clsRemember.GetSessionValue("loginremember") == "true")
            {
                txtUser.Text = clsRemember.GetSessionValue("loginUser");
                txtPassword.Text = clsRemember.GetSessionValue("loginUserPass");
                chkRemember.Checked = true;
                btnLogin.Focus();
            }
            else
            {
                txtUser.Text = string.Empty;
                txtPassword.Text = string.Empty;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to Exit?", "Application Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.Cancel:
                    {
                        return;
                    }
            }
            if (shadow != null)
            {
                shadow.Dispose();
                shadow = null;
            }
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                Login();
            }
        }

        private bool Validation()
        {
            bool result = true;

            if (string.IsNullOrEmpty(txtUser.Text))
            {
                MessageBox.Show("Please Enter User Name.", "User Name is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUser.Focus();
                result = false;
                return result;
            }

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please Enter User's Password", "User's Password is Required.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                result = false;
                return result;
            }
            return result;
        }

        private void Login()
        {
            DataTable dt;
            UserManager user = new UserManager();
            dt = user.GetUserName(txtUser.Text, txtPassword.Text);
            if (dt.Rows.Count == 0)
            {
                lblMessage.Visible = true;
            }
            else
            {
                if (chkRemember.Checked)
                {
                    try
                    {
                        clsRemember.SetSessionValue("loginremember", "true");
                        clsRemember.SetSessionValue("loginUser", txtUser.Text);
                        clsRemember.SetSessionValue("loginUserPass", txtPassword.Text);
                    }
                    catch (Exception ex)
                    { 
                    }
                    
                }
                else
                {
                    try
                    {
                        clsRemember.SetSessionValue("loginremember", "false");
                        clsRemember.SetSessionValue("loginUser", string.Empty);
                        clsRemember.SetSessionValue("loginUserPass", string.Empty);
                    }
                    catch (Exception ex)
                    { 
                    }
                    
                }

                if (user.ApplicationExpire())
                {
                    MessageBox.Show("Application has been Expire" + Environment.NewLine + "Please Contact with Handsome Solution to renew your version", "Application Duration Expire.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                MainForm main = new MainForm(dt);
                MainForm.User_Id = (int)dt.Rows[0]["UserId"];
                main.Text = "Welcome To General Shop System";
                if (shadow != null)
                {
                    shadow.Dispose();
                    shadow = null;
                }
                this.Hide();
                main.Show();

            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }

        private void btnConnection_Click(object sender, EventArgs e)
        {
            frmConnection connection = new frmConnection();
            connection.ShowDialog();
        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
    }
}
