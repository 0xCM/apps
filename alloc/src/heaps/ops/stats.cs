//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class Heaps
    {
        public static SymHeapStats stats(ReadOnlySpan<SymLiteralRow> src)
        {
            var dst = new SymHeapStats();
            dst.SymbolCount = (uint)src.Length;
            dst.EntryCount = (uint)bits.next((Pow2x32)bits.xmsb(dst.SymbolCount));
            dst.CharCount = Heaps.charcount(src);
            dst.DataSize = dst.CharCount*2;
            return dst;
        }
   }
}