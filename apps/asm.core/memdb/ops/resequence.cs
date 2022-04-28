//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class MemDb
    {
        public static ClrRecordFields resequence(ClrRecordFields src)
        {
            var count = src.Count;
            var dst = src;
            for(var i=z16; i<count; i++)
            {
                ref readonly var field = ref src[i];
                dst[i] = new ClrTableField(i, field.Definition);
            }
            return dst;
        }

        public static Index<ColDef> resequence(Index<ColDef> left, Index<ColDef> right)
        {
            var count = left.Count + right.Count;
            var dst = alloc<ColDef>(count);
            var k=z8;
            for(var i=0; i<left.Count; i++, k++)
                seek(dst,k) = (left[i].Reposition(k));

            for(var i=0; i<right.Count; i++, k++)
                seek(dst,k) = (right[i].Reposition(k));

            return dst;
        }
    }
}