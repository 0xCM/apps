//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class FileTypes
    {
        public static FS.FileExt ext(FileKind src)
            => FS.ext(format(src));

        public static string name(FileKind src)
            => Symbols.index<FileKind>()[src].Name.Format().ToLower();

        [Op]
        public static string format(FileKind src)
            => Symbols.index<FileKind>()[src].Expr.Format();
    }

    partial class XTend
    {
        public static FS.FileExt Ext(this FileKind src)
            => FileTypes.ext(src);

        public static string Name(this FileKind src)
            => FileTypes.name(src);
    }
}