namespace LibISULR.Records
{
  public class AbstractRecord: BaseRecord
  {
    private RecordType type;
    private uint extraData;
    private byte[] data;

    public AbstractRecord(RecordType type, int extraData, byte[] data)
    {
      this.type = type;
      this.extraData = (uint)extraData;
      this.data = data;
    }

    public override RecordType Type
    {
      get { return type; }
    }

    public uint ExtraData
    {
      get { return extraData; }
    }

    public byte[] Data
    {
      get { return data; }
    }

    public override string Description
    {
      get { return $"Extra flags: {extraData}"; }
    }
  }
}
