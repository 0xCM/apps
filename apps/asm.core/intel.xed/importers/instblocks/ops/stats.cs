//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedImport
    {
        public static unsafe TextDocStats stats(MemoryFile src, uint blocks, uint blocksize, uint remainder)
        {
            var counter = 0u;
            var seg = src.Segment();
            var offset = src.BaseAddress;
            var dst = new TextDocStats();
            for(var i=0u; i<blocks; i++)
            {
                stats(offset, blocksize, ref dst);
                offset = offset + blocksize;
            }
            stats(offset, remainder, ref dst);
            return dst;
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