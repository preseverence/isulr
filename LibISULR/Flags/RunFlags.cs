using System;

namespace LibISULR.Flags
{
  [Flags]
  public enum RunFlags
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
}