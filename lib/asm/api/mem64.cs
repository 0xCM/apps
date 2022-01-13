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
        public static m64 mem64(RegOp @base)
            => new m64(@base, RegOp.Invalid, 0, Disp.Zero);

        [MethodImpl(Inline), Op]
        public static m64 mem64(AsmAddress address)
            => new m64(address);

        [MethodImpl(Inline), Op]
        public static m64 mem64(RegOp @base, RegOp index, MemoryScale scale, Disp disp)
            => new m64(@base, index, scale, disp);
    }
}