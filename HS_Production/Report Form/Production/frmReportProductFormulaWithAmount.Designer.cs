
partial class frmReportProductFormulaWithAmount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportProductFormulaWithAmount));
            this.lblHeaderEn = new System.Windows.Forms.Label();
            this.CrViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btnView = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnVoucherToCodeSearch = new System.Windows.Forms.Button();
            this.txtPCode = new System.Windows.Forms.TextBox();
            this.txtPName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pbitem = new System.Windows.Forms.PictureBox();
            this.btnfomulaSearch = new System.Windows.Forms.Button();
            this.txtFormulaId = new System.Windows.Forms.TextBox();
            this.cmbProductFormulaNew = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.pbitem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProductFormulaNew.Properties)).BeginInit();
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
            this.lblHeaderEn.Size = new System.Drawing.Size(328, 25);
            this.lblHeaderEn.TabIndex = 177;
            this.lblHeaderEn.Text = "Product Formula With Amount";
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
            this.CrViewer.Size = new System.Drawing.Size(1125, 473);
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
            this.btnView.Location = new System.Drawing.Point(784, 53);
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
            this.btnClear.Location = new System.Drawing.Point(827, 53);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(37, 26);
            this.btnClear.TabIndex = 7;
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F);
            this.label2.Location = new System.Drawing.Point(20, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 18);
            this.label2.TabIndex = 190;
            this.label2.Text = "Article Code";
            // 
            // btnVoucherToCodeSearch
            // 
            this.btnVoucherToCodeSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVoucherToCodeSearch.BackgroundImage")));
            this.btnVoucherToCodeSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVoucherToCodeSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVoucherToCodeSearch.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnVoucherToCodeSearch.FlatAppearance.BorderSize = 0;
            this.btnVoucherToCodeSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnVoucherToCodeSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnVoucherToCodeSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoucherToCodeSearch.Location = new System.Drawing.Point(149, 54);
            this.btnVoucherToCodeSearch.Name = "btnVoucherToCodeSearch";
            this.btnVoucherToCodeSearch.Size = new System.Drawing.Size(26, 28);
            this.btnVoucherToCodeSearch.TabIndex = 188;
            this.btnVoucherToCodeSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVoucherToCodeSearch.UseVisualStyleBackColor = true;
            this.btnVoucherToCodeSearch.Click += new System.EventHandler(this.btnVoucherToCodeSearch_Click);
            // 
            // txtPCode
            // 
            this.txtPCode.Font = new System.Drawing.Font("Arial", 12F);
            this.txtPCode.Location = new System.Drawing.Point(17, 54);
            this.txtPCode.Name = "txtPCode";
            this.txtPCode.Size = new System.Drawing.Size(126, 26);
            this.txtPCode.TabIndex = 189;
            this.txtPCode.TextChanged += new System.EventHandler(this.txtProductCode_TextChanged);
            // 
            // txtPName
            // 
            this.txtPName.Font = new System.Drawing.Font("Arial", 12F);
            this.txtPName.Location = new System.Drawing.Point(181, 54);
            this.txtPName.Name = "txtPName";
            this.txtPName.ReadOnly = true;
            this.txtPName.Size = new System.Drawing.Size(326, 26);
            this.txtPName.TabIndex = 191;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F);
            this.label1.Location = new System.Drawing.Point(181, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 18);
            this.label1.TabIndex = 192;
            this.label1.Text = "Article Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F);
            this.label3.Location = new System.Drawing.Point(510, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 18);
            this.label3.TabIndex = 193;
            this.label3.Text = "Formula Name";
            // 
            // pbitem
            // 
            this.pbitem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbitem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbitem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbitem.Image = global::FIL.Properties.Resources.User;
            this.pbitem.Location = new System.Drawing.Point(1019, 7);
            this.pbitem.Name = "pbitem";
            this.pbitem.Size = new System.Drawing.Size(94, 75);
            this.pbitem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbitem.TabIndex = 195;
            this.pbitem.TabStop = false;
            // 
            // btnfomulaSearch
            // 
            this.btnfomulaSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnfomulaSearch.BackgroundImage")));
            this.btnfomulaSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnfomulaSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnfomulaSearch.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnfomulaSearch.FlatAppearance.BorderSize = 0;
            this.btnfomulaSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnfomulaSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnfomulaSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnfomulaSearch.Location = new System.Drawing.Point(784, 25);
            this.btnfomulaSearch.Name = "btnfomulaSearch";
            this.btnfomulaSearch.Size = new System.Drawing.Size(26, 28);
            this.btnfomulaSearch.TabIndex = 196;
            this.btnfomulaSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnfomulaSearch.UseVisualStyleBackColor = true;
            this.btnfomulaSearch.Click += new System.EventHandler(this.btnfomulaSearch_Click);
            // 
            // txtFormulaId
            // 
            this.txtFormulaId.Font = new System.Drawing.Font("Arial", 12F);
            this.txtFormulaId.Location = new System.Drawing.Point(652, 25);
            this.txtFormulaId.Name = "txtFormulaId";
            this.txtFormulaId.Size = new System.Drawing.Size(126, 26);
            this.txtFormulaId.TabIndex = 197;
            this.txtFormulaId.TextChanged += new System.EventHandler(this.txtFormulaId_TextChanged);
            this.txtFormulaId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFormulaId_KeyPress);
            // 
            // cmbProductFormulaNew
            // 
            this.cmbProductFormulaNew.Location = new System.Drawing.Point(513, 54);
            this.cmbProductFormulaNew.Name = "cmbProductFormulaNew";
            this.cmbProductFormulaNew.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.cmbProductFormulaNew.Properties.Appearance.Options.UseFont = true;
            this.cmbProductFormulaNew.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbProductFormulaNew.Properties.NullText = "";
            this.cmbProductFormulaNew.Properties.PopupSizeable = false;
            this.cmbProductFormulaNew.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cmbProductFormulaNew.Properties.View = this.gridLookUpEdit1View;
            this.cmbProductFormulaNew.Size = new System.Drawing.Size(265, 24);
            this.cmbProductFormulaNew.TabIndex = 223;
            this.cmbProductFormulaNew.EditValueChanged += new System.EventHandler(this.cmbProductFormulaNew_EditValueChanged);
            this.cmbProductFormulaNew.Enter += new System.EventHandler(this.cmbProductFormulaNew_Enter);
            this.cmbProductFormulaNew.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbProductFormulaNew_KeyDown);
            this.cmbProductFormulaNew.Leave += new System.EventHandler(this.cmbProductFormulaNew_Leave);
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // frmReportProductFormulaWithAmount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 571);
            this.Controls.Add(this.cmbProductFormulaNew);
            this.Controls.Add(this.btnfomulaSearch);
            this.Controls.Add(this.txtFormulaId);
            this.Controls.Add(this.pbitem);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnVoucherToCodeSearch);
            this.Controls.Add(this.txtPCode);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.CrViewer);
            this.Controls.Add(this.lblHeaderEn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReportProductFormulaWithAmount";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmReportStockInn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbitem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProductFormulaNew.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeaderEn;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer CrViewer;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnVoucherToCodeSearch;
        private System.Windows.Forms.TextBox txtPCode;
        private System.Windows.Forms.TextBox txtPName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pbitem;
        private System.Windows.Forms.Button btnfomulaSearch;
        private System.Windows.Forms.TextBox txtFormulaId;
        private DevExpress.XtraEditors.GridLookUpEdit cmbProductFormulaNew;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;

    }
