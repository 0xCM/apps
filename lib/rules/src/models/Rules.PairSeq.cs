//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct RuleModels
    {
        /// <summary>
        /// Defines a sequence of dynamically-typed pairs with arbitrary homogeneity
        /// </summary>
        public readonly struct PairSeq
        {
            public readonly Index<Paired<dynamic,dynamic>> Terms {get;}

            [MethodImpl(Inline)]
            public PairSeq(Index<Paired<dynamic,dynamic>> src)
            {
                Terms = src;
            }

            [MethodImpl(Inline)]
            public static implicit operator PairSeq(Paired<dynamic,dynamic>[] src)
                => new PairSeq(src);
        }
    }
}