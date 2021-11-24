//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Collections.Generic;

    using static LlvmNames;
    using static core;

    public partial class LlvmRecordEtl : AppService<LlvmRecordEtl>
    {
        LlvmPaths LlvmPaths;

        OmniScript OmniScript;

        llvm.LlvmNm Nm;

        llvm.LlvmObjDump ObjDump;

        llvm.McSyntaxLogs McSyntaxLogs;

        HashSet<string> ClassExclusions {get;}
            = hashset<string>("Hexagon", "Neon", "PowerPC", "RISCV", "SystemZ", "Hexagom", "AMDGPU");

        public LlvmRecordEtl()
        {
        }

        protected override void Initialized()
        {
            LlvmPaths = Wf.LlvmPaths();
            OmniScript = Wf.OmniScript();
            Nm = Wf.LlvmNm();
            ObjDump = Wf.LlvmObjDump();
            McSyntaxLogs = Wf.McSyntaxLogs();
        }

        public EtlDatasets Run()
        {
            var dst = new EtlDatasets();
            var records = LoadSourceRecords(Datasets.X86);
            dst.Records = records;
            EmitLinedRecords(records, Datasets.X86Lined);
            var classes = EmitClassRelations(records);
            dst.ClassRelations = classes;
            var defs = EmitDefRelations(records);
            dst.DefRelations = defs;
            var defMap = EmitLineMap(defs, records, Datasets.X86Defs);
            dst.DefMap = defMap;
            var defFields = LoadFields(records, defMap);
            dst.Defs = defFields;
            EmitFields(defFields, Datasets.X86DefFields);
            var classMap = EmitLineMap(classes, records, Datasets.X86Classes);
            dst.ClassMap = classMap;
            var classFields = LoadFields(records, classMap);
            dst.Classes = classFields;
            EmitFields(classFields, Datasets.X86ClassFields);
            Wf.LlvmEtlCodeGen().Run();
            return dst;
        }

        void GenDocs(in EtlDatasets src)
        {
            var dst = LlvmPaths.Docs("instructions");
            dst.Clear();
            var running = Running(string.Format("Emitting instruction docs to {0}", dst));
            var docgen = LlvmDocGen.create(Wf,src);
            var count = docgen.GenInsructionDocs(dst);
            Ran(running, string.Format("Emitted docs for {0} instructions", count));
        }

        public void CollectProjectData()
        {
            iter(Projects.ProjectNames, name => ProjectCollect(Ws.Project(name)));
        }

        Outcome ProjectCollect(IProjectWs ws)
        {
            var result = Outcome.Success;
            result = ObjDump.Consolidate(ws);
            if(result.Fail)
                return result;

            result = CollectSyms(ws);
            if(result.Fail)
                return result;

            result = CollectObjHex(ws);
            if(result.Fail)
                return result;

            var syntax = McSyntaxLogs.Collect(ws);

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