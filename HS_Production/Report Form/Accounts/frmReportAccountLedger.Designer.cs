
    partial class frmReportAccountLedger
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportAccountLedger));
            this.lblHeaderEn = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.lblToDate = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.btnFAccSearch = new System.Windows.Forms.Button();
            this.txtFromAcc = new System.Windows.Forms.TextBox();
            this.CrViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btnView = new System.Windows.Forms.Button();
            this.txtFAccName = new System.Windows.Forms.TextBox();
            this.txtTAccName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnTAccSearch = new System.Windows.Forms.Button();
            this.txtTAcc = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblHeaderEn
            // 
            this.lblHeaderEn.AutoSize = true;
            this.lblHeaderEn.Font = new System.Drawing.Font("Arial", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblHeaderEn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(141)))), ((int)(((byte)(188)))));
            this.lblHeaderEn.Location = new System.Drawing.Point(12, 4);
            this.lblHeaderEn.Name = "lblHeaderEn";
            this.lblHeaderEn.Size = new System.Drawing.Size(236, 25);
            this.lblHeaderEn.TabIndex = 177;
            this.lblHeaderEn.Text = "Genral Ledger Report";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F);
            this.label2.Location = new System.Drawing.Point(301, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 18);
            this.label2.TabIndex = 197;
            this.label2.Text = "From Account";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpToDate.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(156, 54);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(139, 26);
            this.dtpToDate.TabIndex = 1;
            this.dtpToDate.ValueChanged += new System.EventHandler(this.dtpToDate_ValueChanged);
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Font = new System.Drawing.Font("Arial", 12F);
            this.lblToDate.Location = new System.Drawing.Point(153, 34);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(62, 18);
            this.lblToDate.TabIndex = 195;
            this.lblToDate.Text = "To Date";
            this.lblToDate.Click += new System.EventHandler(this.lblToDate_Click);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpFromDate.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(17, 54);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(133, 26);
            this.dtpFromDate.TabIndex = 0;
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Font = new System.Drawing.Font("Arial", 12F);
            this.lblFromDate.Location = new System.Drawing.Point(14, 33);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(83, 18);
            this.lblFromDate.TabIndex = 193;
            this.lblFromDate.Text = "From Date";
            // 
            // btnFAccSearch
            // 
            this.btnFAccSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFAccSearch.BackgroundImage")));
            this.btnFAccSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFAccSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFAccSearch.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnFAccSearch.FlatAppearance.BorderSize = 0;
            this.btnFAccSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFAccSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFAccSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFAccSearch.Location = new System.Drawing.Point(599, 56);
            this.btnFAccSearch.Name = "btnFAccSearch";
            this.btnFAccSearch.Size = new System.Drawing.Size(26, 28);
            this.btnFAccSearch.TabIndex = 190;
            this.btnFAccSearch.TabStop = false;
            this.btnFAccSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFAccSearch.UseVisualStyleBackColor = true;
            this.btnFAccSearch.Click += new System.EventHandler(this.btnFPartySearch_Click);
            // 
            // txtFromAcc
            // 
            this.txtFromAcc.Font = new System.Drawing.Font("Arial", 12F);
            this.txtFromAcc.Location = new System.Drawing.Point(411, 57);
            this.txtFromAcc.Name = "txtFromAcc";
            this.txtFromAcc.Size = new System.Drawing.Size(183, 26);
            this.txtFromAcc.TabIndex = 3;
            this.txtFromAcc.TextChanged += new System.EventHandler(this.txtFromPartyCode_TextChanged);
            this.txtFromAcc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPartyCode_KeyDown);
            // 
            // CrViewer
            // 
            this.CrViewer.ActiveViewIndex = -1;
            this.CrViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CrViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CrViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.CrViewer.Location = new System.Drawing.Point(0, 122);
            this.CrViewer.Name = "CrViewer";
            this.CrViewer.Size = new System.Drawing.Size(1182, 437);
            this.CrViewer.TabIndex = 187;
            this.CrViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.CrViewer.ReportRefresh += new CrystalDecisions.Windows.Forms.RefreshEventHandler(this.crystalRptCustomerLedger_ReportRefresh);
            // 
            // btnView
            // 
            this.btnView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnView.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnView.FlatAppearance.BorderSize = 0;
            this.btnView.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnView.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(232)))), ((int)(((byte)(244)))));
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.Image = ((System.Drawing.Image)(resources.GetObject("btnView.Image")));
            this.btnView.Location = new System.Drawing.Point(976, 58);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(37, 26);
            this.btnView.TabIndex = 8;
            this.btnView.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnViewReport_Click);
            // 
            // txtFAccName
            // 
            this.txtFAccName.Font = new System.Drawing.Font("Arial", 12F);
            this.txtFAccName.Location = new System.Drawing.Point(631, 57);
            this.txtFAccName.Name = "txtFAccName";
            this.txtFAccName.ReadOnly = true;
            this.txtFAccName.Size = new System.Drawing.Size(339, 26);
            this.txtFAccName.TabIndex = 3;
            this.txtFAccName.TabStop = false;
            // 
            // txtTAccName
            // 
            this.txtTAccName.Font = new System.Drawing.Font("Arial", 12F);
            this.txtTAccName.Location = new System.Drawing.Point(630, 89);
            this.txtTAccName.Name = "txtTAccName";
            this.txtTAccName.ReadOnly = true;
            this.txtTAccName.Size = new System.Drawing.Size(339, 26);
            this.txtTAccName.TabIndex = 5;
            this.txtTAccName.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F);
            this.label4.Location = new System.Drawing.Point(301, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 18);
            this.label4.TabIndex = 205;
            this.label4.Text = "To Account";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // btnTAccSearch
            // 
            this.btnTAccSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTAccSearch.BackgroundImage")));
            this.btnTAccSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTAccSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTAccSearch.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnTAccSearch.FlatAppearance.BorderSize = 0;
            this.btnTAccSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnTAccSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnTAccSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTAccSearch.Location = new System.Drawing.Point(598, 88);
            this.btnTAccSearch.Name = "btnTAccSearch";
            this.btnTAccSearch.Size = new System.Drawing.Size(26, 28);
            this.btnTAccSearch.TabIndex = 203;
            this.btnTAccSearch.TabStop = false;
            this.btnTAccSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTAccSearch.UseVisualStyleBackColor = true;
            this.btnTAccSearch.Click += new System.EventHandler(this.btnFItemSearch_Click);
            // 
            // txtTAcc
            // 
            this.txtTAcc.Font = new System.Drawing.Font("Arial", 12F);
            this.txtTAcc.Location = new System.Drawing.Point(411, 89);
            this.txtTAcc.Name = "txtTAcc";
            this.txtTAcc.Size = new System.Drawing.Size(181, 26);
            this.txtTAcc.TabIndex = 5;
            this.txtTAcc.TextChanged += new System.EventHandler(this.txtItemCode_TextChanged);
            this.txtTAcc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemCode_KeyDown);
            // 
            // btnClear
            // 
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(232)))), ((int)(((byte)(244)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Image = global::FIL.Properties.Resources.clear_32;
            this.btnClear.Location = new System.Drawing.Point(1019, 56);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(37, 26);
            this.btnClear.TabIndex = 9;
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Font = new System.Drawing.Font("Arial", 12F);
            this.chkAll.Location = new System.Drawing.Point(17, 86);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(82, 22);
            this.chkAll.TabIndex = 2;
            this.chkAll.Text = "All Date";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.Visible = false;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // frmReportAccountLedger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 571);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtTAccName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnTAccSearch);
            this.Controls.Add(this.txtTAcc);
            this.Controls.Add(this.txtFAccName);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpToDate);
            this.Controls.Add(this.lblToDate);
            this.Controls.Add(this.dtpFromDate);
            this.Controls.Add(this.lblFromDate);
            this.Controls.Add(this.btnFAccSearch);
            this.Controls.Add(this.txtFromAcc);
            this.Controls.Add(this.CrViewer);
            this.Controls.Add(this.lblHeaderEn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReportAccountLedger";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmReportStockInn_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeaderEn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.Button btnFAccSearch;
        private System.Windows.Forms.TextBox txtFromAcc;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer CrViewer;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.TextBox txtFAccName;
        private System.Windows.Forms.TextBox txtTAccName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnTAccSearch;
        private System.Windows.Forms.TextBox txtTAcc;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.CheckBox chkAll;

    }
