//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static LlvmNames;
    using static core;

    public class LlvmDataImporter : AppService<LlvmDataImporter>
    {
        LlvmDataProvider DataProvider => Service(Wf.LlvmDataProvider);

        LlvmDataEmitter DataEmitter => Service(Wf.LlvmDataEmitter);

        LlvmPaths LlvmPaths => Service(Wf.LlvmPaths);

        public LlvmDataImporter()
        {
        }

        protected override void Initialized()
        {

        }

        public void Run(LlvmImportObserver observer)
        {
            run(() => observer.EtlStarted());

            var help = ImportToolHelp();
            run(() => observer.ToolHelpEmitted(help));

            var asmId = DataEmitter.EmitAsmIdentifiers();
            run(() => observer.AsmIdDefsEmitted(asmId));

            var regId = DataEmitter.EmitRegIdentifiers();
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

        public Index<ToolHelpDoc> ImportToolHelp()
        {
            var imports = LlvmPaths.ToolImports();
            var docs = DataProvider.SelectToolHelp();
            var count = docs.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var doc = ref docs[i];
                var content = doc.Content;
                var dst = imports + FS.file(doc.Tool.Format(),FS.Help);
                var emitting = EmittingFile(dst);
                using var writer = dst.Writer();
                writer.Write(content);
                EmittedFile(emitting, content.Length);
            }
            return docs;
        }

        public void Run()
        {
            var observer = new LlvmImportObserver();
            Run(observer);
        }
   }
}