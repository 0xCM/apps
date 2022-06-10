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

        static string format(FileKind src)
            => Symbols.index<FileKind>()[src].Expr.Format();
    }

    partial class XTend
    {
        public static FS.FileExt Ext(this FileKind src)
            => FileTypes.ext(src);

        public static FileKind FileKind(this FS.FileExt src)
            => FileTypes.kind(src);

        public static FileKind FileKind(this FS.FileName src)
            => FileTypes.kind(src.Ext);

        public static FileKind FileKind(this FS.FilePath src)
            => FileTypes.kind(src.FileName.Ext);
    }
}