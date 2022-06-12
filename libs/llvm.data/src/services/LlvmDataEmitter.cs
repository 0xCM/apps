//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    public class LlvmDataEmitter : WfSvc<LlvmDataEmitter>
    {
        LlvmPaths LlvmPaths => Service(Wf.LlvmPaths);

        LlvmDataProvider DataProvider => Service(Wf.LlvmDataProvider);

        LlvmDataCalcs DataCalcs => Service(Wf.LlvmDataCalcs);

        AppSvcOps AppSvc => Service(Wf.AppSvc);

        public LlvmQuery Query => Service(() => LlvmQuery.create(Wf));

        public void Emit(Index<ClassRelations> src)
            => TableEmit(src, LlvmPaths.Table<ClassRelations>());

        public void Emit(Index<DefRelations> src)
            => TableEmit(src, LlvmPaths.Table<DefRelations>());

        public void Emit(string id, Index<LlvmTestLogEntry> src)
            => TableEmit(src, LlvmPaths.LogTargets().Table<LlvmTestLogEntry>("llvm.tests.logs." + id + ".detail"));

        public void Emit(ReadOnlySpan<LlvmInstDef> src)
            => TableEmit(src, LlvmPaths.Table<LlvmInstDef>());

        public void Emit(ReadOnlySpan<AsmMnemonicRow> src)
            => TableEmit(src, LlvmPaths.Table("llvm.asm.mnemonics"));

        public void Emit(ReadOnlySpan<LlvmAsmInstPattern> src)
            => TableEmit(src, LlvmPaths.Table<LlvmAsmInstPattern>());

        public void Emit(ReadOnlySpan<LlvmAsmVariation> src)
            => AppSvc.TableEmit(src, LlvmPaths.Table<LlvmAsmVariation>());

        public FS.FilePath EmitList(LlvmList src)
        {
            var dst = LlvmPaths.ListImportPath(src.Name);
            EmitList(src,dst);
            return dst;
        }

        public void EmitList(LlvmList src, FS.FilePath dst)
            => TableEmit(src.Items, dst);

        public void Emit(RegIdentifiers src)
        {
            var dst = LlvmPaths.Table(RegIdentifier.TableId);
            var list = new LlvmList(dst, src.Values.Select(x => new LlvmListItem(x.Id, x.Name.Format())));
            EmitList(list, dst);
        }

        public void Emit(AsmIdentifiers src)
        {
            var items = src.Values.Select(x => new LlvmListItem(x.Id, x.Name.Format()));
            var dst = LlvmPaths.Table(AsmIdentifier.TableId);
            EmitList(new LlvmList(dst, items), dst);
        }

        public void Emit(ReadOnlySpan<LlvmAsmOpCode> src)
            => TableEmit(src, LlvmPaths.Table<LlvmAsmOpCode>());

        public Index<LlvmList> EmitLists(Index<LlvmEntity> entities)
        {
            FS.Files paths = LlvmPaths.ListNames().Map(x => LlvmPaths.ListImportPath(x));
            paths.Delete();
            return EmitLists(entities, DataProvider.ConfiguredListNames());
        }

        Index<LlvmList> EmitLists(Index<LlvmEntity> src, ReadOnlySpan<string> classes)
        {
            var lists = DataCalcs.CalcLists(src, classes);
            iter(lists, c => EmitList(c), true);
            return lists;
        }

        public void EmitChildRelations(ReadOnlySpan<LlvmEntity> src)
            => TableEmit(DataCalcs.CalcChildRelations(src), LlvmPaths.Table<ChildRelation>());

        public Index<RecordField> EmitDefFields(Index<RecordField> src)
            => EmitFields(src, LlvmNames.Datasets.X86DefFields);

        public Index<RecordField> EmitClassFields(Index<RecordField> src)
            => EmitFields(src, LlvmNames.Datasets.X86ClassFields);

        Index<RecordField> EmitFields(Index<RecordField> src, string id)
        {
            TableEmit<RecordField>(src, RecordField.RenderWidths, LlvmPaths.Table(id));
            return src;
        }


        public LineMap<Identifier> EmitLineMap<T>(ReadOnlySpan<T> src, ReadOnlySpan<TextLine> records, string dstid)
            where T : struct, ILineRelations<T>
        {
            const uint BufferLength = 256;
            var result = Outcome.Success;
            var linecount = records.Length;
            var count = src.Length;
            var buffer = span<TextLine>(BufferLength);
            var intervals = list<LineInterval<Identifier>>();
            for(var i=0;i<count; i++)
            {
                ref readonly var relation = ref skip(src,i);
                var k=0;
                buffer.Clear();
                var index = relation.SourceLine.Value;
                for(var j=index; j<linecount && k<BufferLength; j++)
                {
                    ref readonly var line = ref skip(records,j);
                    ref readonly var content = ref line.Content;
                    if(SQ.index(content, Chars.RBrace) != 0)
                        seek(buffer,k++) = line;
                    else
                        break;
                }

                if(k>0)
                {
                    ref readonly var l0 = ref first(buffer);
                    ref readonly var l1 = ref skip(buffer,k-1);
                    intervals.Add(Lines.interval(relation.Name, l0.LineNumber, l1.LineNumber));
                }
            }

            var map = Lines.map(intervals.ToArray());
            var dst = LlvmPaths.ImportMap(dstid);
            var emitting = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            var _intervals = map.Intervals;
            for(var i=0; i<_intervals.Length; i++)
                writer.WriteLine(skip(_intervals,i).Format());
            EmittedFile(emitting, _intervals.Length);
            return map;
        }
    }
}