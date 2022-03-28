//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using System.Linq;

    partial class XedRules
    {
        public class RuleTableSet
        {
            internal class Buffers
            {
                public readonly ConcurrentDictionary<RuleSig,Index<RuleCellSpec>> Cells = new();

                public readonly ConcurrentDictionary<RuleTableKind,Index<RuleTable>> Defs = new();

                public readonly ConcurrentDictionary<RuleSig,Index<RuleTableRow>> Rows = new();

                public readonly ConcurrentDictionary<RuleTableKind,Index<RuleTableSpec>> Specs = new();

                public Index<RuleSchema> Schema = sys.empty<RuleSchema>();

                public Index<RuleSigRow> Sigs = sys.empty<RuleSigRow>();

                public static Buffers Empty => new();
            }

            public ref readonly ConcurrentDictionary<RuleSig,Index<RuleCellSpec>> Cells
            {
                [MethodImpl(Inline)]
                get => ref Data.Cells;
            }

            public ref readonly ConcurrentDictionary<RuleTableKind,Index<RuleTable>> Defs
            {
                [MethodImpl(Inline)]
                get => ref Data.Defs;
            }

            public ref readonly ConcurrentDictionary<RuleTableKind,Index<RuleTableSpec>> Specs
            {
                get => ref Data.Specs;
            }

            Index<RuleTableRow> _AllRows;

            ConstLookup<RuleTableKind,Index<RuleTableRow>> _RowsByKind;

            ConcurrentDictionary<RuleSig,Index<RuleTableRow>> _RowsBySig;

            public Index<RuleTableRow> Rows(RuleTableKind kind)
                => _RowsByKind[kind];

            public Index<RuleTableRow> Rows(RuleSig sig)
                => _RowsBySig[sig];

            public Index<RuleTableRow> Rows()
                =>_AllRows;

            public ref readonly Index<RuleSchema> Schema
            {
                [MethodImpl(Inline)]
                get => ref Data.Schema;
            }

            public ref readonly Index<RuleSigRow> SigRows
            {
                [MethodImpl(Inline)]
                get => ref Data.Sigs;
            }

            ConstLookup<string,Index<RuleSchema>> SchemaLookup;

            Buffers Data = Buffers.Empty;

            public RuleTableSet()
            {

            }

            internal Buffers CreateBuffers()
                => new();

            internal RuleTableSet Seal(Buffers src)
            {
                Data = src;
                var dst = cdict<string,ConcurrentBag<RuleSchema>>();
                iter(Schema, row => {
                if(dst.TryGetValue(row.TableName, out var bag))
                    bag.Add(row);
                    else
                    {
                        bag = new();
                        bag.Add(row);
                        dst.TryAdd(row.TableName,bag);
                    }
                });

                SchemaLookup = dst.Keys.Map(name => (name,dst[name].ToIndex())).ToDictionary();
                _RowsBySig = src.Rows;
                _AllRows = src.Rows.Values.SelectMany(x => x).ToIndex().Sort();
                _RowsByKind = _AllRows.GroupBy(x => x.TableKind).Map(x => (x.Key,x.ToIndex())).ToConstLookup();
                return this;
            }

            public FS.FileUri FindTablePath(string name)
            {
                if(SchemaLookup.Find(name, out var schema))
                {
                    if(schema.IsNonEmpty)
                        return schema.First.TableDef;
                }
                return FS.FileUri.Empty;
            }
        }
    }
}