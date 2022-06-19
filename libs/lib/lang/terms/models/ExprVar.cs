//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ExprVar : IVar
    {
        public VarSymbol Name {get;}

        public ExprVar(VarSymbol name)
        {
            Name = name;
        }

        public IExpr Eval(IExprContext context)
            => context.Resolve(Name);

        public T Eval<T>(IExprContext context)
            where T : IExpr
                => context.Resolve<T>(Name);

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsEmpty;
        }

        public string Format()
            => Name.Format();

        public override int GetHashCode()
            => Name.GetHashCode();

        public bool Equals(ExprVar src)
            => Name.Equals(src.Name);

        public override bool Equals(object src)
            => src is ExprVar v && Equals(v);
    }
}