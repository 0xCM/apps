//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    [ApiHost("expr.api")]
    public readonly partial struct expr
    {
        const NumericKind Closure = UnsignedInts;

        public static ExprContext context()
            => new ExprContext();
   }
}