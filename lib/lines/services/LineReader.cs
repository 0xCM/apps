//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.IO;

    using static Root;
    using static core;

    public struct LineReader : IDisposable
    {
        readonly StreamReader Source;

        uint Consumed;

        [MethodImpl(Inline)]
        public LineReader(StreamReader src)
        {
            Source = src;
            Consumed = 0;
        }

        public void Dispose()
        {
            Source?.Dispose();
        }

        public bool Next(out TextLine dst)
        {
            dst = TextLine.Empty;
            var line = Source.ReadLine();
            if(line == null)
                return false;

            Consumed++;

            var data = span(line);
            if(Lines.number(data, out var length, out var number))
                dst = new TextLine(number, line.Substring((int)length));
            else
                dst = new TextLine(Consumed, line);

            return true;
        }

        public bool Skip(uint count, out TextLine dst)
        {
            bool result = true;
            dst = default;
            for(var i=0; i<count; i++)
            {
                if(!Next(out dst))
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        public ReadOnlySpan<TextLine> ReadAll()
        {
            var dst = list<TextLine>();
            while(Next(out var line))
                dst.Add(line);
            return dst.ViewDeposited();
        }
    }
}