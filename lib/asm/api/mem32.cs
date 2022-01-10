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
        public static m32 mem32(RegOp @base)
            => new m32(@base, RegOp.Invalid, 0, Disp.Zero);

        [MethodImpl(Inline), Op]
        public static m32 mem32(AsmAddress address)
            => new m32(address);

        [MethodImpl(Inline), Op]
        public static m32 mem32(RegOp @base, RegOp index, MemoryScale scale, Disp disp)
            => new m32(@base, index, scale, disp);
    }
}