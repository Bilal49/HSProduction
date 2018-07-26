namespace FIL.Report_Form
{
    partial class frmReportProductStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportProductStock));
            this.crystalRptProductStock = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.chkShowCetagory = new System.Windows.Forms.CheckBox();
            this.chkShowStock = new System.Windows.Forms.CheckBox();
            this.chkShowColor = new System.Windows.Forms.CheckBox();
            this.btnView = new System.Windows.Forms.Button();
            this.btnToSearch = new System.Windows.Forms.Button();
            this.lblToSearch = new System.Windows.Forms.Label();
            this.txtToCode = new System.Windows.Forms.TextBox();
            this.btnFromSearch = new System.Windows.Forms.Button();
            this.lblFromSearch = new System.Windows.Forms.Label();
            this.txtFromCode = new System.Windows.Forms.TextBox();
            this.cmbProductCatagory = new System.Windows.Forms.ComboBox();
            this.lblProductCatagory = new System.Windows.Forms.Label();
            this.chkShowCompany = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblHeaderEn = new System.Windows.Forms.Label();
            this.txtFromProduct = new System.Windows.Forms.TextBox();
            this.txtToProduct = new System.Windows.Forms.TextBox();
            this.cmbWarehouse = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.cmbFProductName = new System.Windows.Forms.ComboBox();
            this.cmbProductNameNew = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProductNameNew.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // crystalRptProductStock
            // 
            this.crystalRptProductStock.ActiveViewIndex = -1;
            this.crystalRptProductStock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crystalRptProductStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalRptProductStock.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalRptProductStock.Location = new System.Drawing.Point(0, 112);
            this.crystalRptProductStock.Name = "crystalRptProductStock";
            this.crystalRptProductStock.Size = new System.Drawing.Size(1243, 379);
            this.crystalRptProductStock.TabIndex = 5;
            this.crystalRptProductStock.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // chkShowCetagory
            // 
            this.chkShowCetagory.AutoSize = true;
            this.chkShowCetagory.Checked = true;
            this.chkShowCetagory.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowCetagory.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold);
            this.chkShowCetagory.Location = new System.Drawing.Point(6, 19);
            this.chkShowCetagory.Name = "chkShowCetagory";
            this.chkShowCetagory.Size = new System.Drawing.Size(130, 20);
            this.chkShowCetagory.TabIndex = 6;
            this.chkShowCetagory.Text = "Show  Cetagory";
            this.chkShowCetagory.UseVisualStyleBackColor = true;
            // 
            // chkShowStock
            // 
            this.chkShowStock.AutoSize = true;
            this.chkShowStock.Checked = true;
            this.chkShowStock.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowStock.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold);
            this.chkShowStock.Location = new System.Drawing.Point(6, 40);
            this.chkShowStock.Name = "chkShowStock";
            this.chkShowStock.Size = new System.Drawing.Size(102, 20);
            this.chkShowStock.TabIndex = 8;
            this.chkShowStock.Text = "Show Stock";
            this.chkShowStock.UseVisualStyleBackColor = true;
            // 
            // chkShowColor
            // 
            this.chkShowColor.AutoSize = true;
            this.chkShowColor.Checked = true;
            this.chkShowColor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowColor.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold);
            this.chkShowColor.Location = new System.Drawing.Point(140, 40);
            this.chkShowColor.Name = "chkShowColor";
            this.chkShowColor.Size = new System.Drawing.Size(99, 20);
            this.chkShowColor.TabIndex = 9;
            this.chkShowColor.Text = "Show Color";
            this.chkShowColor.UseVisualStyleBackColor = true;
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
            this.btnView.Location = new System.Drawing.Point(871, 74);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(37, 26);
            this.btnView.TabIndex = 5;
            this.btnView.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnToSearch
            // 
            this.btnToSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnToSearch.BackgroundImage")));
            this.btnToSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnToSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnToSearch.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnToSearch.FlatAppearance.BorderSize = 0;
            this.btnToSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnToSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnToSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToSearch.Location = new System.Drawing.Point(527, 78);
            this.btnToSearch.Name = "btnToSearch";
            this.btnToSearch.Size = new System.Drawing.Size(26, 26);
            this.btnToSearch.TabIndex = 3;
            this.btnToSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnToSearch.UseVisualStyleBackColor = true;
            this.btnToSearch.Click += new System.EventHandler(this.btnToSearch_Click);
            // 
            // lblToSearch
            // 
            this.lblToSearch.AutoSize = true;
            this.lblToSearch.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToSearch.Location = new System.Drawing.Point(298, 82);
            this.lblToSearch.Name = "lblToSearch";
            this.lblToSearch.Size = new System.Drawing.Size(82, 18);
            this.lblToSearch.TabIndex = 208;
            this.lblToSearch.Text = "To Product";
            // 
            // txtToCode
            // 
            this.txtToCode.Font = new System.Drawing.Font("Arial", 12F);
            this.txtToCode.Location = new System.Drawing.Point(407, 78);
            this.txtToCode.Name = "txtToCode";
            this.txtToCode.Size = new System.Drawing.Size(114, 26);
            this.txtToCode.TabIndex = 4;
            this.txtToCode.TextChanged += new System.EventHandler(this.txtToCode_TextChanged);
            // 
            // btnFromSearch
            // 
            this.btnFromSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFromSearch.BackgroundImage")));
            this.btnFromSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFromSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFromSearch.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnFromSearch.FlatAppearance.BorderSize = 0;
            this.btnFromSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFromSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFromSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFromSearch.Location = new System.Drawing.Point(527, 46);
            this.btnFromSearch.Name = "btnFromSearch";
            this.btnFromSearch.Size = new System.Drawing.Size(26, 26);
            this.btnFromSearch.TabIndex = 1;
            this.btnFromSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFromSearch.UseVisualStyleBackColor = true;
            this.btnFromSearch.Click += new System.EventHandler(this.btnFromSearch_Click);
            // 
            // lblFromSearch
            // 
            this.lblFromSearch.AutoSize = true;
            this.lblFromSearch.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromSearch.Location = new System.Drawing.Point(298, 50);
            this.lblFromSearch.Name = "lblFromSearch";
            this.lblFromSearch.Size = new System.Drawing.Size(103, 18);
            this.lblFromSearch.TabIndex = 205;
            this.lblFromSearch.Text = "From Product";
            // 
            // txtFromCode
            // 
            this.txtFromCode.Font = new System.Drawing.Font("Arial", 12F);
            this.txtFromCode.Location = new System.Drawing.Point(407, 46);
            this.txtFromCode.Name = "txtFromCode";
            this.txtFromCode.Size = new System.Drawing.Size(114, 26);
            this.txtFromCode.TabIndex = 2;
            this.txtFromCode.TextChanged += new System.EventHandler(this.txtFromCode_TextChanged);
            // 
            // cmbProductCatagory
            // 
            this.cmbProductCatagory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProductCatagory.Font = new System.Drawing.Font("Arial", 12F);
            this.cmbProductCatagory.FormattingEnabled = true;
            this.cmbProductCatagory.Location = new System.Drawing.Point(87, 46);
            this.cmbProductCatagory.Name = "cmbProductCatagory";
            this.cmbProductCatagory.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbProductCatagory.Size = new System.Drawing.Size(193, 26);
            this.cmbProductCatagory.TabIndex = 0;
            // 
            // lblProductCatagory
            // 
            this.lblProductCatagory.AutoSize = true;
            this.lblProductCatagory.Font = new System.Drawing.Font("Arial", 12F);
            this.lblProductCatagory.Location = new System.Drawing.Point(9, 50);
            this.lblProductCatagory.Name = "lblProductCatagory";
            this.lblProductCatagory.Size = new System.Drawing.Size(72, 18);
            this.lblProductCatagory.TabIndex = 202;
            this.lblProductCatagory.Text = "Category";
            // 
            // chkShowCompany
            // 
            this.chkShowCompany.AutoSize = true;
            this.chkShowCompany.Checked = true;
            this.chkShowCompany.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowCompany.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold);
            this.chkShowCompany.Location = new System.Drawing.Point(140, 20);
            this.chkShowCompany.Name = "chkShowCompany";
            this.chkShowCompany.Size = new System.Drawing.Size(125, 20);
            this.chkShowCompany.TabIndex = 7;
            this.chkShowCompany.Text = "Show Campany";
            this.chkShowCompany.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chkShowCetagory);
            this.groupBox1.Controls.Add(this.chkShowCompany);
            this.groupBox1.Controls.Add(this.chkShowStock);
            this.groupBox1.Controls.Add(this.chkShowColor);
            this.groupBox1.Location = new System.Drawing.Point(965, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(267, 64);
            this.groupBox1.TabIndex = 211;
            this.groupBox1.TabStop = false;
            // 
            // lblHeaderEn
            // 
            this.lblHeaderEn.AutoSize = true;
            this.lblHeaderEn.Font = new System.Drawing.Font("Arial", 16F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))));
            this.lblHeaderEn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(141)))), ((int)(((byte)(188)))));
            this.lblHeaderEn.Location = new System.Drawing.Point(12, 9);
            this.lblHeaderEn.Name = "lblHeaderEn";
            this.lblHeaderEn.Size = new System.Drawing.Size(117, 25);
            this.lblHeaderEn.TabIndex = 214;
            this.lblHeaderEn.Text = "Stock List";
            // 
            // txtFromProduct
            // 
            this.txtFromProduct.Font = new System.Drawing.Font("Arial", 12F);
            this.txtFromProduct.Location = new System.Drawing.Point(559, 46);
            this.txtFromProduct.Name = "txtFromProduct";
            this.txtFromProduct.ReadOnly = true;
            this.txtFromProduct.Size = new System.Drawing.Size(306, 26);
            this.txtFromProduct.TabIndex = 215;
            this.txtFromProduct.TextChanged += new System.EventHandler(this.txtFromProduct_TextChanged);
            // 
            // txtToProduct
            // 
            this.txtToProduct.Font = new System.Drawing.Font("Arial", 12F);
            this.txtToProduct.Location = new System.Drawing.Point(559, 78);
            this.txtToProduct.Name = "txtToProduct";
            this.txtToProduct.ReadOnly = true;
            this.txtToProduct.Size = new System.Drawing.Size(306, 26);
            this.txtToProduct.TabIndex = 216;
            // 
            // cmbWarehouse
            // 
            this.cmbWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWarehouse.Font = new System.Drawing.Font("Arial", 12F);
            this.cmbWarehouse.FormattingEnabled = true;
            this.cmbWarehouse.Location = new System.Drawing.Point(87, 78);
            this.cmbWarehouse.Name = "cmbWarehouse";
            this.cmbWarehouse.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbWarehouse.Size = new System.Drawing.Size(193, 26);
            this.cmbWarehouse.TabIndex = 217;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F);
            this.label1.Location = new System.Drawing.Point(9, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 18);
            this.label1.TabIndex = 218;
            this.label1.Text = "Depart";
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
            this.btnClear.Location = new System.Drawing.Point(914, 74);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(37, 26);
            this.btnClear.TabIndex = 219;
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // cmbFProductName
            // 
            this.cmbFProductName.Font = new System.Drawing.Font("Arial", 12F);
            this.cmbFProductName.FormattingEnabled = true;
            this.cmbFProductName.Location = new System.Drawing.Point(407, 8);
            this.cmbFProductName.Name = "cmbFProductName";
            this.cmbFProductName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbFProductName.Size = new System.Drawing.Size(115, 26);
            this.cmbFProductName.TabIndex = 220;
            this.cmbFProductName.Visible = false;
            this.cmbFProductName.SelectedIndexChanged += new System.EventHandler(this.cmbFProductName_SelectedIndexChanged);
            this.cmbFProductName.SelectedValueChanged += new System.EventHandler(this.cmbFProductName_SelectedValueChanged);
            // 
            // cmbProductNameNew
            // 
            this.cmbProductNameNew.Location = new System.Drawing.Point(559, 12);
            this.cmbProductNameNew.Name = "cmbProductNameNew";
            this.cmbProductNameNew.Properties.Appearance.Font = new System.Drawing.Font("Arial", 12F);
            this.cmbProductNameNew.Properties.Appearance.Options.UseFont = true;
            this.cmbProductNameNew.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbProductNameNew.Properties.NullText = "";
            this.cmbProductNameNew.Properties.PopupSizeable = false;
            this.cmbProductNameNew.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cmbProductNameNew.Properties.View = this.gridLookUpEdit1View;
            this.cmbProductNameNew.Size = new System.Drawing.Size(306, 24);
            this.cmbProductNameNew.TabIndex = 221;
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
            // frmReportProductStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 503);
            this.Controls.Add(this.cmbFProductName);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.cmbWarehouse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtToProduct);
            this.Controls.Add(this.txtFromProduct);
            this.Controls.Add(this.lblHeaderEn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.btnToSearch);
            this.Controls.Add(this.lblToSearch);
            this.Controls.Add(this.txtToCode);
            this.Controls.Add(this.btnFromSearch);
            this.Controls.Add(this.lblFromSearch);
            this.Controls.Add(this.txtFromCode);
            this.Controls.Add(this.cmbProductCatagory);
            this.Controls.Add(this.lblProductCatagory);
            this.Controls.Add(this.crystalRptProductStock);
            this.Controls.Add(this.cmbProductNameNew);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "frmReportProductStock";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmReportProductStock_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProductNameNew.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalRptProductStock;
        private System.Windows.Forms.CheckBox chkShowCetagory;
        private System.Windows.Forms.CheckBox chkShowStock;
        private System.Windows.Forms.CheckBox chkShowColor;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnToSearch;
        private System.Windows.Forms.Label lblToSearch;
        private System.Windows.Forms.TextBox txtToCode;
        private System.Windows.Forms.Button btnFromSearch;
        private System.Windows.Forms.Label lblFromSearch;
        private System.Windows.Forms.TextBox txtFromCode;
        private System.Windows.Forms.ComboBox cmbProductCatagory;
        private System.Windows.Forms.Label lblProductCatagory;
        private System.Windows.Forms.CheckBox chkShowCompany;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblHeaderEn;
        private System.Windows.Forms.TextBox txtFromProduct;
        private System.Windows.Forms.TextBox txtToProduct;
        private System.Windows.Forms.ComboBox cmbWarehouse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ComboBox cmbFProductName;
        private DevExpress.XtraEditors.GridLookUpEdit cmbProductNameNew;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
    }
}