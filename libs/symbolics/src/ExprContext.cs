//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class ExprContext : IVarResolver
    {
        ConcurrentDictionary<NameOld,IExprDeprecated> Vars;

        public ExprContext()
        {
            Vars = new();
        }

        public void Inject(params (ExprVar var, IExprDeprecated value)[] src)
        {
            iter(src, x => Inject(x.var, x.value));
        }

        public void Inject(ExprVar var, IExprDeprecated value)
        {
            Vars[var.Name] = value;
        }

        public IExprDeprecated Resolve(NameOld name)
        {
            if(Vars.TryGetValue(name, out var expr))
                return expr;
            else
                return Errors.Throw<IExprDeprecated>(string.Format("The variable '{0}' cannot be resolved", name));
        }

        public T Resolve<T>(NameOld name)
            where T : IExprDeprecated
        {
            if(Vars.TryGetValue(name, out var expr))
                return (T)expr;
            else
                return Errors.Throw<T>(string.Format("The variable '{0}' cannot be resolved", name));
        }
    }
}