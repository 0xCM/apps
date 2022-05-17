//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    using static core;

    public ref struct UnicodeLineReader
    {
        readonly StreamReader Source;

        uint Consumed;

        [MethodImpl(Inline)]
        public UnicodeLineReader(StreamReader src)
        {
            Source = src;
            Consumed = 0;
        }

        public void Dispose()
        {
            Source?.Dispose();
        }

        public bool Next(out UnicodeLine dst)
        {
            dst = UnicodeLine.Empty;
            var line = Source.ReadLine();
            if(line == null)
                return false;

            Consumed++;

            var data = span(line);
            if(AsciLines.number(data, out var length, out var number))
                dst = new UnicodeLine(number, text.slice(line, (int)length));
            else
                dst = new UnicodeLine(Consumed, line);

            return true;
        }
    }
}