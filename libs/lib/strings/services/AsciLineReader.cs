//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XTend
    {
        [Op]
        public static AsciLineReader AsciLineReader(this FS.FilePath src)
            => new AsciLineReader(src.AsciReader());
    }

    public ref struct AsciLineReader
    {
        readonly StreamReader Source;

        uint LineCount;

        uint Offset;

        Span<byte> _Buffer;

        public AsciLineReader(StreamReader src)
        {
            Source = src;
            LineCount = 0;
            Offset = 0;
            _Buffer = alloc<byte>(1024);
        }

        [MethodImpl(Inline)]
        Span<byte> Buffer()
        {
            _Buffer.Clear();
            return _Buffer;
        }


        public void Dispose()
        {
            Source?.Dispose();
        }

        public bool Next(out AsciLine dst)
        {
            dst = AsciLine.Empty;
            var _line = Source.ReadLine();
            if(_line == null)
                return false;
            var buffer = Buffer();
            var count = AsciSymbols.encode(_line, buffer);
            var data = slice(buffer,0,count);

            LineCount++;

            if(AsciLines.number(data, out var length, out var n))
                dst = new AsciLine(slice(data, (int)length));
            else
                dst = new AsciLine(data);

            Offset+=length;

            return true;
        }
    }
}