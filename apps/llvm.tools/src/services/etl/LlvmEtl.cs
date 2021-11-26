//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static LlvmNames;

    public partial class LlvmEtl : AppService<LlvmEtl>
    {
        LlvmPaths LlvmPaths;

        OmniScript OmniScript;

        llvm.LlvmNm Nm;

        llvm.LlvmObjDump ObjDump;

        llvm.LlvmMc McSyntaxLogs;

        public LlvmEtl()
        {
        }

        protected override void Initialized()
        {
            LlvmPaths = Wf.LlvmPaths();
            OmniScript = Wf.OmniScript();
            Nm = Wf.LlvmNm();
            ObjDump = Wf.LlvmObjDump();
            McSyntaxLogs = Wf.LlvmMc();
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
            return dst;
        }

        public void GenDocs(in EtlDatasets src)
        {
            var dst = LlvmPaths.Docs("instructions");
            dst.Clear();
            var running = Running(string.Format("Emitting instruction docs to {0}", dst));
            var docgen = LlvmDocGen.create(Wf,src);
            var count = docgen.GenInsructionDocs(dst);
            Ran(running, string.Format("Emitted docs for {0} instructions", count));
        }
   }
}