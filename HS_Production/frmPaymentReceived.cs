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


    public partial class frmPaymentReceived : Form
    {
        private Dropshadow shadow;
       Decimal NetAmount = 0;
       public Decimal CashReceived = 0;
       public Decimal CashBack = 0;
       public frmPaymentReceived(decimal NetAmount )
        {
            InitializeComponent();
            this.NetAmount = NetAmount;
            
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
                       ShadowBlur = 20,
                       ShadowSpread = -13,
                       ShadowColor = Color.WhiteSmoke, //Color.FromArgb(245, 159, 182), //Color.Black,
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
       private void frmPaymentReceived_Load(object sender, EventArgs e)
        {
            FormLoadShadow();
            lblTotalAmount.Text = NetAmount.ToString();
            txtCashReceived.Text = CashReceived.ToString();
            lblCashBack.Text = CashBack.ToString();
        }
       private void btnSave_Click(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(lblCashBack.Text) < 0)
            {
                lblError.Text = "Amount Should be equal or greater then Total Amount";
                lblError.Visible = true;    
                return;
            }
            if (Convert.ToDecimal(lblTotalAmount.Text) > Convert.ToDecimal(txtCashReceived.Text))
            {
                lblError.Text = "Amount Should be equal or greater then Total Amount";
                lblError.Visible = true;    
                return;
            }
            this.CashBack = Convert.ToDecimal(lblCashBack.Text);
            this.CashReceived = Convert.ToDecimal(txtCashReceived.Text);
            this.Close();
        }
       private void txtCashReceived_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCashReceived.Text))
            {
                lblCashBack.Text = "0";
            }
            else
            {
                lblCashBack.Text = (( Convert.ToDecimal(txtCashReceived.Text) - Convert.ToDecimal(lblTotalAmount.Text)) > 0 ? ( Convert.ToDecimal(txtCashReceived.Text) - Convert.ToDecimal(lblTotalAmount.Text)) : 0).ToString();
            }
            

        }

       private void frmPaymentReceived_KeyDown(object sender, KeyEventArgs e)
       {
           if (e.KeyCode == Keys.Escape)
           {
               this.Close();
           }
       }

       private void txtCashReceived_KeyDown(object sender, KeyEventArgs e)
       {
           if (e.KeyCode == Keys.Escape)
           {
               this.Close();
           }
           if (e.KeyCode == Keys.Enter)
           {
               btnSave.PerformClick();
           }
       }

       private void txtCashReceived_KeyPress(object sender, KeyPressEventArgs e)
       {
           if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)) || (e.KeyChar == (char)Keys.Escape) || (e.KeyChar == (char)Keys.Enter))
               e.Handled = true;
       }

      
    }
}
