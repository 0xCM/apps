//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class FileTypes
    {
        public static FileKind kind(FS.FileExt src)
        {
            var dst = FileKind.None;
            var symbols = Symbols.index<FileKind>();
            symbols.ExprKind(src.Format(), out dst);
            return dst;
        }

        public static FS.FileExt ext(FileKind src)
            => FS.ext(format(src));

        public static string name(FileKind src)
            => Symbols.index<FileKind>()[src].Name.ToLower();

        [Op]
        internal static string format(FileKind src)
            => Symbols.index<FileKind>()[src].Expr.Format();
    }

    partial class XTend
    {
        public static FS.FileExt Ext(this FileKind src)
            => FileTypes.ext(src);
    }
}