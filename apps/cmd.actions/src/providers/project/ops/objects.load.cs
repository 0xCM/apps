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
            var project = Project();
            var hexSrc = CoffObjects.LoadObjHex(project);
            var objSrc = CoffObjects.LoadObjects(project);
            //var objFiles = Project().OutFiles(FS.Obj).Map(x => (x.SrcId(FileKind.Obj), x)).ToConstLookup();
            var hexFiles = hexSrc.Keys.Array();
            var stats = hexSrc.Stats;
            var count = hexFiles.Length;
            var formatter = Tables.formatter<HexFileStats>();
            for(var i=0; i<count; i++)
            {

                ref readonly var stat = ref skip(stats,i);
                ref readonly var file = ref stat.Path;

                var obj = objSrc[file];
                var objData = obj.Data;

                var data = hexSrc[file];
                uint size = data.TotalSize();
                Write(string.Format("{0}:{1}", file, size.FormatHex()));
                var compacted = data.Compact().Storage;
                var objLength = objData.Length;
                var length = min(objLength, compacted.Length);
                for(var j=0u; j<length; j++)
                {
                    ref readonly var a = ref skip(compacted,j);
                    ref readonly var b = ref objData[j];
                    MemoryAddress offset = j;
                    if(a != b)
                    {
                        Error(string.Format("{0} != {1} at {2}", a, b,offset));
                        break;
                    }
                }

                // if(compacted.Size >= (0x3e + 4))
                // {
                //     var sig = slice(compacted.View,0x3e,4);
                //     Write(string.Format("Sig:{0}", sig.FormatHex()));
                // }

                // Write(string.Format("Compacted size: {0}", compacted.Count.FormatHex()));
                // Write(formatter.FormatKvp(stat));
            }

            return  true;
        }
    }

}