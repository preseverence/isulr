using System.Collections.Generic;

namespace ISULR.Model.Records
{
  class DeleteIniSectionRecord: BaseRecord
  {
    private IniFlags flags;
    private string filename;
    private string section;

    public DeleteIniSectionRecord(int flags, byte[] data)
    {
      this.flags = (IniFlags)flags;

      List<string> items = Helpers.SplitString(data, true);
      filename = items[0];
      section = items[1];
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

    public override RecordType Type
    {
      get { return RecordType.IniDeleteSection; }
    }

    public override string Description
    {
      get { return $"File: \"{filename}\"; Section: \"{section}\"; Flags: {flags}"; }
    }
  }
}
