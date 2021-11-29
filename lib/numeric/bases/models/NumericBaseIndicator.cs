//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines common numeric base indicators that prefix or suffix a numeric literal
    /// to designate the literal's numeric base
    /// </summary>
    public enum NumericBaseIndicator : ushort
    {
        None = 0,

        /// <summary>
        /// Identifies base 2, binary
        /// </summary>
        Base2 = 'b',

        /// <summary>
        /// Identifies base 3, ternary
        /// </summary>
        Base3 = 't',

        /// <summary>
        /// Identifies base 3, quaternary
        /// </summary>
        Base4 = 'q',

        /// <summary>
        /// Identifies base 8, octal
        /// </summary>
        Base8 = 'o',

        /// <summary>
        /// Identifies base 10, decimal
        /// </summary>
        Base10 = 'd',

        /// <summary>
        /// Identifies base 16, hex
        /// </summary>
        Base16 = 'h',
    }
}