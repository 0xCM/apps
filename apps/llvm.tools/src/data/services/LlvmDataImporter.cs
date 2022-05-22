//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;
    using static LlvmNames;

    public class LlvmDataImporter : AppService<LlvmDataImporter>
    {
        LlvmDataProvider DataProvider => Service(Wf.LlvmDataProvider);

        LlvmDataEmitter DataEmitter => Service(Wf.LlvmDataEmitter);

        LlvmDataCalcs DataCalcs => Service(Wf.LlvmDataCalcs);

        LlvmPaths LlvmPaths => Service(Wf.LlvmPaths);

        public bool PllExec
        {
            [MethodImpl(Inline)]
            get => AppData.get().PllExec();
        }

        public void Run()
        {
            var asmids = DataProvider.DiscoverAsmIdentifiers();
            var records = DataProvider.X86RecordLines();
            exec(PllExec,
                () => DataEmitter.Emit(asmids),
                () => DataEmitter.Emit(DataProvider.DiscoverRegIdentifiers()),
                () => ImportToolHelp()
            );

            var classes = DataEmitter.EmitClassRelations(records);
            var defRelations = DataEmitter.EmitDefRelations(records);
            LineMap<Identifier> defMap = LineMap<Identifier>.Empty;
            LineMap<Identifier> classMap = LineMap<Identifier>.Empty;
            exec(PllExec,
                () => classMap = DataEmitter.EmitLineMap(classes.View, records, Datasets.X86Classes),
                () => defMap = DataEmitter.EmitLineMap(defRelations.View, records, Datasets.X86Defs)
            );

            Index<RecordField> classFields = sys.empty<RecordField>();
            Index<RecordField> defFields = sys.empty<RecordField>();
            exec(PllExec,
                () => classFields = RecordFieldParser.parse(records, classMap),
                () => defFields = RecordFieldParser.parse(records, defMap)
            );

            Index<LlvmEntity> entities = sys.empty<LlvmEntity>();
            exec(PllExec,
                () => entities = DataProvider.SelectEntities(defRelations, defFields),
                () => DataEmitter.EmitClassFields(classFields),
                () => DataEmitter.EmitDefFields(defFields)
            );

            var instructions = DataProvider.Instructions(entities);
            exec(PllExec,
                () => DataEmitter.Emit(DataCalcs.CalcInstDefs(asmids, entities)),
                () => DataEmitter.Emit(DataCalcs.CalcAsmVariations(asmids, instructions)),
                () => DataEmitter.EmitChildRelations(entities),
                () => DataEmitter.Emit(DataCalcs.CalcInstPatterns(asmids, entities)),
                () => DataEmitter.Emit(DataCalcs.CalcAsmOpCodes(asmids, DataCalcs.CalcOpCodeMap(instructions))),
                () => DataEmitter.EmitLists(entities)
            );
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
   }
}