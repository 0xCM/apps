//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class AsciLines
    {
        public static ReadOnlySpan<LineStats> stats(MemoryFile src, uint buffer = 0)
        {
            var dst = list<LineStats>(buffer);
            var data = src.View();
            var last = 0u;
            var counter = 0u;
            for(var i=0u; i<data.Length; i++)
            {
                if(SQ.nl(skip(data,i)))
                {
                    var offset = i;
                    var length = (byte)(offset - last);
                    dst.Add(new LineStats(counter++, offset, length));
                    last = offset;
                }
            }

            return dst.ViewDeposited();
        }

        public static ReadOnlySpan<LineStats> stats(ReadOnlySpan<byte> data, uint buffer = 0)
        {
            var dst = list<LineStats>(buffer);
            var last = 0u;
            var counter = 0u;
            for(var i=0u; i<data.Length; i++)
            {
                if(SQ.nl(skip(data,i)))
                {
                    var offset = i;
                    var length = (byte)(offset - last);
                    dst.Add(new LineStats(counter++, offset, length));
                    last = offset;
                }
            }

            return dst.ViewDeposited();
        }
    }
}