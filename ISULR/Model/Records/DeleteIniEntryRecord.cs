using System.Collections.Generic;

namespace ISULR.Model.Records
{
  class DeleteIniEntryRecord: BaseRecord
  {
    private IniFlags flags;
    private string filename;
    private string section;
    private string entry;

    public DeleteIniEntryRecord(int flags, byte[] data)
    {
      this.flags = (IniFlags)flags;
      List<string> items = Helpers.SplitString(data, true);
      filename = items[0];
      section = items[1];
      entry = items[2];
    }

    public IniFlags Flags
    {
      get { return flags; }
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
