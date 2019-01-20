namespace ISULR.Model.Records
{
  static class RecordFactory
  {
    public static BaseRecord CreateRecord(RecordType type, int extra, byte[] data)
    {
      switch (type)
      {
        case RecordType.Run:
          return new RunRecord(extra, data);

        case RecordType.DeleteFile:
          return new DeleteFileRecord(extra, data);

        case RecordType.DeleteDirOrFiles:
          return new DeleteDirOrFilesRecord(extra, data);

        case RecordType.IniDeleteEntry:
          return new DeleteIniEntryRecord(extra, data);

        case RecordType.IniDeleteSection:
          return new DeleteIniSectionRecord(extra, data);

        case RecordType.RegDeleteEntireKey:
        case RecordType.RegDeleteKeyIfEmpty:
          return new RegistryKeyRecord(type, extra, data);

        case RecordType.RegClearValue:
        case RecordType.RegDeleteValue:
          return new RegistryValueRecord(type, extra, data);

        default:
          return new AbstractRecord(type, extra, data);
      }
    }
  }
}
