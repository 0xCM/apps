//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Classifies scalar types
    /// </summary>
    [SymSource("canonical")]
    public enum ScalarClass : byte
    {
        None,

        [Symbol("b", "Designates a bit type")]
        B = 1,

        [Symbol("u", "Designates an unsigned integer type")]
        U = 2,

        [Symbol("i", "Designates a signed integer type")]
        I = 4,

        [Symbol("f", "Designates a floating point type")]
        F = 8,

        [Symbol("c", "Designates a character type")]
        C = 16,
    }
}