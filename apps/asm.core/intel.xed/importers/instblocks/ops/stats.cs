//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static Numbers;

    partial class XedImport
    {
        public static ReadOnlySpan<LineStats> stats(MemoryFile src)
        {
            var dst = list<LineStats>(400000);
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

        public static unsafe void stats(MemoryAddress src, uint size, ref TextDocStats dst)
        {
            var data = core.cover(src.Pointer<byte>(), size);
            add(ref dst.Size, data.Length);
            for(var i=0; i<size; i++)
            {
                if(SQ.nl(skip(data,i)))
                    inc(ref dst.LineCount);
            }
        }
    }
}