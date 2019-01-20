using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ISULR.Model
{
  public static class Helpers
  {
    public static string ReadString(this Stream stream, byte[] buffer, int size)
    {
      stream.Read(buffer, 0, size);

      int stringLength = 0;
      // clean out 0s
      while (buffer[stringLength] != 0)
        stringLength++;

      return Encoding.ASCII.GetString(buffer, 0, stringLength);
    }

    public static int ReadInt(this Stream stream, byte[] buffer)
    {
      stream.Read(buffer, 0, 4);
      return BitConverter.ToInt32(buffer, 0);
    }

    public static uint ReadUInt(this Stream stream, byte[] buffer)
    {
      stream.Read(buffer, 0, 4);
      return BitConverter.ToUInt32(buffer, 0);
    }

    public static uint ReadUShort(this Stream stream, byte[] buffer)
    {
      stream.Read(buffer, 0, 2);
      return BitConverter.ToUInt16(buffer, 0);
    }

    public static List<string> SplitString(byte[] data, bool keepOrder)
    {
      List<string> result = new List<string>();     

      int i = 0;

      while (i < data.Length)
      {
        int strLen;

        byte b = data[i];

        switch (b)
        {
          case 0xFD:
            i++;
            strLen = BitConverter.ToInt16(data, i);
            i += 2;
            break;

          case 0xFE:
            i++;
            strLen = BitConverter.ToInt32(data, i);
            i += 4;
            break;

          case 0xFF:
            return result;

          default: // 0..0xFC
            strLen = b;
            i++;
            break;
        }

        if (strLen < 0)
        {
          // unicode
          strLen = -strLen;
          result.Add(Encoding.Unicode.GetString(data, i, strLen));
        }
        else if (strLen == 0)
        {
          if (keepOrder)
            result.Add(null);
        }
        else
          result.Add(Encoding.Default.GetString(data, i, strLen));

        i += strLen;
      }

      return result;
    }
  }
}