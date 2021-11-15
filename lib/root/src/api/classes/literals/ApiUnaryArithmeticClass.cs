//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Id = ApiClassKind;

    /// <summary>
    /// Classifies unary arithmetic operators
    /// </summary>
    [ApiClass]
    public enum ApiUnaryArithmeticClass : ushort
    {
        None = 0,

        Inc = Id.Inc,

        Dec = Id.Dec,

        Negate = Id.Negate,

        Abs = Id.Abs,

        Square = Id.Square,

        Sqrt = Id.Sqrt,

        Even = Id.Even,

        Odd = Id.Odd,
    }
}