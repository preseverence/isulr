namespace ISULR.Model.Records
{
  class DeleteDirOrFilesRecord: AbstractListRecord<DeleteDirOrFilesFlags>
  {
    public DeleteDirOrFilesRecord(int flags, byte[] data): base(flags, data) { }

    public override RecordType Type
    {
      get { return RecordType.DeleteDirOrFiles; }
    }
  }
}
