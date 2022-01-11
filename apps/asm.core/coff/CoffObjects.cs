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

        HexDataFormatter Formatter => Service(() => HexDataFormatter.create(0,32,true));

        public Outcome CollectObjHex(IProjectWs project)
        {
            var result = Outcome.Success;
            var paths = project.OutFiles(FileKind.Obj, FileKind.O).View;
            var count = paths.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var src = ref skip(paths,i);
                var srcid = text.ifempty(src.SrcId(FileKind.Obj, FileKind.O), src.FileName.WithoutExtension.Format());
                var dst = ProjectDb.ProjectData(scope(project)) + FS.file(srcid, FileKind.HexDat.Ext());
                var running = Running(string.Format("Emitting {0}", dst));
                using var writer = dst.AsciWriter();
                var data = src.ReadBytes();
                var lines = Formatter.FormatLines(data);
                iter(lines, line => writer.WriteLine(line));
                Ran(running, string.Format("coffobj:{0} -> {1}", src.ToUri(), dst.ToUri()));
            }

            return result;
        }

        static string scope(IProjectWs project)
            => string.Format("{0}.{1}", project.Name, "objhex");

        public HexFileData LoadObjHex(IProjectWs project)
        {
            var src = ProjectDb.ProjectDataFiles(project, scope(project), FileKind.HexDat.Ext());
            var count = src.Length;
            var dst = dict<FS.FilePath,Index<HexDataRow>>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref src[i];
                dst[path] = HexReader.Read(path);
            }

            return dst;
        }

        public CoffObjectData LoadObjData(IProjectWs project)
        {
            var src = project.OutFiles(FileKind.Obj, FileKind.O);
            var count = src.Length;
            var dst = dict<FS.FilePath,CoffObject>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref src[i];
                var obj = CoffObject.Empty;
                obj.SrcId = path.Ext == FS.Obj
                    ? path.SrcId(FileKind.Obj)
                    : path.SrcId(FileKind.O);
                obj.Path = path;
                obj.Data = obj.Path.ReadBytes();
                dst[path] = obj;
            }
            return dst;
        }
    }
}