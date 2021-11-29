//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops
{
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Represents a bijective correspondence between two sequences of homogenous type
    /// </summary>
    public readonly struct BijectivePoints<T>
    {
        public Index<T> Source {get;}

        public Index<T> Target {get;}

        [MethodImpl(Inline)]
        public BijectivePoints(Index<T> src, Index<T> dst)
        {
            Source = src;
            Target = dst;
        }

        public Pair<T> this[uint i]
        {
            [MethodImpl(Inline)]
            get => (Source[i], Target[i]);
        }
    }   
}