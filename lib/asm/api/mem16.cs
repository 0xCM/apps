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
    }
}