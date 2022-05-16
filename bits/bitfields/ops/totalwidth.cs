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
        public static uint totalwidth(in BfModel src)
            => totalwidth(src.Segments);

        [MethodImpl(Inline), Op]
        public static uint totalwidth(ReadOnlySpan<BfSegModel> src)
        {
            var count = src.Length;
            var w = 0u;
            for(var i=0; i<count; i++)
                w += skip(src,i).Width;
            return w;
        }

        [MethodImpl(Inline), Op]
        public static uint totalwidth<K>(ReadOnlySpan<BfSegModel<K>> src)
            where K : unmanaged
        {
            var count = src.Length;
            var w = 0u;
            for(var i=0; i<count; i++)
                w += skip(src,i).Width;
            return w;
        }

        /// <summary>
        /// Computes the aggregate width of the segments that comprise the bitfield
        /// </summary>
        /// <param name="src">The bitfield spec</param>
        [MethodImpl(Inline), Op]
        public static uint totalwidth<T>(in BfModel<T> src)
            where T : unmanaged
        {
            var total = 0u;
            var count = src.SegCount;
            var segments = src.Segments;
            for(byte i=0; i<count; i++)
                total += skip(segments, i).Width;
            return total;
        }
    }
}