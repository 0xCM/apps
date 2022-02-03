//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial class AsmBytes
    {
        [MethodImpl(Inline), Op]
        public static byte int3(Span<byte> dst)
        {
            seek(dst,int3());
            return 1;
        }

        [MethodImpl(Inline), Op]
        public static byte int3()
            => 0xCC;

        [MethodImpl(Inline), Op]
        public static bit int3(byte src)
            => src == int3();
    }
}