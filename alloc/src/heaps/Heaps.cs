//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [Free, ApiHost]
    public partial class Heaps : AppService<Heaps>
    {
        const NumericKind Closure = UnsignedInts;

        AppDb AppDb => Service(Wf.AppDb);

        AppSvcOps AppSvc => Service(Wf.AppSvc);

        static int SegCount;

        public static Index<SymKindRow> symkinds<K>()
            where K : unmanaged, Enum
        {
            var src = Symbols.index<K>();
            var count = src.Count;
            var dst = alloc<SymKindRow>(count);
            symkinds(src, dst);
            return dst;
        }

        public static uint symkinds<K>(in Symbols<K> src, Span<SymKindRow> dst)
            where K : unmanaged
        {
            var symbols = src.View;
            var count = (uint)min(symbols.Length, dst.Length);
            var type = typeof(K).Name;
            for(var i=0; i<count; i++)
            {
                ref var target = ref seek(dst,i);
                ref readonly var symbol = ref skip(symbols,i);
                target.Index = symbol.Key;
                target.Value = bw64(symbol.Kind);
                target.Type = type;
                target.Name = symbol.Name;
            }
            return count;
        }

        public Index<SymLiteralRow> CalcSymLits()
            => Data(nameof(SymLiteralRow), () => Symbols.literals(ApiRuntimeCatalog.Components));

        Index<SymHeapEntry> CalcEntries(SymHeap src)
            => Data(Heaps.id(src),() => Heaps.entries(src));

        public void Emit(SymHeap src, FS.FilePath dst)
            => AppSvc.TableEmit(CalcEntries(src), dst);

        public void Emit(SymHeap src)
            => AppSvc.TableEmit(CalcEntries(src), ApiTargets().Table<SymHeapEntry>(), TextEncodingKind.Unicode);

        public Index<SymLiteralRow> EmitSymLits()
            => EmitSymLits(ApiTargets().Table<SymLiteralRow>());

        public Index<SymLiteralRow> EmitSymLits(FS.FilePath dst)
            => EmitSymLits(ApiRuntimeCatalog.Components, dst);

        public Index<SymLiteralRow> EmitSymLits<E>()
            where E : unmanaged, Enum
                => EmitSymLits<E>(ApiTargets().Table<SymLiteralRow>(typeof(E).FullName));

        public Index<SymLiteralRow> EmitSymLits<E>(FS.FilePath dst)
            where E : unmanaged, Enum
        {
            var flow = EmittingTable<SymLiteralRow>(dst);
            var rows = Symbols.literals<E>();
            var count = rows.Length;
            var formatter = Tables.formatter<SymLiteralRow>();
            using var writer = dst.Writer(TextEncodingKind.Unicode);
            writer.WriteLine(formatter.FormatHeader());
            for(var i=0; i<count; i++)
                writer.WriteLine(formatter.Format(rows[i]));
            EmittedTable<SymLiteralRow>(flow, count);
            return rows;
        }

        public Index<SymLiteralRow> EmitSymLits(Assembly[] src, FS.FilePath dst)
        {
            var rows = Heaps.symlits(src);
            AppSvc.TableEmit(rows, dst, TextEncodingKind.Unicode);
            return rows;
        }

        public Index<SymLiteralRow> LoadSymLits(FS.FilePath src)
        {
            using var reader = src.TableReader<SymLiteralRow>(SymLiteralRow.parse);
            var header = reader.Header.Split(Chars.Tab);
            if(header.Length != SymLiteralRow.FieldCount)
            {
                Error(AppMsg.FieldCountMismatch.Format(SymLiteralRow.FieldCount, header.Length));
                return Index<SymLiteralRow>.Empty;
            }

            var dst = list<SymLiteralRow>();
            while(!reader.Complete)
            {
                var outcome = reader.ReadRow(out var row);
                if(!outcome)
                {
                    Error(outcome.Message);
                    break;
                }
                dst.Add(row);
            }

            return dst.ToArray();
        }

        DbTargets ApiTargets()
            => AppDb.Targets("api");
   }
}