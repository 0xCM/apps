//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Rules
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct Split<T> 
    {
        public readonly T Delimiter;

        [MethodImpl(Inline)]
        public Split(T delimiter)
        {
            Delimiter = delimiter;
        }
    }    
}