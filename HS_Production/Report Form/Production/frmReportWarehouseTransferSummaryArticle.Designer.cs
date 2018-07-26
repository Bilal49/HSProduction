
partial class frmReportWarehouseTransferSummaryArticle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportWarehouseTransferSummaryArticle));
            this.lblHeaderEn = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.CrViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.cmbWarehouse = new System.Windows.Forms.ComboBox();
            this.lblProductCatagory = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnSNo = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSONo = new System.Windows.Forms.TextBox();
            this.txtPName = new System.Windows.Forms.TextBox();
            this.btnPSearch = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPCode = new System.Windows.Forms.TextBox();
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
            this.lblHeaderEn.Size = new System.Drawing.Size(443, 25);
            this.lblHeaderEn.TabIndex = 177;
            this.lblHeaderEn.Text = "Warehouse Transfer Summary For Article";
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpDate.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(17, 54);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(133, 26);
            this.dtpDate.TabIndex = 0;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Font = new System.Drawing.Font("Arial", 12F);
            this.lblFromDate.Location = new System.Drawing.Point(14, 33);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(51, 18);
            this.lblFromDate.TabIndex = 193;
            this.lblFromDate.Text = "As On";
            // 
            // CrViewer
            // 
            this.CrViewer.ActiveViewIndex = -1;
            this.CrViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CrViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CrViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.CrViewer.Location = new System.Drawing.Point(0, 86);
            this.CrViewer.Name = "CrViewer";
            this.CrViewer.Size = new System.Drawing.Size(1164, 473);
            this.CrViewer.TabIndex = 187;
            this.CrViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.CrViewer.ReportRefresh += new CrystalDecisions.Windows.Forms.RefreshEventHandler(this.crystalRptCustomerLedger_ReportRefresh);
            // 
            // cmbWarehouse
            // 
            this.cmbWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWarehouse.Font = new System.Drawing.Font("Arial", 12F);
            this.cmbWarehouse.FormattingEnabled = true;
            this.cmbWarehouse.Location = new System.Drawing.Point(156, 54);
            this.cmbWarehouse.Name = "cmbWarehouse";
            this.cmbWarehouse.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbWarehouse.Size = new System.Drawing.Size(193, 26);
            this.cmbWarehouse.TabIndex = 203;
            // 
            // lblProductCatagory
            // 
            this.lblProductCatagory.AutoSize = true;
            this.lblProductCatagory.Font = new System.Drawing.Font("Arial", 12F);
            this.lblProductCatagory.Location = new System.Drawing.Point(153, 29);
            this.lblProductCatagory.Name = "lblProductCatagory";
            this.lblProductCatagory.Size = new System.Drawing.Size(87, 18);
            this.lblProductCatagory.TabIndex = 204;
            this.lblProductCatagory.Text = "Warehouse";
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
            this.btnClear.Location = new System.Drawing.Point(1108, 21);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(37, 26);
            this.btnClear.TabIndex = 7;
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
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
            this.btnView.Location = new System.Drawing.Point(1065, 21);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(37, 26);
            this.btnView.TabIndex = 6;
            this.btnView.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnViewReport_Click);
            // 
            // btnSNo
            // 
            this.btnSNo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSNo.BackgroundImage")));
            this.btnSNo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSNo.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnSNo.FlatAppearance.BorderSize = 0;
            this.btnSNo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSNo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSNo.Location = new System.Drawing.Point(566, 54);
            this.btnSNo.Name = "btnSNo";
            this.btnSNo.Size = new System.Drawing.Size(26, 26);
            this.btnSNo.TabIndex = 206;
            this.btnSNo.TabStop = false;
            this.btnSNo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSNo.UseVisualStyleBackColor = true;
            this.btnSNo.Click += new System.EventHandler(this.btnSNo_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(353, 58);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(59, 18);
            this.label5.TabIndex = 207;
            this.label5.Text = "S.O No";
            // 
            // txtSONo
            // 
            this.txtSONo.Font = new System.Drawing.Font("Arial", 12F);
            this.txtSONo.Location = new System.Drawing.Point(418, 54);
            this.txtSONo.Name = "txtSONo";
            this.txtSONo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSONo.Size = new System.Drawing.Size(140, 26);
            this.txtSONo.TabIndex = 205;
            this.txtSONo.TextChanged += new System.EventHandler(this.txtSONo_TextChanged);
            // 
            // txtPName
            // 
            this.txtPName.Font = new System.Drawing.Font("Arial", 12F);
            this.txtPName.Location = new System.Drawing.Point(879, 50);
            this.txtPName.Name = "txtPName";
            this.txtPName.ReadOnly = true;
            this.txtPName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPName.Size = new System.Drawing.Size(270, 26);
            this.txtPName.TabIndex = 211;
            this.txtPName.TabStop = false;
            // 
            // btnPSearch
            // 
            this.btnPSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPSearch.BackgroundImage")));
            this.btnPSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPSearch.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnPSearch.FlatAppearance.BorderSize = 0;
            this.btnPSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPSearch.Location = new System.Drawing.Point(847, 50);
            this.btnPSearch.Name = "btnPSearch";
            this.btnPSearch.Size = new System.Drawing.Size(26, 26);
            this.btnPSearch.TabIndex = 208;
            this.btnPSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPSearch.UseVisualStyleBackColor = true;
            this.btnPSearch.Click += new System.EventHandler(this.btnPSearch_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(595, 53);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label7.Size = new System.Drawing.Size(98, 18);
            this.label7.TabIndex = 210;
            this.label7.Text = "Article Name";
            // 
            // txtPCode
            // 
            this.txtPCode.Font = new System.Drawing.Font("Arial", 12F);
            this.txtPCode.Location = new System.Drawing.Point(699, 50);
            this.txtPCode.Name = "txtPCode";
            this.txtPCode.ReadOnly = true;
            this.txtPCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPCode.Size = new System.Drawing.Size(140, 26);
            this.txtPCode.TabIndex = 209;
            this.txtPCode.TextChanged += new System.EventHandler(this.txtPCode_TextChanged);
            // 
            // frmReportWarehouseTransferSummaryArticle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 571);
            this.Controls.Add(this.txtPName);
            this.Controls.Add(this.btnPSearch);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPCode);
            this.Controls.Add(this.btnSNo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSONo);
            this.Controls.Add(this.cmbWarehouse);
            this.Controls.Add(this.lblProductCatagory);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblFromDate);
            this.Controls.Add(this.CrViewer);
            this.Controls.Add(this.lblHeaderEn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReportWarehouseTransferSummaryArticle";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmReportStockInn_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeaderEn;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblFromDate;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer CrViewer;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ComboBox cmbWarehouse;
        private System.Windows.Forms.Label lblProductCatagory;
        private System.Windows.Forms.Button btnSNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSONo;
        private System.Windows.Forms.TextBox txtPName;
        private System.Windows.Forms.Button btnPSearch;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPCode;

    }
