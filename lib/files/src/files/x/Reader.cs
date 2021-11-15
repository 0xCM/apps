//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.IO;
    using System.Text;

    using static Root;

    partial class XFs
    {
        /// <summary>
        /// Creates a reader initialized with the source file; caller-disposal required
        /// </summary>
        /// <param name="src">The file path</param>
        [Op]
        public static StreamReader Utf8Reader(this FS.FilePath src)
            => FS.reader(src, Encoding.UTF8);

        [Op]
        public static StreamReader Reader(this FS.FilePath src, TextEncodingKind encoding)
            => FS.reader(src, encoding);

        [Op]
        public static StreamReader AsciReader(this FS.FilePath src)
            => FS.reader(src, Encoding.ASCII);

        [Op]
        public static StreamReader UnicodeReader(this FS.FilePath src)
            => FS.reader(src, Encoding.Unicode);

        [Op]
        public static AsciLineReader AsciLineReader(this FS.FilePath src)
            => new AsciLineReader(src.AsciReader());

        [Op]
        public static AsciLineReader<byte> AsciLineReader2(this FS.FilePath src)
            => new AsciLineReader<byte>(src.AsciReader());

        [Op]
        public static AsciLineReader<T> AsciLineReader2<T>(this FS.FilePath src)
            where T : unmanaged
                => new AsciLineReader<T>(src.AsciReader());

        [Op]
        public static LineReader Utf8LineReader(this FS.FilePath src)
            => new LineReader(src.Utf8Reader());

        [Op]
        public static UnicodeLineReader UnicodeLineReader(this FS.FilePath src)
            => new UnicodeLineReader(src.UnicodeReader());

        [MethodImpl(Inline), Op]
        public static LineReader ToLineReader(this StreamReader src)
            => new LineReader(src);

        [Op]
        public static LineReader LineReader(this FS.FilePath src, TextEncodingKind encoding)
            => src.Reader(encoding).ToLineReader();
    }
}