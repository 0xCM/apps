//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
[assembly: PartId(PartId.AsmCore)]
namespace Z0.Parts
{
    public sealed partial class AsmCore : Part<AsmCore>
    {

    }
}

namespace Z0
{
    using static Root;
    using static core;

    public static partial class XTend
    {
        public static string SrcId(this FS.FilePath src, params WfFileKind[] kinds)
            => src.FileName.SrcId(kinds);

        public static string SrcId(this ObjDumpRow row)
            => FS.path(row.Source.WithoutLine.Format()).SrcId(WfFileKind.ObjAsm);

        public static string SrcId(this FS.FileName src, params WfFileKind[] kinds)
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