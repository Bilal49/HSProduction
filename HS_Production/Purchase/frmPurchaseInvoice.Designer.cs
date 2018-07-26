namespace FIL
{
    partial class frmPurchaseInvoice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPurchaseInvoice));
            this.label3 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtVendorCode = new System.Windows.Forms.TextBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.btnRPOSearch = new System.Windows.Forms.Button();
            this.txtRPONo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.gvDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.GCDetail = new DevExpress.XtraGrid.GridControl();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.txtDiscountPercent = new System.Windows.Forms.TextBox();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.txtNetTotal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtVendorName = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnPost = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnMinInvioceNo = new System.Windows.Forms.Button();
            this.btnMaxInvioceNo = new System.Windows.Forms.Button();
            this.btnPrevInvioceNo = new System.Windows.Forms.Button();
            this.btnNextInvioceNo = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpRPODate = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.txtEmployeeName = new System.Windows.Forms.TextBox();
            this.btnESearch = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtEmployeeCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPINo = new System.Windows.Forms.TextBox();
            this.txtVendorAccName = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtVendorAccCode = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtVoucherNo = new System.Windows.Forms.TextBox();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtGSTAmount = new System.Windows.Forms.TextBox();
            this.txtGSTPerc = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lblPosted = new System.Windows.Forms.Label();
            this.chkPrice = new System.Windows.Forms.CheckBox();
            this.label29 = new System.Windows.Forms.Label();
            this.btnUnPost = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCDetail)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 24F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(141)))), ((int)(((byte)(188)))));
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(279, 36);
            this.label3.TabIndex = 62;
            this.label3.Text = "Purchase Invoice";
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(507, 638);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(54, 18);
            this.label20.TabIndex = 70;
            this.label20.Text = "Delete";
            // 
            // label21
            // 
            this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(447, 638);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(46, 18);
            this.label21.TabIndex = 69;
            this.label21.Text = "Clear";
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(378, 638);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(59, 18);
            this.label22.TabIndex = 68;
            this.label22.Text = "Update";
            // 
            // label23
            // 
            this.label23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(323, 638);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(37, 18);
            this.label23.TabIndex = 67;
            this.label23.Text = "Add";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(232)))), ((int)(((byte)(244)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(319, 599);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(44, 36);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btnAdd, "Add (F3)");
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(232)))), ((int)(((byte)(244)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.Location = new System.Drawing.Point(385, 599);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(44, 36);
            this.btnUpdate.TabIndex = 13;
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btnUpdate, "Update (F3)");
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(232)))), ((int)(((byte)(244)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.Location = new System.Drawing.Point(448, 599);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(44, 36);
            this.btnClear.TabIndex = 14;
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btnClear, "Clear (F6)");
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(232)))), ((int)(((byte)(244)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(512, 599);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(44, 36);
            this.btnDelete.TabIndex = 15;
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btnDelete, "Delete");
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtVendorCode
            // 
            this.txtVendorCode.Font = new System.Drawing.Font("Arial", 12F);
            this.txtVendorCode.Location = new System.Drawing.Point(162, 151);
            this.txtVendorCode.Name = "txtVendorCode";
            this.txtVendorCode.ReadOnly = true;
            this.txtVendorCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtVendorCode.Size = new System.Drawing.Size(176, 26);
            this.txtVendorCode.TabIndex = 6;
            this.txtVendorCode.TabStop = false;
            this.txtVendorCode.TextChanged += new System.EventHandler(this.txtVendorCode_TextChanged);
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCode.Location = new System.Drawing.Point(18, 154);
            this.lblCode.Name = "lblCode";
            this.lblCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblCode.Size = new System.Drawing.Size(101, 18);
            this.lblCode.TabIndex = 73;
            this.lblCode.Text = "Vendor Code";
            // 
            // btnRPOSearch
            // 
            this.btnRPOSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRPOSearch.BackgroundImage")));
            this.btnRPOSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRPOSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRPOSearch.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnRPOSearch.FlatAppearance.BorderSize = 0;
            this.btnRPOSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRPOSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRPOSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRPOSearch.Location = new System.Drawing.Point(344, 90);
            this.btnRPOSearch.Name = "btnRPOSearch";
            this.btnRPOSearch.Size = new System.Drawing.Size(26, 26);
            this.btnRPOSearch.TabIndex = 3;
            this.btnRPOSearch.TabStop = false;
            this.btnRPOSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRPOSearch.UseVisualStyleBackColor = true;
            this.btnRPOSearch.Click += new System.EventHandler(this.btnCSearch_Click);
            // 
            // txtRPONo
            // 
            this.txtRPONo.Font = new System.Drawing.Font("Arial", 12F);
            this.txtRPONo.Location = new System.Drawing.Point(162, 87);
            this.txtRPONo.Name = "txtRPONo";
            this.txtRPONo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtRPONo.Size = new System.Drawing.Size(176, 26);
            this.txtRPONo.TabIndex = 2;
            this.txtRPONo.TextChanged += new System.EventHandler(this.txtPONo_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 90);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(113, 18);
            this.label1.TabIndex = 76;
            this.label1.Text = "Receving PO #";
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.BackgroundImage")));
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(344, 55);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(26, 26);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 125);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(51, 18);
            this.label2.TabIndex = 77;
            this.label2.Text = "Dated";
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpDate.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(162, 119);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpDate.Size = new System.Drawing.Size(176, 26);
            this.dtpDate.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 249);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(71, 18);
            this.label5.TabIndex = 81;
            this.label5.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Font = new System.Drawing.Font("Arial", 12F);
            this.txtRemarks.Location = new System.Drawing.Point(162, 246);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtRemarks.Size = new System.Drawing.Size(821, 26);
            this.txtRemarks.TabIndex = 8;
            // 
            // gvDetail
            // 
            this.gvDetail.GridControl = this.GCDetail;
            this.gvDetail.Name = "gvDetail";
            this.gvDetail.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvDetail.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gvDetail.OptionsNavigation.AutoFocusNewRow = true;
            this.gvDetail.OptionsNavigation.EnterMoveNextColumn = true;
            this.gvDetail.OptionsNavigation.UseTabKey = false;
            this.gvDetail.OptionsView.ColumnAutoWidth = false;
            this.gvDetail.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gvDetail.OptionsView.ShowAutoFilterRow = true;
            this.gvDetail.OptionsView.ShowGroupPanel = false;
            this.gvDetail.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvDetail_FocusedRowChanged);
            this.gvDetail.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvDetail_CellValueChanged);
            this.gvDetail.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvDetail_CellValueChanging);
            this.gvDetail.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gvDetail_InvalidRowException);
            this.gvDetail.RowDeleting += new DevExpress.Data.RowDeletingEventHandler(this.gvDetail_RowDeleting);
            this.gvDetail.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gvDetail_ValidateRow);
            this.gvDetail.GotFocus += new System.EventHandler(this.gvDetail_GotFocus);
            this.gvDetail.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gvDetail_ValidatingEditor);
            this.gvDetail.RowCountChanged += new System.EventHandler(this.gvDetail_RowCountChanged);
            this.gvDetail.InvalidValueException += new DevExpress.XtraEditors.Controls.InvalidValueExceptionEventHandler(this.gvDetail_InvalidValueException);
            // 
            // GCDetail
            // 
            this.GCDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GCDetail.Location = new System.Drawing.Point(18, 278);
            this.GCDetail.MainView = this.gvDetail;
            this.GCDetail.Name = "GCDetail";
            this.GCDetail.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.GCDetail.Size = new System.Drawing.Size(965, 243);
            this.GCDetail.TabIndex = 6;
            this.GCDetail.UseEmbeddedNavigator = true;
            this.GCDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDetail});
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalAmount.Font = new System.Drawing.Font("Arial", 12F);
            this.txtTotalAmount.Location = new System.Drawing.Point(814, 527);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotalAmount.Size = new System.Drawing.Size(170, 26);
            this.txtTotalAmount.TabIndex = 84;
            this.txtTotalAmount.TabStop = false;
            this.txtTotalAmount.TextChanged += new System.EventHandler(this.txtTotalAmount_TextChanged);
            // 
            // txtDiscountPercent
            // 
            this.txtDiscountPercent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiscountPercent.Font = new System.Drawing.Font("Arial", 12F);
            this.txtDiscountPercent.Location = new System.Drawing.Point(533, 530);
            this.txtDiscountPercent.Name = "txtDiscountPercent";
            this.txtDiscountPercent.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDiscountPercent.Size = new System.Drawing.Size(153, 26);
            this.txtDiscountPercent.TabIndex = 10;
            this.txtDiscountPercent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiscountPercent_KeyPress);
            this.txtDiscountPercent.Leave += new System.EventHandler(this.txtDiscountPercent_Leave);
            // 
            // txtDiscount
            // 
            this.txtDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiscount.Font = new System.Drawing.Font("Arial", 12F);
            this.txtDiscount.Location = new System.Drawing.Point(533, 561);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDiscount.Size = new System.Drawing.Size(153, 26);
            this.txtDiscount.TabIndex = 11;
            this.txtDiscount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiscountPercent_KeyPress);
            this.txtDiscount.Leave += new System.EventHandler(this.txtDiscount_Leave);
            // 
            // txtNetTotal
            // 
            this.txtNetTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNetTotal.Font = new System.Drawing.Font("Arial", 12F);
            this.txtNetTotal.Location = new System.Drawing.Point(814, 622);
            this.txtNetTotal.Name = "txtNetTotal";
            this.txtNetTotal.ReadOnly = true;
            this.txtNetTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNetTotal.Size = new System.Drawing.Size(170, 26);
            this.txtNetTotal.TabIndex = 87;
            this.txtNetTotal.TabStop = false;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(712, 530);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 18);
            this.label6.TabIndex = 88;
            this.label6.Text = "Total Amount";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(431, 533);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label7.Size = new System.Drawing.Size(58, 18);
            this.label7.TabIndex = 89;
            this.label7.Text = "Disc %";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(431, 564);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 18);
            this.label8.TabIndex = 90;
            this.label8.Text = "Discount";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(712, 625);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 18);
            this.label9.TabIndex = 91;
            this.label9.Text = "Net Total";
            // 
            // txtVendorName
            // 
            this.txtVendorName.Font = new System.Drawing.Font("Arial", 12F);
            this.txtVendorName.Location = new System.Drawing.Point(344, 151);
            this.txtVendorName.Name = "txtVendorName";
            this.txtVendorName.ReadOnly = true;
            this.txtVendorName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtVendorName.Size = new System.Drawing.Size(326, 26);
            this.txtVendorName.TabIndex = 7;
            this.txtVendorName.TabStop = false;
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
            this.btnPrint.Location = new System.Drawing.Point(572, 599);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(44, 36);
            this.btnPrint.TabIndex = 16;
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btnPrint, "Delete");
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnPost
            // 
            this.btnPost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPost.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPost.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnPost.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnPost.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(232)))), ((int)(((byte)(244)))));
            this.btnPost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPost.Image = global::FIL.Properties.Resources.load_321;
            this.btnPost.Location = new System.Drawing.Point(631, 599);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(44, 36);
            this.btnPost.TabIndex = 223;
            this.btnPost.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btnPost, "Delete");
            this.btnPost.UseVisualStyleBackColor = true;
            this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnMinInvioceNo);
            this.groupBox1.Controls.Add(this.btnMaxInvioceNo);
            this.groupBox1.Controls.Add(this.btnPrevInvioceNo);
            this.groupBox1.Controls.Add(this.btnNextInvioceNo);
            this.groupBox1.Location = new System.Drawing.Point(376, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(112, 35);
            this.groupBox1.TabIndex = 133;
            this.groupBox1.TabStop = false;
            // 
            // btnMinInvioceNo
            // 
            this.btnMinInvioceNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinInvioceNo.FlatAppearance.BorderSize = 0;
            this.btnMinInvioceNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinInvioceNo.Image = global::FIL.Properties.Resources.forward2;
            this.btnMinInvioceNo.Location = new System.Drawing.Point(2, 7);
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
            this.btnMaxInvioceNo.Location = new System.Drawing.Point(83, 8);
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
            this.btnPrevInvioceNo.Location = new System.Drawing.Point(32, 7);
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
            this.btnNextInvioceNo.Location = new System.Drawing.Point(58, 7);
            this.btnNextInvioceNo.Name = "btnNextInvioceNo";
            this.btnNextInvioceNo.Size = new System.Drawing.Size(24, 24);
            this.btnNextInvioceNo.TabIndex = 129;
            this.btnNextInvioceNo.TabStop = false;
            this.btnNextInvioceNo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNextInvioceNo.UseVisualStyleBackColor = false;
            this.btnNextInvioceNo.Click += new System.EventHandler(this.btnNextInvioceNo_Click);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(576, 638);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 18);
            this.label10.TabIndex = 138;
            this.label10.Text = "Print";
            // 
            // dtpRPODate
            // 
            this.dtpRPODate.CustomFormat = "dd-MMM-yyyy";
            this.dtpRPODate.Enabled = false;
            this.dtpRPODate.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpRPODate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRPODate.Location = new System.Drawing.Point(494, 87);
            this.dtpRPODate.Name = "dtpRPODate";
            this.dtpRPODate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpRPODate.Size = new System.Drawing.Size(176, 26);
            this.dtpRPODate.TabIndex = 222;
            this.dtpRPODate.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(377, 94);
            this.label11.Name = "label11";
            this.label11.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label11.Size = new System.Drawing.Size(80, 18);
            this.label11.TabIndex = 140;
            this.label11.Text = "RPO Date";
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.Font = new System.Drawing.Font("Arial", 12F);
            this.txtEmployeeName.Location = new System.Drawing.Point(376, 215);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.ReadOnly = true;
            this.txtEmployeeName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtEmployeeName.Size = new System.Drawing.Size(294, 26);
            this.txtEmployeeName.TabIndex = 144;
            this.txtEmployeeName.TabStop = false;
            // 
            // btnESearch
            // 
            this.btnESearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnESearch.BackgroundImage")));
            this.btnESearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnESearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnESearch.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnESearch.FlatAppearance.BorderSize = 0;
            this.btnESearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnESearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnESearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnESearch.Location = new System.Drawing.Point(344, 215);
            this.btnESearch.Name = "btnESearch";
            this.btnESearch.Size = new System.Drawing.Size(26, 26);
            this.btnESearch.TabIndex = 7;
            this.btnESearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnESearch.UseVisualStyleBackColor = true;
            this.btnESearch.Click += new System.EventHandler(this.btnESearch_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(18, 218);
            this.label12.Name = "label12";
            this.label12.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label12.Size = new System.Drawing.Size(121, 18);
            this.label12.TabIndex = 143;
            this.label12.Text = "Employee Code";
            // 
            // txtEmployeeCode
            // 
            this.txtEmployeeCode.Font = new System.Drawing.Font("Arial", 12F);
            this.txtEmployeeCode.Location = new System.Drawing.Point(162, 215);
            this.txtEmployeeCode.Name = "txtEmployeeCode";
            this.txtEmployeeCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtEmployeeCode.Size = new System.Drawing.Size(176, 26);
            this.txtEmployeeCode.TabIndex = 6;
            this.txtEmployeeCode.TextChanged += new System.EventHandler(this.txtEmployeeCode_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 59);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(143, 18);
            this.label4.TabIndex = 146;
            this.label4.Text = "Purchase Invoice  #";
            // 
            // txtPINo
            // 
            this.txtPINo.Font = new System.Drawing.Font("Arial", 12F);
            this.txtPINo.Location = new System.Drawing.Point(162, 55);
            this.txtPINo.Name = "txtPINo";
            this.txtPINo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPINo.Size = new System.Drawing.Size(176, 26);
            this.txtPINo.TabIndex = 0;
            this.txtPINo.TextChanged += new System.EventHandler(this.txtPINo_TextChanged);
            // 
            // txtVendorAccName
            // 
            this.txtVendorAccName.Font = new System.Drawing.Font("Arial", 12F);
            this.txtVendorAccName.Location = new System.Drawing.Point(344, 183);
            this.txtVendorAccName.Name = "txtVendorAccName";
            this.txtVendorAccName.ReadOnly = true;
            this.txtVendorAccName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtVendorAccName.Size = new System.Drawing.Size(326, 26);
            this.txtVendorAccName.TabIndex = 152;
            this.txtVendorAccName.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(18, 186);
            this.label14.Name = "label14";
            this.label14.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label14.Size = new System.Drawing.Size(97, 18);
            this.label14.TabIndex = 151;
            this.label14.Text = "Vendor COA";
            // 
            // txtVendorAccCode
            // 
            this.txtVendorAccCode.Font = new System.Drawing.Font("Arial", 12F);
            this.txtVendorAccCode.Location = new System.Drawing.Point(162, 183);
            this.txtVendorAccCode.Name = "txtVendorAccCode";
            this.txtVendorAccCode.ReadOnly = true;
            this.txtVendorAccCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtVendorAccCode.Size = new System.Drawing.Size(176, 26);
            this.txtVendorAccCode.TabIndex = 150;
            this.txtVendorAccCode.TabStop = false;
            this.txtVendorAccCode.TextChanged += new System.EventHandler(this.txtVendorAccCode_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(676, 191);
            this.label15.Name = "label15";
            this.label15.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label15.Size = new System.Drawing.Size(85, 18);
            this.label15.TabIndex = 154;
            this.label15.Text = "VoucherNo";
            // 
            // txtVoucherNo
            // 
            this.txtVoucherNo.Font = new System.Drawing.Font("Arial", 12F);
            this.txtVoucherNo.Location = new System.Drawing.Point(676, 214);
            this.txtVoucherNo.Name = "txtVoucherNo";
            this.txtVoucherNo.ReadOnly = true;
            this.txtVoucherNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtVoucherNo.Size = new System.Drawing.Size(176, 26);
            this.txtVoucherNo.TabIndex = 153;
            this.txtVoucherNo.TabStop = false;
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpDueDate.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDueDate.Location = new System.Drawing.Point(494, 119);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpDueDate.Size = new System.Drawing.Size(176, 26);
            this.dtpDueDate.TabIndex = 5;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(377, 126);
            this.label16.Name = "label16";
            this.label16.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label16.Size = new System.Drawing.Size(75, 18);
            this.label16.TabIndex = 156;
            this.label16.Text = "Due Date";
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(712, 593);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(96, 18);
            this.label17.TabIndex = 160;
            this.label17.Text = "GST Amount";
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(712, 562);
            this.label18.Name = "label18";
            this.label18.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label18.Size = new System.Drawing.Size(58, 18);
            this.label18.TabIndex = 159;
            this.label18.Text = "GST %";
            // 
            // txtGSTAmount
            // 
            this.txtGSTAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGSTAmount.Font = new System.Drawing.Font("Arial", 12F);
            this.txtGSTAmount.Location = new System.Drawing.Point(814, 590);
            this.txtGSTAmount.Name = "txtGSTAmount";
            this.txtGSTAmount.ReadOnly = true;
            this.txtGSTAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtGSTAmount.Size = new System.Drawing.Size(170, 26);
            this.txtGSTAmount.TabIndex = 158;
            // 
            // txtGSTPerc
            // 
            this.txtGSTPerc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGSTPerc.Font = new System.Drawing.Font("Arial", 12F);
            this.txtGSTPerc.Location = new System.Drawing.Point(814, 559);
            this.txtGSTPerc.Name = "txtGSTPerc";
            this.txtGSTPerc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtGSTPerc.Size = new System.Drawing.Size(170, 26);
            this.txtGSTPerc.TabIndex = 9;
            this.txtGSTPerc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiscountPercent_KeyPress);
            this.txtGSTPerc.Leave += new System.EventHandler(this.txtGSTPerc_Leave);
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(632, 638);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 19);
            this.label13.TabIndex = 224;
            this.label13.Text = "Post";
            // 
            // lblPosted
            // 
            this.lblPosted.AutoSize = true;
            this.lblPosted.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold);
            this.lblPosted.ForeColor = System.Drawing.Color.Red;
            this.lblPosted.Location = new System.Drawing.Point(503, 40);
            this.lblPosted.Name = "lblPosted";
            this.lblPosted.Size = new System.Drawing.Size(146, 37);
            this.lblPosted.TabIndex = 836;
            this.lblPosted.Text = "POSTED";
            this.lblPosted.Visible = false;
            // 
            // chkPrice
            // 
            this.chkPrice.AutoSize = true;
            this.chkPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPrice.Location = new System.Drawing.Point(678, 156);
            this.chkPrice.Name = "chkPrice";
            this.chkPrice.Size = new System.Drawing.Size(222, 17);
            this.chkPrice.TabIndex = 837;
            this.chkPrice.TabStop = false;
            this.chkPrice.Text = "Update Cost Price in Product Form";
            this.chkPrice.UseVisualStyleBackColor = true;
            // 
            // label29
            // 
            this.label29.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(7, 641);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(66, 19);
            this.label29.TabIndex = 861;
            this.label29.Text = "UnPost";
            // 
            // btnUnPost
            // 
            this.btnUnPost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUnPost.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUnPost.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnUnPost.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnUnPost.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(232)))), ((int)(((byte)(244)))));
            this.btnUnPost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnPost.Image = global::FIL.Properties.Resources.unpost;
            this.btnUnPost.Location = new System.Drawing.Point(18, 599);
            this.btnUnPost.Name = "btnUnPost";
            this.btnUnPost.Size = new System.Drawing.Size(44, 36);
            this.btnUnPost.TabIndex = 860;
            this.btnUnPost.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUnPost.UseVisualStyleBackColor = true;
            this.btnUnPost.Click += new System.EventHandler(this.btnUnPost_Click);
            // 
            // frmPurchaseInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 670);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.btnUnPost);
            this.Controls.Add(this.chkPrice);
            this.Controls.Add(this.lblPosted);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnPost);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txtGSTAmount);
            this.Controls.Add(this.txtGSTPerc);
            this.Controls.Add(this.dtpDueDate);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtVoucherNo);
            this.Controls.Add(this.txtVendorAccName);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtVendorAccCode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPINo);
            this.Controls.Add(this.txtEmployeeName);
            this.Controls.Add(this.btnESearch);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtEmployeeCode);
            this.Controls.Add(this.dtpRPODate);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtVendorName);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtNetTotal);
            this.Controls.Add(this.txtDiscount);
            this.Controls.Add(this.txtDiscountPercent);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.GCDetail);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRPONo);
            this.Controls.Add(this.btnRPOSearch);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.txtVendorCode);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label3);
            this.KeyPreview = true;
            this.Name = "frmPurchaseInvoice";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmDirectSales_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDirectPurchase_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gvDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCDetail)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtVendorCode;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Button btnRPOSearch;
        private System.Windows.Forms.TextBox txtRPONo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRemarks;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDetail;
        private DevExpress.XtraGrid.GridControl GCDetail;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.TextBox txtDiscountPercent;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.TextBox txtNetTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtVendorName;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnMinInvioceNo;
        private System.Windows.Forms.Button btnMaxInvioceNo;
        private System.Windows.Forms.Button btnPrevInvioceNo;
        private System.Windows.Forms.Button btnNextInvioceNo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DateTimePicker dtpRPODate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtEmployeeName;
        private System.Windows.Forms.Button btnESearch;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtEmployeeCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPINo;
        private System.Windows.Forms.TextBox txtVendorAccName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtVendorAccCode;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtVoucherNo;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtGSTAmount;
        private System.Windows.Forms.TextBox txtGSTPerc;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnPost;
        private System.Windows.Forms.Label lblPosted;
        private System.Windows.Forms.CheckBox chkPrice;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Button btnUnPost;
    }
}