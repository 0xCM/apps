//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

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

            Index<RuleSig> _SigIndex;

            Index<TableCriteria> _Criteria;

            TableSpecs _Specs;

            HashSet<RuleSig> _SigSet;

            [MethodImpl(Inline)]
            public ref readonly Index<RuleSig> Sigs()
                => ref _SigIndex;

            public ref readonly Index<RuleSigRow> SigRows
            {
                [MethodImpl(Inline)]
                get => ref _SigRows;
            }

            public bool IsTableDefind(in RuleSig src)
                => _SigSet.Contains(src);

            [MethodImpl(Inline)]
            public ref readonly Index<TableCriteria> Criteria()
                => ref _Criteria;

            [MethodImpl(Inline)]
            public ref readonly TableSpecs Specs()
                => ref _Specs;

            public TableSpec Spec(RuleSig sig)
            {
                var dst = TableSpec.Empty;
                Specs().Find(sig, out dst);
                return dst;
            }

            Buffers Data = Buffers.Empty;

            public RuleTables()
            {

            }

            internal Buffers CreateBuffers()
                => new();

            internal void Seal(Buffers src, bool pll)
            {
                Data = src;
                var criteria = sort(src.Criteria);
                var count = criteria.Count;
                var sigs =  alloc<RuleSig>(count);
                var rows = alloc<RuleSigRow>(count);
                var sigset = hashset<RuleSig>();
                _Specs = CellParser.specs(criteria);
                _Criteria = criteria;
                _SigIndex = sigs;
                _SigRows = rows;
                _SigSet = sigset;
                for(var i=0u; i<count; i++)
                {
                    ref readonly var spec = ref criteria[i];
                    ref readonly var sig = ref spec.Sig;
                    sigs[i] = sig;
                    sigset.Add(sig);
                    ref var row = ref rows[i];
                    row.Seq = i;
                    row.Sig = sig;
                    row.TableDef = XedPaths.Service.TableDef(sig);
                }
            }

            static Index<TableCriteria> sort(ConcurrentDictionary<RuleTableKind,Index<TableCriteria>> src)
            {
                var enc = src[RuleTableKind.ENC];
                var dec = src[RuleTableKind.DEC];
                var specs = enc.Append(dec).Sort();
                for(var i=0u; i<specs.Count; i++)
                    specs[i] = specs[i].WithId(i);
                return specs;
            }

           public static RuleTables Empty => new();
        }
    }
}