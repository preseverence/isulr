using System;

namespace LibISULR.Flags
{
  [Flags]
  public enum DeleteFileFlags
  {
    ExistedBeforeInstall = 1,
    Extra = 2,
    IsFont = 4,
    SharedFile = 8,
    RegisteredServer = 16,
    CallChangeNotify = 32,
    RegisteredTypeLib = 64,
    RestartDelete = 128,
    RemoveReadOnly = 256,
    NoSharedFilePrompt = 512,
    SharedFileIn64BitKey = 1024,
    DisableFsRedir = 2048,  /* also determines whether file was registered as 64-bit */
    GacInstalled = 4096,
  }
}