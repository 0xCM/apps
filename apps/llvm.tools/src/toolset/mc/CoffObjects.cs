//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using static core;

    public class CoffObjects : AppService<CoffObjects>
    {
        public Outcome CollectObjHex(IProjectWs project)
        {
            var result = Outcome.Success;
            var paths = project.OutFiles(WfFileKind.Obj, WfFileKind.O).View;
            var count = paths.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var src = ref skip(paths,i);
                var scope = string.Format("{0}.{1}", project.Name, "objhex");
                var srcid = text.ifempty(src.SrcId(WfFileKind.Obj, WfFileKind.O), src.FileName.WithoutExtension.Format());
                var dst = ProjectDb.ProjectData(scope) + FS.file(srcid, WfFileKind.HexDat.Ext());
                var running = Running(string.Format("Emitting {0}", dst));
                using var writer = dst.AsciWriter();
                var data = src.ReadBytes();
                var size = HexFormatter.emit(data, writer);
                Ran(running, string.Format("({0:D5} bytes)[{1} -> {2}]", size, src.ToUri(), dst.ToUri()));
            }

            return result;
        }
    }
}