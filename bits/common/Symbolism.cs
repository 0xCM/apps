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

        DbTargets ApiTargets()
            => AppDb.Targets("api");

        /// <summary>
        /// Discovers symbolic literals defined in a specified component collection
        /// </summary>
        public Index<SymLiteralRow> CalcSymLits(Assembly[] src)
            => Symbols.literals(src);

        /// <summary>
        /// Discovers symbolic literals defined in the api catalog
        /// </summary>
        public Index<SymLiteralRow> CalcSymLits()
            => Data(nameof(SymLiteralRow), () => Symbols.literals(ApiRuntimeCatalog.Components));

        /// <summary>
        /// Discovers the symbolic literals for parametrically-identified symbol type
        /// </summary>
        /// <typeparam name="E">The symbol type</typeparam>
        public Index<SymLiteralRow> CalcSymLits<E>()
            where E : unmanaged, Enum
                => Symbols.literals<E>();

        /// <summary>
        /// Computes a <see cref='SymHeap'/> for a parametrically-identified symbol type
        /// </summary>
        /// <typeparam name="E">The symbol type</typeparam>
        public SymHeap CalcSymHeap<E>()
            where E : unmanaged, Enum
                => SymHeaps.create(CalcSymLits<E>());

        public SymHeap CalcSymHeap(Index<SymLiteralRow> src)
            => Data(nameof(SymHeap), () => SymHeaps.create(src));

        Index<SymHeapEntry> CalcEntries(SymHeap src)
            => Data(SymHeap.id(src),() => SymHeaps.entries(src));

        public void EmitSymHeap(SymHeap src, FS.FilePath dst)
            => AppSvc.TableEmit(CalcEntries(src), dst);

        public void EmitSymHeap(SymHeap src)
            => AppSvc.TableEmit(CalcEntries(src), ApiTargets().Table<SymHeapEntry>(), TextEncodingKind.Unicode);

        public Index<ClrEnumRecord> EmitEnums(Assembly src, FS.FilePath dst)
        {
            var records = Enums.records(src);
            if(records.Length != 0)
                TableEmit(@readonly(records), dst);
            return records;
        }

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
            var rows = CalcSymLits(src);
            AppSvc.TableEmit(rows, dst, TextEncodingKind.Unicode);
            return rows;
        }

        public Index<SymInfo> EmitTokens(Type src)
        {
            var tokens = Symbols.syminfo(src);
            WfEmit.TableEmit(tokens, ApiTargets().Table<SymInfo>("tokens" + "." +  src.Name.ToLower()));
            return tokens;
        }

        public Index<SymInfo> LoadTokens(string name)
        {
            var src = ApiTargets().Table<SymInfo>("tokens" + "." +  name.ToLower());
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