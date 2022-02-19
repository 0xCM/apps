//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [DataType("base<n:3>")]
    public readonly struct Base3 : INumericBase<Base3>
    {
        public static Base3 Base => default;

        public NumericBaseKind Modulus
            => NumericBaseKind.Base3;

        public NumericBaseIndicator Indicator
            => NumericBaseIndicator.Base3;

        [MethodImpl(Inline)]
        public static implicit operator int(Base3 src)
            => (int)src.Modulus;

        [MethodImpl(Inline)]
        public static implicit operator NumericBaseKind(Base3 src)
            => src.Modulus;
    }
}