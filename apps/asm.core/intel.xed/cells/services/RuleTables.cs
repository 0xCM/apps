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
        public partial class RuleTables
        {
            public static Index<RuleCell> linearize(Pairings<RuleSig,Index<RuleCell>> src)
                => src.Array().SelectMany(x => x.Right).Sort();

            [MethodImpl(Inline)]
            public static RuleCell cell(CellMetrics metrics, CellValue value)
                => new (metrics,value);

            [MethodImpl(Inline)]
            public static RuleCell cell(CellMetrics metrics, RuleOperator op)
                => new (metrics, new CellValue(op));

            [MethodImpl(Inline)]
            public static CellMetrics metrics(CellKey key)
                => new CellMetrics(key, XedFields.size(key.Field,key.CellType));

            internal class Buffers
            {
                public readonly ConcurrentDictionary<RuleTableKind,Index<TableCriteria>> Criteria = new();

                public static Buffers Empty => new();
            }

            Index<TableCriteria> _Criteria;

            TableSpecs _Specs;

            [MethodImpl(Inline)]
            public ref readonly Index<TableCriteria> Criteria()
                => ref _Criteria;

            [MethodImpl(Inline)]
            public ref readonly TableSpecs Specs()
                => ref _Specs;

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
                _Specs = CellParser.specs(criteria);
                _Criteria = criteria;
            }

            static Index<TableCriteria> sort(ConcurrentDictionary<RuleTableKind,Index<TableCriteria>> src)
            {
                var enc = src[RuleTableKind.ENC];
                var dec = src[RuleTableKind.DEC];
                var specs = enc.Append(dec).Where(x => x.IsNonEmpty).Sort();
                for(var i=0u; i<specs.Count; i++)
                    specs[i] = specs[i].WithId(i);
                return specs;
            }

           public static RuleTables Empty => new();
        }
    }
}