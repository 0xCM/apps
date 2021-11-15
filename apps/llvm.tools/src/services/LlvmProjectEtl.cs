//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using records;

    using static LlvmNames;
    using static core;

    public class LlvmProjectEtl : AppService<LlvmProjectEtl>
    {
        LlvmPaths LlvmPaths;

        IProjectWs LlvmData;

        llvm.LlvmNm Nm;

        llvm.LlvmObjDump ObjDump;

        llvm.McSyntaxLogs McSyntaxLogs;

        protected override void Initialized()
        {
            LlvmPaths = Wf.LlvmPaths();
            LlvmData = Ws.Project(Projects.LlvmData);
            Nm = Wf.LlvmNm();
            ObjDump = Wf.LlvmObjDump();
            McSyntaxLogs = Wf.McSyntaxLogs();
        }

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

            result = CollectSyms(ws);
            if(result.Fail)
                Error(result.Message);

            result = CollectObjHex(ws);
            if(result.Fail)
                Error(result.Message);

            var syntax = McSyntaxLogs.Collect(ws);
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
                var dst = ws.OutDir(WsAtoms.objhex) + FS.file(id,FileTypes.ext(FileKind.HexDat));
                using var writer = dst.AsciWriter();
                var data = src.ReadBytes();
                var size = HexFormatter.emit(data, writer);
                Write(string.Format("({0:D5} bytes)[{1} -> {2}]", size, src.ToUri(), dst.ToUri()));
            }

            return result;
        }

        Outcome CollectSyms(IProjectWs ws)
        {
            var result = Outcome.Success;
            var src = ws.OutFiles(FS.Sym).View;
            var dst = ws.Table<ObjSymRow>(ws.Project.Format());
            var symbols = Nm.Collect(src, dst);
            return result;
        }
    }
}