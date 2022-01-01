//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static core;
    using static Root;

    public abstract class Production<S,T> : IProduction<S,T>
        where S : IExpr
        where T : IExpr

    {
        public S Source {get;}

        public T Target {get;}


        protected Production(S src, T dst)
        {
            Source = src;
            Target = dst;
        }

        public virtual string Format()
            => string.Format("{0} -> {1}", Source, Target);

        public override string ToString()
            => Format();
    }
}