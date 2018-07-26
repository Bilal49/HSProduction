namespace FIL
{
    partial class frmProductFormula
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductFormula));
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblCityId = new System.Windows.Forms.Label();
            this.txtFormulaId = new System.Windows.Forms.TextBox();
            this.lblDelete = new System.Windows.Forms.Label();
            this.lblClear = new System.Windows.Forms.Label();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.lblAdd = new System.Windows.Forms.Label();
            this.lblCityName = new System.Windows.Forms.Label();
            this.txtFormulaName = new System.Windows.Forms.TextBox();
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
            this.btnRefresh = new System.Windows.Forms.Button();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbLastNo = new System.Windows.Forms.ComboBox();
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
            this.label3.Size = new System.Drawing.Size(271, 36);
            this.label3.TabIndex = 153;
            this.label3.Text = "Product Formula";
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
            this.btnSearch.Location = new System.Drawing.Point(231, 59);
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
            this.btnDelete.Location = new System.Drawing.Point(408, 474);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(44, 36);
            this.btnDelete.TabIndex = 11;
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
            this.btnClear.Location = new System.Drawing.Point(344, 474);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(44, 36);
            this.btnClear.TabIndex = 10;
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
            this.btnUpdate.Location = new System.Drawing.Point(281, 474);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(44, 36);
            this.btnUpdate.TabIndex = 9;
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
            this.btnAdd.Location = new System.Drawing.Point(215, 474);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(44, 36);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblCityId
            // 
            this.lblCityId.AutoSize = true;
            this.lblCityId.Font = new System.Drawing.Font("Arial", 12F);
            this.lblCityId.Location = new System.Drawing.Point(12, 63);
            this.lblCityId.Name = "lblCityId";
            this.lblCityId.Size = new System.Drawing.Size(47, 18);
            this.lblCityId.TabIndex = 171;
            this.lblCityId.Text = "Code";
            // 
            // txtFormulaId
            // 
            this.txtFormulaId.Font = new System.Drawing.Font("Arial", 12F);
            this.txtFormulaId.Location = new System.Drawing.Point(125, 59);
            this.txtFormulaId.Name = "txtFormulaId";
            this.txtFormulaId.ReadOnly = true;
            this.txtFormulaId.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtFormulaId.Size = new System.Drawing.Size(100, 26);
            this.txtFormulaId.TabIndex = 0;
            this.txtFormulaId.TextChanged += new System.EventHandler(this.txtFormulaId_TextChanged);
            // 
            // lblDelete
            // 
            this.lblDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDelete.AutoSize = true;
            this.lblDelete.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDelete.Location = new System.Drawing.Point(402, 516);
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
            this.lblClear.Location = new System.Drawing.Point(342, 516);
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
            this.lblUpdate.Location = new System.Drawing.Point(273, 516);
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
            this.lblAdd.Location = new System.Drawing.Point(218, 516);
            this.lblAdd.Name = "lblAdd";
            this.lblAdd.Size = new System.Drawing.Size(37, 18);
            this.lblAdd.TabIndex = 167;
            this.lblAdd.Text = "Add";
            // 
            // lblCityName
            // 
            this.lblCityName.AutoSize = true;
            this.lblCityName.Font = new System.Drawing.Font("Arial", 12F);
            this.lblCityName.Location = new System.Drawing.Point(12, 127);
            this.lblCityName.Name = "lblCityName";
            this.lblCityName.Size = new System.Drawing.Size(111, 18);
            this.lblCityName.TabIndex = 166;
            this.lblCityName.Text = "Formula Name";
            // 
            // txtFormulaName
            // 
            this.txtFormulaName.Font = new System.Drawing.Font("Arial", 12F);
            this.txtFormulaName.Location = new System.Drawing.Point(125, 123);
            this.txtFormulaName.Name = "txtFormulaName";
            this.txtFormulaName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtFormulaName.Size = new System.Drawing.Size(250, 26);
            this.txtFormulaName.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnMinInvioceNo);
            this.groupBox1.Controls.Add(this.btnMaxInvioceNo);
            this.groupBox1.Controls.Add(this.btnPrevInvioceNo);
            this.groupBox1.Controls.Add(this.btnNextInvioceNo);
            this.groupBox1.Location = new System.Drawing.Point(763, 12);
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
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.Location = new System.Drawing.Point(12, 95);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(98, 18);
            this.lblProductName.TabIndex = 174;
            this.lblProductName.Text = "Article Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F);
            this.label1.Location = new System.Drawing.Point(12, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 18);
            this.label1.TabIndex = 176;
            this.label1.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Font = new System.Drawing.Font("Arial", 12F);
            this.txtRemarks.Location = new System.Drawing.Point(125, 155);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtRemarks.Size = new System.Drawing.Size(531, 26);
            this.txtRemarks.TabIndex = 5;
            // 
            // GCDetail
            // 
            this.GCDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GCDetail.Location = new System.Drawing.Point(125, 187);
            this.GCDetail.MainView = this.gvDetail;
            this.GCDetail.Name = "GCDetail";
            this.GCDetail.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.GCDetail.Size = new System.Drawing.Size(750, 281);
            this.GCDetail.TabIndex = 7;
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
            this.gvDetail.MasterRowExpanding += new DevExpress.XtraGrid.Views.Grid.MasterRowCanExpandEventHandler(this.gvDetail_MasterRowExpanding);
            this.gvDetail.MasterRowExpanded += new DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventHandler(this.gvDetail_MasterRowExpanded);
            this.gvDetail.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvDetail_FocusedRowChanged);
            this.gvDetail.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvDetail_CellValueChanged);
            this.gvDetail.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvDetail_CellValueChanging);
            this.gvDetail.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gvDetail_InvalidRowException);
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
            this.label10.Location = new System.Drawing.Point(471, 516);
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
            this.btnPrint.Location = new System.Drawing.Point(467, 474);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(44, 36);
            this.btnPrint.TabIndex = 12;
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
            this.btnPSearch.Location = new System.Drawing.Point(231, 91);
            this.btnPSearch.Name = "btnPSearch";
            this.btnPSearch.Size = new System.Drawing.Size(26, 26);
            this.btnPSearch.TabIndex = 2;
            this.btnPSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPSearch.UseVisualStyleBackColor = true;
            this.btnPSearch.Click += new System.EventHandler(this.btnPSearch_Click);
            // 
            // txtPCode
            // 
            this.txtPCode.Font = new System.Drawing.Font("Arial", 12F);
            this.txtPCode.Location = new System.Drawing.Point(125, 91);
            this.txtPCode.Name = "txtPCode";
            this.txtPCode.ReadOnly = true;
            this.txtPCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPCode.Size = new System.Drawing.Size(100, 26);
            this.txtPCode.TabIndex = 179;
            this.txtPCode.TextChanged += new System.EventHandler(this.txtPCode_TextChanged);
            // 
            // txtPName
            // 
            this.txtPName.Font = new System.Drawing.Font("Arial", 12F);
            this.txtPName.Location = new System.Drawing.Point(263, 91);
            this.txtPName.Name = "txtPName";
            this.txtPName.ReadOnly = true;
            this.txtPName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPName.Size = new System.Drawing.Size(393, 26);
            this.txtPName.TabIndex = 181;
            // 
            // pbitem
            // 
            this.pbitem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbitem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbitem.Image = global::FIL.Properties.Resources.User;
            this.pbitem.Location = new System.Drawing.Point(662, 59);
            this.pbitem.Name = "pbitem";
            this.pbitem.Size = new System.Drawing.Size(150, 120);
            this.pbitem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbitem.TabIndex = 182;
            this.pbitem.TabStop = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(232)))), ((int)(((byte)(244)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Image = global::FIL.Properties.Resources.prevoius2;
            this.btnRefresh.Location = new System.Drawing.Point(263, 58);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(24, 24);
            this.btnRefresh.TabIndex = 803;
            this.btnRefresh.TabStop = false;
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Font = new System.Drawing.Font("Arial", 12F);
            this.chkActive.Location = new System.Drawing.Point(581, 125);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(70, 22);
            this.chkActive.TabIndex = 6;
            this.chkActive.Text = "Active";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(581, 58);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 27);
            this.btnCopy.TabIndex = 804;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F);
            this.label2.Location = new System.Drawing.Point(381, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 18);
            this.label2.TabIndex = 805;
            this.label2.Text = "Last #";
            // 
            // cmbLastNo
            // 
            this.cmbLastNo.Font = new System.Drawing.Font("Arial", 12F);
            this.cmbLastNo.FormattingEnabled = true;
            this.cmbLastNo.Location = new System.Drawing.Point(438, 123);
            this.cmbLastNo.Name = "cmbLastNo";
            this.cmbLastNo.Size = new System.Drawing.Size(121, 26);
            this.cmbLastNo.TabIndex = 4;
            // 
            // frmProductFormula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 541);
            this.Controls.Add(this.cmbLastNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.pbitem);
            this.Controls.Add(this.txtPName);
            this.Controls.Add(this.btnPSearch);
            this.Controls.Add(this.txtPCode);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.GCDetail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblCityId);
            this.Controls.Add(this.txtFormulaId);
            this.Controls.Add(this.lblDelete);
            this.Controls.Add(this.lblClear);
            this.Controls.Add(this.lblUpdate);
            this.Controls.Add(this.lblAdd);
            this.Controls.Add(this.lblCityName);
            this.Controls.Add(this.txtFormulaName);
            this.Controls.Add(this.label3);
            this.KeyPreview = true;
            this.Name = "frmProductFormula";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmProductFormula_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmProductFormula_KeyDown);
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
        private System.Windows.Forms.TextBox txtFormulaId;
        private System.Windows.Forms.Label lblDelete;
        private System.Windows.Forms.Label lblClear;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.Label lblAdd;
        private System.Windows.Forms.Label lblCityName;
        private System.Windows.Forms.TextBox txtFormulaName;
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
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbLastNo;
    }
}