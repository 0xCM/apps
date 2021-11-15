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
        public readonly struct Region
        {
            public dynamic Base {get;}

            public Pair<dynamic> UpperLeft {get;}

            public Pair<dynamic> LowerRight {get;}

            [MethodImpl(Inline)]
            public Region(dynamic @base, Pair<dynamic> tl, Pair<dynamic> br)
            {
                Base = @base;
                UpperLeft = tl;
                LowerRight = br;
            }
        }
    }
}