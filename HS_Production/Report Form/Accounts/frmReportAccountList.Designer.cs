
partial class frmReportAccountList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportAccountList));
            this.CRViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.cmbProductCatagory = new System.Windows.Forms.ComboBox();
            this.lblProductCatagory = new System.Windows.Forms.Label();
            this.txtFromAccCode = new System.Windows.Forms.TextBox();
            this.txtToAccCode = new System.Windows.Forms.TextBox();
            this.lblToSearch = new System.Windows.Forms.Label();
            this.lblFromSearch = new System.Windows.Forms.Label();
            this.lblHeaderEn = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.btnToSearch = new System.Windows.Forms.Button();
            this.btnFromSearch = new System.Windows.Forms.Button();
            this.txtFromAccName = new System.Windows.Forms.TextBox();
            this.txtToAccName = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdCode = new System.Windows.Forms.RadioButton();
            this.rdName = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CRViewer
            // 
            this.CRViewer.ActiveViewIndex = -1;
            this.CRViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CRViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CRViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.CRViewer.Location = new System.Drawing.Point(0, 96);
            this.CRViewer.Name = "CRViewer";
            this.CRViewer.Size = new System.Drawing.Size(1210, 406);
            this.CRViewer.TabIndex = 1;
            this.CRViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // cmbProductCatagory
            // 
            this.cmbProductCatagory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProductCatagory.Font = new System.Drawing.Font("Arial", 12F);
            this.cmbProductCatagory.FormattingEnabled = true;
            this.cmbProductCatagory.Location = new System.Drawing.Point(17, 62);
            this.cmbProductCatagory.Name = "cmbProductCatagory";
            this.cmbProductCatagory.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbProductCatagory.Size = new System.Drawing.Size(279, 26);
            this.cmbProductCatagory.TabIndex = 0;
            // 
            // lblProductCatagory
            // 
            this.lblProductCatagory.AutoSize = true;
            this.lblProductCatagory.Font = new System.Drawing.Font("Arial", 12F);
            this.lblProductCatagory.Location = new System.Drawing.Point(14, 37);
            this.lblProductCatagory.Name = "lblProductCatagory";
            this.lblProductCatagory.Size = new System.Drawing.Size(118, 18);
            this.lblProductCatagory.TabIndex = 129;
            this.lblProductCatagory.Text = "Category Name";
            // 
            // txtFromAccCode
            // 
            this.txtFromAccCode.Font = new System.Drawing.Font("Arial", 12F);
            this.txtFromAccCode.Location = new System.Drawing.Point(396, 34);
            this.txtFromAccCode.Name = "txtFromAccCode";
            this.txtFromAccCode.Size = new System.Drawing.Size(114, 26);
            this.txtFromAccCode.TabIndex = 2;
            this.txtFromAccCode.TextChanged += new System.EventHandler(this.txtFromAccCode_TextChanged);
            // 
            // txtToAccCode
            // 
            this.txtToAccCode.Font = new System.Drawing.Font("Arial", 12F);
            this.txtToAccCode.Location = new System.Drawing.Point(396, 64);
            this.txtToAccCode.Name = "txtToAccCode";
            this.txtToAccCode.Size = new System.Drawing.Size(114, 26);
            this.txtToAccCode.TabIndex = 4;
            this.txtToAccCode.TextChanged += new System.EventHandler(this.txtToAccCode_TextChanged);
            // 
            // lblToSearch
            // 
            this.lblToSearch.AutoSize = true;
            this.lblToSearch.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToSearch.Location = new System.Drawing.Point(302, 67);
            this.lblToSearch.Name = "lblToSearch";
            this.lblToSearch.Size = new System.Drawing.Size(67, 18);
            this.lblToSearch.TabIndex = 135;
            this.lblToSearch.Text = "To Code";
            // 
            // lblFromSearch
            // 
            this.lblFromSearch.AutoSize = true;
            this.lblFromSearch.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromSearch.Location = new System.Drawing.Point(302, 37);
            this.lblFromSearch.Name = "lblFromSearch";
            this.lblFromSearch.Size = new System.Drawing.Size(88, 18);
            this.lblFromSearch.TabIndex = 132;
            this.lblFromSearch.Text = "From Code";
            // 
            // lblHeaderEn
            // 
            this.lblHeaderEn.AutoSize = true;
            this.lblHeaderEn.Font = new System.Drawing.Font("Arial", 16F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))));
            this.lblHeaderEn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(141)))), ((int)(((byte)(188)))));
            this.lblHeaderEn.Location = new System.Drawing.Point(12, 4);
            this.lblHeaderEn.Name = "lblHeaderEn";
            this.lblHeaderEn.Size = new System.Drawing.Size(143, 25);
            this.lblHeaderEn.TabIndex = 213;
            this.lblHeaderEn.Text = "Account List";
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
            this.btnView.Location = new System.Drawing.Point(1052, 59);
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
            this.btnToSearch.Location = new System.Drawing.Point(517, 64);
            this.btnToSearch.Name = "btnToSearch";
            this.btnToSearch.Size = new System.Drawing.Size(26, 26);
            this.btnToSearch.TabIndex = 3;
            this.btnToSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnToSearch.UseVisualStyleBackColor = true;
            this.btnToSearch.Click += new System.EventHandler(this.btnToSearch_Click);
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
            this.btnFromSearch.Location = new System.Drawing.Point(516, 33);
            this.btnFromSearch.Name = "btnFromSearch";
            this.btnFromSearch.Size = new System.Drawing.Size(26, 26);
            this.btnFromSearch.TabIndex = 1;
            this.btnFromSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFromSearch.UseVisualStyleBackColor = true;
            this.btnFromSearch.Click += new System.EventHandler(this.btnFromSearch_Click);
            // 
            // txtFromAccName
            // 
            this.txtFromAccName.Font = new System.Drawing.Font("Arial", 12F);
            this.txtFromAccName.Location = new System.Drawing.Point(548, 34);
            this.txtFromAccName.Name = "txtFromAccName";
            this.txtFromAccName.ReadOnly = true;
            this.txtFromAccName.Size = new System.Drawing.Size(296, 26);
            this.txtFromAccName.TabIndex = 214;
            // 
            // txtToAccName
            // 
            this.txtToAccName.Font = new System.Drawing.Font("Arial", 12F);
            this.txtToAccName.Location = new System.Drawing.Point(549, 64);
            this.txtToAccName.Name = "txtToAccName";
            this.txtToAccName.ReadOnly = true;
            this.txtToAccName.Size = new System.Drawing.Size(296, 26);
            this.txtToAccName.TabIndex = 215;
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
            this.btnClear.Location = new System.Drawing.Point(1091, 59);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(37, 26);
            this.btnClear.TabIndex = 216;
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdName);
            this.groupBox1.Controls.Add(this.rdCode);
            this.groupBox1.Location = new System.Drawing.Point(851, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(195, 43);
            this.groupBox1.TabIndex = 217;
            this.groupBox1.TabStop = false;
            // 
            // rdCode
            // 
            this.rdCode.AutoSize = true;
            this.rdCode.Checked = true;
            this.rdCode.Font = new System.Drawing.Font("Arial", 12F);
            this.rdCode.Location = new System.Drawing.Point(6, 17);
            this.rdCode.Name = "rdCode";
            this.rdCode.Size = new System.Drawing.Size(87, 22);
            this.rdCode.TabIndex = 0;
            this.rdCode.Text = "By Code";
            this.rdCode.UseVisualStyleBackColor = true;
            // 
            // rdName
            // 
            this.rdName.AutoSize = true;
            this.rdName.Font = new System.Drawing.Font("Arial", 12F);
            this.rdName.Location = new System.Drawing.Point(99, 15);
            this.rdName.Name = "rdName";
            this.rdName.Size = new System.Drawing.Size(90, 22);
            this.rdName.TabIndex = 1;
            this.rdName.Text = "By Name";
            this.rdName.UseVisualStyleBackColor = true;
            // 
            // frmReportAccountList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1211, 503);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtToAccName);
            this.Controls.Add(this.txtFromAccName);
            this.Controls.Add(this.lblHeaderEn);
            this.Controls.Add(this.btnToSearch);
            this.Controls.Add(this.lblToSearch);
            this.Controls.Add(this.txtToAccCode);
            this.Controls.Add(this.btnFromSearch);
            this.Controls.Add(this.lblFromSearch);
            this.Controls.Add(this.txtFromAccCode);
            this.Controls.Add(this.cmbProductCatagory);
            this.Controls.Add(this.lblProductCatagory);
            this.Controls.Add(this.CRViewer);
            this.Name = "frmReportAccountList";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmReportPriceList_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CRViewer;
        private System.Windows.Forms.ComboBox cmbProductCatagory;
        private System.Windows.Forms.Label lblProductCatagory;
        private System.Windows.Forms.Button btnFromSearch;
        private System.Windows.Forms.TextBox txtFromAccCode;
        private System.Windows.Forms.Button btnToSearch;
        private System.Windows.Forms.TextBox txtToAccCode;
        private System.Windows.Forms.Label lblToSearch;
        private System.Windows.Forms.Label lblFromSearch;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label lblHeaderEn;
        private System.Windows.Forms.TextBox txtFromAccName;
        private System.Windows.Forms.TextBox txtToAccName;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdName;
        private System.Windows.Forms.RadioButton rdCode;
    }
