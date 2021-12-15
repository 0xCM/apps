//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using NBK = NumericBaseKind;

    using static Perm4Sym;

    /// <summary>
    /// Identifies 2-element cycles over 4 symbols
    /// </summary>
    [SymSource("perms", NBK.Base2)]
    public enum Perm2x4 : byte
    {
        /// <summary>
        /// ([0, 1, 2, 3], [4, 5, 6, 7]) -> [0, 1, 4, 5]
        /// </summary>
        [Symbol("([0, 1, 2, 3], [4, 5, 6, 7]) -> [0, 1, 4, 5]")]
        AC = A | C << 4,

        /// <summary>
        /// ([0, 1, 2, 3], [4, 5, 6, 7]) -> [4, 5, 0, 1]
        /// </summary>
        [Symbol("([0, 1, 2, 3], [4, 5, 6, 7]) -> [4, 5, 0, 1]")]
        CA = C | A << 4,

        /// <summary>
        /// ([0, 1, 2, 3], [4, 5, 6, 7]) -> [0, 1, 6, 7]
        /// </summary>
        [Symbol("([0, 1, 2, 3], [4, 5, 6, 7]) -> [0, 1, 6, 7]")]
        AD = A | D << 4,

        /// <summary>
        /// ([0, 1, 2, 3], [4, 5, 6, 7]) -> [6, 7, 0, 1]
        /// </summary>
        [Symbol("([0, 1, 2, 3], [4, 5, 6, 7]) -> [6, 7, 0, 1]")]
        DA = D | A << 4,

        /// <summary>
        /// ([0, 1, 2, 3], [4, 5, 6, 7]) -> [2, 3, 4, 5]
        /// </summary>
        [Symbol("([0, 1, 2, 3], [4, 5, 6, 7]) -> [2, 3, 4, 5]")]
        BC = B | C << 4,

        /// <summary>
        /// ([0, 1, 2, 3], [4, 5, 6, 7]) -> [4, 5, 2, 3]
        /// </summary>
        [Symbol("([0, 1, 2, 3], [4, 5, 6, 7]) -> [4, 5, 2, 3]")]
        CB = C | B << 4,

        /// <summary>
        /// ([0, 1, 2, 3], [4, 5, 6, 7]) -> [2, 3, 6, 7]
        /// </summary>
        [Symbol("([0, 1, 2, 3], [4, 5, 6, 7]) -> [2, 3, 6, 7]")]
        BD = B | D << 4,

        /// <summary>
        /// ([0, 1, 2, 3], [4, 5, 6, 7]) -> [6, 7, 2, 3]
        /// </summary>
        [Symbol("([0, 1, 2, 3], [4, 5, 6, 7]) -> [6, 7, 2, 3]")]
        DB = D | B << 4,
    }
}