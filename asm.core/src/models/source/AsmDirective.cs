//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct AsmDirective
    {
        public readonly text15 Name;

        public readonly AsmDirectiveOp Op0;

        public readonly AsmDirectiveOp Op1;

        public readonly AsmDirectiveOp Op2;

        [MethodImpl(Inline)]
        public AsmDirective(text15 name, AsmDirectiveOp op0 = default, AsmDirectiveOp op1 = default, AsmDirectiveOp op2 = default)
        {
            Name = name;
            Op0 = op0;
            Op1 = op1;
            Op2 = op2;
        }

        public static AsmDirective Empty => new AsmDirective(EmptyString, EmptyString, EmptyString, EmptyString);
    }
}