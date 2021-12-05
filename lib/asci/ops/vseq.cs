//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static Root;
    using static core;

    partial struct Asci
    {
        /// <summary>
        /// Loads up to 16 asci scalar symbols [offset, offset + count]
        /// </summary>
        /// <param name="count">The number of symbols to load</param>
        [MethodImpl(Inline), Op]
        public static Vector256<ushort> vseq(W256 w, sbyte offset, Hex4Seq count)
        {
            var src = scalars(offset, (sbyte)count);
            var target = default(Vector256<ushort>);
            ref var dst = ref gcpu.vref(ref target);
            for(byte i=0; i<(byte)count; i++)
                seek(dst,i) = skip(src,i);
            return target;
        }

        /// <summary>
        /// Loads up to 32 asci scalar symbols [offset, offset + count]
        /// </summary>
        /// <param name="count">The number of symbols to load</param>
        [MethodImpl(Inline), Op]
        public static Vector512<ushort> vseq(W512 w, sbyte offset, Hex5Seq count)
        {
            var src = scalars(offset, (sbyte)count);
            var target = default(Vector512<ushort>);
            ref var dst = ref gcpu.vref(ref target);
            for(byte i=0; i<(byte)count; i++)
                seek(dst, i) = skip(src, i);
            return target;
        }
    }
}