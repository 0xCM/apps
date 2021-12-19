//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class FileTypes
    {
        public static FileType define(string name, params FS.FileExt[] ext)
            => new FileType(name, ext);

        public static FileType<K> define<K>(K kind, params FS.FileExt[] ext)
            where K : unmanaged
                => new FileType<K>(kind, ext);

        public static FS.FileExt ext(FileKind src)
            => FS.ext(format(src));

        public static string name(FileKind src)
            => Symbols.index<FileKind>()[src].Name.ToLower();

        [Op]
        public static string format(FileKind src)
            => Symbols.index<FileKind>()[src].Expr.Format();
    }

    partial class XTend
    {
        public static FS.FileExt Ext(this FileKind src)
            => FileTypes.ext(src);

        public static FileType<FileKind> FileType(this FileKind src)
            => FileTypes.define(src, FileTypes.ext(src));

        public static string Name(this FileKind src)
            => FileTypes.name(src);
    }
}