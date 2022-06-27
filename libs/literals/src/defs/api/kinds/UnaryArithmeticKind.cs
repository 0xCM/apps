//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Classifies elementary unary arithmetic operations
    /// </summary>
    [SymSource("api.kinds")]
    public enum UnaryArithmeticKind : byte
    {
        None,

        Inc,

        Dec,
    }
}