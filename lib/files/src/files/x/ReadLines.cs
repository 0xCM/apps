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
        public static Index<string> ReadLines(this FS.FilePath src)
            => src.Exists ? File.ReadAllLines(src.Name) : sys.empty<string>();

        [Op]
        public static Index<string> ReadLines(this FS.FilePath src, TextEncodingKind encoding)
            => FS.readtext(src, encoding);

        /// <summary>
        /// Reads the line-partitioned content of a text file
        /// </summary>
        /// <param name="src">The file path</param>
        [Op]
        public static ReadOnlySpan<TextLine> ReadNumberedLines(this FS.FilePath src)
            => FS.readlines(src);

        public static Index<TextLine> ReadNumberedLines(this FS.FilePath src, TextEncodingKind encoding)
            => FS.readlines(src,encoding);
    }
}