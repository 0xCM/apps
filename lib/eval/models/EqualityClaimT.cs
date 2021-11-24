//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    public readonly struct EqualityClaim<C> : IEqualityClaim<C>
        where C : IEquatable<C>
    {
        public C Actual {get;}

        public C Expect {get;}

        [MethodImpl(Inline)]
        public EqualityClaim(C actual, C expect)
        {
            Actual = actual;
            Expect = expect;
        }

        public string Format()
            => string.Format("claim(equal<{0}>(actual:{1}, expect:{2}))", typeof(C).DisplayName(),  Actual, Expect);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator EqualityClaim<C>((C actual, C expect) src)
            => new EqualityClaim<C>(src.actual, src.expect);
    }
}