namespace LibISULR.Records
{
  public class RegistryValueRecord: RegistryKeyRecord
  {
    private string value;

    public RegistryValueRecord(RecordType type, int flags, byte[] data)
      : base(type, flags, data) { }

    protected override void Init(ref Helpers.StringSpliiter splitter)
    {
      base.Init(ref splitter);
      value = splitter.ReadString();
    }

    public override string Description
    {
      get { return $"View: {View}; Hive: {Hive}; Path: {Path}; Value: {value}"; }
    }

    public string Value
    {
      get { return value; }
    }
  }
}
