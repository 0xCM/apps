//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct RuleModels
    {
        public readonly struct Substitution<T>
        {
            public T Match {get;}

            public T Replace {get;}

            [MethodImpl(Inline)]
            public Substitution(T src, T dst)
            {
                Match = src;
                Replace = dst;
            }
        }
    }
}