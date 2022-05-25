//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public class SymHeaps : AppService<SymHeaps>
    {
        AppDb AppDb => Service(Wf.AppDb);

        AppSvcOps AppSvc => Service(Wf.AppSvc);


        [MethodImpl(Inline), Op]
        public static Span<char> expr(SymHeap src, uint index)
            => core.slice(src.Expr.Edit, src.ExprOffsets[index], src.ExprLengths[index]);

        public static asci16 id(SymHeap src)
            => string.Format("H{0:X4}x{1:X4}x{2:X6}",src.SymbolCount, src.EntryCount, src.ExprLengths.Storage.Sum());

        /// <summary>
        /// Discovers symbolic literals defined in a specified component collection
        /// </summary>
        public static Index<SymLiteralRow> symlits(Assembly[] src)
            => Symbols.literals(src);

        /// <summary>
        /// Discovers the symbolic literals for parametrically-identified symbol type
        /// </summary>
        /// <typeparam name="E">The symbol type</typeparam>
        public static Index<SymLiteralRow> symlits<E>()
            where E : unmanaged, Enum
                => Symbols.literals<E>();

        /// <summary>
        /// Computes a <see cref='SymHeap'/> for a parametrically-identified symbol type
        /// </summary>
        /// <typeparam name="E">The symbol type</typeparam>
        public static SymHeap heap<E>()
            where E : unmanaged, Enum
                => heap(symlits<E>());

        [Op]
        public static SymHeap heap(ReadOnlySpan<SymLiteralRow> src)
        {
            var dst = new SymHeap();
            var stats = SymHeaps.stats(src);
            dst.SymbolCount = stats.SymbolCount;;
            dst.EntryCount = stats.EntryCount;
            dst.ExprLengths = alloc<uint>(stats.EntryCount);
            dst.CharCount = stats.CharCount;
            dst.Expr = alloc<char>(stats.CharCount);
            dst.ExprOffsets = alloc<uint>(stats.EntryCount);
            dst.Values = alloc<SymVal>(stats.EntryCount);
            dst.Names = alloc<Identifier>(stats.EntryCount);
            dst.Sources = alloc<Identifier>(stats.EntryCount);
            var size=0u;
            var offset=0u;
            for(var i=0u; i<dst.SymbolCount; i++)
            {
                ref readonly var row = ref skip(src,i);
                var chars = row.Symbol.Data;
                var length = (uint)chars.Length;
                dst.Length(i) = length;
                dst.Value(i) = row.Value;
                dst.Name(i) = row.Name;
                dst.Offset(i) = offset;
                dst.Source(i) = row.Type;
                Demand.lteq(offset + length, stats.CharCount);
                chars.CopyTo(slice(dst.Expr.Edit, offset, length));
                offset += length;
                size += length*2;
            }

            return dst;
        }

        public static SymHeap<K,uint,ushort> create<K>()
            where K : unmanaged, Enum
        {
            var symbols = Symbols.index<K>();
            var kinds = symbols.Kinds;
            var buffer = text.buffer();
            var count = symbols.Count;
            var offsets = alloc<uint>(count);
            var lengths = alloc<ushort>(count);
            var entries = alloc<SymHeapEntry<K,uint,ushort>>(count);
            var offset = 0u;
            for(var i=0; i<symbols.Count; i++)
            {
                ref var entry = ref seek(entries,i);
                ref readonly var symbol = ref symbols[i];
                var expr = symbol.Expr.Data;
                var length = (ushort)expr.Length;
                entry = new SymHeapEntry<K,uint,ushort>(symbol.Kind, offset, length);
                buffer.Append(expr);
                offset += length;
            }

            return new SymHeap<K,uint,ushort>(entries,buffer.Emit());
        }

        [MethodImpl(Inline)]
        public static SymHeapEntry<K,A,T> entry<K,A,T>(K key, A offset, T length)
            where K : unmanaged
            where A : unmanaged
            where T : unmanaged
                => new SymHeapEntry<K,A,T>(key, offset, length);

        [MethodImpl(Inline), Op]
        public static uint charcount(ReadOnlySpan<SymLiteralRow> src)
        {
            var counter = 0u;
            var kSrc = src.Length;
            for(var i=0; i<src.Length; i++)
                counter += skip(src,i).Symbol.CharCount;
            return counter;
        }

        [Op]
        public static Index<SymHeapEntry> entries(SymHeap src)
        {
            var count = src.SymbolCount;
            var entries = alloc<SymHeapEntry>(count);
            var remains = src.CharCount*2;
            for(var i=0u; i<count; i++)
            {
                ref var entry = ref seek(entries,i);
                remains -= src.Size(i);
                entry.Key = i;
                entry.Offset = src.Offset(i)*2;
                entry.Size = src.Size(i);
                entry.Remains = remains;
                entry.Source = src.Source(i);
                entry.Name = src.Name(i);
                entry.Value = src.Value(i);
                entry.Expression = text.format(src.Symbol(i));
            }
            return entries;
        }

        public static SymHeapStats stats(ReadOnlySpan<SymLiteralRow> src)
        {
            var dst = new SymHeapStats();
            dst.SymbolCount = (uint)src.Length;
            dst.EntryCount = (uint)bits.next((Pow2x32)bits.xmsb(dst.SymbolCount));
            dst.CharCount = charcount(src);
            dst.DataSize = dst.CharCount*2;
            return dst;
        }

        /// <summary>
        /// Discovers symbolic literals defined in the api catalog
        /// </summary>
        public Index<SymLiteralRow> CalcSymLits()
            => Data(nameof(SymLiteralRow), () => Symbols.literals(ApiRuntimeCatalog.Components));

        Index<SymHeapEntry> CalcEntries(SymHeap src)
            => Data(id(src),() => SymHeaps.entries(src));

        public void EmitSymHeap(SymHeap src, FS.FilePath dst)
            => AppSvc.TableEmit(CalcEntries(src), dst);

        public void EmitSymHeap(SymHeap src)
            => AppSvc.TableEmit(CalcEntries(src), ApiTargets().Table<SymHeapEntry>(), TextEncodingKind.Unicode);

        public Index<SymLiteralRow> EmitLiterals()
            => EmitLiterals(ApiTargets().Table<SymLiteralRow>());

        public Index<SymLiteralRow> EmitLiterals(FS.FilePath dst)
            => EmitSymLits(ApiRuntimeCatalog.Components, dst);

        /// <summary>
        /// Emits the symbolic literals for parametrically-identified symbol type
        /// </summary>
        /// <typeparam name="E">The defining typ
        /// e</typeparam>
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
            var rows = SymHeaps.symlits(src);
            AppSvc.TableEmit(rows, dst, TextEncodingKind.Unicode);
            return rows;
        }

        public Index<SymLiteralRow> LoadLiterals(FS.FilePath src)
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


        public Index<SymInfo> EmitTokens(Type src)
        {
            var tokens = Symbols.syminfo(src);
            WfEmit.TableEmit(tokens, ApiTargets().Table<SymInfo>("tokens" + "." +  src.Name.ToLower()));
            return tokens;
        }

        public Index<SymInfo> LoadTokens(string name)
        {
            var src = ApiTargets().Table<SymInfo>("tokens" + "." +  name.ToLower());
            using var reader = src.TableReader<SymInfo>(SymInfo.parse);
            var header = reader.Header.Split(Chars.Pipe);
            if(header.Length != SymInfo.FieldCount)
            {
                Error(AppMsg.FieldCountMismatch.Format(SymInfo.FieldCount, header.Length));
                return Index<SymInfo>.Empty;
            }
            var dst = list<SymInfo>();
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
    }
}