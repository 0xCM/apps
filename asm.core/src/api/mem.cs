//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static AsmOperands;

    partial struct asm
    {
        [MethodImpl(Inline), Op]
        public static m8 mem8(AsmAddress address)
            => new m8(address);

        [MethodImpl(Inline), Op]
        public static m16 mem16(AsmAddress address)
            => new m16(address);

        [MethodImpl(Inline), Op]
        public static m32 mem32(AsmAddress address)
            => new m32(address);

        [MethodImpl(Inline), Op]
        public static m64 mem64(AsmAddress address)
            => new m64(address);

        [MethodImpl(Inline), Op]
        public static m128 mem128(AsmAddress address)
            => new m128(address);

        [MethodImpl(Inline), Op]
        public static m256 mem256(AsmAddress address)
            => new m256(address);

        [MethodImpl(Inline), Op]
        public static m512 mem512(AsmAddress address)
            => new m512(address);

        [MethodImpl(Inline), Op]
        public static m8 mem8(RegOp @base, RegOp index, MemoryScale scale, Disp disp)
            => new m8(@base, index, scale, disp);

        [MethodImpl(Inline), Op]
        public static m16 mem16(RegOp @base, RegOp index, MemoryScale scale, Disp disp)
            => new m16(@base, index, scale, disp);

        [MethodImpl(Inline), Op]
        public static m32 mem32(RegOp @base, RegOp index, MemoryScale scale, Disp disp)
            => new m32(@base, index, scale, disp);

        [MethodImpl(Inline), Op]
        public static m64 mem64(RegOp @base, RegOp index, MemoryScale scale, Disp disp)
            => new m64(@base, index, scale, disp);

        [MethodImpl(Inline), Op]
        public static m128 mem128(RegOp @base, RegOp index, MemoryScale scale, Disp disp)
            => new m128(@base, index, scale, disp);

        [MethodImpl(Inline), Op]
        public static m256 mem256(RegOp @base, RegOp index, MemoryScale scale, Disp disp)
            => new m256(@base, index, scale, disp);

        [MethodImpl(Inline), Op]
        public static m512 mem512(RegOp @base, RegOp index, MemoryScale scale, Disp disp)
            => new m512(@base,index,scale,disp);

        [MethodImpl(Inline)]
        public static mem<T> mem<T>(RegOp @base, RegOp index, MemoryScale scale, Disp disp)
            where T : unmanaged, IMemOp<T>
                => new mem<T>(@base, index,scale, disp);
    }
}