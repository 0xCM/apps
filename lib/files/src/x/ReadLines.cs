//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.IO;

    partial class XFs
    {
        /// <summary>
        /// Reads the line-partitioned content of a text file
        /// </summary>
        /// <param name="src">The file path</param>
        public static Index<string> ReadLines(this FS.FilePath src, bool skipBlank = false)
            => FS.readtext(src, TextEncodingKind.Utf8, skipBlank);

        [Op]
        public static Index<string> ReadLines(this FS.FilePath src, TextEncodingKind encoding, bool skipBlank = false)
            => FS.readtext(src, encoding, skipBlank);

        /// <summary>
        /// Reads the line-partitioned content of a text file
        /// </summary>
        /// <param name="src">The file path</param>
        [Op]
        public static Index<TextLine> ReadNumberedLines(this FS.FilePath src, bool skipBlank = false)
            => FS.readlines(src, skipBlank);

        public static Index<TextLine> ReadNumberedLines(this FS.FilePath src, TextEncodingKind encoding, bool skipBlank = false)
            => FS.readlines(src,encoding, skipBlank);
    }
}