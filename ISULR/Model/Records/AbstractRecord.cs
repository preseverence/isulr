namespace ISULR.Model.Records
{
  class AbstractRecord: BaseRecord
  {
    private RecordType type;
    private int extraData;
    private byte[] data;

    public AbstractRecord(RecordType type, int extraData, byte[] data)
    {
      this.type = type;
      this.extraData = extraData;
      this.data = data;
    }

    public override RecordType Type
    {
      get { return type; }
    }

    public int ExtraData
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
