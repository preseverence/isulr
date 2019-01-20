using System;
using System.Collections.Generic;

namespace ISULR.Model.Records
{
  abstract class AbstractListRecord<TFlags>: BaseRecord
  {
    private List<string> items;
    private TFlags flags;

    protected AbstractListRecord(int flags, byte[] data)
    {
      this.flags = (TFlags)Enum.ToObject(typeof(TFlags), flags);
      items = Helpers.SplitString(data, false);
    }

    public IReadOnlyList<string> Items
    {
      get { return items; }
    }

    public TFlags Flags
    {
      get { return flags; }
    }

    public override string Description
    {
      get { return $"{string.Join(", ", items)}; Flags: {flags}"; }
    }
  }
}
