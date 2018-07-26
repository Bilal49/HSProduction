
partial class frmFicalYearClosing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFicalYearClosing));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtpFiscalEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpFicalStart = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSalesCheck = new System.Windows.Forms.Button();
            this.btnPurchaseCheck = new System.Windows.Forms.Button();
            this.btnVoucherCheck = new System.Windows.Forms.Button();
            this.pbSalesValid = new System.Windows.Forms.PictureBox();
            this.pbSalesInvalid = new System.Windows.Forms.PictureBox();
            this.pbPurchaseInvalid = new System.Windows.Forms.PictureBox();
            this.pbPurchaseValid = new System.Windows.Forms.PictureBox();
            this.pbVoucherInvalid = new System.Windows.Forms.PictureBox();
            this.pbVoucherValid = new System.Windows.Forms.PictureBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSalesValid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSalesInvalid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPurchaseInvalid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPurchaseValid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVoucherInvalid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVoucherValid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 18F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(141)))), ((int)(((byte)(188)))));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 28);
            this.label1.TabIndex = 11;
            this.label1.Text = "Fiscal Year Closing";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtpFiscalEnd);
            this.groupBox2.Controls.Add(this.dtpFicalStart);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 40);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(532, 72);
            this.groupBox2.TabIndex = 72;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fical Year";
            // 
            // dtpFiscalEnd
            // 
            this.dtpFiscalEnd.CustomFormat = "dd-MMM-yyyy";
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pbVoucherInvalid);
            this.groupBox1.Controls.Add(this.pbVoucherValid);
            this.groupBox1.Controls.Add(this.pbPurchaseInvalid);
            this.groupBox1.Controls.Add(this.pbPurchaseValid);
            this.groupBox1.Controls.Add(this.pbSalesInvalid);
            this.groupBox1.Controls.Add(this.pbSalesValid);
            this.groupBox1.Controls.Add(this.btnVoucherCheck);
            this.groupBox1.Controls.Add(this.btnPurchaseCheck);
            this.groupBox1.Controls.Add(this.btnSalesCheck);
            this.groupBox1.Location = new System.Drawing.Point(12, 118);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(532, 141);
            this.groupBox1.TabIndex = 73;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Posting Transaction Verification";
            // 
            // btnSalesCheck
            // 
            this.btnSalesCheck.Font = new System.Drawing.Font("Arial", 12F);
            this.btnSalesCheck.Location = new System.Drawing.Point(6, 19);
            this.btnSalesCheck.Name = "btnSalesCheck";
            this.btnSalesCheck.Size = new System.Drawing.Size(155, 34);
            this.btnSalesCheck.TabIndex = 0;
            this.btnSalesCheck.Text = "Sales Check";
            this.btnSalesCheck.UseVisualStyleBackColor = true;
            this.btnSalesCheck.Click += new System.EventHandler(this.btnSalesCheck_Click);
            // 
            // btnPurchaseCheck
            // 
            this.btnPurchaseCheck.Font = new System.Drawing.Font("Arial", 12F);
            this.btnPurchaseCheck.Location = new System.Drawing.Point(6, 59);
            this.btnPurchaseCheck.Name = "btnPurchaseCheck";
            this.btnPurchaseCheck.Size = new System.Drawing.Size(155, 34);
            this.btnPurchaseCheck.TabIndex = 1;
            this.btnPurchaseCheck.Text = "Purchase Check";
            this.btnPurchaseCheck.UseVisualStyleBackColor = true;
            this.btnPurchaseCheck.Click += new System.EventHandler(this.btnPurchaseCheck_Click);
            // 
            // btnVoucherCheck
            // 
            this.btnVoucherCheck.Font = new System.Drawing.Font("Arial", 12F);
            this.btnVoucherCheck.Location = new System.Drawing.Point(6, 99);
            this.btnVoucherCheck.Name = "btnVoucherCheck";
            this.btnVoucherCheck.Size = new System.Drawing.Size(155, 34);
            this.btnVoucherCheck.TabIndex = 2;
            this.btnVoucherCheck.Text = "Voucher Check";
            this.btnVoucherCheck.UseVisualStyleBackColor = true;
            this.btnVoucherCheck.Click += new System.EventHandler(this.btnVoucherCheck_Click);
            // 
            // pbSalesValid
            // 
            this.pbSalesValid.Image = ((System.Drawing.Image)(resources.GetObject("pbSalesValid.Image")));
            this.pbSalesValid.Location = new System.Drawing.Point(167, 19);
            this.pbSalesValid.Name = "pbSalesValid";
            this.pbSalesValid.Size = new System.Drawing.Size(32, 32);
            this.pbSalesValid.TabIndex = 3;
            this.pbSalesValid.TabStop = false;
            this.pbSalesValid.Visible = false;
            // 
            // pbSalesInvalid
            // 
            this.pbSalesInvalid.Image = ((System.Drawing.Image)(resources.GetObject("pbSalesInvalid.Image")));
            this.pbSalesInvalid.Location = new System.Drawing.Point(205, 19);
            this.pbSalesInvalid.Name = "pbSalesInvalid";
            this.pbSalesInvalid.Size = new System.Drawing.Size(32, 32);
            this.pbSalesInvalid.TabIndex = 4;
            this.pbSalesInvalid.TabStop = false;
            this.pbSalesInvalid.Visible = false;
            // 
            // pbPurchaseInvalid
            // 
            this.pbPurchaseInvalid.Image = ((System.Drawing.Image)(resources.GetObject("pbPurchaseInvalid.Image")));
            this.pbPurchaseInvalid.Location = new System.Drawing.Point(205, 61);
            this.pbPurchaseInvalid.Name = "pbPurchaseInvalid";
            this.pbPurchaseInvalid.Size = new System.Drawing.Size(32, 32);
            this.pbPurchaseInvalid.TabIndex = 6;
            this.pbPurchaseInvalid.TabStop = false;
            this.pbPurchaseInvalid.Visible = false;
            // 
            // pbPurchaseValid
            // 
            this.pbPurchaseValid.Image = ((System.Drawing.Image)(resources.GetObject("pbPurchaseValid.Image")));
            this.pbPurchaseValid.Location = new System.Drawing.Point(167, 61);
            this.pbPurchaseValid.Name = "pbPurchaseValid";
            this.pbPurchaseValid.Size = new System.Drawing.Size(32, 32);
            this.pbPurchaseValid.TabIndex = 5;
            this.pbPurchaseValid.TabStop = false;
            this.pbPurchaseValid.Visible = false;
            // 
            // pbVoucherInvalid
            // 
            this.pbVoucherInvalid.Image = ((System.Drawing.Image)(resources.GetObject("pbVoucherInvalid.Image")));
            this.pbVoucherInvalid.Location = new System.Drawing.Point(205, 101);
            this.pbVoucherInvalid.Name = "pbVoucherInvalid";
            this.pbVoucherInvalid.Size = new System.Drawing.Size(32, 32);
            this.pbVoucherInvalid.TabIndex = 8;
            this.pbVoucherInvalid.TabStop = false;
            this.pbVoucherInvalid.Visible = false;
            // 
            // pbVoucherValid
            // 
            this.pbVoucherValid.Image = ((System.Drawing.Image)(resources.GetObject("pbVoucherValid.Image")));
            this.pbVoucherValid.Location = new System.Drawing.Point(167, 101);
            this.pbVoucherValid.Name = "pbVoucherValid";
            this.pbVoucherValid.Size = new System.Drawing.Size(32, 32);
            this.pbVoucherValid.TabIndex = 7;
            this.pbVoucherValid.TabStop = false;
            this.pbVoucherValid.Visible = false;
            // 
            // frmFicalYearClosing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 467);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "frmFicalYearClosing";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmFicalYearClosing_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbSalesValid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSalesInvalid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPurchaseInvalid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPurchaseValid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVoucherInvalid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVoucherValid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.DateTimePicker dtpFiscalEnd;
    private System.Windows.Forms.DateTimePicker dtpFicalStart;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Button btnSalesCheck;
    private System.Windows.Forms.Button btnVoucherCheck;
    private System.Windows.Forms.Button btnPurchaseCheck;
    private System.Windows.Forms.PictureBox pbSalesInvalid;
    private System.Windows.Forms.PictureBox pbSalesValid;
    private System.Windows.Forms.PictureBox pbVoucherInvalid;
    private System.Windows.Forms.PictureBox pbVoucherValid;
    private System.Windows.Forms.PictureBox pbPurchaseInvalid;
    private System.Windows.Forms.PictureBox pbPurchaseValid;
}
