namespace LibISULR.Records
{
  public class CompiledCodeRecord: BaseRecord
  {
    public CompiledCodeRecord(byte[] data)
    {
      Helpers.StringSpliiter splitter = new Helpers.StringSpliiter(data);
      Code = splitter.ReadBytes();
      LeadBytes = splitter.ReadBytes();
      ExpandedApp = splitter.ReadString();
      ExpandedGroup = splitter.ReadString();
      WizardGroup = splitter.ReadString();
      Language = splitter.ReadString();
    }

    public byte[] Code { get; }

    public byte[] LeadBytes { get; }

    public string ExpandedApp { get; }

    public string ExpandedGroup { get; }

    public string WizardGroup { get; }

    public string Language { get; }

    public override RecordType Type
    {
      get { return RecordType.CompiledCode; }
    }

    public override string Description
    {
      get { return $"Code: {Code?.Length}; App: {ExpandedApp}; Group: {ExpandedGroup}; Wizard group: {WizardGroup}; Language: {Language}"; }
    }
  }
}
