using System;

using Microsoft.Win32;

namespace LibISULR
{
  public class InstalledApp
  {
    internal InstalledApp(RegistryKey key, string path, bool isMachineWide, bool isX64)
    {
      UninstallLogPath = path;
      IsMachineWide = isMachineWide;
      IsX64 = isX64;

      // display name
      DisplayName = (key.GetValue("DisplayName") as string) ?? key.Name;

      // version
      string s = key.GetValue("DisplayVersion") as string;
      if (s != null && Version.TryParse(s, out Version version))
        Version = version;

      // raw fields
      InstallerVersion = key.GetValue("Inno Setup: Setup Version") as string;
      Publisher = key.GetValue("Publisher") as string;
      InstallUser = key.GetValue("Inno Setup: User") as string;
      InstallLanguage = key.GetValue("Inno Setup: Language") as string;

      // install date
      s = key.GetValue("InstallDate") as string;
      if (s != null && int.TryParse(s, out int date))
        InstallDate = new DateTime(date / 10000, (date % 10000) / 100, date % 100);

      // selected tasks
      s = key.GetValue("Inno Setup: Selected Tasks") as string;
      if (!string.IsNullOrWhiteSpace(s))
        SelectedTasks = s.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
      else
        SelectedTasks = new string[0];

      // deselected tasks
      s = key.GetValue("Inno Setup: Deselected Tasks") as string;
      if (!string.IsNullOrWhiteSpace(s))
        DeselectedTasks = s.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
      else
        DeselectedTasks = new string[0];
    }

    /// <summary>
    /// Gets the path to the uninstall log file. File is garanteed to exist.
    /// </summary>
    public string UninstallLogPath { get; }

    /// <summary>
    /// Gets the application display name.
    /// </summary>
    public string DisplayName { get; }

    /// <summary>
    /// Gets the application version.
    /// </summary>
    public Version Version { get; }

    /// <summary>
    /// Gets the installer version.
    /// </summary>
    public string InstallerVersion { get; }

    /// <summary>
    /// Gets the application publisher.
    /// </summary>
    public string Publisher { get; }

    /// <summary>
    /// Gets the user who installed the application.
    /// </summary>
    public string InstallUser { get; }

    /// <summary>
    /// Gets the installer language.
    /// </summary>
    public string InstallLanguage { get; }

    /// <summary>
    /// Gets the array of inno-specific tasks selected during the installation.
    /// </summary>
    public string[] SelectedTasks { get; }

    /// <summary>
    /// Gets the array of inno-specific tasks not selected during the installation.
    /// </summary>
    public string[] DeselectedTasks { get; }

    /// <summary>
    /// Gets the installation date.
    /// </summary>
    public DateTime InstallDate { get; }

    /// <summary>
    /// Gets the value indicating whether the installation was machine-wide or specific to current user.
    /// </summary>
    public bool IsMachineWide { get; }

    /// <summary>
    /// Gets the value indication whether the application is installed as x64 (or x86).
    /// </summary>
    public bool IsX64 { get; }
  }
}
