//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public sealed class Symbolism : AppService<Symbolism>
    {
        AppDb AppDb => Service(Wf.AppDb);

        AppServices AppSvc => Service(Wf.AppServices);

        DbTargets SymTargets()
            => AppDb.Targets("api/symbols");

        public Index<ClrEnumRecord> EmitEnums(Assembly src, FS.FilePath dst)
        {
            var records = Enums.records(src);
            if(records.Length != 0)
                TableEmit(@readonly(records), dst);
            return records;
        }

        public SymHeap EmitSymHeap()
            => EmitSymHeap(Symbols.literals(ApiRuntimeCatalog.Components));

        public SymHeap EmitSymHeap(string name, params Type[] src)
        {
            var heap = SymHeaps.create(Symbols.literals(src));
            AppSvc.TableEmit(SymHeaps.entries(heap), SymTargets().Table<SymHeapEntry>(name));
            return heap;
        }

        public SymHeap EmitSymHeap<E>(FS.FilePath dst)
            where E : unmanaged, Enum
                => EmitHeap(Symbols.literals<E>(), dst);

        public SymHeap EmitSymHeap(ReadOnlySpan<SymLiteralRow> src)
            => EmitHeap(src, SymTargets().Table<SymHeapEntry>());

        public SymHeap EmitHeap(ReadOnlySpan<SymLiteralRow> src, FS.FilePath dst)
        {
            var heap = SymHeaps.create(src);
            AppSvc.TableEmit(SymHeaps.entries(heap), dst);
            return heap;
        }

        public void EmitHeap(string name, SymHeap src)
            => AppSvc.TableEmit(SymHeaps.entries(src), SymTargets().Table<SymHeapEntry>(name));

        public ReadOnlySpan<SymLiteralRow> EmitLiterals()
            => EmitLiterals(SymTargets().Table<SymLiteralRow>());

        public Index<SymLiteralRow> EmitLiterals(FS.FilePath dst)
            => EmitLiterals(ApiRuntimeCatalog.Components, dst);

        /// <summary>
        /// Discovers symbolic literals defined in a specified component collection
        /// </summary>
        public Index<SymLiteralRow> DiscoverLiterals(Assembly[] src)
            => Symbols.literals(src);

        /// <summary>
        /// Discovers all symbolic literals everywhere
        /// </summary>
        public Index<SymLiteralRow> DiscoverLiterals()
            => Symbols.literals(ApiRuntimeCatalog.Components);

        /// <summary>
        /// Discovers the symbolic literals for parametrically-identified symbol type
        /// </summary>
        /// <typeparam name="E">The defining type</typeparam>
        public Index<SymLiteralRow> DiscoverLiterals<E>()
            where E : unmanaged, Enum
                => Symbols.literals<E>();

        /// <summary>
        /// Emits the symbolic literals for parametrically-identified symbol type
        /// </summary>
        /// <typeparam name="E">The defining typ
        /// e</typeparam>
        public Index<SymLiteralRow> EmitLiterals<E>()
            where E : unmanaged, Enum
                => EmitLiterals<E>(SymTargets().Table<SymLiteralRow>(typeof(E).FullName));

        public Index<SymLiteralRow> EmitLiterals<E>(FS.FilePath dst)
            where E : unmanaged, Enum
        {
            var flow = EmittingTable<SymLiteralRow>(dst);
            var rows = Symbols.literals<E>();
            var count = rows.Length;
            var formatter = Tables.formatter<SymLiteralRow>();
            using var writer = dst.Writer();
            writer.WriteLine(formatter.FormatHeader());
            for(var i=0; i<count; i++)
                writer.WriteLine(formatter.Format(rows[i]));
            EmittedTable<SymLiteralRow>(flow, count);
            return rows;
        }

        public Index<SymLiteralRow> EmitLiterals(Assembly[] src, FS.FilePath dst)
        {
            var rows = Symbols.literals(src);
            TableEmit(rows.View, dst);
            return rows;
        }

        public ReadOnlySpan<Sym<K>> EmitSymbols<K>(FS.FolderPath dir)
            where K : unmanaged, Enum
        {
            var symbols = Symbols.index<K>().View;
            EmitSymbols(symbols, dir);
            return symbols;
        }

        public void EmitSymbols<K>(ReadOnlySpan<Sym<K>> src, FS.FolderPath dir)
            where K : unmanaged
        {
            var dst  = dir + FS.file(typeof(K).Name.ToLower(), FS.Csv);
            var count = src.Length;
            if(count != 0)
            {
                var flow = EmittingFile(dst);
                using var writer = dst.Writer();
                writer.WriteLine(Symbols.header());
                for(var i=0; i<count; i++)
                    writer.WriteLine(skip(src,i));
                EmittedFile(flow, count);
            }
        }

        public Index<SymInfo> EmitTokenSpecs(Type src)
        {
            var tokens = Symbols.syminfo(src);
            WfEmit.TableEmit(tokens, SymTargets().Table<SymInfo>("tokens" + "." +  src.Name.ToLower()));
            return tokens;
        }

        public Index<SymInfo> LoadTokenSpecs(string name)
        {
            var src = SymTargets().Table<SymInfo>("tokens" + "." +  name.ToLower());
            using var reader = src.TableReader<SymInfo>(SymbolicParse.parse);
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

        public Index<SymLiteralRow> LoadLiterals(FS.FilePath src)
        {
            using var reader = src.TableReader<SymLiteralRow>(SymbolicParse.parse);
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
    }
}