//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Classifies hex number specifiers
    /// </summary>
    public enum HexSpecKind : byte
    {
        /// <summary>
        /// Indicates the absence of a specifier
        /// </summary>
        None = 0,

        /// <summary>
        /// Indicates the character 'h" that may follow a sequence of hex digits
        /// </summary>
        PostSpec = 1,

        /// <summary>
        /// Indicates the 2-character sequence '0x' that may precede a sequence of hex digits
        /// </summary>
        PreSpec = 2,
    }
}