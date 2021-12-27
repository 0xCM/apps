//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Concurrent;

    using static Root;
    using static core;

    public class ExprContext : IVarResolver
    {
        ConcurrentDictionary<VarSymbol,IExpr> Vars;

        public ExprContext()
        {
            Vars = new();
        }

        public ExprContext(params (VarSymbol name,IExpr value)[] src)
        {
            Vars = new();
            iter(src, x => Inject(x.name, x.value));
        }

        public bool Inject(VarSymbol name, IExpr value)
            => Vars.TryAdd(name,value);

        public IExpr Resolve(VarSymbol name)
        {
            if(Vars.TryGetValue(name, out var expr))
                return expr;
            else
                return EmptyExpr.Empty;
        }
    }
}