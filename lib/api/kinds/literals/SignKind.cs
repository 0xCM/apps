//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Classifies the sign aspect of an integral value
    /// </summary>
    [SymSource("api.kinds")]
    public enum SignKind : sbyte
    {
        /// <summary>
        /// Indicates a value is greater than or equal to zero
        /// </summary>
        Unsigned = 0,

        /// <summary>
        /// Indicates a value is less than zero
        /// </summary>
        Signed = -1
    }
}