//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class AsciLines
    {
        public static ReadOnlySpan<LineStats> stats(ReadOnlySpan<byte> data, uint buffer = 0)
        {
            var dst = span<LineStats>(buffer);
            var last = 0u;
            var counter = 0u;
            var j=0u;
            for(var i=0u; i<data.Length && i < buffer; i++)
            {
                if(SQ.nl(skip(data,i)))
                {
                    var offset = i;
                    var length = (byte)(offset - last);
                    seek(dst,j++) = new LineStats(counter++, offset, length);
                    last = offset;
                }
            }

            return slice(dst,0,j);
        }
    }
}