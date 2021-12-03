//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Represents a bijective correspondence between two sequences
    /// </summary>
    public class BijectivePoints<S,T>
    {
        public Index<S> Source {get;}

        public Index<T> Target {get;}

        [MethodImpl(Inline)]
        public BijectivePoints(Index<S> src, Index<T> dst)
        {
            Source = src;
            Target = dst;
        }

        public Paired<S,T> this[uint i]
        {
            [MethodImpl(Inline)]
            get => (Source[i], Target[i]);
        }
    }    
}