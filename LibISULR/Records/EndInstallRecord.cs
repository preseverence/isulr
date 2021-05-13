using System;

namespace LibISULR.Records
{
  class EndInstallRecord: BaseRecord
  {
    public EndInstallRecord(byte[] data)
    {
      Time = new Helpers.StringSpliiter(data).ReadDateTime();
    }

    public DateTime Time { get; }

    public override RecordType Type
    {
      get { return RecordType.EndInstall; }
    }

    public override string Description
    {
      get { return $"At: {Time}"; }
    }
  }
}
