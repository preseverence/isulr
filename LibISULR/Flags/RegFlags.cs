using System;

namespace LibISULR.Flags
{
  [Flags]
  enum RegFlags : uint
  {
    Reg_KeyHandleMask = 0x80FFFFFF,
    Reg_64BitKey = 0x01000000,
  }
}