//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;

    partial class XedRules
    {
        public class RuleTables
        {
            internal class Buffers
            {
                public readonly ConcurrentDictionary<RuleTableKind,Index<TableCriteria>> Specs = new();

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

            Index<TableCriteria> _EncTableSpecs;

            Index<TableCriteria> _DecTableSpecs;

            Index<TableCriteria> _TableSpecs;

            [MethodImpl(Inline)]
            public ref readonly Index<TableCriteria> TableSpecs()
                => ref _TableSpecs;

            SortedLookup<RuleSig,TableCriteria> _TableSpecLookup;

            public TableCriteria TableSpec(in RuleSig sig)
            {
                if(_TableSpecLookup.Find(sig,out var spec))
                    return spec;
                else
                    return XedRules.TableCriteria.Empty;
            }

            //Index<TableDefRow> DefRowIndex;

            // [MethodImpl(Inline)]
            // public ref readonly Index<TableDefRow> DefRows()
            //     => ref DefRowIndex;

            Dictionary<RuleSig,FS.FilePath> TablePaths;

            public FS.FileUri FindTablePath(Nonterminal src)
            {
                var name = src.Name;
                var path = FS.FilePath.Empty;
                if(!TablePaths.TryGetValue(new (RuleTableKind.Dec,name), out path))
                    TablePaths.TryGetValue(new (RuleTableKind.Enc,name), out path);
                return path;
            }

            SortedLookup<ushort,Index<RowSpec>> RowSpecLookup;

            [MethodImpl(Inline)]
            public ref readonly SortedLookup<ushort,Index<RowSpec>> RowSpecs()
                => ref RowSpecLookup;

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
                    () => RowSpecLookup = CalcRowSpecs(specs)
                    );
                return this;
            }

            internal Buffers CreateBuffers()
                => new();

            void SealPaths()
            {
                var paths = dict<RuleSig,FS.FilePath>();
                foreach(var spec in _EncTableSpecs)
                    paths.TryAdd(spec.Sig, XedPaths.Service.TableDef(spec.Sig));
                foreach(var spec in _DecTableSpecs)
                    paths.TryAdd(spec.Sig, XedPaths.Service.TableDef(spec.Sig));
                TablePaths = paths;
            }

            Index<TableCriteria> SealTableSpecs()
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
            }

           public static RuleTables Empty => new();
        }
    }
}