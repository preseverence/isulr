namespace ISULR.Model
{
  enum RecordType: ushort
  {
    UserDefined = 0x01,
    StartInstall = 0x10,
    EndInstall = 0x11,
    CompiledCode = 0x20,
    Run = 0x80,
    DeleteDirOrFiles = 0x81,
    DeleteFile = 0x82,
    DeleteGroupOrItem = 0x83,
    IniDeleteEntry = 0x84,
    IniDeleteSection = 0x85,
    RegDeleteEntireKey = 0x86,
    RegClearValue = 0x87,
    RegDeleteKeyIfEmpty = 0x88,
    RegDeleteValue = 0x89,
    DecrementSharedCount = 0x8A,
    RefreshFileAssoc = 0x8B,
    MutexCheck = 0x8C,
  }
}
