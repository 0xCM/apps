//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static core;

    partial class XedRules
    {
        public class RuleTables
        {
            internal class Buffers
            {
                public readonly ConcurrentDictionary<RuleTableKind,Index<TableSpec>> Specs = new();

                public static Buffers Empty => new();
            }

            Index<RuleSigRow> _SigRows;

            public ref readonly Index<RuleSigRow> SigRows
            {
                [MethodImpl(Inline)]
                get => ref _SigRows;
            }

            Index<RuleSig> SigIndex;

            [MethodImpl(Inline)]
            public ref readonly Index<RuleSig> Sigs()
                => ref SigIndex;

            HashSet<RuleSig> SigSet;

            public bool IsTableDefind(in RuleSig src)
                => SigSet.Contains(src);

            Index<TableSpec> _EncTableSpecs;

            [MethodImpl(Inline)]
            public ref readonly Index<TableSpec> EncTableSpecs()
                => ref _EncTableSpecs;

            Index<TableSpec> _DecTableSpecs;

            [MethodImpl(Inline)]
            public ref readonly Index<TableSpec> DecTableSpecs()
                => ref _DecTableSpecs;

            Index<TableSpec> _TableSpecs;

            [MethodImpl(Inline)]
            public ref readonly Index<TableSpec> TableSpecs()
                => ref _TableSpecs;

            SortedLookup<RuleSig,TableSpec> _TableSpecLookup;

            public TableSpec TableSpec(in RuleSig sig)
            {
                if(_TableSpecLookup.Find(sig,out var spec))
                    return spec;
                else
                    return XedRules.TableSpec.Empty;
            }

            Index<TableDefRow> DefRowIndex;

            [MethodImpl(Inline)]
            public ref readonly Index<TableDefRow> DefRows()
                => ref DefRowIndex;

            Dictionary<RuleSig,FS.FilePath> TablePaths;

            public FS.FileUri FindTablePath(Nonterminal src)
            {
                var name = src.Name;
                var path = FS.FilePath.Empty;
                if(!TablePaths.TryGetValue(new (RuleTableKind.Dec,name), out path))
                    TablePaths.TryGetValue(new (RuleTableKind.Enc,name), out path);
                return path;
            }

            SortedLookup<ushort,Index<CellRows>> CellRowLookup;

            [MethodImpl(Inline)]
            public ref readonly SortedLookup<ushort,Index<CellRows>> RowLookup()
                => ref CellRowLookup;

            Buffers Data = Buffers.Empty;

            public RuleTables()
            {

            }

            internal RuleTables Seal(Buffers src, bool pll)
            {
                Data = src;
                var specs = SealTableSpecs();
                exec(pll,
                    SealTableDefs,
                    SealPaths,
                    () => CellRowLookup = CalcRowLookup(specs)
                    );
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

            Index<TableSpec> SealTableSpecs()
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
                _TableSpecLookup = specs.Map(x => (x.Sig,x)).ToDictionary();
                return specs;
            }

            void SealTableDefs()
            {
                var specs = TableSpecs();
                SigIndex = alloc<RuleSig>(specs.Count);
                _SigRows = alloc<RuleSigRow>(specs.Count);
                SigSet = new();
                for(var i=0u; i<specs.Count; i++)
                {
                    ref readonly var spec = ref specs[i];
                    ref readonly var sig = ref spec.Sig;
                    SigIndex[i] = sig;
                    SigSet.Add(sig);

                    ref var row = ref _SigRows[i];
                    row.Seq = i;
                    row.TableKind = spec.TableKind;
                    row.TableName = spec.TableName;
                    row.TableDef = XedPaths.Service.TableDef(sig);
                }

                DefRowIndex = TableCalcs.rows(specs);
            }

           public static RuleTables Empty => new();
        }
    }
}