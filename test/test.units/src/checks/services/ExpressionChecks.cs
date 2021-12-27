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

    public class ExpressionChecks : Checker<ExpressionChecks>
    {
        public Outcome CheckRelationalExpressions()
        {
            var result = Outcome.Success;

            var v1 = expr.var("a");
            var v2 = expr.var("b");
            var a1 = expr.scalar((byte)22);
            var b1 = expr.scalar((byte)12);
            var a2 = expr.scalar((byte)16);
            var b2 = expr.scalar((byte)87);
            var context = expr.context();
            context.Inject((v1,a1), (v2,b1));
            var eval1 =  v1.Eval<scalar<byte>>(context);
            var eval2 = v2.Eval<scalar<byte>>(context);
            result = (eval1 == a1 && eval2 == b1);

            var eq1 = ScalarOps.eq(a1,b1);
            Write(eq1.Format());

            context.Inject((v1,a2), (v2,b2));
            var eval3 = v1.Eval(context);
            var eval4 = v2.Eval(context);
            var eq2 = ScalarOps.eq(a2,b2);
            Write(eq2.Format());

            return result;
        }
    }
}