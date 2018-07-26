
partial class frmProcess
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProcess));
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblCityId = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblDelete = new System.Windows.Forms.Label();
            this.lblClear = new System.Windows.Forms.Label();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.lblAdd = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnMinInvioceNo = new System.Windows.Forms.Button();
            this.btnMaxInvioceNo = new System.Windows.Forms.Button();
            this.btnPrevInvioceNo = new System.Windows.Forms.Button();
            this.btnNextInvioceNo = new System.Windows.Forms.Button();
            this.lblProductName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.GCDetail = new DevExpress.XtraGrid.GridControl();
            this.gvDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.label10 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnPSearch = new System.Windows.Forms.Button();
            this.txtPCode = new System.Windows.Forms.TextBox();
            this.txtPName = new System.Windows.Forms.TextBox();
            this.pbitem = new System.Windows.Forms.PictureBox();
            this.dtp = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSOSearch = new System.Windows.Forms.Button();
            this.txtSOrderNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpOrder = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbWarehouse = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtOrderQty = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtProcessQty = new System.Windows.Forms.TextBox();
            this.txtDoneQty = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cmbTransferWarehouse = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GCDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbitem)).BeginInit();
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
            this.label3.Size = new System.Drawing.Size(140, 36);
            this.label3.TabIndex = 153;
            this.label3.Text = "Process";
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
            this.btnSearch.Location = new System.Drawing.Point(269, 48);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(26, 26);
            this.btnSearch.TabIndex = 1;
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
            this.btnDelete.Location = new System.Drawing.Point(431, 534);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(44, 36);
            this.btnDelete.TabIndex = 9;
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
            this.btnClear.Location = new System.Drawing.Point(367, 534);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(44, 36);
            this.btnClear.TabIndex = 8;
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
            this.btnUpdate.Location = new System.Drawing.Point(304, 534);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(44, 36);
            this.btnUpdate.TabIndex = 7;
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
            this.btnAdd.Location = new System.Drawing.Point(238, 534);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(44, 36);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblCityId
            // 
            this.lblCityId.AutoSize = true;
            this.lblCityId.Font = new System.Drawing.Font("Arial", 12F);
            this.lblCityId.Location = new System.Drawing.Point(12, 52);
            this.lblCityId.Name = "lblCityId";
            this.lblCityId.Size = new System.Drawing.Size(47, 18);
            this.lblCityId.TabIndex = 171;
            this.lblCityId.Text = "Code";
            // 
            // txtCode
            // 
            this.txtCode.Font = new System.Drawing.Font("Arial", 12F);
            this.txtCode.Location = new System.Drawing.Point(125, 48);
            this.txtCode.Name = "txtCode";
            this.txtCode.ReadOnly = true;
            this.txtCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCode.Size = new System.Drawing.Size(136, 26);
            this.txtCode.TabIndex = 0;
            this.txtCode.TextChanged += new System.EventHandler(this.txtFormulaId_TextChanged);
            // 
            // lblDelete
            // 
            this.lblDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDelete.AutoSize = true;
            this.lblDelete.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDelete.Location = new System.Drawing.Point(425, 576);
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
            this.lblClear.Location = new System.Drawing.Point(365, 576);
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
            this.lblUpdate.Location = new System.Drawing.Point(296, 576);
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
            this.lblAdd.Location = new System.Drawing.Point(241, 576);
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
            this.groupBox1.Location = new System.Drawing.Point(299, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(112, 35);
            this.groupBox1.TabIndex = 172;
            this.groupBox1.TabStop = false;
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
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.Location = new System.Drawing.Point(426, 56);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(98, 18);
            this.lblProductName.TabIndex = 174;
            this.lblProductName.Text = "Article Name";
            this.lblProductName.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F);
            this.label1.Location = new System.Drawing.Point(15, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 18);
            this.label1.TabIndex = 176;
            this.label1.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Font = new System.Drawing.Font("Arial", 12F);
            this.txtRemarks.Location = new System.Drawing.Point(125, 112);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtRemarks.Size = new System.Drawing.Size(634, 26);
            this.txtRemarks.TabIndex = 4;
            // 
            // GCDetail
            // 
            this.GCDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GCDetail.Location = new System.Drawing.Point(15, 144);
            this.GCDetail.MainView = this.gvDetail;
            this.GCDetail.Name = "GCDetail";
            this.GCDetail.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.GCDetail.Size = new System.Drawing.Size(965, 376);
            this.GCDetail.TabIndex = 5;
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
            this.gvDetail.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gvDetail_RowUpdated);
            this.gvDetail.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gvDetail_CustomColumnDisplayText);
            this.gvDetail.GotFocus += new System.EventHandler(this.gvDetail_GotFocus);
            this.gvDetail.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gvDetail_ValidatingEditor);
            this.gvDetail.InvalidValueException += new DevExpress.XtraEditors.Controls.InvalidValueExceptionEventHandler(this.gvDetail_InvalidValueException);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(495, 576);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 18);
            this.label10.TabIndex = 178;
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
            this.btnPrint.Location = new System.Drawing.Point(491, 534);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(44, 36);
            this.btnPrint.TabIndex = 10;
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
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
            this.btnPSearch.Location = new System.Drawing.Point(574, 52);
            this.btnPSearch.Name = "btnPSearch";
            this.btnPSearch.Size = new System.Drawing.Size(26, 26);
            this.btnPSearch.TabIndex = 6;
            this.btnPSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPSearch.UseVisualStyleBackColor = true;
            this.btnPSearch.Visible = false;
            this.btnPSearch.Click += new System.EventHandler(this.btnPSearch_Click);
            // 
            // txtPCode
            // 
            this.txtPCode.Font = new System.Drawing.Font("Arial", 12F);
            this.txtPCode.Location = new System.Drawing.Point(539, 52);
            this.txtPCode.Name = "txtPCode";
            this.txtPCode.ReadOnly = true;
            this.txtPCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPCode.Size = new System.Drawing.Size(27, 26);
            this.txtPCode.TabIndex = 5;
            this.txtPCode.Visible = false;
            this.txtPCode.TextChanged += new System.EventHandler(this.txtPCode_TextChanged);
            // 
            // txtPName
            // 
            this.txtPName.Font = new System.Drawing.Font("Arial", 12F);
            this.txtPName.Location = new System.Drawing.Point(604, 52);
            this.txtPName.Name = "txtPName";
            this.txtPName.ReadOnly = true;
            this.txtPName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPName.Size = new System.Drawing.Size(26, 26);
            this.txtPName.TabIndex = 181;
            this.txtPName.TabStop = false;
            this.txtPName.Visible = false;
            // 
            // pbitem
            // 
            this.pbitem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbitem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbitem.Image = global::FIL.Properties.Resources.User;
            this.pbitem.Location = new System.Drawing.Point(682, 78);
            this.pbitem.Name = "pbitem";
            this.pbitem.Size = new System.Drawing.Size(77, 74);
            this.pbitem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbitem.TabIndex = 182;
            this.pbitem.TabStop = false;
            this.pbitem.Visible = false;
            // 
            // dtp
            // 
            this.dtp.CustomFormat = "dd-MMM-yyyy";
            this.dtp.Font = new System.Drawing.Font("Arial", 12F);
            this.dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp.Location = new System.Drawing.Point(125, 80);
            this.dtp.Name = "dtp";
            this.dtp.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtp.Size = new System.Drawing.Size(136, 26);
            this.dtp.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 86);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(51, 18);
            this.label2.TabIndex = 805;
            this.label2.Text = "Dated";
            // 
            // btnSOSearch
            // 
            this.btnSOSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSOSearch.BackgroundImage")));
            this.btnSOSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSOSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSOSearch.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnSOSearch.FlatAppearance.BorderSize = 0;
            this.btnSOSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSOSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSOSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSOSearch.Location = new System.Drawing.Point(574, 20);
            this.btnSOSearch.Name = "btnSOSearch";
            this.btnSOSearch.Size = new System.Drawing.Size(26, 26);
            this.btnSOSearch.TabIndex = 3;
            this.btnSOSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSOSearch.UseVisualStyleBackColor = true;
            this.btnSOSearch.Visible = false;
            this.btnSOSearch.Click += new System.EventHandler(this.btnSOSearch_Click);
            // 
            // txtSOrderNo
            // 
            this.txtSOrderNo.Font = new System.Drawing.Font("Arial", 12F);
            this.txtSOrderNo.Location = new System.Drawing.Point(539, 20);
            this.txtSOrderNo.Name = "txtSOrderNo";
            this.txtSOrderNo.ReadOnly = true;
            this.txtSOrderNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSOrderNo.Size = new System.Drawing.Size(27, 26);
            this.txtSOrderNo.TabIndex = 2;
            this.txtSOrderNo.Visible = false;
            this.txtSOrderNo.TextChanged += new System.EventHandler(this.txtSOrderNo_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(426, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 18);
            this.label4.TabIndex = 806;
            this.label4.Text = "PO Number";
            this.label4.Visible = false;
            // 
            // dtpOrder
            // 
            this.dtpOrder.CustomFormat = "dd-MMM-yyyy";
            this.dtpOrder.Enabled = false;
            this.dtpOrder.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpOrder.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOrder.Location = new System.Drawing.Point(701, 18);
            this.dtpOrder.Name = "dtpOrder";
            this.dtpOrder.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpOrder.Size = new System.Drawing.Size(45, 26);
            this.dtpOrder.TabIndex = 809;
            this.dtpOrder.TabStop = false;
            this.dtpOrder.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(606, 23);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(86, 18);
            this.label5.TabIndex = 810;
            this.label5.Text = "Order Date";
            this.label5.Visible = false;
            // 
            // cmbWarehouse
            // 
            this.cmbWarehouse.Font = new System.Drawing.Font("Arial", 12F);
            this.cmbWarehouse.FormattingEnabled = true;
            this.cmbWarehouse.Location = new System.Drawing.Point(631, 109);
            this.cmbWarehouse.Name = "cmbWarehouse";
            this.cmbWarehouse.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbWarehouse.Size = new System.Drawing.Size(45, 26);
            this.cmbWarehouse.TabIndex = 2;
            this.cmbWarehouse.Visible = false;
            this.cmbWarehouse.SelectedIndexChanged += new System.EventHandler(this.cmbWarehouse_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F);
            this.label6.Location = new System.Drawing.Point(518, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 18);
            this.label6.TabIndex = 812;
            this.label6.Text = "Department";
            this.label6.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 12F);
            this.label13.Location = new System.Drawing.Point(426, 88);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 18);
            this.label13.TabIndex = 826;
            this.label13.Text = "Order Qty";
            this.label13.Visible = false;
            // 
            // txtOrderQty
            // 
            this.txtOrderQty.Font = new System.Drawing.Font("Arial", 12F);
            this.txtOrderQty.Location = new System.Drawing.Point(539, 84);
            this.txtOrderQty.Name = "txtOrderQty";
            this.txtOrderQty.ReadOnly = true;
            this.txtOrderQty.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtOrderQty.Size = new System.Drawing.Size(27, 26);
            this.txtOrderQty.TabIndex = 823;
            this.txtOrderQty.TabStop = false;
            this.txtOrderQty.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 12F);
            this.label14.Location = new System.Drawing.Point(665, 88);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(66, 18);
            this.label14.TabIndex = 825;
            this.label14.Text = "Process";
            this.label14.Visible = false;
            // 
            // txtProcessQty
            // 
            this.txtProcessQty.Font = new System.Drawing.Font("Arial", 12F);
            this.txtProcessQty.Location = new System.Drawing.Point(743, 84);
            this.txtProcessQty.Name = "txtProcessQty";
            this.txtProcessQty.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtProcessQty.Size = new System.Drawing.Size(32, 26);
            this.txtProcessQty.TabIndex = 8;
            this.txtProcessQty.Visible = false;
            this.txtProcessQty.TextChanged += new System.EventHandler(this.txtProcessQty_TextChanged);
            this.txtProcessQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProcessQty_KeyPress);
            // 
            // txtDoneQty
            // 
            this.txtDoneQty.Font = new System.Drawing.Font("Arial", 12F);
            this.txtDoneQty.Location = new System.Drawing.Point(634, 84);
            this.txtDoneQty.Name = "txtDoneQty";
            this.txtDoneQty.ReadOnly = true;
            this.txtDoneQty.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDoneQty.Size = new System.Drawing.Size(26, 26);
            this.txtDoneQty.TabIndex = 827;
            this.txtDoneQty.TabStop = false;
            this.txtDoneQty.Visible = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial", 12F);
            this.label15.Location = new System.Drawing.Point(582, 88);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(46, 18);
            this.label15.TabIndex = 828;
            this.label15.Text = "Done";
            this.label15.Visible = false;
            // 
            // cmbTransferWarehouse
            // 
            this.cmbTransferWarehouse.Font = new System.Drawing.Font("Arial", 12F);
            this.cmbTransferWarehouse.FormattingEnabled = true;
            this.cmbTransferWarehouse.Location = new System.Drawing.Point(631, 141);
            this.cmbTransferWarehouse.Name = "cmbTransferWarehouse";
            this.cmbTransferWarehouse.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbTransferWarehouse.Size = new System.Drawing.Size(45, 26);
            this.cmbTransferWarehouse.TabIndex = 3;
            this.cmbTransferWarehouse.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F);
            this.label7.Location = new System.Drawing.Point(518, 144);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 18);
            this.label7.TabIndex = 830;
            this.label7.Text = "Transfer To";
            this.label7.Visible = false;
            // 
            // frmProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 607);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.GCDetail);
            this.Controls.Add(this.cmbTransferWarehouse);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnSOSearch);
            this.Controls.Add(this.btnPSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cmbWarehouse);
            this.Controls.Add(this.txtDoneQty);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtProcessQty);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtOrderQty);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtpOrder);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSOrderNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pbitem);
            this.Controls.Add(this.txtPName);
            this.Controls.Add(this.txtPCode);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblCityId);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lblDelete);
            this.Controls.Add(this.lblClear);
            this.Controls.Add(this.lblUpdate);
            this.Controls.Add(this.lblAdd);
            this.Controls.Add(this.label3);
            this.KeyPreview = true;
            this.Name = "frmProcess";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmProductFormula_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmProduction_KeyDown);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GCDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbitem)).EndInit();
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
    private System.Windows.Forms.TextBox txtCode;
    private System.Windows.Forms.Label lblDelete;
    private System.Windows.Forms.Label lblClear;
    private System.Windows.Forms.Label lblUpdate;
    private System.Windows.Forms.Label lblAdd;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Button btnMinInvioceNo;
    private System.Windows.Forms.Button btnMaxInvioceNo;
    private System.Windows.Forms.Button btnPrevInvioceNo;
    private System.Windows.Forms.Button btnNextInvioceNo;
    private System.Windows.Forms.Label lblProductName;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtRemarks;
    private DevExpress.XtraGrid.GridControl GCDetail;
    private DevExpress.XtraGrid.Views.Grid.GridView gvDetail;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Button btnPrint;
    private System.Windows.Forms.Button btnPSearch;
    private System.Windows.Forms.TextBox txtPCode;
    private System.Windows.Forms.TextBox txtPName;
    private System.Windows.Forms.PictureBox pbitem;
    private System.Windows.Forms.DateTimePicker dtp;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button btnSOSearch;
    private System.Windows.Forms.TextBox txtSOrderNo;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.DateTimePicker dtpOrder;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.ComboBox cmbWarehouse;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.TextBox txtOrderQty;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.TextBox txtProcessQty;
    private System.Windows.Forms.TextBox txtDoneQty;
    private System.Windows.Forms.Label label15;
    private System.Windows.Forms.ComboBox cmbTransferWarehouse;
    private System.Windows.Forms.Label label7;
}
