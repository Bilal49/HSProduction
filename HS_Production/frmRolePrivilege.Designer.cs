namespace FIL
{
    partial class frmRolePrivilege
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRolePrivilege));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtRoleName = new System.Windows.Forms.TextBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnSearch = new System.Windows.Forms.Button();
            this.gvPrivilege = new System.Windows.Forms.DataGridView();
            this.Privilege_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Menu_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roleid1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Privilege_Allow = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Privilege_Add = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Privilege_Edit = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Privilege_Delete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Privilege_Post = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.chkAll = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.gvPrivilege)).BeginInit();
            this.SuspendLayout();
            // 
            // txtRoleName
            // 
            this.txtRoleName.Font = new System.Drawing.Font("Arial", 12F);
            this.txtRoleName.Location = new System.Drawing.Point(91, 48);
            this.txtRoleName.Name = "txtRoleName";
            this.txtRoleName.ReadOnly = true;
            this.txtRoleName.Size = new System.Drawing.Size(223, 26);
            this.txtRoleName.TabIndex = 0;
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCode.Location = new System.Drawing.Point(20, 51);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(40, 18);
            this.lblCode.TabIndex = 3;
            this.lblCode.Text = "Role";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 24F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(141)))), ((int)(((byte)(188)))));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 36);
            this.label1.TabIndex = 8;
            this.label1.Text = "Role Privilege";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(232)))), ((int)(((byte)(244)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.Location = new System.Drawing.Point(253, 471);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(44, 36);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btnUpdate, "Update Record");
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClear
            // 
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(232)))), ((int)(((byte)(244)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.Location = new System.Drawing.Point(316, 471);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(44, 36);
            this.btnClear.TabIndex = 6;
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btnClear, "Clear Record");
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(246, 510);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 18);
            this.label5.TabIndex = 13;
            this.label5.Text = "Update";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(315, 510);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 18);
            this.label6.TabIndex = 14;
            this.label6.Text = "Clear";
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
            this.btnSearch.Location = new System.Drawing.Point(320, 47);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(26, 26);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btnSearch, "Search Record");
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // gvPrivilege
            // 
            this.gvPrivilege.AllowUserToAddRows = false;
            this.gvPrivilege.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvPrivilege.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvPrivilege.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvPrivilege.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvPrivilege.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Privilege_Id,
            this.Menu_Id,
            this.MenuName,
            this.roleid1,
            this.Privilege_Allow,
            this.Privilege_Add,
            this.Privilege_Edit,
            this.Privilege_Delete,
            this.Privilege_Post});
            this.gvPrivilege.Location = new System.Drawing.Point(21, 79);
            this.gvPrivilege.Name = "gvPrivilege";
            this.gvPrivilege.RowHeadersVisible = false;
            this.gvPrivilege.RowHeadersWidth = 10;
            this.gvPrivilege.Size = new System.Drawing.Size(564, 386);
            this.gvPrivilege.TabIndex = 16;
            this.gvPrivilege.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvPrivilege_CellValueChanged);
            // 
            // Privilege_Id
            // 
            this.Privilege_Id.DataPropertyName = "Privilege_Id";
            this.Privilege_Id.HeaderText = "Privilege_Id";
            this.Privilege_Id.Name = "Privilege_Id";
            this.Privilege_Id.Visible = false;
            // 
            // Menu_Id
            // 
            this.Menu_Id.DataPropertyName = "Menu_Id";
            this.Menu_Id.HeaderText = "Menu_Id";
            this.Menu_Id.Name = "Menu_Id";
            this.Menu_Id.Visible = false;
            // 
            // MenuName
            // 
            this.MenuName.DataPropertyName = "MenuName";
            this.MenuName.FillWeight = 82.08122F;
            this.MenuName.HeaderText = "Menu Name";
            this.MenuName.Name = "MenuName";
            // 
            // roleid1
            // 
            this.roleid1.DataPropertyName = "roleid";
            this.roleid1.HeaderText = "roleid";
            this.roleid1.Name = "roleid1";
            this.roleid1.Visible = false;
            // 
            // Privilege_Allow
            // 
            this.Privilege_Allow.DataPropertyName = "Privilege_Allow";
            this.Privilege_Allow.FillWeight = 30F;
            this.Privilege_Allow.HeaderText = "Allow";
            this.Privilege_Allow.Name = "Privilege_Allow";
            // 
            // Privilege_Add
            // 
            this.Privilege_Add.DataPropertyName = "Privilege_Add";
            this.Privilege_Add.FillWeight = 30F;
            this.Privilege_Add.HeaderText = "Add";
            this.Privilege_Add.Name = "Privilege_Add";
            // 
            // Privilege_Edit
            // 
            this.Privilege_Edit.DataPropertyName = "Privilege_Edit";
            this.Privilege_Edit.FillWeight = 30F;
            this.Privilege_Edit.HeaderText = "Edit";
            this.Privilege_Edit.Name = "Privilege_Edit";
            // 
            // Privilege_Delete
            // 
            this.Privilege_Delete.DataPropertyName = "Privilege_Delete";
            this.Privilege_Delete.FillWeight = 30F;
            this.Privilege_Delete.HeaderText = "Delete";
            this.Privilege_Delete.Name = "Privilege_Delete";
            // 
            // Privilege_Post
            // 
            this.Privilege_Post.DataPropertyName = "Privilege_Post";
            this.Privilege_Post.FillWeight = 30F;
            this.Privilege_Post.HeaderText = "Post";
            this.Privilege_Post.Name = "Privilege_Post";
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.chkAll.Location = new System.Drawing.Point(479, 51);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(106, 21);
            this.chkAll.TabIndex = 17;
            this.chkAll.Text = "All Checked";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // frmRolePrivilege
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(606, 533);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.gvPrivilege);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.txtRoleName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmRolePrivilege";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmArea_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvPrivilege)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRoleName;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView gvPrivilege;
        private System.Windows.Forms.DataGridViewTextBoxColumn Privilege_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Menu_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn MenuName;
        private System.Windows.Forms.DataGridViewTextBoxColumn roleid1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Privilege_Allow;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Privilege_Add;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Privilege_Edit;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Privilege_Delete;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Privilege_Post;
        private System.Windows.Forms.CheckBox chkAll;
    }
}