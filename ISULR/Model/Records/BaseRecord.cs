namespace ISULR.Model.Records
{
  abstract class BaseRecord
  {
    public abstract RecordType Type { get; }

    public abstract string Description { get; }

    public override string ToString()
    {
      return $"Type: {Type}. Desc: {Description}";
    }
  }
}
