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
        public static m256 mem256(RegOp @base)
            => new m256(@base, RegOp.Invalid, 0, Disp.Zero);

        [MethodImpl(Inline), Op]
        public static m256 mem256(AsmAddress address)
            => new m256(address);

        [MethodImpl(Inline), Op]
        public static m256 mem256(RegOp @base, RegOp index, MemoryScale scale, Disp disp)
            => new m256(@base, index, scale, disp);
    }
}