//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using Operands;

    using static Root;

    partial struct asm
    {
        [MethodImpl(Inline), Op]
        public static m16 mem16(RegOp @base)
            => new m16(@base, RegOp.Invalid, 0, Disp.Zero);

        [MethodImpl(Inline), Op]
        public static m16 mem16(AsmAddress address)
            => new m16(address);

        [MethodImpl(Inline), Op]
        public static m16 mem16(RegOp @base, RegOp index, MemoryScale scale, Disp disp)
            => new m16(@base, index, scale, disp);

        [MethodImpl(Inline), Op]
        public static m64 mem64(RegOp @base)
            => new m64(@base, RegOp.Invalid, 0, Disp.Zero);

        [MethodImpl(Inline), Op]
        public static m64 mem64(AsmAddress address)
            => new m64(address);

        [MethodImpl(Inline), Op]
        public static m64 mem64(RegOp @base, RegOp index, MemoryScale scale, Disp disp)
            => new m64(@base, index, scale, disp);

        [MethodImpl(Inline), Op]
        public static m128 mem128(RegOp @base)
            => new m128(@base, RegOp.Invalid, 0, Disp.Zero);

        [MethodImpl(Inline), Op]
        public static m128 mem128(AsmAddress address)
            => new m128(address);

        [MethodImpl(Inline), Op]
        public static m128 mem128(RegOp @base, RegOp index, MemoryScale scale, Disp disp)
            => new m128(@base, index, scale, disp);

        [MethodImpl(Inline)]
        public static mem<T> mem<T>(RegOp @base, RegOp index, MemoryScale scale, Disp disp)
            where T : unmanaged, IMemOp<T>
                => new mem<T>(@base, index,scale, disp);
    }
}