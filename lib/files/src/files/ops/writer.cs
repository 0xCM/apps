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

    partial struct FS
    {
        [Op]
        public static string SearchPattern(FS.FileExt[] src)
            => string.Join(";*.", src.Select(e => e.Name));

        [MethodImpl(Inline), Op]
        public static StreamWriter writer(FS.FilePath dst, FileWriteMode mode, Encoding encoding)
            => new StreamWriter(dst.EnsureParentExists().Name.Format(), mode == FileWriteMode.Append, encoding);

        [Op]
        public static StreamWriter writer(FS.FilePath dst, TextEncodingKind encoding)
            => writer(dst, FileWriteMode.Overwrite, encoding.ToSystemEncoding());

        [Op]
        public static StreamWriter writer(FS.FilePath dst, FileWriteMode mode, TextEncodingKind encoding)
            => writer(dst, mode, encoding.ToSystemEncoding());
    }
}