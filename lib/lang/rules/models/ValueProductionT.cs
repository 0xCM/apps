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

    public abstract class ValueProduction<T> : ValueProduction<T,T>
    {
        protected ValueProduction(T src, T dst)
            : base(src,dst)
        {
        }
    }
}