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
        /// Converts the vector to a bitspan representation
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline), Op]
        public static BitSpan bitspan(BitVector4 x)
            => BitSpans.create(x.State);

        /// <summary>
        /// Converts the vector to a bitspan representation
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline), Op]
        public static BitSpan bitspan(BitVector8 x)
            => BitSpans.create(x.State);

        /// <summary>
        /// Converts the vector to a bitspan representation
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline), Op]
        public static BitSpan bitspan(BitVector16 x)
            => BitSpans.create(x.State);

        /// <summary>
        /// Converts the vector to a bitspan representation
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline), Op]
        public static BitSpan bitspan(BitVector24 x)
            => BitSpans.create(x.State);

        /// <summary>
        /// Converts the vector to a bitspan representation
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline), Op]
        public static BitSpan bitspan(BitVector32 x)
            => BitSpans.create(x.State);

        /// <summary>
        /// Converts the vector to a bitspan representation
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline), Op]
        public static BitSpan bitspan(BitVector64 x)
            => BitSpans.create(x.State);
    }
}