//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct Bitfields
    {
        [MethodImpl(Inline)]
        public static BitfieldInterval interval(uint offset, byte width)
            => new BitfieldInterval(offset,width);

        /// <summary>
        /// Computes a <see cref='BitfieldInterval'/> sequence given a paired offset/width seqence
        /// </summary>
        /// <param name="widths">The 0-based offset of each segment in the field</param>
        public static Index<BitfieldInterval> intervals(ReadOnlySpan<uint> offsets, ReadOnlySpan<byte> widths)
        {
            var count = Require.equal(offsets.Length,widths.Length);
            var dst = alloc<BitfieldInterval>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = interval(skip(offsets,i), skip(widths,i));
            return dst;
        }
    }
}