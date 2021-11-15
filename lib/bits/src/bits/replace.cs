//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class bits
    {
        /// <summary>
        /// Replaces an index-delimited source segment with a specified value
        /// </summary>
        /// <param name="src"></param>
        /// <param name="k0"></param>
        /// <param name="k1"></param>
        /// <param name="value"></param>
        [MethodImpl(Inline), Op]
        public static byte replace(byte src, byte k0, byte k1, byte value)
            => math.or(math.sll(value, (byte)(k1 - k0)), trim(src,k0,k1));

        /// <summary>
        /// Replaces an index-delimited source segment with a specified value
        /// </summary>
        /// <param name="src"></param>
        /// <param name="k0"></param>
        /// <param name="k1"></param>
        /// <param name="value"></param>
        [MethodImpl(Inline), Op]
        public static ushort replace(ushort src, byte k0, byte k1, ushort value)
            => math.or(math.sll(value, (byte)(k1 - k0)), trim(src, k0,k1));

        /// <summary>
        /// Replaces an index-delimited source segment with a specified value
        /// </summary>
        /// <param name="src"></param>
        /// <param name="k0"></param>
        /// <param name="k1"></param>
        /// <param name="value"></param>
        [MethodImpl(Inline), Op]
        public static uint replace(uint src, byte k0, byte k1, uint value)
            => math.or(math.sll(value, (byte)(k1 - k0)), trim(src,k0,k1));

        /// <summary>
        /// Replaces an index-delimited source segment with a specified value
        /// </summary>
        /// <param name="src"></param>
        /// <param name="k0"></param>
        /// <param name="k1"></param>
        /// <param name="value"></param>
        [MethodImpl(Inline), Op]
        public static ulong replace(ulong src, byte k0, byte k1, ulong value)
            => math.or(math.sll(value, (byte)(k1 - k0)), trim(src,k0,k1));
    }
}