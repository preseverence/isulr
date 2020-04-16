using System.Collections.Generic;

namespace LibISULR.Records
{
  public class RunRecord: BaseRecord
  {
    private RunFlags flags;
    private string filename;
    private string args;
    private string workingDir;

    public RunRecord(int flags, byte[] data)
    {      
      this.flags = (RunFlags)flags;

      List<string> items = Helpers.SplitString(data, true);
      filename = items[0];
      args = items[1];
      workingDir = items[2];
    }

    public override RecordType Type
    {
      get { return RecordType.Run; }
    }

    public override string Description
    {
      get { return $"File: \"{filename}\" Args: \"{args}\"; At \"{workingDir}\"; Flags: {flags}"; }
    }

    public RunFlags Flags
    {
      get { return flags; }
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
