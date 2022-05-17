//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class ExprContext : IExprContext
    {
        ConcurrentDictionary<VarSymbol,IExpr> Vars;

        public ExprContext()
        {
            Vars = new();
        }

        public void Inject(params (ExprVar var, IExpr value)[] src)
        {
            iter(src, x => Inject(x.var, x.value));
        }

        public void Inject(ExprVar var, IExpr value)
        {
            Vars[var.Name] = value;
        }

        public IExpr Resolve(VarSymbol name)
        {
            if(Vars.TryGetValue(name, out var expr))
                return expr;
            else
                return Errors.Throw<IExpr>(string.Format("The variable '{0}' cannot be resolved", name));
        }

        public T Resolve<T>(VarSymbol name)
            where T : IExpr
        {
            if(Vars.TryGetValue(name, out var expr))
                return (T)expr;
            else
                return Errors.Throw<T>(string.Format("The variable '{0}' cannot be resolved", name));
        }
    }
}