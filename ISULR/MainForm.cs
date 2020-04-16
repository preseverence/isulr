using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using LibISULR;
using LibISULR.Records;

namespace ISULR
{
  public partial class MainForm : Form
  {
    private string filename;
    private UninstallLog log;
    private const string TITLE = "InnoSetup Logs Reader";

    public MainForm(string filename)
    {
      this.filename = filename;
      InitializeComponent();

      listView_Resize(listView, EventArgs.Empty);
      Text = TITLE;
    }

    private void LoadLog()
    {
      using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
        log = new UninstallLog(fs);

      slblRecords.Text = $"Records: {log.Records.Count}";
      slblAppID.Text = $"ID: {log.AppId}";
      slblAppName.Text = $"ID: {log.AppName}";

      listView.BeginUpdate();
      listView.Items.Clear();

      foreach (BaseRecord record in log.Records)
      {
        ListViewItem item = new ListViewItem();
        item.Text = record.Type.ToString();
        item.SubItems.Add(record.Description);
        item.Tag = record;

        listView.Items.Add(item);
      }

      listView.EndUpdate();

      Text = $"{TITLE} - {filename}";
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
      if (filename != null)
        LoadLog();
    }

    private void listView_Resize(object sender, EventArgs e)
    {
      chDescription.Width = listView.ClientSize.Width - chType.Width;
    }

    private bool CheckFilename(string path)
    {
      string name = Path.GetFileName(path);

      return Regex.IsMatch(name, @"unins\d{3}\.dat");
    }

    private void MainForm_DragEnter(object sender, DragEventArgs e)
    {
      e.Effect = DragDropEffects.None;

      if (!e.Data.GetDataPresent(DataFormats.FileDrop))
        return;

      string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
      if (files.Length == 0 || CheckFilename(files[0]))
        return;

      e.Effect = DragDropEffects.Move;
    }

    private void MainForm_DragDrop(object sender, DragEventArgs e)
    {
      if (!e.Data.GetDataPresent(DataFormats.FileDrop))
        return;

      string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
      if (files.Length == 0 || CheckFilename(files[0]))
        return;

      filename = files[0];

      LoadLog();
    }

    private void openLogToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (openFileDialog.ShowDialog(this) != DialogResult.OK)
        return;

      filename = openFileDialog.FileName;
      LoadLog();
    }

    private void exportToTXTToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (saveFileDialog.ShowDialog(this) != DialogResult.OK)
        return;

      StringBuilder sb = new StringBuilder();
      foreach (BaseRecord record in log.Records)
        sb.Append(record.Type).Append(";").Append(record.Description).AppendLine();

      File.WriteAllText(saveFileDialog.FileName, sb.ToString());
    }
  }
}
