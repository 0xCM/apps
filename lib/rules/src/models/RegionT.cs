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
        public readonly struct Region<B,T>
        {
            public B Base {get;}

            public Pair<T> UpperLeft {get;}

            public Pair<T> LowerRight {get;}

            [MethodImpl(Inline)]
            public Region(B @base, Pair<T> tl, Pair<T> br)
            {
                Base = @base;
                UpperLeft = tl;
                LowerRight = br;
            }

            public static implicit operator Region(Region<B,T> src)
                => new Region(src.Base,
                    ((dynamic)src.UpperLeft.Left, src.UpperLeft.Right),
                    ((dynamic)src.LowerRight.Left, src.LowerRight.Right)
                    );
        }
    }
}