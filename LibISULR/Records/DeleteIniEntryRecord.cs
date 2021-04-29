using System.Collections.Generic;

using LibISULR.Flags;

namespace LibISULR.Records
{
  public class DeleteIniEntryRecord: BaseRecord<IniFlags>
  {
    private string filename;
    private string section;
    private string entry;

    public DeleteIniEntryRecord(int flags, byte[] data)
      : base(flags)
    {
      List<string> items = Helpers.SplitString(data, true);
      filename = items[0];
      section = items[1];
      entry = items[2];
    }

    public string Filename
    {
      get { return filename; }
    }

    public string Section
    {
      get { return section; }
    }

    public string Entry
    {
      get { return entry; }
    }

    public override RecordType Type
    {
      get { return RecordType.IniDeleteEntry; }
    }

    public override string Description
    {
      get { return $"File: \"{filename}\"; Section: \"{section}\"; Entry: {entry}; Flags: {flags}"; }
    }
  }
}
