//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct gcpu
    {
        /// <summary>
        /// Rotates the full 128 bits of a vector leftward at bit-level resolution
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The number of bits to shift</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector128<T> vrotlx<T>(Vector128<T> src, [Imm] byte count)
            where T : unmanaged
                => generic<T>(cpu.vrotlx(v64u(src), count));

        /// <summary>
        /// Rotates each 128 bit lane vector leftward at bit-level resolution
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The number of bits to shift</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector256<T> vrotlx<T>(Vector256<T> src, [Imm] byte count)
            where T : unmanaged
                => generic<T>(cpu.vrotlx(v64u(src), count));
    }
}
