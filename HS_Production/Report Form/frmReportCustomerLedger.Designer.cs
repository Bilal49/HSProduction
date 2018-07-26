namespace FIL.Report_Form
{
    partial class frmReportCustomerLedger
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportCustomerLedger));
            this.lblHeaderEn = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.lblToDate = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.btnCustomerCodeSearch = new System.Windows.Forms.Button();
            this.txtCustomerCode = new System.Windows.Forms.TextBox();
            this.crystalRptCustomerLedger = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btnView = new System.Windows.Forms.Button();
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
            this.lblHeaderEn.Size = new System.Drawing.Size(270, 25);
            this.lblHeaderEn.TabIndex = 177;
            this.lblHeaderEn.Text = "Customer Ledger Report";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F);
            this.label2.Location = new System.Drawing.Point(13, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 18);
            this.label2.TabIndex = 197;
            this.label2.Text = "Customer Code";
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpToDate.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(319, 64);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(139, 26);
            this.dtpToDate.TabIndex = 194;
            this.dtpToDate.ValueChanged += new System.EventHandler(this.dtpToDate_ValueChanged);
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Font = new System.Drawing.Font("Arial", 12F);
            this.lblToDate.Location = new System.Drawing.Point(316, 43);
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
            this.dtpFromDate.Location = new System.Drawing.Point(180, 64);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(133, 26);
            this.dtpFromDate.TabIndex = 192;
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Font = new System.Drawing.Font("Arial", 12F);
            this.lblFromDate.Location = new System.Drawing.Point(177, 43);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(83, 18);
            this.lblFromDate.TabIndex = 193;
            this.lblFromDate.Text = "From Date";
            // 
            // btnCustomerCodeSearch
            // 
            this.btnCustomerCodeSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCustomerCodeSearch.BackgroundImage")));
            this.btnCustomerCodeSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCustomerCodeSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCustomerCodeSearch.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnCustomerCodeSearch.FlatAppearance.BorderSize = 0;
            this.btnCustomerCodeSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCustomerCodeSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCustomerCodeSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomerCodeSearch.Location = new System.Drawing.Point(148, 62);
            this.btnCustomerCodeSearch.Name = "btnCustomerCodeSearch";
            this.btnCustomerCodeSearch.Size = new System.Drawing.Size(26, 28);
            this.btnCustomerCodeSearch.TabIndex = 190;
            this.btnCustomerCodeSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCustomerCodeSearch.UseVisualStyleBackColor = true;
            this.btnCustomerCodeSearch.Click += new System.EventHandler(this.btnCustomerCodeSearch_Click);
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.Font = new System.Drawing.Font("Arial", 12F);
            this.txtCustomerCode.Location = new System.Drawing.Point(16, 62);
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.Size = new System.Drawing.Size(126, 26);
            this.txtCustomerCode.TabIndex = 191;
            // 
            // crystalRptCustomerLedger
            // 
            this.crystalRptCustomerLedger.ActiveViewIndex = -1;
            this.crystalRptCustomerLedger.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crystalRptCustomerLedger.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalRptCustomerLedger.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalRptCustomerLedger.Location = new System.Drawing.Point(0, 100);
            this.crystalRptCustomerLedger.Name = "crystalRptCustomerLedger";
            this.crystalRptCustomerLedger.Size = new System.Drawing.Size(935, 459);
            this.crystalRptCustomerLedger.TabIndex = 187;
            this.crystalRptCustomerLedger.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crystalRptCustomerLedger.ReportRefresh += new CrystalDecisions.Windows.Forms.RefreshEventHandler(this.crystalRptCustomerLedger_ReportRefresh);
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
            this.btnView.Location = new System.Drawing.Point(464, 64);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(37, 26);
            this.btnView.TabIndex = 199;
            this.btnView.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnViewReport_Click);
            // 
            // frmReportCustomerLedger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 571);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpToDate);
            this.Controls.Add(this.lblToDate);
            this.Controls.Add(this.dtpFromDate);
            this.Controls.Add(this.lblFromDate);
            this.Controls.Add(this.btnCustomerCodeSearch);
            this.Controls.Add(this.txtCustomerCode);
            this.Controls.Add(this.crystalRptCustomerLedger);
            this.Controls.Add(this.lblHeaderEn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmReportCustomerLedger";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.Button btnCustomerCodeSearch;
        private System.Windows.Forms.TextBox txtCustomerCode;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalRptCustomerLedger;
        private System.Windows.Forms.Button btnView;

    }
}