using System;

namespace LibISULR.Flags
{
  [Flags]
  public enum UninstallLogFlags
  {
    AdminInstalled = 1 << 0,
    DontCheckRecCRCs = 1 << 1,
    ModernStyle = 1 << 2,
    AlwaysRestart = 1 << 3,
    ChangesEnvironment = 1 << 4,
    Win64 = 1 << 5,
    PowerUserInstalled = 1 << 6,
  }
}
