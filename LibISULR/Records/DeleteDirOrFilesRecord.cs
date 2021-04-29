using LibISULR.Flags;

namespace LibISULR.Records
{
  class DeleteDirOrFilesRecord: BaseRecord<DeleteDirOrFilesFlags>
  {
    public DeleteDirOrFilesRecord(int flags, string path)
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
      get { return RecordType.DeleteDirOrFiles; }
    }
  }
}
