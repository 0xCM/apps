//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using static core;
    using static LlvmNames;

    public class LlvmDataImporter : AppService<LlvmDataImporter>
    {
        LlvmDataProvider DataProvider => Service(Wf.LlvmDataProvider);

        LlvmDataEmitter DataEmitter => Service(Wf.LlvmDataEmitter);

        LlvmDataCalcs DataCalcs => Service(Wf.LlvmDataCalcs);

        LlvmPaths LlvmPaths => Service(Wf.LlvmPaths);

        public void Run(LlvmImportObserver observer)
        {
            run(() => observer.EtlStarted());

            var help = ImportToolHelp();
            run(() => observer.ToolHelpEmitted(help));

            var asmids = DataProvider.DiscoverAsmIdentifiers();
            DataEmitter.Emit(asmids);
            run(() => observer.AsmIdDefsEmitted(asmids));

            var regids = DataEmitter.EmitRegIdentifiers();
            run(() => observer.RegIdDefsEmitted(regids));

            var records = DataProvider.SelectX86SourceRecords();
            run(() => observer.SourceRecordsSelected(records));

            var classes = DataEmitter.EmitClassRelations(records);
            run(() => observer.ClassRelationsEmitted(classes));

            var defs = DataEmitter.EmitDefRelations(records);
            run(() => observer.DefRelationsEmitted(defs));

            var defMap = DataEmitter.EmitLineMap(defs.View, records, Datasets.X86Defs);
            run(() => observer.DefMapEmitted(defMap));

            var defFields = RecordFieldParser.parse(records, defMap);
            DataEmitter.EmitDefFields(defFields);
            run(() => observer.DefFieldsEmitted(defFields));

            var classMap = DataEmitter.EmitLineMap(classes.View, records, Datasets.X86Classes);
            run(() => observer.ClassMapEmitted(classMap));

            var classFields = RecordFieldParser.parse(records, classMap);
            DataEmitter.EmitClassFields(classFields);
            run(() => observer.ClassFieldsEmitted(classFields));

            var entities = DataProvider.SelectEntities();
            run(() => observer.EntitiesSelected(entities));

            var lists = DataEmitter.EmitLists(entities);
            run(() => observer.ListsEmitted(lists));

            var childRelations = DataEmitter.EmitChildRelations(entities);
            run(() => observer.ChildRelationsEmitted(childRelations));

            var variations = DataEmitter.EmitAsmVariations();
            run(() => observer.AsmVariationsEmitted(variations));

            var instdefs = DataProvider.SelectInstDefs(asmids, entities);
            DataEmitter.Emit(instdefs.View);
            run(() => observer.InstDefsEmitted(instdefs));

            var patterns = DataEmitter.EmitInstPatterns();
            run(() => observer.InstPatternsEmitted(patterns));

            var ocmap = DataProvider.SelectOpCodeMap();
            var opcodes = DataCalcs.CalcAsmOpCodes(asmids, ocmap);
            DataEmitter.Emit(opcodes.View);

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