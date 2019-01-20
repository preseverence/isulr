
using System;

namespace ISULR.Model
{
  [Flags]
  enum RunFlags
  {
    NoWait = 1,
    WaitUntilIdle = 2,
    ShellExec = 4,
    RunMinimized = 8,
    RunMaximized = 16,
    SkipIfDoesntExist = 32,
    RunHidden = 64,
    ShellExecRespectWaitFlags = 128,
    DisableFsRedir = 256,
  }

  [Flags]
  enum DeleteFileFlags
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

  [Flags]
  enum DeleteDirOrFilesFlags
  {
    Extra = 1,
    IsDir = 2,
    DeleteFiles = 4,
    DeleteSubdirsAlso = 8,
    CallChangeNotify = 16,
    DisableFsRedir = 32,
  }

  [Flags]
  enum IniFlags
  {
    OnlyIfEmpty = 1,
  }

  [Flags]
  enum RegFlags : uint
  {
    Reg_KeyHandleMask = 0x80FFFFFF,
    Reg_64BitKey = 0x01000000,
  }

  [Flags]
  enum UninstallLogFlags
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
