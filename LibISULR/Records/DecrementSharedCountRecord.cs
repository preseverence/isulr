using LibISULR.Flags;

namespace LibISULR.Records
{
  public class DecrementSharedCountRecord: BaseRecord<DecrementSharedCountFlags>
  {
    public DecrementSharedCountRecord(int extra, byte[] data)
      : base(extra)
    {
      Path = new Helpers.StringSpliiter(data).ReadString();
    }

    public string Path { get; }

    public override RecordType Type
    {
      get { return RecordType.DecrementSharedCount; }
    }

    public override string Description
    {
      get { return $"Path: {Path}"; }
    }
  }
}
