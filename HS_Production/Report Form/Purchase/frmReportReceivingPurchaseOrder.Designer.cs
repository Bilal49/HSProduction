
    partial class frmReportReceivingPurchaseOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportReceivingPurchaseOrder));
            this.lblHeaderEn = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.lblToDate = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.CrViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btnView = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnTInvoiceSearch = new System.Windows.Forms.Button();
            this.txtTOrder = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnFInvoiceSearch = new System.Windows.Forms.Button();
            this.txtFOrder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFCCSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtToVendorCode = new System.Windows.Forms.TextBox();
            this.btnTCCSearch = new System.Windows.Forms.Button();
            this.txtFromVendorCode = new System.Windows.Forms.TextBox();
            this.txtFVendorName = new System.Windows.Forms.TextBox();
            this.txtTVendorName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblHeaderEn
            // 
            this.lblHeaderEn.AutoSize = true;
            this.lblHeaderEn.Font = new System.Drawing.Font("Arial", 16F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))));
            this.lblHeaderEn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(141)))), ((int)(((byte)(188)))));
            this.lblHeaderEn.Location = new System.Drawing.Point(12, 4);
            this.lblHeaderEn.Name = "lblHeaderEn";
            this.lblHeaderEn.Size = new System.Drawing.Size(354, 25);
            this.lblHeaderEn.TabIndex = 177;
            this.lblHeaderEn.Text = "Receving Purchase Order Report";
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
            this.lblToDate.Location = new System.Drawing.Point(153, 33);
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
            // CrViewer
            // 
            this.CrViewer.ActiveViewIndex = -1;
            this.CrViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CrViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CrViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.CrViewer.Location = new System.Drawing.Point(0, 137);
            this.CrViewer.Name = "CrViewer";
            this.CrViewer.Size = new System.Drawing.Size(1125, 422);
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
            this.btnView.Location = new System.Drawing.Point(1039, 105);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(37, 26);
            this.btnView.TabIndex = 6;
            this.btnView.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnViewReport_Click);
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
            this.btnClear.Location = new System.Drawing.Point(1082, 105);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(37, 26);
            this.btnClear.TabIndex = 7;
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F);
            this.label3.Location = new System.Drawing.Point(478, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 18);
            this.label3.TabIndex = 208;
            this.label3.Text = "To Order";
            // 
            // btnTInvoiceSearch
            // 
            this.btnTInvoiceSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTInvoiceSearch.BackgroundImage")));
            this.btnTInvoiceSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTInvoiceSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTInvoiceSearch.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnTInvoiceSearch.FlatAppearance.BorderSize = 0;
            this.btnTInvoiceSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnTInvoiceSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnTInvoiceSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTInvoiceSearch.Location = new System.Drawing.Point(623, 53);
            this.btnTInvoiceSearch.Name = "btnTInvoiceSearch";
            this.btnTInvoiceSearch.Size = new System.Drawing.Size(26, 28);
            this.btnTInvoiceSearch.TabIndex = 207;
            this.btnTInvoiceSearch.TabStop = false;
            this.btnTInvoiceSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTInvoiceSearch.UseVisualStyleBackColor = true;
            this.btnTInvoiceSearch.Click += new System.EventHandler(this.btnTInvoiceSearch_Click);
            // 
            // txtTOrder
            // 
            this.txtTOrder.Font = new System.Drawing.Font("Arial", 12F);
            this.txtTOrder.Location = new System.Drawing.Point(478, 54);
            this.txtTOrder.Name = "txtTOrder";
            this.txtTOrder.Size = new System.Drawing.Size(139, 26);
            this.txtTOrder.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F);
            this.label4.Location = new System.Drawing.Point(298, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 18);
            this.label4.TabIndex = 206;
            this.label4.Text = "From Order";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnFInvoiceSearch
            // 
            this.btnFInvoiceSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFInvoiceSearch.BackgroundImage")));
            this.btnFInvoiceSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFInvoiceSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFInvoiceSearch.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnFInvoiceSearch.FlatAppearance.BorderSize = 0;
            this.btnFInvoiceSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFInvoiceSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFInvoiceSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFInvoiceSearch.Location = new System.Drawing.Point(446, 53);
            this.btnFInvoiceSearch.Name = "btnFInvoiceSearch";
            this.btnFInvoiceSearch.Size = new System.Drawing.Size(26, 28);
            this.btnFInvoiceSearch.TabIndex = 205;
            this.btnFInvoiceSearch.TabStop = false;
            this.btnFInvoiceSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFInvoiceSearch.UseVisualStyleBackColor = true;
            this.btnFInvoiceSearch.Click += new System.EventHandler(this.btnFInvoiceSearch_Click);
            // 
            // txtFOrder
            // 
            this.txtFOrder.Font = new System.Drawing.Font("Arial", 12F);
            this.txtFOrder.Location = new System.Drawing.Point(301, 54);
            this.txtFOrder.Name = "txtFOrder";
            this.txtFOrder.Size = new System.Drawing.Size(139, 26);
            this.txtFOrder.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F);
            this.label1.Location = new System.Drawing.Point(475, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 18);
            this.label1.TabIndex = 202;
            this.label1.Text = "To Vendor";
            // 
            // btnFCCSearch
            // 
            this.btnFCCSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFCCSearch.BackgroundImage")));
            this.btnFCCSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFCCSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFCCSearch.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnFCCSearch.FlatAppearance.BorderSize = 0;
            this.btnFCCSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFCCSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFCCSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFCCSearch.Location = new System.Drawing.Point(162, 103);
            this.btnFCCSearch.Name = "btnFCCSearch";
            this.btnFCCSearch.Size = new System.Drawing.Size(26, 28);
            this.btnFCCSearch.TabIndex = 190;
            this.btnFCCSearch.TabStop = false;
            this.btnFCCSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFCCSearch.UseVisualStyleBackColor = true;
            this.btnFCCSearch.Click += new System.EventHandler(this.btnFPartySearch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F);
            this.label2.Location = new System.Drawing.Point(14, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 18);
            this.label2.TabIndex = 197;
            this.label2.Text = "From Vendor";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtToVendorCode
            // 
            this.txtToVendorCode.Font = new System.Drawing.Font("Arial", 12F);
            this.txtToVendorCode.Location = new System.Drawing.Point(478, 103);
            this.txtToVendorCode.Name = "txtToVendorCode";
            this.txtToVendorCode.Size = new System.Drawing.Size(139, 26);
            this.txtToVendorCode.TabIndex = 5;
            this.txtToVendorCode.TextChanged += new System.EventHandler(this.txtToVendorCode_TextChanged);
            // 
            // btnTCCSearch
            // 
            this.btnTCCSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTCCSearch.BackgroundImage")));
            this.btnTCCSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTCCSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTCCSearch.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnTCCSearch.FlatAppearance.BorderSize = 0;
            this.btnTCCSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnTCCSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnTCCSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTCCSearch.Location = new System.Drawing.Point(623, 102);
            this.btnTCCSearch.Name = "btnTCCSearch";
            this.btnTCCSearch.Size = new System.Drawing.Size(26, 28);
            this.btnTCCSearch.TabIndex = 200;
            this.btnTCCSearch.TabStop = false;
            this.btnTCCSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTCCSearch.UseVisualStyleBackColor = true;
            this.btnTCCSearch.Click += new System.EventHandler(this.btnTPartySearch_Click);
            // 
            // txtFromVendorCode
            // 
            this.txtFromVendorCode.Font = new System.Drawing.Font("Arial", 12F);
            this.txtFromVendorCode.Location = new System.Drawing.Point(17, 104);
            this.txtFromVendorCode.Name = "txtFromVendorCode";
            this.txtFromVendorCode.Size = new System.Drawing.Size(139, 26);
            this.txtFromVendorCode.TabIndex = 4;
            this.txtFromVendorCode.TextChanged += new System.EventHandler(this.txtFromVendorCode_TextChanged);
            // 
            // txtFVendorName
            // 
            this.txtFVendorName.Font = new System.Drawing.Font("Arial", 12F);
            this.txtFVendorName.Location = new System.Drawing.Point(194, 103);
            this.txtFVendorName.Name = "txtFVendorName";
            this.txtFVendorName.ReadOnly = true;
            this.txtFVendorName.Size = new System.Drawing.Size(278, 26);
            this.txtFVendorName.TabIndex = 209;
            // 
            // txtTVendorName
            // 
            this.txtTVendorName.Font = new System.Drawing.Font("Arial", 12F);
            this.txtTVendorName.Location = new System.Drawing.Point(655, 102);
            this.txtTVendorName.Name = "txtTVendorName";
            this.txtTVendorName.ReadOnly = true;
            this.txtTVendorName.Size = new System.Drawing.Size(278, 26);
            this.txtTVendorName.TabIndex = 210;
            // 
            // frmReportReceivingPurchaseOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 571);
            this.Controls.Add(this.txtTVendorName);
            this.Controls.Add(this.txtFVendorName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnTInvoiceSearch);
            this.Controls.Add(this.txtTOrder);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnFInvoiceSearch);
            this.Controls.Add(this.txtFOrder);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTCCSearch);
            this.Controls.Add(this.txtToVendorCode);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpToDate);
            this.Controls.Add(this.lblToDate);
            this.Controls.Add(this.dtpFromDate);
            this.Controls.Add(this.lblFromDate);
            this.Controls.Add(this.btnFCCSearch);
            this.Controls.Add(this.txtFromVendorCode);
            this.Controls.Add(this.CrViewer);
            this.Controls.Add(this.lblHeaderEn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReportReceivingPurchaseOrder";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmReportStockInn_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeaderEn;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label lblFromDate;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer CrViewer;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnTInvoiceSearch;
        private System.Windows.Forms.TextBox txtTOrder;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnFInvoiceSearch;
        private System.Windows.Forms.TextBox txtFOrder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFCCSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtToVendorCode;
        private System.Windows.Forms.Button btnTCCSearch;
        private System.Windows.Forms.TextBox txtFromVendorCode;
        private System.Windows.Forms.TextBox txtFVendorName;
        private System.Windows.Forms.TextBox txtTVendorName;

    }
