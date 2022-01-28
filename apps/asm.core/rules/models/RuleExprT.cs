//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public abstract class RuleExpr<T> : RuleExpr, IRuleExpr<T>
    {
        public T Content {get;}

        protected RuleExpr(T value)
        {
            Content = value;
        }

        public override string Format()
            => Content.ToString();
    }

    public abstract class RuleExpr<R,T> : RuleExpr<T>
        where R : RuleExpr<R,T>
    {
        protected RuleExpr(T content)
            : base(content)
        {

        }


        public override bool IsTerminal {get; protected set;}

        public virtual Index<R> Terminate()
        {
            IsTerminal = true;
            return core.array((R)this);
        }
    }
}