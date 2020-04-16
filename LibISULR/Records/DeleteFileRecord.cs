namespace LibISULR.Records
{
  public class DeleteFileRecord: AbstractListRecord<DeleteFileFlags>
  {
    public DeleteFileRecord(int flags, byte[] data): base(flags, data) { }

    public override RecordType Type
    {
      get { return RecordType.DeleteFile; }
    }
  }
}
