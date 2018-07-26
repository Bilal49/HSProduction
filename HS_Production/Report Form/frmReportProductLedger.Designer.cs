namespace FIL.Report_Form
{
    partial class frmReportProductLedger
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportProductLedger));
            this.lblHeaderEn = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.lblToDate = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.btnFCCSearch = new System.Windows.Forms.Button();
            this.txtFromProductCode = new System.Windows.Forms.TextBox();
            this.CrViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btnView = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTCCSearch = new System.Windows.Forms.Button();
            this.txtToProductCode = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.cmbProductCatagory = new System.Windows.Forms.ComboBox();
            this.lblProductCatagory = new System.Windows.Forms.Label();
            this.cmbWarehouse = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFromPName = new System.Windows.Forms.TextBox();
            this.txtToPName = new System.Windows.Forms.TextBox();
            this.cmbFProductName = new System.Windows.Forms.ComboBox();
            this.cmbProductNameNew = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProductNameNew.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
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
            this.lblHeaderEn.Size = new System.Drawing.Size(213, 25);
            this.lblHeaderEn.TabIndex = 177;
            this.lblHeaderEn.Text = "Item Ledger Report";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F);
            this.label2.Location = new System.Drawing.Point(352, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 18);
            this.label2.TabIndex = 197;
            this.label2.Text = "From Item";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpToDate.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(17, 107);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(133, 26);
            this.dtpToDate.TabIndex = 1;
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Font = new System.Drawing.Font("Arial", 12F);
            this.lblToDate.Location = new System.Drawing.Point(14, 86);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(62, 18);
            this.lblToDate.TabIndex = 195;
            this.lblToDate.Text = "To Date";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpFromDate.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(17, 55);
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
            this.btnFCCSearch.Location = new System.Drawing.Point(468, 57);
            this.btnFCCSearch.Name = "btnFCCSearch";
            this.btnFCCSearch.Size = new System.Drawing.Size(26, 28);
            this.btnFCCSearch.TabIndex = 190;
            this.btnFCCSearch.TabStop = false;
            this.btnFCCSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFCCSearch.UseVisualStyleBackColor = true;
            this.btnFCCSearch.Click += new System.EventHandler(this.btnFPartySearch_Click);
            // 
            // txtFromProductCode
            // 
            this.txtFromProductCode.Font = new System.Drawing.Font("Arial", 12F);
            this.txtFromProductCode.Location = new System.Drawing.Point(355, 55);
            this.txtFromProductCode.Name = "txtFromProductCode";
            this.txtFromProductCode.Size = new System.Drawing.Size(108, 26);
            this.txtFromProductCode.TabIndex = 4;
            this.txtFromProductCode.TextChanged += new System.EventHandler(this.txtFromProductCode_TextChanged);
            // 
            // CrViewer
            // 
            this.CrViewer.ActiveViewIndex = -1;
            this.CrViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CrViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CrViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.CrViewer.Location = new System.Drawing.Point(0, 139);
            this.CrViewer.Name = "CrViewer";
            this.CrViewer.Size = new System.Drawing.Size(1125, 420);
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
            this.btnView.Location = new System.Drawing.Point(820, 100);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(37, 31);
            this.btnView.TabIndex = 6;
            this.btnView.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnViewReport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F);
            this.label1.Location = new System.Drawing.Point(352, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 18);
            this.label1.TabIndex = 202;
            this.label1.Text = "To Item";
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
            this.btnTCCSearch.Location = new System.Drawing.Point(468, 106);
            this.btnTCCSearch.Name = "btnTCCSearch";
            this.btnTCCSearch.Size = new System.Drawing.Size(26, 28);
            this.btnTCCSearch.TabIndex = 200;
            this.btnTCCSearch.TabStop = false;
            this.btnTCCSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTCCSearch.UseVisualStyleBackColor = true;
            this.btnTCCSearch.Click += new System.EventHandler(this.btnTPartySearch_Click);
            // 
            // txtToProductCode
            // 
            this.txtToProductCode.Font = new System.Drawing.Font("Arial", 12F);
            this.txtToProductCode.Location = new System.Drawing.Point(355, 107);
            this.txtToProductCode.Name = "txtToProductCode";
            this.txtToProductCode.Size = new System.Drawing.Size(108, 26);
            this.txtToProductCode.TabIndex = 5;
            this.txtToProductCode.TextChanged += new System.EventHandler(this.txtToProductCode_TextChanged);
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
            this.btnClear.Location = new System.Drawing.Point(863, 100);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(37, 31);
            this.btnClear.TabIndex = 7;
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // cmbProductCatagory
            // 
            this.cmbProductCatagory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProductCatagory.Font = new System.Drawing.Font("Arial", 12F);
            this.cmbProductCatagory.FormattingEnabled = true;
            this.cmbProductCatagory.Location = new System.Drawing.Point(156, 55);
            this.cmbProductCatagory.Name = "cmbProductCatagory";
            this.cmbProductCatagory.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbProductCatagory.Size = new System.Drawing.Size(193, 26);
            this.cmbProductCatagory.TabIndex = 203;
            // 
            // lblProductCatagory
            // 
            this.lblProductCatagory.AutoSize = true;
            this.lblProductCatagory.Font = new System.Drawing.Font("Arial", 12F);
            this.lblProductCatagory.Location = new System.Drawing.Point(153, 33);
            this.lblProductCatagory.Name = "lblProductCatagory";
            this.lblProductCatagory.Size = new System.Drawing.Size(72, 18);
            this.lblProductCatagory.TabIndex = 204;
            this.lblProductCatagory.Text = "Category";
            // 
            // cmbWarehouse
            // 
            this.cmbWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWarehouse.Font = new System.Drawing.Font("Arial", 12F);
            this.cmbWarehouse.FormattingEnabled = true;
            this.cmbWarehouse.Location = new System.Drawing.Point(156, 107);
            this.cmbWarehouse.Name = "cmbWarehouse";
            this.cmbWarehouse.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbWarehouse.Size = new System.Drawing.Size(193, 26);
            this.cmbWarehouse.TabIndex = 205;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F);
            this.label3.Location = new System.Drawing.Point(153, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 18);
            this.label3.TabIndex = 206;
            this.label3.Text = "Department";
            // 
            // txtFromPName
            // 
            this.txtFromPName.Font = new System.Drawing.Font("Arial", 12F);
            this.txtFromPName.Location = new System.Drawing.Point(500, 54);
            this.txtFromPName.Name = "txtFromPName";
            this.txtFromPName.ReadOnly = true;
            this.txtFromPName.Size = new System.Drawing.Size(314, 26);
            this.txtFromPName.TabIndex = 207;
            // 
            // txtToPName
            // 
            this.txtToPName.Font = new System.Drawing.Font("Arial", 12F);
            this.txtToPName.Location = new System.Drawing.Point(500, 106);
            this.txtToPName.Name = "txtToPName";
            this.txtToPName.ReadOnly = true;
            this.txtToPName.Size = new System.Drawing.Size(314, 26);
            this.txtToPName.TabIndex = 208;
            // 
            // cmbFProductName
            // 
            this.cmbFProductName.Font = new System.Drawing.Font("Arial", 12F);
            this.cmbFProductName.FormattingEnabled = true;
            this.cmbFProductName.Location = new System.Drawing.Point(911, 43);
            this.cmbFProductName.Name = "cmbFProductName";
            this.cmbFProductName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbFProductName.Size = new System.Drawing.Size(69, 26);
            this.cmbFProductName.TabIndex = 221;
            this.cmbFProductName.Visible = false;
            this.cmbFProductName.SelectedIndexChanged += new System.EventHandler(this.cmbFProductName_SelectedIndexChanged);
            this.cmbFProductName.SelectedValueChanged += new System.EventHandler(this.cmbFProductName_SelectedValueChanged);
            // 
            // cmbProductNameNew
            // 
            this.cmbProductNameNew.Location = new System.Drawing.Point(500, 24);
            this.cmbProductNameNew.Name = "cmbProductNameNew";
            this.cmbProductNameNew.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.cmbProductNameNew.Properties.Appearance.Options.UseFont = true;
            this.cmbProductNameNew.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbProductNameNew.Properties.NullText = "";
            this.cmbProductNameNew.Properties.PopupSizeable = false;
            this.cmbProductNameNew.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cmbProductNameNew.Properties.View = this.gridLookUpEdit1View;
            this.cmbProductNameNew.Size = new System.Drawing.Size(314, 24);
            this.cmbProductNameNew.TabIndex = 222;
            this.cmbProductNameNew.EditValueChanged += new System.EventHandler(this.cmbProductNameNew_EditValueChanged);
            this.cmbProductNameNew.Enter += new System.EventHandler(this.cmbProductNameNew_Enter);
            this.cmbProductNameNew.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbProductNameNew_KeyDown);
            this.cmbProductNameNew.Leave += new System.EventHandler(this.cmbProductNameNew_Leave);
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // frmReportProductLedger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 571);
            this.Controls.Add(this.cmbProductNameNew);
            this.Controls.Add(this.cmbFProductName);
            this.Controls.Add(this.txtToPName);
            this.Controls.Add(this.txtFromPName);
            this.Controls.Add(this.cmbProductCatagory);
            this.Controls.Add(this.cmbWarehouse);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblProductCatagory);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTCCSearch);
            this.Controls.Add(this.txtToProductCode);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpToDate);
            this.Controls.Add(this.lblToDate);
            this.Controls.Add(this.dtpFromDate);
            this.Controls.Add(this.lblFromDate);
            this.Controls.Add(this.btnFCCSearch);
            this.Controls.Add(this.txtFromProductCode);
            this.Controls.Add(this.CrViewer);
            this.Controls.Add(this.lblHeaderEn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReportProductLedger";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmReportStockInn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbProductNameNew.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
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
        private System.Windows.Forms.Button btnFCCSearch;
        private System.Windows.Forms.TextBox txtFromProductCode;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer CrViewer;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTCCSearch;
        private System.Windows.Forms.TextBox txtToProductCode;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ComboBox cmbProductCatagory;
        private System.Windows.Forms.Label lblProductCatagory;
        private System.Windows.Forms.ComboBox cmbWarehouse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFromPName;
        private System.Windows.Forms.TextBox txtToPName;
        private System.Windows.Forms.ComboBox cmbFProductName;
        private DevExpress.XtraEditors.GridLookUpEdit cmbProductNameNew;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;

    }
}