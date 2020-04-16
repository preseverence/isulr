using System.Collections.Generic;

namespace LibISULR.Records
{
  public class RegistryValueRecord: RegistryKeyRecord
  {
    private string value;

    public RegistryValueRecord(RecordType type, int flags, byte[] data): base(type, flags, data) { }

    protected override void ParseData(List<string> items)
    {
      base.ParseData(items);
      value = items[1];
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
