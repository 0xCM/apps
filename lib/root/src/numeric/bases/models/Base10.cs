//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct Base10 : INumericBase<Base10>
    {
        public static Base10 Base => default;

        public NumericBaseKind Modulus
            => NumericBaseKind.Base10;

        public NumericBaseIndicator Indicator
            => NumericBaseIndicator.Base10;

        [MethodImpl(Inline)]
        public static implicit operator int(Base10 src)
            => (int)src.Modulus;

        [MethodImpl(Inline)]
        public static implicit operator NumericBaseKind(Base10 src)
            => src.Modulus;
    }
}