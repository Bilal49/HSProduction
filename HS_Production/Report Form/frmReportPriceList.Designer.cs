namespace FIL.Report_Form
{
    partial class frmReportPriceList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportPriceList));
            this.chkShowRate = new System.Windows.Forms.CheckBox();
            this.chkShowCetagory = new System.Windows.Forms.CheckBox();
            this.crystalRptPriceList = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.chkShowColor = new System.Windows.Forms.CheckBox();
            this.cmbProductCatagory = new System.Windows.Forms.ComboBox();
            this.lblProductCatagory = new System.Windows.Forms.Label();
            this.btnFromSearch = new System.Windows.Forms.Button();
            this.txtFromCode = new System.Windows.Forms.TextBox();
            this.btnToSearch = new System.Windows.Forms.Button();
            this.txtToCode = new System.Windows.Forms.TextBox();
            this.lblToSearch = new System.Windows.Forms.Label();
            this.lblFromSearch = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.chkShowCompany = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblHeaderEn = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkShowRate
            // 
            this.chkShowRate.AutoSize = true;
            this.chkShowRate.Checked = true;
            this.chkShowRate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowRate.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowRate.Location = new System.Drawing.Point(6, 19);
            this.chkShowRate.Name = "chkShowRate";
            this.chkShowRate.Size = new System.Drawing.Size(129, 20);
            this.chkShowRate.TabIndex = 6;
            this.chkShowRate.Text = "Show RatePrice";
            this.chkShowRate.UseVisualStyleBackColor = true;
            // 
            // chkShowCetagory
            // 
            this.chkShowCetagory.AutoSize = true;
            this.chkShowCetagory.Checked = true;
            this.chkShowCetagory.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowCetagory.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowCetagory.Location = new System.Drawing.Point(6, 42);
            this.chkShowCetagory.Name = "chkShowCetagory";
            this.chkShowCetagory.Size = new System.Drawing.Size(130, 20);
            this.chkShowCetagory.TabIndex = 8;
            this.chkShowCetagory.Text = "Show  Cetagory";
            this.chkShowCetagory.UseVisualStyleBackColor = true;
            // 
            // crystalRptPriceList
            // 
            this.crystalRptPriceList.ActiveViewIndex = -1;
            this.crystalRptPriceList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crystalRptPriceList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalRptPriceList.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalRptPriceList.Location = new System.Drawing.Point(0, 94);
            this.crystalRptPriceList.Name = "crystalRptPriceList";
            this.crystalRptPriceList.Size = new System.Drawing.Size(996, 397);
            this.crystalRptPriceList.TabIndex = 1;
            this.crystalRptPriceList.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // chkShowColor
            // 
            this.chkShowColor.AutoSize = true;
            this.chkShowColor.Checked = true;
            this.chkShowColor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowColor.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowColor.Location = new System.Drawing.Point(141, 42);
            this.chkShowColor.Name = "chkShowColor";
            this.chkShowColor.Size = new System.Drawing.Size(99, 20);
            this.chkShowColor.TabIndex = 9;
            this.chkShowColor.Text = "Show Color";
            this.chkShowColor.UseVisualStyleBackColor = true;
            // 
            // cmbProductCatagory
            // 
            this.cmbProductCatagory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbProductCatagory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProductCatagory.Font = new System.Drawing.Font("Arial", 12F);
            this.cmbProductCatagory.FormattingEnabled = true;
            this.cmbProductCatagory.Location = new System.Drawing.Point(16, 62);
            this.cmbProductCatagory.Name = "cmbProductCatagory";
            this.cmbProductCatagory.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbProductCatagory.Size = new System.Drawing.Size(193, 26);
            this.cmbProductCatagory.TabIndex = 0;
            // 
            // lblProductCatagory
            // 
            this.lblProductCatagory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProductCatagory.AutoSize = true;
            this.lblProductCatagory.Font = new System.Drawing.Font("Arial", 12F);
            this.lblProductCatagory.Location = new System.Drawing.Point(13, 37);
            this.lblProductCatagory.Name = "lblProductCatagory";
            this.lblProductCatagory.Size = new System.Drawing.Size(72, 18);
            this.lblProductCatagory.TabIndex = 129;
            this.lblProductCatagory.Text = "Category";
            // 
            // btnFromSearch
            // 
            this.btnFromSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFromSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFromSearch.BackgroundImage")));
            this.btnFromSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFromSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFromSearch.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnFromSearch.FlatAppearance.BorderSize = 0;
            this.btnFromSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFromSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFromSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFromSearch.Location = new System.Drawing.Point(335, 62);
            this.btnFromSearch.Name = "btnFromSearch";
            this.btnFromSearch.Size = new System.Drawing.Size(26, 26);
            this.btnFromSearch.TabIndex = 1;
            this.btnFromSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFromSearch.UseVisualStyleBackColor = true;
            this.btnFromSearch.Click += new System.EventHandler(this.btnFromSearch_Click);
            // 
            // txtFromCode
            // 
            this.txtFromCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFromCode.Font = new System.Drawing.Font("Arial", 12F);
            this.txtFromCode.Location = new System.Drawing.Point(215, 62);
            this.txtFromCode.Name = "txtFromCode";
            this.txtFromCode.Size = new System.Drawing.Size(114, 26);
            this.txtFromCode.TabIndex = 2;
            // 
            // btnToSearch
            // 
            this.btnToSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnToSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnToSearch.BackgroundImage")));
            this.btnToSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnToSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnToSearch.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnToSearch.FlatAppearance.BorderSize = 0;
            this.btnToSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnToSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnToSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToSearch.Location = new System.Drawing.Point(488, 62);
            this.btnToSearch.Name = "btnToSearch";
            this.btnToSearch.Size = new System.Drawing.Size(26, 26);
            this.btnToSearch.TabIndex = 3;
            this.btnToSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnToSearch.UseVisualStyleBackColor = true;
            this.btnToSearch.Click += new System.EventHandler(this.btnToSearch_Click);
            // 
            // txtToCode
            // 
            this.txtToCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtToCode.Font = new System.Drawing.Font("Arial", 12F);
            this.txtToCode.Location = new System.Drawing.Point(367, 62);
            this.txtToCode.Name = "txtToCode";
            this.txtToCode.Size = new System.Drawing.Size(114, 26);
            this.txtToCode.TabIndex = 4;
            // 
            // lblToSearch
            // 
            this.lblToSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblToSearch.AutoSize = true;
            this.lblToSearch.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToSearch.Location = new System.Drawing.Point(364, 37);
            this.lblToSearch.Name = "lblToSearch";
            this.lblToSearch.Size = new System.Drawing.Size(67, 18);
            this.lblToSearch.TabIndex = 135;
            this.lblToSearch.Text = "To Code";
            // 
            // lblFromSearch
            // 
            this.lblFromSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFromSearch.AutoSize = true;
            this.lblFromSearch.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromSearch.Location = new System.Drawing.Point(212, 37);
            this.lblFromSearch.Name = "lblFromSearch";
            this.lblFromSearch.Size = new System.Drawing.Size(88, 18);
            this.lblFromSearch.TabIndex = 132;
            this.lblFromSearch.Text = "From Code";
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
            this.btnView.Location = new System.Drawing.Point(520, 61);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(37, 26);
            this.btnView.TabIndex = 5;
            this.btnView.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // chkShowCompany
            // 
            this.chkShowCompany.AutoSize = true;
            this.chkShowCompany.Checked = true;
            this.chkShowCompany.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowCompany.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold);
            this.chkShowCompany.Location = new System.Drawing.Point(141, 19);
            this.chkShowCompany.Name = "chkShowCompany";
            this.chkShowCompany.Size = new System.Drawing.Size(125, 20);
            this.chkShowCompany.TabIndex = 7;
            this.chkShowCompany.Text = "Show Campany";
            this.chkShowCompany.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chkShowRate);
            this.groupBox1.Controls.Add(this.chkShowCompany);
            this.groupBox1.Controls.Add(this.chkShowCetagory);
            this.groupBox1.Controls.Add(this.chkShowColor);
            this.groupBox1.Location = new System.Drawing.Point(714, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(271, 71);
            this.groupBox1.TabIndex = 212;
            this.groupBox1.TabStop = false;
            // 
            // lblHeaderEn
            // 
            this.lblHeaderEn.AutoSize = true;
            this.lblHeaderEn.Font = new System.Drawing.Font("Arial", 16F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))));
            this.lblHeaderEn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(141)))), ((int)(((byte)(188)))));
            this.lblHeaderEn.Location = new System.Drawing.Point(12, 4);
            this.lblHeaderEn.Name = "lblHeaderEn";
            this.lblHeaderEn.Size = new System.Drawing.Size(111, 25);
            this.lblHeaderEn.TabIndex = 213;
            this.lblHeaderEn.Text = "Price List";
            // 
            // frmReportPriceList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 503);
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
            this.Controls.Add(this.crystalRptPriceList);
            this.Name = "frmReportPriceList";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmReportPriceList_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkShowRate;
        private System.Windows.Forms.CheckBox chkShowCetagory;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalRptPriceList;
        private System.Windows.Forms.CheckBox chkShowColor;
        private System.Windows.Forms.ComboBox cmbProductCatagory;
        private System.Windows.Forms.Label lblProductCatagory;
        private System.Windows.Forms.Button btnFromSearch;
        private System.Windows.Forms.TextBox txtFromCode;
        private System.Windows.Forms.Button btnToSearch;
        private System.Windows.Forms.TextBox txtToCode;
        private System.Windows.Forms.Label lblToSearch;
        private System.Windows.Forms.Label lblFromSearch;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.CheckBox chkShowCompany;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblHeaderEn;
    }
}