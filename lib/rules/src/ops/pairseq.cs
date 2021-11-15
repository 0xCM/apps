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
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static PairSeq<T> pairseq<T>(Pair<T>[] terms)
            => terms;

        [MethodImpl(Inline)]
        public static PairSeq<L,R> pairseq<L,R>(Paired<L,R>[] terms)
            => terms;
    }
}