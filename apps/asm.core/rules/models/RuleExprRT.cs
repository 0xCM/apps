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

    public abstract class RuleExpr<R,T> : RuleExpr<Index<T>>
        where R : RuleExpr<R,T>
    {
        protected RuleExpr(Index<T> terms)
            : base(terms)
        {
            Terms = terms;
        }

        public Index<T> Terms {get;}

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Content.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Content.IsNonEmpty;
        }
    }
}