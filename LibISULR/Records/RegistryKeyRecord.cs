using LibISULR.Flags;

using Microsoft.Win32;

namespace LibISULR.Records
{
  public class RegistryKeyRecord: BaseRecord
  {
    private RecordType type;
    private string path;
    private RegistryHive hive;
    private RegistryView view;

    public RegistryKeyRecord(RecordType type, int flags, byte[] data)
    {
      this.type = type;

      Helpers.StringSpliiter spliiter = new Helpers.StringSpliiter(data);
      Init(ref spliiter);

      RegFlags f = (RegFlags)flags;
      view = (f & RegFlags.Reg_64BitKey) != 0 ? RegistryView.Registry64 : RegistryView.Registry32;
      hive = (RegistryHive)(f & RegFlags.Reg_KeyHandleMask);
    }

    protected virtual void Init(ref Helpers.StringSpliiter splitter)
    {
      path = splitter.ReadString();
    }

    public string Path
    {
      get { return path; }
    }

    public RegistryHive Hive
    {
      get { return hive; }
    }

    public RegistryView View
    {
      get { return view; }
    }

    public override RecordType Type
    {
      get { return type; }
    }

    public override string Description
    {
      get { return $"View: {view}; Hive: {hive}; Path: {path}"; }
    }
  }
}
