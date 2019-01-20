namespace ISULR
{
  partial class MainForm
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
      this.statusStrip = new System.Windows.Forms.StatusStrip();
      this.slblRecords = new System.Windows.Forms.ToolStripStatusLabel();
      this.slblAppID = new System.Windows.Forms.ToolStripStatusLabel();
      this.slblAppName = new System.Windows.Forms.ToolStripStatusLabel();
      this.listView = new System.Windows.Forms.ListView();
      this.chType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.chDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.statusStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // statusStrip
      // 
      this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.slblRecords,
            this.slblAppID,
            this.slblAppName});
      this.statusStrip.Location = new System.Drawing.Point(0, 428);
      this.statusStrip.Name = "statusStrip";
      this.statusStrip.Size = new System.Drawing.Size(800, 22);
      this.statusStrip.TabIndex = 0;
      this.statusStrip.Text = "statusStrip1";
      // 
      // slblRecords
      // 
      this.slblRecords.AutoSize = false;
      this.slblRecords.Name = "slblRecords";
      this.slblRecords.Size = new System.Drawing.Size(100, 17);
      this.slblRecords.Text = "Records: n/a";
      // 
      // slblAppID
      // 
      this.slblAppID.Name = "slblAppID";
      this.slblAppID.Size = new System.Drawing.Size(42, 17);
      this.slblAppID.Text = "ID: n/a";
      // 
      // slblAppName
      // 
      this.slblAppName.Name = "slblAppName";
      this.slblAppName.Size = new System.Drawing.Size(63, 17);
      this.slblAppName.Text = "Name: n/a";
      // 
      // listView
      // 
      this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chType,
            this.chDescription});
      this.listView.FullRowSelect = true;
      this.listView.Location = new System.Drawing.Point(12, 12);
      this.listView.Name = "listView";
      this.listView.ShowItemToolTips = true;
      this.listView.Size = new System.Drawing.Size(776, 413);
      this.listView.TabIndex = 1;
      this.listView.UseCompatibleStateImageBehavior = false;
      this.listView.View = System.Windows.Forms.View.Details;
      this.listView.Resize += new System.EventHandler(this.listView_Resize);
      // 
      // chType
      // 
      this.chType.Text = "Type";
      this.chType.Width = 120;
      // 
      // chDescription
      // 
      this.chDescription.Text = "Description";
      // 
      // MainForm
      // 
      this.AllowDrop = true;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.listView);
      this.Controls.Add(this.statusStrip);
      this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
      this.Name = "MainForm";
      this.Text = "InnoSetup Logs Reader";
      this.Load += new System.EventHandler(this.MainForm_Load);
      this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
      this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
      this.statusStrip.ResumeLayout(false);
      this.statusStrip.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.StatusStrip statusStrip;
    private System.Windows.Forms.ToolStripStatusLabel slblRecords;
    private System.Windows.Forms.ListView listView;
    private System.Windows.Forms.ToolStripStatusLabel slblAppID;
    private System.Windows.Forms.ToolStripStatusLabel slblAppName;
    private System.Windows.Forms.ColumnHeader chType;
    private System.Windows.Forms.ColumnHeader chDescription;
  }
}

