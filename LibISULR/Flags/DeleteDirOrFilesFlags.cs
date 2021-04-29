using System;

namespace LibISULR.Flags
{
  [Flags]
  public enum DeleteDirOrFilesFlags
  {
    Extra = 1,
    IsDir = 2,
    DeleteFiles = 4,
    DeleteSubdirsAlso = 8,
    CallChangeNotify = 16,
    DisableFsRedir = 32,
  }
}