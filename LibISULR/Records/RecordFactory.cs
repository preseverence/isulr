using System.Collections.Generic;

namespace LibISULR.Records
{
  static class RecordFactory
  {
    public static IEnumerable<BaseRecord> CreateRecord(RecordType type, int extra, byte[] data)
    {
      switch (type)
      {
        case RecordType.Run:
          yield return new RunRecord(extra, data);
          yield break;

        case RecordType.DeleteFile:
          foreach (string s in new Helpers.StringSpliiter(data).EnumerateStrings())
            yield return new DeleteFileRecord(extra, s);
          yield break;

        case RecordType.DeleteDirOrFiles:
          foreach (string s in new Helpers.StringSpliiter(data).EnumerateStrings())
            yield return new DeleteDirOrFilesRecord(extra, s);
          yield break;

        case RecordType.IniDeleteEntry:
          yield return new DeleteIniEntryRecord(extra, data);
          yield break;

        case RecordType.IniDeleteSection:
          yield return new DeleteIniSectionRecord(extra, data);
          yield break;

        case RecordType.RegDeleteEntireKey:
        case RecordType.RegDeleteKeyIfEmpty:
          yield return new RegistryKeyRecord(type, extra, data);
          yield break;

        case RecordType.RegClearValue:
        case RecordType.RegDeleteValue:
          yield return new RegistryValueRecord(type, extra, data);
          yield break;

        case RecordType.StartInstall:
          yield return new StartInstallRecord(data);
          yield break;

        case RecordType.EndInstall:
          yield return new EndInstallRecord(data);
          yield break;

        case RecordType.MutexCheck:
          yield return new MutexCheckRecord(data);
          yield break;

        case RecordType.DecrementSharedCount:
          yield return new DecrementSharedCountRecord(extra, data);
          yield break;

        case RecordType.CompiledCode:
          yield return new CompiledCodeRecord(data);
          yield break;

        default:
          yield return new AbstractRecord(type, extra, data);
          yield break;
      }
    }
  }
}
