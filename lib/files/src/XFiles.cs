//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    using static core;

    public static class XFiles
    {
        public static FS.FileExt Ext(this FileKind src)
            => FileTypes.ext(src);

        public static FileKind FileKind(this FS.FileExt src)
            => FileTypes.kind(src);

        public static FileKind FileKind(this FS.FileName src)
            => FileTypes.kind(src.Ext);

        public static FileKind FileKind(this FS.FilePath src)
            => FileTypes.kind(src.FileName.Ext);

        public static string SrcId(this FS.FilePath src, params FileKind[] kinds)
            => src.FileName.SrcId(kinds);

        public static string SrcId(this FS.FileName src, params FileKind[] kinds)
        {
            var file = src.Format();
            var count = kinds.Length;
            var id = EmptyString;
            for(var i=0; i<count; i++)
            {
                ref readonly var kind = ref skip(kinds,i);
                var ext = kind.Ext();
                var j = text.index(file, "." + ext);
                if(j >0)
                {
                    id = text.left(file,j);
                    break;
                }
            }
            return id;
        }
    }
}