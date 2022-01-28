//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;

    using static Root;
    using static core;

    public abstract class RuleExpr : IRuleExpr
    {
        public abstract string Format();

        public override string ToString()
            => Format();


        public virtual bool IsTerminal {get; protected set;}
    }
}