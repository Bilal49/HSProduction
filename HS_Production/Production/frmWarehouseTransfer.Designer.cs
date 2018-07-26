namespace FIL
{
    partial class frmWarehouseTransfer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWarehouseTransfer));
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblCityId = new System.Windows.Forms.Label();
            this.txtWTCode = new System.Windows.Forms.TextBox();
            this.lblDelete = new System.Windows.Forms.Label();
            this.lblClear = new System.Windows.Forms.Label();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.lblAdd = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnMinInvioceNo = new System.Windows.Forms.Button();
            this.btnMaxInvioceNo = new System.Windows.Forms.Button();
            this.btnPrevInvioceNo = new System.Windows.Forms.Button();
            this.btnNextInvioceNo = new System.Windows.Forms.Button();
            this.cmbFWarehouse = new System.Windows.Forms.ComboBox();
            this.lblProductName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.GCDetail = new DevExpress.XtraGrid.GridControl();
            this.gvDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.label10 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.txtEmployeeName = new System.Windows.Forms.TextBox();
            this.btnESearch = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtEmployeeCode = new System.Windows.Forms.TextBox();
            this.cmbTWarehouse = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSNo = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSONo = new System.Windows.Forms.TextBox();
            this.txtCName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPONo = new System.Windows.Forms.TextBox();
            this.txtPName = new System.Windows.Forms.TextBox();
            this.btnPSearch = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPCode = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtProcessQty = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkProcess = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBatchNo = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GCDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetail)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 24F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(141)))), ((int)(((byte)(188)))));
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(323, 36);
            this.label3.TabIndex = 153;
            this.label3.Text = "Warehouse Transfer";
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
            this.btnSearch.Location = new System.Drawing.Point(297, 59);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(26, 26);
            this.btnSearch.TabIndex = 159;
            this.btnSearch.TabStop = false;
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
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
            this.btnDelete.Location = new System.Drawing.Point(488, 524);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(44, 36);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
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
            this.btnClear.Location = new System.Drawing.Point(424, 524);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(44, 36);
            this.btnClear.TabIndex = 11;
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
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
            this.btnUpdate.Location = new System.Drawing.Point(361, 524);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(44, 36);
            this.btnUpdate.TabIndex = 10;
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
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
            this.btnAdd.Location = new System.Drawing.Point(295, 524);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(44, 36);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblCityId
            // 
            this.lblCityId.AutoSize = true;
            this.lblCityId.Font = new System.Drawing.Font("Arial", 12F);
            this.lblCityId.Location = new System.Drawing.Point(15, 63);
            this.lblCityId.Name = "lblCityId";
            this.lblCityId.Size = new System.Drawing.Size(47, 18);
            this.lblCityId.TabIndex = 171;
            this.lblCityId.Text = "Code";
            // 
            // txtWTCode
            // 
            this.txtWTCode.Font = new System.Drawing.Font("Arial", 12F);
            this.txtWTCode.Location = new System.Drawing.Point(149, 59);
            this.txtWTCode.Name = "txtWTCode";
            this.txtWTCode.ReadOnly = true;
            this.txtWTCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtWTCode.Size = new System.Drawing.Size(140, 26);
            this.txtWTCode.TabIndex = 0;
            this.txtWTCode.TextChanged += new System.EventHandler(this.txtFormulaId_TextChanged);
            // 
            // lblDelete
            // 
            this.lblDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDelete.AutoSize = true;
            this.lblDelete.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDelete.Location = new System.Drawing.Point(482, 566);
            this.lblDelete.Name = "lblDelete";
            this.lblDelete.Size = new System.Drawing.Size(54, 18);
            this.lblDelete.TabIndex = 170;
            this.lblDelete.Text = "Delete";
            // 
            // lblClear
            // 
            this.lblClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblClear.AutoSize = true;
            this.lblClear.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClear.Location = new System.Drawing.Point(422, 566);
            this.lblClear.Name = "lblClear";
            this.lblClear.Size = new System.Drawing.Size(46, 18);
            this.lblClear.TabIndex = 169;
            this.lblClear.Text = "Clear";
            // 
            // lblUpdate
            // 
            this.lblUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdate.Location = new System.Drawing.Point(353, 566);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(59, 18);
            this.lblUpdate.TabIndex = 168;
            this.lblUpdate.Text = "Update";
            // 
            // lblAdd
            // 
            this.lblAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAdd.AutoSize = true;
            this.lblAdd.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdd.Location = new System.Drawing.Point(298, 566);
            this.lblAdd.Name = "lblAdd";
            this.lblAdd.Size = new System.Drawing.Size(37, 18);
            this.lblAdd.TabIndex = 167;
            this.lblAdd.Text = "Add";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnMinInvioceNo);
            this.groupBox1.Controls.Add(this.btnMaxInvioceNo);
            this.groupBox1.Controls.Add(this.btnPrevInvioceNo);
            this.groupBox1.Controls.Add(this.btnNextInvioceNo);
            this.groupBox1.Location = new System.Drawing.Point(329, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(112, 35);
            this.groupBox1.TabIndex = 172;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // btnMinInvioceNo
            // 
            this.btnMinInvioceNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinInvioceNo.FlatAppearance.BorderSize = 0;
            this.btnMinInvioceNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinInvioceNo.Image = global::FIL.Properties.Resources.forward2;
            this.btnMinInvioceNo.Location = new System.Drawing.Point(2, 8);
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
            this.btnPrevInvioceNo.Location = new System.Drawing.Point(30, 8);
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
            this.btnNextInvioceNo.Location = new System.Drawing.Point(59, 8);
            this.btnNextInvioceNo.Name = "btnNextInvioceNo";
            this.btnNextInvioceNo.Size = new System.Drawing.Size(24, 24);
            this.btnNextInvioceNo.TabIndex = 129;
            this.btnNextInvioceNo.TabStop = false;
            this.btnNextInvioceNo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNextInvioceNo.UseVisualStyleBackColor = false;
            this.btnNextInvioceNo.Click += new System.EventHandler(this.btnNextInvioceNo_Click);
            // 
            // cmbFWarehouse
            // 
            this.cmbFWarehouse.Font = new System.Drawing.Font("Arial", 12F);
            this.cmbFWarehouse.FormattingEnabled = true;
            this.cmbFWarehouse.Location = new System.Drawing.Point(149, 123);
            this.cmbFWarehouse.Name = "cmbFWarehouse";
            this.cmbFWarehouse.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbFWarehouse.Size = new System.Drawing.Size(186, 26);
            this.cmbFWarehouse.TabIndex = 2;
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.Location = new System.Drawing.Point(15, 127);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(83, 18);
            this.lblProductName.TabIndex = 174;
            this.lblProductName.Text = "From Dept";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F);
            this.label1.Location = new System.Drawing.Point(15, 255);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 18);
            this.label1.TabIndex = 176;
            this.label1.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Font = new System.Drawing.Font("Arial", 12F);
            this.txtRemarks.Location = new System.Drawing.Point(149, 251);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtRemarks.Size = new System.Drawing.Size(450, 26);
            this.txtRemarks.TabIndex = 7;
            // 
            // GCDetail
            // 
            this.GCDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GCDetail.Location = new System.Drawing.Point(149, 315);
            this.GCDetail.MainView = this.gvDetail;
            this.GCDetail.Name = "GCDetail";
            this.GCDetail.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.GCDetail.Size = new System.Drawing.Size(883, 203);
            this.GCDetail.TabIndex = 8;
            this.GCDetail.UseEmbeddedNavigator = true;
            this.GCDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDetail});
            // 
            // gvDetail
            // 
            this.gvDetail.GridControl = this.GCDetail;
            this.gvDetail.Name = "gvDetail";
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
            this.gvDetail.InvalidValueException += new DevExpress.XtraEditors.Controls.InvalidValueExceptionEventHandler(this.gvDetail_InvalidValueException);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(551, 566);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 18);
            this.label10.TabIndex = 178;
            this.label10.Text = "Print";
            this.label10.Visible = false;
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
            this.btnPrint.Location = new System.Drawing.Point(547, 524);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(44, 36);
            this.btnPrint.TabIndex = 13;
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Visible = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.Font = new System.Drawing.Font("Arial", 12F);
            this.txtEmployeeName.Location = new System.Drawing.Point(329, 91);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.ReadOnly = true;
            this.txtEmployeeName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtEmployeeName.Size = new System.Drawing.Size(270, 26);
            this.txtEmployeeName.TabIndex = 182;
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
            this.btnESearch.Location = new System.Drawing.Point(297, 91);
            this.btnESearch.Name = "btnESearch";
            this.btnESearch.Size = new System.Drawing.Size(26, 26);
            this.btnESearch.TabIndex = 180;
            this.btnESearch.TabStop = false;
            this.btnESearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnESearch.UseVisualStyleBackColor = true;
            this.btnESearch.Click += new System.EventHandler(this.btnESearch_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(15, 95);
            this.label12.Name = "label12";
            this.label12.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label12.Size = new System.Drawing.Size(78, 18);
            this.label12.TabIndex = 181;
            this.label12.Text = "Employee";
            // 
            // txtEmployeeCode
            // 
            this.txtEmployeeCode.Font = new System.Drawing.Font("Arial", 12F);
            this.txtEmployeeCode.Location = new System.Drawing.Point(149, 91);
            this.txtEmployeeCode.Name = "txtEmployeeCode";
            this.txtEmployeeCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtEmployeeCode.Size = new System.Drawing.Size(140, 26);
            this.txtEmployeeCode.TabIndex = 1;
            this.txtEmployeeCode.TextChanged += new System.EventHandler(this.txtEmployeeCode_TextChanged);
            // 
            // cmbTWarehouse
            // 
            this.cmbTWarehouse.Font = new System.Drawing.Font("Arial", 12F);
            this.cmbTWarehouse.FormattingEnabled = true;
            this.cmbTWarehouse.Location = new System.Drawing.Point(413, 123);
            this.cmbTWarehouse.Name = "cmbTWarehouse";
            this.cmbTWarehouse.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbTWarehouse.Size = new System.Drawing.Size(186, 26);
            this.cmbTWarehouse.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(345, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 18);
            this.label2.TabIndex = 184;
            this.label2.Text = "To Dept";
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpDate.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(149, 187);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpDate.Size = new System.Drawing.Size(140, 26);
            this.dtpDate.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 191);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(51, 18);
            this.label4.TabIndex = 186;
            this.label4.Text = "Dated";
            // 
            // btnSNo
            // 
            this.btnSNo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSNo.BackgroundImage")));
            this.btnSNo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSNo.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnSNo.FlatAppearance.BorderSize = 0;
            this.btnSNo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSNo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSNo.Location = new System.Drawing.Point(297, 155);
            this.btnSNo.Name = "btnSNo";
            this.btnSNo.Size = new System.Drawing.Size(26, 26);
            this.btnSNo.TabIndex = 188;
            this.btnSNo.TabStop = false;
            this.btnSNo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSNo.UseVisualStyleBackColor = true;
            this.btnSNo.Click += new System.EventHandler(this.btnSNo_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 159);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(59, 18);
            this.label5.TabIndex = 189;
            this.label5.Text = "S.O No";
            // 
            // txtSONo
            // 
            this.txtSONo.Font = new System.Drawing.Font("Arial", 12F);
            this.txtSONo.Location = new System.Drawing.Point(149, 155);
            this.txtSONo.Name = "txtSONo";
            this.txtSONo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSONo.Size = new System.Drawing.Size(140, 26);
            this.txtSONo.TabIndex = 4;
            this.txtSONo.TextChanged += new System.EventHandler(this.txtSONo_TextChanged);
            // 
            // txtCName
            // 
            this.txtCName.Font = new System.Drawing.Font("Arial", 12F);
            this.txtCName.Location = new System.Drawing.Point(329, 155);
            this.txtCName.Name = "txtCName";
            this.txtCName.ReadOnly = true;
            this.txtCName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCName.Size = new System.Drawing.Size(270, 26);
            this.txtCName.TabIndex = 190;
            this.txtCName.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(345, 191);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 18);
            this.label6.TabIndex = 191;
            this.label6.Text = "P.O No";
            // 
            // txtPONo
            // 
            this.txtPONo.Font = new System.Drawing.Font("Arial", 12F);
            this.txtPONo.Location = new System.Drawing.Point(413, 187);
            this.txtPONo.Name = "txtPONo";
            this.txtPONo.ReadOnly = true;
            this.txtPONo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPONo.Size = new System.Drawing.Size(186, 26);
            this.txtPONo.TabIndex = 192;
            // 
            // txtPName
            // 
            this.txtPName.Font = new System.Drawing.Font("Arial", 12F);
            this.txtPName.Location = new System.Drawing.Point(329, 219);
            this.txtPName.Name = "txtPName";
            this.txtPName.ReadOnly = true;
            this.txtPName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPName.Size = new System.Drawing.Size(270, 26);
            this.txtPName.TabIndex = 196;
            this.txtPName.TabStop = false;
            // 
            // btnPSearch
            // 
            this.btnPSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPSearch.BackgroundImage")));
            this.btnPSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPSearch.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnPSearch.FlatAppearance.BorderSize = 0;
            this.btnPSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPSearch.Location = new System.Drawing.Point(297, 219);
            this.btnPSearch.Name = "btnPSearch";
            this.btnPSearch.Size = new System.Drawing.Size(26, 26);
            this.btnPSearch.TabIndex = 6;
            this.btnPSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPSearch.UseVisualStyleBackColor = true;
            this.btnPSearch.Click += new System.EventHandler(this.btnPSearch_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(15, 223);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label7.Size = new System.Drawing.Size(98, 18);
            this.label7.TabIndex = 195;
            this.label7.Text = "Article Name";
            // 
            // txtPCode
            // 
            this.txtPCode.Font = new System.Drawing.Font("Arial", 12F);
            this.txtPCode.Location = new System.Drawing.Point(149, 219);
            this.txtPCode.Name = "txtPCode";
            this.txtPCode.ReadOnly = true;
            this.txtPCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPCode.Size = new System.Drawing.Size(140, 26);
            this.txtPCode.TabIndex = 193;
            this.txtPCode.TextChanged += new System.EventHandler(this.txtPCode_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtProcessQty);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.chkProcess);
            this.groupBox2.Location = new System.Drawing.Point(605, 170);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(274, 103);
            this.groupBox2.TabIndex = 197;
            this.groupBox2.TabStop = false;
            // 
            // txtProcessQty
            // 
            this.txtProcessQty.Font = new System.Drawing.Font("Arial", 12F);
            this.txtProcessQty.Location = new System.Drawing.Point(73, 49);
            this.txtProcessQty.Name = "txtProcessQty";
            this.txtProcessQty.ReadOnly = true;
            this.txtProcessQty.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtProcessQty.Size = new System.Drawing.Size(186, 26);
            this.txtProcessQty.TabIndex = 200;
            this.txtProcessQty.TabStop = false;
            this.txtProcessQty.TextChanged += new System.EventHandler(this.txtProcessQty_TextChanged);
            this.txtProcessQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProcessQty_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(5, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 18);
            this.label8.TabIndex = 199;
            this.label8.Text = "Quantity";
            // 
            // chkProcess
            // 
            this.chkProcess.AutoSize = true;
            this.chkProcess.Font = new System.Drawing.Font("Arial", 12F);
            this.chkProcess.Location = new System.Drawing.Point(7, 19);
            this.chkProcess.Name = "chkProcess";
            this.chkProcess.Size = new System.Drawing.Size(171, 22);
            this.chkProcess.TabIndex = 198;
            this.chkProcess.TabStop = false;
            this.chkProcess.Text = "For Processing Start";
            this.chkProcess.UseVisualStyleBackColor = true;
            this.chkProcess.CheckedChanged += new System.EventHandler(this.chkProcess_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 12F);
            this.label9.Location = new System.Drawing.Point(15, 287);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 18);
            this.label9.TabIndex = 199;
            this.label9.Text = "Batch No.";
            // 
            // txtBatchNo
            // 
            this.txtBatchNo.Font = new System.Drawing.Font("Arial", 12F);
            this.txtBatchNo.Location = new System.Drawing.Point(149, 283);
            this.txtBatchNo.Name = "txtBatchNo";
            this.txtBatchNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBatchNo.Size = new System.Drawing.Size(140, 26);
            this.txtBatchNo.TabIndex = 198;
            this.txtBatchNo.TextChanged += new System.EventHandler(this.txtBatchNo_TextChanged);
            // 
            // frmWarehouseTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 591);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtBatchNo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtPName);
            this.Controls.Add(this.btnPSearch);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPCode);
            this.Controls.Add(this.txtPONo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCName);
            this.Controls.Add(this.btnSNo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSONo);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbTWarehouse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEmployeeName);
            this.Controls.Add(this.btnESearch);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtEmployeeCode);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.GCDetail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.cmbFWarehouse);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblCityId);
            this.Controls.Add(this.txtWTCode);
            this.Controls.Add(this.lblDelete);
            this.Controls.Add(this.lblClear);
            this.Controls.Add(this.lblUpdate);
            this.Controls.Add(this.lblAdd);
            this.Controls.Add(this.label3);
            this.KeyPreview = true;
            this.Name = "frmWarehouseTransfer";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmProductFormula_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmWarehouseTransfer_KeyDown);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GCDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetail)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblCityId;
        private System.Windows.Forms.TextBox txtWTCode;
        private System.Windows.Forms.Label lblDelete;
        private System.Windows.Forms.Label lblClear;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.Label lblAdd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnMinInvioceNo;
        private System.Windows.Forms.Button btnMaxInvioceNo;
        private System.Windows.Forms.Button btnPrevInvioceNo;
        private System.Windows.Forms.Button btnNextInvioceNo;
        private System.Windows.Forms.ComboBox cmbFWarehouse;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRemarks;
        private DevExpress.XtraGrid.GridControl GCDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDetail;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.TextBox txtEmployeeName;
        private System.Windows.Forms.Button btnESearch;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtEmployeeCode;
        private System.Windows.Forms.ComboBox cmbTWarehouse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSONo;
        private System.Windows.Forms.TextBox txtCName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPONo;
        private System.Windows.Forms.TextBox txtPName;
        private System.Windows.Forms.Button btnPSearch;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPCode;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkProcess;
        private System.Windows.Forms.TextBox txtProcessQty;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBatchNo;
    }
}