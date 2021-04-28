using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

using Microsoft.Win32;

namespace LibISULR
{
  public static class UninstallScanner
  {
    private static readonly Regex uninstallPathRegex = new Regex("^\"?(.+)(unins[\\d]{3})\\.exe\"?$", RegexOptions.Singleline | RegexOptions.Compiled);

    public static IEnumerable<InstalledApp> Scan()
    {
      foreach (InstalledApp app in Scan(RegistryHive.LocalMachine, RegistryView.Registry64, true, true))
        yield return app;

      foreach (InstalledApp app in Scan(RegistryHive.CurrentUser, RegistryView.Registry64, false, true))
        yield return app;

      foreach (InstalledApp app in Scan(RegistryHive.LocalMachine, RegistryView.Registry32, true, false))
        yield return app;

      foreach (InstalledApp app in Scan(RegistryHive.CurrentUser, RegistryView.Registry32, false, false))
        yield return app;
    }

    private static IEnumerable<InstalledApp> Scan(RegistryHive hive, RegistryView view, bool isMachineWide, bool isX64)
    {
      using (RegistryKey hiveKey = RegistryKey.OpenBaseKey(hive, view))
      {
        using (RegistryKey appsKey = hiveKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall", false))
        {
          foreach (string s in appsKey.GetSubKeyNames())
          {
            using (RegistryKey appKey = appsKey.OpenSubKey(s, false))
            {
              string uninstallString = appKey.GetValue("UninstallString") as string;
              if (uninstallString == null)
                continue;

              Match match = uninstallPathRegex.Match(uninstallString);
              if (!match.Success)
                continue;

              string uninstallLogPath = Path.Combine(match.Groups[1].Value, match.Groups[2].Value + ".dat");

              if (!File.Exists(uninstallLogPath))
                continue;

              InstalledApp app;
              try
              {
                app = new InstalledApp(appKey, uninstallLogPath, isMachineWide, isX64);
              }
              catch
              {
                continue;
              }

              yield return app;
            }
          }
        }
      }
    }
  }
}
