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
        public static m8 mem8(RegOp @base)
            => new m8(@base, RegOp.Invalid, 0, Disp.Zero);

        [MethodImpl(Inline), Op]
        public static m8 mem8(AsmAddress address)
            => new m8(address);

        [MethodImpl(Inline), Op]
        public static m8 mem8(RegOp @base, RegOp index, MemoryScale scale, Disp disp)
            => new m8(@base, index, scale, disp);
    }
}