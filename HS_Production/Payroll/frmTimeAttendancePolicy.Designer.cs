using System;
namespace FIL.Payroll
{
    partial class frmTimeAttendancePolicy
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
        //private void InitializeComponent()
        //{
        //    //this.label1 = new System.Windows.Forms.Label();
        //    this.SuspendLayout();

        //    // 
        //    // frmTimeAttendancePolicy
        //    // 
        //    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        //    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        //    this.ClientSize = new System.Drawing.Size(284, 261);
        //    //this.Controls.Add(this.label1);

        //    this.Name = "frmTimeAttendancePolicy";
        //    this.Text = "frmTimeAttendancePolicy";
        //    this.ResumeLayout(false);
        //    this.PerformLayout();

        //}

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTimeAttendancePolicy));
            this.lblDepartmentCode = new System.Windows.Forms.Label();
            this.TextBoxDepartmentName = new System.Windows.Forms.TextBox();
            this.btnDepartLookUp = new System.Windows.Forms.Button();
            this.Label3 = new System.Windows.Forms.Label();
            this.grpDepartment = new System.Windows.Forms.GroupBox();
            this.txtDeductionAfterLate = new System.Windows.Forms.TextBox();
            this.Label17 = new System.Windows.Forms.Label();
            this.txtLateAfter = new System.Windows.Forms.TextBox();
            this.Label16 = new System.Windows.Forms.Label();
            this.EndAttTime = new System.Windows.Forms.DateTimePicker();
            this.BeginAttTime = new System.Windows.Forms.DateTimePicker();
            this.DutyTimeOFF = new System.Windows.Forms.DateTimePicker();
            this.DutyTimeON = new System.Windows.Forms.DateTimePicker();
            this.txtOffDayDutyRate = new System.Windows.Forms.TextBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.TextBoxShiftCode = new System.Windows.Forms.TextBox();
            this.btnSearchPolicyCode = new System.Windows.Forms.Button();
            this.txtPolicyCode = new System.Windows.Forms.TextBox();
            this.Label15 = new System.Windows.Forms.Label();
            this.TextBoxDepartmentCode = new System.Windows.Forms.TextBox();
            this.txtGraceTime = new System.Windows.Forms.TextBox();
            this.txtOverTimeRate = new System.Windows.Forms.TextBox();
            this.txtHalfDayStartTime = new System.Windows.Forms.TextBox();
            this.Label14 = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.Label11 = new System.Windows.Forms.Label();
            this.Label12 = new System.Windows.Forms.Label();
            this.Label13 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.txtSickLeave = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.btnShiftLookUp = new System.Windows.Forms.Button();
            this.TextBoxShiftName = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtCasualLeave = new System.Windows.Forms.TextBox();
            this.lblDepartmentName = new System.Windows.Forms.Label();
            this.TextBoxEndAttTime2 = new DevExpress.XtraEditors.TimeEdit();
            this.TextBoxBeginAttTime2 = new DevExpress.XtraEditors.TimeEdit();
            this.DateTimePicker4 = new System.Windows.Forms.DateTimePicker();
            this.GraceTime = new System.Windows.Forms.DateTimePicker();
            this.TextBoxOffDutyTime = new DevExpress.XtraEditors.TimeEdit();
            this.TextBoxOnDutyTime = new DevExpress.XtraEditors.TimeEdit();
            this.label22 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.grpDepartment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TextBoxEndAttTime2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBoxBeginAttTime2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBoxOffDutyTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBoxOnDutyTime.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDepartmentCode
            // 
            this.lblDepartmentCode.AutoSize = true;
            this.lblDepartmentCode.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartmentCode.ForeColor = System.Drawing.Color.Black;
            this.lblDepartmentCode.Location = new System.Drawing.Point(9, 291);
            this.lblDepartmentCode.Name = "lblDepartmentCode";
            this.lblDepartmentCode.Size = new System.Drawing.Size(71, 13);
            this.lblDepartmentCode.TabIndex = 0;
            this.lblDepartmentCode.Text = "Department :";
            this.lblDepartmentCode.Visible = false;
            // 
            // TextBoxDepartmentName
            // 
            this.TextBoxDepartmentName.Location = new System.Drawing.Point(135, 289);
            this.TextBoxDepartmentName.MaxLength = 2;
            this.TextBoxDepartmentName.Name = "TextBoxDepartmentName";
            this.TextBoxDepartmentName.Size = new System.Drawing.Size(148, 20);
            this.TextBoxDepartmentName.TabIndex = 1;
            this.TextBoxDepartmentName.Visible = false;
            // 
            // btnDepartLookUp
            // 
            this.btnDepartLookUp.FlatAppearance.BorderSize = 0;
            this.btnDepartLookUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDepartLookUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDepartLookUp.Location = new System.Drawing.Point(284, 287);
            this.btnDepartLookUp.Name = "btnDepartLookUp";
            this.btnDepartLookUp.Size = new System.Drawing.Size(20, 20);
            this.btnDepartLookUp.TabIndex = 2;
            this.btnDepartLookUp.TabStop = false;
            this.btnDepartLookUp.UseVisualStyleBackColor = true;
            this.btnDepartLookUp.Visible = false;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(35, 280);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(0, 13);
            this.Label3.TabIndex = 4;
            // 
            // grpDepartment
            // 
            this.grpDepartment.Controls.Add(this.txtDeductionAfterLate);
            this.grpDepartment.Controls.Add(this.Label17);
            this.grpDepartment.Controls.Add(this.txtLateAfter);
            this.grpDepartment.Controls.Add(this.Label16);
            this.grpDepartment.Controls.Add(this.EndAttTime);
            this.grpDepartment.Controls.Add(this.BeginAttTime);
            this.grpDepartment.Controls.Add(this.DutyTimeOFF);
            this.grpDepartment.Controls.Add(this.DutyTimeON);
            this.grpDepartment.Controls.Add(this.txtOffDayDutyRate);
            this.grpDepartment.Controls.Add(this.Label8);
            this.grpDepartment.Controls.Add(this.TextBoxShiftCode);
            this.grpDepartment.Controls.Add(this.btnSearchPolicyCode);
            this.grpDepartment.Controls.Add(this.txtPolicyCode);
            this.grpDepartment.Controls.Add(this.Label15);
            this.grpDepartment.Controls.Add(this.TextBoxDepartmentCode);
            this.grpDepartment.Controls.Add(this.txtGraceTime);
            this.grpDepartment.Controls.Add(this.txtOverTimeRate);
            this.grpDepartment.Controls.Add(this.txtHalfDayStartTime);
            this.grpDepartment.Controls.Add(this.Label14);
            this.grpDepartment.Controls.Add(this.Label10);
            this.grpDepartment.Controls.Add(this.Label11);
            this.grpDepartment.Controls.Add(this.Label12);
            this.grpDepartment.Controls.Add(this.Label13);
            this.grpDepartment.Controls.Add(this.Label5);
            this.grpDepartment.Controls.Add(this.Label4);
            this.grpDepartment.Controls.Add(this.txtSickLeave);
            this.grpDepartment.Controls.Add(this.Label2);
            this.grpDepartment.Controls.Add(this.btnShiftLookUp);
            this.grpDepartment.Controls.Add(this.TextBoxShiftName);
            this.grpDepartment.Controls.Add(this.Label1);
            this.grpDepartment.Controls.Add(this.btnDepartLookUp);
            this.grpDepartment.Controls.Add(this.txtCasualLeave);
            this.grpDepartment.Controls.Add(this.lblDepartmentName);
            this.grpDepartment.Controls.Add(this.Label3);
            this.grpDepartment.Controls.Add(this.TextBoxDepartmentName);
            this.grpDepartment.Controls.Add(this.lblDepartmentCode);
            this.grpDepartment.Location = new System.Drawing.Point(8, 12);
            this.grpDepartment.Name = "grpDepartment";
            this.grpDepartment.Size = new System.Drawing.Size(523, 210);
            this.grpDepartment.TabIndex = 1;
            this.grpDepartment.TabStop = false;
            // 
            // txtDeductionAfterLate
            // 
            this.txtDeductionAfterLate.Location = new System.Drawing.Point(465, 169);
            this.txtDeductionAfterLate.MaxLength = 50;
            this.txtDeductionAfterLate.Name = "txtDeductionAfterLate";
            this.txtDeductionAfterLate.Size = new System.Drawing.Size(46, 20);
            this.txtDeductionAfterLate.TabIndex = 12;
            // 
            // Label17
            // 
            this.Label17.AutoSize = true;
            this.Label17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label17.ForeColor = System.Drawing.Color.Black;
            this.Label17.Location = new System.Drawing.Point(310, 172);
            this.Label17.Name = "Label17";
            this.Label17.Size = new System.Drawing.Size(135, 13);
            this.Label17.TabIndex = 37;
            this.Label17.Text = "Salary deduction after late";
            // 
            // txtLateAfter
            // 
            this.txtLateAfter.Location = new System.Drawing.Point(237, 169);
            this.txtLateAfter.MaxLength = 50;
            this.txtLateAfter.Name = "txtLateAfter";
            this.txtLateAfter.Size = new System.Drawing.Size(46, 20);
            this.txtLateAfter.TabIndex = 11;
            // 
            // Label16
            // 
            this.Label16.AutoSize = true;
            this.Label16.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label16.ForeColor = System.Drawing.Color.Black;
            this.Label16.Location = new System.Drawing.Point(8, 172);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(144, 13);
            this.Label16.TabIndex = 35;
            this.Label16.Text = "Consider Late After (Mints) :";
            // 
            // EndAttTime
            // 
            this.EndAttTime.CustomFormat = "hh:mm tt";
            this.EndAttTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.EndAttTime.Location = new System.Drawing.Point(407, 117);
            this.EndAttTime.Name = "EndAttTime";
            this.EndAttTime.Size = new System.Drawing.Size(104, 20);
            this.EndAttTime.TabIndex = 8;
            // 
            // BeginAttTime
            // 
            this.BeginAttTime.CustomFormat = "hh:mm tt";
            this.BeginAttTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.BeginAttTime.Location = new System.Drawing.Point(407, 92);
            this.BeginAttTime.Name = "BeginAttTime";
            this.BeginAttTime.Size = new System.Drawing.Size(104, 20);
            this.BeginAttTime.TabIndex = 7;
            // 
            // DutyTimeOFF
            // 
            this.DutyTimeOFF.CustomFormat = "hh:mm tt";
            this.DutyTimeOFF.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DutyTimeOFF.Location = new System.Drawing.Point(179, 117);
            this.DutyTimeOFF.Name = "DutyTimeOFF";
            this.DutyTimeOFF.Size = new System.Drawing.Size(104, 20);
            this.DutyTimeOFF.TabIndex = 6;
            // 
            // DutyTimeON
            // 
            this.DutyTimeON.CustomFormat = "hh:mm tt";
            this.DutyTimeON.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DutyTimeON.Location = new System.Drawing.Point(179, 91);
            this.DutyTimeON.Name = "DutyTimeON";
            this.DutyTimeON.Size = new System.Drawing.Size(104, 20);
            this.DutyTimeON.TabIndex = 5;
            // 
            // txtOffDayDutyRate
            // 
            this.txtOffDayDutyRate.Location = new System.Drawing.Point(465, 144);
            this.txtOffDayDutyRate.MaxLength = 50;
            this.txtOffDayDutyRate.Name = "txtOffDayDutyRate";
            this.txtOffDayDutyRate.Size = new System.Drawing.Size(46, 20);
            this.txtOffDayDutyRate.TabIndex = 10;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label8.ForeColor = System.Drawing.Color.Black;
            this.Label8.Location = new System.Drawing.Point(310, 146);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(156, 13);
            this.Label8.TabIndex = 33;
            this.Label8.Text = "Off Day Duty Rate - In Day(s):";
            // 
            // TextBoxShiftCode
            // 
            this.TextBoxShiftCode.Location = new System.Drawing.Point(354, 284);
            this.TextBoxShiftCode.MaxLength = 50;
            this.TextBoxShiftCode.Name = "TextBoxShiftCode";
            this.TextBoxShiftCode.Size = new System.Drawing.Size(46, 20);
            this.TextBoxShiftCode.TabIndex = 37;
            this.TextBoxShiftCode.Visible = false;
            // 
            // btnSearchPolicyCode
            // 
            this.btnSearchPolicyCode.FlatAppearance.BorderSize = 0;
            this.btnSearchPolicyCode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSearchPolicyCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchPolicyCode.Location = new System.Drawing.Point(211, 12);
            this.btnSearchPolicyCode.Name = "btnSearchPolicyCode";
            this.btnSearchPolicyCode.Size = new System.Drawing.Size(20, 20);
            this.btnSearchPolicyCode.TabIndex = 1;
            this.btnSearchPolicyCode.TabStop = false;
            this.btnSearchPolicyCode.UseVisualStyleBackColor = true;
            // 
            // txtPolicyCode
            // 
            this.txtPolicyCode.Location = new System.Drawing.Point(237, 13);
            this.txtPolicyCode.MaxLength = 50;
            this.txtPolicyCode.Name = "txtPolicyCode";
            this.txtPolicyCode.Size = new System.Drawing.Size(46, 20);
            this.txtPolicyCode.TabIndex = 0;
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label15.ForeColor = System.Drawing.Color.Black;
            this.Label15.Location = new System.Drawing.Point(8, 16);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(69, 13);
            this.Label15.TabIndex = 0;
            this.Label15.Text = "Policy Code :";
            // 
            // TextBoxDepartmentCode
            // 
            this.TextBoxDepartmentCode.Location = new System.Drawing.Point(85, 289);
            this.TextBoxDepartmentCode.MaxLength = 50;
            this.TextBoxDepartmentCode.Name = "TextBoxDepartmentCode";
            this.TextBoxDepartmentCode.Size = new System.Drawing.Size(46, 20);
            this.TextBoxDepartmentCode.TabIndex = 33;
            this.TextBoxDepartmentCode.Visible = false;
            // 
            // txtGraceTime
            // 
            this.txtGraceTime.Location = new System.Drawing.Point(237, 143);
            this.txtGraceTime.MaxLength = 50;
            this.txtGraceTime.Name = "txtGraceTime";
            this.txtGraceTime.Size = new System.Drawing.Size(46, 20);
            this.txtGraceTime.TabIndex = 9;
            // 
            // txtOverTimeRate
            // 
            this.txtOverTimeRate.Location = new System.Drawing.Point(465, 65);
            this.txtOverTimeRate.MaxLength = 50;
            this.txtOverTimeRate.Name = "txtOverTimeRate";
            this.txtOverTimeRate.Size = new System.Drawing.Size(46, 20);
            this.txtOverTimeRate.TabIndex = 4;
            // 
            // txtHalfDayStartTime
            // 
            this.txtHalfDayStartTime.Location = new System.Drawing.Point(237, 65);
            this.txtHalfDayStartTime.MaxLength = 50;
            this.txtHalfDayStartTime.Name = "txtHalfDayStartTime";
            this.txtHalfDayStartTime.Size = new System.Drawing.Size(46, 20);
            this.txtHalfDayStartTime.TabIndex = 3;
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label14.ForeColor = System.Drawing.Color.Black;
            this.Label14.Location = new System.Drawing.Point(8, 147);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(103, 13);
            this.Label14.TabIndex = 31;
            this.Label14.Text = "Grace Time (Mints) :";
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label10.ForeColor = System.Drawing.Color.Black;
            this.Label10.Location = new System.Drawing.Point(310, 121);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(79, 13);
            this.Label10.TabIndex = 29;
            this.Label10.Text = "End Att. Time :";
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label11.ForeColor = System.Drawing.Color.Black;
            this.Label11.Location = new System.Drawing.Point(8, 121);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(81, 13);
            this.Label11.TabIndex = 27;
            this.Label11.Text = "Off Duty Time :";
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label12.ForeColor = System.Drawing.Color.Black;
            this.Label12.Location = new System.Drawing.Point(310, 96);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(87, 13);
            this.Label12.TabIndex = 25;
            this.Label12.Text = "Begin Att. Time :";
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label13.ForeColor = System.Drawing.Color.Black;
            this.Label13.Location = new System.Drawing.Point(8, 96);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(79, 13);
            this.Label13.TabIndex = 23;
            this.Label13.Text = "On Duty Time :";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.ForeColor = System.Drawing.Color.Black;
            this.Label5.Location = new System.Drawing.Point(310, 69);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(108, 13);
            this.Label5.TabIndex = 13;
            this.Label5.Text = "Over Time Rate(%) :";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.ForeColor = System.Drawing.Color.Black;
            this.Label4.Location = new System.Drawing.Point(8, 69);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(167, 13);
            this.Label4.TabIndex = 11;
            this.Label4.Text = "Halfday Start Time After (Mints) :";
            // 
            // txtSickLeave
            // 
            this.txtSickLeave.Location = new System.Drawing.Point(465, 39);
            this.txtSickLeave.MaxLength = 50;
            this.txtSickLeave.Name = "txtSickLeave";
            this.txtSickLeave.Size = new System.Drawing.Size(46, 20);
            this.txtSickLeave.TabIndex = 2;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(310, 43);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(64, 13);
            this.Label2.TabIndex = 9;
            this.Label2.Text = "Sick Leave :";
            // 
            // btnShiftLookUp
            // 
            this.btnShiftLookUp.FlatAppearance.BorderSize = 0;
            this.btnShiftLookUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnShiftLookUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShiftLookUp.Location = new System.Drawing.Point(516, 283);
            this.btnShiftLookUp.Name = "btnShiftLookUp";
            this.btnShiftLookUp.Size = new System.Drawing.Size(20, 20);
            this.btnShiftLookUp.TabIndex = 7;
            this.btnShiftLookUp.TabStop = false;
            this.btnShiftLookUp.UseVisualStyleBackColor = true;
            this.btnShiftLookUp.Visible = false;
            // 
            // TextBoxShiftName
            // 
            this.TextBoxShiftName.Location = new System.Drawing.Point(406, 284);
            this.TextBoxShiftName.MaxLength = 2;
            this.TextBoxShiftName.Name = "TextBoxShiftName";
            this.TextBoxShiftName.Size = new System.Drawing.Size(108, 20);
            this.TextBoxShiftName.TabIndex = 6;
            this.TextBoxShiftName.Visible = false;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(313, 288);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(36, 13);
            this.Label1.TabIndex = 5;
            this.Label1.Text = "Shift :";
            this.Label1.Visible = false;
            // 
            // txtCasualLeave
            // 
            this.txtCasualLeave.Location = new System.Drawing.Point(237, 39);
            this.txtCasualLeave.MaxLength = 50;
            this.txtCasualLeave.Name = "txtCasualLeave";
            this.txtCasualLeave.Size = new System.Drawing.Size(46, 20);
            this.txtCasualLeave.TabIndex = 1;
            // 
            // lblDepartmentName
            // 
            this.lblDepartmentName.AutoSize = true;
            this.lblDepartmentName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartmentName.ForeColor = System.Drawing.Color.Black;
            this.lblDepartmentName.Location = new System.Drawing.Point(8, 43);
            this.lblDepartmentName.Name = "lblDepartmentName";
            this.lblDepartmentName.Size = new System.Drawing.Size(78, 13);
            this.lblDepartmentName.TabIndex = 7;
            this.lblDepartmentName.Text = "Casual Leave :";
            // 
            // TextBoxEndAttTime2
            // 
            this.TextBoxEndAttTime2.EditValue = new System.DateTime(2012, 3, 26, 0, 0, 0, 0);
            this.TextBoxEndAttTime2.Location = new System.Drawing.Point(437, 262);
            this.TextBoxEndAttTime2.Name = "TextBoxEndAttTime2";
            this.TextBoxEndAttTime2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.TextBoxEndAttTime2.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.TextBoxEndAttTime2.Properties.Mask.EditMask = "(0?[1-9]|1[012]):[0-5]\\d(AM|PM)";
            this.TextBoxEndAttTime2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.TextBoxEndAttTime2.Size = new System.Drawing.Size(42, 20);
            this.TextBoxEndAttTime2.TabIndex = 31;
            this.TextBoxEndAttTime2.Visible = false;
            // 
            // TextBoxBeginAttTime2
            // 
            this.TextBoxBeginAttTime2.EditValue = new System.DateTime(2012, 3, 26, 0, 0, 0, 0);
            this.TextBoxBeginAttTime2.Location = new System.Drawing.Point(437, 242);
            this.TextBoxBeginAttTime2.Name = "TextBoxBeginAttTime2";
            this.TextBoxBeginAttTime2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.TextBoxBeginAttTime2.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.TextBoxBeginAttTime2.Properties.Mask.EditMask = "(0?[1-9]|1[012]):[0-5]\\d(AM|PM)";
            this.TextBoxBeginAttTime2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.TextBoxBeginAttTime2.Size = new System.Drawing.Size(42, 20);
            this.TextBoxBeginAttTime2.TabIndex = 30;
            this.TextBoxBeginAttTime2.Visible = false;
            // 
            // DateTimePicker4
            // 
            this.DateTimePicker4.CustomFormat = "hh:mm tt";
            this.DateTimePicker4.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateTimePicker4.Location = new System.Drawing.Point(19, 263);
            this.DateTimePicker4.Name = "DateTimePicker4";
            this.DateTimePicker4.Size = new System.Drawing.Size(37, 20);
            this.DateTimePicker4.TabIndex = 44;
            this.DateTimePicker4.Visible = false;
            // 
            // GraceTime
            // 
            this.GraceTime.CustomFormat = "hh:mm tt";
            this.GraceTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.GraceTime.Location = new System.Drawing.Point(19, 244);
            this.GraceTime.Name = "GraceTime";
            this.GraceTime.Size = new System.Drawing.Size(37, 20);
            this.GraceTime.TabIndex = 43;
            this.GraceTime.Visible = false;
            // 
            // TextBoxOffDutyTime
            // 
            this.TextBoxOffDutyTime.EditValue = new System.DateTime(2012, 3, 26, 0, 0, 0, 0);
            this.TextBoxOffDutyTime.Location = new System.Drawing.Point(496, 263);
            this.TextBoxOffDutyTime.Name = "TextBoxOffDutyTime";
            this.TextBoxOffDutyTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.TextBoxOffDutyTime.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.TextBoxOffDutyTime.Properties.Mask.EditMask = "(0?[1-9]|1[012]):[0-5]\\d(AM|PM)";
            this.TextBoxOffDutyTime.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.TextBoxOffDutyTime.Size = new System.Drawing.Size(28, 20);
            this.TextBoxOffDutyTime.TabIndex = 28;
            this.TextBoxOffDutyTime.Visible = false;
            // 
            // TextBoxOnDutyTime
            // 
            this.TextBoxOnDutyTime.EditValue = new System.DateTime(2012, 3, 26, 0, 0, 0, 0);
            this.TextBoxOnDutyTime.Location = new System.Drawing.Point(496, 243);
            this.TextBoxOnDutyTime.Name = "TextBoxOnDutyTime";
            this.TextBoxOnDutyTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.TextBoxOnDutyTime.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.TextBoxOnDutyTime.Properties.Mask.EditMask = "(0?[1-9]|1[012]):[0-5]\\d(AM|PM)";
            this.TextBoxOnDutyTime.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.TextBoxOnDutyTime.Size = new System.Drawing.Size(28, 20);
            this.TextBoxOnDutyTime.TabIndex = 27;
            this.TextBoxOnDutyTime.Visible = false;
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(241, 270);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(59, 18);
            this.label22.TabIndex = 231;
            this.label22.Text = "Update";
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
            this.btnUpdate.Location = new System.Drawing.Point(248, 231);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(44, 36);
            this.btnUpdate.TabIndex = 226;
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // frmTimeAttendancePolicy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(541, 295);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.DateTimePicker4);
            this.Controls.Add(this.GraceTime);
            this.Controls.Add(this.TextBoxEndAttTime2);
            this.Controls.Add(this.TextBoxBeginAttTime2);
            this.Controls.Add(this.grpDepartment);
            this.Controls.Add(this.TextBoxOnDutyTime);
            this.Controls.Add(this.TextBoxOffDutyTime);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmTimeAttendancePolicy";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Time Attendance Policy";
            this.Load += new System.EventHandler(this.frmTimeAttendancePolicy_Load);
            this.grpDepartment.ResumeLayout(false);
            this.grpDepartment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TextBoxEndAttTime2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBoxBeginAttTime2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBoxOffDutyTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBoxOnDutyTime.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private System.Windows.Forms.Label label1;
        System.Windows.Forms.Label lblDepartmentCode;
        System.Windows.Forms.TextBox TextBoxDepartmentName;
        System.Windows.Forms.Button btnDepartLookUp;
        System.Windows.Forms.Label Label3;
        System.Windows.Forms.GroupBox grpDepartment;
        System.Windows.Forms.TextBox txtCasualLeave;
        System.Windows.Forms.Label lblDepartmentName;
        System.Windows.Forms.Button btnShiftLookUp;
        System.Windows.Forms.TextBox TextBoxShiftName;
        System.Windows.Forms.Label Label1;
        System.Windows.Forms.Label Label5;
        System.Windows.Forms.Label Label4;
        System.Windows.Forms.TextBox txtSickLeave;
        System.Windows.Forms.Label Label2;
        System.Windows.Forms.Label Label14;
        System.Windows.Forms.Label Label10;
        System.Windows.Forms.Label Label11;
        System.Windows.Forms.Label Label12;
        System.Windows.Forms.Label Label13;
        System.Windows.Forms.TextBox txtOverTimeRate;
        System.Windows.Forms.TextBox txtHalfDayStartTime;
        System.Windows.Forms.TextBox txtGraceTime;
        DevExpress.XtraEditors.TimeEdit TextBoxOffDutyTime;
        DevExpress.XtraEditors.TimeEdit TextBoxOnDutyTime;
        DevExpress.XtraEditors.TimeEdit TextBoxEndAttTime2;
        DevExpress.XtraEditors.TimeEdit TextBoxBeginAttTime2;
        System.Windows.Forms.TextBox TextBoxDepartmentCode;
        System.Windows.Forms.Button btnSearchPolicyCode;
        System.Windows.Forms.TextBox txtPolicyCode;
        System.Windows.Forms.Label Label15;
        System.Windows.Forms.TextBox TextBoxShiftCode;
        System.Windows.Forms.TextBox txtOffDayDutyRate;
        System.Windows.Forms.Label Label8;
        System.Windows.Forms.DateTimePicker DateTimePicker4;
        System.Windows.Forms.DateTimePicker GraceTime;
        System.Windows.Forms.DateTimePicker DutyTimeOFF;
        System.Windows.Forms.DateTimePicker DutyTimeON;
        System.Windows.Forms.DateTimePicker EndAttTime;
        System.Windows.Forms.DateTimePicker BeginAttTime;
        System.Windows.Forms.TextBox txtDeductionAfterLate;
        System.Windows.Forms.Label Label17;
        System.Windows.Forms.TextBox txtLateAfter;
        System.Windows.Forms.Label Label16;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btnUpdate;

    }
}