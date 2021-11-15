//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class BitVector
    {
        /// <summary>
        /// Disables the high bits starting at a specified position
        /// </summary>
        /// <param name="pos">The bit position</param>
        [MethodImpl(Inline), MsbOff]
        public static BitVector4 cut(BitVector4 src, byte pos)
            => gbits.cut(src.State, pos);

        /// <summary>
        /// Disables the high bits starting at a specified position
        /// </summary>
        /// <param name="pos">The bit position</param>
        [MethodImpl(Inline), MsbOff]
        public static BitVector8 cut(BitVector8 src, byte pos)
            => gbits.cut(src.State, pos);

        /// <summary>
        /// Disables the high bits starting at a specified position
        /// </summary>
        /// <param name="pos">The bit position</param>
        [MethodImpl(Inline), MsbOff]
        public static BitVector16 cut(BitVector16 src, byte pos)
            => gbits.cut(src.State, pos);

        /// <summary>
        /// Disables the high bits starting at a specified position
        /// </summary>
        /// <param name="pos">The bit position</param>
        [MethodImpl(Inline), MsbOff]
        public static BitVector32 cut(BitVector32 src, byte pos)
            => gbits.cut(src.State, pos);

        /// <summary>
        /// Disables the high bits starting at a specified position
        /// </summary>
        /// <param name="pos">The bit position</param>
        [MethodImpl(Inline), MsbOff]
        public static BitVector64 cut(BitVector64 src, byte pos)
            => gbits.cut(src.State, pos);
    }
}