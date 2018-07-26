namespace FIL
{
    partial class frmCashPayment
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCashPayment));
            this.lblHeaderEn = new System.Windows.Forms.Label();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.Balance = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnVoucherSearch = new System.Windows.Forms.Button();
            this.lblReceiptVoucherCode = new System.Windows.Forms.Label();
            this.txtCashPaymentCode = new System.Windows.Forms.TextBox();
            this.dtpVoucher = new System.Windows.Forms.DateTimePicker();
            this.lblVoucherDate = new System.Windows.Forms.Label();
            this.btnVendorSearch = new System.Windows.Forms.Button();
            this.lblVendorCode = new System.Windows.Forms.Label();
            this.txtVendorCode = new System.Windows.Forms.TextBox();
            this.txtNaration = new System.Windows.Forms.TextBox();
            this.lblNarration = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.txtVendorName = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnMinInvioceNo = new System.Windows.Forms.Button();
            this.btnMaxInvioceNo = new System.Windows.Forms.Button();
            this.btnPrevInvioceNo = new System.Windows.Forms.Button();
            this.btnNextInvioceNo = new System.Windows.Forms.Button();
            this.txtAccName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAccCode = new System.Windows.Forms.TextBox();
            this.txtCashAccName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCashAcc = new System.Windows.Forms.TextBox();
            this.btnCOASearch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnACSearch = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeaderEn
            // 
            this.lblHeaderEn.AutoSize = true;
            this.lblHeaderEn.Font = new System.Drawing.Font("Arial", 24F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))));
            this.lblHeaderEn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(141)))), ((int)(((byte)(188)))));
            this.lblHeaderEn.Location = new System.Drawing.Point(12, 18);
            this.lblHeaderEn.Name = "lblHeaderEn";
            this.lblHeaderEn.Size = new System.Drawing.Size(373, 36);
            this.lblHeaderEn.TabIndex = 64;
            this.lblHeaderEn.Text = "Cash Payment Voucher";
            // 
            // txtBalance
            // 
            this.txtBalance.Font = new System.Drawing.Font("Arial", 12F);
            this.txtBalance.Location = new System.Drawing.Point(620, 43);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.ReadOnly = true;
            this.txtBalance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBalance.Size = new System.Drawing.Size(43, 26);
            this.txtBalance.TabIndex = 147;
            this.txtBalance.TabStop = false;
            this.txtBalance.Text = "0.00";
            this.txtBalance.Visible = false;
            // 
            // Balance
            // 
            this.Balance.AutoSize = true;
            this.Balance.Font = new System.Drawing.Font("Arial", 12F);
            this.Balance.Location = new System.Drawing.Point(549, 43);
            this.Balance.Name = "Balance";
            this.Balance.Size = new System.Drawing.Size(65, 18);
            this.Balance.TabIndex = 148;
            this.Balance.Text = "Balance";
            this.Balance.Visible = false;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.Location = new System.Drawing.Point(12, 243);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(61, 18);
            this.lblAmount.TabIndex = 142;
            this.lblAmount.Text = "Amount";
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Arial", 12F);
            this.txtAmount.Location = new System.Drawing.Point(122, 208);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtAmount.Size = new System.Drawing.Size(133, 26);
            this.txtAmount.TabIndex = 7;
            this.txtAmount.Text = "0";
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            // 
            // btnDelete
            // 
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(232)))), ((int)(((byte)(244)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(408, 359);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(44, 36);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(232)))), ((int)(((byte)(244)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.Location = new System.Drawing.Point(340, 359);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(44, 36);
            this.btnClear.TabIndex = 12;
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
            this.btnUpdate.Location = new System.Drawing.Point(275, 359);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(44, 36);
            this.btnUpdate.TabIndex = 11;
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(232)))), ((int)(((byte)(244)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(210, 359);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(44, 36);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
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
            this.btnVoucherSearch.Location = new System.Drawing.Point(261, 80);
            this.btnVoucherSearch.Name = "btnVoucherSearch";
            this.btnVoucherSearch.Size = new System.Drawing.Size(26, 26);
            this.btnVoucherSearch.TabIndex = 0;
            this.btnVoucherSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVoucherSearch.UseVisualStyleBackColor = true;
            this.btnVoucherSearch.Click += new System.EventHandler(this.btnVoucherSearch_Click);
            // 
            // lblReceiptVoucherCode
            // 
            this.lblReceiptVoucherCode.AutoSize = true;
            this.lblReceiptVoucherCode.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceiptVoucherCode.Location = new System.Drawing.Point(12, 84);
            this.lblReceiptVoucherCode.Name = "lblReceiptVoucherCode";
            this.lblReceiptVoucherCode.Size = new System.Drawing.Size(78, 18);
            this.lblReceiptVoucherCode.TabIndex = 132;
            this.lblReceiptVoucherCode.Text = "Voucher #";
            // 
            // txtCashPaymentCode
            // 
            this.txtCashPaymentCode.Font = new System.Drawing.Font("Arial", 12F);
            this.txtCashPaymentCode.Location = new System.Drawing.Point(122, 80);
            this.txtCashPaymentCode.Name = "txtCashPaymentCode";
            this.txtCashPaymentCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCashPaymentCode.Size = new System.Drawing.Size(133, 26);
            this.txtCashPaymentCode.TabIndex = 1;
            this.txtCashPaymentCode.TextChanged += new System.EventHandler(this.txtReceiptVoucherCode_TextChanged);
            this.txtCashPaymentCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtReceiptVoucherCode_KeyDown);
            this.txtCashPaymentCode.Leave += new System.EventHandler(this.txtReceiptVoucherCode_Leave);
            // 
            // dtpVoucher
            // 
            this.dtpVoucher.CustomFormat = "dd-MMM-yyyy";
            this.dtpVoucher.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpVoucher.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpVoucher.Location = new System.Drawing.Point(122, 112);
            this.dtpVoucher.Name = "dtpVoucher";
            this.dtpVoucher.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpVoucher.Size = new System.Drawing.Size(133, 26);
            this.dtpVoucher.TabIndex = 2;
            // 
            // lblVoucherDate
            // 
            this.lblVoucherDate.AutoSize = true;
            this.lblVoucherDate.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVoucherDate.Location = new System.Drawing.Point(12, 116);
            this.lblVoucherDate.Name = "lblVoucherDate";
            this.lblVoucherDate.Size = new System.Drawing.Size(51, 18);
            this.lblVoucherDate.TabIndex = 155;
            this.lblVoucherDate.Text = "Dated";
            // 
            // btnVendorSearch
            // 
            this.btnVendorSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVendorSearch.BackgroundImage")));
            this.btnVendorSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVendorSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVendorSearch.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnVendorSearch.FlatAppearance.BorderSize = 0;
            this.btnVendorSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnVendorSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnVendorSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVendorSearch.Location = new System.Drawing.Point(552, 12);
            this.btnVendorSearch.Name = "btnVendorSearch";
            this.btnVendorSearch.Size = new System.Drawing.Size(26, 26);
            this.btnVendorSearch.TabIndex = 4;
            this.btnVendorSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVendorSearch.UseVisualStyleBackColor = true;
            this.btnVendorSearch.Visible = false;
            this.btnVendorSearch.Click += new System.EventHandler(this.btnCustomerSearch_Click);
            // 
            // lblVendorCode
            // 
            this.lblVendorCode.AutoSize = true;
            this.lblVendorCode.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVendorCode.Location = new System.Drawing.Point(404, 16);
            this.lblVendorCode.Name = "lblVendorCode";
            this.lblVendorCode.Size = new System.Drawing.Size(101, 18);
            this.lblVendorCode.TabIndex = 158;
            this.lblVendorCode.Text = "Vendor Code";
            this.lblVendorCode.Visible = false;
            // 
            // txtVendorCode
            // 
            this.txtVendorCode.Font = new System.Drawing.Font("Arial", 12F);
            this.txtVendorCode.Location = new System.Drawing.Point(514, 12);
            this.txtVendorCode.Name = "txtVendorCode";
            this.txtVendorCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtVendorCode.Size = new System.Drawing.Size(30, 26);
            this.txtVendorCode.TabIndex = 3;
            this.txtVendorCode.Visible = false;
            this.txtVendorCode.TextChanged += new System.EventHandler(this.txtCustomerCode_TextChanged);
            this.txtVendorCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtReceiptVoucherCode_KeyDown);
            // 
            // txtNaration
            // 
            this.txtNaration.Font = new System.Drawing.Font("Arial", 12F);
            this.txtNaration.Location = new System.Drawing.Point(122, 240);
            this.txtNaration.Multiline = true;
            this.txtNaration.Name = "txtNaration";
            this.txtNaration.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtNaration.Size = new System.Drawing.Size(550, 75);
            this.txtNaration.TabIndex = 8;
            // 
            // lblNarration
            // 
            this.lblNarration.AutoSize = true;
            this.lblNarration.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNarration.Location = new System.Drawing.Point(12, 243);
            this.lblNarration.Name = "lblNarration";
            this.lblNarration.Size = new System.Drawing.Size(67, 18);
            this.lblNarration.TabIndex = 160;
            this.lblNarration.Text = "Naration";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Font = new System.Drawing.Font("Arial", 12F);
            this.txtRemarks.Location = new System.Drawing.Point(122, 321);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtRemarks.Size = new System.Drawing.Size(550, 26);
            this.txtRemarks.TabIndex = 9;
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemarks.Location = new System.Drawing.Point(12, 324);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(71, 18);
            this.lblRemarks.TabIndex = 162;
            this.lblRemarks.Text = "Remarks";
            // 
            // txtVendorName
            // 
            this.txtVendorName.Font = new System.Drawing.Font("Arial", 12F);
            this.txtVendorName.Location = new System.Drawing.Point(585, 12);
            this.txtVendorName.Name = "txtVendorName";
            this.txtVendorName.ReadOnly = true;
            this.txtVendorName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtVendorName.Size = new System.Drawing.Size(25, 26);
            this.txtVendorName.TabIndex = 163;
            this.txtVendorName.Visible = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(402, 398);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(54, 18);
            this.label20.TabIndex = 167;
            this.label20.Text = "Delete";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(338, 398);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(46, 18);
            this.label21.TabIndex = 166;
            this.label21.Text = "Clear";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(272, 398);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(59, 18);
            this.label22.TabIndex = 165;
            this.label22.Text = "Update";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(216, 398);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(37, 18);
            this.label23.TabIndex = 164;
            this.label23.Text = "Add";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnMinInvioceNo);
            this.groupBox1.Controls.Add(this.btnMaxInvioceNo);
            this.groupBox1.Controls.Add(this.btnPrevInvioceNo);
            this.groupBox1.Controls.Add(this.btnNextInvioceNo);
            this.groupBox1.Location = new System.Drawing.Point(294, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(112, 35);
            this.groupBox1.TabIndex = 168;
            this.groupBox1.TabStop = false;
            // 
            // btnMinInvioceNo
            // 
            this.btnMinInvioceNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinInvioceNo.FlatAppearance.BorderSize = 0;
            this.btnMinInvioceNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinInvioceNo.Image = global::FIL.Properties.Resources.forward2;
            this.btnMinInvioceNo.Location = new System.Drawing.Point(3, 7);
            this.btnMinInvioceNo.Name = "btnMinInvioceNo";
            this.btnMinInvioceNo.Size = new System.Drawing.Size(24, 24);
            this.btnMinInvioceNo.TabIndex = 131;
            this.btnMinInvioceNo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMinInvioceNo.UseVisualStyleBackColor = false;
            this.btnMinInvioceNo.Click += new System.EventHandler(this.btnMinInvioceNo_Click);
            // 
            // btnMaxInvioceNo
            // 
            this.btnMaxInvioceNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaxInvioceNo.FlatAppearance.BorderSize = 0;
            this.btnMaxInvioceNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaxInvioceNo.Image = global::FIL.Properties.Resources.forward1;
            this.btnMaxInvioceNo.Location = new System.Drawing.Point(85, 7);
            this.btnMaxInvioceNo.Name = "btnMaxInvioceNo";
            this.btnMaxInvioceNo.Size = new System.Drawing.Size(24, 24);
            this.btnMaxInvioceNo.TabIndex = 128;
            this.btnMaxInvioceNo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMaxInvioceNo.UseVisualStyleBackColor = false;
            this.btnMaxInvioceNo.Click += new System.EventHandler(this.btnMaxInvioceNo_Click);
            // 
            // btnPrevInvioceNo
            // 
            this.btnPrevInvioceNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrevInvioceNo.FlatAppearance.BorderSize = 0;
            this.btnPrevInvioceNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevInvioceNo.Image = global::FIL.Properties.Resources.forward4;
            this.btnPrevInvioceNo.Location = new System.Drawing.Point(31, 8);
            this.btnPrevInvioceNo.Name = "btnPrevInvioceNo";
            this.btnPrevInvioceNo.Size = new System.Drawing.Size(24, 24);
            this.btnPrevInvioceNo.TabIndex = 130;
            this.btnPrevInvioceNo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPrevInvioceNo.UseVisualStyleBackColor = false;
            this.btnPrevInvioceNo.Click += new System.EventHandler(this.btnPrevInvioceNo_Click);
            // 
            // btnNextInvioceNo
            // 
            this.btnNextInvioceNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNextInvioceNo.FlatAppearance.BorderSize = 0;
            this.btnNextInvioceNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextInvioceNo.Image = global::FIL.Properties.Resources.forward3;
            this.btnNextInvioceNo.Location = new System.Drawing.Point(57, 8);
            this.btnNextInvioceNo.Name = "btnNextInvioceNo";
            this.btnNextInvioceNo.Size = new System.Drawing.Size(24, 24);
            this.btnNextInvioceNo.TabIndex = 129;
            this.btnNextInvioceNo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNextInvioceNo.UseVisualStyleBackColor = false;
            this.btnNextInvioceNo.Click += new System.EventHandler(this.btnNextInvioceNo_Click);
            // 
            // txtAccName
            // 
            this.txtAccName.Font = new System.Drawing.Font("Arial", 12F);
            this.txtAccName.Location = new System.Drawing.Point(294, 144);
            this.txtAccName.Name = "txtAccName";
            this.txtAccName.ReadOnly = true;
            this.txtAccName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtAccName.Size = new System.Drawing.Size(335, 26);
            this.txtAccName.TabIndex = 175;
            this.txtAccName.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 18);
            this.label1.TabIndex = 174;
            this.label1.Text = "Account Code";
            // 
            // txtAccCode
            // 
            this.txtAccCode.Font = new System.Drawing.Font("Arial", 12F);
            this.txtAccCode.Location = new System.Drawing.Point(122, 144);
            this.txtAccCode.Name = "txtAccCode";
            this.txtAccCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtAccCode.Size = new System.Drawing.Size(133, 26);
            this.txtAccCode.TabIndex = 3;
            this.txtAccCode.TabStop = false;
            this.txtAccCode.TextChanged += new System.EventHandler(this.txtAccCode_TextChanged);
            // 
            // txtCashAccName
            // 
            this.txtCashAccName.Font = new System.Drawing.Font("Arial", 12F);
            this.txtCashAccName.Location = new System.Drawing.Point(294, 176);
            this.txtCashAccName.Name = "txtCashAccName";
            this.txtCashAccName.ReadOnly = true;
            this.txtCashAccName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCashAccName.Size = new System.Drawing.Size(335, 26);
            this.txtCashAccName.TabIndex = 178;
            this.txtCashAccName.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 18);
            this.label2.TabIndex = 177;
            this.label2.Text = "Cash A/C";
            // 
            // txtCashAcc
            // 
            this.txtCashAcc.Font = new System.Drawing.Font("Arial", 12F);
            this.txtCashAcc.Location = new System.Drawing.Point(122, 176);
            this.txtCashAcc.Name = "txtCashAcc";
            this.txtCashAcc.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCashAcc.Size = new System.Drawing.Size(133, 26);
            this.txtCashAcc.TabIndex = 5;
            this.txtCashAcc.TabStop = false;
            this.txtCashAcc.TextChanged += new System.EventHandler(this.txtCashAcc_TextChanged);
            // 
            // btnCOASearch
            // 
            this.btnCOASearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCOASearch.BackgroundImage")));
            this.btnCOASearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCOASearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCOASearch.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnCOASearch.FlatAppearance.BorderSize = 0;
            this.btnCOASearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCOASearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCOASearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCOASearch.Location = new System.Drawing.Point(261, 176);
            this.btnCOASearch.Name = "btnCOASearch";
            this.btnCOASearch.Size = new System.Drawing.Size(26, 26);
            this.btnCOASearch.TabIndex = 6;
            this.btnCOASearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCOASearch.UseVisualStyleBackColor = true;
            this.btnCOASearch.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(635, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 19);
            this.label3.TabIndex = 180;
            this.label3.Text = "( C )";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(635, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 19);
            this.label4.TabIndex = 181;
            this.label4.Text = "( D )";
            // 
            // btnACSearch
            // 
            this.btnACSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnACSearch.BackgroundImage")));
            this.btnACSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnACSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnACSearch.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnACSearch.FlatAppearance.BorderSize = 0;
            this.btnACSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnACSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnACSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnACSearch.Location = new System.Drawing.Point(261, 143);
            this.btnACSearch.Name = "btnACSearch";
            this.btnACSearch.Size = new System.Drawing.Size(26, 26);
            this.btnACSearch.TabIndex = 4;
            this.btnACSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnACSearch.UseVisualStyleBackColor = true;
            this.btnACSearch.Click += new System.EventHandler(this.btnACSearch_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 211);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 18);
            this.label5.TabIndex = 183;
            this.label5.Text = "Amount";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(475, 398);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 18);
            this.label10.TabIndex = 190;
            this.label10.Text = "Print";
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnPrint.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(232)))), ((int)(((byte)(244)))));
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Image = global::FIL.Properties.Resources.Print_32;
            this.btnPrint.Location = new System.Drawing.Point(471, 359);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(44, 36);
            this.btnPrint.TabIndex = 189;
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btnPrint, "Delete");
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // frmCashPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 460);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnACSearch);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCOASearch);
            this.Controls.Add(this.txtCashAccName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCashAcc);
            this.Controls.Add(this.txtAccName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAccCode);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.txtVendorName);
            this.Controls.Add(this.lblRemarks);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.lblNarration);
            this.Controls.Add(this.txtNaration);
            this.Controls.Add(this.btnVendorSearch);
            this.Controls.Add(this.lblVendorCode);
            this.Controls.Add(this.txtVendorCode);
            this.Controls.Add(this.dtpVoucher);
            this.Controls.Add(this.lblVoucherDate);
            this.Controls.Add(this.txtBalance);
            this.Controls.Add(this.Balance);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnVoucherSearch);
            this.Controls.Add(this.lblReceiptVoucherCode);
            this.Controls.Add(this.txtCashPaymentCode);
            this.Controls.Add(this.lblHeaderEn);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCashPayment";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmCashReceiptVoucher_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCashPayment_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeaderEn;
        private System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.Label Balance;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnVoucherSearch;
        private System.Windows.Forms.Label lblReceiptVoucherCode;
        private System.Windows.Forms.TextBox txtCashPaymentCode;
        private System.Windows.Forms.DateTimePicker dtpVoucher;
        private System.Windows.Forms.Label lblVoucherDate;
        private System.Windows.Forms.Button btnVendorSearch;
        private System.Windows.Forms.Label lblVendorCode;
        private System.Windows.Forms.TextBox txtVendorCode;
        private System.Windows.Forms.TextBox txtNaration;
        private System.Windows.Forms.Label lblNarration;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.TextBox txtVendorName;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnMinInvioceNo;
        private System.Windows.Forms.Button btnMaxInvioceNo;
        private System.Windows.Forms.Button btnPrevInvioceNo;
        private System.Windows.Forms.Button btnNextInvioceNo;
        private System.Windows.Forms.TextBox txtAccName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAccCode;
        private System.Windows.Forms.TextBox txtCashAccName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCashAcc;
        private System.Windows.Forms.Button btnCOASearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnACSearch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnPrint;
    }
}