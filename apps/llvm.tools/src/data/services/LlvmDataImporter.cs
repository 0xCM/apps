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
            var lines = DataProvider.X86RecordLines();
            Index<DefRelations> defRelations = sys.empty<DefRelations>();
            LineMap<Identifier> defMap = LineMap<Identifier>.Empty;
            LineMap<Identifier> classMap = LineMap<Identifier>.Empty;
            Index<RecordField> classFields = sys.empty<RecordField>();
            Index<RecordField> defFields = sys.empty<RecordField>();
            exec(PllExec,
                () => ImportToolHelp(),
                () => DataEmitter.Emit(DataProvider.DiscoverRegIdentifiers()),
                () => classMap = EmitClasses(lines),
                () => defMap = EmitDefs(lines, out defRelations)
            );

            exec(PllExec,
                () => classFields = DataEmitter.EmitClassFields(RecordFieldParser.parse(lines, classMap)),
                () => defFields = DataEmitter.EmitDefFields(RecordFieldParser.parse(lines, defMap))
            );

            Emit(DataProvider.Entities(defRelations, defFields));
        }

        LineMap<Identifier> EmitClasses(Index<TextLine> lines)
        {
            var classes = DataEmitter.EmitClassRelations(lines);
            return DataEmitter.EmitLineMap(classes.View, lines, Datasets.X86Classes);
        }

        LineMap<Identifier> EmitDefs(Index<TextLine> lines, out Index<DefRelations> defs)
        {
            defs = DataEmitter.EmitDefRelations(lines);
            return DataEmitter.EmitLineMap(defs.View, lines, Datasets.X86Defs);
        }

        void Emit(Index<LlvmEntity> entities)
        {
            var asmids = DataProvider.DiscoverAsmIdentifiers();
            var instructions = DataProvider.Instructions(entities);
            exec(PllExec,
                () => DataEmitter.Emit(asmids),
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