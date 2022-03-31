//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using static core;

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

            ref readonly ConcurrentDictionary<RuleSig,Index<RuleCellSpec>> Cells
            {
                [MethodImpl(Inline)]
                get => ref Data.Cells;
            }

            ref readonly ConcurrentDictionary<RuleTableKind,Index<RuleTable>> Defs
            {
                [MethodImpl(Inline)]
                get => ref Data.Defs;
            }

            public ref readonly ConcurrentDictionary<RuleTableKind,Index<RuleTableSpec>> Specs
            {
                get => ref Data.Specs;
            }

            Index<RuleTableRow> _AllRows;

            Dictionary<string,RuleSigRow> EncSigs = new();

            Dictionary<string,RuleSigRow> DecSigs = new();

            public Index<RuleTableRow> Rows()
                => _AllRows;

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

                foreach(var sig in Sigs)
                {
                    if(sig.TableKind == RuleTableKind.Enc)
                        EncSigs.TryAdd(sig.TableName, sig);
                    else if(sig.TableKind == RuleTableKind.Dec)
                        DecSigs.TryAdd(sig.TableName, sig);
                }

                var all = src.Rows.Values.SelectMany(x => x).ToIndex().Sort();
                for(var i=0u; i<all.Count; i++)
                {
                    ref var row = ref all[i];
                    row.Seq = i;
                }
                _AllRows = all;

                return this;
            }

            public FS.FileUri FindTablePath(RuleTableKind kind, string name)
            {
                var sig = default(RuleSigRow);
                if(kind == RuleTableKind.Dec)
                    DecSigs.TryGetValue(name, out sig);
                else if(kind == RuleTableKind.Enc)
                    EncSigs.TryGetValue(name, out sig);
                return sig.TableDef;
            }

            public FS.FileUri FindTablePath(string name)
            {
               var path = FindTablePath(RuleTableKind.Dec,name);
               if(path.IsEmpty)
                   path = FindTablePath(RuleTableKind.Enc,name);
                return path;
            }

            public static RuleTableSet Empty => new();
        }
    }
}