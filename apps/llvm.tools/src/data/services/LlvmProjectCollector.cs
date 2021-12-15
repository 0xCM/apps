//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static LlvmNames;
    using static core;

    public class LlvmProjectCollector : AppService<LlvmProjectCollector>
    {
        llvm.LlvmNm Nm => Service(Wf.LlvmNm);

        llvm.LlvmObjDump ObjDump => Service(Wf.LlvmObjDump);

        llvm.LlvmMc Mc => Service(Wf.LlvmMc);

        public void Collect()
        {
            iter(Projects.ProjectNames, name => Collect(Ws.Project(name)));
        }

        public void Collect(IProjectWs ws)
        {
            var result = Outcome.Success;
            result = ObjDump.Consolidate(ws);
            if(result.Fail)
                Error(result.Message);

            result = Nm.Collect(ws);
            if(result.Fail)
                Error(result.Message);

            result = CollectObjHex(ws);
            if(result.Fail)
                Error(result.Message);

            Mc.Collect(ws);
        }

        public FS.Files XedDisasmFiles(IProjectWs ws)
            => ws.OutFiles(FS.ext("xed.txt"));

        Outcome CollectXedDisam(IProjectWs ws)
        {
            var result = Outcome.Success;
            var ext = FS.ext("xed.txt");
            var paths = ws.OutFiles(FS.ext("xed.txt"));
            var count = paths.Length;
            var xed = Wf.IntelXed();
            for(var i=0; i<count; i++)
            {
                ref readonly var src = ref paths[i];
                var blocks = xed.ParseDisasmBlocks(src);
                var id = text.remove(src.FileName.Format(), ".xed.txt");
            }

            return result;
        }

        Outcome CollectObjHex(IProjectWs ws)
        {
            var result = Outcome.Success;
            var paths = ws.OutFiles(FileKind.Obj, FileKind.O).View;
            var count = paths.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var src = ref skip(paths,i);
                var id = src.FileName.WithoutExtension.Format();
                //var dst = ws.OutDir(WsAtoms.objhex) + FS.file(id,FileTypes.ext(FileKind.HexDat));
                var dst = ProjectDb.Subdir("projects/" + ws.Project.Format() + ".objhex") + FS.file(id,FileTypes.ext(FileKind.HexDat));
                using var writer = dst.AsciWriter();
                var data = src.ReadBytes();
                var size = HexFormatter.emit(data, writer);
                Write(string.Format("({0:D5} bytes)[{1} -> {2}]", size, src.ToUri(), dst.ToUri()));
            }

            return result;
        }
    }
}