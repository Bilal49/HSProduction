namespace FIL.Report_Form
{
    partial class frmReportCashPayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportCashPayment));
            this.crystalRptCashPayment = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btnVoucheFromCodeSearch = new System.Windows.Forms.Button();
            this.txtVoucherFromCode = new System.Windows.Forms.TextBox();
            this.btnVoucherToCodeSearch = new System.Windows.Forms.Button();
            this.txtVoucherToCode = new System.Windows.Forms.TextBox();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.lblToDate = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblHeaderEn = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // crystalRptCashPayment
            // 
            this.crystalRptCashPayment.ActiveViewIndex = -1;
            this.crystalRptCashPayment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crystalRptCashPayment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalRptCashPayment.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalRptCashPayment.Location = new System.Drawing.Point(1, 87);
            this.crystalRptCashPayment.Name = "crystalRptCashPayment";
            this.crystalRptCashPayment.Size = new System.Drawing.Size(1068, 463);
            this.crystalRptCashPayment.TabIndex = 1;
            this.crystalRptCashPayment.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // btnVoucheFromCodeSearch
            // 
            this.btnVoucheFromCodeSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVoucheFromCodeSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVoucheFromCodeSearch.BackgroundImage")));
            this.btnVoucheFromCodeSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVoucheFromCodeSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVoucheFromCodeSearch.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnVoucheFromCodeSearch.FlatAppearance.BorderSize = 0;
            this.btnVoucheFromCodeSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnVoucheFromCodeSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnVoucheFromCodeSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoucheFromCodeSearch.Location = new System.Drawing.Point(148, 54);
            this.btnVoucheFromCodeSearch.Name = "btnVoucheFromCodeSearch";
            this.btnVoucheFromCodeSearch.Size = new System.Drawing.Size(26, 28);
            this.btnVoucheFromCodeSearch.TabIndex = 0;
            this.btnVoucheFromCodeSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVoucheFromCodeSearch.UseVisualStyleBackColor = true;
            this.btnVoucheFromCodeSearch.Click += new System.EventHandler(this.btnVoucheFromCodeSearch_Click);
            // 
            // txtVoucherFromCode
            // 
            this.txtVoucherFromCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVoucherFromCode.Font = new System.Drawing.Font("Arial", 12F);
            this.txtVoucherFromCode.Location = new System.Drawing.Point(16, 55);
            this.txtVoucherFromCode.Name = "txtVoucherFromCode";
            this.txtVoucherFromCode.Size = new System.Drawing.Size(126, 26);
            this.txtVoucherFromCode.TabIndex = 1;
            // 
            // btnVoucherToCodeSearch
            // 
            this.btnVoucherToCodeSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVoucherToCodeSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVoucherToCodeSearch.BackgroundImage")));
            this.btnVoucherToCodeSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVoucherToCodeSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVoucherToCodeSearch.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnVoucherToCodeSearch.FlatAppearance.BorderSize = 0;
            this.btnVoucherToCodeSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnVoucherToCodeSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnVoucherToCodeSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoucherToCodeSearch.Location = new System.Drawing.Point(312, 54);
            this.btnVoucherToCodeSearch.Name = "btnVoucherToCodeSearch";
            this.btnVoucherToCodeSearch.Size = new System.Drawing.Size(26, 28);
            this.btnVoucherToCodeSearch.TabIndex = 2;
            this.btnVoucherToCodeSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVoucherToCodeSearch.UseVisualStyleBackColor = true;
            this.btnVoucherToCodeSearch.Click += new System.EventHandler(this.btnVoucherToCodeSearch_Click);
            // 
            // txtVoucherToCode
            // 
            this.txtVoucherToCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVoucherToCode.Font = new System.Drawing.Font("Arial", 12F);
            this.txtVoucherToCode.Location = new System.Drawing.Point(180, 55);
            this.txtVoucherToCode.Name = "txtVoucherToCode";
            this.txtVoucherToCode.Size = new System.Drawing.Size(126, 26);
            this.txtVoucherToCode.TabIndex = 3;
            // 
            // dtpToDate
            // 
            this.dtpToDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpToDate.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(483, 55);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(139, 26);
            this.dtpToDate.TabIndex = 5;
            // 
            // lblToDate
            // 
            this.lblToDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblToDate.AutoSize = true;
            this.lblToDate.Font = new System.Drawing.Font("Arial", 12F);
            this.lblToDate.Location = new System.Drawing.Point(480, 34);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(62, 18);
            this.lblToDate.TabIndex = 170;
            this.lblToDate.Text = "To Date";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpFromDate.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(344, 55);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(133, 26);
            this.dtpFromDate.TabIndex = 4;
            // 
            // lblFromDate
            // 
            this.lblFromDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Font = new System.Drawing.Font("Arial", 12F);
            this.lblFromDate.Location = new System.Drawing.Point(341, 34);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(83, 18);
            this.lblFromDate.TabIndex = 168;
            this.lblFromDate.Text = "From Date";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F);
            this.label1.Location = new System.Drawing.Point(13, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 18);
            this.label1.TabIndex = 171;
            this.label1.Text = "From Voucher";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F);
            this.label2.Location = new System.Drawing.Point(177, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 18);
            this.label2.TabIndex = 172;
            this.label2.Text = "To Voucher";
            // 
            // lblHeaderEn
            // 
            this.lblHeaderEn.AutoSize = true;
            this.lblHeaderEn.Font = new System.Drawing.Font("Arial", 16F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))));
            this.lblHeaderEn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(141)))), ((int)(((byte)(188)))));
            this.lblHeaderEn.Location = new System.Drawing.Point(11, 4);
            this.lblHeaderEn.Name = "lblHeaderEn";
            this.lblHeaderEn.Size = new System.Drawing.Size(240, 25);
            this.lblHeaderEn.TabIndex = 175;
            this.lblHeaderEn.Text = "Cash Payment Report";
            // 
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnView.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnView.FlatAppearance.BorderSize = 0;
            this.btnView.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnView.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(232)))), ((int)(((byte)(244)))));
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.Image = ((System.Drawing.Image)(resources.GetObject("btnView.Image")));
            this.btnView.Location = new System.Drawing.Point(628, 55);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(37, 26);
            this.btnView.TabIndex = 6;
            this.btnView.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnViewRepot_Click);
            // 
            // frmReportCashPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 562);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.lblHeaderEn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpToDate);
            this.Controls.Add(this.lblToDate);
            this.Controls.Add(this.dtpFromDate);
            this.Controls.Add(this.lblFromDate);
            this.Controls.Add(this.btnVoucherToCodeSearch);
            this.Controls.Add(this.txtVoucherToCode);
            this.Controls.Add(this.btnVoucheFromCodeSearch);
            this.Controls.Add(this.txtVoucherFromCode);
            this.Controls.Add(this.crystalRptCashPayment);
            this.Name = "frmReportCashPayment";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalRptCashPayment;
        private System.Windows.Forms.Button btnVoucheFromCodeSearch;
        private System.Windows.Forms.TextBox txtVoucherFromCode;
        private System.Windows.Forms.Button btnVoucherToCodeSearch;
        private System.Windows.Forms.TextBox txtVoucherToCode;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblHeaderEn;
        private System.Windows.Forms.Button btnView;
    }
}