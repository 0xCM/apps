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

        public static FS.FileExt ext(WfFileKind src)
            => FS.ext(format(src));

        public static string name(WfFileKind src)
            => Symbols.index<WfFileKind>()[src].Name.ToLower();

        [Op]
        public static string format(WfFileKind src)
            => Symbols.index<WfFileKind>()[src].Expr.Format();
    }

    partial class XTend
    {
        public static FS.FileExt Ext(this WfFileKind src)
            => FileTypes.ext(src);

        public static FileType<WfFileKind> FileType(this WfFileKind src)
            => FileTypes.define(src, FileTypes.ext(src));

        public static string Name(this WfFileKind src)
            => FileTypes.name(src);
    }
}