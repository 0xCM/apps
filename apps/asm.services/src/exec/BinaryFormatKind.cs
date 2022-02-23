//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Classifies binary content at rest
    /// </summary>
    public enum BinaryFormatKind : byte
    {
        None,

        /// <summary>
        /// Identifies raw binary data
        /// </summary>
        Raw,

        /// <summary>
        /// Specifies content consisting of one or more lines of delimited hex bytes
        /// </summary>
        Text,

        Csv,

        /// <summary>
        /// Specifies content consisting of one or more lines of delimited hex bytes, where each line begins with an offset
        /// </summary>
        Located,

        AsmHex,

        /// <summary>
        /// Specifies content that conforms to a <see cref='ApiHexRow'/> sequence
        /// </summary>
        ApiHexRows,

        HexPack,
    }
}