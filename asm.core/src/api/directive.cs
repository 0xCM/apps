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
        public static AsmDirective directive(text15 name, AsmDirectiveOp op0 = default, AsmDirectiveOp op1 = default, AsmDirectiveOp op2 = default)
            => new AsmDirective(name,op0,op1,op2);
    }
}