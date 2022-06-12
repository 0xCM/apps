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
        LlvmDataProvider DataProvider => Wf.LlvmDataProvider();

        LlvmDataEmitter DataEmitter => Wf.LlvmDataEmitter();

        LlvmDataCalcs DataCalcs => Service(Wf.LlvmDataCalcs);

        LlvmPaths LlvmPaths => Service(Wf.LlvmPaths);

        AppSvcOps AppSvc => Wf.AppSvc();

        public bool PllExec
        {
            [MethodImpl(Inline)]
            get => AppData.get().PllExec();
        }

        public void ImportTestLogs()
        {
            iter(new string[]
            {
                "clang",
                "llvm",
                "lldb",
                "lld",
                "mlir",
                "polly"
            }, id => DataEmitter.Emit(id, DataProvider.TestLogs(id)), PllExec);
        }

        public void Run()
        {
            var lines = DataProvider.X86RecordLines();
            LlvmPaths.Tables().Delete();
            Index<DefRelations> defRelations = sys.empty<DefRelations>();
            LineMap<Identifier> defMap = LineMap<Identifier>.Empty;
            LineMap<Identifier> classMap = LineMap<Identifier>.Empty;
            Index<RecordField> classFields = sys.empty<RecordField>();
            Index<RecordField> defFields = sys.empty<RecordField>();
            exec(PllExec,
                () => ImportToolHelp(),
                ImportTestLogs,
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

        LineMap<Identifier> EmitClasses(Index<TextLine> src)
        {
            var relations = DataCalcs.CalcClassRelations(src);
            DataEmitter.Emit(relations);
            return DataEmitter.EmitLineMap(relations.View, src, Datasets.X86Classes);
        }
          
        LineMap<Identifier> EmitDefs(Index<TextLine> src, out Index<DefRelations> defs)
        {
            defs = DataCalcs.CalcDefRelations(src);
            DataEmitter.Emit(defs);
            return DataEmitter.EmitLineMap(defs.View, src, Datasets.X86Defs);
        }

        void Emit(Index<LlvmEntity> src)
        {
            var asmids = DataProvider.DiscoverAsmIdentifiers();
            var instructions = DataProvider.Instructions(src);
            var variations = sys.empty<LlvmAsmVariation>();
            exec(PllExec,
                () => DataEmitter.Emit(asmids),
                () => DataEmitter.Emit(DataProvider.InstDefs(asmids, src)),
                () => variations = DataCalcs.CalcAsmVariations(asmids, instructions),
                () => DataEmitter.EmitChildRelations(src),
                () => DataEmitter.Emit(DataProvider.InstPatterns(asmids, src)),
                () => DataEmitter.Emit(DataProvider.AsmOpCodes(asmids, DataProvider.AsmOpCodeMap(instructions))),
                () => DataEmitter.EmitLists(src)
            );

            exec(PllExec,
                () => DataEmitter.Emit(DataCalcs.CalcAsmMnemonics(variations)),
                () => DataEmitter.Emit(variations)
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