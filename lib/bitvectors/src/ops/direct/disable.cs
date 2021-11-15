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
        /// Disables a bit if it is enabled
        /// </summary>
        /// <param name="pos">The bit position</param>
        [MethodImpl(Inline), Op]
        public static BitVector4 disable(BitVector4 x, int index)
            => bits.disable(x.State, index);

        /// <summary>
        /// Disables a bit if it is enabled
        /// </summary>
        /// <param name="index">The bit position</param>
        [MethodImpl(Inline), Op]
        public static BitVector8 disable(BitVector8 x, int index)
            => bits.disable(x.State, index);

        /// <summary>
        /// Disables a bit if it is enabled
        /// </summary>
        /// <param name="index">The bit position</param>
        [MethodImpl(Inline), Op]
        public static BitVector16 disable(BitVector16 x, int index)
            => bits.disable(x.State, index);

        /// <summary>
        /// Disables a bit if it is enabled
        /// </summary>
        /// <param name="index">The bit position</param>
        [MethodImpl(Inline), Op]
        public static BitVector32 disable(BitVector32 x, int index)
            => bits.disable(x.State, index);

        /// <summary>
        /// Disables a bit if it is enabled
        /// </summary>
        /// <param name="index">The bit position</param>
        [MethodImpl(Inline), Op]
        public static BitVector64 disable(BitVector64 x, int index)
            => bits.disable(x.State, index);
    }
}