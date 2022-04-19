//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class BitVectors
    {
        /// <summary>
        /// Disables a bit if it is enabled
        /// </summary>
        /// <param name="index">The position of the bit to disable</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ScalarBits<T> disable<T>(ScalarBits<T> x, int index)
            where T : unmanaged
                => gbits.disable(x.State,index);

        /// <summary>
        /// Disables a bit if it is enabled
        /// </summary>
        /// <param name="index">The position of the bit to disable</param>
        [MethodImpl(Inline)]
        public static ScalarBits<N,T> disable<N,T>(ScalarBits<N,T> x, int index)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => gbits.disable(x.State,index);

        /// <summary>
        /// Disables a bit if it is enabled
        /// </summary>
        /// <param name="index">The position of the bit to enable</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitVector128<T> disable<T>(BitVector128<T> src, byte index)
            where T : unmanaged
        {
            if(index < 64)
                return generic<T>(cpu.vparts(w128, bits.disable(src.Lo,index), src.Hi));
            else
                return generic<T>(cpu.vparts(w128, src.Lo, bits.disable(src.Hi,(byte)(index-64))));
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitVector256<T> disable<T>(BitVector256<T> src, byte pos)
            where T : unmanaged
                => pos < 127
                ? gcpu.vinsert(disable(src.Lo,pos), src.State,LaneIndex.L0)
                : gcpu.vinsert(disable(src.Hi,pos), src.State,LaneIndex.L1);

    }
}