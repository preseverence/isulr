using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LibISULR
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

    public static ushort ReadUShort(this byte[] data, ref int index)
    {
      ushort result = BitConverter.ToUInt16(data, index);
      index += 2;
      return result;
    }

    public static int ReadInt(this byte[] data, ref int index)
    {
      int result = BitConverter.ToInt32(data, index);
      index += 4;
      return result;
    }

    public struct StringSpliiter
    {
      private readonly byte[] data;
      private int index;

      public StringSpliiter(byte[] data)
      {
        this.data = data;
        index = 0;
      }

      private int ReadLength(out bool eof)
      {
        byte b = data[index++];

        eof = false;

        switch (b)
        {
          case 0xFD:
            return data.ReadUShort(ref index);

          case 0xFE:
            return data.ReadInt(ref index);

          case 0xFF:
            eof = true;
            return 0;

          default: // 0..0xFC
            return b;
        }
      }

      public string ReadString()
      {
        bool eof;
        int lenght = ReadLength(out eof);
        if (eof)
          return null;

        string result;

        if (lenght < 0)
        {
          lenght = -lenght;
          result = Encoding.Unicode.GetString(data, index, lenght);
        }
        else if (lenght == 0)
          return null;
        else
          result = Encoding.Default.GetString(data, index, lenght);

        index += lenght;
        return result;
      }

      public DateTime ReadDateTime()
      {
        bool eof;
        int length = ReadLength(out eof);
        if (eof)
          return DateTime.MinValue;
        if (length < 0)
          length = -length;

        DateTime result;

        /*
        type TSystemTime = record
          Year: Word;	      // Year part
          Month: Word;	    // Month part
          DayOfWeek: Word;	
          Day: Word;        // Day of month part
          Hour: Word;	      // Hour of the day
          Minute: Word;     // Minute of the hour
          Second: Word;	    // Second of the minute
          MilliSecond: Word;// Milliseconds in the second
        end;
        */

        if (length >= 16)
        {
          int i = index;

          ushort year = data.ReadUShort(ref i);
          ushort month = data.ReadUShort(ref i);
          i += 2; //ushort dow = data.ReadUShort(ref i);
          ushort day = data.ReadUShort(ref i);
          ushort hour = data.ReadUShort(ref i);
          ushort minute = data.ReadUShort(ref i);
          ushort second = data.ReadUShort(ref i);
          ushort ms = data.ReadUShort(ref i);

          result = new DateTime(year, month, day, hour, minute, second, ms, DateTimeKind.Local);
        }
        else
          result = DateTime.MinValue;

        index += length;
        return result;
      }

      public byte[] ReadBytes()
      {
        bool eof;
        int length = ReadLength(out eof);
        if (eof)
          return null;
        if (length < 0)
          length = -length;

        byte[] result = new byte[length];
        Array.Copy(data, index, result, 0, length);
        index += length;

        return result;
      }

      public bool IsEnd
      {
        get { return index >= data.Length; }
      }

      public IEnumerable<string> EnumerateStrings()
      {
        while (!IsEnd)
        {
          string str = ReadString();
          if (str != null)
            yield return str;
        }
      }
    }
  }
}