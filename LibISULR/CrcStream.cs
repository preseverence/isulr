using System;
using System.IO;

namespace LibISULR
{
  class CrcStream: Stream
  {
    private readonly byte[] data = new byte[4096];
    private int dataPos;
    private int dataAvailable;
    private readonly Stream innerStream;

    public CrcStream(Stream innerStream)
    {
      this.innerStream = innerStream;

      FillBuffer();
    }

    #region Empty Stream Overrides

    public override void Flush() { }

    public override long Seek(long offset, SeekOrigin origin)
    {
      return 0;
    }

    public override void SetLength(long value) { }

    public override void Write(byte[] buffer, int offset, int count) { }

    public override bool CanRead
    {
      get { return true; }
    }

    public override bool CanSeek
    {
      get { return false; }
    }

    public override bool CanWrite
    {
      get { return false; }
    }

    public override long Length
    {
      get { return innerStream.Length; }
    }

    public override long Position
    {
      get { return innerStream.Position - dataAvailable; }
      set { }
    }

    #endregion

    private void FillBuffer()
    {
      /*
      TUninstallCrcHeader = packed record
        Size, NotSize: Cardinal; (uint)
        CRC: Longint; (int)
      end;
      */

      uint size = innerStream.ReadUInt(data);
      uint notSize = innerStream.ReadUInt(data);
      System.Diagnostics.Debug.WriteLine($"CRC block size: {size}");

      // skip CRC, we will not check it anyway
      innerStream.Read(data, 0, 4);

      if (size != ~notSize)
        throw new Exception("File record header is corrupt (size != notSize)");

      dataAvailable = (int)size;
      dataPos = 0;
      dataAvailable = innerStream.Read(data, 0, dataAvailable);
    }

    public override int Read(byte[] buffer, int offset, int count)
    {
      int result = 0;

      while (count > 0)
      {
        if (dataAvailable == 0)
          FillBuffer();

        int dataToRead = count;
        if (dataToRead > dataAvailable)
          dataToRead = dataAvailable;

        Array.Copy(data, dataPos, buffer, offset, dataToRead);
        offset += dataToRead;
        count -= dataToRead;
        dataPos += dataToRead;
        dataAvailable -= dataToRead;
      }

      return result;
    }
  }
}
