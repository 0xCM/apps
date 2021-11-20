//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct AsmEncoding
    {
         [MethodImpl(Inline), Op]
         static byte combine(Pair<byte> a, Pair<byte> b, Pair<byte> c)
         {
             var dst = Bytes.sll(a.Left, a.Right);
             dst = Bytes.or(dst, Bytes.sll(b.Left, b.Right));
             dst = Bytes.or(dst, Bytes.sll(c.Left, c.Right));
             return dst;
         }

        [MethodImpl(Inline), Op]
        public static Sib sib(uint3 @base, uint3 index, uint2 scale)
            => new Sib(combine((scale, 0), (index, 2), (@base, 6)));
    }
}
