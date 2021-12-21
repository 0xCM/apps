//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.IO;

    using static core;

    public sealed class Symbolism : AppService<Symbolism>
    {
        public Index<ClrEnumRecord> EmitEnums(Assembly src, FS.FilePath dst)
        {
            var records = Enums.records(src);
            if(records.Length != 0)
                TableEmit(@readonly(records), dst);
            return records;
        }

        IApiCatalog ApiRuntimeCatalog => Service(ApiRuntimeLoader.catalog);

        public Index<SymHeapEntry> EmitSymHeap()
        {
            var literals = Symbols.literals(ApiRuntimeCatalog.Components);
            var heap = SymHeaps.define(literals);
            var count = heap.SymbolCount;
            var entries = SymHeaps.entries(heap);
            var dst = ProjectDb.ApiTablePath<SymHeapEntry>();
            TableEmit(entries.View, SymHeapEntry.RenderWidths, dst);
            return entries;
        }

        public ReadOnlySpan<SymLiteralRow> EmitLiterals()
            => EmitLiterals(ProjectDb.ApiTablePath<SymLiteralRow>());

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
        /// <typeparam name="E">The defining type</typeparam>
        public Index<SymLiteralRow> EmitLiterals<E>()
            where E : unmanaged, Enum
                => EmitLiterals<E>(ProjectDb.ApiTablePath<SymLiteralRow>(typeof(E).FullName));

        public void EmitSymbolSpan<E>(Identifier name, FS.FolderPath dst)
            where E : unmanaged, Enum
        {
            var path = dst + FS.file(name.Format(), FS.Cs);
            using var writer = path.Writer();
            EmitSymbolSpan<E>(name,writer);
        }

        public void EmitSymbolSpan<E>(Identifier name, StreamWriter dst)
            where E : unmanaged, Enum
        {
            var buffer = text.buffer();
            SpanRes.symrender<E>(name, buffer);
            dst.WriteLine(buffer.Emit());
        }

        public Index<SymLiteralRow> EmitLiterals<E>(FS.FilePath dst)
            where E : unmanaged, Enum
        {
            var flow = EmittingTable<SymLiteralRow>(dst);
            var rows = Symbols.literals<E>();
            var count = rows.Length;
            var formatter = Tables.formatter<SymLiteralRow>(SymLiteralRow.RenderWidths);
            using var writer = dst.Writer();
            writer.WriteLine(formatter.FormatHeader());
            for(var i=0; i<count; i++)
                writer.WriteLine(formatter.Format(skip(rows,i)));
            EmittedTable<SymLiteralRow>(flow, count);
            return rows;
        }

        public Index<SymLiteralRow> EmitLiterals(Assembly[] src, FS.FilePath dst)
        {
            var rows = Symbols.literals(src);
            TableEmit(rows.View, SymLiteralRow.RenderWidths, dst);
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
            var dst = ProjectDb.ApiTablePath<SymInfo>("tokens", src.Name.ToLower());
            var tokens = Symbols.syminfo(src);
            TableEmit(tokens.View, SymInfo.RenderWidths, dst);
            return tokens;
        }

        public Index<SymInfo> LoadTokenSpecs(string name)
        {
            var src = ProjectDb.ApiTablePath<SymInfo>("tokens", name.ToLower());
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
                Error(AppMsg.FieldCountMismatch.Format(SymLiteralRow.FieldCount,header.Length));
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