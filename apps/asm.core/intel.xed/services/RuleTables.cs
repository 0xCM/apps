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
                public readonly ConcurrentDictionary<RuleTableKind,Index<RuleTable>> Defs = new();

                public readonly ConcurrentDictionary<RuleTableKind,Index<RuleTableSpec>> Specs = new();

                public Index<RuleSchema> Schema = sys.empty<RuleSchema>();

                public Index<RuleSigRow> Sigs = sys.empty<RuleSigRow>();

                public static Buffers Empty => new();
            }

            Index<RuleTable> TableDefIndex;

            SortedLookup<RuleSig,RuleTable> TableDefLookup;

            Dictionary<RuleSig,FS.FilePath> TablePaths;

            Index<TableDefRow> DefRowIndex;

            SortedLookup<RuleSig,Index<TableDefRow>> DefRowLookup;

            Index<RuleTableSpec> _EncTableSpecs;

            Index<RuleTableSpec> _DecTableSpecs;

            Index<RuleTableSpec> _TableSpecs;

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

            [MethodImpl(Inline)]
            public ref readonly Index<RuleTableSpec> EncTableSpecs()
                => ref _EncTableSpecs;

            [MethodImpl(Inline)]
            public ref readonly Index<RuleTableSpec> DecTableSpecs()
                => ref _DecTableSpecs;

            [MethodImpl(Inline)]
            public ref readonly Index<RuleTableSpec> TableSpecs(RuleTableKind kind)
            {
                if(kind == RuleTableKind.Enc)
                    return ref EncTableSpecs();
                else
                    return ref DecTableSpecs();
            }

            [MethodImpl(Inline)]
            public ref readonly Index<RuleTableSpec> TableSpecs()
                => ref _TableSpecs;

            [MethodImpl(Inline)]
            public ref readonly Index<TableDefRow> DefRows()
                => ref DefRowIndex;

            public Index<TableDefRow> DefRows(in RuleSig sig)
            {
                var dst = Index<TableDefRow>.Empty;
                DefRowLookup.Find(sig, out dst);
                return dst;
            }

            [MethodImpl(Inline)]
            public ref readonly Index<RuleTable> Tables()
                => ref TableDefIndex;

            [MethodImpl(Inline)]
            public RuleTable Table(in RuleSig sig)
            {
                var dst = RuleTable.Empty;
                TableDefLookup.Find(sig, out dst);
                return dst;
            }

            [MethodImpl(Inline)]
            public ReadOnlySpan<RuleSig> Sigs()
                => TableDefLookup.Keys;

            public FS.FileUri FindTablePath(Nonterminal src)
            {
                var name = src.Name;
                var path = FS.FilePath.Empty;
                if(!TablePaths.TryGetValue(new (RuleTableKind.Dec,name), out path))
                    TablePaths.TryGetValue(new (RuleTableKind.Enc,name), out path);
                return path;
            }

            Buffers Data = Buffers.Empty;

            public RuleTables()
            {

            }

            internal RuleTables Seal(Buffers src, bool pll)
            {
                Data = src;
                SealTableSpecs();
                exec(pll, SealTableDefs, SealPaths);
                return this;
            }

            internal Buffers CreateBuffers()
                => new();

            void SealPaths()
            {
                var paths = dict<RuleSig,FS.FilePath>();
                foreach(var spec in EncTableSpecs())
                    paths.TryAdd(spec.Sig, XedPaths.Service.TableDef(spec.Sig));
                foreach(var spec in DecTableSpecs())
                    paths.TryAdd(spec.Sig, XedPaths.Service.TableDef(spec.Sig));
                TablePaths = paths;
            }

            void SealTableSpecs()
            {
                var enc = Data.Specs[RuleTableKind.Enc];
                var dec = Data.Specs[RuleTableKind.Dec];
                var specs = enc.Append(dec).Sort();
                for(var i=0u; i<specs.Count; i++)
                    specs[i] = specs[i].WithId(i);

                var j=0u;
                var k=0u;
                for(var i=0u; i<specs.Count; i++)
                {
                    ref readonly var spec = ref specs[i];
                    if(spec.IsEncTable)
                        enc[j++] = spec;
                    else
                        dec[k++] = spec;
                }

                _EncTableSpecs = enc;
                _DecTableSpecs = dec;
                _TableSpecs = specs;
            }

            void SealTableDefs()
            {
                DefRowIndex = RuleTableCalcs.CalcDefRows(TableSpecs());
                DefRowLookup = DefRowIndex.GroupBy(x => x.Sig).Select(x => (x.Key,x.Index())).ToDictionary();
                var tables = Data.Defs.Values.SelectMany(x => x).Array();
                var count = tables.Length;
                var defs = dict<RuleSig,RuleTable>(count);
                for(var i=0; i<count; i++)
                {
                    ref readonly var table = ref tables[i];
                    if(defs.TryGetValue(table.Sig, out var t))
                        defs[table.Sig] = t.WithBody(table.Body);
                    else
                        defs.Add(table.Sig, table);
                }

                TableDefLookup = defs;
                TableDefIndex = defs.Values.Array().Sort();
            }

           public static RuleTables Empty => new();
        }
    }
}