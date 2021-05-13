using System;

namespace LibISULR.Records
{
  public class StartInstallRecord: BaseRecord
  {
    public StartInstallRecord(byte[] data)
    {
      Helpers.StringSpliiter splitter = new Helpers.StringSpliiter(data);
      ComputerName = splitter.ReadString();
      UserName = splitter.ReadString();
      ApplicationDir = splitter.ReadString();
      Time = splitter.ReadDateTime();
    }

    public string ComputerName { get; }

    public string UserName { get; }

    public string ApplicationDir { get; }

    public DateTime Time { get; }

    public override RecordType Type
    {
      get { return RecordType.StartInstall; }
    }

    public override string Description
    {
      get { return $"Computer: {ComputerName}; User: {UserName}; Dir: {ApplicationDir}; At: {Time}"; }
    }
  }
}
