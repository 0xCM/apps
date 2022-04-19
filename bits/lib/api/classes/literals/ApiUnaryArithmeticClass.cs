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
    [ApiClass, SymSource("api.classes")]
    public enum ApiUnaryArithmeticClass : ushort
    {
        None = 0,

        [Symbol("inc")]
        Inc = Id.Inc,

        [Symbol("dec")]
        Dec = Id.Dec,

        [Symbol("negate")]
        Negate = Id.Negate,

        [Symbol("abs")]
        Abs = Id.Abs,

        [Symbol("square")]
        Square = Id.Square,

        [Symbol("sqrt")]
        Sqrt = Id.Sqrt,

        [Symbol("even")]
        Even = Id.Even,

        [Symbol("odd")]
        Odd = Id.Odd,
    }
}