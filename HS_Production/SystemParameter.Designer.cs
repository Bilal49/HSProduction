namespace FIL
{
    partial class SystemParameter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SystemParameter));
            this.btnUpdate = new System.Windows.Forms.Button();
            this.lblCode = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbNormalPrinter = new System.Windows.Forms.ComboBox();
            this.cmbPOSPrinter = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtReportFooterText = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtpFiscalEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpFicalStart = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(232)))), ((int)(((byte)(244)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.Location = new System.Drawing.Point(518, 332);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(44, 36);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCode.Location = new System.Drawing.Point(3, 25);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(108, 18);
            this.lblCode.TabIndex = 64;
            this.lblCode.Text = "Normal Printer";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(268, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 18);
            this.label1.TabIndex = 65;
            this.label1.Text = "POS Slip";
            // 
            // cmbNormalPrinter
            // 
            this.cmbNormalPrinter.Font = new System.Drawing.Font("Arial", 12F);
            this.cmbNormalPrinter.FormattingEnabled = true;
            this.cmbNormalPrinter.Location = new System.Drawing.Point(6, 46);
            this.cmbNormalPrinter.Name = "cmbNormalPrinter";
            this.cmbNormalPrinter.Size = new System.Drawing.Size(259, 26);
            this.cmbNormalPrinter.TabIndex = 66;
            // 
            // cmbPOSPrinter
            // 
            this.cmbPOSPrinter.Font = new System.Drawing.Font("Arial", 12F);
            this.cmbPOSPrinter.FormattingEnabled = true;
            this.cmbPOSPrinter.Location = new System.Drawing.Point(271, 46);
            this.cmbPOSPrinter.Name = "cmbPOSPrinter";
            this.cmbPOSPrinter.Size = new System.Drawing.Size(259, 26);
            this.cmbPOSPrinter.TabIndex = 67;
            this.cmbPOSPrinter.SelectedIndexChanged += new System.EventHandler(this.cmbPOSPrinter_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbNormalPrinter);
            this.groupBox1.Controls.Add(this.cmbPOSPrinter);
            this.groupBox1.Controls.Add(this.lblCode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(15, 99);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(547, 89);
            this.groupBox1.TabIndex = 68;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Printer Setting";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 18);
            this.label2.TabIndex = 69;
            this.label2.Text = "Report Footer Text";
            // 
            // txtReportFooterText
            // 
            this.txtReportFooterText.Font = new System.Drawing.Font("Arial", 12F);
            this.txtReportFooterText.Location = new System.Drawing.Point(21, 212);
            this.txtReportFooterText.Multiline = true;
            this.txtReportFooterText.Name = "txtReportFooterText";
            this.txtReportFooterText.Size = new System.Drawing.Size(524, 90);
            this.txtReportFooterText.TabIndex = 70;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtpFiscalEnd);
            this.groupBox2.Controls.Add(this.dtpFicalStart);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(15, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(547, 72);
            this.groupBox2.TabIndex = 71;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fical Year";
            // 
            // dtpFiscalEnd
            // 
            this.dtpFiscalEnd.CustomFormat = "dd-MMM-yyyy";
            this.dtpFiscalEnd.Enabled = false;
            this.dtpFiscalEnd.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpFiscalEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFiscalEnd.Location = new System.Drawing.Point(169, 40);
            this.dtpFiscalEnd.Name = "dtpFiscalEnd";
            this.dtpFiscalEnd.Size = new System.Drawing.Size(155, 26);
            this.dtpFiscalEnd.TabIndex = 68;
            // 
            // dtpFicalStart
            // 
            this.dtpFicalStart.CustomFormat = "dd-MMM-yyyy";
            this.dtpFicalStart.Enabled = false;
            this.dtpFicalStart.Font = new System.Drawing.Font("Arial", 12F);
            this.dtpFicalStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFicalStart.Location = new System.Drawing.Point(6, 40);
            this.dtpFicalStart.Name = "dtpFicalStart";
            this.dtpFicalStart.Size = new System.Drawing.Size(155, 26);
            this.dtpFicalStart.TabIndex = 67;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(166, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 18);
            this.label4.TabIndex = 66;
            this.label4.Text = "Fiscal Year End";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 18);
            this.label3.TabIndex = 65;
            this.label3.Text = "Fiscal Year Start";
            // 
            // SystemParameter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 380);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtReportFooterText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnUpdate);
            this.MaximizeBox = false;
            this.Name = "SystemParameter";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "System Parameter";
            this.Load += new System.EventHandler(this.SystemParameter_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbNormalPrinter;
        private System.Windows.Forms.ComboBox cmbPOSPrinter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtReportFooterText;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpFiscalEnd;
        private System.Windows.Forms.DateTimePicker dtpFicalStart;
    }
}