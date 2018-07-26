namespace FIL
{
    partial class frmPaymentReceived
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtCashReceived = new System.Windows.Forms.TextBox();
            this.lblCashReceived = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblTotalAmount1 = new System.Windows.Forms.Label();
            this.lblCashBack1 = new System.Windows.Forms.Label();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.lblCashBack = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtCashReceived
            // 
            this.txtCashReceived.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCashReceived.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtCashReceived.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCashReceived.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.txtCashReceived.Location = new System.Drawing.Point(182, 112);
            this.txtCashReceived.Name = "txtCashReceived";
            this.txtCashReceived.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCashReceived.Size = new System.Drawing.Size(140, 30);
            this.txtCashReceived.TabIndex = 31;
            this.txtCashReceived.TextChanged += new System.EventHandler(this.txtCashReceived_TextChanged);
            this.txtCashReceived.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCashReceived_KeyDown);
            this.txtCashReceived.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCashReceived_KeyPress);
            // 
            // lblCashReceived
            // 
            this.lblCashReceived.AutoSize = true;
            this.lblCashReceived.Font = new System.Drawing.Font("Calibri", 15.75F);
            this.lblCashReceived.ForeColor = System.Drawing.Color.White;
            this.lblCashReceived.Location = new System.Drawing.Point(39, 114);
            this.lblCashReceived.Name = "lblCashReceived";
            this.lblCashReceived.Size = new System.Drawing.Size(132, 26);
            this.lblCashReceived.TabIndex = 32;
            this.lblCashReceived.Text = "Cash Received";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalAmount.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmount.ForeColor = System.Drawing.Color.White;
            this.lblTotalAmount.Location = new System.Drawing.Point(179, 71);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTotalAmount.Size = new System.Drawing.Size(143, 26);
            this.lblTotalAmount.TabIndex = 32;
            this.lblTotalAmount.Text = "Total Amount";
            // 
            // lblTotalAmount1
            // 
            this.lblTotalAmount1.AutoSize = true;
            this.lblTotalAmount1.Font = new System.Drawing.Font("Calibri", 15.75F);
            this.lblTotalAmount1.ForeColor = System.Drawing.Color.White;
            this.lblTotalAmount1.Location = new System.Drawing.Point(39, 71);
            this.lblTotalAmount1.Name = "lblTotalAmount1";
            this.lblTotalAmount1.Size = new System.Drawing.Size(127, 26);
            this.lblTotalAmount1.TabIndex = 32;
            this.lblTotalAmount1.Text = "Total Amount";
            // 
            // lblCashBack1
            // 
            this.lblCashBack1.AutoSize = true;
            this.lblCashBack1.Font = new System.Drawing.Font("Calibri", 15.75F);
            this.lblCashBack1.ForeColor = System.Drawing.Color.White;
            this.lblCashBack1.Location = new System.Drawing.Point(39, 161);
            this.lblCashBack1.Name = "lblCashBack1";
            this.lblCashBack1.Size = new System.Drawing.Size(97, 26);
            this.lblCashBack1.TabIndex = 32;
            this.lblCashBack1.Text = "Cash Back";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Appearance.Font = new System.Drawing.Font("Calibri", 15.75F);
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Image = global::FIL.Properties.Resources.check_32;
            this.btnSave.Location = new System.Drawing.Point(224, 230);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(93, 40);
            this.btnSave.TabIndex = 33;
            this.btnSave.Text = "Done";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblCashBack
            // 
            this.lblCashBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCashBack.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblCashBack.ForeColor = System.Drawing.Color.White;
            this.lblCashBack.Location = new System.Drawing.Point(170, 161);
            this.lblCashBack.Name = "lblCashBack";
            this.lblCashBack.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblCashBack.Size = new System.Drawing.Size(152, 26);
            this.lblCashBack.TabIndex = 34;
            this.lblCashBack.Text = "CashBack";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 26F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(107, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 42);
            this.label1.TabIndex = 35;
            this.label1.Text = "Payment";
            // 
            // lblError
            // 
            this.lblError.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblError.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.lblError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(249)))), ((int)(((byte)(0)))));
            this.lblError.Location = new System.Drawing.Point(12, 192);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(336, 26);
            this.lblError.TabIndex = 36;
            this.lblError.Text = "Error Message";
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblError.Visible = false;
            // 
            // frmPaymentReceived
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(147)))), ((int)(((byte)(155)))));
            this.ClientSize = new System.Drawing.Size(360, 288);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCashBack);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtCashReceived);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.lblCashBack1);
            this.Controls.Add(this.lblTotalAmount1);
            this.Controls.Add(this.lblCashReceived);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPaymentReceived";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payment Received";
            this.Load += new System.EventHandler(this.frmPaymentReceived_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPaymentReceived_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCashReceived;
        private System.Windows.Forms.Label lblCashReceived;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblTotalAmount1;
        private System.Windows.Forms.Label lblCashBack1;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private System.Windows.Forms.Label lblCashBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblError;
    }
}