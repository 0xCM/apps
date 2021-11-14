//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct asm
    {
        [MethodImpl(Inline), Op]
        public static AsmOpCode opcode(uint key, in CharBlock48 expr)
            => new AsmOpCode(key, AsmOpCodeBits.Empty, expr);
    }
}