
    partial class frmJournalVoucher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmJournalVoucher));
            this.lblHeaderEn = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnVoucherSearch = new System.Windows.Forms.Button();
            this.lblReceiptVoucherCode = new System.Windows.Forms.Label();
            this.txtJVCode = new System.Windows.Forms.TextBox();
            this.dtpVoucher = new System.Windows.Forms.DateTimePicker();
            this.lblVoucherDate = new System.Windows.Forms.Label();
            this.txtNaration = new System.Windows.Forms.TextBox();
            this.lblNarration = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnPrint = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnMinInvioceNo = new System.Windows.Forms.Button();
            this.btnMaxInvioceNo = new System.Windows.Forms.Button();
            this.btnPrevInvioceNo = new System.Windows.Forms.Button();
            this.btnNextInvioceNo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotalDebit = new System.Windows.Forms.TextBox();
            this.txtTotalCredit = new System.Windows.Forms.TextBox();
            this.GCDetail = new DevExpress.XtraGrid.GridControl();
            this.gvDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblPosted = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpBillDate = new System.Windows.Forms.DateTimePicker();
            this.txtBillNo = new System.Windows.Forms.TextBox();
            this.lblBillDate = new System.Windows.Forms.Label();
            this.lblBillNo = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GCDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetail)).BeginInit();
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
            this.lblHeaderEn.Size = new System.Drawing.Size(267, 36);
            this.lblHeaderEn.TabIndex = 64;
            this.lblHeaderEn.Text = "Journal Voucher";
            // 
            // btnDelete
            // 
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(232)))), ((int)(((byte)(244)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(428, 436);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(44, 36);
            this.btnDelete.TabIndex = 9;
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
            this.btnClear.Location = new System.Drawing.Point(360, 436);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(44, 36);
            this.btnClear.TabIndex = 8;
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
            this.btnUpdate.Location = new System.Drawing.Point(295, 436);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(44, 36);
            this.btnUpdate.TabIndex = 7;
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
            this.btnAdd.Location = new System.Drawing.Point(230, 436);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(44, 36);
            this.btnAdd.TabIndex = 6;
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
            this.btnVoucherSearch.TabStop = false;
            this.btnVoucherSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVoucherSearch.UseVisualStyleBackColor = true;
            this.btnVoucherSearch.Click += new System.EventHandler(this.btnVoucherSearch_Click);
            // 
            // lblReceiptVoucherCode
            // 
            this.lblReceiptVoucherCode.AutoSize = true;
            this.lblReceiptVoucherCode.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceiptVoucherCode.Location = new System.Drawing.Point(15, 72);
            this.lblReceiptVoucherCode.Name = "lblReceiptVoucherCode";
            this.lblReceiptVoucherCode.Size = new System.Drawing.Size(78, 18);
            this.lblReceiptVoucherCode.TabIndex = 132;
            this.lblReceiptVoucherCode.Text = "Voucher #";
            // 
            // txtJVCode
            // 
            this.txtJVCode.Font = new System.Drawing.Font("Arial", 12F);
            this.txtJVCode.Location = new System.Drawing.Point(138, 70);
            this.txtJVCode.Name = "txtJVCode";
            this.txtJVCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtJVCode.Size = new System.Drawing.Size(133, 26);
            this.txtJVCode.TabIndex = 0;
            this.txtJVCode.TextChanged += new System.EventHandler(this.txtReceiptVoucherCode_TextChanged);
            this.txtJVCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtReceiptVoucherCode_KeyDown);
            this.txtJVCode.Leave += new System.EventHandler(this.txtReceiptVoucherCode_Leave);
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
            this.dtpVoucher.TabIndex = 1;
            this.dtpVoucher.ValueChanged += new System.EventHandler(this.dtpVoucher_ValueChanged);
            // 
            // lblVoucherDate
            // 
            this.lblVoucherDate.AutoSize = true;
            this.lblVoucherDate.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVoucherDate.Location = new System.Drawing.Point(15, 108);
            this.lblVoucherDate.Name = "lblVoucherDate";
            this.lblVoucherDate.Size = new System.Drawing.Size(51, 18);
            this.lblVoucherDate.TabIndex = 155;
            this.lblVoucherDate.Text = "Dated";
            // 
            // txtNaration
            // 
            this.txtNaration.Font = new System.Drawing.Font("Arial", 12F);
            this.txtNaration.Location = new System.Drawing.Point(138, 166);
            this.txtNaration.Multiline = true;
            this.txtNaration.Name = "txtNaration";
            this.txtNaration.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtNaration.Size = new System.Drawing.Size(536, 75);
            this.txtNaration.TabIndex = 4;
            // 
            // lblNarration
            // 
            this.lblNarration.AutoSize = true;
            this.lblNarration.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNarration.Location = new System.Drawing.Point(15, 169);
            this.lblNarration.Name = "lblNarration";
            this.lblNarration.Size = new System.Drawing.Size(72, 18);
            this.lblNarration.TabIndex = 160;
            this.lblNarration.Text = "Narration";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(422, 475);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(54, 18);
            this.label20.TabIndex = 167;
            this.label20.Text = "Delete";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(358, 475);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(46, 18);
            this.label21.TabIndex = 166;
            this.label21.Text = "Clear";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(292, 475);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(59, 18);
            this.label22.TabIndex = 165;
            this.label22.Text = "Update";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(236, 475);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(37, 18);
            this.label23.TabIndex = 164;
            this.label23.Text = "Add";
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
            this.btnPrint.Location = new System.Drawing.Point(491, 436);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(44, 36);
            this.btnPrint.TabIndex = 10;
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btnPrint, "Delete");
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnMinInvioceNo);
            this.groupBox1.Controls.Add(this.btnMaxInvioceNo);
            this.groupBox1.Controls.Add(this.btnPrevInvioceNo);
            this.groupBox1.Controls.Add(this.btnNextInvioceNo);
            this.groupBox1.Location = new System.Drawing.Point(309, 61);
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
            this.btnMinInvioceNo.TabStop = false;
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
            this.btnMaxInvioceNo.TabStop = false;
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
            this.btnPrevInvioceNo.TabStop = false;
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
            this.btnNextInvioceNo.TabStop = false;
            this.btnNextInvioceNo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNextInvioceNo.UseVisualStyleBackColor = false;
            this.btnNextInvioceNo.Click += new System.EventHandler(this.btnNextInvioceNo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(437, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 18);
            this.label1.TabIndex = 170;
            this.label1.Text = "Total Debit";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(437, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 18);
            this.label2.TabIndex = 171;
            this.label2.Text = "Total Credit";
            // 
            // txtTotalDebit
            // 
            this.txtTotalDebit.Font = new System.Drawing.Font("Arial", 12F);
            this.txtTotalDebit.Location = new System.Drawing.Point(525, 68);
            this.txtTotalDebit.Name = "txtTotalDebit";
            this.txtTotalDebit.ReadOnly = true;
            this.txtTotalDebit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTotalDebit.Size = new System.Drawing.Size(149, 26);
            this.txtTotalDebit.TabIndex = 172;
            this.txtTotalDebit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalCredit
            // 
            this.txtTotalCredit.Font = new System.Drawing.Font("Arial", 12F);
            this.txtTotalCredit.Location = new System.Drawing.Point(525, 100);
            this.txtTotalCredit.Name = "txtTotalCredit";
            this.txtTotalCredit.ReadOnly = true;
            this.txtTotalCredit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTotalCredit.Size = new System.Drawing.Size(149, 26);
            this.txtTotalCredit.TabIndex = 173;
            this.txtTotalCredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // GCDetail
            // 
            this.GCDetail.Location = new System.Drawing.Point(18, 247);
            this.GCDetail.MainView = this.gvDetail;
            this.GCDetail.Name = "GCDetail";
            this.GCDetail.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.GCDetail.Size = new System.Drawing.Size(656, 183);
            this.GCDetail.TabIndex = 5;
            this.GCDetail.UseEmbeddedNavigator = true;
            this.GCDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDetail});
            this.GCDetail.Click += new System.EventHandler(this.GCDetail_Click);
            // 
            // gvDetail
            // 
            this.gvDetail.GridControl = this.GCDetail;
            this.gvDetail.Name = "gvDetail";
            this.gvDetail.OptionsNavigation.EnterMoveNextColumn = true;
            this.gvDetail.OptionsNavigation.UseTabKey = false;
            this.gvDetail.OptionsView.ColumnAutoWidth = false;
            this.gvDetail.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gvDetail.OptionsView.ShowGroupPanel = false;
            this.gvDetail.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvDetail_FocusedRowChanged);
            this.gvDetail.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvDetail_CellValueChanged);
            this.gvDetail.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvDetail_CellValueChanging);
            this.gvDetail.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gvDetail_InvalidRowException);
            this.gvDetail.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gvDetail_ValidateRow);
            this.gvDetail.GotFocus += new System.EventHandler(this.gvDetail_GotFocus);
            this.gvDetail.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gvDetail_ValidatingEditor);
            this.gvDetail.RowCountChanged += new System.EventHandler(this.gvDetail_RowCountChanged);
            this.gvDetail.InvalidValueException += new DevExpress.XtraEditors.Controls.InvalidValueExceptionEventHandler(this.gvDetail_InvalidValueException);
            // 
            // lblPosted
            // 
            this.lblPosted.AutoSize = true;
            this.lblPosted.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold);
            this.lblPosted.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblPosted.Location = new System.Drawing.Point(518, 18);
            this.lblPosted.Name = "lblPosted";
            this.lblPosted.Size = new System.Drawing.Size(146, 37);
            this.lblPosted.TabIndex = 175;
            this.lblPosted.Text = "POSTED";
            this.lblPosted.Visible = false;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(495, 475);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 18);
            this.label10.TabIndex = 190;
            this.label10.Text = "Print";
            // 
            // dtpBillDate
            // 
            this.dtpBillDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpBillDate.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpBillDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBillDate.Location = new System.Drawing.Point(525, 134);
            this.dtpBillDate.Name = "dtpBillDate";
            this.dtpBillDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpBillDate.Size = new System.Drawing.Size(148, 26);
            this.dtpBillDate.TabIndex = 3;
            // 
            // txtBillNo
            // 
            this.txtBillNo.Font = new System.Drawing.Font("Arial", 12F);
            this.txtBillNo.Location = new System.Drawing.Point(138, 134);
            this.txtBillNo.Name = "txtBillNo";
            this.txtBillNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBillNo.Size = new System.Drawing.Size(201, 26);
            this.txtBillNo.TabIndex = 2;
            // 
            // lblBillDate
            // 
            this.lblBillDate.AutoSize = true;
            this.lblBillDate.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBillDate.Location = new System.Drawing.Point(437, 138);
            this.lblBillDate.Name = "lblBillDate";
            this.lblBillDate.Size = new System.Drawing.Size(67, 18);
            this.lblBillDate.TabIndex = 208;
            this.lblBillDate.Text = "Bill Date";
            // 
            // lblBillNo
            // 
            this.lblBillNo.AutoSize = true;
            this.lblBillNo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBillNo.Location = new System.Drawing.Point(15, 137);
            this.lblBillNo.Name = "lblBillNo";
            this.lblBillNo.Size = new System.Drawing.Size(57, 18);
            this.lblBillNo.TabIndex = 207;
            this.lblBillNo.Text = "Bill No.";
            // 
            // frmJournalVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 518);
            this.Controls.Add(this.dtpBillDate);
            this.Controls.Add(this.txtBillNo);
            this.Controls.Add(this.lblBillDate);
            this.Controls.Add(this.lblBillNo);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.lblPosted);
            this.Controls.Add(this.GCDetail);
            this.Controls.Add(this.txtTotalCredit);
            this.Controls.Add(this.txtTotalDebit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.lblNarration);
            this.Controls.Add(this.txtNaration);
            this.Controls.Add(this.dtpVoucher);
            this.Controls.Add(this.lblVoucherDate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnVoucherSearch);
            this.Controls.Add(this.lblReceiptVoucherCode);
            this.Controls.Add(this.txtJVCode);
            this.Controls.Add(this.lblHeaderEn);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmJournalVoucher";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmCashReceiptVoucher_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCashReceiptVoucher_KeyDown);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GCDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeaderEn;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnVoucherSearch;
        private System.Windows.Forms.Label lblReceiptVoucherCode;
        private System.Windows.Forms.TextBox txtJVCode;
        private System.Windows.Forms.DateTimePicker dtpVoucher;
        private System.Windows.Forms.Label lblVoucherDate;
        private System.Windows.Forms.TextBox txtNaration;
        private System.Windows.Forms.Label lblNarration;
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTotalDebit;
        private System.Windows.Forms.TextBox txtTotalCredit;
        private DevExpress.XtraGrid.GridControl GCDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDetail;
        private System.Windows.Forms.Label lblPosted;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DateTimePicker dtpBillDate;
        private System.Windows.Forms.TextBox txtBillNo;
        private System.Windows.Forms.Label lblBillDate;
        private System.Windows.Forms.Label lblBillNo;
    }
