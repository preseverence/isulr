using LibISULR.Flags;

namespace LibISULR.Records
{
  public class RunRecord: BaseRecord<RunFlags>
  {
    private string filename;
    private string args;
    private string workingDir;

    public RunRecord(int flags, byte[] data)
      : base(flags)
    {
      Helpers.StringSpliiter spliiter = new Helpers.StringSpliiter(data);
      filename = spliiter.ReadString();
      args = spliiter.ReadString();
      workingDir = spliiter.ReadString();
    }

    public override RecordType Type
    {
      get { return RecordType.Run; }
    }

    public override string Description
    {
      get { return $"File: \"{filename}\" Args: \"{args}\"; At \"{workingDir}\"; Flags: {flags}"; }
    }

    public string Filename
    {
      get { return filename; }
    }

    public string Args
    {
      get { return args; }
    }

    public string WorkingDir
    {
      get { return workingDir; }
    }
  }
}
