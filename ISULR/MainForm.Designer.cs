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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.statusStrip = new System.Windows.Forms.StatusStrip();
      this.slblRecords = new System.Windows.Forms.ToolStripStatusLabel();
      this.slblAppID = new System.Windows.Forms.ToolStripStatusLabel();
      this.slblAppName = new System.Windows.Forms.ToolStripStatusLabel();
      this.listView = new System.Windows.Forms.ListView();
      this.chType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.chDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
      this.openLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.exportToTXTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
      this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
      this.statusStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // statusStrip
      // 
      this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.slblRecords,
            this.slblAppID,
            this.slblAppName,
            this.toolStripSplitButton1});
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
      this.slblAppID.Size = new System.Drawing.Size(559, 17);
      this.slblAppID.Spring = true;
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
      // toolStripSplitButton1
      // 
      this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToTXTToolStripMenuItem,
            this.openLogToolStripMenuItem});
      this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
      this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolStripSplitButton1.Name = "toolStripSplitButton1";
      this.toolStripSplitButton1.Size = new System.Drawing.Size(32, 20);
      this.toolStripSplitButton1.Text = "toolStripSplitButton1";
      // 
      // openLogToolStripMenuItem
      // 
      this.openLogToolStripMenuItem.Name = "openLogToolStripMenuItem";
      this.openLogToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.openLogToolStripMenuItem.Text = "Open Log";
      this.openLogToolStripMenuItem.Click += new System.EventHandler(this.openLogToolStripMenuItem_Click);
      // 
      // exportToTXTToolStripMenuItem
      // 
      this.exportToTXTToolStripMenuItem.Name = "exportToTXTToolStripMenuItem";
      this.exportToTXTToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.exportToTXTToolStripMenuItem.Text = "Export to TXT";
      this.exportToTXTToolStripMenuItem.Click += new System.EventHandler(this.exportToTXTToolStripMenuItem_Click);
      // 
      // openFileDialog
      // 
      this.openFileDialog.Filter = "Inno setup logs|unins*.dat";
      // 
      // saveFileDialog
      // 
      this.saveFileDialog.Filter = "Text files|*.txt";
      // 
      // MainForm
      // 
      this.AllowDrop = true;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.listView);
      this.Controls.Add(this.statusStrip);
      this.DoubleBuffered = true;
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
    private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
    private System.Windows.Forms.ToolStripMenuItem exportToTXTToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem openLogToolStripMenuItem;
    private System.Windows.Forms.OpenFileDialog openFileDialog;
    private System.Windows.Forms.SaveFileDialog saveFileDialog;
  }
}

