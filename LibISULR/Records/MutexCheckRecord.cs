namespace LibISULR.Records
{
  public class MutexCheckRecord: BaseRecord
  {
    public MutexCheckRecord(byte[] data)
    {
      MutexName = new Helpers.StringSpliiter(data).ReadString();
    }

    public string MutexName { get; }

    public override RecordType Type
    {
      get { return RecordType.MutexCheck; }
    }

    public override string Description
    {
      get { return $"Mutex Name: {MutexName}"; }
    }
  }
}
