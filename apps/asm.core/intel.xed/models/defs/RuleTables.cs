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
                public readonly ConcurrentDictionary<RuleSig,Index<RuleCellSpec>> Cells = new();

                public readonly ConcurrentDictionary<RuleTableKind,Index<RuleTable>> Defs = new();

                public readonly ConcurrentDictionary<RuleTableKind,Index<RuleTableSpec>> Specs = new();

                public Index<RuleSchema> Schema = sys.empty<RuleSchema>();

                public Index<RuleSigRow> Sigs = sys.empty<RuleSigRow>();

                public static Buffers Empty => new();
            }

            public ref readonly ConcurrentDictionary<RuleTableKind,Index<RuleTableSpec>> Specs
            {
                get => ref Data.Specs;
            }

            SortedLookup<RuleSig,RuleTable> TableDefs;

            Dictionary<RuleSig,FS.FilePath> TablePaths;

            [MethodImpl(Inline)]
            public ReadOnlySpan<RuleTable> Tables()
                => TableDefs.Values;

            [MethodImpl(Inline)]
            public RuleTable Table(in RuleSig sig)
            {
                if(TableDefs.Find(sig, out var def))
                    return def;
                else
                    return RuleTable.Empty;
            }

            [MethodImpl(Inline)]
            public ReadOnlySpan<RuleSig> Sigs()
                => TableDefs.Keys;

            public ref readonly Index<RuleSchema> Schema
            {
                [MethodImpl(Inline)]
                get => ref Data.Schema;
            }

            public ref readonly Index<RuleSigRow> SigInfo
            {
                [MethodImpl(Inline)]
                get => ref Data.Sigs;
            }

            public FS.FileUri FindTablePath(Nonterminal nt)
            {
                var name = nt.Name;
                var path = FS.FilePath.Empty;
                if(!TablePaths.TryGetValue(new (RuleTableKind.Dec,name), out path))
                    TablePaths.TryGetValue(new (RuleTableKind.Enc,name), out path);
                return path;
            }

            Buffers Data = Buffers.Empty;

            public RuleTables()
            {

            }

            internal Buffers CreateBuffers()
                => new();

            void SealPaths()
            {
                var paths = dict<RuleSig,FS.FilePath>();
                foreach(var spec in Data.Specs[RuleTableKind.Enc])
                    paths.TryAdd(spec.Sig, XedPaths.Service.TableDef(spec.Sig));
                foreach(var spec in Data.Specs[RuleTableKind.Dec])
                    paths.TryAdd(spec.Sig, XedPaths.Service.TableDef(spec.Sig));

                TablePaths = paths;
            }

            void SealTableDefs()
            {
                var tables = Data.Defs.Values.SelectMany(x => x).Array();
                var count = tables.Length;
                var buffer = dict<RuleSig,RuleTable>(count);
                for(var i=0; i<count; i++)
                {
                    ref readonly var table = ref tables[i];
                    if(buffer.TryGetValue(table.Sig, out var t))
                        buffer[table.Sig] = t.WithBody(table.Body);
                    else
                        buffer.Add(table.Sig, table);
                }
                TableDefs = buffer;
            }

            internal RuleTables Seal(Buffers src, bool pll)
            {
                Data = src;
                exec(pll, SealTableDefs,SealPaths);
                return this;
            }

            public static RuleTables Empty => new();
        }
    }
}