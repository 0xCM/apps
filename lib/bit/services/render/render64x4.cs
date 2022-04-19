//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct BitRender
    {
        /// <summary>
        /// Renders 64 1-bit values interspersed with 14 separators consuming 88 characters in the target buffer
        /// </summary>
        /// <param name="sep"></param>
        /// <param name="src"></param>
        /// <param name="i"></param>
        /// <param name="dst"></param>
        [MethodImpl(Inline), Op]
        public static uint render64x4(char sep, ulong src, ref uint i, Span<char> dst)
        {
            var i0=i;
            render32x4(sep, (uint)(src >> 32), ref i, dst);
            i += separate(i, sep, dst);
            render32x4(sep, (uint)src, ref i, dst);
            return i - i0;
         }
    }
}