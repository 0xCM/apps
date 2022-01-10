//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static core;

    public class CoffObjects : AppService<CoffObjects>
    {
        HexDataReader HexReader => Service(Wf.HexDataReader);

        public Outcome CollectObjHex(IProjectWs project)
        {
            var result = Outcome.Success;
            var paths = project.OutFiles(WfFileKind.Obj, WfFileKind.O).View;
            var count = paths.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var src = ref skip(paths,i);
                var srcid = text.ifempty(src.SrcId(WfFileKind.Obj, WfFileKind.O), src.FileName.WithoutExtension.Format());
                var dst = ProjectDb.ProjectData(scope(project)) + FS.file(srcid, WfFileKind.HexDat.Ext());
                var running = Running(string.Format("Emitting {0}", dst));
                using var writer = dst.AsciWriter();
                var data = src.ReadBytes();
                var size = HexFormatter.emit(data, writer);
                Ran(running, string.Format("({0:D5} bytes)[{1} -> {2}]", size, src.ToUri(), dst.ToUri()));
            }

            return result;
        }

        static string scope(IProjectWs project)
            => string.Format("{0}.{1}", project.Name, "objhex");

        public HexFileData LoadObjHex(IProjectWs project)
        {
            var src = ProjectDb.ProjectDataFiles(project, scope(project), WfFileKind.HexDat.Ext());
            var count = src.Length;
            var stats = HexReader.Stats(src);
            var dst = new HexFileData(stats);
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref src[i];
                dst[path] = HexReader.Read(path);
            }

            return dst;
        }
    }
}