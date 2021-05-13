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
      Helpers.StringSpliiter splitter = new Helpers.StringSpliiter(data);
      Init(ref splitter);
    }

    protected virtual void Init(ref Helpers.StringSpliiter splitter)
    {
      filename = splitter.ReadString();
      section = splitter.ReadString();
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
