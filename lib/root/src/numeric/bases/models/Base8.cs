//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct Base8 : INumericBase<Base8>
    {
        public static Base8 Base => default;

        public NumericBaseKind Modulus
            => NumericBaseKind.Base8;

        public NumericBaseIndicator Indicator
            => NumericBaseIndicator.Base8;

        [MethodImpl(Inline)]
        public static implicit operator int(Base8 src)
            => (int)src.Modulus;

        [MethodImpl(Inline)]
        public static implicit operator NumericBaseKind(Base8 src)
            => src.Modulus;
    }
}