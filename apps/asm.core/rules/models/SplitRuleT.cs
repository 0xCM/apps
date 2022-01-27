//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct SplitRule<T>
    {
        public readonly T Delimiter;

        [MethodImpl(Inline)]
        public SplitRule(T delimiter)
        {
            Delimiter = delimiter;
        }
    }
}