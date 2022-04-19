//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct Bitfields
    {
        /// <summary>
        /// Computes the aggregate width of the segments that comprise the bitfield
        /// </summary>
        /// <param name="src">The bitfield spec</param>
        [MethodImpl(Inline), Op]
        public static uint totalwidth(in BitfieldModel src)
            => totalwidth(src.Segments);

        [MethodImpl(Inline), Op]
        public static uint totalwidth(ReadOnlySpan<BitfieldSegModel> src)
        {
            var count = src.Length;
            var w = 0u;
            for(var i=0; i<count; i++)
                w += skip(src,i).SegWidth;
            return w;
        }

        [MethodImpl(Inline), Op]
        public static uint totalwidth<K>(ReadOnlySpan<BitfieldSegModel<K>> src)
            where K : unmanaged
        {
            var count = src.Length;
            var w = 0u;
            for(var i=0; i<count; i++)
                w += skip(src,i).SegWidth;
            return w;
        }

        /// <summary>
        /// Computes the aggregate width of the segments that comprise the bitfield
        /// </summary>
        /// <param name="src">The bitfield spec</param>
        [MethodImpl(Inline), Op]
        public static uint totalwidth<T>(in BitfieldModel<T> src)
            where T : unmanaged
        {
            var total = 0u;
            var count = src.SegCount;
            var segments = src.Segments;
            for(byte i=0; i<count; i++)
                total += skip(segments, i).SegWidth;
            return total;
        }
    }
}