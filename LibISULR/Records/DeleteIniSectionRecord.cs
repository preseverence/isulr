using System.Collections.Generic;

using LibISULR.Flags;

namespace LibISULR.Records
{
  public class DeleteIniSectionRecord: BaseRecord<IniFlags>
  {
    private string filename;
    private string section;

    public DeleteIniSectionRecord(int flags, byte[] data)
      : base(flags)
    {
      Init(Helpers.SplitString(data, true));
    }

    protected virtual void Init(List<string> items)
    {
      filename = items[0];
      section = items[1];
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
