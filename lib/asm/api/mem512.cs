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
        public static m512 mem512(RegOp @base)
            => new m512(@base, RegOp.Invalid, 0, Disp.Zero);

        [MethodImpl(Inline), Op]
        public static m512 mem512(AsmAddress address)
            => new m512(address);

        [MethodImpl(Inline), Op]
        public static m512 mem512(RegOp @base, RegOp index, MemoryScale scale, Disp disp)
            => new m512(@base,index,scale,disp);
    }
}