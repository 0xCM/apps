//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using Expr;

    using static Root;

    partial struct expr
    {
        [MethodImpl(Inline), Op]
        public static Var var(string name, Type t, Func<IExpr> resolver)
            => new Var(name, t, resolver);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Var<T> var<T>(string name, Func<T> resolver)
            => new Var<T>(name,resolver);
    }
}