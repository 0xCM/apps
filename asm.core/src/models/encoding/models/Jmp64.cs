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
    using static AsmOperands;

    [ApiHost]
    public readonly struct Jmp64
    {
        public const byte MaxSize = 3;

        public const byte MinSize = 2;

        public const byte OpCode = 0xFF;

        [MethodImpl(Inline), Op]
        public static bit rex(ReadOnlySpan<byte> src)
            => first(src) == 0x48;

        [MethodImpl(Inline), Op]
        public static bool test(ReadOnlySpan<byte> src)
            => (src.Length == MaxSize && rex(src) && skip(src,1) == OpCode)
            || (src.Length == MinSize && first(src) == OpCode);

        [MethodImpl(Inline), Op]
        public static r64 target(ReadOnlySpan<byte> src)
            => rex(src) ? (RegIndexCode)(skip(src,2) & 0xF) : (RegIndexCode)(skip(src,1) & 0xF);
    }
}