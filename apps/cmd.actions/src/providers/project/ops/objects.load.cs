//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    partial class ProjectCmdProvider
    {
        [CmdOp("objects/load")]
        Outcome LoadObjects(CmdArgs args)
        {
            var src = CoffObjects.LoadObjHex(Project());
            var files = src.Keys.Array();
            var stats = src.Stats;
            var count = files.Length;
            var formatter = Tables.formatter<HexFileStats>();
            for(var i=0; i<count; i++)
            {
                ref readonly var stat = ref skip(stats,i);
                ref readonly var file = ref stat.Path;
                var data = src[file];
                uint size = data.TotalSize();
                Write(string.Format("{0}:{1}", file, size.FormatHex()));
                var compacted = data.Compact();
                Write(string.Format("Compacted size: {0}", compacted.Count.FormatHex()));
                Write(formatter.FormatKvp(stat));
            }

            return  true;
        }
    }

}