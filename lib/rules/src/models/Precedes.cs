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
        /// <summary>
        /// Requires that one element occurrs before another
        /// </summary>
        public readonly struct Precedes<T>
        {
            public T Before {get;}

            public T After {get;}

            [MethodImpl(Inline)]
            public Precedes(T before, T after)
            {
                Before = before;
                After = after;
            }
        }
    }
}