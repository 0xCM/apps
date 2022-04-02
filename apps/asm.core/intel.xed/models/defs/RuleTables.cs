//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using static XedModels;
    using static core;

    partial class XedRules
    {
        public class RuleTables
        {
            internal class Buffers
            {
                public readonly ConcurrentDictionary<RuleTableName,Index<RuleCellSpec>> Cells = new();

                public readonly ConcurrentDictionary<RuleTableKind,Index<RuleTable>> Defs = new();

                public readonly ConcurrentDictionary<RuleTableName,Index<RuleTableRow>> Rows = new();

                public readonly ConcurrentDictionary<RuleTableKind,Index<RuleTableSpec>> Specs = new();

                public Index<RuleSchema> Schema = sys.empty<RuleSchema>();

                public Index<RuleSigRow> Sigs = sys.empty<RuleSigRow>();

                public static Buffers Empty => new();
            }

            public ref readonly ConcurrentDictionary<RuleTableKind,Index<RuleTableSpec>> Specs
            {
                get => ref Data.Specs;
            }

            Index<RuleTableRow> TableRows;

            Dictionary<string,RuleSigRow> EncSigs = new();

            Dictionary<string,RuleSigRow> DecSigs = new();

            SortedLookup<RuleTableName,Index<RuleTableRow>> RowLookup;

            SortedLookup<string,Index<RuleTableRow>> EncTableLookup;

            SortedLookup<string,Index<RuleTableRow>> DecTableLookup;

            public Index<RuleTableRow> Rows()
                => TableRows;

            public Index<RuleTableRow> Table(RuleTableName name)
            {
                if(RowLookup.Find(name, out var rows))
                    return rows;
                else
                    return sys.empty<RuleTableRow>();
            }

            public ReadOnlySpan<RuleTableName> TableNames
            {
                [MethodImpl(Inline)]
                get => RowLookup.Keys;
            }

            public Index<RuleTableRow> EncTable(string name)
            {
                if(EncTableLookup.Find(name, out var rows))
                    return rows;
                else
                    return sys.empty<RuleTableRow>();
            }

            public Index<RuleTableRow> DecTable(string name)
            {
                if(DecTableLookup.Find(name, out var rows))
                    return rows;
                else
                    return sys.empty<RuleTableRow>();
            }

            public ReadOnlySpan<Index<RuleTableRow>> EncTables
            {
                [MethodImpl(Inline)]
                get => EncTableLookup.Values;
            }

            public ReadOnlySpan<Index<RuleTableRow>> DecTables
            {
                [MethodImpl(Inline)]
                get => DecTableLookup.Values;
            }

            public ref readonly Index<RuleSchema> Schema
            {
                [MethodImpl(Inline)]
                get => ref Data.Schema;
            }

            public ref readonly Index<RuleSigRow> Sigs
            {
                [MethodImpl(Inline)]
                get => ref Data.Sigs;
            }

            Buffers Data = Buffers.Empty;

            public RuleTables()
            {

            }

            internal Buffers CreateBuffers()
                => new();

            void SealSigs()
            {
                foreach(var sig in Sigs)
                {
                    if(sig.TableKind == RuleTableKind.Enc)
                        EncSigs.TryAdd(sig.TableName, sig);
                    else if(sig.TableKind == RuleTableKind.Dec)
                        DecSigs.TryAdd(sig.TableName, sig);
                }
            }

            void SealSchema()
            {
                var dst = cdict<string,ConcurrentBag<RuleSchema>>();
                iter(Schema, schema => {
                if(dst.TryGetValue(schema.TableName, out var bag))
                    bag.Add(schema);
                    else
                    {
                        bag = new();
                        bag.Add(schema);
                        dst.TryAdd(schema.TableName,bag);
                    }
                });
            }

            void SealRows()
            {
                var all = Data.Rows.Values.SelectMany(x => x).ToIndex().Sort();
                for(var i=0u; i<all.Count; i++)
                    all[i].Seq = i;
                TableRows = all;
            }

            void SealLookups()
            {
                RowLookup = lookup(TableRows);
                EncTableLookup = tables(RuleTableKind.Enc, TableRows);
                DecTableLookup = tables(RuleTableKind.Dec, TableRows);
            }

            internal RuleTables Seal(Buffers src, bool pll)
            {
                Data = src;
                exec(pll, SealSchema, SealSigs, SealRows);
                SealLookups();
                return this;
            }

            FS.FileUri FindTablePath(RuleTableKind kind, string name)
            {
                var sig = default(RuleSigRow);
                if(kind == RuleTableKind.Dec)
                    DecSigs.TryGetValue(name, out sig);
                else if(kind == RuleTableKind.Enc)
                    EncSigs.TryGetValue(name, out sig);
                return sig.TableDef;
            }

            public FS.FileUri FindTablePath(RuleTableName name)
                => XedPaths.Service.TableDef(name).ToUri();

            public FS.FileUri FindTablePath(Nonterminal nt)
            {
                var name = nt.Name;
                var path = FindTablePath(RuleTableKind.Dec, name);
                if(path.IsEmpty)
                   path = FindTablePath(RuleTableKind.Enc, name);
                return path;
            }

            static SortedLookup<RuleTableName,Index<RuleTableRow>> lookup(Index<RuleTableRow> src)
                => src.GroupBy(x => x.FullTableName).Select(x => (x.Key, x.ToIndex())).ToDictionary();

            static Dictionary<string,Index<RuleTableRow>> tables(RuleTableKind kind, Index<RuleTableRow> rows)
                => rows.Where(row => row.Kind == kind).GroupBy(x => x.TableName).Select(x=> (x.Key,x.ToIndex())).ToDictionary();


            public static RuleTables Empty => new();
        }
    }
}