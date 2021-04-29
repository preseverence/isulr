using System;

namespace LibISULR.Records
{
  public abstract class BaseRecord
  {
    public abstract RecordType Type { get; }

    public abstract string Description { get; }

    public override string ToString()
    {
      return $"Type: {Type}. Desc: {Description}";
    }
  }

  public abstract class BaseRecord<TFlags> : BaseRecord
  {
    protected readonly TFlags flags;

    protected BaseRecord(TFlags flags)
    {
      this.flags = flags;
    }

    protected BaseRecord(int flags)
    {
      this.flags = (TFlags)Enum.ToObject(typeof(TFlags), flags);
    }

    public TFlags Flags
    {
      get { return flags; }
    }
  }
}
