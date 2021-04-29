using System;
using System.Collections.Generic;
using System.IO;

using LibISULR.Flags;
using LibISULR.Records;

namespace LibISULR
{
  public class UninstallLog
  {
    private const string IDx64 = "Inno Setup Uninstall Log (b) 64-bit";
    private const string IDx86 = "Inno Setup Uninstall Log (b)";

    private string appId;
    private string appName;

    private int version;
    private UninstallLogFlags flags;

    private bool isX64;
    private List<BaseRecord> records = new List<BaseRecord>();

    public UninstallLog(Stream stream)
    {
      byte[] buffer = new byte[128];

      // TUninstallLogID = array[0..63] of AnsiChar;
      string id = stream.ReadString(buffer, 64);
      if (id == IDx64)
        isX64 = true;
      else if (id == IDx86)
        isX64 = false;
      else
        throw new Exception("Header ID corrupted");

      // array[0..127] of AnsiChar;
      appId = stream.ReadString(buffer, 128);
      // array[0..127] of AnsiChar;
      appName = stream.ReadString(buffer, 128);

      version = stream.ReadInt(buffer);
      int numRecords = stream.ReadInt(buffer);

      // endOffset - ignored
      stream.Read(buffer, 0, 4);

      flags = (UninstallLogFlags)stream.ReadInt(buffer);

      // array[0..26] of Longint;  { reserved for future use }
      stream.Seek(27 * 4, SeekOrigin.Current);

      // skip header CRC, as we whiil not check it anyway
      stream.Read(buffer, 0, 4);

      using (CrcStream crcStream = new CrcStream(stream))
      {
        for (int i = 0; i < numRecords; i++)
        {
          /*
          TUninstallFileRec = packed record (packed, so no alignment)
            Typ: TUninstallRecTyp; (ushort)
            ExtraData: Longint; (int)
            DataSize: Cardinal; (uint)
          end;
          */

          // ReadBuf(FileRec, SizeOf(FileRec));
          RecordType type = (RecordType)crcStream.ReadUShort(buffer);
          int extraData = crcStream.ReadInt(buffer);
          uint dataSize = crcStream.ReadUInt(buffer);

          System.Diagnostics.Debug.WriteLine($"Read type: {type}; Extra: {extraData}; Data Size: {dataSize}");

          // ReadBuf(NewRec.Data, NewRec.DataSize);
          byte[] data = new byte[dataSize];
          crcStream.Read(data, 0, (int)dataSize);

          records.AddRange(RecordFactory.CreateRecord(type, extraData, data));
        }
      }
    }

    /// <summary>
    /// Gets the application ID.
    /// </summary>
    public string AppId
    {
      get { return appId; }
    }

    /// <summary>
    /// Gets the application name.
    /// </summary>
    public string AppName
    {
      get { return appName; }
    }

    /// <summary>
    /// Gets the application version.
    /// </summary>
    public int Version
    {
      get { return version; }
    }

    public UninstallLogFlags Flags
    {
      get { return flags; }
    }

    public bool IsX64
    {
      get { return isX64; }
    }

    public IReadOnlyList<BaseRecord> Records
    {
      get { return records; }
    }
  }  
}
