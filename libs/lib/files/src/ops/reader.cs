//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;
    using System.Text;
    partial struct FS
    {
        [Op]
        public static StreamReader reader(FS.FilePath src, Encoding encoding)
            => new StreamReader(src.Name.Format(), encoding);

        /// <summary>
        /// Creates a reader initialized with the source file; caller-disposal required
        /// </summary>
        /// <param name="src">The file path</param>
        [Op]
        public static StreamReader reader(FS.FilePath src, TextEncodingKind encoding)
            => reader(src, encoding.ToSystemEncoding());
    }
}