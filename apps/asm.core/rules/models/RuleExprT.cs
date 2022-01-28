//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class RuleExpr : IRuleExpr
    {
        public abstract string Format();

        public override string ToString()
            => Format();

        public virtual bool IsTerminal => false;
    }

    public abstract class RuleExpr<T> : RuleExpr, IRuleExpr<T>
    {
        public T Content {get;}

        protected RuleExpr(T value)
        {
            Content = value;
        }
    }
}