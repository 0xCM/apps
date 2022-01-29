//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;

    using static Root;
    using static core;

    public class AsmOpMaskRule : RuleExpr<AsmOpMask>
    {
        public AsmOpMaskRule(AsmOpMask src)
            : base(src)
        {

        }

        public static implicit operator AsmOpMaskRule(AsmOpMask src)
            => new AsmOpMaskRule(src);
    }
}