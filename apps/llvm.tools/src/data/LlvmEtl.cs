//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static LlvmNames;
    using static core;

    public class LlvmEtl : AppService<LlvmEtl>
    {
        LlvmPaths LlvmPaths;

        LlvmDataProvider DataProvider;

        LlvmDataEmitter DataEmitter;

        public LlvmEtl()
        {
        }

        protected override void Initialized()
        {
            LlvmPaths = Wf.LlvmPaths();
            DataProvider = Wf.LlvmDataProvider();
            DataEmitter = Wf.LlvmDataEmitter();
        }

        public void Run(LlvmEtlObserver observer)
        {
            run(() => observer.EtlStarted());

            var help = DataEmitter.EmitToolHelp();
            run(() => observer.ToolHelpEmitted(help));

            var asmId = DataEmitter.EmitAsmIdDefs();
            run(() => observer.AsmIdDefsEmitted(asmId));

            var regId = DataEmitter.EmitRegIdDefs();
            run(() => observer.RegIdDefsEmitted(regId));

            var records = DataProvider.SelectSourceRecords(Datasets.X86);
            run(() => observer.SourceRecordsSelected(records));

            var classes = DataEmitter.EmitClassRelations(records);
            run(() => observer.ClassRelationsEmitted(classes));

            var defs = DataEmitter.EmitDefRelations(records);
            run(() => observer.DefRelationsEmitted(defs));

            var defMap = DataEmitter.EmitLineMap(defs.View, records, Datasets.X86Defs);
            run(() => observer.DefMapEmitted(defMap));

            var defFields = RecordFieldParser.parse(records, defMap);
            DataEmitter.EmitFields(defFields, Datasets.X86DefFields);
            run(() => observer.DefFieldsEmitted(defFields));

            var classMap = DataEmitter.EmitLineMap(classes.View, records, Datasets.X86Classes);
            run(() => observer.ClassMapEmitted(classMap));

            var classFields = RecordFieldParser.parse(records, classMap);
            DataEmitter.EmitFields(classFields, Datasets.X86ClassFields);
            run(() => observer.ClassFieldsEmitted(classFields));

            var entities = DataProvider.SelectEntities();
            run(() => observer.EntitiesSelected(entities));

            var lists = DataEmitter.EmitLists(entities);
            run(() => observer.ListsEmitted(lists));

            var childRelations = DataEmitter.EmitChildRelations();
            run(() => observer.ChildRelationsEmitted(childRelations));

            var variations = DataEmitter.EmitAsmVariations();
            run(() => observer.AsmVariationsEmitted(variations));

            var instdefs = DataEmitter.EmitInstDefs();
            run(() => observer.InstDefsEmitted(instdefs));

            var instpattterns = DataEmitter.EmitInstPatterns();
            run(() => observer.InstPatternsEmitted(instpattterns));

            run(() => observer.EtlCompleted());
        }
        public void Run()
        {
            var observer = new LlvmEtlObserver();
            Run(observer);
        }
   }
}