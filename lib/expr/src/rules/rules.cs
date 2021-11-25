//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Rules
{
    using System;
    using System.Collections.Generic;

    using Expr;
    using Ops;

    using static Root;

    public readonly partial struct rules
    {
        const NumericKind Closure = UnsignedInts;

        public static IEnumerable<IExpr> tests()
        {
            var counter = 7u;
            var x = expr.var("x", () => expr.value(counter++));
            var y = expr.var("y", () => expr.value(counter+=2));
            var a = logic.and(x,y);
            var b = logic.or(a,x);
            var c = logic.xor(a,b);
            yield return c;
            yield return c;
            yield return c;
        }
    }
}