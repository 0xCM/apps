//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.CompilerServices;

    using static Root;
    using static AsmSigs;

    [ApiHost]
    public readonly struct AsmSigBuilder
    {
        [MethodImpl(Inline), Op]
        public static r8 r8()
            => default;

        [MethodImpl(Inline), Op]
        public static r16 r16()
            => default;

        [MethodImpl(Inline), Op]
        public static r32 r32()
            => default;

        [MethodImpl(Inline), Op]
        public static r64 r64()
            => default;

        [MethodImpl(Inline), Op]
        public static m8 m8()
            => default;

        [MethodImpl(Inline), Op]
        public static m16 m16()
            => default;

        [MethodImpl(Inline), Op]
        public static m32 m32()
            => default;

        [MethodImpl(Inline), Op]
        public static m64 m64()
            => default;

        [MethodImpl(Inline), Op]
        public static imm8 imm8()
            => default;

        [MethodImpl(Inline), Op]
        public static imm16 imm16()
            => default;

        [MethodImpl(Inline), Op]
        public static imm32 imm32()
            => default;

        [MethodImpl(Inline), Op]
        public static imm64 imm64()
            => default;
    }
}