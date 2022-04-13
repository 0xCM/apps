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
                public readonly ConcurrentDictionary<RuleTableKind,Index<TableCriteria>> Criteria = new();

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

            Index<TableCriteria> _EncCriteria;

            Index<TableCriteria> _DecCriteria;

            Index<TableCriteria> _Criteria;

            [MethodImpl(Inline)]
            public ref readonly Index<TableCriteria> Criteria()
                => ref _Criteria;

            SortedLookup<RuleSig,TableCriteria> _CriteriaLookup;

            public TableCriteria Criteria(in RuleSig sig)
            {
                if(_CriteriaLookup.Find(sig,out var spec))
                    return spec;
                else
                    return XedRules.TableCriteria.Empty;
            }

            Dictionary<RuleSig,FS.FilePath> TablePaths;

            public FS.FileUri FindTablePath(Nonterminal src)
            {
                var name = src.Name;
                var path = FS.FilePath.Empty;
                if(!TablePaths.TryGetValue(new (RuleTableKind.Dec,name), out path))
                    TablePaths.TryGetValue(new (RuleTableKind.Enc,name), out path);
                return path;
            }

            TableSpecs _Specs;

            [MethodImpl(Inline)]
            public ref readonly TableSpecs Specs()
                => ref _Specs;

            public TableSpec Spec(RuleSig sig)
            {
                var dst = TableSpec.Empty;
                Specs().Find(sig,out dst);
                return dst;
            }

            Buffers Data = Buffers.Empty;

            public RuleTables()
            {

            }

            internal RuleTables Seal(Buffers src, bool pll)
            {
                Data = src;
                var specs = SealCriteria();
                exec(pll,
                    SealTableDefs,
                    SealPaths,
                    () => _Specs = CalcRowSpecs(specs)
                    );
                return this;
            }

            internal Buffers CreateBuffers()
                => new();

            void SealPaths()
            {
                var paths = dict<RuleSig,FS.FilePath>();
                foreach(var spec in _EncCriteria)
                    paths.TryAdd(spec.Sig, XedPaths.Service.TableDef(spec.Sig));
                foreach(var spec in _DecCriteria)
                    paths.TryAdd(spec.Sig, XedPaths.Service.TableDef(spec.Sig));
                TablePaths = paths;
            }

            Index<TableCriteria> SealCriteria()
            {
                var enc = Data.Criteria[RuleTableKind.Enc];
                var dec = Data.Criteria[RuleTableKind.Dec];
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

                _EncCriteria = enc;
                _DecCriteria = dec;
                _Criteria = specs;
                _CriteriaLookup = specs.Map(x => (x.Sig,x)).ToDictionary();
                return specs;
            }

            void SealTableDefs()
            {
                var specs = Criteria();
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