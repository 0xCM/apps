//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Defines a common set of hex formatting options
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HexFormatOptions
    {
        /// <summary>
        /// Indicates whether the numeric content should be left-padded with zeros
        /// </summary>
        public bool ZeroPad;

        /// <summary>
        /// Indicates whether a hex specifier, either prefixing or suffixing the numeric content, should be emitted
        /// </summary>
        public bool Specifier;

        /// <summary>
        /// Indicates whether the hex digits 'A',..,'F' should be upper-cased
        /// </summary>
        public bool Uppercase;

        /// <summary>
        /// Indicates whether the hex numeric specifier, if emitted, prefix the output
        /// </summary>
        public bool PreSpec;

        /// <summary>
        /// The case format character, either 'X' or 'x'
        /// </summary>
        public char CaseIndicator;

        /// <summary>
        /// Specifies whether segments should be delimited
        /// </summary>
        public bool DelimitSegs;

        /// <summary>
        /// Sepcifies the segment delimiter, if applicable
        /// </summary>
        public char SegDelimiter;

        /// <summary>
        /// Specifies blocks, comprised of segments, should be delimited
        /// </summary>
        public bool DelimitBlocks;

        /// <summary>
        /// The block delimiter, if applicable
        /// </summary>
        public char BlockDelimiter;

        /// <summary>
        /// The width of a block, if applicable
        /// </summary>
        public ushort BlockWidth;

        /// <summary>
        /// The value delimiter
        /// </summary>
        public char ValueDelimiter;
    }
}