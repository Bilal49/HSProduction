
    partial class frmAccountConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccountConfig));
            this.label1 = new System.Windows.Forms.Label();
            this.btnSalesSearch = new System.Windows.Forms.Button();
            this.lblCode = new System.Windows.Forms.Label();
            this.txtSalesAcc = new System.Windows.Forms.TextBox();
            this.txtSalesAccName = new System.Windows.Forms.TextBox();
            this.txtPurchaseAccName = new System.Windows.Forms.TextBox();
            this.btnPurhaseSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPurchaseAcc = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtCashAccName = new System.Windows.Forms.TextBox();
            this.btnCashSearch = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCashAcc = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSaleGSTAccName = new System.Windows.Forms.TextBox();
            this.btnSaleGSTSearch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSaleGSTAcc = new System.Windows.Forms.TextBox();
            this.txtPurchaseGSTAccName = new System.Windows.Forms.TextBox();
            this.btnPurchaseGSTSearch = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPurchaseGSTAcc = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 18F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(141)))), ((int)(((byte)(188)))));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(267, 28);
            this.label1.TabIndex = 10;
            this.label1.Text = "Account Configuration";
            // 
            // btnSalesSearch
            // 
            this.btnSalesSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalesSearch.BackgroundImage")));
            this.btnSalesSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSalesSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalesSearch.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnSalesSearch.FlatAppearance.BorderSize = 0;
            this.btnSalesSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSalesSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSalesSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalesSearch.Location = new System.Drawing.Point(338, 25);
            this.btnSalesSearch.Name = "btnSalesSearch";
            this.btnSalesSearch.Size = new System.Drawing.Size(26, 26);
            this.btnSalesSearch.TabIndex = 15;
            this.btnSalesSearch.TabStop = false;
            this.btnSalesSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalesSearch.UseVisualStyleBackColor = true;
            this.btnSalesSearch.Click += new System.EventHandler(this.btnSalesSearch_Click);
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCode.Location = new System.Drawing.Point(9, 28);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(48, 18);
            this.lblCode.TabIndex = 17;
            this.lblCode.Text = "Sales";
            // 
            // txtSalesAcc
            // 
            this.txtSalesAcc.Font = new System.Drawing.Font("Arial", 12F);
            this.txtSalesAcc.Location = new System.Drawing.Point(128, 25);
            this.txtSalesAcc.Name = "txtSalesAcc";
            this.txtSalesAcc.Size = new System.Drawing.Size(204, 26);
            this.txtSalesAcc.TabIndex = 1;
            this.txtSalesAcc.TextChanged += new System.EventHandler(this.txtSalesAcc_TextChanged);
            this.txtSalesAcc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSalesAcc_KeyDown);
            // 
            // txtSalesAccName
            // 
            this.txtSalesAccName.Font = new System.Drawing.Font("Arial", 12F);
            this.txtSalesAccName.Location = new System.Drawing.Point(370, 25);
            this.txtSalesAccName.Name = "txtSalesAccName";
            this.txtSalesAccName.ReadOnly = true;
            this.txtSalesAccName.Size = new System.Drawing.Size(344, 26);
            this.txtSalesAccName.TabIndex = 18;
            this.txtSalesAccName.TabStop = false;
            // 
            // txtPurchaseAccName
            // 
            this.txtPurchaseAccName.Font = new System.Drawing.Font("Arial", 12F);
            this.txtPurchaseAccName.Location = new System.Drawing.Point(370, 57);
            this.txtPurchaseAccName.Name = "txtPurchaseAccName";
            this.txtPurchaseAccName.ReadOnly = true;
            this.txtPurchaseAccName.Size = new System.Drawing.Size(344, 26);
            this.txtPurchaseAccName.TabIndex = 22;
            this.txtPurchaseAccName.TabStop = false;
            // 
            // btnPurhaseSearch
            // 
            this.btnPurhaseSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPurhaseSearch.BackgroundImage")));
            this.btnPurhaseSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPurhaseSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPurhaseSearch.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnPurhaseSearch.FlatAppearance.BorderSize = 0;
            this.btnPurhaseSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPurhaseSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPurhaseSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPurhaseSearch.Location = new System.Drawing.Point(338, 57);
            this.btnPurhaseSearch.Name = "btnPurhaseSearch";
            this.btnPurhaseSearch.Size = new System.Drawing.Size(26, 26);
            this.btnPurhaseSearch.TabIndex = 19;
            this.btnPurhaseSearch.TabStop = false;
            this.btnPurhaseSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPurhaseSearch.UseVisualStyleBackColor = true;
            this.btnPurhaseSearch.Click += new System.EventHandler(this.btnPurhaseSearch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 18);
            this.label2.TabIndex = 21;
            this.label2.Text = "Purchase";
            // 
            // txtPurchaseAcc
            // 
            this.txtPurchaseAcc.Font = new System.Drawing.Font("Arial", 12F);
            this.txtPurchaseAcc.Location = new System.Drawing.Point(128, 57);
            this.txtPurchaseAcc.Name = "txtPurchaseAcc";
            this.txtPurchaseAcc.Size = new System.Drawing.Size(204, 26);
            this.txtPurchaseAcc.TabIndex = 2;
            this.txtPurchaseAcc.TextChanged += new System.EventHandler(this.txtPurchaseAcc_TextChanged);
            this.txtPurchaseAcc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPurchaseAcc_KeyDown);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(387, 299);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(49, 18);
            this.label21.TabIndex = 186;
            this.label21.Text = "Close";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(321, 299);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(59, 18);
            this.label22.TabIndex = 185;
            this.label22.Text = "Update";
            // 
            // btnClear
            // 
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(232)))), ((int)(((byte)(244)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.Location = new System.Drawing.Point(389, 260);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(44, 36);
            this.btnClear.TabIndex = 14;
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(232)))), ((int)(((byte)(244)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.Location = new System.Drawing.Point(324, 260);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(44, 36);
            this.btnUpdate.TabIndex = 13;
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtCashAccName
            // 
            this.txtCashAccName.Font = new System.Drawing.Font("Arial", 12F);
            this.txtCashAccName.Location = new System.Drawing.Point(370, 89);
            this.txtCashAccName.Name = "txtCashAccName";
            this.txtCashAccName.ReadOnly = true;
            this.txtCashAccName.Size = new System.Drawing.Size(344, 26);
            this.txtCashAccName.TabIndex = 194;
            this.txtCashAccName.TabStop = false;
            // 
            // btnCashSearch
            // 
            this.btnCashSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCashSearch.BackgroundImage")));
            this.btnCashSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCashSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCashSearch.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnCashSearch.FlatAppearance.BorderSize = 0;
            this.btnCashSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCashSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCashSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCashSearch.Location = new System.Drawing.Point(338, 89);
            this.btnCashSearch.Name = "btnCashSearch";
            this.btnCashSearch.Size = new System.Drawing.Size(26, 26);
            this.btnCashSearch.TabIndex = 192;
            this.btnCashSearch.TabStop = false;
            this.btnCashSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCashSearch.UseVisualStyleBackColor = true;
            this.btnCashSearch.Click += new System.EventHandler(this.btnCashSearch_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(9, 92);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 18);
            this.label9.TabIndex = 193;
            this.label9.Text = "Cash";
            // 
            // txtCashAcc
            // 
            this.txtCashAcc.Font = new System.Drawing.Font("Arial", 12F);
            this.txtCashAcc.Location = new System.Drawing.Point(128, 89);
            this.txtCashAcc.Name = "txtCashAcc";
            this.txtCashAcc.Size = new System.Drawing.Size(204, 26);
            this.txtCashAcc.TabIndex = 3;
            this.txtCashAcc.TextChanged += new System.EventHandler(this.txtCashAcc_TextChanged);
            this.txtCashAcc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCashAcc_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPurchaseGSTAccName);
            this.groupBox1.Controls.Add(this.btnPurchaseGSTSearch);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtPurchaseGSTAcc);
            this.groupBox1.Controls.Add(this.txtSaleGSTAccName);
            this.groupBox1.Controls.Add(this.btnSaleGSTSearch);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtSaleGSTAcc);
            this.groupBox1.Controls.Add(this.txtSalesAcc);
            this.groupBox1.Controls.Add(this.txtCashAccName);
            this.groupBox1.Controls.Add(this.lblCode);
            this.groupBox1.Controls.Add(this.btnCashSearch);
            this.groupBox1.Controls.Add(this.btnSalesSearch);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtSalesAccName);
            this.groupBox1.Controls.Add(this.txtCashAcc);
            this.groupBox1.Controls.Add(this.txtPurchaseAcc);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnPurhaseSearch);
            this.groupBox1.Controls.Add(this.txtPurchaseAccName);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 12F);
            this.groupBox1.Location = new System.Drawing.Point(16, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(730, 207);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtSaleGSTAccName
            // 
            this.txtSaleGSTAccName.Font = new System.Drawing.Font("Arial", 12F);
            this.txtSaleGSTAccName.Location = new System.Drawing.Point(370, 121);
            this.txtSaleGSTAccName.Name = "txtSaleGSTAccName";
            this.txtSaleGSTAccName.ReadOnly = true;
            this.txtSaleGSTAccName.Size = new System.Drawing.Size(344, 26);
            this.txtSaleGSTAccName.TabIndex = 198;
            this.txtSaleGSTAccName.TabStop = false;
            // 
            // btnSaleGSTSearch
            // 
            this.btnSaleGSTSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSaleGSTSearch.BackgroundImage")));
            this.btnSaleGSTSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSaleGSTSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaleGSTSearch.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnSaleGSTSearch.FlatAppearance.BorderSize = 0;
            this.btnSaleGSTSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSaleGSTSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSaleGSTSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaleGSTSearch.Location = new System.Drawing.Point(338, 121);
            this.btnSaleGSTSearch.Name = "btnSaleGSTSearch";
            this.btnSaleGSTSearch.Size = new System.Drawing.Size(26, 26);
            this.btnSaleGSTSearch.TabIndex = 196;
            this.btnSaleGSTSearch.TabStop = false;
            this.btnSaleGSTSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSaleGSTSearch.UseVisualStyleBackColor = true;
            this.btnSaleGSTSearch.Click += new System.EventHandler(this.btnGSTSearch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 18);
            this.label3.TabIndex = 197;
            this.label3.Text = "Sales GST";
            // 
            // txtSaleGSTAcc
            // 
            this.txtSaleGSTAcc.Font = new System.Drawing.Font("Arial", 12F);
            this.txtSaleGSTAcc.Location = new System.Drawing.Point(128, 121);
            this.txtSaleGSTAcc.Name = "txtSaleGSTAcc";
            this.txtSaleGSTAcc.Size = new System.Drawing.Size(204, 26);
            this.txtSaleGSTAcc.TabIndex = 195;
            this.txtSaleGSTAcc.TextChanged += new System.EventHandler(this.txtGSTAcc_TextChanged);
            this.txtSaleGSTAcc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGSTAcc_KeyDown);
            // 
            // txtPurchaseGSTAccName
            // 
            this.txtPurchaseGSTAccName.Font = new System.Drawing.Font("Arial", 12F);
            this.txtPurchaseGSTAccName.Location = new System.Drawing.Point(370, 153);
            this.txtPurchaseGSTAccName.Name = "txtPurchaseGSTAccName";
            this.txtPurchaseGSTAccName.ReadOnly = true;
            this.txtPurchaseGSTAccName.Size = new System.Drawing.Size(344, 26);
            this.txtPurchaseGSTAccName.TabIndex = 202;
            this.txtPurchaseGSTAccName.TabStop = false;
            // 
            // btnPurchaseGSTSearch
            // 
            this.btnPurchaseGSTSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPurchaseGSTSearch.BackgroundImage")));
            this.btnPurchaseGSTSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPurchaseGSTSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPurchaseGSTSearch.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnPurchaseGSTSearch.FlatAppearance.BorderSize = 0;
            this.btnPurchaseGSTSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPurchaseGSTSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPurchaseGSTSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPurchaseGSTSearch.Location = new System.Drawing.Point(338, 153);
            this.btnPurchaseGSTSearch.Name = "btnPurchaseGSTSearch";
            this.btnPurchaseGSTSearch.Size = new System.Drawing.Size(26, 26);
            this.btnPurchaseGSTSearch.TabIndex = 200;
            this.btnPurchaseGSTSearch.TabStop = false;
            this.btnPurchaseGSTSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPurchaseGSTSearch.UseVisualStyleBackColor = true;
            this.btnPurchaseGSTSearch.Click += new System.EventHandler(this.btnPurchaseGSTSearch_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 18);
            this.label4.TabIndex = 201;
            this.label4.Text = "Purchase GST";
            // 
            // txtPurchaseGSTAcc
            // 
            this.txtPurchaseGSTAcc.Font = new System.Drawing.Font("Arial", 12F);
            this.txtPurchaseGSTAcc.Location = new System.Drawing.Point(128, 153);
            this.txtPurchaseGSTAcc.Name = "txtPurchaseGSTAcc";
            this.txtPurchaseGSTAcc.Size = new System.Drawing.Size(204, 26);
            this.txtPurchaseGSTAcc.TabIndex = 199;
            this.txtPurchaseGSTAcc.TextChanged += new System.EventHandler(this.txtPurchaseGSTAcc_TextChanged);
            this.txtPurchaseGSTAcc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPurchaseGSTAcc_KeyDown);
            // 
            // frmAccountConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 332);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAccountConfig";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmAccountConfig_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAccountConfig_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSalesSearch;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.TextBox txtSalesAcc;
        private System.Windows.Forms.TextBox txtSalesAccName;
        private System.Windows.Forms.TextBox txtPurchaseAccName;
        private System.Windows.Forms.Button btnPurhaseSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPurchaseAcc;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtCashAccName;
        private System.Windows.Forms.Button btnCashSearch;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCashAcc;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtSaleGSTAccName;
        private System.Windows.Forms.Button btnSaleGSTSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSaleGSTAcc;
        private System.Windows.Forms.TextBox txtPurchaseGSTAccName;
        private System.Windows.Forms.Button btnPurchaseGSTSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPurchaseGSTAcc;
    }
