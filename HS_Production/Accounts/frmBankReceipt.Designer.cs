namespace FIL
{
    partial class frmBankReceipt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBankReceipt));
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
            this.txtReceiptVoucherCode = new System.Windows.Forms.TextBox();
            this.dtpVoucher = new System.Windows.Forms.DateTimePicker();
            this.lblVoucherDate = new System.Windows.Forms.Label();
            this.btnCustomerSearch = new System.Windows.Forms.Button();
            this.lblCustomerCode = new System.Windows.Forms.Label();
            this.txtCustomerCode = new System.Windows.Forms.TextBox();
            this.txtNaration = new System.Windows.Forms.TextBox();
            this.lblNarration = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtAccCode = new System.Windows.Forms.TextBox();
            this.txtAccName = new System.Windows.Forms.TextBox();
            this.txtBankAccName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBankAcc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBACSearch = new System.Windows.Forms.Button();
            this.txtBACTitle = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBankAccountCode = new System.Windows.Forms.TextBox();
            this.dtpCheque = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbChequeBank = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtChequeNumber = new System.Windows.Forms.TextBox();
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
            this.lblHeaderEn.Size = new System.Drawing.Size(356, 36);
            this.lblHeaderEn.TabIndex = 64;
            this.lblHeaderEn.Text = "Bank Receipt Voucher";
            // 
            // txtBalance
            // 
            this.txtBalance.Font = new System.Drawing.Font("Arial", 12F);
            this.txtBalance.Location = new System.Drawing.Point(565, 134);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.ReadOnly = true;
            this.txtBalance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBalance.Size = new System.Drawing.Size(93, 26);
            this.txtBalance.TabIndex = 147;
            this.txtBalance.TabStop = false;
            this.txtBalance.Text = "0.00";
            // 
            // Balance
            // 
            this.Balance.AutoSize = true;
            this.Balance.Font = new System.Drawing.Font("Arial", 12F);
            this.Balance.Location = new System.Drawing.Point(494, 138);
            this.Balance.Name = "Balance";
            this.Balance.Size = new System.Drawing.Size(65, 18);
            this.Balance.TabIndex = 148;
            this.Balance.Text = "Balance";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.Location = new System.Drawing.Point(15, 265);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(61, 18);
            this.lblAmount.TabIndex = 142;
            this.lblAmount.Text = "Amount";
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Arial", 12F);
            this.txtAmount.Location = new System.Drawing.Point(138, 261);
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
            this.btnDelete.Location = new System.Drawing.Point(417, 415);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(44, 36);
            this.btnDelete.TabIndex = 15;
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
            this.btnClear.Location = new System.Drawing.Point(349, 415);
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
            this.btnUpdate.Location = new System.Drawing.Point(284, 415);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(44, 36);
            this.btnUpdate.TabIndex = 13;
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
            this.btnAdd.Location = new System.Drawing.Point(219, 415);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(44, 36);
            this.btnAdd.TabIndex = 12;
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
            this.btnVoucherSearch.Location = new System.Drawing.Point(277, 70);
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
            this.lblReceiptVoucherCode.Location = new System.Drawing.Point(15, 74);
            this.lblReceiptVoucherCode.Name = "lblReceiptVoucherCode";
            this.lblReceiptVoucherCode.Size = new System.Drawing.Size(78, 18);
            this.lblReceiptVoucherCode.TabIndex = 132;
            this.lblReceiptVoucherCode.Text = "Voucher #";
            // 
            // txtReceiptVoucherCode
            // 
            this.txtReceiptVoucherCode.Font = new System.Drawing.Font("Arial", 12F);
            this.txtReceiptVoucherCode.Location = new System.Drawing.Point(138, 70);
            this.txtReceiptVoucherCode.Name = "txtReceiptVoucherCode";
            this.txtReceiptVoucherCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtReceiptVoucherCode.Size = new System.Drawing.Size(133, 26);
            this.txtReceiptVoucherCode.TabIndex = 1;
            this.txtReceiptVoucherCode.TextChanged += new System.EventHandler(this.txtReceiptVoucherCode_TextChanged);
            this.txtReceiptVoucherCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtReceiptVoucherCode_KeyDown);
            this.txtReceiptVoucherCode.Leave += new System.EventHandler(this.txtReceiptVoucherCode_Leave);
            // 
            // dtpVoucher
            // 
            this.dtpVoucher.CustomFormat = "dd-MMM-yyyy";
            this.dtpVoucher.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpVoucher.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpVoucher.Location = new System.Drawing.Point(138, 102);
            this.dtpVoucher.Name = "dtpVoucher";
            this.dtpVoucher.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpVoucher.Size = new System.Drawing.Size(133, 26);
            this.dtpVoucher.TabIndex = 2;
            // 
            // lblVoucherDate
            // 
            this.lblVoucherDate.AutoSize = true;
            this.lblVoucherDate.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVoucherDate.Location = new System.Drawing.Point(15, 106);
            this.lblVoucherDate.Name = "lblVoucherDate";
            this.lblVoucherDate.Size = new System.Drawing.Size(51, 18);
            this.lblVoucherDate.TabIndex = 155;
            this.lblVoucherDate.Text = "Dated";
            // 
            // btnCustomerSearch
            // 
            this.btnCustomerSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCustomerSearch.BackgroundImage")));
            this.btnCustomerSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCustomerSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCustomerSearch.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnCustomerSearch.FlatAppearance.BorderSize = 0;
            this.btnCustomerSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCustomerSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCustomerSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomerSearch.Location = new System.Drawing.Point(277, 134);
            this.btnCustomerSearch.Name = "btnCustomerSearch";
            this.btnCustomerSearch.Size = new System.Drawing.Size(26, 26);
            this.btnCustomerSearch.TabIndex = 4;
            this.btnCustomerSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCustomerSearch.UseVisualStyleBackColor = true;
            this.btnCustomerSearch.Click += new System.EventHandler(this.btnCustomerSearch_Click);
            // 
            // lblCustomerCode
            // 
            this.lblCustomerCode.AutoSize = true;
            this.lblCustomerCode.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerCode.Location = new System.Drawing.Point(15, 138);
            this.lblCustomerCode.Name = "lblCustomerCode";
            this.lblCustomerCode.Size = new System.Drawing.Size(119, 18);
            this.lblCustomerCode.TabIndex = 158;
            this.lblCustomerCode.Text = "Customer Code";
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.Font = new System.Drawing.Font("Arial", 12F);
            this.txtCustomerCode.Location = new System.Drawing.Point(138, 134);
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCustomerCode.Size = new System.Drawing.Size(133, 26);
            this.txtCustomerCode.TabIndex = 3;
            this.txtCustomerCode.TextChanged += new System.EventHandler(this.txtCustomerCode_TextChanged);
            this.txtCustomerCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtReceiptVoucherCode_KeyDown);
            // 
            // txtNaration
            // 
            this.txtNaration.Font = new System.Drawing.Font("Arial", 12F);
            this.txtNaration.Location = new System.Drawing.Point(138, 325);
            this.txtNaration.Multiline = true;
            this.txtNaration.Name = "txtNaration";
            this.txtNaration.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtNaration.Size = new System.Drawing.Size(507, 75);
            this.txtNaration.TabIndex = 11;
            // 
            // lblNarration
            // 
            this.lblNarration.AutoSize = true;
            this.lblNarration.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNarration.Location = new System.Drawing.Point(15, 327);
            this.lblNarration.Name = "lblNarration";
            this.lblNarration.Size = new System.Drawing.Size(72, 18);
            this.lblNarration.TabIndex = 160;
            this.lblNarration.Text = "Narration";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Font = new System.Drawing.Font("Arial", 12F);
            this.txtCustomerName.Location = new System.Drawing.Point(309, 134);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCustomerName.Size = new System.Drawing.Size(179, 26);
            this.txtCustomerName.TabIndex = 163;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(411, 454);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(54, 18);
            this.label20.TabIndex = 167;
            this.label20.Text = "Delete";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(347, 454);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(46, 18);
            this.label21.TabIndex = 166;
            this.label21.Text = "Clear";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(281, 454);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(59, 18);
            this.label22.TabIndex = 165;
            this.label22.Text = "Update";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(225, 454);
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
            this.groupBox1.Location = new System.Drawing.Point(320, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(112, 35);
            this.groupBox1.TabIndex = 169;
            this.groupBox1.TabStop = false;
            // 
            // btnMinInvioceNo
            // 
            this.btnMinInvioceNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinInvioceNo.FlatAppearance.BorderSize = 0;
            this.btnMinInvioceNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinInvioceNo.Image = global::FIL.Properties.Resources.forward2;
            this.btnMinInvioceNo.Location = new System.Drawing.Point(1, 8);
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
            this.btnMaxInvioceNo.Location = new System.Drawing.Point(84, 8);
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
            this.btnPrevInvioceNo.Location = new System.Drawing.Point(28, 8);
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
            this.btnNextInvioceNo.Location = new System.Drawing.Point(54, 8);
            this.btnNextInvioceNo.Name = "btnNextInvioceNo";
            this.btnNextInvioceNo.Size = new System.Drawing.Size(24, 24);
            this.btnNextInvioceNo.TabIndex = 129;
            this.btnNextInvioceNo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNextInvioceNo.UseVisualStyleBackColor = false;
            this.btnNextInvioceNo.Click += new System.EventHandler(this.btnNextInvioceNo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 18);
            this.label1.TabIndex = 171;
            this.label1.Text = "Account Code";
            // 
            // txtAccCode
            // 
            this.txtAccCode.Font = new System.Drawing.Font("Arial", 12F);
            this.txtAccCode.Location = new System.Drawing.Point(138, 166);
            this.txtAccCode.Name = "txtAccCode";
            this.txtAccCode.ReadOnly = true;
            this.txtAccCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtAccCode.Size = new System.Drawing.Size(133, 26);
            this.txtAccCode.TabIndex = 170;
            this.txtAccCode.TabStop = false;
            this.txtAccCode.TextChanged += new System.EventHandler(this.txtAccCode_TextChanged);
            // 
            // txtAccName
            // 
            this.txtAccName.Font = new System.Drawing.Font("Arial", 12F);
            this.txtAccName.Location = new System.Drawing.Point(277, 166);
            this.txtAccName.Name = "txtAccName";
            this.txtAccName.ReadOnly = true;
            this.txtAccName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtAccName.Size = new System.Drawing.Size(368, 26);
            this.txtAccName.TabIndex = 172;
            this.txtAccName.TabStop = false;
            // 
            // txtBankAccName
            // 
            this.txtBankAccName.Font = new System.Drawing.Font("Arial", 12F);
            this.txtBankAccName.Location = new System.Drawing.Point(277, 229);
            this.txtBankAccName.Name = "txtBankAccName";
            this.txtBankAccName.ReadOnly = true;
            this.txtBankAccName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBankAccName.Size = new System.Drawing.Size(368, 26);
            this.txtBankAccName.TabIndex = 182;
            this.txtBankAccName.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 233);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 18);
            this.label2.TabIndex = 181;
            this.label2.Text = "Account Code";
            // 
            // txtBankAcc
            // 
            this.txtBankAcc.Font = new System.Drawing.Font("Arial", 12F);
            this.txtBankAcc.Location = new System.Drawing.Point(138, 229);
            this.txtBankAcc.Name = "txtBankAcc";
            this.txtBankAcc.ReadOnly = true;
            this.txtBankAcc.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBankAcc.Size = new System.Drawing.Size(133, 26);
            this.txtBankAcc.TabIndex = 180;
            this.txtBankAcc.TabStop = false;
            this.txtBankAcc.TextChanged += new System.EventHandler(this.txtCashAcc_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(644, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 19);
            this.label3.TabIndex = 184;
            this.label3.Text = "( D )";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(644, 232);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 19);
            this.label4.TabIndex = 185;
            this.label4.Text = "( C )";
            // 
            // btnBACSearch
            // 
            this.btnBACSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBACSearch.BackgroundImage")));
            this.btnBACSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBACSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBACSearch.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnBACSearch.FlatAppearance.BorderSize = 0;
            this.btnBACSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnBACSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnBACSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBACSearch.Location = new System.Drawing.Point(277, 198);
            this.btnBACSearch.Name = "btnBACSearch";
            this.btnBACSearch.Size = new System.Drawing.Size(26, 26);
            this.btnBACSearch.TabIndex = 6;
            this.btnBACSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBACSearch.UseVisualStyleBackColor = true;
            this.btnBACSearch.Click += new System.EventHandler(this.btnBACSearch_Click);
            // 
            // txtBACTitle
            // 
            this.txtBACTitle.Font = new System.Drawing.Font("Arial", 12F);
            this.txtBACTitle.Location = new System.Drawing.Point(310, 198);
            this.txtBACTitle.Name = "txtBACTitle";
            this.txtBACTitle.ReadOnly = true;
            this.txtBACTitle.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBACTitle.Size = new System.Drawing.Size(335, 26);
            this.txtBACTitle.TabIndex = 188;
            this.txtBACTitle.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 18);
            this.label5.TabIndex = 187;
            this.label5.Text = "Bank A/C";
            // 
            // txtBankAccountCode
            // 
            this.txtBankAccountCode.Font = new System.Drawing.Font("Arial", 12F);
            this.txtBankAccountCode.Location = new System.Drawing.Point(138, 198);
            this.txtBankAccountCode.Name = "txtBankAccountCode";
            this.txtBankAccountCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBankAccountCode.Size = new System.Drawing.Size(133, 26);
            this.txtBankAccountCode.TabIndex = 5;
            this.txtBankAccountCode.TextChanged += new System.EventHandler(this.txtBankAccountCode_TextChanged);
            // 
            // dtpCheque
            // 
            this.dtpCheque.CustomFormat = "dd-MMM-yyyy";
            this.dtpCheque.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpCheque.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCheque.Location = new System.Drawing.Point(138, 293);
            this.dtpCheque.Name = "dtpCheque";
            this.dtpCheque.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpCheque.Size = new System.Drawing.Size(133, 26);
            this.dtpCheque.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(15, 297);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 18);
            this.label6.TabIndex = 191;
            this.label6.Text = "Cheque Date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(277, 297);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 18);
            this.label7.TabIndex = 192;
            this.label7.Text = "Cheque Bank";
            // 
            // cmbChequeBank
            // 
            this.cmbChequeBank.Font = new System.Drawing.Font("Arial", 12F);
            this.cmbChequeBank.FormattingEnabled = true;
            this.cmbChequeBank.Location = new System.Drawing.Point(386, 293);
            this.cmbChequeBank.Name = "cmbChequeBank";
            this.cmbChequeBank.Size = new System.Drawing.Size(259, 26);
            this.cmbChequeBank.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(277, 265);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 18);
            this.label8.TabIndex = 194;
            this.label8.Text = "Cheque #";
            // 
            // txtChequeNumber
            // 
            this.txtChequeNumber.Font = new System.Drawing.Font("Arial", 12F);
            this.txtChequeNumber.Location = new System.Drawing.Point(386, 261);
            this.txtChequeNumber.Name = "txtChequeNumber";
            this.txtChequeNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtChequeNumber.Size = new System.Drawing.Size(259, 26);
            this.txtChequeNumber.TabIndex = 8;
            // 
            // frmBankReceipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 498);
            this.Controls.Add(this.txtChequeNumber);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbChequeBank);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtpCheque);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnBACSearch);
            this.Controls.Add(this.txtBACTitle);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBankAccountCode);
            this.Controls.Add(this.txtBankAccName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBankAcc);
            this.Controls.Add(this.txtAccName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAccCode);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.lblNarration);
            this.Controls.Add(this.txtNaration);
            this.Controls.Add(this.btnCustomerSearch);
            this.Controls.Add(this.lblCustomerCode);
            this.Controls.Add(this.txtCustomerCode);
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
            this.Controls.Add(this.txtReceiptVoucherCode);
            this.Controls.Add(this.lblHeaderEn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBankReceipt";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmCashReceiptVoucher_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCashReceiptVoucher_KeyDown);
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
        private System.Windows.Forms.TextBox txtReceiptVoucherCode;
        private System.Windows.Forms.DateTimePicker dtpVoucher;
        private System.Windows.Forms.Label lblVoucherDate;
        private System.Windows.Forms.Button btnCustomerSearch;
        private System.Windows.Forms.Label lblCustomerCode;
        private System.Windows.Forms.TextBox txtCustomerCode;
        private System.Windows.Forms.TextBox txtNaration;
        private System.Windows.Forms.Label lblNarration;
        private System.Windows.Forms.TextBox txtCustomerName;
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAccCode;
        private System.Windows.Forms.TextBox txtAccName;
        private System.Windows.Forms.TextBox txtBankAccName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBankAcc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBACSearch;
        private System.Windows.Forms.TextBox txtBACTitle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBankAccountCode;
        private System.Windows.Forms.DateTimePicker dtpCheque;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbChequeBank;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtChequeNumber;
    }
}