
partial class frmReportViewer
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportViewer));
        this.CrViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
        this.SuspendLayout();
        // 
        // CrViewer
        // 
        this.CrViewer.ActiveViewIndex = -1;
        this.CrViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.CrViewer.Cursor = System.Windows.Forms.Cursors.Default;
        this.CrViewer.Dock = System.Windows.Forms.DockStyle.Fill;
        this.CrViewer.Location = new System.Drawing.Point(0, 0);
        this.CrViewer.Name = "CrViewer";
        this.CrViewer.Size = new System.Drawing.Size(1125, 571);
        this.CrViewer.TabIndex = 187;
        this.CrViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
        this.CrViewer.ReportRefresh += new CrystalDecisions.Windows.Forms.RefreshEventHandler(this.crystalRptCustomerLedger_ReportRefresh);
        // 
        // frmReportViewer
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(1125, 571);
        this.Controls.Add(this.CrViewer);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.Name = "frmReportViewer";
        this.ShowIcon = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Load += new System.EventHandler(this.frmReportStockInn_Load);
        this.ResumeLayout(false);

    }

    #endregion

    private CrystalDecisions.Windows.Forms.CrystalReportViewer CrViewer;

}
