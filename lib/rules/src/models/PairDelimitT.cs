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
        public readonly struct PairDelimit<T>
            where T : IEquatable<T>
        {
            public Delimit<T> Left {get;}

            public Delimit<T> Right {get;}

            [MethodImpl(Inline)]
            public PairDelimit(Delimit<T> left, Delimit<T> right)
            {
                Left = left;
                Right = right;
            }

            [MethodImpl(Inline)]
            public bool Test(T a0, T a1)
                => Left.Test(a0) && Right.Test(a1);

            [MethodImpl(Inline)]
            public static implicit operator PairDelimit<T>((T left, T right) src)
                => new PairDelimit<T>(src.left, src.right);

            [MethodImpl(Inline)]
            public static implicit operator PairDelimit<T>((Delimit<T> left, Delimit<T> right) src)
                => new PairDelimit<T>(src.left, src.right);
        }
    }
}