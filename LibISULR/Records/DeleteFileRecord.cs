using LibISULR.Flags;

namespace LibISULR.Records
{
  public class DeleteFileRecord: BaseRecord<DeleteFileFlags>
  {
    public DeleteFileRecord(int flags, string path)
      : base(flags)
    {
      Path = path;
    }

    public string Path { get; }

    public override string Description
    {
      get { return $"{Path}; {flags}"; }
    }

    public override RecordType Type
    {
      get { return RecordType.DeleteFile; }
    }
  }
}
