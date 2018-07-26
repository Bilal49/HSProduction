
    partial class frmReportVoucher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportVoucher));
            this.CrViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btnVoucherSearch = new System.Windows.Forms.Button();
            this.lblFromSearch = new System.Windows.Forms.Label();
            this.txtFromVoucherNumber = new System.Windows.Forms.TextBox();
            this.lblHeaderEn = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnToVoucher = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtToVoucherNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // CrViewer
            // 
            this.CrViewer.ActiveViewIndex = -1;
            this.CrViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CrViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CrViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.CrViewer.Location = new System.Drawing.Point(2, 99);
            this.CrViewer.Name = "CrViewer";
            this.CrViewer.Size = new System.Drawing.Size(1213, 409);
            this.CrViewer.TabIndex = 188;
            this.CrViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // btnVoucherSearch
            // 
            this.btnVoucherSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVoucherSearch.BackgroundImage")));
            this.btnVoucherSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVoucherSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVoucherSearch.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnVoucherSearch.FlatAppearance.BorderSize = 0;
            this.btnVoucherSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnVoucherSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnVoucherSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoucherSearch.Location = new System.Drawing.Point(730, 53);
            this.btnVoucherSearch.Name = "btnVoucherSearch";
            this.btnVoucherSearch.Size = new System.Drawing.Size(26, 26);
            this.btnVoucherSearch.TabIndex = 207;
            this.btnVoucherSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVoucherSearch.UseVisualStyleBackColor = true;
            this.btnVoucherSearch.Click += new System.EventHandler(this.btnVoucherSearch_Click);
            // 
            // lblFromSearch
            // 
            this.lblFromSearch.AutoSize = true;
            this.lblFromSearch.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromSearch.Location = new System.Drawing.Point(452, 56);
            this.lblFromSearch.Name = "lblFromSearch";
            this.lblFromSearch.Size = new System.Drawing.Size(88, 18);
            this.lblFromSearch.TabIndex = 209;
            this.lblFromSearch.Text = "From Code";
            // 
            // txtFromVoucherNumber
            // 
            this.txtFromVoucherNumber.Font = new System.Drawing.Font("Arial", 12F);
            this.txtFromVoucherNumber.Location = new System.Drawing.Point(546, 53);
            this.txtFromVoucherNumber.Name = "txtFromVoucherNumber";
            this.txtFromVoucherNumber.Size = new System.Drawing.Size(178, 26);
            this.txtFromVoucherNumber.TabIndex = 208;
            // 
            // lblHeaderEn
            // 
            this.lblHeaderEn.AutoSize = true;
            this.lblHeaderEn.Font = new System.Drawing.Font("Arial", 16F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))));
            this.lblHeaderEn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(141)))), ((int)(((byte)(188)))));
            this.lblHeaderEn.Location = new System.Drawing.Point(5, 9);
            this.lblHeaderEn.Name = "lblHeaderEn";
            this.lblHeaderEn.Size = new System.Drawing.Size(175, 25);
            this.lblHeaderEn.TabIndex = 214;
            this.lblHeaderEn.Text = "Report Voucher";
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
            this.btnClear.Location = new System.Drawing.Point(1098, 52);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(37, 26);
            this.btnClear.TabIndex = 218;
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
            this.btnView.Location = new System.Drawing.Point(1059, 52);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(37, 26);
            this.btnView.TabIndex = 217;
            this.btnView.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnToVoucher
            // 
            this.btnToVoucher.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnToVoucher.BackgroundImage")));
            this.btnToVoucher.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnToVoucher.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnToVoucher.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnToVoucher.FlatAppearance.BorderSize = 0;
            this.btnToVoucher.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnToVoucher.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnToVoucher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToVoucher.Location = new System.Drawing.Point(1023, 53);
            this.btnToVoucher.Name = "btnToVoucher";
            this.btnToVoucher.Size = new System.Drawing.Size(26, 26);
            this.btnToVoucher.TabIndex = 219;
            this.btnToVoucher.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnToVoucher.UseVisualStyleBackColor = true;
            this.btnToVoucher.Click += new System.EventHandler(this.btnToVoucher_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(766, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 18);
            this.label1.TabIndex = 221;
            this.label1.Text = "To Code";
            // 
            // txtToVoucherNumber
            // 
            this.txtToVoucherNumber.Font = new System.Drawing.Font("Arial", 12F);
            this.txtToVoucherNumber.Location = new System.Drawing.Point(839, 53);
            this.txtToVoucherNumber.Name = "txtToVoucherNumber";
            this.txtToVoucherNumber.Size = new System.Drawing.Size(178, 26);
            this.txtToVoucherNumber.TabIndex = 220;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 18);
            this.label2.TabIndex = 222;
            this.label2.Text = "From Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(241, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 18);
            this.label3.TabIndex = 223;
            this.label3.Text = "To Date";
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "dd-MMM-yyyy";
            this.dtpFrom.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(96, 53);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(139, 26);
            this.dtpFrom.TabIndex = 224;
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "dd-MMM-yyyy";
            this.dtpTo.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(309, 53);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(139, 26);
            this.dtpTo.TabIndex = 225;
            // 
            // frmReportVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1218, 510);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnToVoucher);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtToVoucherNumber);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.lblHeaderEn);
            this.Controls.Add(this.btnVoucherSearch);
            this.Controls.Add(this.lblFromSearch);
            this.Controls.Add(this.txtFromVoucherNumber);
            this.Controls.Add(this.CrViewer);
            this.Name = "frmReportVoucher";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmReportVoucher_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CrViewer;
        private System.Windows.Forms.Button btnVoucherSearch;
        private System.Windows.Forms.Label lblFromSearch;
        private System.Windows.Forms.TextBox txtFromVoucherNumber;
        private System.Windows.Forms.Label lblHeaderEn;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnToVoucher;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtToVoucherNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
    }
