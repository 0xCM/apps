//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.CompilerServices;

    using static Root;
    using static AsmSigModels;

    public partial class AsmSigBuilder
    {
        [MethodImpl(Inline), Op]
        public static r8 al()
            => new r8(GpRegToken.al);

        [MethodImpl(Inline), Op]
        public static r16 ax()
            => new r16(GpRegToken.ax);

        [MethodImpl(Inline), Op]
        public static r32 eax()
            => new r32(GpRegToken.eax);

        [MethodImpl(Inline), Op]
        public static r64 rax()
            => new r64(GpRegToken.rax);

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
        public static rK rK()
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
        public static m128 m128()
            => default;

        [MethodImpl(Inline), Op]
        public static m256 m256()
            => default;

        [MethodImpl(Inline), Op]
        public static m256 m512()
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

        [MethodImpl(Inline), Op]
        public static Rel8 rel8()
            => default;

        [MethodImpl(Inline), Op]
        public static Rel16 rel16()
            => default;

        [MethodImpl(Inline), Op]
        public static Rel32 rel32()
            => default;

        [MethodImpl(Inline), Op]
        public static MmxReg mmx()
            => new MmxReg(MmxRegToken.mm);

        [MethodImpl(Inline), Op]
        public static MmxReg mmx32()
            => new MmxReg(MmxRegToken.mm32);

        [MethodImpl(Inline), Op]
        public static MmxReg mmx64()
            => new MmxReg(MmxRegToken.mm64);

        [MethodImpl(Inline), Op]
        public static xmm xmm()
            => default;

        [MethodImpl(Inline), Op]
        public static ymm ymm()
            => default;

        [MethodImpl(Inline), Op]
        public static zmm zmm()
            => default;
    }
}