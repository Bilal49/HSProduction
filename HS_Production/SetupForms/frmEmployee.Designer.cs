namespace FIL
{
    partial class frmEmployee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmployee));
            this.label3 = new System.Windows.Forms.Label();
            this.lblDelete = new System.Windows.Forms.Label();
            this.lblClear = new System.Windows.Forms.Label();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.lblAdd = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txtEmployeeCode = new System.Windows.Forms.TextBox();
            this.txtFatherName = new System.Windows.Forms.TextBox();
            this.txtCellPhone = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtNIC = new System.Windows.Forms.TextBox();
            this.txtEmployeeName = new System.Windows.Forms.TextBox();
            this.txtHomePhone = new System.Windows.Forms.TextBox();
            this.txtMaritalStatus = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblEmployeeCode = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblNIC = new System.Windows.Forms.Label();
            this.lblFatherName = new System.Windows.Forms.Label();
            this.lblCellPhone = new System.Windows.Forms.Label();
            this.lblDOB = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblHomePage = new System.Windows.Forms.Label();
            this.lblDeparment = new System.Windows.Forms.Label();
            this.lblMaritalStatus = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.lblHireDate = new System.Windows.Forms.Label();
            this.lblDesignnationId = new System.Windows.Forms.Label();
            this.cmbDesignationId = new System.Windows.Forms.ComboBox();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.lblRemark = new System.Windows.Forms.Label();
            this.dTPHireDate = new System.Windows.Forms.DateTimePicker();
            this.dTPDOB = new System.Windows.Forms.DateTimePicker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtPayrollId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSalery = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rdMontly = new System.Windows.Forms.RadioButton();
            this.rdPerDay = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 24F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(141)))), ((int)(((byte)(188)))));
            this.label3.Location = new System.Drawing.Point(13, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 36);
            this.label3.TabIndex = 62;
            this.label3.Text = "Employee";
            // 
            // lblDelete
            // 
            this.lblDelete.AutoSize = true;
            this.lblDelete.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDelete.Location = new System.Drawing.Point(472, 477);
            this.lblDelete.Name = "lblDelete";
            this.lblDelete.Size = new System.Drawing.Size(54, 18);
            this.lblDelete.TabIndex = 71;
            this.lblDelete.Text = "Delete";
            // 
            // lblClear
            // 
            this.lblClear.AutoSize = true;
            this.lblClear.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClear.Location = new System.Drawing.Point(412, 477);
            this.lblClear.Name = "lblClear";
            this.lblClear.Size = new System.Drawing.Size(46, 18);
            this.lblClear.TabIndex = 70;
            this.lblClear.Text = "Clear";
            // 
            // lblUpdate
            // 
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdate.Location = new System.Drawing.Point(343, 477);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(59, 18);
            this.lblUpdate.TabIndex = 69;
            this.lblUpdate.Text = "Update";
            // 
            // lblAdd
            // 
            this.lblAdd.AutoSize = true;
            this.lblAdd.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdd.Location = new System.Drawing.Point(288, 477);
            this.lblAdd.Name = "lblAdd";
            this.lblAdd.Size = new System.Drawing.Size(37, 18);
            this.lblAdd.TabIndex = 68;
            this.lblAdd.Text = "Add";
            // 
            // btnDelete
            // 
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(232)))), ((int)(((byte)(244)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(477, 438);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(44, 36);
            this.btnDelete.TabIndex = 22;
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btnDelete, "Delete");
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
            this.btnClear.Location = new System.Drawing.Point(413, 438);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(44, 36);
            this.btnClear.TabIndex = 21;
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btnClear, "Clear (F6)");
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
            this.btnUpdate.Location = new System.Drawing.Point(350, 438);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(44, 36);
            this.btnUpdate.TabIndex = 20;
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btnUpdate, "Update (F3)");
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
            this.btnAdd.Location = new System.Drawing.Point(284, 438);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(44, 36);
            this.btnAdd.TabIndex = 19;
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btnAdd, "Add (F3)");
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtEmployeeCode
            // 
            this.txtEmployeeCode.Font = new System.Drawing.Font("Arial", 12F);
            this.txtEmployeeCode.Location = new System.Drawing.Point(118, 74);
            this.txtEmployeeCode.Name = "txtEmployeeCode";
            this.txtEmployeeCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtEmployeeCode.Size = new System.Drawing.Size(120, 26);
            this.txtEmployeeCode.TabIndex = 0;
            this.txtEmployeeCode.TextChanged += new System.EventHandler(this.txtEmployeeCode_TextChanged);
            this.txtEmployeeCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmployeeCode_KeyDown);
            this.txtEmployeeCode.Leave += new System.EventHandler(this.txtEmployeeCode_Leave);
            // 
            // txtFatherName
            // 
            this.txtFatherName.Font = new System.Drawing.Font("Arial", 12F);
            this.txtFatherName.Location = new System.Drawing.Point(118, 138);
            this.txtFatherName.Name = "txtFatherName";
            this.txtFatherName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtFatherName.Size = new System.Drawing.Size(309, 26);
            this.txtFatherName.TabIndex = 2;
            // 
            // txtCellPhone
            // 
            this.txtCellPhone.Font = new System.Drawing.Font("Arial", 12F);
            this.txtCellPhone.Location = new System.Drawing.Point(118, 170);
            this.txtCellPhone.Name = "txtCellPhone";
            this.txtCellPhone.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCellPhone.Size = new System.Drawing.Size(309, 26);
            this.txtCellPhone.TabIndex = 3;
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Arial", 12F);
            this.txtEmail.Location = new System.Drawing.Point(118, 298);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtEmail.Size = new System.Drawing.Size(239, 26);
            this.txtEmail.TabIndex = 12;
            // 
            // txtNIC
            // 
            this.txtNIC.Font = new System.Drawing.Font("Arial", 12F);
            this.txtNIC.Location = new System.Drawing.Point(556, 234);
            this.txtNIC.Name = "txtNIC";
            this.txtNIC.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtNIC.Size = new System.Drawing.Size(241, 26);
            this.txtNIC.TabIndex = 9;
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.Font = new System.Drawing.Font("Arial", 12F);
            this.txtEmployeeName.Location = new System.Drawing.Point(118, 106);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtEmployeeName.Size = new System.Drawing.Size(308, 26);
            this.txtEmployeeName.TabIndex = 1;
            // 
            // txtHomePhone
            // 
            this.txtHomePhone.Font = new System.Drawing.Font("Arial", 12F);
            this.txtHomePhone.Location = new System.Drawing.Point(556, 170);
            this.txtHomePhone.Name = "txtHomePhone";
            this.txtHomePhone.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtHomePhone.Size = new System.Drawing.Size(242, 26);
            this.txtHomePhone.TabIndex = 4;
            this.txtHomePhone.TextChanged += new System.EventHandler(this.txtHomePhone_TextChanged);
            // 
            // txtMaritalStatus
            // 
            this.txtMaritalStatus.Font = new System.Drawing.Font("Arial", 12F);
            this.txtMaritalStatus.Location = new System.Drawing.Point(118, 266);
            this.txtMaritalStatus.Name = "txtMaritalStatus";
            this.txtMaritalStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtMaritalStatus.Size = new System.Drawing.Size(241, 26);
            this.txtMaritalStatus.TabIndex = 10;
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Arial", 12F);
            this.txtAddress.Location = new System.Drawing.Point(118, 330);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtAddress.Size = new System.Drawing.Size(680, 26);
            this.txtAddress.TabIndex = 14;
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
            this.btnSearch.Location = new System.Drawing.Point(244, 74);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(26, 26);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.TabStop = false;
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblEmployeeCode
            // 
            this.lblEmployeeCode.AutoSize = true;
            this.lblEmployeeCode.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeCode.Location = new System.Drawing.Point(16, 78);
            this.lblEmployeeCode.Name = "lblEmployeeCode";
            this.lblEmployeeCode.Size = new System.Drawing.Size(47, 18);
            this.lblEmployeeCode.TabIndex = 118;
            this.lblEmployeeCode.Text = "Code";
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGender.Location = new System.Drawing.Point(16, 207);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(60, 18);
            this.lblGender.TabIndex = 107;
            this.lblGender.Text = "Gender";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(16, 301);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(48, 18);
            this.lblEmail.TabIndex = 108;
            this.lblEmail.Text = "Email";
            // 
            // lblNIC
            // 
            this.lblNIC.AutoSize = true;
            this.lblNIC.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNIC.Location = new System.Drawing.Point(477, 237);
            this.lblNIC.Name = "lblNIC";
            this.lblNIC.Size = new System.Drawing.Size(46, 18);
            this.lblNIC.TabIndex = 109;
            this.lblNIC.Text = "CNIC";
            // 
            // lblFatherName
            // 
            this.lblFatherName.AutoSize = true;
            this.lblFatherName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFatherName.Location = new System.Drawing.Point(16, 141);
            this.lblFatherName.Name = "lblFatherName";
            this.lblFatherName.Size = new System.Drawing.Size(99, 18);
            this.lblFatherName.TabIndex = 110;
            this.lblFatherName.Text = "Father Name";
            // 
            // lblCellPhone
            // 
            this.lblCellPhone.AutoSize = true;
            this.lblCellPhone.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCellPhone.Location = new System.Drawing.Point(16, 173);
            this.lblCellPhone.Name = "lblCellPhone";
            this.lblCellPhone.Size = new System.Drawing.Size(66, 18);
            this.lblCellPhone.TabIndex = 111;
            this.lblCellPhone.Text = "Phone #";
            // 
            // lblDOB
            // 
            this.lblDOB.AutoSize = true;
            this.lblDOB.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDOB.Location = new System.Drawing.Point(16, 240);
            this.lblDOB.Name = "lblDOB";
            this.lblDOB.Size = new System.Drawing.Size(43, 18);
            this.lblDOB.TabIndex = 112;
            this.lblDOB.Text = "DOB";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(16, 109);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(50, 18);
            this.lblName.TabIndex = 114;
            this.lblName.Text = "Name";
            // 
            // lblHomePage
            // 
            this.lblHomePage.AutoSize = true;
            this.lblHomePage.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHomePage.Location = new System.Drawing.Point(438, 170);
            this.lblHomePage.Name = "lblHomePage";
            this.lblHomePage.Size = new System.Drawing.Size(112, 18);
            this.lblHomePage.TabIndex = 115;
            this.lblHomePage.Text = "Home Phone #";
            // 
            // lblDeparment
            // 
            this.lblDeparment.AutoSize = true;
            this.lblDeparment.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeparment.Location = new System.Drawing.Point(438, 205);
            this.lblDeparment.Name = "lblDeparment";
            this.lblDeparment.Size = new System.Drawing.Size(90, 18);
            this.lblDeparment.TabIndex = 116;
            this.lblDeparment.Text = "Department";
            // 
            // lblMaritalStatus
            // 
            this.lblMaritalStatus.AutoSize = true;
            this.lblMaritalStatus.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaritalStatus.Location = new System.Drawing.Point(16, 269);
            this.lblMaritalStatus.Name = "lblMaritalStatus";
            this.lblMaritalStatus.Size = new System.Drawing.Size(99, 18);
            this.lblMaritalStatus.TabIndex = 119;
            this.lblMaritalStatus.Text = "MaritalStatus";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(16, 333);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(67, 18);
            this.lblAddress.TabIndex = 119;
            this.lblAddress.Text = "Address";
            // 
            // cmbGender
            // 
            this.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGender.Font = new System.Drawing.Font("Arial", 12F);
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Location = new System.Drawing.Point(118, 202);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbGender.Size = new System.Drawing.Size(241, 26);
            this.cmbGender.TabIndex = 5;
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.Font = new System.Drawing.Font("Arial", 12F);
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(557, 202);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbDepartment.Size = new System.Drawing.Size(242, 26);
            this.cmbDepartment.TabIndex = 6;
            // 
            // lblHireDate
            // 
            this.lblHireDate.AutoSize = true;
            this.lblHireDate.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHireDate.Location = new System.Drawing.Point(257, 240);
            this.lblHireDate.Name = "lblHireDate";
            this.lblHireDate.Size = new System.Drawing.Size(75, 18);
            this.lblHireDate.TabIndex = 121;
            this.lblHireDate.Text = "Hire Date";
            // 
            // lblDesignnationId
            // 
            this.lblDesignnationId.AutoSize = true;
            this.lblDesignnationId.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesignnationId.Location = new System.Drawing.Point(438, 269);
            this.lblDesignnationId.Name = "lblDesignnationId";
            this.lblDesignnationId.Size = new System.Drawing.Size(92, 18);
            this.lblDesignnationId.TabIndex = 123;
            this.lblDesignnationId.Text = "Designation";
            // 
            // cmbDesignationId
            // 
            this.cmbDesignationId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDesignationId.Font = new System.Drawing.Font("Arial", 12F);
            this.cmbDesignationId.FormattingEnabled = true;
            this.cmbDesignationId.Location = new System.Drawing.Point(556, 266);
            this.cmbDesignationId.Name = "cmbDesignationId";
            this.cmbDesignationId.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbDesignationId.Size = new System.Drawing.Size(242, 26);
            this.cmbDesignationId.TabIndex = 11;
            // 
            // txtRemark
            // 
            this.txtRemark.Font = new System.Drawing.Font("Arial", 12F);
            this.txtRemark.Location = new System.Drawing.Point(556, 298);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtRemark.Size = new System.Drawing.Size(242, 26);
            this.txtRemark.TabIndex = 13;
            // 
            // lblRemark
            // 
            this.lblRemark.AutoSize = true;
            this.lblRemark.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemark.Location = new System.Drawing.Point(438, 301);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(71, 18);
            this.lblRemark.TabIndex = 126;
            this.lblRemark.Text = "Remarks";
            // 
            // dTPHireDate
            // 
            this.dTPHireDate.CustomFormat = "dd-MMM-yyyy";
            this.dTPHireDate.Font = new System.Drawing.Font("Arial", 12F);
            this.dTPHireDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dTPHireDate.Location = new System.Drawing.Point(338, 234);
            this.dTPHireDate.Name = "dTPHireDate";
            this.dTPHireDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dTPHireDate.Size = new System.Drawing.Size(133, 26);
            this.dTPHireDate.TabIndex = 8;
            // 
            // dTPDOB
            // 
            this.dTPDOB.CustomFormat = "dd-MMM-yyyy";
            this.dTPDOB.Font = new System.Drawing.Font("Arial", 12F);
            this.dTPDOB.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dTPDOB.Location = new System.Drawing.Point(118, 234);
            this.dTPDOB.Name = "dTPDOB";
            this.dTPDOB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dTPDOB.Size = new System.Drawing.Size(133, 26);
            this.dTPDOB.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(614, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(184, 152);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 127;
            this.pictureBox1.TabStop = false;
            // 
            // txtPayrollId
            // 
            this.txtPayrollId.Font = new System.Drawing.Font("Arial", 12F);
            this.txtPayrollId.Location = new System.Drawing.Point(118, 362);
            this.txtPayrollId.Name = "txtPayrollId";
            this.txtPayrollId.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPayrollId.Size = new System.Drawing.Size(76, 26);
            this.txtPayrollId.TabIndex = 15;
            this.txtPayrollId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPayrollId_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 365);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 18);
            this.label1.TabIndex = 129;
            this.label1.Text = "Payroll ID";
            // 
            // txtSalery
            // 
            this.txtSalery.Font = new System.Drawing.Font("Arial", 12F);
            this.txtSalery.Location = new System.Drawing.Point(258, 362);
            this.txtSalery.Name = "txtSalery";
            this.txtSalery.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSalery.Size = new System.Drawing.Size(169, 26);
            this.txtSalery.TabIndex = 16;
            this.txtSalery.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSalery_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(200, 365);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 18);
            this.label2.TabIndex = 131;
            this.label2.Text = "Salery";
            // 
            // rdMontly
            // 
            this.rdMontly.AutoSize = true;
            this.rdMontly.Checked = true;
            this.rdMontly.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.rdMontly.Location = new System.Drawing.Point(258, 394);
            this.rdMontly.Name = "rdMontly";
            this.rdMontly.Size = new System.Drawing.Size(82, 20);
            this.rdMontly.TabIndex = 17;
            this.rdMontly.TabStop = true;
            this.rdMontly.Text = "Monthly";
            this.rdMontly.UseVisualStyleBackColor = true;
            // 
            // rdPerDay
            // 
            this.rdPerDay.AutoSize = true;
            this.rdPerDay.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.rdPerDay.Location = new System.Drawing.Point(348, 394);
            this.rdPerDay.Name = "rdPerDay";
            this.rdPerDay.Size = new System.Drawing.Size(79, 20);
            this.rdPerDay.TabIndex = 18;
            this.rdPerDay.Text = "Per Day";
            this.rdPerDay.UseVisualStyleBackColor = true;
            // 
            // frmEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 515);
            this.Controls.Add(this.rdPerDay);
            this.Controls.Add(this.rdMontly);
            this.Controls.Add(this.txtSalery);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPayrollId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dTPHireDate);
            this.Controls.Add(this.dTPDOB);
            this.Controls.Add(this.lblHireDate);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblRemark);
            this.Controls.Add(this.lblDelete);
            this.Controls.Add(this.lblClear);
            this.Controls.Add(this.cmbDesignationId);
            this.Controls.Add(this.lblUpdate);
            this.Controls.Add(this.lblMaritalStatus);
            this.Controls.Add(this.lblDesignnationId);
            this.Controls.Add(this.txtMaritalStatus);
            this.Controls.Add(this.lblAdd);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lblNIC);
            this.Controls.Add(this.cmbDepartment);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtNIC);
            this.Controls.Add(this.lblDOB);
            this.Controls.Add(this.cmbGender);
            this.Controls.Add(this.lblDeparment);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblEmployeeCode);
            this.Controls.Add(this.txtEmployeeCode);
            this.Controls.Add(this.lblHomePage);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.lblCellPhone);
            this.Controls.Add(this.txtEmployeeName);
            this.Controls.Add(this.lblFatherName);
            this.Controls.Add(this.txtHomePhone);
            this.Controls.Add(this.txtFatherName);
            this.Controls.Add(this.txtCellPhone);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmEmployee";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmEmployee_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmEmployee_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDelete;
        private System.Windows.Forms.Label lblClear;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.Label lblAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txtEmployeeCode;
        private System.Windows.Forms.TextBox txtFatherName;
        private System.Windows.Forms.TextBox txtCellPhone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtNIC;
        private System.Windows.Forms.TextBox txtEmployeeName;
        private System.Windows.Forms.TextBox txtHomePhone;
        private System.Windows.Forms.TextBox txtMaritalStatus;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblEmployeeCode;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblNIC;
        private System.Windows.Forms.Label lblFatherName;
        private System.Windows.Forms.Label lblCellPhone;
        private System.Windows.Forms.Label lblDOB;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblHomePage;
        private System.Windows.Forms.Label lblDeparment;
        private System.Windows.Forms.Label lblMaritalStatus;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.Label lblHireDate;
        private System.Windows.Forms.Label lblDesignnationId;
        private System.Windows.Forms.ComboBox cmbDesignationId;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label lblRemark;
        private System.Windows.Forms.DateTimePicker dTPHireDate;
        private System.Windows.Forms.DateTimePicker dTPDOB;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtPayrollId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSalery;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdMontly;
        private System.Windows.Forms.RadioButton rdPerDay;
    }
}